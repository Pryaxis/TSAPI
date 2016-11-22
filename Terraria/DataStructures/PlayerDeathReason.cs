using System;
using System.IO;

namespace Terraria.DataStructures
{
	public class PlayerDeathReason
	{
		public int SourceItemPrefix;
		public int SourceItemType;
		public int SourceNPCIndex = -1;
		public int SourceOtherIndex = -1;
		public int SourcePlayerIndex = -1;
		public int SourceProjectileIndex = -1;
		public int SourceProjectileType;

		public static PlayerDeathReason ByNPC(int index)
		{
			return new PlayerDeathReason
			{
				SourceNPCIndex = index
			};
		}

		public static PlayerDeathReason ByOther(int type)
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = type
			};
		}

		public static PlayerDeathReason ByPlayer(int index)
		{
			return new PlayerDeathReason
			{
				SourcePlayerIndex = index,
				SourceItemType = Main.player[index].inventory[Main.player[index].selectedItem].type,
				SourceItemPrefix = (int)Main.player[index].inventory[Main.player[index].selectedItem].prefix
			};
		}

		public static PlayerDeathReason ByProjectilePVP(int playerIndex, int projectileIndex)
		{
			PlayerDeathReason playerDeathReason = new PlayerDeathReason
			{
				SourcePlayerIndex = playerIndex,
				SourceProjectileIndex = projectileIndex,
				SourceProjectileType = Main.projectile[projectileIndex].type
			};
			if (playerIndex >= 0 && playerIndex <= 255)
			{
				playerDeathReason.SourceItemType = Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].type;
				playerDeathReason.SourceItemPrefix = (int)Main.player[playerIndex].inventory[Main.player[playerIndex].selectedItem].prefix;
			}
			return playerDeathReason;
		}

		public static PlayerDeathReason FromReader(BinaryReader reader)
		{
			PlayerDeathReason playerDeathReason = new PlayerDeathReason();
			BitsByte bitsByte = reader.ReadByte();
			if (bitsByte[0])
			{
				playerDeathReason.SourcePlayerIndex = (int)reader.ReadInt16();
			}
			if (bitsByte[1])
			{
				playerDeathReason.SourceNPCIndex = (int)reader.ReadInt16();
			}
			if (bitsByte[2])
			{
				playerDeathReason.SourceProjectileIndex = (int)reader.ReadInt16();
			}
			if (bitsByte[3])
			{
				playerDeathReason.SourceOtherIndex = (int)reader.ReadByte();
			}
			if (bitsByte[4])
			{
				playerDeathReason.SourceProjectileType = (int)reader.ReadInt16();
			}
			if (bitsByte[5])
			{
				playerDeathReason.SourceItemType = (int)reader.ReadInt16();
			}
			if (bitsByte[6])
			{
				playerDeathReason.SourceItemPrefix = (int)reader.ReadByte();
			}
			return playerDeathReason;
		}

		public string GetDeathText()
		{
			return Lang.deathMsg(this.SourcePlayerIndex, this.SourceNPCIndex, this.SourceProjectileIndex, this.SourceOtherIndex, this.SourceProjectileType, this.SourceItemType);
		}

		public static PlayerDeathReason LegacyDefault()
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = 255
			};
		}

		public static PlayerDeathReason LegacyEmpty()
		{
			return new PlayerDeathReason
			{
				SourceOtherIndex = 254
			};
		}

		public void WriteSelfTo(BinaryWriter writer)
		{
			BitsByte bb = 0;
			bb[0] = (this.SourcePlayerIndex != -1);
			bb[1] = (this.SourceNPCIndex != -1);
			bb[2] = (this.SourceProjectileIndex != -1);
			bb[3] = (this.SourceOtherIndex != -1);
			bb[4] = (this.SourceProjectileType != 0);
			bb[5] = (this.SourceItemType != 0);
			bb[6] = (this.SourceItemPrefix != 0);
			writer.Write(bb);
			if (bb[0])
			{
				writer.Write((short)this.SourcePlayerIndex);
			}
			if (bb[1])
			{
				writer.Write((short)this.SourceNPCIndex);
			}
			if (bb[2])
			{
				writer.Write((short)this.SourceProjectileIndex);
			}
			if (bb[3])
			{
				writer.Write((byte)this.SourceOtherIndex);
			}
			if (bb[4])
			{
				writer.Write((short)this.SourceProjectileType);
			}
			if (bb[5])
			{
				writer.Write((short)this.SourceItemType);
			}
			if (bb[6])
			{
				writer.Write((byte)this.SourceItemPrefix);
			}
		}
	}
}
