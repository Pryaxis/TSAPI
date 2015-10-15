using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent.Tile_Entities
{
	internal class TEItemFrame : TileEntity
	{
		public Item item;

		public TEItemFrame()
		{
			this.item = new Item();
		}

		public void DropItem()
		{
			if (Main.netMode != 1)
			{
				Item.NewItem(this.Position.X * 16, this.Position.Y * 16, 32, 32, this.item.netID, 1, false, (int)this.item.prefix, false);
			}
			this.item = new Item();
		}

		public static int Find(int x, int y)
		{
			TileEntity tileEntity;
			if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || tileEntity.type != 1)
			{
				return -1;
			}
			return tileEntity.ID;
		}

		public static int Hook_AfterPlacement(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			if (Main.netMode != 1)
			{
				return TEItemFrame.Place(x, y);
			}
			NetMessage.SendTileSquare(Main.myPlayer, x, y, 2);
			NetMessage.SendData((int)PacketTypes.PlaceTileEntity, -1, -1, "", x, (float)y, 1f, 0f, 0, 0, 0);
			return -1;
		}

		public static void Kill(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 1)
			{
				TileEntity.ByID.Remove(tileEntity.ID);
				TileEntity.ByPosition.Remove(new Point16(x, y));
			}
		}

		public static int Place(int x, int y)
		{
			TEItemFrame tEItemFrame = new TEItemFrame()
			{
				Position = new Point16(x, y),
				ID = TileEntity.AssignNewID(),
				type = 1
			};
			TileEntity.ByID[tEItemFrame.ID] = tEItemFrame;
			TileEntity.ByPosition[tEItemFrame.Position] = tEItemFrame;
			return tEItemFrame.ID;
		}

		public override void ReadExtraData(BinaryReader reader)
		{
			this.item = new Item();
			this.item.netDefaults(reader.ReadInt16());
			this.item.Prefix((int)reader.ReadByte());
			this.item.stack = reader.ReadInt16();
		}

		public override string ToString()
		{
			object[] x = new object[] { this.Position.X, "x  ", this.Position.Y, "y item: ", this.item.ToString() };
			return string.Concat(x);
		}

		public static void TryPlacing(int x, int y, int netid, int prefix, int stack)
		{
			int num = TEItemFrame.Find(x, y);
			if (num == -1)
			{
				int num1 = Item.NewItem(x * 16, y * 16, 32, 32, 1, 1, false, 0, false);
				Main.item[num1].netDefaults(netid);
				Main.item[num1].Prefix(prefix);
				Main.item[num1].stack = stack;
				NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num1, 0f, 0f, 0f, 0, 0, 0);
				return;
			}
			TEItemFrame item = (TEItemFrame)TileEntity.ByID[num];
			if (item.item.stack > 0)
			{
				int num2 = Item.NewItem(x * 16, y * 16, 32, 32, 1, 1, false, 0, false);
				Main.item[num2].netDefaults(item.item.netID);
				Main.item[num2].Prefix((int)item.item.prefix);
				Main.item[num2].stack = item.item.stack;
				NetMessage.SendData((int)PacketTypes.ItemDrop, -1, -1, "", num2, 0f, 0f, 0f, 0, 0, 0);
			}
			item.item = new Item();
			item.item.netDefaults(netid);
			item.item.Prefix(prefix);
			item.item.stack = stack;
			NetMessage.SendData((int)PacketTypes.UpdateTileEntity, -1, -1, "", item.ID, (float)x, (float)y, 0f, 0, 0, 0);
		}

		public static bool ValidTile(int x, int y)
		{
			if (Main.tile[x, y].active() && Main.tile[x, y].type == TileID.ItemFrame && Main.tile[x, y].frameY == 0 && Main.tile[x, y].frameX % 36 == 0)
			{
				return true;
			}
			return false;
		}

		public override void WriteExtraData(BinaryWriter writer)
		{
			writer.Write((short)this.item.netID);
			writer.Write(this.item.prefix);
			writer.Write((short)this.item.stack);
		}
	}
}
