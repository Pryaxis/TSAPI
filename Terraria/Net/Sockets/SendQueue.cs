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
		protected const int kSendQueueInitialBufferSize = 1024 * 1024;
		protected volatile bool threadCancelled;
		protected byte[] sendBuffer;
		protected readonly object syncLock = new object();
		protected LinkedList<ArraySegment<byte>> bufferSegments;
		protected BlockingCollection<ArraySegment<byte>> sendQueue;
		protected Thread sendThread;
		protected RemoteClient client;

		public event EventHandler<WriteFailedEventArgs> WriteFailed;
		public event EventHandler BufferGrow;

		public int QueueLength { get { return bufferSegments.Count; } }

		public SendQueue(RemoteClient client)
		{
			this.client = client;
			bufferSegments = new LinkedList<ArraySegment<byte>>();
			sendQueue = new BlockingCollection<ArraySegment<byte>>();
		}

		public void StartThread()
		{
			threadCancelled = false;
			sendBuffer = new byte[kSendQueueInitialBufferSize];
			sendThread = new Thread(WriteThread);
			sendThread.Name = "Network I/O Thread - " + client.Id;
			sendThread.Start();
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
				catch (Exception ex)
				{
					WriteFailedEventArgs args = null;

					if (ex.InnerException != null && ex.InnerException is SocketException)
					{
						args = new WriteFailedEventArgs() {ErrorCode = (ex.InnerException as SocketException).SocketErrorCode};
					} else if (ex is SocketException)
					{
						args = new WriteFailedEventArgs() {ErrorCode = (ex as SocketException).SocketErrorCode};
					}

					if (args != null && WriteFailed != null)
					{
						Console.Write("SendQ: Slot {0} socket error {1}.", ex.Message);
						WriteFailed(this, args);
					}
					__segment_release_internal(segment);
				}
			}
		}

		private void WriteCallback(IAsyncResult ar)
		{
			SocketError? socketError = null;

			try
			{
				(client.Socket as TcpSocket)._connection.GetStream().EndWrite(ar);
				__segment_release_internal((ArraySegment<byte>) ar.AsyncState);
			}
			catch (Exception ex)
			{
				WriteFailedEventArgs args = null;

				if (ex.InnerException != null && ex.InnerException is SocketException)
				{
					args = new WriteFailedEventArgs() { ErrorCode = (ex.InnerException as SocketException).SocketErrorCode };
				}
				else if (ex is SocketException)
				{
					args = new WriteFailedEventArgs() { ErrorCode = (ex as SocketException).SocketErrorCode };
				}

				if (args != null && WriteFailed != null)
				{
					Console.Write("SendQ: Slot {0} socket error {1}.", ex.Message);
					WriteFailed(this, args);
					__segment_reset_internal();
				}
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

		internal void __segment_reset_internal()
		{
			lock (syncLock)
			{
				bufferSegments.Clear();
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

		public SegmentWriter LockSegmentWriter(short size)
		{
            ArraySegment<byte> segment;

			if (LockSegment(size, out segment) == false)
			{
				return null;
			}

            return new SegmentWriter(this, segment);
        }

		public bool LockSegment(short size, out ArraySegment<byte> outSegment)
		{
			ArraySegment<byte> thisSegment = default(ArraySegment<byte>);
			int bufferSize = 0;
			/*
			 * If there are no segments in the buffer, it is completely
			 * free.
			 */
			lock (syncLock)
			{
				if (bufferSegments.Count == 0)
				{
					ArraySegment<byte> newSegment = new ArraySegment<byte>(sendBuffer, 0, size);
					outSegment = bufferSegments.AddFirst(newSegment).Value;
					return true;
				}
			
				for (var segment = bufferSegments.First; segment != bufferSegments.Last; segment = segment.Next)
				{
					if (DistanceBetween(segment.Value, segment.Next.Value) > size)
					{
						ArraySegment<byte> newSegment = new ArraySegment<byte>(sendBuffer, segment.Value.Offset + segment.Value.Count, size);
						outSegment = bufferSegments.AddAfter(segment, newSegment).Value;
						return true;
					}

					bufferSize += segment.Value.Count;
				}

				if (sendBuffer.Length - (bufferSegments.Last.Value.Offset + bufferSegments.Last.Value.Count) > size)
				{
					ArraySegment<byte> newSegment = new ArraySegment<byte>(sendBuffer, bufferSegments.Last.Value.Offset + bufferSegments.Last.Value.Count, size);
					outSegment = bufferSegments.AddAfter(bufferSegments.Last, newSegment).Value;
					return true;
				}

				Console.WriteLine("sendq: Slot {0} buffer full! {0}/{1}  bytes", client.Id, bufferSize, sendBuffer.Length);

				outSegment = default(ArraySegment<byte>);
				return false;

				//Grow(size);


				//throw new Exception(string.Format("Buffer for slot {0} is full.", client.Id));
			}
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
