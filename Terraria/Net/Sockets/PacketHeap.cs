using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;

namespace Terraria.Net.Sockets
{
	public enum HeapType
	{
		None,
		SmallHeap,
		LargeHeap
	}

	public class HeapItem
	{
		public byte[] Array;
		public HeapType HeapType;
		public int Block;
		public bool[] recipients = new bool[256];

		public int Offset
		{
			get
			{
				return Block*
				       (HeapType == HeapType.LargeHeap
					       ? PacketHeap.kPacketHeapLargeBlockSize
						   : PacketHeap.kPacketHeapSmallBlockSize);
			}
		}

		public HeapItem(byte[] array, HeapType type, int block)
		{
			this.Array = array;
			this.HeapType = type;
			this.Block = block;
		}

		public BinaryWriter CreateWriter()
		{
			int blockSize = HeapType == HeapType.LargeHeap
				? PacketHeap.kPacketHeapLargeBlockSize
				: PacketHeap.kPacketHeapSmallBlockSize;
			int index = Block*blockSize;

			/*
			 * Leave the packet header section blank so writers
			 * start pushing data at the payload section of the
			 * packet and not into the header region.
			 */
			BinaryWriter bw = new BinaryWriter(new MemoryStream(Array, index, blockSize));
			bw.BaseStream.Position = 3;

			return bw;
		}

		public BinaryReader CreateReader()
		{
			int blockSize = HeapType == HeapType.LargeHeap
				? PacketHeap.kPacketHeapLargeBlockSize
				: PacketHeap.kPacketHeapSmallBlockSize;
			int index = Block*blockSize;

			return new BinaryReader(new MemoryStream(Array, index, blockSize));
		}

		public void SetRecipients(params int[] ply)
		{
			foreach (int p in ply)
			{
				recipients[p] = true;
			}
		}

		public void SetRecipient(int ply)
		{
			recipients[ply] = true;
		}

		~HeapItem()
		{
			PacketHeap.Free(this);
		}

		public override string ToString()
		{
			return string.Format("[HeapItem: {0}, Block: {1}]", HeapType, Block);
		}
	}

	public static class PacketHeap
	{
		public const int kPacketHeapLargeBlockSize = 16384;
		public const int kPacketHeapSmallBlockSize = 128;

		public const int kPacketHeapLargeCount = 4096;
		public const int kPacketHeapSmallCount = 262144;

		internal static byte[] smallHeap = new byte[kPacketHeapSmallBlockSize * kPacketHeapSmallCount];
		internal static byte[] largeHeap = new byte[kPacketHeapLargeBlockSize * kPacketHeapLargeCount];
		internal static int[] usedLargeBlocks = new int[kPacketHeapLargeCount];
		internal static int[] usedSmallBlocks = new int[kPacketHeapSmallCount];

		static PacketHeap()
		{
			Console.Write("sendq: heap size: {0}kB large {1}kB small allocated",
				(kPacketHeapLargeCount*kPacketHeapLargeBlockSize)/1024,
				(kPacketHeapSmallCount*kPacketHeapSmallBlockSize)/1024);
		}

		public static HeapItem Allocate(HeapType type, int after = 0)
		{
			if (type == HeapType.LargeHeap)
			{
				for (int i = after; i < kPacketHeapLargeCount; i++)
				{
					if (0 == Interlocked.CompareExchange(ref usedLargeBlocks[i], 1, 0))
					{
#if __ZERO_MEM
						Array.Clear(largeHeap, i * kPacketHeapLargeBlockSize, kPacketHeapLargeBlockSize);
#endif
						return new HeapItem(largeHeap, HeapType.LargeHeap, i);
					}
				}

				Console.WriteLine("sendq: heap full!");
			}
			else
			{
				for (int i = after; i < kPacketHeapSmallCount; i++)
				{
					if (0 == Interlocked.CompareExchange(ref usedSmallBlocks[i], 1, 0))
					{
						return new HeapItem(smallHeap, HeapType.SmallHeap, i);
					}
				}
				
				GC.Collect();
				GC.WaitForPendingFinalizers();

				Console.WriteLine("sendq: heap full!");
			}

			return default(HeapItem);
		}


		public static void Free(HeapItem item)
		{
			switch (item.HeapType)
			{
				case HeapType.LargeHeap:
					Interlocked.Exchange(ref usedLargeBlocks[item.Block], 0);
					break;
				case HeapType.SmallHeap:
					Interlocked.Exchange(ref usedSmallBlocks[item.Block], 0);
					break;
			}
		}
	}
}
