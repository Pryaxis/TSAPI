
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria
{
	public static class Wiring
	{
		private const int MaxPump = 20;

		private const int MaxMech = 1000;

		public static bool running;

		private static Dictionary<Point16, bool> _wireSkip;

		private static DoubleStack<Point16> _wireList;

		private static Dictionary<Point16, byte> _toProcess;

		public static Vector2[] _teleport;

		private static int[] _inPumpX;

		private static int[] _inPumpY;

		private static int _numInPump;

		private static int[] _outPumpX;

		private static int[] _outPumpY;

		private static int _numOutPump;

		private static int[] _mechX;

		private static int[] _mechY;

		private static int _numMechs;

		private static int[] _mechTime;

		public static bool CheckMech(int i, int j, int time)
		{
			for (int num = 0; num < Wiring._numMechs; num++)
			{
				if (Wiring._mechX[num] == i && Wiring._mechY[num] == j)
				{
					return false;
				}
			}
			if (Wiring._numMechs >= 999)
			{
				return false;
			}
			Wiring._mechX[Wiring._numMechs] = i;
			Wiring._mechY[Wiring._numMechs] = j;
			Wiring._mechTime[Wiring._numMechs] = time;
			Wiring._numMechs = Wiring._numMechs + 1;
			return true;
		}

		public static void DeActive(int i, int j)
		{
			if (!Main.tile[i, j].active())
			{
				return;
			}
			bool flag = (!Main.tileSolid[Main.tile[i, j].type] ? false : !TileID.Sets.NotReallySolid[Main.tile[i, j].type]);
			ushort num = Main.tile[i, j].type;
			if (num != 314)
			{
				switch (num)
				{
					case 386:
					case 387:
					case 388:
					case 389:
					{
						break;
					}
					default:
					{
						if (!flag)
						{
							return;
						}
						if (Main.tile[i, j - 1].active() && (Main.tile[i, j - 1].type == 5 || Main.tile[i, j - 1].type == 21 || Main.tile[i, j - 1].type == 26 || Main.tile[i, j - 1].type == 77 || Main.tile[i, j - 1].type == 72))
						{
							return;
						}
						Main.tile[i, j].inActive(true);
						WorldGen.SquareTileFrame(i, j, false);
						if (Main.netMode != 1)
						{
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						return;
					}
				}
			}
			flag = false;
			if (!flag)
			{
				return;
			}
			if (Main.tile[i, j - 1].active() && (Main.tile[i, j - 1].type == 5 || Main.tile[i, j - 1].type == 21 || Main.tile[i, j - 1].type == 26 || Main.tile[i, j - 1].type == 77 || Main.tile[i, j - 1].type == 72))
			{
				return;
			}
			Main.tile[i, j].inActive(true);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
		}

		public static void HitSwitch(int i, int j)
		{
			if (!WorldGen.InWorld(i, j, 0))
			{
				return;
			}
			if (Main.tile[i, j] == null)
			{
				return;
			}
			if (Main.tile[i, j].type == TileID.PressurePlates || Main.tile[i, j].type == TileID.MinecartTrack)
			{
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == TileID.Switches)
			{
				if (Main.tile[i, j].frameY != 0)
				{
					Main.tile[i, j].frameY = 0;
				}
				else
				{
					Main.tile[i, j].frameY = 18;
				}
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == TileID.Timers)
			{
				if (Main.tile[i, j].frameY != 0)
				{
					Main.tile[i, j].frameY = 0;
				}
				else
				{
					Main.tile[i, j].frameY = 18;
					if (Main.netMode != 1)
					{
						Wiring.CheckMech(i, j, 18000);
					}
				}
				return;
			}
			if (Main.tile[i, j].type == TileID.Lever || Main.tile[i, j].type == TileID.Detonator)
			{
				short num = 36;
				int num1 = Main.tile[i, j].frameX / 18 * -1;
				int num2 = Main.tile[i, j].frameY / 18 * -1;
				num1 = num1 % 4;
				if (num1 < -1)
				{
					num1 = num1 + 2;
					num = -36;
				}
				num1 = num1 + i;
				num2 = num2 + j;
				if (Main.netMode != 1 && Main.tile[num1, num2].type == TileID.Detonator)
				{
					Wiring.CheckMech(num1, num2, 60);
				}
				for (int i1 = num1; i1 < num1 + 2; i1++)
				{
					for (int j1 = num2; j1 < num2 + 2; j1++)
					{
						if (Main.tile[i1, j1].type == TileID.Lever || Main.tile[i1, j1].type == TileID.Detonator)
						{
							Tile tile = Main.tile[i1, j1];
							tile.frameX = (short)(tile.frameX + num);
						}
					}
				}
				WorldGen.TileFrame(num1, num2, false, false);
				Wiring.TripWire(num1, num2, 2, 2);
			}
		}

		private static void HitWire(DoubleStack<Point16> next, int wireType)
		{
			int num;
			int num1;
			bool flag;
			byte num2;
			for (int i = 0; i < next.Count; i++)
			{
				Point16 point16 = next.PopFront();
				Wiring.SkipWire(point16);
				Wiring._toProcess[point16] = 4;
				next.PushBack(point16);
			}
			while (next.Count > 0)
			{
				Point16 point161 = next.PopFront();
				int x = point161.X;
				int y = point161.Y;
				if (!Wiring._wireSkip.ContainsKey(point161))
				{
					Wiring.HitWireSingle(x, y);
				}
				for (int j = 0; j < 4; j++)
				{
					switch (j)
					{
						case 0:
						{
							num = x;
							num1 = y + 1;
							break;
						}
						case 1:
						{
							num = x;
							num1 = y - 1;
							break;
						}
						case 2:
						{
							num = x + 1;
							num1 = y;
							break;
						}
						case 3:
						{
							num = x - 1;
							num1 = y;
							break;
						}
						default:
						{
							num = x;
							num1 = y + 1;
							break;
						}
					}
					if (num >= 2 && num < Main.maxTilesX - 2 && num1 >= 2 && num1 < Main.maxTilesY - 2)
					{
						Tile tile = Main.tile[num, num1];
						if (tile != null)
						{
							switch (wireType)
							{
								case 1:
								{
									flag = tile.wire();
									break;
								}
								case 2:
								{
									flag = tile.wire2();
									break;
								}
								case 3:
								{
									flag = tile.wire3();
									break;
								}
								default:
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								Point16 point162 = new Point16(num, num1);
								if (!Wiring._toProcess.TryGetValue(point162, out num2))
								{
									next.PushBack(point162);
									Wiring._toProcess[point162] = 3;
								}
								else
								{
									num2 = (byte)(num2 - 1);
									if (num2 != 0)
									{
										Wiring._toProcess[point162] = num2;
									}
									else
									{
										Wiring._toProcess.Remove(point162);
									}
								}
							}
						}
					}
				}
			}
			Wiring._wireSkip.Clear();
			Wiring._toProcess.Clear();
			Wiring.running = false;
		}

		private static void HitWireSingle(int i, int j)
		{
			int num;
			int num1;
			short num2;
			Tile tile = Main.tile[i, j];
			int num3 = tile.type;
			if (tile.active() && num3 >= 255 && num3 <= 268)
			{
				if (num3 < 262)
				{
					Tile tile1 = tile;
					tile1.type = (ushort)(tile1.type + 7);
				}
				else
				{
					Tile tile2 = tile;
					tile2.type = (ushort)(tile2.type - 7);
				}
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
			if (tile.actuator() && (num3 != 226 || (double)j <= Main.worldSurface || NPC.downedPlantBoss))
			{
				if (!tile.inActive())
				{
					Wiring.DeActive(i, j);
				}
				else
				{
					Wiring.ReActive(i, j);
				}
			}
			if (tile.active())
			{
				if (num3 == 144)
				{
					Wiring.HitSwitch(i, j);
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
					return;
				}
				if (num3 == 406)
				{
					int num4 = tile.frameX % 54 / 18;
					int num5 = tile.frameY % 54 / 18;
					int num6 = i - num4;
					int num7 = j - num5;
					int num8 = 54;
					if (Main.tile[num6, num7].frameY >= 108)
					{
						num8 = -108;
					}
					for (int i1 = num6; i1 < num6 + 3; i1++)
					{
						for (int j1 = num7; j1 < num7 + 3; j1++)
						{
							Wiring.SkipWire(i1, j1);
							Main.tile[i1, j1].frameY = (short)(Main.tile[i1, j1].frameY + num8);
						}
					}
					NetMessage.SendTileSquare(-1, num6 + 1, num7 + 1, 3);
					return;
				}
				if (num3 == 411)
				{
					int num9 = tile.frameX % 36 / 18;
					int num10 = tile.frameY % 36 / 18;
					int num11 = i - num9;
					int num12 = j - num10;
					int num13 = 36;
					if (Main.tile[num11, num12].frameX >= 36)
					{
						num13 = -36;
					}
					for (int k = num11; k < num11 + 2; k++)
					{
						for (int l = num12; l < num12 + 2; l++)
						{
							Wiring.SkipWire(k, l);
							Main.tile[k, l].frameX = (short)(Main.tile[k, l].frameX + num13);
						}
					}
					NetMessage.SendTileSquare(-1, num11, num12, 2);
					return;
				}
				if (num3 == 405)
				{
					int num14 = tile.frameX % 54 / 18;
					int num15 = tile.frameY % 36 / 18;
					int num16 = i - num14;
					int num17 = j - num15;
					int num18 = 54;
					if (Main.tile[num16, num17].frameX >= 54)
					{
						num18 = -54;
					}
					for (int m = num16; m < num16 + 3; m++)
					{
						for (int n = num17; n < num17 + 2; n++)
						{
							Wiring.SkipWire(m, n);
							Main.tile[m, n].frameX = (short)(Main.tile[m, n].frameX + num18);
						}
					}
					NetMessage.SendTileSquare(-1, num16 + 1, num17 + 1, 3);
					return;
				}
				if (num3 == 215)
				{
					int num19 = tile.frameX % 54 / 18;
					int num20 = tile.frameY % 36 / 18;
					int num21 = i - num19;
					int num22 = j - num20;
					int num23 = 36;
					if (Main.tile[num21, num22].frameY >= 36)
					{
						num23 = -36;
					}
					for (int o = num21; o < num21 + 3; o++)
					{
						for (int p = num22; p < num22 + 2; p++)
						{
							Wiring.SkipWire(o, p);
							Main.tile[o, p].frameY = (short)(Main.tile[o, p].frameY + num23);
						}
					}
					NetMessage.SendTileSquare(-1, num21 + 1, num22 + 1, 3);
					return;
				}
				if (num3 != 130)
				{
					if (num3 == 131)
					{
						tile.type = 130;
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1);
						return;
					}
					if (num3 == 387 || num3 == 386)
					{
						bool flag = num3 == 387;
						int num24 = WorldGen.ShiftTrapdoor(i, j, true, -1).ToInt();
						if (num24 == 0)
						{
							num24 = -WorldGen.ShiftTrapdoor(i, j, false, -1).ToInt();
						}
						if (num24 != 0)
						{
							NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 2 + flag.ToInt(), (float)i, (float)j, (float)num24, 0, 0, 0);
							return;
						}
					}
					else
					{
						if (num3 == 389 || num3 == 388)
						{
							bool flag1 = num3 == 389;
							WorldGen.ShiftTallGate(i, j, flag1);
							NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 4 + flag1.ToInt(), (float)i, (float)j, 0f, 0, 0, 0);
							return;
						}
						if (num3 == 11)
						{
							if (WorldGen.CloseDoor(i, j, true))
							{
								NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 1, (float)i, (float)j, 0f, 0, 0, 0);
								return;
							}
						}
						else if (num3 != 10)
						{
							if (num3 == 216)
							{
								WorldGen.LaunchRocket(i, j);
								Wiring.SkipWire(i, j);
								return;
							}
							if (num3 == 335)
							{
								int num25 = j - tile.frameY / 18;
								int num26 = i - tile.frameX / 18;
								Wiring.SkipWire(num26, num25);
								Wiring.SkipWire(num26, num25 + 1);
								Wiring.SkipWire(num26 + 1, num25);
								Wiring.SkipWire(num26 + 1, num25 + 1);
								if (Wiring.CheckMech(num26, num25, 30))
								{
									WorldGen.LaunchRocketSmall(num26, num25);
									return;
								}
							}
							else if (num3 == 338)
							{
								int num27 = j - tile.frameY / 18;
								int num28 = i - tile.frameX / 18;
								Wiring.SkipWire(num28, num27);
								Wiring.SkipWire(num28, num27 + 1);
								if (Wiring.CheckMech(num28, num27, 30))
								{
									bool flag2 = false;
									int num29 = 0;
									while (num29 < 1000)
									{
										if (!Main.projectile[num29].active || Main.projectile[num29].aiStyle != 73 || Main.projectile[num29].ai[0] != (float)num28 || Main.projectile[num29].ai[1] != (float)num27)
										{
											num29++;
										}
										else
										{
											flag2 = true;
											break;
										}
									}
									if (!flag2)
									{
										Projectile.NewProjectile((float)(num28 * 16 + 8), (float)(num27 * 16 + 2), 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, Main.myPlayer, (float)num28, (float)num27);
										return;
									}
								}
							}
							else if (num3 != 235)
							{
								if (num3 == 4)
								{
									if (tile.frameX >= 66)
									{
										Tile tile3 = tile;
										tile3.frameX = (short)(tile3.frameX - 66);
									}
									else
									{
										Tile tile4 = tile;
										tile4.frameX = (short)(tile4.frameX + 66);
									}
									NetMessage.SendTileSquare(-1, i, j, 1);
									return;
								}
								if (num3 == 149)
								{
									if (tile.frameX >= 54)
									{
										Tile tile5 = tile;
										tile5.frameX = (short)(tile5.frameX - 54);
									}
									else
									{
										Tile tile6 = tile;
										tile6.frameX = (short)(tile6.frameX + 54);
									}
									NetMessage.SendTileSquare(-1, i, j, 1);
									return;
								}
								if (num3 == 244)
								{
									int num30 = tile.frameX / 18;
									while (num30 >= 3)
									{
										num30 = num30 - 3;
									}
									int num31 = tile.frameY / 18;
									while (num31 >= 3)
									{
										num31 = num31 - 3;
									}
									int num32 = i - num30;
									int num33 = j - num31;
									int num34 = 54;
									if (Main.tile[num32, num33].frameX >= 54)
									{
										num34 = -54;
									}
									for (int q = num32; q < num32 + 3; q++)
									{
										for (int r = num33; r < num33 + 2; r++)
										{
											Wiring.SkipWire(q, r);
											Main.tile[q, r].frameX = (short)(Main.tile[q, r].frameX + num34);
										}
									}
									NetMessage.SendTileSquare(-1, num32 + 1, num33 + 1, 3);
									return;
								}
								if (num3 == 42)
								{
									int num35 = tile.frameY / 18;
									while (num35 >= 2)
									{
										num35 = num35 - 2;
									}
									int num36 = j - num35;
									short num37 = 18;
									if (tile.frameX > 0)
									{
										num37 = -18;
									}
									Tile tile7 = Main.tile[i, num36];
									tile7.frameX = (short)(tile7.frameX + num37);
									Tile tile8 = Main.tile[i, num36 + 1];
									tile8.frameX = (short)(tile8.frameX + num37);
									Wiring.SkipWire(i, num36);
									Wiring.SkipWire(i, num36 + 1);
									NetMessage.SendTileSquare(-1, i, j, 2);
									return;
								}
								if (num3 == 93)
								{
									int num38 = tile.frameY / 18;
									while (num38 >= 3)
									{
										num38 = num38 - 3;
									}
									num38 = j - num38;
									short num39 = 18;
									if (tile.frameX > 0)
									{
										num39 = -18;
									}
									Tile tile9 = Main.tile[i, num38];
									tile9.frameX = (short)(tile9.frameX + num39);
									Tile tile10 = Main.tile[i, num38 + 1];
									tile10.frameX = (short)(tile10.frameX + num39);
									Tile tile11 = Main.tile[i, num38 + 2];
									tile11.frameX = (short)(tile11.frameX + num39);
									Wiring.SkipWire(i, num38);
									Wiring.SkipWire(i, num38 + 1);
									Wiring.SkipWire(i, num38 + 2);
									NetMessage.SendTileSquare(-1, i, num38 + 1, 3);
									return;
								}
								if (num3 == 126 || num3 == 95 || num3 == 100 || num3 == 173)
								{
									int num40 = tile.frameY / 18;
									while (num40 >= 2)
									{
										num40 = num40 - 2;
									}
									num40 = j - num40;
									int num41 = tile.frameX / 18;
									if (num41 > 1)
									{
										num41 = num41 - 2;
									}
									num41 = i - num41;
									short num42 = 36;
									if (Main.tile[num41, num40].frameX > 0)
									{
										num42 = -36;
									}
									Tile tile12 = Main.tile[num41, num40];
									tile12.frameX = (short)(tile12.frameX + num42);
									Tile tile13 = Main.tile[num41, num40 + 1];
									tile13.frameX = (short)(tile13.frameX + num42);
									Tile tile14 = Main.tile[num41 + 1, num40];
									tile14.frameX = (short)(tile14.frameX + num42);
									Tile tile15 = Main.tile[num41 + 1, num40 + 1];
									tile15.frameX = (short)(tile15.frameX + num42);
									Wiring.SkipWire(num41, num40);
									Wiring.SkipWire(num41 + 1, num40);
									Wiring.SkipWire(num41, num40 + 1);
									Wiring.SkipWire(num41 + 1, num40 + 1);
									NetMessage.SendTileSquare(-1, num41, num40, 3);
									return;
								}
								if (num3 == 34)
								{
									int num43 = tile.frameY / 18;
									while (num43 >= 3)
									{
										num43 = num43 - 3;
									}
									int num44 = j - num43;
									int num45 = tile.frameX / 18;
									if (num45 > 2)
									{
										num45 = num45 - 3;
									}
									num45 = i - num45;
									short num46 = 54;
									if (Main.tile[num45, num44].frameX > 0)
									{
										num46 = -54;
									}
									for (int s = num45; s < num45 + 3; s++)
									{
										for (int t = num44; t < num44 + 3; t++)
										{
											Tile tile16 = Main.tile[s, t];
											tile16.frameX = (short)(tile16.frameX + num46);
											Wiring.SkipWire(s, t);
										}
									}
									NetMessage.SendTileSquare(-1, num45 + 1, num44 + 1, 3);
									return;
								}
								if (num3 != 314)
								{
									if (num3 == 33 || num3 == 174)
									{
										short num47 = 18;
										if (tile.frameX > 0)
										{
											num47 = -18;
										}
										Tile tile17 = tile;
										tile17.frameX = (short)(tile17.frameX + num47);
										NetMessage.SendTileSquare(-1, i, j, 3);
										return;
									}
									if (num3 == 92)
									{
										int num48 = j - tile.frameY / 18;
										short num49 = 18;
										if (tile.frameX > 0)
										{
											num49 = -18;
										}
										for (int u = num48; u < num48 + 6; u++)
										{
											Tile tile18 = Main.tile[i, u];
											tile18.frameX = (short)(tile18.frameX + num49);
											Wiring.SkipWire(i, u);
										}
										NetMessage.SendTileSquare(-1, i, num48 + 3, 7);
										return;
									}
									if (num3 != 137)
									{
										if (num3 == 139 || num3 == 35)
										{
											WorldGen.SwitchMB(i, j);
											return;
										}
										if (num3 == 207)
										{
											WorldGen.SwitchFountain(i, j);
											return;
										}
										if (num3 == 410)
										{
											WorldGen.SwitchMonolith(i, j);
											return;
										}
										if (num3 == 141)
										{
											WorldGen.KillTile(i, j, false, false, true);
											NetMessage.SendTileSquare(-1, i, j, 1);
											Projectile.NewProjectile((float)(i * 16 + 8), (float)(j * 16 + 8), 0f, 0f, 108, 500, 10f, Main.myPlayer, 0f, 0f);
											return;
										}
										if (num3 == 210)
										{
											WorldGen.ExplodeMine(i, j);
											return;
										}
										if (num3 == 142 || num3 == 143)
										{
											int num50 = j - tile.frameY / 18;
											int num51 = tile.frameX / 18;
											if (num51 > 1)
											{
												num51 = num51 - 2;
											}
											num51 = i - num51;
											Wiring.SkipWire(num51, num50);
											Wiring.SkipWire(num51, num50 + 1);
											Wiring.SkipWire(num51 + 1, num50);
											Wiring.SkipWire(num51 + 1, num50 + 1);
											if (num3 == 142)
											{
												for (int v = 0; v < 4; v++)
												{
													if (Wiring._numInPump >= 19)
													{
														return;
													}
													if (v == 0)
													{
														num = num51;
														num1 = num50 + 1;
													}
													else if (v == 1)
													{
														num = num51 + 1;
														num1 = num50 + 1;
													}
													else if (v != 2)
													{
														num = num51 + 1;
														num1 = num50;
													}
													else
													{
														num = num51;
														num1 = num50;
													}
													Wiring._inPumpX[Wiring._numInPump] = num;
													Wiring._inPumpY[Wiring._numInPump] = num1;
													Wiring._numInPump = Wiring._numInPump + 1;
												}
												return;
											}
											for (int w = 0; w < 4; w++)
											{
												if (Wiring._numOutPump >= 19)
												{
													return;
												}
												if (w == 0)
												{
													num = num51;
													num1 = num50 + 1;
												}
												else if (w == 1)
												{
													num = num51 + 1;
													num1 = num50 + 1;
												}
												else if (w != 2)
												{
													num = num51 + 1;
													num1 = num50;
												}
												else
												{
													num = num51;
													num1 = num50;
												}
												Wiring._outPumpX[Wiring._numOutPump] = num;
												Wiring._outPumpY[Wiring._numOutPump] = num1;
												Wiring._numOutPump = Wiring._numOutPump + 1;
											}
											return;
										}
										if (num3 == 105)
										{
											int num52 = j - tile.frameY / 18;
											int num53 = tile.frameX / 18;
											int num54 = 0;
											while (num53 >= 2)
											{
												num53 = num53 - 2;
												num54++;
											}
											num53 = i - num53;
											Wiring.SkipWire(num53, num52);
											Wiring.SkipWire(num53, num52 + 1);
											Wiring.SkipWire(num53, num52 + 2);
											Wiring.SkipWire(num53 + 1, num52);
											Wiring.SkipWire(num53 + 1, num52 + 1);
											Wiring.SkipWire(num53 + 1, num52 + 2);
											int num55 = num53 * 16 + 16;
											int num56 = (num52 + 3) * 16;
											int num57 = -1;
											if (num54 == 4)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 1))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 1, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 7)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 49))
												{
													num57 = NPC.NewNPC(num55 - 4, num56 - 6, 49, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 8)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 55))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 55, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 9)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 46))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 46, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 10)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 21))
												{
													num57 = NPC.NewNPC(num55, num56, 21, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 18)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 67))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 67, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 23)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 63))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 63, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 27)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 85))
												{
													num57 = NPC.NewNPC(num55 - 9, num56, 85, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 28)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 74))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 74, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 34)
											{
												for (int x = 0; x < 2; x++)
												{
													for (int y = 0; y < 3; y++)
													{
														Tile tile19 = Main.tile[num53 + x, num52 + y];
														tile19.type = 349;
														tile19.frameX = (short)(x * 18 + 216);
														tile19.frameY = (short)(y * 18);
													}
												}
												Animation.NewTemporaryAnimation(0, 349, num53, num52);
												if (Main.netMode == 2)
												{
													NetMessage.SendTileRange(-1, num53, num52, 2, 3);
												}
											}
											else if (num54 == 42)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 58))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 58, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 37)
											{
												if (Wiring.CheckMech(num53, num52, 600) && Item.MechSpawn((float)num55, (float)num56, 58) && Item.MechSpawn((float)num55, (float)num56, 1734) && Item.MechSpawn((float)num55, (float)num56, 1867))
												{
													Item.NewItem(num55, num56 - 16, 0, 0, 58, 1, false, 0, false);
												}
											}
											else if (num54 == 50)
											{
												if (Wiring.CheckMech(num53, num52, 30) && NPC.MechSpawn((float)num55, (float)num56, 65) && !Collision.SolidTiles(num53 - 2, num53 + 3, num52, num52 + 2))
												{
													num57 = NPC.NewNPC(num55, num56 - 12, 65, 0, 0f, 0f, 0f, 0f, 255);
												}
											}
											else if (num54 == 2)
											{
												if (Wiring.CheckMech(num53, num52, 600) && Item.MechSpawn((float)num55, (float)num56, 184) && Item.MechSpawn((float)num55, (float)num56, 1735) && Item.MechSpawn((float)num55, (float)num56, 1868))
												{
													Item.NewItem(num55, num56 - 16, 0, 0, 184, 1, false, 0, false);
												}
											}
											else if (num54 == 17)
											{
												if (Wiring.CheckMech(num53, num52, 600) && Item.MechSpawn((float)num55, (float)num56, 166))
												{
													Item.NewItem(num55, num56 - 20, 0, 0, 166, 1, false, 0, false);
												}
											}
											else if (num54 == 40)
											{
												if (Wiring.CheckMech(num53, num52, 300))
												{
													int[] numArray = new int[10];
													int num58 = 0;
													for (int a = 0; a < 200; a++)
													{
														if (Main.npc[a].active && (Main.npc[a].type == NPCID.Merchant || Main.npc[a].type == NPCID.ArmsDealer || Main.npc[a].type == NPCID.Guide || Main.npc[a].type == NPCID.Demolitionist || Main.npc[a].type == NPCID.Clothier || Main.npc[a].type == NPCID.GoblinTinkerer || Main.npc[a].type == NPCID.Wizard || Main.npc[a].type == NPCID.SantaClaus || Main.npc[a].type == NPCID.Truffle || Main.npc[a].type == NPCID.DyeTrader || Main.npc[a].type == NPCID.Cyborg || Main.npc[a].type == NPCID.Painter || Main.npc[a].type == NPCID.WitchDoctor || Main.npc[a].type == NPCID.Pirate || Main.npc[a].type == NPCID.LightningBug || Main.npc[a].type == NPCID.Angler))
														{
															numArray[num58] = a;
															num58++;
															if (num58 >= 9)
															{
																break;
															}
														}
													}
													if (num58 > 0)
													{
														int num59 = numArray[Main.rand.Next(num58)];
														Main.npc[num59].position.X = (float)(num55 - Main.npc[num59].width / 2);
														Main.npc[num59].position.Y = (float)(num56 - Main.npc[num59].height - 1);
														NetMessage.SendData((int)PacketTypes.NpcUpdate, -1, -1, "", num59, 0f, 0f, 0f, 0, 0, 0);
													}
												}
											}
											else if (num54 == 41 && Wiring.CheckMech(num53, num52, 300))
											{
												int[] numArray1 = new int[10];
												int num60 = 0;
												for (int b = 0; b < 200; b++)
												{
													if (Main.npc[b].active && (Main.npc[b].type == NPCID.Nurse || Main.npc[b].type == NPCID.Dryad || Main.npc[b].type == NPCID.Mechanic || Main.npc[b].type == NPCID.Steampunker || Main.npc[b].type == NPCID.PartyGirl || Main.npc[b].type == NPCID.Stylist))
													{
														numArray1[num60] = b;
														num60++;
														if (num60 >= 9)
														{
															break;
														}
													}
												}
												if (num60 > 0)
												{
													int num61 = numArray1[Main.rand.Next(num60)];
													Main.npc[num61].position.X = (float)(num55 - Main.npc[num61].width / 2);
													Main.npc[num61].position.Y = (float)(num56 - Main.npc[num61].height - 1);
													NetMessage.SendData((int)PacketTypes.NpcUpdate, -1, -1, "", num61, 0f, 0f, 0f, 0, 0, 0);
												}
											}
											if (num57 >= 0)
											{
												Main.npc[num57].@value = 0f;
												Main.npc[num57].npcSlots = 0f;
												return;
											}
										}
										else if (num3 == 349)
										{
											int num62 = j - tile.frameY / 18;
											int num63 = tile.frameX / 18;
											while (num63 >= 2)
											{
												num63 = num63 - 2;
											}
											num63 = i - num63;
											Wiring.SkipWire(num63, num62);
											Wiring.SkipWire(num63, num62 + 1);
											Wiring.SkipWire(num63, num62 + 2);
											Wiring.SkipWire(num63 + 1, num62);
											Wiring.SkipWire(num63 + 1, num62 + 1);
											Wiring.SkipWire(num63 + 1, num62 + 2);
											num2 = (short)(Main.tile[num63, num62].frameX != 0 ? -216 : 216);
											for (int c = 0; c < 2; c++)
											{
												for (int d = 0; d < 3; d++)
												{
													Tile tile20 = Main.tile[num63 + c, num62 + d];
													tile20.frameX = (short)(tile20.frameX + num2);
												}
											}
											if (Main.netMode == 2)
											{
												NetMessage.SendTileRange(-1, num63, num62, 2, 3);
											}
											Animation.NewTemporaryAnimation((num2 > 0 ? 0 : 1), 349, num63, num62);
										}
									}
									else
									{
										int num64 = tile.frameY / 18;
										Vector2 zero = Vector2.Zero;
										float single = 0f;
										float single1 = 0f;
										int num65 = 0;
										int num66 = 0;
										switch (num64)
										{
											case 0:
											{
												if (!Wiring.CheckMech(i, j, 200))
												{
													break;
												}
												int num67 = -1;
												if (tile.frameX != 0)
												{
													num67 = 1;
												}
												single = (float)(12 * num67);
												num66 = 20;
												num65 = 98;
												zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7))
												{
													X = zero.X + (float)(10 * num67),
													Y = zero.Y + 2f
												};
												break;
											}
											case 1:
											{
												if (!Wiring.CheckMech(i, j, 200))
												{
													break;
												}
												int num68 = -1;
												if (tile.frameX != 0)
												{
													num68 = 1;
												}
												single = (float)(12 * num68);
												num66 = 40;
												num65 = 184;
												zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7))
												{
													X = zero.X + (float)(10 * num68),
													Y = zero.Y + 2f
												};
												break;
											}
											case 2:
											{
												if (!Wiring.CheckMech(i, j, 200))
												{
													break;
												}
												int num69 = -1;
												if (tile.frameX != 0)
												{
													num69 = 1;
												}
												single = (float)(5 * num69);
												num66 = 40;
												num65 = 187;
												zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7))
												{
													X = zero.X + (float)(10 * num69),
													Y = zero.Y + 2f
												};
												break;
											}
											case 3:
											{
												if (!Wiring.CheckMech(i, j, 300))
												{
													break;
												}
												num65 = 185;
												int num70 = 200;
												for (int e = 0; e < 1000; e++)
												{
													if (Main.projectile[e].active && Main.projectile[e].type == num65)
													{
														Vector2 vector2 = new Vector2((float)(i * 16 + 8), (float)(j * 18 + 8)) - Main.projectile[e].Center;
														float single2 = vector2.Length();
														if (single2 < 50f)
														{
															num70 = num70 - 50;
														}
														else if (single2 < 100f)
														{
															num70 = num70 - 15;
														}
														else if (single2 < 200f)
														{
															num70 = num70 - 10;
														}
														else if (single2 < 300f)
														{
															num70 = num70 - 8;
														}
														else if (single2 < 400f)
														{
															num70 = num70 - 6;
														}
														else if (single2 < 500f)
														{
															num70 = num70 - 5;
														}
														else if (single2 < 700f)
														{
															num70 = num70 - 4;
														}
														else if (single2 >= 900f)
														{
															num70 = (single2 >= 1200f ? num70 - 1 : num70 - 2);
														}
														else
														{
															num70 = num70 - 3;
														}
													}
												}
												if (num70 <= 0)
												{
													break;
												}
												single = (float)Main.rand.Next(-20, 21) * 0.05f;
												single1 = 4f + (float)Main.rand.Next(0, 21) * 0.05f;
												num66 = 40;
												zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16))
												{
													Y = zero.Y + 6f
												};
												Projectile.NewProjectile((float)((int)zero.X), (float)((int)zero.Y), single, single1, num65, num66, 2f, Main.myPlayer, 0f, 0f);
												break;
											}
											case 4:
											{
												if (!Wiring.CheckMech(i, j, 90))
												{
													break;
												}
												single = 0f;
												single1 = 8f;
												num66 = 60;
												num65 = 186;
												zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16))
												{
													Y = zero.Y + 10f
												};
												break;
											}
										}
										if (num65 != 0)
										{
											Projectile.NewProjectile((float)((int)zero.X), (float)((int)zero.Y), single, single1, num65, num66, 2f, Main.myPlayer, 0f, 0f);
											return;
										}
									}
								}
								else if (Wiring.CheckMech(i, j, 5))
								{
									Minecart.FlipSwitchTrack(i, j);
									return;
								}
							}
							else
							{
								int num71 = i - tile.frameX / 18;
								if (tile.wall == WallID.LihzahrdBrickUnsafe && (double)j > Main.worldSurface && !NPC.downedPlantBoss)
								{
									return;
								}
								if (Wiring._teleport[0].X == -1f)
								{
									Wiring._teleport[0].X = (float)num71;
									Wiring._teleport[0].Y = (float)j;
									if (tile.halfBrick())
									{
										Wiring._teleport[0].Y = Wiring._teleport[0].Y + 0.5f;
										return;
									}
								}
								else if (Wiring._teleport[0].X != (float)num71 || Wiring._teleport[0].Y != (float)j)
								{
									Wiring._teleport[1].X = (float)num71;
									Wiring._teleport[1].Y = (float)j;
									if (tile.halfBrick())
									{
										Wiring._teleport[1].Y = Wiring._teleport[1].Y + 0.5f;
										return;
									}
								}
							}
						}
						else
						{
							int num72 = 1;
							if (Main.rand.Next(2) == 0)
							{
								num72 = -1;
							}
							if (WorldGen.OpenDoor(i, j, num72))
							{
								NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 0, (float)i, (float)j, (float)num72, 0, 0, 0);
								return;
							}
							if (WorldGen.OpenDoor(i, j, -num72))
							{
								NetMessage.SendData((int)PacketTypes.DoorUse, -1, -1, "", 0, (float)i, (float)j, (float)(-num72), 0, 0, 0);
								return;
							}
						}
					}
				}
				else
				{
					if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active())
					{
						if (Main.tile[i, j - 1].type == 21)
						{
							return;
						}
						if (Main.tile[i, j - 1].type == 88)
						{
							return;
						}
					}
					tile.type = 131;
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
					return;
				}
			}
		}

		public static void Initialize()
		{
			Wiring._wireSkip = new Dictionary<Point16, bool>();
			Wiring._wireList = new DoubleStack<Point16>(1024, 0);
			Wiring._toProcess = new Dictionary<Point16, byte>();
			Wiring._inPumpX = new int[20];
			Wiring._inPumpY = new int[20];
			Wiring._outPumpX = new int[20];
			Wiring._outPumpY = new int[20];
			Wiring._teleport = new Vector2[2];
			Wiring._mechX = new int[1000];
			Wiring._mechY = new int[1000];
			Wiring._mechTime = new int[1000];
		}

		public static void ReActive(int i, int j)
		{
			Main.tile[i, j].inActive(false);
			WorldGen.SquareTileFrame(i, j, false);
			if (Main.netMode != 1)
			{
				NetMessage.SendTileSquare(-1, i, j, 1);
			}
		}

		public static void SkipWire(int x, int y)
		{
			Wiring._wireSkip[new Point16(x, y)] = true;
		}

		public static void SkipWire(Point16 point)
		{
			Wiring._wireSkip[point] = true;
		}

		public static void Teleport()
		{
			if (Wiring._teleport[0].X < Wiring._teleport[1].X + 3f && Wiring._teleport[0].X > Wiring._teleport[1].X - 3f && Wiring._teleport[0].Y > Wiring._teleport[1].Y - 3f && Wiring._teleport[0].Y < Wiring._teleport[1].Y)
			{
				return;
			}
			Rectangle[] x = new Rectangle[2];
			x[0].X = (int)(Wiring._teleport[0].X * 16f);
			x[0].Width = 48;
			x[0].Height = 48;
			x[0].Y = (int)(Wiring._teleport[0].Y * 16f - (float)x[0].Height);
			x[1].X = (int)(Wiring._teleport[1].X * 16f);
			x[1].Width = 48;
			x[1].Height = 48;
			x[1].Y = (int)(Wiring._teleport[1].Y * 16f - (float)x[1].Height);
			for (int i = 0; i < 2; i++)
			{
				Vector2 vector2 = new Vector2((float)(x[1].X - x[0].X), (float)(x[1].Y - x[0].Y));
				if (i == 1)
				{
					vector2 = new Vector2((float)(x[0].X - x[1].X), (float)(x[0].Y - x[1].Y));
				}
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && !Main.player[j].dead && !Main.player[j].teleporting && x[i].Intersects(Main.player[j].getRect()))
					{
						Vector2 vector21 = Main.player[j].position + vector2;
						Main.player[j].teleporting = true;
						if (Main.netMode == 2)
						{
							RemoteClient.CheckSection(j, vector21, 1);
						}
						Main.player[j].Teleport(vector21, 0, 0);
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)PacketTypes.Teleport, -1, -1, "", 0, (float)j, vector21.X, vector21.Y, 0, 0, 0);
						}
					}
				}
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active && !Main.npc[k].teleporting && Main.npc[k].lifeMax > 5 && !Main.npc[k].boss && !Main.npc[k].noTileCollide && x[i].Intersects(Main.npc[k].getRect()))
					{
						Main.npc[k].teleporting = true;
						Main.npc[k].Teleport(Main.npc[k].position + vector2, 0, 0);
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

		private static void TripWire(int left, int top, int width, int height)
		{
			Point16 point16;
			if (Main.netMode == 1)
			{
				return;
			}
			Wiring.running = true;
			if (Wiring._wireList.Count != 0)
			{
				Wiring._wireList.Clear(true);
			}
			for (int i = left; i < left + width; i++)
			{
				for (int j = top; j < top + height; j++)
				{
					point16 = new Point16(i, j);
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.wire())
					{
						Wiring._wireList.PushBack(point16);
					}
				}
			}
			Vector2[] vector2Array = new Vector2[6];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 1);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			for (int k = left; k < left + width; k++)
			{
				for (int l = top; l < top + height; l++)
				{
					point16 = new Point16(k, l);
					Tile tile1 = Main.tile[k, l];
					if (tile1 != null && tile1.wire2())
					{
						Wiring._wireList.PushBack(point16);
					}
				}
			}
			vector2Array[0] = Wiring._teleport[0];
			vector2Array[1] = Wiring._teleport[1];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 2);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			vector2Array[2] = Wiring._teleport[0];
			vector2Array[3] = Wiring._teleport[1];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			for (int m = left; m < left + width; m++)
			{
				for (int n = top; n < top + height; n++)
				{
					point16 = new Point16(m, n);
					Tile tile2 = Main.tile[m, n];
					if (tile2 != null && tile2.wire3())
					{
						Wiring._wireList.PushBack(point16);
					}
				}
			}
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 3);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			vector2Array[4] = Wiring._teleport[0];
			vector2Array[5] = Wiring._teleport[1];
			for (int o = 0; o < 5; o = o + 2)
			{
				Wiring._teleport[0] = vector2Array[o];
				Wiring._teleport[1] = vector2Array[o + 1];
				if (Wiring._teleport[0].X >= 0f && Wiring._teleport[1].X >= 0f)
				{
					Wiring.Teleport();
				}
			}
		}

		public static void UpdateMech()
		{
			for (int i = Wiring._numMechs - 1; i >= 0; i--)
			{
				Wiring._mechTime[i] = Wiring._mechTime[i] - 1;
				if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].active() && Main.tile[Wiring._mechX[i], Wiring._mechY[i]].type == 144)
				{
					if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].frameY != 0)
					{
						int num = Main.tile[Wiring._mechX[i], Wiring._mechY[i]].frameX / 18;
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
						if (Math.IEEERemainder((double)Wiring._mechTime[i], (double)num) == 0)
						{
							Wiring._mechTime[i] = 18000;
							Wiring.TripWire(Wiring._mechX[i], Wiring._mechY[i], 1, 1);
						}
					}
					else
					{
						Wiring._mechTime[i] = 0;
					}
				}
				if (Wiring._mechTime[i] <= 0)
				{
					if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].active() && Main.tile[Wiring._mechX[i], Wiring._mechY[i]].type == 144)
					{
						Main.tile[Wiring._mechX[i], Wiring._mechY[i]].frameY = 0;
						NetMessage.SendTileSquare(-1, Wiring._mechX[i], Wiring._mechY[i], 1);
					}
					if (Main.tile[Wiring._mechX[i], Wiring._mechY[i]].active() && Main.tile[Wiring._mechX[i], Wiring._mechY[i]].type == 411)
					{
						Tile tile = Main.tile[Wiring._mechX[i], Wiring._mechY[i]];
						int num1 = tile.frameX % 36 / 18;
						int num2 = tile.frameY % 36 / 18;
						int num3 = Wiring._mechX[i] - num1;
						int num4 = Wiring._mechY[i] - num2;
						int num5 = 36;
						if (Main.tile[num3, num4].frameX >= 36)
						{
							num5 = -36;
						}
						for (int j = num3; j < num3 + 2; j++)
						{
							for (int k = num4; k < num4 + 2; k++)
							{
								Main.tile[j, k].frameX = (short)(Main.tile[j, k].frameX + num5);
							}
						}
						NetMessage.SendTileSquare(-1, num3, num4, 2);
					}
					for (int l = i; l < Wiring._numMechs; l++)
					{
						Wiring._mechX[l] = Wiring._mechX[l + 1];
						Wiring._mechY[l] = Wiring._mechY[l + 1];
						Wiring._mechTime[l] = Wiring._mechTime[l + 1];
					}
					Wiring._numMechs = Wiring._numMechs - 1;
				}
			}
		}

		private static void XferWater()
		{
			for (int i = 0; i < Wiring._numInPump; i++)
			{
				int num = Wiring._inPumpX[i];
				int num1 = Wiring._inPumpY[i];
				int num2 = Main.tile[num, num1].liquid;
				if (num2 > 0)
				{
					bool flag = Main.tile[num, num1].lava();
					bool flag1 = Main.tile[num, num1].honey();
					for (int j = 0; j < Wiring._numOutPump; j++)
					{
						int num3 = Wiring._outPumpX[j];
						int num4 = Wiring._outPumpY[j];
						int num5 = Main.tile[num3, num4].liquid;
						if (num5 < 255)
						{
							bool flag2 = Main.tile[num3, num4].lava();
							bool flag3 = Main.tile[num3, num4].honey();
							if (num5 == 0)
							{
								flag2 = flag;
								flag3 = flag1;
							}
							if (flag == flag2 && flag1 == flag3)
							{
								int num6 = num2;
								if (num6 + num5 > 255)
								{
									num6 = 255 - num5;
								}
								Tile tile = Main.tile[num3, num4];
								tile.liquid = (byte)(tile.liquid + (byte)num6);
								Tile tile1 = Main.tile[num, num1];
								tile1.liquid = (byte)(tile1.liquid - (byte)num6);
								num2 = Main.tile[num, num1].liquid;
								Main.tile[num3, num4].lava(flag);
								Main.tile[num3, num4].honey(flag1);
								WorldGen.SquareTileFrame(num3, num4, true);
								if (Main.tile[num, num1].liquid == 0)
								{
									Main.tile[num, num1].lava(false);
									WorldGen.SquareTileFrame(num, num1, true);
									break;
								}
							}
						}
					}
					WorldGen.SquareTileFrame(num, num1, true);
				}
			}
		}
	}
}
