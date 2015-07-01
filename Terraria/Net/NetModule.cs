using System;
using System.IO;

namespace Terraria.Net
{
	public abstract class NetModule
	{
		protected const int HEADER_SIZE = 5;

		public ushort Id;

		public NetModule()
		{
		}

		protected static NetPacket CreatePacket<T>(int size)
		where T : NetModule
		{
			ushort id = NetManager.Instance.GetId<T>();
			NetPacket netPacket = new NetPacket(id, size + 5);
			netPacket.Writer.Write((ushort)(size + 5));
			netPacket.Writer.Write((byte)82);
			netPacket.Writer.Write(id);
			return netPacket;
		}

		public abstract bool Deserialize(BinaryReader reader, int userId);
	}
}