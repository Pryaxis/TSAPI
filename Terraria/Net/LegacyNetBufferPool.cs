using System;
using System.Collections.Generic;

namespace Terraria.Net
{
	public class LegacyNetBufferPool
	{
		private const int SMALL_BUFFER_SIZE = 32;

		private const int MEDIUM_BUFFER_SIZE = 256;

		private const int LARGE_BUFFER_SIZE = 16384;

		private static object bufferLock;

		private static Queue<byte[]> SmallBufferQueue;

		private static Queue<byte[]> MediumBufferQueue;

		private static Queue<byte[]> LargeBufferQueue;

		static LegacyNetBufferPool()
		{
			LegacyNetBufferPool.bufferLock = new object();
			LegacyNetBufferPool.SmallBufferQueue = new Queue<byte[]>();
			LegacyNetBufferPool.MediumBufferQueue = new Queue<byte[]>();
			LegacyNetBufferPool.LargeBufferQueue = new Queue<byte[]>();
		}

		public LegacyNetBufferPool()
		{
		}

		public static void PrintBufferSizes()
		{
			lock (LegacyNetBufferPool.bufferLock)
			{
				Console.WriteLine(string.Concat("SmallBufferQueue.Count: ", LegacyNetBufferPool.SmallBufferQueue.Count));
				Console.WriteLine(string.Concat("MediumBufferQueue.Count: ", LegacyNetBufferPool.MediumBufferQueue.Count));
				Console.WriteLine(string.Concat("LargeBufferQueue.Count: ", LegacyNetBufferPool.LargeBufferQueue.Count));
				Console.WriteLine("");
			}
		}

		public static byte[] RequestBuffer(int size)
		{
			byte[] numArray;
			lock (LegacyNetBufferPool.bufferLock)
			{
				if (size <= 32)
				{
					numArray = (LegacyNetBufferPool.SmallBufferQueue.Count != 0 ? LegacyNetBufferPool.SmallBufferQueue.Dequeue() : new byte[32]);
				}
				else if (size <= 256)
				{
					numArray = (LegacyNetBufferPool.MediumBufferQueue.Count != 0 ? LegacyNetBufferPool.MediumBufferQueue.Dequeue() : new byte[256]);
				}
				else if (size > 16384)
				{
					numArray = new byte[size];
				}
				else
				{
					numArray = (LegacyNetBufferPool.LargeBufferQueue.Count != 0 ? LegacyNetBufferPool.LargeBufferQueue.Dequeue() : new byte[16384]);
				}
			}
			return numArray;
		}

		public static byte[] RequestBuffer(byte[] data, int offset, int size)
		{
			byte[] numArray = LegacyNetBufferPool.RequestBuffer(size);
			Buffer.BlockCopy(data, offset, numArray, 0, size);
			return numArray;
		}

		public static void ReturnBuffer(byte[] buffer)
		{
			int length = (int)buffer.Length;
			lock (LegacyNetBufferPool.bufferLock)
			{
				if (length <= 32)
				{
					LegacyNetBufferPool.SmallBufferQueue.Enqueue(buffer);
				}
				else if (length <= 256)
				{
					LegacyNetBufferPool.MediumBufferQueue.Enqueue(buffer);
				}
				else if (length <= 16384)
				{
					LegacyNetBufferPool.LargeBufferQueue.Enqueue(buffer);
				}
			}
		}
	}
}