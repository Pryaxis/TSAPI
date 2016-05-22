
using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.ID;
using System.Threading;
using Terraria.GameContent.UI;

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

		#region 1.3.1
		private static int CurrentUser = 254;

		public static bool blockPlayerTeleportationForOneIteration;

		private static DoubleStack<byte> _wireDirectionList;

		private static Dictionary<Point16, byte> _PixelBoxTriggers;

		private static Queue<Point16> _GatesNext;

		private static Dictionary<Point16, bool> _GatesDone;

		private static Queue<Point16> _GatesCurrent;

		private static int _currentWireColor;

		private static Queue<Point16> _LampsToCheck;
		#endregion

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
			Interlocked.Increment(ref _numMechs);
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
							if (Main.tile[i, j - 1].active() && (Main.tile[i, j - 1].type == 5 || Main.tile[i, j - 1].type == 21 || Main.tile[i, j - 1].type == 26 || Main.tile[i, j - 1].type == 77 || Main.tile[i, j - 1].type == 72 || Main.tile[i, j - 1].type == 88))
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
			if (Main.tile[i, j].type == 135 || Main.tile[i, j].type == 314 || Main.tile[i, j].type == 423 || Main.tile[i, j].type == 428 || Main.tile[i, j].type == 442)
			{
				Wiring.TripWire(i, j, 1, 1);
				return;
			}
			if (Main.tile[i, j].type == 440)
			{
				Wiring.TripWire(i, j, 3, 3);
				return;
			}
			if (Main.tile[i, j].type == 136)
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
			if (Main.tile[i, j].type == 144)
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
			if (Main.tile[i, j].type == 441)
			{
				int num = (int)(Main.tile[i, j].frameX / 18 * -1);
				int num2 = (int)(Main.tile[i, j].frameY / 18 * -1);
				num %= 4;
				if (num < -1)
				{
					num += 2;
				}
				num += i;
				num2 += j;
				Wiring.TripWire(num, num2, 2, 2);
				return;
			}
			if (Main.tile[i, j].type == 132 || Main.tile[i, j].type == 411)
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
				if (Main.netMode != 1 && Main.tile[num1, num2].type == 411)
				{
					Wiring.CheckMech(num1, num2, 60);
				}
				for (int i1 = num1; i1 < num1 + 2; i1++)
				{
					for (int j1 = num2; j1 < num2 + 2; j1++)
					{
						if (Main.tile[i1, j1].type == 132 || Main.tile[i1, j1].type == 411)
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
			Wiring._wireDirectionList.Clear(true);
			for (int i = 0; i < next.Count; i++)
			{
				Point16 point = next.PopFront();
				Wiring.SkipWire(point);
				Wiring._toProcess.Add(point, 4);
				next.PushBack(point);
				Wiring._wireDirectionList.PushBack(0);
			}
			Wiring._currentWireColor = wireType;
			while (next.Count > 0)
			{
				Point16 point2 = next.PopFront();
				int num = (int)Wiring._wireDirectionList.PopFront();
				int x = (int)point2.X;
				int y = (int)point2.Y;
				if (!Wiring._wireSkip.ContainsKey(point2))
				{
					Wiring.HitWireSingle(x, y);
				}
				for (int j = 0; j < 4; j++)
				{
				for_start:
					int num2;
					int num3;
					switch (j)
					{
						case 0:
							num2 = x;
							num3 = y + 1;
							break;
						case 1:
							num2 = x;
							num3 = y - 1;
							break;
						case 2:
							num2 = x + 1;
							num3 = y;
							break;
						case 3:
							num2 = x - 1;
							num3 = y;
							break;
						default:
							num2 = x;
							num3 = y + 1;
							break;
					}
					if (num2 >= 2 && num2 < Main.maxTilesX - 2 && num3 >= 2 && num3 < Main.maxTilesY - 2)
					{
						Tile tile = Main.tile[num2, num3];
						if (tile != null)
						{
							Tile tile2 = Main.tile[x, y];
							if (tile2 != null)
							{
								byte b = 3;
								if (tile.type == 424 || tile.type == 445)
								{
									b = 0;
								}
								if (tile2.type == 424)
								{
									switch (tile2.frameX / 18)
									{
										case 0:
											if (j != num)
											{
												goto for_start;
											}
											break;
										case 1:
											if ((num != 0 || j != 3) && (num != 3 || j != 0) && (num != 1 || j != 2))
											{
												if (num != 2)
												{
													goto for_start;
												}
												if (j != 1)
												{
													goto for_start;
												}
											}
											break;
										case 2:
											if ((num != 0 || j != 2) && (num != 2 || j != 0) && (num != 1 || j != 3) && (num != 3 || j != 1))
											{
												goto for_start;
											}
											break;
									}
								}
								if (tile2.type == 445)
								{
									if (j != num)
									{
										continue;
									}
									if (Wiring._PixelBoxTriggers.ContainsKey(point2))
									{
										Dictionary<Point16, byte> pixelBoxTriggers;
										Point16 key;
										(pixelBoxTriggers = Wiring._PixelBoxTriggers)[key = point2] = (byte)(pixelBoxTriggers[key] | ((j == 0 | j == 1) ? 2 : 1));
									}
									else
									{
										Wiring._PixelBoxTriggers[point2] = (byte)((j == 0 | j == 1) ? 2 : 1);
									}
								}
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
									case 4:
										flag = tile.wire4();
										break;
									default:
										flag = false;
										break;
								}
								if (flag)
								{
									Point16 point3 = new Point16(num2, num3);
									byte b2;
									if (Wiring._toProcess.TryGetValue(point3, out b2))
									{
										b2 -= 1;
										if (b2 == 0)
										{
											Wiring._toProcess.Remove(point3);
										}
										else
										{
											Wiring._toProcess[point3] = b2;
										}
									}
									else
									{
										next.PushBack(point3);
										Wiring._wireDirectionList.PushBack((byte)j);
										if (b > 0)
										{
											Wiring._toProcess.Add(point3, b);
										}
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
			Tile tile = Main.tile[i, j];
			int type = (int)tile.type;
			if (tile.actuator())
			{
				Wiring.ActuateForced(i, j);
			}
			if (tile.active())
			{
				if (type == 144)
				{
					Wiring.HitSwitch(i, j);
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				else if (type == 421)
				{
					if (!tile.actuator())
					{
						tile.type = 422;
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
				}
				else if (type == 422 && !tile.actuator())
				{
					tile.type = 421;
					WorldGen.SquareTileFrame(i, j, true);
					NetMessage.SendTileSquare(-1, i, j, 1);
				}
				if (type >= 255 && type <= 268)
				{
					if (!tile.actuator())
					{
						if (type >= 262)
						{
							Tile expr_CE = tile;
							expr_CE.type -= 7;
						}
						else
						{
							Tile expr_DF = tile;
							expr_DF.type += 7;
						}
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1);
						return;
					}
				}
				else
				{
					if (type == 419)
					{
						int num = 18;
						if ((int)tile.frameX >= num)
						{
							num = -num;
						}
						if (tile.frameX == 36)
						{
							num = 0;
						}
						Wiring.SkipWire(i, j);
						tile.frameX = (short)((int)tile.frameX + num);
						WorldGen.SquareTileFrame(i, j, true);
						NetMessage.SendTileSquare(-1, i, j, 1);
						Wiring._LampsToCheck.Enqueue(new Point16(i, j));
						return;
					}
					if (type == 406)
					{
						int num2 = (int)(tile.frameX % 54 / 18);
						int num3 = (int)(tile.frameY % 54 / 18);
						int num4 = i - num2;
						int num5 = j - num3;
						int num6 = 54;
						if (Main.tile[num4, num5].frameY >= 108)
						{
							num6 = -108;
						}
						for (int k = num4; k < num4 + 3; k++)
						{
							for (int l = num5; l < num5 + 3; l++)
							{
								Wiring.SkipWire(k, l);
								Main.tile[k, l].frameY = (short)((int)Main.tile[k, l].frameY + num6);
							}
						}
						NetMessage.SendTileSquare(-1, num4 + 1, num5 + 1, 3);
						return;
					}
					if (type == 411)
					{
						int num7 = (int)(tile.frameX % 36 / 18);
						int num8 = (int)(tile.frameY % 36 / 18);
						int num9 = i - num7;
						int num10 = j - num8;
						int num11 = 36;
						if (Main.tile[num9, num10].frameX >= 36)
						{
							num11 = -36;
						}
						for (int m = num9; m < num9 + 2; m++)
						{
							for (int n = num10; n < num10 + 2; n++)
							{
								Wiring.SkipWire(m, n);
								Main.tile[m, n].frameX = (short)((int)Main.tile[m, n].frameX + num11);
							}
						}
						NetMessage.SendTileSquare(-1, num9, num10, 2);
						return;
					}
					if (type == 425)
					{
						int num12 = (int)(tile.frameX % 36 / 18);
						int num13 = (int)(tile.frameY % 36 / 18);
						int num14 = i - num12;
						int num15 = j - num13;
						for (int num16 = num14; num16 < num14 + 2; num16++)
						{
							for (int num17 = num15; num17 < num15 + 2; num17++)
							{
								Wiring.SkipWire(num16, num17);
							}
						}
						if (!Main.AnnouncementBoxDisabled)
						{
							Color pink = Color.Pink;
							int num18 = Sign.ReadSign(num14, num15, false);
							if (num18 != -1 && Main.sign[num18] != null && !string.IsNullOrWhiteSpace(Main.sign[num18].text))
							{
								if (Main.AnnouncementBoxRange == -1)
								{
									if (Main.netMode == 0)
									{
										Main.NewTextMultiline(Main.sign[num18].text, false, pink);
										return;
									}
									if (Main.netMode == 2)
									{
										NetMessage.SendData(107, -1, -1, Main.sign[num18].text, (int)pink.R, (float)pink.G, (float)pink.B, 0f, 0, 0, 0);
										return;
									}
								}
								else if (Main.netMode == 0)
								{
									if (Main.player[Main.myPlayer].Distance(new Vector2((float)(num14 * 16 + 16), (float)(num15 * 16 + 16))) <= (float)Main.AnnouncementBoxRange)
									{
										Main.NewTextMultiline(Main.sign[num18].text, false, pink);
										return;
									}
								}
								else if (Main.netMode == 2)
								{
									for (int num19 = 0; num19 < 255; num19++)
									{
										if (Main.player[num19].active && Main.player[num19].Distance(new Vector2((float)(num14 * 16 + 16), (float)(num15 * 16 + 16))) <= (float)Main.AnnouncementBoxRange)
										{
											NetMessage.SendData(107, num19, -1, Main.sign[num18].text, 255, 255f, 192f, 203f, 0, 0, 0);
										}
									}
									return;
								}
							}
						}
					}
					else
					{
						if (type == 405)
						{
							int num20 = (int)(tile.frameX % 54 / 18);
							int num21 = (int)(tile.frameY % 36 / 18);
							int num22 = i - num20;
							int num23 = j - num21;
							int num24 = 54;
							if (Main.tile[num22, num23].frameX >= 54)
							{
								num24 = -54;
							}
							for (int num25 = num22; num25 < num22 + 3; num25++)
							{
								for (int num26 = num23; num26 < num23 + 2; num26++)
								{
									Wiring.SkipWire(num25, num26);
									Main.tile[num25, num26].frameX = (short)((int)Main.tile[num25, num26].frameX + num24);
								}
							}
							NetMessage.SendTileSquare(-1, num22 + 1, num23 + 1, 3);
							return;
						}
						if (type == 209)
						{
							int num27 = (int)(tile.frameX % 72 / 18);
							int num28 = (int)(tile.frameY % 54 / 18);
							int num29 = i - num27;
							int num30 = j - num28;
							int num31 = (int)(tile.frameY / 54);
							int num32 = (int)(tile.frameX / 72);
							int num33 = -1;
							if (num27 == 1 || num27 == 2)
							{
								num33 = num28;
							}
							int num34 = 0;
							if (num27 == 3)
							{
								num34 = -54;
							}
							if (num27 == 0)
							{
								num34 = 54;
							}
							if (num31 >= 8 && num34 > 0)
							{
								num34 = 0;
							}
							if (num31 == 0 && num34 < 0)
							{
								num34 = 0;
							}
							bool flag = false;
							if (num34 != 0)
							{
								for (int num35 = num29; num35 < num29 + 4; num35++)
								{
									for (int num36 = num30; num36 < num30 + 3; num36++)
									{
										Wiring.SkipWire(num35, num36);
										Main.tile[num35, num36].frameY = (short)((int)Main.tile[num35, num36].frameY + num34);
									}
								}
								flag = true;
							}
							if ((num32 == 3 || num32 == 4) && (num33 == 0 || num33 == 1))
							{
								num34 = ((num32 == 3) ? 72 : -72);
								for (int num37 = num29; num37 < num29 + 4; num37++)
								{
									for (int num38 = num30; num38 < num30 + 3; num38++)
									{
										Wiring.SkipWire(num37, num38);
										Main.tile[num37, num38].frameX = (short)((int)Main.tile[num37, num38].frameX + num34);
									}
								}
								flag = true;
							}
							if (flag)
							{
								NetMessage.SendTileSquare(-1, num29 + 1, num30 + 1, 4);
							}
							if (num33 != -1)
							{
								bool flag2 = true;
								if ((num32 == 3 || num32 == 4) && num33 < 2)
								{
									flag2 = false;
								}
								if (Wiring.CheckMech(num29, num30, 30) && flag2)
								{
									WorldGen.ShootFromCannon(num29, num30, num31, num32 + 1, 0, 0f, Wiring.CurrentUser);
									return;
								}
							}
						}
						else if (type == 212)
						{
							int num39 = (int)(tile.frameX % 54 / 18);
							int num40 = (int)(tile.frameY % 54 / 18);
							int num41 = i - num39;
							int num42 = j - num40;
							int num43 = (int)(tile.frameX / 54);
							int num44 = -1;
							if (num39 == 1)
							{
								num44 = num40;
							}
							int num45 = 0;
							if (num39 == 0)
							{
								num45 = -54;
							}
							if (num39 == 2)
							{
								num45 = 54;
							}
							if (num43 >= 1 && num45 > 0)
							{
								num45 = 0;
							}
							if (num43 == 0 && num45 < 0)
							{
								num45 = 0;
							}
							bool flag3 = false;
							if (num45 != 0)
							{
								for (int num46 = num41; num46 < num41 + 3; num46++)
								{
									for (int num47 = num42; num47 < num42 + 3; num47++)
									{
										Wiring.SkipWire(num46, num47);
										Main.tile[num46, num47].frameX = (short)((int)Main.tile[num46, num47].frameX + num45);
									}
								}
								flag3 = true;
							}
							if (flag3)
							{
								NetMessage.SendTileSquare(-1, num41 + 1, num42 + 1, 4);
							}
							if (num44 != -1 && Wiring.CheckMech(num41, num42, 10))
							{
								float num48 = 12f + (float)Main.rand.Next(450) * 0.01f;
								float num49 = (float)Main.rand.Next(85, 105);
								float num50 = (float)Main.rand.Next(-35, 11);
								int type2 = 166;
								int damage = 0;
								float knockBack = 0f;
								Vector2 vector = new Vector2((float)((num41 + 2) * 16 - 8), (float)((num42 + 2) * 16 - 8));
								if (tile.frameX / 54 == 0)
								{
									num49 *= -1f;
									vector.X -= 12f;
								}
								else
								{
									vector.X += 12f;
								}
								float num51 = num49;
								float num52 = num50;
								float num53 = (float)Math.Sqrt((double)(num51 * num51 + num52 * num52));
								num53 = num48 / num53;
								num51 *= num53;
								num52 *= num53;
								Projectile.NewProjectile(vector.X, vector.Y, num51, num52, type2, damage, knockBack, Wiring.CurrentUser, 0f, 0f);
								return;
							}
						}
						else
						{
							if (type == 215)
							{
								int num54 = (int)(tile.frameX % 54 / 18);
								int num55 = (int)(tile.frameY % 36 / 18);
								int num56 = i - num54;
								int num57 = j - num55;
								int num58 = 36;
								if (Main.tile[num56, num57].frameY >= 36)
								{
									num58 = -36;
								}
								for (int num59 = num56; num59 < num56 + 3; num59++)
								{
									for (int num60 = num57; num60 < num57 + 2; num60++)
									{
										Wiring.SkipWire(num59, num60);
										Main.tile[num59, num60].frameY = (short)((int)Main.tile[num59, num60].frameY + num58);
									}
								}
								NetMessage.SendTileSquare(-1, num56 + 1, num57 + 1, 3);
								return;
							}
							if (type == 130)
							{
								if (Main.tile[i, j - 1] != null && Main.tile[i, j - 1].active())
								{
									if (Main.tile[i, j - 1].type == 21 || Main.tile[i, j - 1].type == 441)
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
							if (type == 131)
							{
								tile.type = 130;
								WorldGen.SquareTileFrame(i, j, true);
								NetMessage.SendTileSquare(-1, i, j, 1);
								return;
							}
							if (type == 387 || type == 386)
							{
								bool value = type == 387;
								int num61 = WorldGen.ShiftTrapdoor(i, j, true, -1).ToInt();
								if (num61 == 0)
								{
									num61 = -WorldGen.ShiftTrapdoor(i, j, false, -1).ToInt();
								}
								if (num61 != 0)
								{
									NetMessage.SendData(19, -1, -1, "", 3 - value.ToInt(), (float)i, (float)j, (float)num61, 0, 0, 0);
									return;
								}
							}
							else
							{
								if (type == 389 || type == 388)
								{
									bool flag4 = type == 389;
									WorldGen.ShiftTallGate(i, j, flag4);
									NetMessage.SendData(19, -1, -1, "", 4 + flag4.ToInt(), (float)i, (float)j, 0f, 0, 0, 0);
									return;
								}
								if (type == 11)
								{
									if (WorldGen.CloseDoor(i, j, true))
									{
										NetMessage.SendData(19, -1, -1, "", 1, (float)i, (float)j, 0f, 0, 0, 0);
										return;
									}
								}
								else if (type == 10)
								{
									int num62 = 1;
									if (Main.rand.Next(2) == 0)
									{
										num62 = -1;
									}
									if (WorldGen.OpenDoor(i, j, num62))
									{
										NetMessage.SendData(19, -1, -1, "", 0, (float)i, (float)j, (float)num62, 0, 0, 0);
										return;
									}
									if (WorldGen.OpenDoor(i, j, -num62))
									{
										NetMessage.SendData(19, -1, -1, "", 0, (float)i, (float)j, (float)(-(float)num62), 0, 0, 0);
										return;
									}
								}
								else
								{
									if (type == 216)
									{
										WorldGen.LaunchRocket(i, j);
										Wiring.SkipWire(i, j);
										return;
									}
									if (type == 335)
									{
										int num63 = j - (int)(tile.frameY / 18);
										int num64 = i - (int)(tile.frameX / 18);
										Wiring.SkipWire(num64, num63);
										Wiring.SkipWire(num64, num63 + 1);
										Wiring.SkipWire(num64 + 1, num63);
										Wiring.SkipWire(num64 + 1, num63 + 1);
										if (Wiring.CheckMech(num64, num63, 30))
										{
											WorldGen.LaunchRocketSmall(num64, num63);
											return;
										}
									}
									else if (type == 338)
									{
										int num65 = j - (int)(tile.frameY / 18);
										int num66 = i - (int)(tile.frameX / 18);
										Wiring.SkipWire(num66, num65);
										Wiring.SkipWire(num66, num65 + 1);
										if (Wiring.CheckMech(num66, num65, 30))
										{
											bool flag5 = false;
											for (int num67 = 0; num67 < 1000; num67++)
											{
												if (Main.projectile[num67].active && Main.projectile[num67].aiStyle == 73 && Main.projectile[num67].ai[0] == (float)num66 && Main.projectile[num67].ai[1] == (float)num65)
												{
													flag5 = true;
													break;
												}
											}
											if (!flag5)
											{
												Projectile.NewProjectile((float)(num66 * 16 + 8), (float)(num65 * 16 + 2), 0f, 0f, 419 + Main.rand.Next(4), 0, 0f, Main.myPlayer, (float)num66, (float)num65);
												return;
											}
										}
									}
									else if (type == 235)
									{
										int num68 = i - (int)(tile.frameX / 18);
										if (tile.wall == 87 && (double)j > Main.worldSurface && !NPC.downedPlantBoss)
										{
											return;
										}
										if (Wiring._teleport[0].X == -1f)
										{
											Wiring._teleport[0].X = (float)num68;
											Wiring._teleport[0].Y = (float)j;
											if (tile.halfBrick())
											{
												Vector2[] expr_E14_cp_0 = Wiring._teleport;
												int expr_E14_cp_1 = 0;
												expr_E14_cp_0[expr_E14_cp_1].Y = expr_E14_cp_0[expr_E14_cp_1].Y + 0.5f;
												return;
											}
										}
										else if (Wiring._teleport[0].X != (float)num68 || Wiring._teleport[0].Y != (float)j)
										{
											Wiring._teleport[1].X = (float)num68;
											Wiring._teleport[1].Y = (float)j;
											if (tile.halfBrick())
											{
												Vector2[] expr_E8D_cp_0 = Wiring._teleport;
												int expr_E8D_cp_1 = 1;
												expr_E8D_cp_0[expr_E8D_cp_1].Y = expr_E8D_cp_0[expr_E8D_cp_1].Y + 0.5f;
												return;
											}
										}
									}
									else
									{
										if (type == 4)
										{
											if (tile.frameX < 66)
											{
												Tile expr_EAE = tile;
												expr_EAE.frameX += 66;
											}
											else
											{
												Tile expr_EC0 = tile;
												expr_EC0.frameX -= 66;
											}
											NetMessage.SendTileSquare(-1, i, j, 1);
											return;
										}
										if (type == 429)
										{
											int num69 = (int)(Main.tile[i, j].frameX / 18);
											bool flag6 = num69 % 2 >= 1;
											bool flag7 = num69 % 4 >= 2;
											bool flag8 = num69 % 8 >= 4;
											bool flag9 = num69 % 16 >= 8;
											bool flag10 = false;
											short num70 = 0;
											switch (Wiring._currentWireColor)
											{
											case 1:
												num70 = 18;
												flag10 = !flag6;
												break;
											case 2:
												num70 = 72;
												flag10 = !flag8;
												break;
											case 3:
												num70 = 36;
												flag10 = !flag7;
												break;
											case 4:
												num70 = 144;
												flag10 = !flag9;
												break;
											}
											if (flag10)
											{
												Tile expr_F8D = tile;
												expr_F8D.frameX += num70;
											}
											else
											{
												Tile expr_F9F = tile;
												expr_F9F.frameX -= num70;
											}
											NetMessage.SendTileSquare(-1, i, j, 1);
											return;
										}
										if (type == 149)
										{
											if (tile.frameX < 54)
											{
												Tile expr_FCB = tile;
												expr_FCB.frameX += 54;
											}
											else
											{
												Tile expr_FDD = tile;
												expr_FDD.frameX -= 54;
											}
											NetMessage.SendTileSquare(-1, i, j, 1);
											return;
										}
										if (type == 244)
										{
											int num71;
											for (num71 = (int)(tile.frameX / 18); num71 >= 3; num71 -= 3)
											{
											}
											int num72;
											for (num72 = (int)(tile.frameY / 18); num72 >= 3; num72 -= 3)
											{
											}
											int num73 = i - num71;
											int num74 = j - num72;
											int num75 = 54;
											if (Main.tile[num73, num74].frameX >= 54)
											{
												num75 = -54;
											}
											for (int num76 = num73; num76 < num73 + 3; num76++)
											{
												for (int num77 = num74; num77 < num74 + 2; num77++)
												{
													Wiring.SkipWire(num76, num77);
													Main.tile[num76, num77].frameX = (short)((int)Main.tile[num76, num77].frameX + num75);
												}
											}
											NetMessage.SendTileSquare(-1, num73 + 1, num74 + 1, 3);
											return;
										}
										if (type == 42)
										{
											int num78;
											for (num78 = (int)(tile.frameY / 18); num78 >= 2; num78 -= 2)
											{
											}
											int num79 = j - num78;
											short num80 = 18;
											if (tile.frameX > 0)
											{
												num80 = -18;
											}
											Tile expr_110B = Main.tile[i, num79];
											expr_110B.frameX += num80;
											Tile expr_1129 = Main.tile[i, num79 + 1];
											expr_1129.frameX += num80;
											Wiring.SkipWire(i, num79);
											Wiring.SkipWire(i, num79 + 1);
											NetMessage.SendTileSquare(-1, i, j, 2);
											return;
										}
										if (type == 93)
										{
											int num81;
											for (num81 = (int)(tile.frameY / 18); num81 >= 3; num81 -= 3)
											{
											}
											num81 = j - num81;
											short num82 = 18;
											if (tile.frameX > 0)
											{
												num82 = -18;
											}
											Tile expr_1198 = Main.tile[i, num81];
											expr_1198.frameX += num82;
											Tile expr_11B6 = Main.tile[i, num81 + 1];
											expr_11B6.frameX += num82;
											Tile expr_11D4 = Main.tile[i, num81 + 2];
											expr_11D4.frameX += num82;
											Wiring.SkipWire(i, num81);
											Wiring.SkipWire(i, num81 + 1);
											Wiring.SkipWire(i, num81 + 2);
											NetMessage.SendTileSquare(-1, i, num81 + 1, 3);
											return;
										}
										if (type == 126 || type == 95 || type == 100 || type == 173)
										{
											int num83;
											for (num83 = (int)(tile.frameY / 18); num83 >= 2; num83 -= 2)
											{
											}
											num83 = j - num83;
											int num84 = (int)(tile.frameX / 18);
											if (num84 > 1)
											{
												num84 -= 2;
											}
											num84 = i - num84;
											short num85 = 36;
											if (Main.tile[num84, num83].frameX > 0)
											{
												num85 = -36;
											}
											Tile expr_128C = Main.tile[num84, num83];
											expr_128C.frameX += num85;
											Tile expr_12AB = Main.tile[num84, num83 + 1];
											expr_12AB.frameX += num85;
											Tile expr_12CA = Main.tile[num84 + 1, num83];
											expr_12CA.frameX += num85;
											Tile expr_12EB = Main.tile[num84 + 1, num83 + 1];
											expr_12EB.frameX += num85;
											Wiring.SkipWire(num84, num83);
											Wiring.SkipWire(num84 + 1, num83);
											Wiring.SkipWire(num84, num83 + 1);
											Wiring.SkipWire(num84 + 1, num83 + 1);
											NetMessage.SendTileSquare(-1, num84, num83, 3);
											return;
										}
										if (type == 34)
										{
											int num86;
											for (num86 = (int)(tile.frameY / 18); num86 >= 3; num86 -= 3)
											{
											}
											int num87 = j - num86;
											int num88 = (int)(tile.frameX / 18);
											if (num88 > 2)
											{
												num88 -= 3;
											}
											num88 = i - num88;
											short num89 = 54;
											if (Main.tile[num88, num87].frameX > 0)
											{
												num89 = -54;
											}
											for (int num90 = num88; num90 < num88 + 3; num90++)
											{
												for (int num91 = num87; num91 < num87 + 3; num91++)
												{
													Tile expr_13AC = Main.tile[num90, num91];
													expr_13AC.frameX += num89;
													Wiring.SkipWire(num90, num91);
												}
											}
											NetMessage.SendTileSquare(-1, num88 + 1, num87 + 1, 3);
											return;
										}
										if (type == 314)
										{
											if (Wiring.CheckMech(i, j, 5))
											{
												Minecart.FlipSwitchTrack(i, j);
												return;
											}
										}
										else
										{
											if (type == 33 || type == 174)
											{
												short num92 = 18;
												if (tile.frameX > 0)
												{
													num92 = -18;
												}
												Tile expr_142C = tile;
												expr_142C.frameX += num92;
												NetMessage.SendTileSquare(-1, i, j, 3);
												return;
											}
											if (type == 92)
											{
												int num93 = j - (int)(tile.frameY / 18);
												short num94 = 18;
												if (tile.frameX > 0)
												{
													num94 = -18;
												}
												for (int num95 = num93; num95 < num93 + 6; num95++)
												{
													Tile expr_147B = Main.tile[i, num95];
													expr_147B.frameX += num94;
													Wiring.SkipWire(i, num95);
												}
												NetMessage.SendTileSquare(-1, i, num93 + 3, 7);
												return;
											}
											if (type == 137)
											{
												int num96 = (int)(tile.frameY / 18);
												Vector2 zero = Vector2.Zero;
												float speedX = 0f;
												float speedY = 0f;
												int num97 = 0;
												int damage2 = 0;
												switch (num96)
												{
												case 0:
												case 1:
												case 2:
													if (Wiring.CheckMech(i, j, 200))
													{
														int num98 = (tile.frameX == 0) ? -1 : ((tile.frameX == 18) ? 1 : 0);
														int num99 = (tile.frameX < 36) ? 0 : ((tile.frameX < 72) ? -1 : 1);
														zero = new Vector2((float)(i * 16 + 8 + 10 * num98), (float)(j * 16 + 9 + num99 * 9));
														float num100 = 3f;
														if (num96 == 0)
														{
															num97 = 98;
															damage2 = 20;
															num100 = 12f;
														}
														if (num96 == 1)
														{
															num97 = 184;
															damage2 = 40;
															num100 = 12f;
														}
														if (num96 == 2)
														{
															num97 = 187;
															damage2 = 40;
															num100 = 5f;
														}
														speedX = (float)num98 * num100;
														speedY = (float)num99 * num100;
													}
													break;
												case 3:
													if (Wiring.CheckMech(i, j, 300))
													{
														int num101 = 200;
														for (int num102 = 0; num102 < 1000; num102++)
														{
															if (Main.projectile[num102].active && Main.projectile[num102].type == num97)
															{
																float num103 = (new Vector2((float)(i * 16 + 8), (float)(j * 18 + 8)) - Main.projectile[num102].Center).Length();
																if (num103 < 50f)
																{
																	num101 -= 50;
																}
																else if (num103 < 100f)
																{
																	num101 -= 15;
																}
																else if (num103 < 200f)
																{
																	num101 -= 10;
																}
																else if (num103 < 300f)
																{
																	num101 -= 8;
																}
																else if (num103 < 400f)
																{
																	num101 -= 6;
																}
																else if (num103 < 500f)
																{
																	num101 -= 5;
																}
																else if (num103 < 700f)
																{
																	num101 -= 4;
																}
																else if (num103 < 900f)
																{
																	num101 -= 3;
																}
																else if (num103 < 1200f)
																{
																	num101 -= 2;
																}
																else
																{
																	num101--;
																}
															}
														}
														if (num101 > 0)
														{
															num97 = 185;
															damage2 = 40;
															int num104 = 0;
															int num105 = 0;
															switch (tile.frameX / 18)
															{
															case 0:
															case 1:
																num104 = 0;
																num105 = 1;
																break;
															case 2:
																num104 = 0;
																num105 = -1;
																break;
															case 3:
																num104 = -1;
																num105 = 0;
																break;
															case 4:
																num104 = 1;
																num105 = 0;
																break;
															}
															speedX = (float)(4 * num104) + (float)Main.rand.Next(-20 + ((num104 == 1) ? 20 : 0), 21 - ((num104 == -1) ? 20 : 0)) * 0.05f;
															speedY = (float)(4 * num105) + (float)Main.rand.Next(-20 + ((num105 == 1) ? 20 : 0), 21 - ((num105 == -1) ? 20 : 0)) * 0.05f;
															zero = new Vector2((float)(i * 16 + 8 + 14 * num104), (float)(j * 16 + 8 + 14 * num105));
														}
													}
													break;
												case 4:
													if (Wiring.CheckMech(i, j, 90))
													{
														int num106 = 0;
														int num107 = 0;
														switch (tile.frameX / 18)
														{
														case 0:
														case 1:
															num106 = 0;
															num107 = 1;
															break;
														case 2:
															num106 = 0;
															num107 = -1;
															break;
														case 3:
															num106 = -1;
															num107 = 0;
															break;
														case 4:
															num106 = 1;
															num107 = 0;
															break;
														}
														speedX = (float)(8 * num106);
														speedY = (float)(8 * num107);
														damage2 = 60;
														num97 = 186;
														zero = new Vector2((float)(i * 16 + 8 + 18 * num106), (float)(j * 16 + 8 + 18 * num107));
													}
													break;
												}
												switch (num96 + 10)
												{
												case 0:
													if (Wiring.CheckMech(i, j, 200))
													{
														int num108 = -1;
														if (tile.frameX != 0)
														{
															num108 = 1;
														}
														speedX = (float)(12 * num108);
														damage2 = 20;
														num97 = 98;
														zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
														zero.X += (float)(10 * num108);
														zero.Y += 2f;
													}
													break;
												case 1:
													if (Wiring.CheckMech(i, j, 200))
													{
														int num109 = -1;
														if (tile.frameX != 0)
														{
															num109 = 1;
														}
														speedX = (float)(12 * num109);
														damage2 = 40;
														num97 = 184;
														zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
														zero.X += (float)(10 * num109);
														zero.Y += 2f;
													}
													break;
												case 2:
													if (Wiring.CheckMech(i, j, 200))
													{
														int num110 = -1;
														if (tile.frameX != 0)
														{
															num110 = 1;
														}
														speedX = (float)(5 * num110);
														damage2 = 40;
														num97 = 187;
														zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 7));
														zero.X += (float)(10 * num110);
														zero.Y += 2f;
													}
													break;
												case 3:
													if (Wiring.CheckMech(i, j, 300))
													{
														num97 = 185;
														int num111 = 200;
														for (int num112 = 0; num112 < 1000; num112++)
														{
															if (Main.projectile[num112].active && Main.projectile[num112].type == num97)
															{
																float num113 = (new Vector2((float)(i * 16 + 8), (float)(j * 18 + 8)) - Main.projectile[num112].Center).Length();
																if (num113 < 50f)
																{
																	num111 -= 50;
																}
																else if (num113 < 100f)
																{
																	num111 -= 15;
																}
																else if (num113 < 200f)
																{
																	num111 -= 10;
																}
																else if (num113 < 300f)
																{
																	num111 -= 8;
																}
																else if (num113 < 400f)
																{
																	num111 -= 6;
																}
																else if (num113 < 500f)
																{
																	num111 -= 5;
																}
																else if (num113 < 700f)
																{
																	num111 -= 4;
																}
																else if (num113 < 900f)
																{
																	num111 -= 3;
																}
																else if (num113 < 1200f)
																{
																	num111 -= 2;
																}
																else
																{
																	num111--;
																}
															}
														}
														if (num111 > 0)
														{
															speedX = (float)Main.rand.Next(-20, 21) * 0.05f;
															speedY = 4f + (float)Main.rand.Next(0, 21) * 0.05f;
															damage2 = 40;
															zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16));
															zero.Y += 6f;
															Projectile.NewProjectile((float)((int)zero.X), (float)((int)zero.Y), speedX, speedY, num97, damage2, 2f, Main.myPlayer, 0f, 0f);
														}
													}
													break;
												case 4:
													if (Wiring.CheckMech(i, j, 90))
													{
														speedX = 0f;
														speedY = 8f;
														damage2 = 60;
														num97 = 186;
														zero = new Vector2((float)(i * 16 + 8), (float)(j * 16 + 16));
														zero.Y += 10f;
													}
													break;
												}
												if (num97 != 0)
												{
													Projectile.NewProjectile((float)((int)zero.X), (float)((int)zero.Y), speedX, speedY, num97, damage2, 2f, Main.myPlayer, 0f, 0f);
													return;
												}
											}
											else if (type == 443)
											{
												int num114 = (int)(tile.frameX / 36);
												int num115 = i - ((int)tile.frameX - num114 * 36) / 18;
												if (Wiring.CheckMech(num115, j, 200))
												{
													Vector2 vector2 = Vector2.Zero;
													Vector2 zero2 = Vector2.Zero;
													int num116 = 654;
													int damage3 = 20;
													if (num114 < 2)
													{
														vector2 = new Vector2((float)(num115 + 1), (float)j) * 16f;
														zero2 = new Vector2(0f, -8f);
													}
													else
													{
														vector2 = new Vector2((float)(num115 + 1), (float)(j + 1)) * 16f;
														zero2 = new Vector2(0f, 8f);
													}
													if (num116 != 0)
													{
														Projectile.NewProjectile((float)((int)vector2.X), (float)((int)vector2.Y), zero2.X, zero2.Y, num116, damage3, 2f, Main.myPlayer, 0f, 0f);
														return;
													}
												}
											}
											else
											{
												if (type == 139 || type == 35)
												{
													WorldGen.SwitchMB(i, j);
													return;
												}
												if (type == 207)
												{
													WorldGen.SwitchFountain(i, j);
													return;
												}
												if (type == 410)
												{
													WorldGen.SwitchMonolith(i, j);
													return;
												}
												if (type == 141)
												{
													WorldGen.KillTile(i, j, false, false, true);
													NetMessage.SendTileSquare(-1, i, j, 1);
													Projectile.NewProjectile((float)(i * 16 + 8), (float)(j * 16 + 8), 0f, 0f, 108, 500, 10f, Main.myPlayer, 0f, 0f);
													return;
												}
												if (type == 210)
												{
													WorldGen.ExplodeMine(i, j);
													return;
												}
												if (type == 142 || type == 143)
												{
													int num117 = j - (int)(tile.frameY / 18);
													int num118 = (int)(tile.frameX / 18);
													if (num118 > 1)
													{
														num118 -= 2;
													}
													num118 = i - num118;
													Wiring.SkipWire(num118, num117);
													Wiring.SkipWire(num118, num117 + 1);
													Wiring.SkipWire(num118 + 1, num117);
													Wiring.SkipWire(num118 + 1, num117 + 1);
													if (type == 142)
													{
														for (int num119 = 0; num119 < 4; num119++)
														{
															if (Wiring._numInPump >= 19)
															{
																return;
															}
															int num120;
															int num121;
															if (num119 == 0)
															{
																num120 = num118;
																num121 = num117 + 1;
															}
															else if (num119 == 1)
															{
																num120 = num118 + 1;
																num121 = num117 + 1;
															}
															else if (num119 == 2)
															{
																num120 = num118;
																num121 = num117;
															}
															else
															{
																num120 = num118 + 1;
																num121 = num117;
															}
															Wiring._inPumpX[Wiring._numInPump] = num120;
															Wiring._inPumpY[Wiring._numInPump] = num121;
															Wiring._numInPump++;
														}
														return;
													}
													for (int num122 = 0; num122 < 4; num122++)
													{
														if (Wiring._numOutPump >= 19)
														{
															return;
														}
														int num120;
														int num121;
														if (num122 == 0)
														{
															num120 = num118;
															num121 = num117 + 1;
														}
														else if (num122 == 1)
														{
															num120 = num118 + 1;
															num121 = num117 + 1;
														}
														else if (num122 == 2)
														{
															num120 = num118;
															num121 = num117;
														}
														else
														{
															num120 = num118 + 1;
															num121 = num117;
														}
														Wiring._outPumpX[Wiring._numOutPump] = num120;
														Wiring._outPumpY[Wiring._numOutPump] = num121;
														Wiring._numOutPump++;
													}
													return;
												}
												else if (type == 105)
												{
													int num123 = j - (int)(tile.frameY / 18);
													int num124 = (int)(tile.frameX / 18);
													int num125 = 0;
													while (num124 >= 2)
													{
														num124 -= 2;
														num125++;
													}
													num124 = i - num124;
													num124 = i - (int)(tile.frameX % 36 / 18);
													num123 = j - (int)(tile.frameY % 54 / 18);
													num125 = (int)(tile.frameX / 36 + tile.frameY / 54 * 55);
													Wiring.SkipWire(num124, num123);
													Wiring.SkipWire(num124, num123 + 1);
													Wiring.SkipWire(num124, num123 + 2);
													Wiring.SkipWire(num124 + 1, num123);
													Wiring.SkipWire(num124 + 1, num123 + 1);
													Wiring.SkipWire(num124 + 1, num123 + 2);
													int num126 = num124 * 16 + 16;
													int num127 = (num123 + 3) * 16;
													int num128 = -1;
													int num129 = -1;
													bool flag11 = false;
													switch (num125)
													{
													case 51:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															299,
															538
														});
														break;
													case 52:
														num129 = 356;
														break;
													case 53:
														num129 = 357;
														break;
													case 54:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															355,
															358
														});
														break;
													case 55:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															367,
															366
														});
														break;
													case 56:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															359,
															359,
															359,
															359,
															360
														});
														break;
													case 57:
														num129 = 377;
														break;
													case 58:
														num129 = 300;
														break;
													case 59:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															364,
															362
														});
														break;
													case 60:
														num129 = 148;
														break;
													case 61:
														num129 = 361;
														break;
													case 62:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															487,
															486,
															485
														});
														break;
													case 63:
														num129 = 164;
														break;
													case 64:
														num129 = 86;
														flag11 = true;
														break;
													case 65:
														num129 = 490;
														break;
													case 66:
														num129 = 82;
														break;
													case 67:
														num129 = 449;
														break;
													case 68:
														num129 = 167;
														break;
													case 69:
														num129 = 480;
														break;
													case 70:
														num129 = 48;
														break;
													case 71:
														num129 = (int)Utils.SelectRandom<short>(Main.rand, new short[]
														{
															170,
															180,
															171
														});
														flag11 = true;
														break;
													case 72:
														num129 = 481;
														break;
													case 73:
														num129 = 482;
														break;
													case 74:
														num129 = 430;
														break;
													case 75:
														num129 = 489;
														break;
													}
													if (num129 != -1 && Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, num129))
													{
														if (!flag11 || !Collision.SolidTiles(num124 - 2, num124 + 3, num123, num123 + 2))
														{
															num128 = NPC.NewNPC(num126, num127 - 12, num129, 0, 0f, 0f, 0f, 0f, 255);
														}
														else
														{
															Vector2 position = new Vector2((float)(num126 - 4), (float)(num127 - 22)) - new Vector2(10f);
															Utils.PoofOfSmoke(position);
															NetMessage.SendData(106, -1, -1, "", (int)position.X, position.Y, 0f, 0f, 0, 0, 0);
														}
													}
													if (num128 <= -1)
													{
														if (num125 == 4)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 1))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, 1, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 7)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 49))
															{
																num128 = NPC.NewNPC(num126 - 4, num127 - 6, 49, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 8)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 55))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, 55, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 9)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 46))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, 46, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 10)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 21))
															{
																num128 = NPC.NewNPC(num126, num127, 21, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 18)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 67))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, 67, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 23)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 63))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, 63, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 27)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 85))
															{
																num128 = NPC.NewNPC(num126 - 9, num127, 85, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 28)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 74))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, (int)Utils.SelectRandom<short>(Main.rand, new short[]
																{
																	74,
																	297,
																	298
																}), 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 34)
														{
															for (int num130 = 0; num130 < 2; num130++)
															{
																for (int num131 = 0; num131 < 3; num131++)
																{
																	Tile tile2 = Main.tile[num124 + num130, num123 + num131];
																	tile2.type = 349;
																	tile2.frameX = (short)(num130 * 18 + 216);
																	tile2.frameY = (short)(num131 * 18);
																}
															}
															Animation.NewTemporaryAnimation(0, 349, num124, num123);
															if (Main.netMode == 2)
															{
																NetMessage.SendTileRange(-1, num124, num123, 2, 3);
															}
														}
														else if (num125 == 42)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 58))
															{
																num128 = NPC.NewNPC(num126, num127 - 12, 58, 0, 0f, 0f, 0f, 0f, 255);
															}
														}
														else if (num125 == 37)
														{
															if (Wiring.CheckMech(num124, num123, 600) && Item.MechSpawn((float)num126, (float)num127, 58) && Item.MechSpawn((float)num126, (float)num127, 1734) && Item.MechSpawn((float)num126, (float)num127, 1867))
															{
																Item.NewItem(num126, num127 - 16, 0, 0, 58, 1, false, 0, false, false);
															}
														}
														else if (num125 == 50)
														{
															if (Wiring.CheckMech(num124, num123, 30) && NPC.MechSpawn((float)num126, (float)num127, 65))
															{
																if (!Collision.SolidTiles(num124 - 2, num124 + 3, num123, num123 + 2))
																{
																	num128 = NPC.NewNPC(num126, num127 - 12, 65, 0, 0f, 0f, 0f, 0f, 255);
																}
																else
																{
																	Vector2 position2 = new Vector2((float)(num126 - 4), (float)(num127 - 22)) - new Vector2(10f);
																	Utils.PoofOfSmoke(position2);
																	NetMessage.SendData(106, -1, -1, "", (int)position2.X, position2.Y, 0f, 0f, 0, 0, 0);
																}
															}
														}
														else if (num125 == 2)
														{
															if (Wiring.CheckMech(num124, num123, 600) && Item.MechSpawn((float)num126, (float)num127, 184) && Item.MechSpawn((float)num126, (float)num127, 1735) && Item.MechSpawn((float)num126, (float)num127, 1868))
															{
																Item.NewItem(num126, num127 - 16, 0, 0, 184, 1, false, 0, false, false);
															}
														}
														else if (num125 == 17)
														{
															if (Wiring.CheckMech(num124, num123, 600) && Item.MechSpawn((float)num126, (float)num127, 166))
															{
																Item.NewItem(num126, num127 - 20, 0, 0, 166, 1, false, 0, false, false);
															}
														}
														else if (num125 == 40)
														{
															if (Wiring.CheckMech(num124, num123, 300))
															{
																int[] array = new int[10];
																int num132 = 0;
																for (int num133 = 0; num133 < 200; num133++)
																{
																	if (Main.npc[num133].active && (Main.npc[num133].type == 17 || Main.npc[num133].type == 19 || Main.npc[num133].type == 22 || Main.npc[num133].type == 38 || Main.npc[num133].type == 54 || Main.npc[num133].type == 107 || Main.npc[num133].type == 108 || Main.npc[num133].type == 142 || Main.npc[num133].type == 160 || Main.npc[num133].type == 207 || Main.npc[num133].type == 209 || Main.npc[num133].type == 227 || Main.npc[num133].type == 228 || Main.npc[num133].type == 229 || Main.npc[num133].type == 358 || Main.npc[num133].type == 369))
																	{
																		array[num132] = num133;
																		num132++;
																		if (num132 >= 9)
																		{
																			break;
																		}
																	}
																}
																if (num132 > 0)
																{
																	int num134 = array[Main.rand.Next(num132)];
																	Main.npc[num134].position.X = (float)(num126 - Main.npc[num134].width / 2);
																	Main.npc[num134].position.Y = (float)(num127 - Main.npc[num134].height - 1);
																	NetMessage.SendData(23, -1, -1, "", num134, 0f, 0f, 0f, 0, 0, 0);
																}
															}
														}
														else if (num125 == 41 && Wiring.CheckMech(num124, num123, 300))
														{
															int[] array2 = new int[10];
															int num135 = 0;
															for (int num136 = 0; num136 < 200; num136++)
															{
																if (Main.npc[num136].active && (Main.npc[num136].type == 18 || Main.npc[num136].type == 20 || Main.npc[num136].type == 124 || Main.npc[num136].type == 178 || Main.npc[num136].type == 208 || Main.npc[num136].type == 353))
																{
																	array2[num135] = num136;
																	num135++;
																	if (num135 >= 9)
																	{
																		break;
																	}
																}
															}
															if (num135 > 0)
															{
																int num137 = array2[Main.rand.Next(num135)];
																Main.npc[num137].position.X = (float)(num126 - Main.npc[num137].width / 2);
																Main.npc[num137].position.Y = (float)(num127 - Main.npc[num137].height - 1);
																NetMessage.SendData(23, -1, -1, "", num137, 0f, 0f, 0f, 0, 0, 0);
															}
														}
													}
													if (num128 >= 0)
													{
														Main.npc[num128].value = 0f;
														Main.npc[num128].npcSlots = 0f;
														Main.npc[num128].SpawnedFromStatue = true;
														return;
													}
												}
												else if (type == 349)
												{
													int num138 = j - (int)(tile.frameY / 18);
													int num139;
													for (num139 = (int)(tile.frameX / 18); num139 >= 2; num139 -= 2)
													{
													}
													num139 = i - num139;
													Wiring.SkipWire(num139, num138);
													Wiring.SkipWire(num139, num138 + 1);
													Wiring.SkipWire(num139, num138 + 2);
													Wiring.SkipWire(num139 + 1, num138);
													Wiring.SkipWire(num139 + 1, num138 + 1);
													Wiring.SkipWire(num139 + 1, num138 + 2);
													short num140;
													if (Main.tile[num139, num138].frameX == 0)
													{
														num140 = 216;
													}
													else
													{
														num140 = -216;
													}
													for (int num141 = 0; num141 < 2; num141++)
													{
														for (int num142 = 0; num142 < 3; num142++)
														{
															Tile expr_2E17 = Main.tile[num139 + num141, num138 + num142];
															expr_2E17.frameX += num140;
														}
													}
													if (Main.netMode == 2)
													{
														NetMessage.SendTileRange(-1, num139, num138, 2, 3);
													}
													Animation.NewTemporaryAnimation((num140 > 0) ? 0 : 1, 349, num139, num138);
												}
											}
										}
									}
								}
							}
						}
					}
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

			#region 1.3.1
			Wiring._wireDirectionList = new DoubleStack<byte>(1024, 0);
			Wiring._GatesCurrent = new Queue<Point16>();
			Wiring._GatesNext = new Queue<Point16>();
			Wiring._GatesDone = new Dictionary<Point16, bool>();
			Wiring._LampsToCheck = new Queue<Point16>();
			Wiring._PixelBoxTriggers = new Dictionary<Point16, byte>();
			#endregion
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
							NetMessage.SendData(65, -1, -1, "", 0, (float)j, vector21.X, vector21.Y, 0, 0, 0);
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

		// Token: 0x06000E86 RID: 3718 RVA: 0x0025C710 File Offset: 0x0025A910
		private static void TripWire(int left, int top, int width, int height)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Wiring.running = true;
			if (Wiring._wireList.Count != 0)
			{
				Wiring._wireList.Clear(true);
			}
			if (Wiring._wireDirectionList.Count != 0)
			{
				Wiring._wireDirectionList.Clear(true);
			}
			Vector2[] array = new Vector2[8];
			int num = 0;
			for (int i = left; i < left + width; i++)
			{
				for (int j = top; j < top + height; j++)
				{
					Point16 back = new Point16(i, j);
					Tile tile = Main.tile[i, j];
					if (tile != null && tile.wire())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
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
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			for (int k = left; k < left + width; k++)
			{
				for (int l = top; l < top + height; l++)
				{
					Point16 back = new Point16(k, l);
					Tile tile2 = Main.tile[k, l];
					if (tile2 != null && tile2.wire2())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
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
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			for (int m = left; m < left + width; m++)
			{
				for (int n = top; n < top + height; n++)
				{
					Point16 back = new Point16(m, n);
					Tile tile3 = Main.tile[m, n];
					if (tile3 != null && tile3.wire3())
					{
						Wiring._wireList.PushBack(back);
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
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			Wiring._teleport[0].X = -1f;
			Wiring._teleport[0].Y = -1f;
			Wiring._teleport[1].X = -1f;
			Wiring._teleport[1].Y = -1f;
			for (int num2 = left; num2 < left + width; num2++)
			{
				for (int num3 = top; num3 < top + height; num3++)
				{
					Point16 back = new Point16(num2, num3);
					Tile tile4 = Main.tile[num2, num3];
					if (tile4 != null && tile4.wire4())
					{
						Wiring._wireList.PushBack(back);
					}
				}
			}
			if (Wiring._wireList.Count > 0)
			{
				Wiring._numInPump = 0;
				Wiring._numOutPump = 0;
				Wiring.HitWire(Wiring._wireList, 4);
				if (Wiring._numInPump > 0 && Wiring._numOutPump > 0)
				{
					Wiring.XferWater();
				}
			}
			array[num++] = Wiring._teleport[0];
			array[num++] = Wiring._teleport[1];
			for (int num4 = 0; num4 < 8; num4 += 2)
			{
				Wiring._teleport[0] = array[num4];
				Wiring._teleport[1] = array[num4 + 1];
				if (Wiring._teleport[0].X >= 0f && Wiring._teleport[1].X >= 0f)
				{
					Wiring.Teleport();
				}
			}
			Wiring.PixelBoxPass();
			Wiring.LogicGatePass();
		}

		public static void UpdateMech()
		{
			Wiring.SetCurrentUser(-1);

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
					Interlocked.Decrement(ref _numMechs);

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

		#region 1.3.1
		private static void PixelBoxPass() 
		{
			foreach (KeyValuePair<Point16, byte> current in Wiring._PixelBoxTriggers)
			{
				if (current.Value != 2)
				{
					if (current.Value == 1)
					{
						if (Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX != 0)
						{
							Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX = 0;
							NetMessage.SendTileSquare(-1, (int)current.Key.X, (int)current.Key.Y, 1);
						}
					}
					else if (current.Value == 3 && Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX != 18)
					{
						Main.tile[(int)current.Key.X, (int)current.Key.Y].frameX = 18;
						NetMessage.SendTileSquare(-1, (int)current.Key.X, (int)current.Key.Y, 1);
					}
				}
			}
			Wiring._PixelBoxTriggers.Clear();
		}

		public static bool Actuate(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (!tile.actuator())
			{
				return false;
			}
			if ((tile.type != 226 || (double)j <= Main.worldSurface || NPC.downedPlantBoss) && ((double)j <= Main.worldSurface || NPC.downedGolemBoss || Main.tile[i, j - 1].type != 237))
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
			return true;
		}

		public static void ActuateForced(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile.type == 226 && (double)j > Main.worldSurface && !NPC.downedPlantBoss)
			{
				return;
			}
			if (tile.inActive())
			{
				Wiring.ReActive(i, j);
				return;
			}
			Wiring.DeActive(i, j);
		}

		public static void MassWireOperation(Point ps, Point pe, Player master)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 58; i++)
			{
				if (master.inventory[i].type == 530)
				{
					num += master.inventory[i].stack;
				}
				if (master.inventory[i].type == 849)
				{
					num2 += master.inventory[i].stack;
				}
			}
			int num3 = num;
			int num4 = num2;
			Wiring.MassWireOperationInner(ps, pe, master.Center, master.direction == 1, ref num, ref num2);
			int num5 = num3 - num;
			int num6 = num4 - num2;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(110, master.whoAmI, -1, "", 530, (float)num5, (float)master.whoAmI, 0f, 0, 0, 0);
				NetMessage.SendData(110, master.whoAmI, -1, "", 849, (float)num6, (float)master.whoAmI, 0f, 0, 0, 0);
				return;
			}
			for (int j = 0; j < num5; j++)
			{
				master.consumeItem(530);
			}
			for (int k = 0; k < num6; k++)
			{
				master.consumeItem(849);
			}
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x002608DC File Offset: 0x0025EADC
		private static void MassWireOperationInner(Point ps, Point pe, Vector2 dropPoint, bool dir, ref int wireCount, ref int actuatorCount)
		{
			Math.Abs(ps.X - pe.X);
			Math.Abs(ps.Y - pe.Y);
			int num = Math.Sign(pe.X - ps.X);
			int num2 = Math.Sign(pe.Y - ps.Y);
			WiresUI.Settings.MultiToolMode toolMode = WiresUI.Settings.ToolMode;
			Point pt = default(Point);
			bool flag = false;
			Item.StartCachingType(530);
			Item.StartCachingType(849);
			int num3;
			int num4;
			int num5;
			if (dir)
			{
				pt.X = ps.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			else
			{
				pt.Y = ps.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			int num6 = num3;
			while (num6 != num4 && !flag)
			{
				if (dir)
				{
					pt.Y = num6;
				}
				else
				{
					pt.X = num6;
				}
				bool? flag2 = Wiring.MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
				if (flag2.HasValue && !flag2.Value)
				{
					flag = true;
					break;
				}
				num6 += num5;
			}
			if (dir)
			{
				pt.Y = pe.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			else
			{
				pt.X = pe.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			int num7 = num3;
			while (num7 != num4 && !flag)
			{
				if (!dir)
				{
					pt.Y = num7;
				}
				else
				{
					pt.X = num7;
				}
				bool? flag3 = Wiring.MassWireOperationStep(pt, toolMode, ref wireCount, ref actuatorCount);
				if (flag3.HasValue && !flag3.Value)
				{
					flag = true;
					break;
				}
				num7 += num5;
			}
			if (!flag)
			{
				Wiring.MassWireOperationStep(pe, toolMode, ref wireCount, ref actuatorCount);
			}
			Item.DropCache(dropPoint, Vector2.Zero, 530, true);
			Item.DropCache(dropPoint, Vector2.Zero, 849, true);
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x00260AD8 File Offset: 0x0025ECD8
		private static bool? MassWireOperationStep(Point pt, WiresUI.Settings.MultiToolMode mode, ref int wiresLeftToConsume, ref int actuatorsLeftToConstume)
		{
			if (!WorldGen.InWorld(pt.X, pt.Y, 1))
			{
				return null;
			}
			Tile tile = Main.tile[pt.X, pt.Y];
			if (tile == null)
			{
				return null;
			}
			if (!mode.HasFlag(WiresUI.Settings.MultiToolMode.Cutter))
			{
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Red) && !tile.wire())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, "", 5, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Green) && !tile.wire3())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire3(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, "", 12, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Blue) && !tile.wire2())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire2(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, "", 10, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Yellow) && !tile.wire4())
				{
					if (wiresLeftToConsume <= 0)
					{
						return new bool?(false);
					}
					wiresLeftToConsume--;
					WorldGen.PlaceWire4(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, "", 16, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Actuator) && !tile.actuator())
				{
					if (actuatorsLeftToConstume <= 0)
					{
						return new bool?(false);
					}
					actuatorsLeftToConstume--;
					WorldGen.PlaceActuator(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, "", 8, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
			}
			if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Cutter))
			{
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Red) && tile.wire() && WorldGen.KillWire(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, "", 6, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Green) && tile.wire3() && WorldGen.KillWire3(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, "", 13, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Blue) && tile.wire2() && WorldGen.KillWire2(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, "", 11, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Yellow) && tile.wire4() && WorldGen.KillWire4(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, "", 17, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
				if (mode.HasFlag(WiresUI.Settings.MultiToolMode.Actuator) && tile.actuator() && WorldGen.KillActuator(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, "", 9, (float)pt.X, (float)pt.Y, 0f, 0, 0, 0);
				}
			}
			return new bool?(true);
		}

		private static void CheckLogicGate(int lampX, int lampY)
		{
			if (!WorldGen.InWorld(lampX, lampY, 1))
			{
				return;
			}
			int i = lampY;
			while (i < Main.maxTilesY)
			{
				Tile tile = Main.tile[lampX, i];
				if (!tile.active())
				{
					return;
				}
				if (tile.type == 420)
				{
					bool flag;
					Wiring._GatesDone.TryGetValue(new Point16(lampX, i), out flag);
					int num = (int)(tile.frameY / 18);
					bool flag2 = tile.frameX == 18;
					bool flag3 = tile.frameX == 36;
					if (num < 0)
					{
						return;
					}
					int num2 = 0;
					int num3 = 0;
					bool flag4 = false;
					for (int j = i - 1; j > 0; j--)
					{
						Tile tile2 = Main.tile[lampX, j];
						if (!tile2.active() || tile2.type != 419)
						{
							break;
						}
						if (tile2.frameX == 36)
						{
							flag4 = true;
							break;
						}
						num2++;
						num3 += (tile2.frameX == 18).ToInt();
					}
					bool flag5;
					switch (num)
					{
						case 0:
							flag5 = (num2 == num3);
							break;
						case 1:
							flag5 = (num3 > 0);
							break;
						case 2:
							flag5 = (num2 != num3);
							break;
						case 3:
							flag5 = (num3 == 0);
							break;
						case 4:
							flag5 = (num3 == 1);
							break;
						case 5:
							flag5 = (num3 != 1);
							break;
						default:
							return;
					}
					bool flag6 = !flag4 && flag3;
					bool flag7 = false;
					if (flag4 && Framing.GetTileSafely(lampX, lampY).frameX == 36)
					{
						flag7 = true;
					}
					if (flag5 != flag2 || flag6 || flag7)
					{
						short arg_183_0 = (short)(tile.frameX % 18 / 18);
						tile.frameX = (short)(18 * flag5.ToInt());
						if (flag4)
						{
							tile.frameX = 36;
						}
						Wiring.SkipWire(lampX, i);
						WorldGen.SquareTileFrame(lampX, i, true);
						NetMessage.SendTileSquare(-1, lampX, i, 1);
						bool flag8 = !flag4 || flag7;
						if (flag7)
						{
							if (num3 == 0 || num2 == 0)
							{
							}
							flag8 = (Main.rand.NextFloat() < (float)num3 / (float)num2);
						}
						if (flag6)
						{
							flag8 = false;
						}
						if (flag8)
						{
							if (!flag)
							{
								Wiring._GatesNext.Enqueue(new Point16(lampX, i));
								return;
							}
							Vector2 position = new Vector2((float)lampX, (float)i) * 16f - new Vector2(10f);
							Utils.PoofOfSmoke(position);
							NetMessage.SendData(106, -1, -1, "", (int)position.X, position.Y, 0f, 0f, 0, 0, 0);
						}
					}
					return;
				}
				else
				{
					if (tile.type != 419)
					{
						return;
					}
					i++;
				}
			}
		}


		private static void LogicGatePass()
		{
			if (Wiring._GatesCurrent.Count == 0)
			{
				Wiring._GatesDone.Clear();
				while (Wiring._LampsToCheck.Count > 0)
				{
					while (Wiring._LampsToCheck.Count > 0)
					{
						Point16 point = Wiring._LampsToCheck.Dequeue();
						Wiring.CheckLogicGate((int)point.X, (int)point.Y);
					}
					while (Wiring._GatesNext.Count > 0)
					{
						Utils.Swap<Queue<Point16>>(ref Wiring._GatesCurrent, ref Wiring._GatesNext);
						while (Wiring._GatesCurrent.Count > 0)
						{
							Point16 key = Wiring._GatesCurrent.Peek();
							bool flag;
							if (Wiring._GatesDone.TryGetValue(key, out flag) && flag)
							{
								Wiring._GatesCurrent.Dequeue();
							}
							else
							{
								Wiring._GatesDone.Add(key, true);
								Wiring.TripWire((int)key.X, (int)key.Y, 1, 1);
								Wiring._GatesCurrent.Dequeue();
							}
						}
					}
				}
				Wiring._GatesDone.Clear();
				if (Wiring.blockPlayerTeleportationForOneIteration)
				{
					Wiring.blockPlayerTeleportationForOneIteration = false;
				}
			}
		}


		public static void PokeLogicGate(int lampX, int lampY)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			Wiring._LampsToCheck.Enqueue(new Point16(lampX, lampY));
			Wiring.LogicGatePass();
		}


		// Token: 0x06000E7A RID: 3706 RVA: 0x0025BAD3 File Offset: 0x00259CD3
		public static void SetCurrentUser(int plr = -1)
		{
			if (plr < 0 || plr >= 255)
			{
				plr = 254;
			}
			if (Main.netMode == 0)
			{
				plr = Main.myPlayer;
			}
			Wiring.CurrentUser = plr;
		}
		#endregion
	}
}