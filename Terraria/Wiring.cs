using System;
using System.Collections.Generic;
using Terraria.DataStructures;
namespace Terraria
{
	public static class Wiring
	{
		public static bool running = false;
		[ThreadStatic]
		private static Dictionary<Point16, bool> wireSkip;
		[ThreadStatic]
		private static DoubleStack<Point16> wireList;
		[ThreadStatic]
		private static Dictionary<Point16, byte> toProcess;
		public static Vector2[] teleport = new Vector2[2];
		private static int maxPump = 20;
		private static int[] inPumpX = new int[Wiring.maxPump];
		private static int[] inPumpY = new int[Wiring.maxPump];
		private static int numInPump = 0;
		private static int[] outPumpX = new int[Wiring.maxPump];
		private static int[] outPumpY = new int[Wiring.maxPump];
		private static int numOutPump = 0;
		private static int maxMech = 1000;
		private static int[] mechX = new int[Wiring.maxMech];
		private static int[] mechY = new int[Wiring.maxMech];
		private static int numMechs = 0;
		private static int[] mechTime = new int[Wiring.maxMech];
		public static void SkipWire(int x, int y)
		{
			if (wireSkip == null)
				wireSkip = new Dictionary<Point16, bool>();
			Wiring.wireSkip[new Point16(x, y)] = true;
		}
		public static void SkipWire(Point16 point)
		{
			if (wireSkip == null)
				wireSkip = new Dictionary<Point16, bool>();
			Wiring.wireSkip[point] = true;
		}
		public static void UpdateMech()
		{
			for (int i = Wiring.numMechs - 1; i >= 0; i--)
			{
				Wiring.mechTime[i]--;
				if (Main.tile[Wiring.mechX[i], Wiring.mechY[i]].active() && Main.tile[Wiring.mechX[i], Wiring.mechY[i]].type == 144)
				{
					if (Main.tile[Wiring.mechX[i], Wiring.mechY[i]].frameY == 0)
					{
						Wiring.mechTime[i] = 0;
					}
					else
					{
						int num = (int)(Main.tile[Wiring.mechX[i], Wiring.mechY[i]].frameX / 18);
						if (num == 0)
						{
							num = 60;
						}
						else if (num == 1)
						{
							num = 180;
						}
						else if (num == 2)
						{
							num = 300;
						}
						if (Math.IEEERemainder((double)Wiring.mechTime[i], (double)num) == 0.0)
						{
							Wiring.mechTime[i] = 18000;
							Wiring.TripWire(Wiring.mechX[i], Wiring.mechY[i], 1, 1);
						}
					}
				}
				if (Wiring.mechTime[i] <= 0)
				{
					if (Main.tile[Wiring.mechX[i], Wiring.mechY[i]].active() && Main.tile[Wiring.mechX[i], Wiring.mechY[i]].type == 144)
					{
						Main.tile[Wiring.mechX[i], Wiring.mechY[i]].frameY = 0;
						NetMessage.SendTileSquare(-1, Wiring.mechX[i], Wiring.mechY[i], 1);
					}
					for (int j = i; j < Wiring.numMechs; j++)
					{
						Wiring.mechX[j] = Wiring.mechX[j + 1];
						Wiring.mechY[j] = Wiring.mechY[j + 1];
						Wiring.mechTime[j] = Wiring.mechTime[j + 1];
					}
					Wiring.numMechs--;
				}
			}
		}
		public static void hitSwitch(int i, int j)
		{
			if (Main.tile[i, j] == null)
			{
				return;
			}
			if (Main.tile[i, j].type == 135 || Main.tile[i, j].type == 314)
			{
				//Main.PlaySound(28, i * 16, j * 16, 0);
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == 136)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				//Main.PlaySound(28, i * 16, j * 16, 0);
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == 144)
			{
				if (Main.tile[i, j].frameY == 0)
				{
					Main.tile[i, j].frameY = 18;
					if (Main.netMode != 1)
					{
						Wiring.checkMech(i, j, 18000);
					}
				}
				else
				{
					Main.tile[i, j].frameY = 0;
				}
				//Main.PlaySound(28, i * 16, j * 16, 0);
				return;
			}
			if (Main.tile[i, j].type == 132)
			{
				short num = 36;
				int num2 = (int)(Main.tile[i, j].frameX / 18 * -1);
				int num3 = (int)(Main.tile[i, j].frameY / 18 * -1);
				num2 %= 4;
				if (num2 < -1)
				{
					num2 += 2;
					num = -36;
				}
				num2 += i;
				num3 += j;
				for (int k = num2; k < num2 + 2; k++)
				{
					for (int l = num3; l < num3 + 2; l++)
					{
						if (Main.tile[k, l].type == 132)
						{
							Tile expr_1D3 = Main.tile[k, l];
							expr_1D3.frameX += num;
						}
					}
				}
				WorldGen.TileFrame(num2, num3, false, false);
				//Main.PlaySound(28, i * 16, j * 16, 0);
				Wiring.TripWire(num2, num3, 2, 2);
			}
		}
		public static bool checkMech(int i, int j, int time)
		{
			for (int k = 0; k < Wiring.numMechs; k++)
			{
				if (Wiring.mechX[k] == i && Wiring.mechY[k] == j)
				{
					return false;
				}
			}
			if (Wiring.numMechs < Wiring.maxMech - 1)
			{
				Wiring.mechX[Wiring.numMechs] = i;
				Wiring.mechY[Wiring.numMechs] = j;
				Wiring.mechTime[Wiring.numMechs] = time;
				Wiring.numMechs++;
				return true;
			}
			return false;
		}
		private static void xferWater()
		{
			for (int i = 0; i < Wiring.numInPump; i++)
			{
				int num = Wiring.inPumpX[i];
				int num2 = Wiring.inPumpY[i];
				int liquid = (int)Main.tile[num, num2].liquid;
				if (liquid > 0)
				{
					bool flag = Main.tile[num, num2].lava();
					bool flag2 = Main.tile[num, num2].honey();
					for (int j = 0; j < Wiring.numOutPump; j++)
					{
						int num3 = Wiring.outPumpX[j];
						int num4 = Wiring.outPumpY[j];
						int liquid2 = (int)Main.tile[num3, num4].liquid;
						if (liquid2 < 255)
						{
							bool flag3 = Main.tile[num3, num4].lava();
							bool flag4 = Main.tile[num3, num4].honey();
							if (liquid2 == 0)
							{
								flag3 = flag;
								flag4 = flag2;
							}
							if (flag == flag3 && flag2 == flag4)
							{
								int num5 = liquid;
								if (num5 + liquid2 > 255)
								{
									num5 = 255 - liquid2;
								}
								Tile expr_102 = Main.tile[num3, num4];
								expr_102.liquid += (byte)num5;
								Tile expr_11E = Main.tile[num, num2];
								expr_11E.liquid -= (byte)num5;
								liquid = (int)Main.tile[num, num2].liquid;
								Main.tile[num3, num4].lava(flag);
								Main.tile[num3, num4].honey(flag2);
								WorldGen.SquareTileFrame(num3, num4, true);
								if (Main.tile[num, num2].liquid == 0)
								{
									Main.tile[num, num2].lava(false);
									WorldGen.SquareTileFrame(num, num2, true);
									break;
								}
							}
						}
					}
					WorldGen.SquareTileFrame(num, num2, true);
				}
			}
		}
		private static void TripWire(int left, int top, int width, int height)
		{
			if (wireList == null)
				wireList = new DoubleStack<Point16>(1024, 0);

			Wiring.running = true;
			if (Wiring.wireList.Count != 0)
			{
				Wiring.wireList.Clear(true);
			}
			for (int i = left; i < left + width; i++)
			{
				for (int j = top; j < top + height; j++)
				{
					Point16 back = new Point16(i, j);
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.wire())
					{
						Wiring.wireList.PushBack(back);
					}
				}
			}
			Vector2[] array = new Vector2[6];
			Wiring.teleport[0].X = -1f;
			Wiring.teleport[0].Y = -1f;
			Wiring.teleport[1].X = -1f;
			Wiring.teleport[1].Y = -1f;
			if (Wiring.wireList.Count > 0)
			{
				Wiring.numInPump = 0;
				Wiring.numOutPump = 0;
				Wiring.hitWire(Wiring.wireList, 1);
				if (Wiring.numInPump > 0 && Wiring.numOutPump > 0)
				{
					Wiring.xferWater();
				}
			}
			for (int k = left; k < left + width; k++)
			{
				for (int l = top; l < top + height; l++)
				{
					Point16 back = new Point16(k, l);
					Tile tile2 = Main.tile[k, l];
					if (tile2 != null && tile2.wire2())
					{
						Wiring.wireList.PushBack(back);
					}
				}
			}
			array[0] = Wiring.teleport[0];
			array[1] = Wiring.teleport[1];
			Wiring.teleport[0].X = -1f;
			Wiring.teleport[0].Y = -1f;
			Wiring.teleport[1].X = -1f;
			Wiring.teleport[1].Y = -1f;
			if (Wiring.wireList.Count > 0)
			{
				Wiring.numInPump = 0;
				Wiring.numOutPump = 0;
				Wiring.hitWire(Wiring.wireList, 2);
				if (Wiring.numInPump > 0 && Wiring.numOutPump > 0)
				{
					Wiring.xferWater();
				}
			}
			array[2] = Wiring.teleport[0];
			array[3] = Wiring.teleport[1];
			Wiring.teleport[0].X = -1f;
			Wiring.teleport[0].Y = -1f;
			Wiring.teleport[1].X = -1f;
			Wiring.teleport[1].Y = -1f;
			for (int m = left; m < left + width; m++)
			{
				for (int n = top; n < top + height; n++)
				{
					Point16 back = new Point16(m, n);
					Tile tile3 = Main.tile[m, n];
					if (tile3 != null && tile3.wire3())
					{
						Wiring.wireList.PushBack(back);
					}
				}
			}
			if (Wiring.wireList.Count > 0)
			{
				Wiring.numInPump = 0;
				Wiring.numOutPump = 0;
				Wiring.hitWire(Wiring.wireList, 3);
				if (Wiring.numInPump > 0 && Wiring.numOutPump > 0)
				{
					Wiring.xferWater();
				}
			}
			array[4] = Wiring.teleport[0];
			array[5] = Wiring.teleport[1];
			for (int num = 0; num < 5; num += 2)
			{
				Wiring.teleport[0] = array[num];
				Wiring.teleport[1] = array[num + 1];
				if (Wiring.teleport[0].X >= 0f && Wiring.teleport[1].X >= 0f)
				{
					Wiring.Teleport();
				}
			}
			Wiring.running = false;
		}
		private static void hitWire(DoubleStack<Point16> next, int wireType)
		{
			if (toProcess == null)
				toProcess = new Dictionary<Point16, byte>();
			if (wireSkip == null)
				wireSkip = new Dictionary<Point16, bool>();

			for (int i = 0; i < next.Count; i++)
			{
				Point16 point = next.PopFront();
				Wiring.SkipWire(point);
				Wiring.toProcess.Add(point, 4);
				next.PushBack(point);
			}
			while (next.Count > 0)
			{
				Point16 key = next.PopFront();
				int x = (int)key.x;
				int y = (int)key.y;
				if (!Wiring.wireSkip.ContainsKey(key))
				{
					Wiring.hitWireSingle(x, y);
				}
				for (int j = 0; j < 4; j++)
				{
					int num;
					int num2;
					switch (j)
					{
					case 0:
						num = x;
						num2 = y + 1;
						break;
					case 1:
						num = x;
						num2 = y - 1;
						break;
					case 2:
						num = x + 1;
						num2 = y;
						break;
					case 3:
						num = x - 1;
						num2 = y;
						break;
					default:
						num = x;
						num2 = y + 1;
						break;
					}
					if (num >= 2 && num < Main.maxTilesX - 2 && num2 >= 2 && num2 < Main.maxTilesY - 2)
					{
						Tile tile = Main.tile[num, num2];
						if (tile != null)
						{
							bool flag;
							switch (wireType)
							{
							case 1:
								flag = tile.wire();
								break;
							case 2:
								flag = tile.wire2();
								break;
							case 3:
								flag = tile.wire3();
								break;
							default:
								flag = false;
								break;
							}
							if (flag)
							{
								Point16 point2 = new Point16(num, num2);
								byte b;
								if (Wiring.toProcess.TryGetValue(point2, out b))
								{
									b -= 1;
									if (b == 0)
									{
										Wiring.toProcess.Remove(point2);
									}
									else
									{
										Wiring.toProcess[point2] = b;
									}
								}
								else
								{
									next.PushBack(point2);
									Wiring.toProcess.Add(point2, 3);
								}
							}
						}
					}
				}
			}
			Wiring.wireSkip.Clear();
			Wiring.toProcess.Clear();
		}
		private static bool hitWireSingle(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			int type = (int)tile.type;
			if (tile.active() && type >= 255 && type <= 268)
			{
				if (type >= 262)
				{
					Tile expr_35 = tile;
					expr_35.type -= 7;
				}
				else
				{
					Tile expr_46 = tile;
					expr_46.type += 7;
				}
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
			if (tile.actuator() && (type != 226 || (double)j <= Main.worldSurface || NPC.downedPlantBoss))
			{
				if (tile.inActive())
				{
					Wiring.ReActive(i, j);
				}
				else
				{
					Wiring.DeActive(i, j);
				}
			}
			if (tile.active())
			{
				if (type == 144)
				{
					Wiring.hitSwitch(i, j);
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				else if (type == 130)
				{
					if (Main.tile[i, j - 1] == null || !Main.tile[i, j - 1].active() || Main.tile[i, j - 1].type != 21)
					{
						tile.type = 131;
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
				}
				else if (type == 131)
				{
					tile.type = 130;
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				else if (type == 11)
				{
					if (WorldGen.CloseDoor(i, j, true))
					{
						NetMessage.SendData(19, -1, -1, "", 1, (float)i, (float)j, 0f, 0);
					}
				}
				else if (type == 10)
				{
					int num = 1;
					if (Main.rand.Next(2) == 0)
					{
						num = -1;
					}
					if (!WorldGen.OpenDoor(i, j, num))
					{
						if (WorldGen.OpenDoor(i, j, -num))
						{
							NetMessage.SendData(19, -1, -1, "", 0, (float)i, (float)j, (float)(-(float)num), 0);
						}
					}
					else
					{
						NetMessage.SendData(19, -1, -1, "", 0, (float)i, (float)j, (float)num, 0);
					}
				}
				else if (type == 216)
				{
					WorldGen.LaunchRocket(i, j);
					Wiring.SkipWire(i, j);
				}
				else if (type == 335)
				{
					int num2 = j - (int)(tile.frameY / 18);
					int num3 = i - (int)(tile.frameX / 18);
					Wiring.SkipWire(num3, num2);
					Wiring.SkipWire(num3, num2 + 1);
					Wiring.SkipWire(num3 + 1, num2);
					Wiring.SkipWire(num3 + 1, num2 + 1);
					if (Wiring.checkMech(num3, num2, 30))
					{
						WorldGen.LaunchRocketSmall(num3, num2);
					}
				}
				else if (type == 338)
				{
					int num4 = j - (int)(tile.frameY / 18);
					int num5 = i - (int)(tile.frameX / 18);
					Wiring.SkipWire(num5, num4);
					Wiring.SkipWire(num5, num4 + 1);
					if (Wiring.checkMech(num5, num4, 30))
					{
						bool flag = false;
						for (int k = 0; k < 1000; k++)
						{
							if (Main.projectile[k].active && Main.projectile[k].aiStyle == 73 && Main.projectile[k].ai[0] == (float)num5 && Main.projectile[k].ai[1] == (float)num4)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							Projectile.NewProjectile((float)(num5 * 16 + 8), (float)(num4 * 16 + 2), 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, Main.myPlayer, (float)num5, (float)num4);
						}
					}
				}
				else if (type == 235)
				{
					int num6 = i - (int)(tile.frameX / 18);
					if (tile.wall != 87 || (double)j <= Main.worldSurface || NPC.downedPlantBoss)
					{
						if (Wiring.teleport[0].X == -1f)
						{
							Wiring.teleport[0].X = (float)num6;
							Wiring.teleport[0].Y = (float)j;
							if (tile.halfBrick())
							{
								Vector2[] expr_3EF_cp_0 = Wiring.teleport;
								int expr_3EF_cp_1 = 0;
								expr_3EF_cp_0[expr_3EF_cp_1].Y = expr_3EF_cp_0[expr_3EF_cp_1].Y + 0.5f;
							}
						}
						else if (Wiring.teleport[0].X != (float)num6 || Wiring.teleport[0].Y != (float)j)
						{
							Wiring.teleport[1].X = (float)num6;
							Wiring.teleport[1].Y = (float)j;
							if (tile.halfBrick())
							{
								Vector2[] expr_46C_cp_0 = Wiring.teleport;
								int expr_46C_cp_1 = 1;
								expr_46C_cp_0[expr_46C_cp_1].Y = expr_46C_cp_0[expr_46C_cp_1].Y + 0.5f;
							}
						}
					}
				}
				else if (type == 4)
				{
					if (tile.frameX < 66)
					{
						Tile expr_491 = tile;
						expr_491.frameX += 66;
					}
					else
					{
						Tile expr_4A3 = tile;
						expr_4A3.frameX -= 66;
					}
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				else if (type == 149)
				{
					if (tile.frameX < 54)
					{
						Tile expr_4D3 = tile;
						expr_4D3.frameX += 54;
					}
					else
					{
						Tile expr_4E5 = tile;
						expr_4E5.frameX -= 54;
					}
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				else if (type == 244)
				{
					int l;
					for (l = (int)(tile.frameX / 18); l >= 3; l -= 3)
					{
					}
					int m;
					for (m = (int)(tile.frameY / 18); m >= 3; m -= 3)
					{
					}
					int num7 = i - l;
					int num8 = j - m;
					int num9 = 54;
					if (Main.tile[num7, num8].frameX >= 54)
					{
						num9 = -54;
					}
					for (int n = num7; n < num7 + 3; n++)
					{
						for (int num10 = num8; num10 < num8 + 2; num10++)
						{
							Wiring.SkipWire(n, num10);
							Main.tile[n, num10].frameX = (short)((int)Main.tile[n, num10].frameX + num9);
						}
					}
				}
				else if (type == 42)
				{
					int num11;
					for (num11 = (int)(tile.frameY / 18); num11 >= 2; num11 -= 2)
					{
					}
					int num12 = j - num11;
					short num13 = 18;
					if (tile.frameX > 0)
					{
						num13 = -18;
					}
					Tile expr_60C = Main.tile[i, num12];
					expr_60C.frameX += num13;
					Tile expr_62A = Main.tile[i, num12 + 1];
					expr_62A.frameX += num13;
					Wiring.SkipWire(i, num12);
					Wiring.SkipWire(i, num12 + 1);
					NetMessage.SendTileSquare(-1, i, j, 2);
				}
				else if (type == 93)
				{
					int num14;
					for (num14 = (int)(tile.frameY / 18); num14 >= 3; num14 -= 3)
					{
					}
					num14 = j - num14;
					short num15 = 18;
					if (tile.frameX > 0)
					{
						num15 = -18;
					}
					Tile expr_69D = Main.tile[i, num14];
					expr_69D.frameX += num15;
					Tile expr_6BB = Main.tile[i, num14 + 1];
					expr_6BB.frameX += num15;
					Tile expr_6D9 = Main.tile[i, num14 + 2];
					expr_6D9.frameX += num15;
					Wiring.SkipWire(i, num14);
					Wiring.SkipWire(i, num14 + 1);
					Wiring.SkipWire(i, num14 + 2);
					NetMessage.SendTileSquare(-1, i, num14 + 1, 3);
				}
				else if (type == 126 || type == 95 || type == 100 || type == 173)
				{
					int num16;
					for (num16 = (int)(tile.frameY / 18); num16 >= 2; num16 -= 2)
					{
					}
					num16 = j - num16;
					int num17 = (int)(tile.frameX / 18);
					if (num17 > 1)
					{
						num17 -= 2;
					}
					num17 = i - num17;
					short num18 = 36;
					if (Main.tile[num17, num16].frameX > 0)
					{
						num18 = -36;
					}
					Tile expr_795 = Main.tile[num17, num16];
					expr_795.frameX += num18;
					Tile expr_7B4 = Main.tile[num17, num16 + 1];
					expr_7B4.frameX += num18;
					Tile expr_7D3 = Main.tile[num17 + 1, num16];
					expr_7D3.frameX += num18;
					Tile expr_7F4 = Main.tile[num17 + 1, num16 + 1];
					expr_7F4.frameX += num18;
					Wiring.SkipWire(num17, num16);
					Wiring.SkipWire(num17 + 1, num16);
					Wiring.SkipWire(num17, num16 + 1);
					Wiring.SkipWire(num17 + 1, num16 + 1);
					NetMessage.SendTileSquare(-1, num17, num16, 3);
				}
				else if (type == 34)
				{
					int num19;
					for (num19 = (int)(tile.frameY / 18); num19 >= 3; num19 -= 3)
					{
					}
					int num20 = j - num19;
					int num21 = (int)(tile.frameX / 18);
					if (num21 > 2)
					{
						num21 -= 3;
					}
					num21 = i - num21;
					short num22 = 54;
					if (Main.tile[num21, num20].frameX > 0)
					{
						num22 = -54;
					}
					for (int num23 = num21; num23 < num21 + 3; num23++)
					{
						for (int num24 = num20; num24 < num20 + 3; num24++)
						{
							Tile expr_8B9 = Main.tile[num23, num24];
							expr_8B9.frameX += num22;
							Wiring.SkipWire(num23, num24);
						}
					}
					NetMessage.SendTileSquare(-1, num21 + 1, num20 + 1, 3);
				}
				else if (type == 314)
				{
					if (Wiring.checkMech(i, j, 5))
					{
						Minecart.FlipSwitchTrack(i, j);
					}
				}
				else if (type == 33 || type == 174)
				{
					short num25 = 18;
					if (tile.frameX > 0)
					{
						num25 = -18;
					}
					Tile expr_934 = tile;
					expr_934.frameX += num25;
					NetMessage.SendTileSquare(-1, i, j, 3);
				}
				else if (type == 92)
				{
					int num26 = j - (int)(tile.frameY / 18);
					short num27 = 18;
					if (tile.frameX > 0)
					{
						num27 = -18;
					}
					for (int num28 = num26; num28 < num26 + 6; num28++)
					{
						Tile expr_987 = Main.tile[i, num28];
						expr_987.frameX += num27;
						Wiring.SkipWire(i, num28);
					}
					NetMessage.SendTileSquare(-1, i, num26 + 3, 7);
				}
				else if (type == 137)
				{
					int num29 = (int)(tile.frameY / 18);
					if (num29 == 0 && Wiring.checkMech(i, j, 180))
					{
						int num30 = -1;
						if (tile.frameX != 0)
						{
							num30 = 1;
						}
						float speedX = (float)(12 * num30);
						int damage = 20;
						int type2 = 98;
						Vector2 vector = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
						vector.X += (float)(10 * num30);
						vector.Y += 2f;
						Projectile.NewProjectile((float)((int)vector.X), (float)((int)vector.Y), speedX, 0f, type2, damage, 2f, Main.myPlayer, 0f, 0f);
					}
					if (num29 == 1 && Wiring.checkMech(i, j, 180))
					{
						int num31 = -1;
						if (tile.frameX != 0)
						{
							num31 = 1;
						}
						float speedX2 = (float)(12 * num31);
						int damage2 = 40;
						int type3 = 184;
						Vector2 vector2 = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
						vector2.X += (float)(10 * num31);
						vector2.Y += 2f;
						Projectile.NewProjectile((float)((int)vector2.X), (float)((int)vector2.Y), speedX2, 0f, type3, damage2, 2f, Main.myPlayer, 0f, 0f);
					}
					if (num29 == 2 && Wiring.checkMech(i, j, 180))
					{
						int num32 = -1;
						if (tile.frameX != 0)
						{
							num32 = 1;
						}
						float speedX3 = (float)(5 * num32);
						int damage3 = 40;
						int type4 = 187;
						Vector2 vector3 = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
						vector3.X += (float)(10 * num32);
						vector3.Y += 2f;
						Projectile.NewProjectile((float)((int)vector3.X), (float)((int)vector3.Y), speedX3, 0f, type4, damage3, 2f, Main.myPlayer, 0f, 0f);
					}
					if (num29 == 3 && Wiring.checkMech(i, j, 240))
					{
						float speedX4 = (float)Main.rand.Next(-20, 21) * 0.05f;
						float speedY = 4f + (float)Main.rand.Next(0, 21) * 0.05f;
						int damage4 = 40;
						int type5 = 185;
						Vector2 vector4 = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16));
						vector4.Y += 6f;
						Projectile.NewProjectile((float)((int)vector4.X), (float)((int)vector4.Y), speedX4, speedY, type5, damage4, 2f, Main.myPlayer, 0f, 0f);
					}
					if (num29 == 4 && Wiring.checkMech(i, j, 90))
					{
						float speedX5 = 0f;
						float speedY2 = 8f;
						int damage5 = 60;
						int type6 = 186;
						Vector2 vector5 = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16));
						vector5.Y += 10f;
						Projectile.NewProjectile((float)((int)vector5.X), (float)((int)vector5.Y), speedX5, speedY2, type6, damage5, 2f, Main.myPlayer, 0f, 0f);
					}
				}
				else if (type == 139 || type == 35)
				{
					WorldGen.SwitchMB(i, j);
				}
				else if (type == 207)
				{
					WorldGen.SwitchFountain(i, j);
				}
				else if (type == 141)
				{
					WorldGen.KillTile(i, j, false, false, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
					Projectile.NewProjectile((float)(i * 16 + 8), (float)(j * 16 + 8), 0f, 0f, 108, 250, 10f, Main.myPlayer, 0f, 0f);
				}
				else if (type == 210)
				{
					WorldGen.ExplodeMine(i, j);
				}
				else if (type == 142 || type == 143)
				{
					int num33 = j - (int)(tile.frameY / 18);
					int num34 = (int)(tile.frameX / 18);
					if (num34 > 1)
					{
						num34 -= 2;
					}
					num34 = i - num34;
					Wiring.SkipWire(num34, num33);
					Wiring.SkipWire(num34, num33 + 1);
					Wiring.SkipWire(num34 + 1, num33);
					Wiring.SkipWire(num34 + 1, num33 + 1);
					if (type == 142)
					{
						for (int num35 = 0; num35 < 4; num35++)
						{
							if (Wiring.numInPump >= Wiring.maxPump - 1)
							{
								break;
							}
							int num36;
							int num37;
							if (num35 == 0)
							{
								num36 = num34;
								num37 = num33 + 1;
							}
							else if (num35 == 1)
							{
								num36 = num34 + 1;
								num37 = num33 + 1;
							}
							else if (num35 == 2)
							{
								num36 = num34;
								num37 = num33;
							}
							else
							{
								num36 = num34 + 1;
								num37 = num33;
							}
							Wiring.inPumpX[Wiring.numInPump] = num36;
							Wiring.inPumpY[Wiring.numInPump] = num37;
							Wiring.numInPump++;
						}
					}
					else
					{
						for (int num38 = 0; num38 < 4; num38++)
						{
							if (Wiring.numOutPump >= Wiring.maxPump - 1)
							{
								break;
							}
							int num39;
							int num40;
							if (num38 == 0)
							{
								num39 = num34;
								num40 = num33 + 1;
							}
							else if (num38 == 1)
							{
								num39 = num34 + 1;
								num40 = num33 + 1;
							}
							else if (num38 == 2)
							{
								num39 = num34;
								num40 = num33;
							}
							else
							{
								num39 = num34 + 1;
								num40 = num33;
							}
							Wiring.outPumpX[Wiring.numOutPump] = num39;
							Wiring.outPumpY[Wiring.numOutPump] = num40;
							Wiring.numOutPump++;
						}
					}
				}
				else if (type == 105)
				{
					int num41 = j - (int)(tile.frameY / 18);
					int num42 = (int)(tile.frameX / 18);
					int num43 = 0;
					while (num42 >= 2)
					{
						num42 -= 2;
						num43++;
					}
					num42 = i - num42;
					Wiring.SkipWire(num42, num41);
					Wiring.SkipWire(num42, num41 + 1);
					Wiring.SkipWire(num42, num41 + 2);
					Wiring.SkipWire(num42 + 1, num41);
					Wiring.SkipWire(num42 + 1, num41 + 1);
					Wiring.SkipWire(num42 + 1, num41 + 2);
					int num44 = num42 * 16 + 16;
					int num45 = (num41 + 3) * 16;
					int num46 = -1;
					if (num43 == 4)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 1))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 1, 0);
						}
					}
					else if (num43 == 7)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 49))
						{
							num46 = NPC.NewNPC(num44 - 4, num45 - 6, 49, 0);
						}
					}
					else if (num43 == 8)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 55))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 55, 0);
						}
					}
					else if (num43 == 9)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 46))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 46, 0);
						}
					}
					else if (num43 == 10)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 21))
						{
							num46 = NPC.NewNPC(num44, num45, 21, 0);
						}
					}
					else if (num43 == 18)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 67))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 67, 0);
						}
					}
					else if (num43 == 23)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 63))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 63, 0);
						}
					}
					else if (num43 == 27)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 85))
						{
							num46 = NPC.NewNPC(num44 - 9, num45, 85, 0);
						}
					}
					else if (num43 == 28)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 74))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 74, 0);
						}
					}
					else if (num43 == 42)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 58))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 58, 0);
						}
					}
					else if (num43 == 37)
					{
						if (Wiring.checkMech(i, j, 600) && Item.MechSpawn((float)num44, (float)num45, 58) && Item.MechSpawn((float)num44, (float)num45, 1734) && Item.MechSpawn((float)num44, (float)num45, 1867))
						{
							Item.NewItem(num44, num45 - 16, 0, 0, 58, 1, false, 0, false);
						}
					}
					else if (num43 == 50)
					{
						if (Wiring.checkMech(i, j, 30) && NPC.MechSpawn((float)num44, (float)num45, 65) && !Collision.SolidTiles(num42 - 2, num42 + 3, num41, num41 + 2))
						{
							num46 = NPC.NewNPC(num44, num45 - 12, 65, 0);
						}
					}
					else if (num43 == 2)
					{
						if (Wiring.checkMech(i, j, 600) && Item.MechSpawn((float)num44, (float)num45, 184) && Item.MechSpawn((float)num44, (float)num45, 1735) && Item.MechSpawn((float)num44, (float)num45, 1868))
						{
							Item.NewItem(num44, num45 - 16, 0, 0, 184, 1, false, 0, false);
						}
					}
					else if (num43 == 17)
					{
						if (Wiring.checkMech(i, j, 600) && Item.MechSpawn((float)num44, (float)num45, 166))
						{
							Item.NewItem(num44, num45 - 20, 0, 0, 166, 1, false, 0, false);
						}
					}
					else if (num43 == 40)
					{
						if (Wiring.checkMech(i, j, 300))
						{
							int[] array = new int[10];
							int num47 = 0;
							for (int num48 = 0; num48 < 200; num48++)
							{
								if (Main.npc[num48].active && (Main.npc[num48].type == 17 || Main.npc[num48].type == 19 || Main.npc[num48].type == 22 || Main.npc[num48].type == 38 || Main.npc[num48].type == 54 || Main.npc[num48].type == 107 || Main.npc[num48].type == 108 || Main.npc[num48].type == 142 || Main.npc[num48].type == 160 || Main.npc[num48].type == 207 || Main.npc[num48].type == 209 || Main.npc[num48].type == 227 || Main.npc[num48].type == 228 || Main.npc[num48].type == 229 || Main.npc[num48].type == 358 || Main.npc[num48].type == 369))
								{
									array[num47] = num48;
									num47++;
									if (num47 >= 9)
									{
										break;
									}
								}
							}
							if (num47 > 0)
							{
								int num49 = array[Main.rand.Next(num47)];
								Main.npc[num49].position.X = (float)(num44 - Main.npc[num49].width / 2);
								Main.npc[num49].position.Y = (float)(num45 - Main.npc[num49].height - 1);
								NetMessage.SendData(23, -1, -1, "", num49, 0f, 0f, 0f, 0);
							}
						}
					}
					else if (num43 == 41 && Wiring.checkMech(i, j, 300))
					{
						int[] array2 = new int[10];
						int num50 = 0;
						for (int num51 = 0; num51 < 200; num51++)
						{
							if (Main.npc[num51].active && (Main.npc[num51].type == 18 || Main.npc[num51].type == 20 || Main.npc[num51].type == 124 || Main.npc[num51].type == 178 || Main.npc[num51].type == 208 || Main.npc[num51].type == 353))
							{
								array2[num50] = num51;
								num50++;
								if (num50 >= 9)
								{
									break;
								}
							}
						}
						if (num50 > 0)
						{
							int num52 = array2[Main.rand.Next(num50)];
							Main.npc[num52].position.X = (float)(num44 - Main.npc[num52].width / 2);
							Main.npc[num52].position.Y = (float)(num45 - Main.npc[num52].height - 1);
							NetMessage.SendData(23, -1, -1, "", num52, 0f, 0f, 0f, 0);
						}
					}
					if (num46 >= 0)
					{
						Main.npc[num46].value = 0f;
						Main.npc[num46].npcSlots = 0f;
					}
				}
			}
			return true;
		}
		public static void Teleport()
		{
			if (Wiring.teleport[0].X < Wiring.teleport[1].X + 3f && Wiring.teleport[0].X > Wiring.teleport[1].X - 3f && Wiring.teleport[0].Y > Wiring.teleport[1].Y - 3f && Wiring.teleport[0].Y < Wiring.teleport[1].Y)
			{
				return;
			}
			Rectangle[] array = new Rectangle[2];
			array[0].X = (int)(Wiring.teleport[0].X * 16f);
			array[0].Width = 48;
			array[0].Height = 48;
			array[0].Y = (int)(Wiring.teleport[0].Y * 16f - (float)array[0].Height);
			array[1].X = (int)(Wiring.teleport[1].X * 16f);
			array[1].Width = 48;
			array[1].Height = 48;
			array[1].Y = (int)(Wiring.teleport[1].Y * 16f - (float)array[1].Height);
			for (int i = 0; i < 2; i++)
			{
				Vector2 value = new Vector2((float)(array[1].X - array[0].X), (float)(array[1].Y - array[0].Y));
				if (i == 1)
				{
					value = new Vector2((float)(array[0].X - array[1].X), (float)(array[0].Y - array[1].Y));
				}
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && !Main.player[j].dead && !Main.player[j].teleporting && array[i].Intersects(Main.player[j].getRect()))
					{
						Vector2 vector = Main.player[j].position + value;
						Main.player[j].teleporting = true;
						if (Main.netMode == 2)
						{
							ServerSock.CheckSection(j, vector);
						}
						Main.player[j].Teleport(vector, 0);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(65, -1, -1, "", 0, (float)j, vector.X, vector.Y, 0);
						}
					}
				}
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].teleporting && Main.npc[k].lifeMax > 5 && !Main.npc[k].boss && !Main.npc[k].noTileCollide && array[i].Intersects(Main.npc[k].getRect()))
					{
						Main.npc[k].teleporting = true;
						Main.npc[k].Teleport(Main.npc[k].position + value, 0);
					}
				}
			}
			for (int l = 0; l < 255; l++)
			{
				Main.player[l].teleporting = false;
			}
			for (int m = 0; m < 200; m++)
			{
				Main.npc[m].teleporting = false;
			}
		}
		public static bool DeActive(int i, int j)
		{
			if (!Main.tile[i, j].active() || ((!Main.tileSolid[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 10) && Main.tile[i, j].type != 314))
			{
				return false;
			}
			if (Main.tile[i, j - 1].active() && (Main.tile[i, j - 1].type == 5 || Main.tile[i, j - 1].type == 21 || Main.tile[i, j - 1].type == 26 || Main.tile[i, j - 1].type == 77 || Main.tile[i, j - 1].type == 72))
			{
				return false;
			}
			Main.tile[i, j].inActive(true);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
			return true;
		}
		public static bool ReActive(int i, int j)
		{
			Main.tile[i, j].inActive(false);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
			return true;
		}
	}
}
