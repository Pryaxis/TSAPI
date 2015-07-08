using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
			sendThread = new Thread(WriteThread);
			sendThread.Name = client.Id + " - Network I/O Thread - " + client.Name;
			sendThread.Start();

			Console.WriteLine("IO thread - slot {0}", client.Id);
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
				}

				__segment_release_internal((ArraySegment<byte>)ar.AsyncState);
			}
		}

		public void Enqueue(ArraySegment<byte> segment)
		{
			//Console.WriteLine("slot {0} Enqueued segment {1} @ {2}", client.Id, segment, sendQueue.Count);
			sendQueue.TryAdd(segment);
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

		public ArraySegment<byte> LockSegment(short size)
		{
			int previousSegmentEnd = 0;

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


				foreach (var bufferSegment in bufferSegments)
				{
					/*
					 * If this is the first segment and the distance between
					 * here and the start of the array is big enough to fit the
					 * segment then fit it at position 0.
					 */
					if (bufferSegment == bufferSegments.First() && bufferSegment.Offset >= size)
					{
						return __segment_lock_internal(0, size);
					}

					if (bufferSegment.Offset - previousSegmentEnd > size)
					{
						return __segment_lock_internal(previousSegmentEnd, size);
					}

					previousSegmentEnd += bufferSegment.Offset + bufferSegment.Count;
				}

				if (sendBuffer.Length - previousSegmentEnd >= size)
				{
					return __segment_lock_internal(previousSegmentEnd, size);
				}

				//The buffer must get bigger to accommodate
				Grow(size - previousSegmentEnd);
				return __segment_lock_internal(previousSegmentEnd, size);
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

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				threadCancelled = true;
				sendThread.Join();
				bufferSegments = null;
				sendBuffer = null;
			}
		}
	}
}
