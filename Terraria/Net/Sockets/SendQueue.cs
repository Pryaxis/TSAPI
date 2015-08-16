using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using Steamworks;
using Terraria.Net.Sockets.EventArgs;
using ThreadState = System.Threading.ThreadState;

namespace Terraria.Net.Sockets
{
	public enum HeapType
	{
		None,
		SmallHeap,
		LargeHeap
	}

	public struct HeapItem
	{
		private SendQueue queue;

        public readonly byte[] Heap;
		public readonly int Block;
		public readonly HeapType HeapType;

        public int Offset { get { return Block * (HeapType == HeapType.LargeHeap ? SendQueue.kSendQueueLargeBlockSize : SendQueue.kSendQueueSmallBlockSize); } }
        public int Count { get { return HeapType == HeapType.LargeHeap ? SendQueue.kSendQueueLargeBlockSize : SendQueue.kSendQueueSmallBlockSize; } }

		public HeapItem(SendQueue queue, byte[] heap, HeapType type, int block)
		{
			this.queue = queue;
			this.HeapType = type;
            this.Heap = heap;
			this.Block = block;
		}

	}

	public class SendQueue : IDisposable
	{
		public static System.Timers.Timer sendQWatcher = new System.Timers.Timer(10000);

		public const int kSendQueueLargeBlockSize = 16384;
		public const int kSendQueueSmallBlockSize = 128;

		protected volatile bool threadCancelled;

		protected byte[] smallObjectHeap;
		protected byte[] largeObjectHeap;

		//protected int maxLargeBlocks = 8;
		//protected int maxSmallBlocks = 16;

		public volatile int overflowSmallBlocks;
		public volatile int overflowLargeBlocks;
		protected int maxLargeBlocks = 192;
		protected int maxSmallBlocks = 4096;

		protected int[] freeLargeBlocks;
		protected int[] freeSmallBlocks;

		protected Thread sendThread;
		protected RemoteClient client;

        protected Queue<HeapItem> sendQueue = new Queue<HeapItem>();
        protected readonly object _syncRoot = new object();
        protected readonly object _allocRoot = new object();

		public event EventHandler<WriteFailedEventArgs> WriteFailed;

		static SendQueue()
		{
			sendQWatcher.Elapsed += (s, args) =>
			{
				List<string> laggingPlayers = new List<string>();
				foreach (RemoteClient client in Netplay.Clients)
				{
					int clientOverflow = 0;

					if ((clientOverflow = (Interlocked.Exchange(ref client.sendQueue.overflowLargeBlocks, 0) + Interlocked.Exchange(ref client.sendQueue.overflowSmallBlocks, 0))) > 0) 
					{
						laggingPlayers.Add(client.Name);
					}
				}

				if (laggingPlayers.Count > 0)
				{
					TerrariaApi.Server.ServerApi.LogWriter.ServerWriteLine(string.Format("sendq: WARNING: players {0} are lagging behind the server!", string.Join(", ", laggingPlayers)), TraceLevel.Warning);
				}
			};
		}

		public SendQueue(RemoteClient client)
		{
			sendQWatcher.Start();

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
		}

		public void StartThread()
		{
			smallObjectHeap = new byte[maxSmallBlocks * kSendQueueSmallBlockSize];
			largeObjectHeap = new byte[maxLargeBlocks * kSendQueueLargeBlockSize];
			threadCancelled = false;
			(client.Socket as TcpSocket)._connection.SendTimeout = 5000;

			sendThread = new Thread(WriteThread);
			sendThread.Name = "Network I/O Thread - " + client.Id;
			sendThread.IsBackground = true;
			sendThread.Start();
		}

		protected void WriteThread()
		{
            HeapItem item;

            while (true)
            {
                if (threadCancelled == true)
                {
                    break;
                }

                lock (_syncRoot)
                {
                    while (sendQueue.Count == 0 && threadCancelled == false)
                    {
                        Monitor.Wait(_syncRoot);
                    }

                    if (threadCancelled == true)
                    {
                        break;
                    }
                    item = sendQueue.Dequeue();
                }

                SendHeapItem(item);
            }

			lock (_allocRoot)
			{
				Interlocked.Exchange(ref smallObjectHeap, null);
				Interlocked.Exchange(ref largeObjectHeap, null);
			}
		    lock (_syncRoot)
		    {
                sendQueue.Clear();
            }
		}

        protected void SendHeapItem(HeapItem item)
        {
			if (item.Heap == null)
			{
				return;
			}

            try
            {
                int length = BitConverter.ToInt16(item.Heap, item.Offset);
                PacketTypes type = (PacketTypes)item.Heap[item.Offset + 2];
                TcpClient tcpClient = (client.Socket as TcpSocket)._connection;

                tcpClient.GetStream().Write(item.Heap, item.Offset, length);

                if (type == PacketTypes.Disconnect)
                {
                    Netplay.Clients[client.Id].PendingTermination = true;
                }
            }
            catch
            {
                Netplay.Clients[client.Id].PendingTermination = true;
            }
            finally
            {
                Free(item.Block, item.HeapType);
            }
        }

		public HeapItem Alloc(int size, out HeapType type, out int block)
        {
            type = HeapType.None;
            block = -1;

            if (size <= kSendQueueSmallBlockSize)
			{
				for (int i = 0; i < maxSmallBlocks; i++)
				{
					if (1 == Interlocked.CompareExchange(ref freeSmallBlocks[i], 0, 1))
					{
						type = HeapType.SmallHeap;
						block = i;
                        return new HeapItem(this, smallObjectHeap, HeapType.SmallHeap, i);
					}
				}

				overflowSmallBlocks += 1;

                return default(HeapItem);
            }

			for (int i = 0; i < maxLargeBlocks; i++)
			{
				if (1 == Interlocked.CompareExchange(ref freeLargeBlocks[i], 0, 1))
				{
					type = HeapType.LargeHeap;
					block = i;
                    return new HeapItem(this, largeObjectHeap, HeapType.LargeHeap, i);
				}
			}

			overflowLargeBlocks += 1;

            return default(HeapItem);
        }

		public void AllocAndSet(int size, Func<HeapItem, bool> setFunc)
		{
			HeapType type;
			int blockId;
			bool enqueue;

			var block = Alloc(size, out type, out blockId);
			if (blockId == -1)
			{
				return;
			}

			lock (_allocRoot)
			{
				enqueue = setFunc(block);
			}
			if (enqueue && !threadCancelled)
			{
				Enqueue(block);
			}
		}

		public void AllocAndSet(int size, Func<BinaryWriter, bool> setFunc)
		{
			HeapType type;
			int blockId;

			var block = Alloc(size, out type, out blockId);
			if (blockId == -1)
			{
				return;
			}

			lock (_allocRoot)
			{
				using (MemoryStream ms = new MemoryStream(block.Heap, block.Offset, block.Count, true))
				using (BinaryWriter bw = new BinaryWriter(ms))
				{
					if (setFunc(bw))
					{
						Enqueue(block);
					}
				}
			}
		}

		public HeapItem AllocAndCopy(ref byte[] buffer, int offset, int count)
		{
			HeapType type;
			int blockId;

			var block = Alloc(count, out type, out blockId);
			if (blockId == -1 || threadCancelled)
			{
                return default(HeapItem);
			}

			if (count > block.Count)
			{
				throw new Exception("Attempt to overwrite boundary");
			}

			Array.Copy(buffer, offset, block.Heap, block.Offset + offset, count);

			return block;
		}


		public void Enqueue(HeapItem item)
		{
            if (item.Block == -1 || threadCancelled)
            {
                return;
            }

			lock (_syncRoot)
            {
                sendQueue.Enqueue(item);
                Monitor.Pulse(_syncRoot);
            }
		}

		public void FreeLarge(int block)
		{
			Interlocked.Exchange(ref freeLargeBlocks[block], 1);
		}

		public void Free(int block)
		{
			Interlocked.Exchange(ref freeSmallBlocks[block], 1);
		}

		public void Free(int block, HeapType type)
		{
			if (type == HeapType.LargeHeap)
			{
				FreeLarge(block);
				return;
			}

			Free(block);
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
			threadCancelled = true;
            lock (_syncRoot)
            {
                Monitor.Pulse(_syncRoot);
            }

			if (sendThread != null && sendThread.ThreadState == ThreadState.Running)
			{
				sendThread.Abort();
				sendThread.Join();
			}

			for (int i = 0; i < maxSmallBlocks; i++)
			{
				freeSmallBlocks[i] = 1;
			}

			for (int i = 0; i < maxLargeBlocks; i++)
			{
				freeLargeBlocks[i] = 1;
			}

		    client.State = 0;
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
			}
		}
	}
}
