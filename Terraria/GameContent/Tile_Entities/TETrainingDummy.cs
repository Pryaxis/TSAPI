
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria.GameContent.Tile_Entities
{
	internal class TETrainingDummy : TileEntity
	{
		private static Dictionary<int, Rectangle> playerBox;

		private static bool playerBoxFilled;

		public int npc;

		static TETrainingDummy()
		{
			TETrainingDummy.playerBox = new Dictionary<int, Rectangle>();
			TETrainingDummy.playerBoxFilled = false;
		}

		public TETrainingDummy()
		{
			this.npc = -1;
		}

		public void Activate()
		{
			int num = NPC.NewNPC(this.Position.X * 16 + 16, this.Position.Y * 16 + 48, 488, 100, 0f, 0f, 0f, 0f, 255);
			Main.npc[num].ai[0] = (float)this.Position.X;
			Main.npc[num].ai[1] = (float)this.Position.Y;
			Main.npc[num].netUpdate = true;
			this.npc = num;
			if (Main.netMode != 1)
			{
				NetMessage.SendData((int)PacketTypes.UpdateTileEntity, -1, -1, "", this.ID, (float)this.Position.X, (float)this.Position.Y, 0f, 0, 0, 0);
			}
		}

		public static void ClearBoxes()
		{
			TETrainingDummy.playerBox.Clear();
			TETrainingDummy.playerBoxFilled = false;
		}

		public void Deactivate()
		{
			if (this.npc != -1)
			{
				Main.npc[this.npc].active = false;
			}
			this.npc = -1;
			if (Main.netMode != 1)
			{
				NetMessage.SendData((int)PacketTypes.UpdateTileEntity, -1, -1, "", this.ID, (float)this.Position.X, (float)this.Position.Y, 0f, 0, 0, 0);
			}
		}

		private static void FillPlayerHitboxes()
		{
			if (!TETrainingDummy.playerBoxFilled)
			{
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active)
					{
						TETrainingDummy.playerBox[i] = Main.player[i].getRect();
					}
				}
				TETrainingDummy.playerBoxFilled = true;
			}
		}

		public static int Find(int x, int y)
		{
			TileEntity tileEntity;
			if (!TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) || tileEntity.type != 0)
			{
				return -1;
			}
			return tileEntity.ID;
		}

		public static int Hook_AfterPlacement(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			if (Main.netMode != 1)
			{
				return TETrainingDummy.Place(x - 1, y - 2);
			}
			NetMessage.SendTileSquare(Main.myPlayer, x - 1, y - 1, 3);
			NetMessage.SendData((int)PacketTypes.PlaceTileEntity, -1, -1, "", x - 1, (float)(y - 2), 0f, 0f, 0, 0, 0);
			return -1;
		}

		public static void Initialize()
		{
			TileEntity._UpdateStart += new Action(TETrainingDummy.ClearBoxes);
		}

		public static void Kill(int x, int y)
		{
			TileEntity tileEntity;
			if (TileEntity.ByPosition.TryGetValue(new Point16(x, y), out tileEntity) && tileEntity.type == 0)
			{
				TileEntity.ByID.Remove(tileEntity.ID);
				TileEntity.ByPosition.Remove(new Point16(x, y));
			}
		}

		public static int Place(int x, int y)
		{
			TETrainingDummy tETrainingDummy = new TETrainingDummy()
			{
				Position = new Point16(x, y),
				ID = TileEntity.AssignNewID(),
				type = 0
			};
			TileEntity.ByID[tETrainingDummy.ID] = tETrainingDummy;
			TileEntity.ByPosition[tETrainingDummy.Position] = tETrainingDummy;
			return tETrainingDummy.ID;
		}

		public override void ReadExtraData(BinaryReader reader)
		{
			this.npc = reader.ReadInt16();
		}

		public override string ToString()
		{
			object[] x = new object[] { this.Position.X, "x  ", this.Position.Y, "y npc: ", this.npc };
			return string.Concat(x);
		}

		public override void Update()
		{
			Rectangle rectangle = new Rectangle(0, 0, 32, 48);
			rectangle.Inflate(1600, 1600);
			int x = rectangle.X;
			int y = rectangle.Y;
			if (this.npc == -1)
			{
				TETrainingDummy.FillPlayerHitboxes();
				rectangle.X = this.Position.X * 16 + x;
				rectangle.Y = this.Position.Y * 16 + y;
				bool flag = false;
				foreach (KeyValuePair<int, Rectangle> keyValuePair in TETrainingDummy.playerBox)
				{
					if (!keyValuePair.Value.Intersects(rectangle))
					{
						continue;
					}
					flag = true;
					break;
				}
				if (flag)
				{
					this.Activate();
				}
			}
			else if (!Main.npc[this.npc].active || Main.npc[this.npc].type != 488 || Main.npc[this.npc].ai[0] != (float)this.Position.X || Main.npc[this.npc].ai[1] != (float)this.Position.Y)
			{
				this.Deactivate();
				return;
			}
		}

		public static bool ValidTile(int x, int y)
		{
			if (Main.tile[x, y].active() && Main.tile[x, y].type == TileID.TargetDummy && Main.tile[x, y].frameY == 0 && Main.tile[x, y].frameX % 36 == 0)
			{
				return true;
			}
			return false;
		}

		public override void WriteExtraData(BinaryWriter writer)
		{
			writer.Write((short)this.npc);
		}
	}
}
