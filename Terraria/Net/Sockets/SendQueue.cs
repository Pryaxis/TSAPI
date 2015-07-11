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
		protected const int kSendQueueInitialBufferSize = 2 * 1024 * 1024;

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
			sendQueue = new BlockingCollection<ArraySegment<byte>>(new ConcurrentQueue<ArraySegment<byte>>());
		}

		public void StartThread()
		{
			sendBuffer = new byte[kSendQueueInitialBufferSize];
			threadCancelled = false;
			(client.Socket as TcpSocket)._connection.SendTimeout = 1000;

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
				if (threadCancelled == true || client.PendingTermination == true)
				{
					break;
				}

				if (sendQueue.TryTake(out segment, TimeSpan.FromMilliseconds(100)) == false)
				{
					continue;
				}

				try
				{
					(client.Socket as TcpSocket)._connection.GetStream().Write(segment.Array, segment.Offset, segment.Count);
					__segment_release_internal(segment);
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

					Netplay.Clients[client.Id].PendingTermination = true;
				}
			}
		}

		public void Enqueue(ArraySegment<byte> segment)
		{
			sendQueue.TryAdd(segment);
		}

		public void CopyTo(ArraySegment<byte> segment, ref byte[] buffer)
		{
			Array.Copy(buffer, 0, segment.Array, segment.Offset, segment.Count);
		}

		internal void __segment_reset_internal()
		{
			lock (syncLock)
			{
				bufferSegments.Clear();
			}
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

		public bool LockSegment(short size, out ArraySegment<byte> outSegment)
		{
			ArraySegment<byte> thisSegment = default(ArraySegment<byte>);
			int bufferSize = 0;

			outSegment = default(ArraySegment<byte>);
			if (threadCancelled == true)
			{
				return false;
			}

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

				return false;
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
				lock (syncLock)
				{
					bufferSegments.Clear();
				}
			}
			sendBuffer = null;
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
