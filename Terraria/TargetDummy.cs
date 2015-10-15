
using System;
using System.Collections.Generic;

namespace Terraria
{
	public class TargetDummy
	{
		public const int MaxDummies = 1000;

		public static TargetDummy[] dummies;

		public short x;

		public short y;

		public int npc;

		public int whoAmI;

		static TargetDummy()
		{
			TargetDummy.dummies = new TargetDummy[1000];
		}

		public TargetDummy(int x, int y)
		{
			this.x = (short)x;
			this.y = (short)y;
			this.npc = -1;
		}

		public void Activate()
		{
			int num = NPC.NewNPC(this.x * 16 + 16, this.y * 16 + 48, 488, 100, 0f, 0f, 0f, 0f, 255);
			Main.npc[num].ai[0] = (float)this.x;
			Main.npc[num].ai[1] = (float)this.y;
			Main.npc[num].netUpdate = true;
			this.npc = num;
			if (Main.netMode != 1)
			{
				NetMessage.SendData((int)PacketTypes.UpdateTileEntity, -1, -1, "", this.whoAmI, (float)this.x, (float)this.y, 0f, 0, 0, 0);
			}
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
				NetMessage.SendData((int)PacketTypes.UpdateTileEntity, -1, -1, "", this.whoAmI, (float)this.x, (float)this.y, 0f, 0, 0, 0);
			}
		}

		public static int Find(int x, int y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (TargetDummy.dummies[i] != null && TargetDummy.dummies[i].x == x && TargetDummy.dummies[i].y == y)
				{
					return i;
				}
			}
			return -1;
		}

		public static int Hook_AfterPlacement(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			if (Main.netMode != 1)
			{
				return TargetDummy.Place(x - 1, y - 2);
			}
			NetMessage.SendTileSquare(Main.myPlayer, x - 1, y - 1, 3);
			NetMessage.SendData((int)PacketTypes.PlaceTileEntity, -1, -1, "", x - 1, (float)(y - 2), 0f, 0f, 0, 0, 0);
			return -1;
		}

		public static void Kill(int x, int y)
		{
			for (int i = 0; i < 1000; i++)
			{
				TargetDummy targetDummy = TargetDummy.dummies[i];
				if (targetDummy != null && targetDummy.x == x && targetDummy.y == y)
				{
					TargetDummy.dummies[i] = null;
				}
			}
		}

		public static int Place(int x, int y)
		{
			int num = -1;
			int num1 = 0;
			while (num1 < 1000)
			{
				if (TargetDummy.dummies[num1] != null)
				{
					num1++;
				}
				else
				{
					num = num1;
					break;
				}
			}
			if (num == -1)
			{
				return num;
			}
			TargetDummy.dummies[num] = new TargetDummy(x, y);
			return num;
		}

		public override string ToString()
		{
			object[] objArray = new object[] { this.x, "x  ", this.y, "y npc: ", this.npc };
			return string.Concat(objArray);
		}

		public static void UpdateDummies()
		{
			Dictionary<int, Rectangle> nums = new Dictionary<int, Rectangle>();
			bool flag = false;
			Rectangle rectangle = new Rectangle(0, 0, 32, 48);
			rectangle.Inflate(1600, 1600);
			int x = rectangle.X;
			int y = rectangle.Y;
			for (int i = 0; i < 1000; i++)
			{
				if (TargetDummy.dummies[i] != null)
				{
					TargetDummy.dummies[i].whoAmI = i;
					if (TargetDummy.dummies[i].npc == -1)
					{
						if (!flag)
						{
							for (int j = 0; j < 255; j++)
							{
								if (Main.player[j].active)
								{
									nums[j] = Main.player[j].getRect();
								}
							}
							flag = true;
						}
						rectangle.X = TargetDummy.dummies[i].x * 16 + x;
						rectangle.Y = TargetDummy.dummies[i].y * 16 + y;
						bool flag1 = false;
						foreach (KeyValuePair<int, Rectangle> num in nums)
						{
							if (!num.Value.Intersects(rectangle))
							{
								continue;
							}
							flag1 = true;
							break;
						}
						if (flag1)
						{
							TargetDummy.dummies[i].Activate();
						}
					}
					else if (!Main.npc[TargetDummy.dummies[i].npc].active || Main.npc[TargetDummy.dummies[i].npc].type != 488 || Main.npc[TargetDummy.dummies[i].npc].ai[0] != (float)TargetDummy.dummies[i].x || Main.npc[TargetDummy.dummies[i].npc].ai[1] != (float)TargetDummy.dummies[i].y)
					{
						TargetDummy.dummies[i].Deactivate();
					}
				}
			}
		}
	}
}
