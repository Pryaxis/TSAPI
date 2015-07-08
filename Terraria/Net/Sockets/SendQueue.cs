using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using Terraria.Net.Sockets.EventArgs;

namespace Terraria.Net.Sockets
{

	public class SendQueue : IDisposable
	{
		protected const int kSendQueueInitialBufferSize = 262144;
		protected volatile bool threadCancelled;
		protected byte[] sendBuffer;
		protected readonly object syncLock = new object();
		protected List<ArraySegment<byte>> bufferSegments;
		protected BlockingCollection<ArraySegment<byte>> sendQueue;
		protected Thread sendThread;
		protected RemoteClient client;

		public event EventHandler<WriteFailedEventArgs> WriteFailed;
		public event EventHandler BufferGrow;

		public int QueueLength { get { return bufferSegments.Count; } }

		public SendQueue(RemoteClient client)
		{
			this.client = client;
			bufferSegments = new List<ArraySegment<byte>>();
			sendQueue = new BlockingCollection<ArraySegment<byte>>();
			sendBuffer = new byte[kSendQueueInitialBufferSize];
		}

		public void StartThread()
		{
			threadCancelled = false;
			sendThread = new Thread(WriteThread);
			sendThread.Name = "Network I/O Thread - " + client.Id;
			sendThread.Start();
		}

		public static IEnumerable<ArraySegment<byte>> LockMultiple(IEnumerable<int> ids, short size)
		{
			List<ArraySegment<byte>> segments = new List<ArraySegment<byte>>(256);
			foreach (int id in ids)
			{
				segments.Add(Netplay.Clients[id].sendQueue.LockSegment(size));
			}

			return segments;
		}

		public static void WriteMultiple(IEnumerable<ArraySegment<byte>> segments, ref byte[] buffer)
		{
			foreach (ArraySegment<byte> arraySegment in segments)
			{
				Array.Copy(buffer, arraySegment.Array, arraySegment.Count);
			}
		}

		public static void EnqueueMultiple(IEnumerable<SendQueue> queues, IEnumerable<ArraySegment<byte>> segments)
		{
			foreach (SendQueue queue in queues)
			{
				foreach (var arraySegment in segments)
				{
					queue.Enqueue(arraySegment);
				}
			}
		}

		protected void WriteThread()
		{
			ArraySegment<byte> segment;
			SocketError? socketError = null;
			while (true)
			{
				if (threadCancelled == true)
				{
					break;
				}

				if (sendQueue.TryTake(out segment, TimeSpan.FromMilliseconds(100)) == false)
				{
					continue;
				}

				try
				{
					(client.Socket as TcpSocket)._connection.GetStream()
						.BeginWrite(segment.Array, segment.Offset, segment.Count, WriteCallback, segment);
				}
				catch (IOException ioe)
				{
					socketError = (ioe.InnerException as SocketException).SocketErrorCode;
				}
				catch (SocketException se)
				{
					socketError = se.SocketErrorCode;
				}
				catch (Exception)
				{
				}
				finally
				{
					if (WriteFailed != null && socketError.HasValue == true)
					{
						WriteFailed(this, new WriteFailedEventArgs() { ErrorCode = socketError.Value });
						__segment_release_internal(segment);
					}
				}
			}
		}

		private void WriteCallback(IAsyncResult ar)
		{
			SocketError? socketError = null;

			try
			{
				(client.Socket as TcpSocket)._connection.GetStream().EndWrite(ar);
			}
			catch (IOException ioe)
			{
				SocketException socketEx = ioe.InnerException as SocketException;

				if (socketEx != null)
				{
					socketError = (ioe.InnerException as SocketException).SocketErrorCode;
				}
			}
			catch (SocketException se)
			{
				socketError = se.SocketErrorCode;
			}
			catch (Exception)
			{
			}
			finally
			{
				if (WriteFailed != null && socketError.HasValue == true)
				{
					WriteFailed(this, new WriteFailedEventArgs() { ErrorCode = socketError.Value });
				}

				__segment_release_internal((ArraySegment<byte>)ar.AsyncState);
			}
		}

		public void Enqueue(ArraySegment<byte> segment)
		{
			//Console.WriteLine("slot {0} Enqueued segment {1} @ {2}", client.Id, segment, sendQueue.Count);
			sendQueue.TryAdd(segment);
		}

		public void CopyTo(ArraySegment<byte> segment, ref byte[] buffer)
		{
			Array.Copy(buffer, 0, segment.Array, segment.Offset, segment.Count);
		}

		protected void Grow(int sizeDelta)
		{
			try
			{
				Array.Resize<byte>(ref sendBuffer, sizeDelta);
			}
			catch (OutOfMemoryException)
			{
				Console.WriteLine("Grow failed: Out of memory asking for {0} bytes", sizeDelta);
			}
		}

		internal ArraySegment<byte> __segment_lock_internal(int offset, int size)
		{
			ArraySegment<byte> newSegment = new ArraySegment<byte>(sendBuffer, offset, size);

			__segment_lock_internal(newSegment);
	
			return newSegment;
		}

		internal void __segment_lock_internal(ArraySegment<byte> segment)
		{
			lock (syncLock)
			{
				foreach (ArraySegment<byte> bufferSegment in bufferSegments)
				{
					if (segment.Offset >= bufferSegment.Offset && (segment.Offset + segment.Count) <= (bufferSegment.Offset + bufferSegment.Count))
					{
						throw new Exception("Segment " + segment.Offset + " overlaps with locked segment " + bufferSegment.Offset);
					}
				}
				bufferSegments.Add(segment);
			}
				
			//Console.WriteLine("queue {0}: locked {1} bytes @ {2}/{3}", client.Id, segment.Count, segment.Offset, bufferSegments.Count);
		}

		internal void __segment_release_internal(ArraySegment<byte> segment)
		{
			lock (syncLock)
			{
				bufferSegments.Remove(segment);
			}
		}

		protected int DistanceBetween(ArraySegment<byte> from, ArraySegment<byte> to)
		{
			return to.Offset - (from.Offset + from.Count);
		}

		public ArraySegment<byte> LockSegment(short size)
		{
			ArraySegment<byte> thisSegment = default(ArraySegment<byte>);
			int lastSegmentEnd = 0;
			/*
			 * If there are no segments in the buffer, it is completely
			 * free.
			 */
			lock (syncLock)
			{
				if (bufferSegments.Count == 0)
				{
					return __segment_lock_internal(0, size);
				}

				for (int i = 0; i < bufferSegments.Count; i++)
				{
					ArraySegment<byte>? nextSegment = null;
					thisSegment = bufferSegments.OrderBy(seg => seg.Offset).ElementAt(i);

					/*
					 *
					 * If this is the first segment and the distance between
					 * here and the start of the array is big enough to fit the
					 * segment then fit it at position 0.
					 */
					if (bufferSegments.Count == 1 && i == 0 && thisSegment.Offset > size)
					{
						return __segment_lock_internal(0, size);
					}

					if (i < bufferSegments.Count - 1)
					{
						nextSegment = bufferSegments.OrderBy(seg => seg.Offset).ElementAt(i);
					}

					if (nextSegment.HasValue && DistanceBetween(thisSegment, nextSegment.Value) > size)
					{
						return __segment_lock_internal(thisSegment.Offset + thisSegment.Count, size);
					}

					lastSegmentEnd = thisSegment.Offset + thisSegment.Count;
				}

				/*
				 * Can it fit at the end?
				 */
				if (sendBuffer.Length - lastSegmentEnd > size)
				{
					return __segment_lock_internal(lastSegmentEnd, size);
				}

				//The buffer must get bigger to accommodate
				Grow(sendBuffer.Length - (thisSegment.Offset + thisSegment.Count));
				return __segment_lock_internal(thisSegment.Offset + thisSegment.Count, size);
			}
		}

		public BinaryWriter SegmentWriter(ArraySegment<byte> segment)
		{
			return new BinaryWriter(new MemoryStream(segment.Array, segment.Offset, segment.Count, true));
		}

		public BinaryWriter SegmentWriter(short size)
		{
			ArraySegment<byte> segment = LockSegment(size);
			return SegmentWriter(segment);
		}

		~SendQueue()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Reset()
		{
			if (sendThread != null)
			{
				threadCancelled = true;
				sendThread.Join();
			}
			bufferSegments.Clear();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (sendThread != null)
			{
				threadCancelled = true;
				sendThread.Join();
			}

			if (disposing)
			{
				bufferSegments = null;
				sendBuffer = null;
			}
		}
	}
}
