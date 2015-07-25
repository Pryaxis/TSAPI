using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Terraria.Net.Sockets.EventArgs;

namespace Terraria.Net.Sockets
{
	public enum HeapType
	{
		None,
		SmallHeap,
		LargeHeap
	}
	public struct SequenceItem
	{
		private SendQueue queue;

		public readonly int Block;
		public readonly HeapType HeapType;

		public SequenceItem(SendQueue queue, HeapType type, int block)
		{
			this.queue = queue;
			this.HeapType = type;
			this.Block = block;
		}

	}

	public class SendQueue : IDisposable
	{
		public const int kSendQueueMaxSequences = 8192;
		public const int kSendQueueLargeBlockSize = 16384;
		public const int kSendQueueSmallBlockSize = 128;

		protected volatile bool threadCancelled;

		protected byte[] smallObjectHeap;
		protected byte[] largeObjectHeap;

		protected int maxLargeBlocks = 192;
		protected int maxSmallBlocks = 4096;

		protected int[] freeLargeBlocks;
		protected int[] freeSmallBlocks;

		protected bool[] queuedLargeBlocks;
		protected bool[] queuedSmallBlocks;

		protected LinkedList<SequenceItem>[] sequences;

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

		}

		public void StartThread()
		{
			sequences = new LinkedList<SequenceItem>[kSendQueueMaxSequences];
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
			SocketError? socketError = null;
			while (true)
			{
				int blockIndex = 0;

				try
				{
					if (waitHandle.WaitOne(100) == false)
					{
						continue;
					}
				}
				catch (ObjectDisposedException)
				{
					break;
				}

				if (threadCancelled == true || client.PendingTermination == true)
				{
					break;
				}

				for (int i = 0; i < kSendQueueMaxSequences; i++)
				{
					LinkedList<SequenceItem> sequence;

					if (threadCancelled == true)
					{
						break;
					}

					if ((sequence = Interlocked.Exchange(ref sequences[i], null)) == null)
					{
						continue;
					}

					foreach (SequenceItem sequenceItem in sequence)
					{
						byte[] heap = sequenceItem.HeapType == HeapType.LargeHeap ? largeObjectHeap : smallObjectHeap;
						int offset = sequenceItem.Block *
									 (sequenceItem.HeapType == HeapType.LargeHeap ? kSendQueueLargeBlockSize : kSendQueueSmallBlockSize);
						int length = BitConverter.ToInt16(heap, offset);
						PacketTypes type = (PacketTypes)heap[offset + 2];

						try
						{
							(client.Socket as TcpSocket)._connection.GetStream().Write(heap, offset, length);
							//System.Diagnostics.Trace.WriteLineIf(type == PacketTypes.TileSendSection || type == PacketTypes.TileFrameSection, "sent " + type);
						}
						catch
						{
						}
						finally
						{
							Free(sequenceItem.Block, sequenceItem.HeapType);
						}
					}
				}

				for (blockIndex = 0; blockIndex < maxLargeBlocks; blockIndex++)
				{
					short length;
					byte type;
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
					type = largeObjectHeap[offset + 2];
					length = BitConverter.ToInt16(largeObjectHeap, offset);

					try
					{
						(client.Socket as TcpSocket)._connection.GetStream().Write(largeObjectHeap, offset, length);
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
						FreeLarge(blockIndex);


					}
				}
				for (blockIndex = 0; blockIndex < maxSmallBlocks; blockIndex++)
				{
					short length;
					int offset;
					byte type;

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
					type = smallObjectHeap[offset + 2];

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
						if (type == (byte)PacketTypes.Disconnect)
						{
							Netplay.Clients[client.Id].PendingTermination = true;
						}
					}
				}


				//Thread.Sleep(1);
			}
		}

		public ArraySegment<byte> Alloc(int size, out HeapType type, out int block)
		{
			if (size <= kSendQueueSmallBlockSize)
			{
				for (int i = 0; i < maxSmallBlocks; i++)
				{
					if (1 == Interlocked.CompareExchange(ref freeSmallBlocks[i], 0, 1))
					{
						type = HeapType.SmallHeap;
						block = i;
						return new ArraySegment<byte>(smallObjectHeap, i * kSendQueueSmallBlockSize, kSendQueueSmallBlockSize);
					}
				}
			}

			for (int i = 0; i < maxLargeBlocks; i++)
			{
				if (1 == Interlocked.CompareExchange(ref freeLargeBlocks[i], 0, 1))
				{
					type = HeapType.LargeHeap;
					block = i;
					return new ArraySegment<byte>(largeObjectHeap, i * kSendQueueLargeBlockSize, kSendQueueLargeBlockSize);
				}
			}

			type = HeapType.None;
			block = -1;
			//Console.WriteLine("send: slot {0} alloc failed!", client.Id);
			return default(ArraySegment<byte>);
		}

		public void AllocAndSet(int size, Func<ArraySegment<byte>, bool> setFunc, LinkedList<SequenceItem> sequence = null)
		{
			HeapType type;
			int blockId;
			bool enqueue;

			ArraySegment<byte> block = Alloc(size, out type, out blockId);
			if (block == default(ArraySegment<byte>))
			{
				return;
			}

			enqueue = setFunc(block);
			if (sequence != null && enqueue)
			{
				sequence.AddLast(new SequenceItem(this, type, blockId));
				return;
			}

			/*
			 * If the sequence is not null, then the sequence must be appended
			 * and not enqueued.
			 */

			if (enqueue)
			{
				Enqueue(block);
			}
		}

		public void AllocAndSet(int size, Func<BinaryWriter, bool> setFunc)
		{
			HeapType type;
			int blockId;

			ArraySegment<byte> block = Alloc(size, out type, out blockId);
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

		public ArraySegment<byte> AllocAndCopy(ref byte[] buffer, int offset, int count, LinkedList<SequenceItem> sequence = null)
		{
			HeapType type;
			int blockId;

			ArraySegment<byte> block = Alloc(count, out type, out blockId);
			if (block == default(ArraySegment<byte>))
			{
				return default(ArraySegment<byte>);
			}

			if (count > block.Count)
			{
				throw new Exception("Attempt to overwrite boundary");
			}

			Array.Copy(buffer, offset, block.Array, block.Offset + offset, count);

			if (sequence != null)
			{
				sequence.AddLast(new SequenceItem(this, type, blockId));
			}

			return block;
		}


		public void Enqueue(ArraySegment<byte> block, LinkedList<SequenceItem> sequence = null)
		{
			if (block == default(ArraySegment<byte>) || sequence != null)
			{
				return;
			}
			if (block.Count == kSendQueueLargeBlockSize)
			{
				queuedLargeBlocks[block.Offset / kSendQueueLargeBlockSize] = true; //atomic
			}
			else
			{
				queuedSmallBlocks[block.Offset / kSendQueueSmallBlockSize] = true;
			}
			waitHandle.Set();
		}

		public void Enqueue(LinkedList<SequenceItem> sequence)
		{
			for (int i = 0; i < kSendQueueMaxSequences; i++)
			{
				if (null == Interlocked.CompareExchange(ref sequences[i], sequence, null))
				{
					waitHandle.Set();
					return;
				}
			}
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
			if (sendThread != null)
			{
				sendThread.Abort();
				sendThread.Join();
			}

			for (int i = 0; i < maxSmallBlocks; i++)
			{
				freeSmallBlocks[i] = 1;
				queuedSmallBlocks[i] = false;
			}

			for (int i = 0; i < maxLargeBlocks; i++)
			{
				freeLargeBlocks[i] = 1;
				queuedLargeBlocks[i] = false;
			}

			Interlocked.Exchange(ref sequences, new LinkedList<SequenceItem>[kSendQueueMaxSequences]);
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
