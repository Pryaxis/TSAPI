using System;
using System.Collections.Generic;

namespace Terraria.Net
{
	public class LegacyNetBufferPool
	{
		private static object bufferLock = new object();


		private const int LARGE_BUFFER_SIZE = 16384;


		private const int MEDIUM_BUFFER_SIZE = 1024;


		private const int SMALL_BUFFER_SIZE = 256;


		private static int _customBufferCount = 0;


		private static int _largeBufferCount = 0;


		private static Queue<byte[]> _largeBufferQueue = new Queue<byte[]>();


		private static int _mediumBufferCount = 0;


		private static Queue<byte[]> _mediumBufferQueue = new Queue<byte[]>();


		private static int _smallBufferCount = 0;


		private static Queue<byte[]> _smallBufferQueue = new Queue<byte[]>();

		static LegacyNetBufferPool()
		{
			LegacyNetBufferPool.bufferLock = new object();
			LegacyNetBufferPool._smallBufferQueue = new Queue<byte[]>();
			LegacyNetBufferPool._mediumBufferQueue = new Queue<byte[]>();
			LegacyNetBufferPool._largeBufferQueue = new Queue<byte[]>();
		}

		public LegacyNetBufferPool()
		{
		}

		public static void PrintBufferSizes()
		{
			lock (LegacyNetBufferPool.bufferLock)
			{
				Console.WriteLine(string.Concat("SmallBufferQueue.Count: ", LegacyNetBufferPool._smallBufferQueue.Count));
				Console.WriteLine(string.Concat("MediumBufferQueue.Count: ", LegacyNetBufferPool._mediumBufferQueue.Count));
				Console.WriteLine(string.Concat("LargeBufferQueue.Count: ", LegacyNetBufferPool._largeBufferQueue.Count));
				Console.WriteLine("");
			}
		}

		public static byte[] RequestBuffer(int size)
		{
			byte[] result;
			lock (LegacyNetBufferPool.bufferLock)
			{
				if (size <= 256)
				{
					if (LegacyNetBufferPool._smallBufferQueue.Count == 0)
					{
						LegacyNetBufferPool._smallBufferCount++;
						result = new byte[256];
					}
					else
					{
						result = LegacyNetBufferPool._smallBufferQueue.Dequeue();
					}
				}
				else if (size <= 1024)
				{
					if (LegacyNetBufferPool._mediumBufferQueue.Count == 0)
					{
						LegacyNetBufferPool._mediumBufferCount++;
						result = new byte[1024];
					}
					else
					{
						result = LegacyNetBufferPool._mediumBufferQueue.Dequeue();
					}
				}
				else if (size <= 16384)
				{
					if (LegacyNetBufferPool._largeBufferQueue.Count == 0)
					{
						LegacyNetBufferPool._largeBufferCount++;
						result = new byte[16384];
					}
					else
					{
						result = LegacyNetBufferPool._largeBufferQueue.Dequeue();
					}
				}
				else
				{
					LegacyNetBufferPool._customBufferCount++;
					result = new byte[size];
				}
			}
			return result;
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
					LegacyNetBufferPool._smallBufferQueue.Enqueue(buffer);
				}
				else if (length <= 256)
				{
					LegacyNetBufferPool._smallBufferQueue.Enqueue(buffer);
				}
				else if (length <= 16384)
				{
					LegacyNetBufferPool._smallBufferQueue.Enqueue(buffer);
				}
			}
		}
	}
}