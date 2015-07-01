using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
	internal class NetLiquidModule : NetModule
	{
		public NetLiquidModule()
		{
		}

		public override bool Deserialize(BinaryReader reader, int userId)
		{
			int num = reader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				int num1 = reader.ReadInt32();
				byte num2 = reader.ReadByte();
				byte num3 = reader.ReadByte();
				int num4 = num1 >> 16 & 65535;
				Tile tile = Main.tile[num4, num1 & 65535];
				if (tile != null)
				{
					tile.liquid = num2;
					tile.liquidType((int)num3);
				}
			}
			return true;
		}

		public static NetPacket Serialize(HashSet<int> changes)
		{
			NetPacket netPacket = NetModule.CreatePacket<NetLiquidModule>(changes.Count * 6 + 2);
			netPacket.Writer.Write((ushort)changes.Count);
			foreach (int change in changes)
			{
				int num = change >> 16 & 65535;
				int num1 = change & 65535;
				netPacket.Writer.Write(change);
				netPacket.Writer.Write(Main.tile[num, num1].liquid);
				netPacket.Writer.Write(Main.tile[num, num1].liquidType());
			}
			return netPacket;
		}
	}
}