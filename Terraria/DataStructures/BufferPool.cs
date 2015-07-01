using System;
using System.Collections.Generic;

namespace Terraria.DataStructures
{
	public static class BufferPool
	{
		private const int SMALL_BUFFER_SIZE = 32;

		private const int MEDIUM_BUFFER_SIZE = 256;

		private const int LARGE_BUFFER_SIZE = 16384;

		private static object bufferLock;

		private static Queue<CachedBuffer> SmallBufferQueue;

		private static Queue<CachedBuffer> MediumBufferQueue;

		private static Queue<CachedBuffer> LargeBufferQueue;

		static BufferPool()
		{
			BufferPool.bufferLock = new object();
			BufferPool.SmallBufferQueue = new Queue<CachedBuffer>();
			BufferPool.MediumBufferQueue = new Queue<CachedBuffer>();
			BufferPool.LargeBufferQueue = new Queue<CachedBuffer>();
		}

		public static void PrintBufferSizes()
		{
			lock (BufferPool.bufferLock)
			{
				Console.WriteLine(string.Concat("SmallBufferQueue.Count: ", BufferPool.SmallBufferQueue.Count));
				Console.WriteLine(string.Concat("MediumBufferQueue.Count: ", BufferPool.MediumBufferQueue.Count));
				Console.WriteLine(string.Concat("LargeBufferQueue.Count: ", BufferPool.LargeBufferQueue.Count));
				Console.WriteLine("");
			}
		}

		public static void Recycle(CachedBuffer buffer)
		{
			int length = buffer.Length;
			lock (BufferPool.bufferLock)
			{
				if (length <= 32)
				{
					BufferPool.SmallBufferQueue.Enqueue(buffer);
				}
				else if (length <= 256)
				{
					BufferPool.MediumBufferQueue.Enqueue(buffer);
				}
				else if (length <= 16384)
				{
					BufferPool.LargeBufferQueue.Enqueue(buffer);
				}
			}
		}

		public static CachedBuffer Request(int size)
		{
			CachedBuffer cachedBuffer;
			lock (BufferPool.bufferLock)
			{
				if (size <= 32)
				{
					cachedBuffer = (BufferPool.SmallBufferQueue.Count != 0 ? BufferPool.SmallBufferQueue.Dequeue().Activate() : new CachedBuffer(new byte[32]));
				}
				else if (size <= 256)
				{
					cachedBuffer = (BufferPool.MediumBufferQueue.Count != 0 ? BufferPool.MediumBufferQueue.Dequeue().Activate() : new CachedBuffer(new byte[256]));
				}
				else if (size > 16384)
				{
					cachedBuffer = new CachedBuffer(new byte[size]);
				}
				else
				{
					cachedBuffer = (BufferPool.LargeBufferQueue.Count != 0 ? BufferPool.LargeBufferQueue.Dequeue().Activate() : new CachedBuffer(new byte[16384]));
				}
			}
			return cachedBuffer;
		}

		public static CachedBuffer Request(byte[] data, int offset, int size)
		{
			CachedBuffer cachedBuffer = BufferPool.Request(size);
			Buffer.BlockCopy(data, offset, cachedBuffer.Data, 0, size);
			return cachedBuffer;
		}
	}
}