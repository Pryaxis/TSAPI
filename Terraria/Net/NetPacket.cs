using System;
using System.IO;
using Terraria.DataStructures;

namespace Terraria.Net
{
	public struct NetPacket
	{
		public ushort Id;

		public int Length;

		public CachedBuffer Buffer;

		public BinaryReader Reader
		{
			get
			{
				return this.Buffer.Reader;
			}
		}

		public BinaryWriter Writer
		{
			get
			{
				return this.Buffer.Writer;
			}
		}

		public NetPacket(ushort id, int size)
		{
			this.Id = id;
			this.Buffer = BufferPool.Request(size);
			this.Length = size;
		}

		public void Recycle()
		{
			this.Buffer.Recycle();
		}
	}
}