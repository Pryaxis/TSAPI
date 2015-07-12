using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using Steamworks;
using Terraria.Net.Sockets.EventArgs;

namespace Terraria.Net.Sockets
{

	public class SendQueue : IDisposable
	{
		public const int kSendQueueLargeBlockSize = 16384;
		public const int kSendQueueSmallBlockSize = 128;

		protected volatile bool threadCancelled;

		protected byte[] smallObjectHeap;
		protected byte[] largeObjectHeap;

		protected int maxLargeBlocks = 32;
		protected int maxSmallBlocks = 4096;
		
		protected int[] freeLargeBlocks;
		protected int[] freeSmallBlocks;

		protected bool[] queuedLargeBlocks;
		protected bool[] queuedSmallBlocks;

		protected Thread sendThread;
		protected RemoteClient client;

		protected AutoResetEvent waitHandle = new AutoResetEvent(false);

		public event EventHandler<WriteFailedEventArgs> WriteFailed;

		public SendQueue(RemoteClient client)
		{
			this.client = client;
			freeLargeBlocks = new int[maxLargeBlocks];
			freeSmallBlocks = new int[maxSmallBlocks];

			for (int i = 0; i < maxLargeBlocks; i++)
			{
				freeLargeBlocks[i] = 1;
			}

			for (int i = 0; i < maxSmallBlocks; i++)
			{
				freeSmallBlocks[i] = 1;
			}

			queuedLargeBlocks = new bool[maxLargeBlocks];
			queuedSmallBlocks = new bool[maxSmallBlocks];

			largeObjectHeap = new byte[maxLargeBlocks * kSendQueueLargeBlockSize];
			smallObjectHeap = new byte[maxSmallBlocks * kSendQueueSmallBlockSize];
		}

		public void StartThread()
		{
			threadCancelled = false;
			(client.Socket as TcpSocket)._connection.SendTimeout = 5000;

			sendThread = new Thread(WriteThread);
			sendThread.Name = "Network I/O Thread - " + client.Id;
			sendThread.Start();
		}

		protected void WriteThread()
		{
			SocketError? socketError = null;
			while (true)
			{
				int blockIndex = 0;

				if (waitHandle.WaitOne(100) == false)
				{
					continue;
				}

				if (threadCancelled == true || client.PendingTermination == true)
				{
					break;
				}

				for (blockIndex = 0; blockIndex < maxSmallBlocks; blockIndex++)
				{
					short length;
					int offset;

					if (threadCancelled == true)
					{
						break;
					}

					if (queuedSmallBlocks[blockIndex] == false)
					{
						continue;
					}

					offset = blockIndex * kSendQueueSmallBlockSize;
					length = BitConverter.ToInt16(smallObjectHeap, offset);

					try
					{
						(client.Socket as TcpSocket)._connection.GetStream().Write(smallObjectHeap, offset, length);
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
						}
						Netplay.Clients[client.Id].PendingTermination = true;
						break;
					}
					finally
					{
						Free(blockIndex);
					}
				}

				for (blockIndex = 0; blockIndex < maxLargeBlocks; blockIndex++)
				{
					short length;
					int offset;

					if (threadCancelled == true)
					{
						break;
					}

					if (queuedLargeBlocks[blockIndex] == false)
					{
						continue;
					}

					offset = blockIndex * kSendQueueLargeBlockSize;
					length = BitConverter.ToInt16(largeObjectHeap, offset);

					try
					{
						(client.Socket as TcpSocket)._connection.GetStream().Write(largeObjectHeap, offset, length);
					}
					catch(Exception ex)
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
						}
						Netplay.Clients[client.Id].PendingTermination = true;
						break;
					}
					finally
					{
						FreeLarge(blockIndex);
					}
				}
			}
		}


		public ArraySegment<byte> Alloc(int size)
		{
			lock (this)
			{

				if (size <= kSendQueueSmallBlockSize)
				{
					for (int i = 0; i < maxSmallBlocks; i++)
					{
						if (1 == Interlocked.CompareExchange(ref freeSmallBlocks[i], 0, 1))
						{
							return new ArraySegment<byte>(smallObjectHeap, i*kSendQueueSmallBlockSize, kSendQueueSmallBlockSize);
						}
					}
				}

				for (int i = 0; i < maxLargeBlocks; i++)
				{
					if (1 == Interlocked.CompareExchange(ref freeLargeBlocks[i], 0, 1))
					{
						return new ArraySegment<byte>(largeObjectHeap, i*kSendQueueLargeBlockSize, kSendQueueLargeBlockSize);
					}
				}
			}

			//Console.WriteLine("send: slot {0} alloc failed!", client.Id);
			return default(ArraySegment<byte>);
		}

		public void AllocAndSet(int size, Func<ArraySegment<byte>, bool> setFunc)
		{
			ArraySegment<byte> block = Alloc(size);
			if (block == default(ArraySegment<byte>))
			{
				return;
			}

			if (setFunc(block))
			{
				Enqueue(block);
			}
		}

		public void AllocAndSet(int size, Func<BinaryWriter, bool> setFunc)
		{
			ArraySegment<byte> block = Alloc(size);
			if (block == default(ArraySegment<byte>))
			{
				return;
			}

			using (MemoryStream ms = new MemoryStream(block.Array, block.Offset, block.Count, true))
			using (BinaryWriter bw = new BinaryWriter(ms))
			{
				if (setFunc(bw))
				{
					Enqueue(block);
				}
			}
		}

		public ArraySegment<byte> AllocAndCopy(ref byte[] buffer, int offset, int count)
		{
			ArraySegment<byte> block = Alloc(count);
			if (block == default(ArraySegment<byte>))
			{
				return default(ArraySegment<byte>);
			}

			if (count > block.Count)
			{
				throw new Exception("Attempt to overwrite boundary");
			}

			Array.Copy(buffer, offset, block.Array, block.Offset + offset, count);

			return block;
		}


		public void Enqueue(ArraySegment<byte> block)
		{
			if (block == default(ArraySegment<byte>))
			{
				return;
			}
			if (block.Count == kSendQueueLargeBlockSize)
			{
				queuedLargeBlocks[block.Offset/kSendQueueLargeBlockSize] = true; //atomic
			}
			else
			{
				queuedSmallBlocks[block.Offset/kSendQueueSmallBlockSize] = true;
			}
			waitHandle.Set();
		}

		public void FreeLarge(int block)
		{
			Interlocked.Exchange(ref freeLargeBlocks[block], 1);
			queuedLargeBlocks[block] = false;
		}

		public void Free(int block)
		{
			Interlocked.Exchange(ref freeSmallBlocks[block], 1);
			queuedSmallBlocks[block] = false;
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
			//for (int i = 0; i < maxSmallBlocks; i++)
			//{
			//	freeSmallBlocks[i] = 1;
			//	queuedSmallBlocks[i] = false;
			//}

			//for (int i = 0; i < maxLargeBlocks; i++)
			//{
			//	freeLargeBlocks[i] = 1;
			//	queuedLargeBlocks[i] = false;
			//}
		
			threadCancelled = true;
			waitHandle.Set();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (sendThread != null)
			{
				threadCancelled = true;
				waitHandle.Set();
				sendThread.Join();
			}

			if (disposing)
			{
				waitHandle.Dispose();
			}
		}
	}
}
