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

    /// <summary>
    /// Represents a stack-allocated heap item, which points to a block on a player's
    /// queue.
    /// </summary>
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

    /// <summary>
    /// SendQ: A lock-and-pulse queue for the management of sending data to terraria clients
    /// </summary>
    public class SendQueue
    {
        /// <summary>
        /// The send queue watcher is a 10 second timer that watches for failed packet allocations
        /// called overflows.  Overflows happen when the client is not able to receive the amount
        /// of data that the system is sending it, thus the packet heaps get full and no more information
        /// can be sent to the client.
        /// </summary>
        public static System.Timers.Timer sendQWatcher = new System.Timers.Timer(10000);

        /// <summary>
        /// Key relating to the size in bytes of a large block
        /// </summary>
        public const int kSendQueueLargeBlockSize = 16384;

        /// <summary>
        /// Key relating to the size in bytes of a small block
        /// </summary>
        public const int kSendQueueSmallBlockSize = 128;

        /// <summary>
        /// Volatile flag indicating whether the write thread is currently
        /// running or not
        /// </summary>
        protected volatile bool threadCancelled;

        protected volatile bool hasWriteThread = false;

        static byte[] smallObjectHeap;
        static protected byte[] largeObjectHeap;

        //protected int maxLargeBlocks = 8;
        //protected int maxSmallBlocks = 16;

        public volatile int overflowSmallBlocks;
        public volatile int overflowLargeBlocks;

        /// <summary>
        /// The maximum number of large heap blocks to make up the large heap.
        /// This together with the block size, indicates the size of the large heap.
        /// </summary>
        protected static int maxLargeBlocks = 2048;

        /// <summary>
        /// The maximum number of small heap blocks to make up the small heap.
        /// 
        /// This, together with the small block size inficated the size of the
        /// small heap.
        /// </summary>
        protected static int maxSmallBlocks = 32768;

        protected static int[] freeLargeBlocks;
        protected static int[] freeSmallBlocks;

        /// <summary>
        /// Represents a write thread.  Each client has one to acheive async
        /// writes without having to worry about windows/mono socket semantics
        /// </summary>
        protected Thread sendThread;
        protected RemoteClient client;

        /// <summary>
        /// A queue of heap items enforces packet sending order
        /// </summary>
        protected Queue<HeapItem> sendQueue = new Queue<HeapItem>();

        /// <summary>
        /// Synch-root that protects the lock and pulse queue.  Manipulating
        /// the private sendQueue variable requires an acquisition of this lock.
        /// </summary>
        protected readonly object _syncRoot = new object();

        /// <summary>
        /// Synch-root for protecting the allocators.  A write thread could exit
        /// at any time and exchange the packet heaps to null, even whilst a thread
        /// is still writing to it.
        /// </summary>
        //protected readonly object _allocRoot = new object();

        static SendQueue()
        {
            freeLargeBlocks = new int[maxLargeBlocks];
            freeSmallBlocks = new int[maxSmallBlocks];
            smallObjectHeap = new byte[maxSmallBlocks * kSendQueueSmallBlockSize];
            largeObjectHeap = new byte[maxLargeBlocks * kSendQueueLargeBlockSize];


            for (int i = 0; i < maxLargeBlocks; i++)
            {
                freeLargeBlocks[i] = 1;
            }

            for (int i = 0; i < maxSmallBlocks; i++)
            {
                freeSmallBlocks[i] = 1;
            }

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

        /// <summary>
        /// Initializes a new send queue for the supplied remote client.
        /// </summary>
        /// <param name="client"></param>
        public SendQueue(RemoteClient client)
        {
            sendQWatcher.Start();
            this.client = client;
        }

        /// <summary>
        /// Called to initalize the write thread with new heaps. It's most commonly used 
        /// after TSAPI calls <see cref="Reset"/>.
        /// </summary>
        public void StartThread()
        {
            (client.Socket as TcpSocket)._connection.SendTimeout = 5000;

            sendThread = new Thread(WriteThread);
            sendThread.Name = "Network I/O Thread - " + client.Id;
            sendThread.IsBackground = true;
            sendThread.Start();
            hasWriteThread = true;
        }

        /// <summary>
        /// Main body of the write thread.  Blocks until the lock on _syncRoot
        /// has been pulsed and then pops the top heap item off the queue and
        /// sends it to the connected client.
        /// </summary>
        protected void WriteThread()
        {
            HeapItem item;
            threadCancelled = false;
            bool exit = false;

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
                        /*
						 * Will wait without timeout until it is pulsed
						 */
                        if (Monitor.Wait(_syncRoot, 100) == false)
                        {
                            TcpSocket sock = client.Socket as TcpSocket;

                            try
                            {
                                if (sock._connection.Client.Poll(1000, SelectMode.SelectRead) && sock._connection.Available == 0)
                                {
                                    //Trace.WriteLine($"{client.Id} has a dead socket!");
                                    exit = true;
                                    break;
                                }
                            }
                            catch
                            {
                                //Trace.WriteLine($"{client.Id} has a dead socket!");
                                exit = true;
                                break;
                            }
                        }
                    }

                    if (threadCancelled || exit)
                    {
                        Netplay.Clients[client.Id].PendingTermination = true;
                        break;
                    }

                    item = sendQueue.Dequeue();
                }

                SendHeapItem(item);
            }

            hasWriteThread = false;
        }

        /// <summary>
        /// Sends a HeapItem to the connected client.  The HeapItem must be a valid
        /// Terraria packet.
        /// </summary>
        /// <remarks>
        /// Heap item must point to a valid packet.
        /// </remarks>
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

        /// <summary>
        /// Allocates a new HeapItem based on the first free block on the small
        /// or large heaps.
        /// </summary>
        /// <param name="size">The size of packet requested</param>
        /// <param name="type">(out) Small or large heap</param>
        /// <param name="block">(out) the block ID</param>
        /// <returns>
        /// A HeapItem pointing to a segment of the packet heap in which the
        /// packet may be written to
        /// </returns>
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

        /// <summary>
        /// Allocates a new packet on the heap and executes the in-line set method which
        /// allows the packet to be written in an anonymous method.
        /// </summary>
        /// <param name="size">The size of heap requested</param>
        /// <param name="setFunc">
        /// A delegate pointing to the method in which to run that will write the packet
        /// to the HeapItem.  It has one parameter (the heap item) and expects a bool
        /// return value indicating whether to proceed adding the heap item to the queue
        /// once the function has completed executing.
        /// </param>
        public void AllocAndSet(int size, Func<HeapItem, bool> setFunc)
        {
            HeapType type;
            int blockId;
            bool enqueue = false;

            var block = Alloc(size, out type, out blockId);
            if (blockId == -1)
            {
                return;
            }

            if (block.Heap != null)
            {
                try
                {
                    enqueue = setFunc(block);
                }
                catch
                {
                    Free(block.Block, block.HeapType);
                }
            }

            if (enqueue)
            {
                Enqueue(block);
            }
        }

        /// <summary>
        /// Allocates a packet on the heap, and executes the set method with a new
        /// BinaryWriter, allowing for the function to not have to worry about
        /// setting up the memory scaffolding to write binary data.
        /// </summary>
        /// <param name="size">The size of packet requested</param>
        /// <param name="setFunc">
        /// A delegate pointing to the method in which to write the packet to the
        /// HeapItem.  The method has one parameter (a BinaryWriter) in which callers
        /// may use the BinaryWriter's methods to write packet data, as long as it
        /// does not overwrite the bounds of the heap in which it's allocated in.
        /// 
        /// The method expects one bool return value indicating whether to proceed
        /// adding the packet to the queue after the set method has been called.
        /// </param>
        public void AllocAndSet(int size, Func<BinaryWriter, bool> setFunc)
        {
            HeapType type;
            int blockId;

            var block = Alloc(size, out type, out blockId);
            if (blockId == -1)
            {
                return;
            }

            using (MemoryStream ms = new MemoryStream(block.Heap, block.Offset, block.Count, true))
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                try
                {
                    if (setFunc(bw))
                    {
                        Enqueue(block);
                    }
                }
                catch
                {
                    Free(block.Block, block.HeapType);
                }
            }
        }

        /// <summary>
        /// Allocates a packet on the heap, and copies the supplied byte buffer to the
        /// heap block.
        /// </summary>
        /// <param name="buffer">A reference to the byte buffer in which to copy</param>
        /// <param name="offset">The offset in the source buffer in which to copy</param>
        /// <param name="count">Amount of bytes from the source buffer in which to copy</param>
        /// <returns>A HeapItem with the contents of the source byte array copied</returns>
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
                Free(block.Block, block.HeapType);
                throw new Exception("Attempt to overwrite boundary");
            }

            try
            {
                Array.Copy(buffer, offset, block.Heap, block.Offset + offset, count);
            }
            catch
            {
                Free(block.Block, block.HeapType);
            }

            return block;
        }

        /// <summary>
        /// Enqueues a heap item into the send queue.  Packets enqued will be sent to the client.
        /// </summary>
        public void Enqueue(HeapItem item)
        {
            if (item.Block == -1 || item.Heap == null)
            {
                return;
            }

            lock (_syncRoot)
            {
                sendQueue.Enqueue(item);
                Monitor.Pulse(_syncRoot);
            }
            //Trace.WriteLine($"Enqueue on {client.Id}");
        }

        /// <summary>
        /// Frees a large block from the heap for re-use.
        /// </summary>
        public void FreeLarge(int block)
        {
            Interlocked.Exchange(ref freeLargeBlocks[block], 1);
        }

        /// <summary>
        /// Frees a small block from the heap for re-use.
        /// </summary>
        public void Free(int block)
        {
            Interlocked.Exchange(ref freeSmallBlocks[block], 1);
        }

        /// <summary>
        /// Frees a block for re-use.
        /// </summary>
        public void Free(int block, HeapType type)
        {
            if (type == HeapType.LargeHeap)
            {
                FreeLarge(block);
                return;
            }

            Free(block);
        }

        /// <summary>
        /// Called when a client disconnects, resets the send queue to a state
        /// where it may be re used for another client that lands in the slot.
        /// </summary>
        public void Reset()
        {
            //Trace.WriteLine($"Reset called on {client.Id}");

            lock (_syncRoot)
            {
                foreach (var item in sendQueue)
                {
                    Free(item.Block, item.HeapType);
                }

                Monitor.PulseAll(_syncRoot);
            }

            /*
             * WORKAROUND
             * 
             * Fixes an issue where the client state will be non-zero in some cases when
             * the client has been disconnected and a packet got past the queue, causing
             * clients to be kicked with an "Invalid operation at this state" error which
             * is baked into terraria.
             * 
             * When the send queue gets reset, this ensures all RemoteClients are reset to
             * state 0.
             */
            client.State = 0;
        }
    }
}
