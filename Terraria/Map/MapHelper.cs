using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using Terraria;
using Terraria.IO;
using Terraria.Social;
using Terraria.Utilities;

namespace Terraria.Map
{
	internal static class MapHelper
	{
		public const int drawLoopMilliseconds = 5;

		private const int HeaderEmpty = 0;

		private const int HeaderTile = 1;

		private const int HeaderWall = 2;

		private const int HeaderWater = 3;

		private const int HeaderLava = 4;

		private const int HeaderHoney = 5;

		private const int HeaderHeavenAndHell = 6;

		private const int HeaderBackground = 7;

		private const int maxTileOptions = 12;

		private const int maxWallOptions = 2;

		private const int maxLiquidTypes = 3;

		private const int maxSkyGradients = 256;

		private const int maxDirtGradients = 256;

		private const int maxRockGradients = 256;

		public static int maxUpdateTile;

		public static int numUpdateTile;

		public static short[] updateTileX;

		public static short[] updateTileY;

		private static bool saveLock;

		private static object padlock;

		public static int[] tileOptionCounts;

		public static int[] wallOptionCounts;

		public static ushort[] tileLookup;

		public static ushort[] wallLookup;

		private static ushort tilePosition;

		private static ushort wallPosition;

		private static ushort liquidPosition;

		private static ushort skyPosition;

		private static ushort dirtPosition;

		private static ushort rockPosition;

		private static ushort hellPosition;

		private static Color[] colorLookup;

		private static ushort[] snowTypes;

		private static ushort wallRangeStart;

		private static ushort wallRangeEnd;

		static MapHelper()
		{
			MapHelper.maxUpdateTile = 1000;
			MapHelper.numUpdateTile = 0;
			MapHelper.updateTileX = new short[MapHelper.maxUpdateTile];
			MapHelper.updateTileY = new short[MapHelper.maxUpdateTile];
			MapHelper.saveLock = false;
			MapHelper.padlock = new object();
		}

		public static MapTile CreateMapTile(int i, int j, byte Light)
		{
			int num;
			bool flag;
			Tile tile = Main.tile[i, j];
			if (tile == null)
			{
				Tile[,] tileArray = Main.tile;
				Tile tile1 = new Tile();
				Tile tile2 = tile1;
				tileArray[i, j] = tile1;
				tile = tile2;
			}
			int num1 = 0;
			int light = Light;
			ushort type = Main.Map[i, j].Type;
			int num2 = 0;
			int num3 = 0;
			if (tile.active())
			{
				int num4 = tile.type;
				num2 = MapHelper.tileLookup[num4];
				if (num4 == 51 && (i + j) % 2 == 0)
				{
					num2 = 0;
				}
				if (num2 != 0)
				{
					if (num4 != 160)
					{
						num1 = tile.color();
					}
					else
					{
						num1 = 0;
					}
					int num5 = num4;
					if (num5 <= 137)
					{
						if (num5 > 31)
						{
							switch (num5)
							{
								case 82:
								case 83:
								case 84:
								{
									if (tile.frameX < 18)
									{
										num3 = 0;
										goto Label0;
									}
									else if (tile.frameX < 36)
									{
										num3 = 1;
										goto Label0;
									}
									else if (tile.frameX < 54)
									{
										num3 = 2;
										goto Label0;
									}
									else if (tile.frameX < 72)
									{
										num3 = 3;
										goto Label0;
									}
									else if (tile.frameX < 90)
									{
										num3 = 4;
										goto Label0;
									}
									else if (tile.frameX >= 108)
									{
										num3 = 6;
										goto Label0;
									}
									else
									{
										num3 = 5;
										goto Label0;
									}
								}
								default:
								{
									if (num5 != 105)
									{
										switch (num5)
										{
											case 133:
											{
												if (tile.frameX >= 52)
												{
													num3 = 1;
													goto Label0;
												}
												else
												{
													num3 = 0;
													goto Label0;
												}
											}
											case 134:
											{
												if (tile.frameX >= 28)
												{
													num3 = 1;
													goto Label0;
												}
												else
												{
													num3 = 0;
													goto Label0;
												}
											}
											case 137:
											{
												if (tile.frameY != 0)
												{
													num3 = 1;
													goto Label0;
												}
												else
												{
													num3 = 0;
													goto Label0;
												}
											}
										}
									}
									else if (tile.frameX >= 1548 && tile.frameX <= 1654)
									{
										num3 = 1;
										goto Label0;
									}
									else if (tile.frameX < 1656 || tile.frameX > 1798)
									{
										num3 = 0;
										goto Label0;
									}
									else
									{
										num3 = 2;
										goto Label0;
									}
									break;
								}
							}
						}
						else if (num5 == 4)
						{
							if (tile.frameX < 66)
							{
								num3 = 1;
							}
							num3 = 0;
							goto Label0;
						}
						else if (num5 == 21)
						{
							num = tile.frameX / 36;
							if (num == 1 || num == 2 || num == 10 || num == 13 || num == 15)
							{
								num3 = 1;
								goto Label0;
							}
							else if (num == 3 || num == 4)
							{
								num3 = 2;
								goto Label0;
							}
							else if (num == 6)
							{
								num3 = 3;
								goto Label0;
							}
							else if (num == 11 || num == 17)
							{
								num3 = 4;
								goto Label0;
							}
							else
							{
								num3 = 0;
								goto Label0;
							}
						}
						else
						{
							switch (num5)
							{
								case 26:
								{
									if (tile.frameX < 54)
									{
										num3 = 0;
										goto Label0;
									}
									else
									{
										num3 = 1;
										goto Label0;
									}
								}
								case 27:
								{
									if (tile.frameY >= 34)
									{
										num3 = 0;
										goto Label0;
									}
									else
									{
										num3 = 1;
										goto Label0;
									}
								}
								case 28:
								{
									if (tile.frameY < 144)
									{
										num3 = 0;
										goto Label0;
									}
									else if (tile.frameY < 252)
									{
										num3 = 1;
										goto Label0;
									}
									else if (tile.frameY < 360 || tile.frameY > 900 && tile.frameY < 1008)
									{
										num3 = 2;
										goto Label0;
									}
									else if (tile.frameY < 468)
									{
										num3 = 3;
										goto Label0;
									}
									else if (tile.frameY < 576)
									{
										num3 = 4;
										goto Label0;
									}
									else if (tile.frameY < 684)
									{
										num3 = 5;
										goto Label0;
									}
									else if (tile.frameY < 792)
									{
										num3 = 6;
										goto Label0;
									}
									else if (tile.frameY < 898)
									{
										num3 = 8;
										goto Label0;
									}
									else if (tile.frameY < 1006)
									{
										num3 = 7;
										goto Label0;
									}
									else if (tile.frameY < 1114)
									{
										num3 = 0;
										goto Label0;
									}
									else if (tile.frameY >= 1222)
									{
										num3 = 7;
										goto Label0;
									}
									else
									{
										num3 = 3;
										goto Label0;
									}
								}
								case 31:
								{
									if (tile.frameX < 36)
									{
										num3 = 0;
										goto Label0;
									}
									else
									{
										num3 = 1;
										goto Label0;
									}
								}
							}
						}
					}
					else if (num5 <= 165)
					{
						if (num5 == 149)
						{
							num3 = j % 3;
							goto Label0;
						}
						else if (num5 == 160)
						{
							num3 = j % 3;
							goto Label0;
						}
						else
						{
							if (num5 != 165)
							{
								goto Label6;
							}
							if (tile.frameX < 54)
							{
								num3 = 0;
								goto Label0;
							}
							else if (tile.frameX < 106)
							{
								num3 = 1;
								goto Label0;
							}
							else if (tile.frameX >= 216)
							{
								num3 = 1;
								goto Label0;
							}
							else if (tile.frameX >= 162)
							{
								num3 = 3;
								goto Label0;
							}
							else
							{
								num3 = 2;
								goto Label0;
							}
						}
					}
					else if (num5 > 187)
					{
						if (num5 == 227)
						{
							num3 = tile.frameX / 34;
							goto Label0;
						}
						else
						{
							switch (num5)
							{
								case 240:
								{
									num = tile.frameX / 54;
									num = num + tile.frameY / 54 * 36;
									if (num >= 0 && num <= 11 || num >= 47 && num <= 53)
									{
										num3 = 0;
										goto Label0;
									}
									else if (num >= 12 && num <= 15)
									{
										num3 = 1;
										goto Label0;
									}
									else if (num == 16 || num == 17)
									{
										num3 = 2;
										goto Label0;
									}
									else if (num >= 18 && num <= 35)
									{
										num3 = 1;
										goto Label0;
									}
									else if (num < 41 || num > 45)
									{
										if (num != 46)
										{
											goto Label0;
										}
										num3 = 4;
										goto Label0;
									}
									else
									{
										num3 = 3;
										goto Label0;
									}
								}
								case 242:
								{
									num = tile.frameY / 72;
									if (num < 22 || num > 24)
									{
										num3 = 0;
										goto Label0;
									}
									else
									{
										num3 = 1;
										goto Label0;
									}
								}
							}
						}
					}
					else if (num5 != 178)
					{
						switch (num5)
						{
							case 184:
							{
								if (tile.frameX < 22)
								{
									num3 = 0;
									goto Label0;
								}
								else if (tile.frameX < 44)
								{
									num3 = 1;
									goto Label0;
								}
								else if (tile.frameX < 66)
								{
									num3 = 2;
									goto Label0;
								}
								else if (tile.frameX < 88)
								{
									num3 = 3;
									goto Label0;
								}
								else if (tile.frameX >= 110)
								{
									num3 = 5;
									goto Label0;
								}
								else
								{
									num3 = 4;
									goto Label0;
								}
							}
							case 185:
							{
								if (tile.frameY >= 18)
								{
									num = tile.frameX / 36;
									if (num < 6 || num == 19 || num == 20 || num == 21 || num == 22 || num == 23 || num == 24 || num == 33 || num == 38 || num == 39 || num == 40)
									{
										num3 = 0;
										goto Label0;
									}
									else if (num < 16)
									{
										num3 = 2;
										goto Label0;
									}
									else if (num < 19 || num == 31 || num == 32)
									{
										num3 = 1;
										goto Label0;
									}
									else if (num >= 31)
									{
										if (num >= 38)
										{
											goto Label0;
										}
										num3 = 4;
										goto Label0;
									}
									else
									{
										num3 = 3;
										goto Label0;
									}
								}
								else
								{
									num = tile.frameX / 18;
									if (num < 6 || num == 28 || num == 29 || num == 30 || num == 31 || num == 32)
									{
										num3 = 0;
										goto Label0;
									}
									else if (num < 12 || num == 33 || num == 34 || num == 35)
									{
										num3 = 1;
										goto Label0;
									}
									else if (num < 28)
									{
										num3 = 2;
										goto Label0;
									}
									else if (num >= 48)
									{
										if (num >= 54)
										{
											goto Label0;
										}
										num3 = 4;
										goto Label0;
									}
									else
									{
										num3 = 3;
										goto Label0;
									}
								}
							}
							case 186:
							{
								num = tile.frameX / 54;
								if (num < 7)
								{
									num3 = 2;
									goto Label0;
								}
								else if (num < 22 || num == 33 || num == 34 || num == 35)
								{
									num3 = 0;
									goto Label0;
								}
								else if (num < 25)
								{
									num3 = 1;
									goto Label0;
								}
								else if (num != 25)
								{
									if (num >= 32)
									{
										goto Label0;
									}
									num3 = 3;
									goto Label0;
								}
								else
								{
									num3 = 5;
									goto Label0;
								}
							}
							case 187:
							{
								num = tile.frameX / 54;
								if (num < 3 || num == 14 || num == 15 || num == 16)
								{
									num3 = 0;
									goto Label0;
								}
								else if (num < 6)
								{
									num3 = 6;
									goto Label0;
								}
								else if (num < 9)
								{
									num3 = 7;
									goto Label0;
								}
								else if (num < 14)
								{
									num3 = 4;
									goto Label0;
								}
								else if (num < 18)
								{
									num3 = 4;
									goto Label0;
								}
								else if (num < 23)
								{
									num3 = 8;
									goto Label0;
								}
								else if (num >= 25)
								{
									if (num >= 29)
									{
										goto Label0;
									}
									num3 = 1;
									goto Label0;
								}
								else
								{
									num3 = 0;
									goto Label0;
								}
							}
						}
					}
					else if (tile.frameX < 18)
					{
						num3 = 0;
						goto Label0;
					}
					else if (tile.frameX < 36)
					{
						num3 = 1;
						goto Label0;
					}
					else if (tile.frameX < 54)
					{
						num3 = 2;
						goto Label0;
					}
					else if (tile.frameX < 72)
					{
						num3 = 3;
						goto Label0;
					}
					else if (tile.frameX < 90)
					{
						num3 = 4;
						goto Label0;
					}
					else if (tile.frameX >= 108)
					{
						num3 = 6;
						goto Label0;
					}
					else
					{
						num3 = 5;
						goto Label0;
					}
				Label6:
					num3 = 0;
				}
			}
		Label0:
			if (num2 == 0)
			{
				if (tile.liquid > 32)
				{
					int num6 = tile.liquidType();
					num2 = MapHelper.liquidPosition + num6;
				}
				else if (tile.wall > 0)
				{
					int num7 = tile.wall;
					num2 = MapHelper.wallLookup[num7];
					num1 = tile.wallColor();
					int num8 = num7;
					if (num8 > 27)
					{
						switch (num8)
						{
							case 88:
							case 89:
							case 90:
							case 91:
							case 92:
							case 93:
							{
								break;
							}
							default:
							{
								if (num8 != 168)
								{
									goto Label2;
								}
								else
								{
									break;
								}
							}
						}
					}
					else
					{
						if (num8 == 21)
						{
							goto Label4;
						}
						if (num8 != 27)
						{
							goto Label2;
						}
						num3 = i % 2;
						goto Label3;
					}
				Label4:
					num1 = 0;
				}
			}
		Label3:
			if (num2 == 0)
			{
				if ((double)j < Main.worldSurface)
				{
					int num9 = (byte)(255 * ((double)j / Main.worldSurface));
					num2 = MapHelper.skyPosition + num9;
					light = 255;
					num1 = 0;
				}
				else if (j >= Main.maxTilesY - 200)
				{
					num2 = MapHelper.hellPosition;
				}
				else
				{
					num1 = 0;
					flag = (type < MapHelper.dirtPosition || type >= MapHelper.hellPosition ? true : false);
					byte num10 = 0;
					float x = Main.screenPosition.X / 16f - 5f;
					float single = (Main.screenPosition.X + (float)Main.screenWidth) / 16f + 5f;
					float y = Main.screenPosition.Y / 16f - 5f;
					float y1 = (Main.screenPosition.Y + (float)Main.screenHeight) / 16f + 5f;
					if (((float)i < x || (float)i > single || (float)j < y || (float)j > y1) && i > 40 && i < Main.maxTilesX - 40 && j > 40 && j < Main.maxTilesY - 40 && flag)
					{
						for (int i1 = i - 36; i1 <= i + 30; i1 = i1 + 10)
						{
							for (int j1 = j - 36; j1 <= j + 30; j1 = j1 + 10)
							{
								int num11 = 0;
								while (num11 < (int)MapHelper.snowTypes.Length)
								{
									if (MapHelper.snowTypes[num11] != type)
									{
										num11++;
									}
									else
									{
										num10 = 255;
										i1 = i + 31;
										j1 = j + 31;
										break;
									}
								}
							}
						}
					}
					else
					{
						float single1 = (float)Main.snowTiles / 1000f;
						single1 = single1 * 255f;
						if (single1 > 255f)
						{
							single1 = 255f;
						}
						num10 = (byte)single1;
					}
					num2 = ((double)j >= Main.rockLayer ? MapHelper.rockPosition + num10 : MapHelper.dirtPosition + num10);
				}
			}
			int num12 = num2 + num3;
			return MapTile.Create((ushort)num12, (byte)light, (byte)num1);
		Label2:
			num3 = 0;
			goto Label3;
		}

		public static Color GetMapTileXnaColor(ref MapTile tile)
		{
			Color r = MapHelper.colorLookup[tile.Type];
			byte color = tile.Color;
			if (color > 0)
			{
				MapHelper.MapColor(tile.Type, ref r, color);
			}
			if (tile.Light == 255)
			{
				return r;
			}
			float light = (float)tile.Light / 255f;
			r.R = (byte)((float)r.R * light);
			r.G = (byte)((float)r.G * light);
			r.B = (byte)((float)r.B * light);
			return r;
		}

		public static void Initialize()
		{
			Color[][] color = new Color[419][];
			for (int i = 0; i < 419; i++)
			{
				color[i] = new Color[12];
			}
			Color color1 = new Color(151, 107, 75);
			color[0][0] = color1;
			color[5][0] = color1;
			color[30][0] = color1;
			color[191][0] = color1;
			color[272][0] = new Color(121, 119, 101);
			color1 = new Color(128, 128, 128);
			color[1][0] = color1;
			color[38][0] = color1;
			color[48][0] = color1;
			color[130][0] = color1;
			color[138][0] = color1;
			color[273][0] = color1;
			color[283][0] = color1;
			color[2][0] = new Color(28, 216, 94);
			color1 = new Color(26, 196, 84);
			color[3][0] = color1;
			color[192][0] = color1;
			color[73][0] = new Color(27, 197, 109);
			color[52][0] = new Color(23, 177, 76);
			color[353][0] = new Color(28, 216, 94);
			color[20][0] = new Color(163, 116, 81);
			color[6][0] = new Color(140, 101, 80);
			color1 = new Color(150, 67, 22);
			color[7][0] = color1;
			color[47][0] = color1;
			color[284][0] = color1;
			color1 = new Color(185, 164, 23);
			color[8][0] = color1;
			color[45][0] = color1;
			color1 = new Color(185, 194, 195);
			color[9][0] = color1;
			color[46][0] = color1;
			color1 = new Color(98, 95, 167);
			color[22][0] = color1;
			color[140][0] = color1;
			color[23][0] = new Color(141, 137, 223);
			color[24][0] = new Color(122, 116, 218);
			color[25][0] = new Color(109, 90, 128);
			color[37][0] = new Color(104, 86, 84);
			color[39][0] = new Color(181, 62, 59);
			color[40][0] = new Color(146, 81, 68);
			color[41][0] = new Color(66, 84, 109);
			color[43][0] = new Color(84, 100, 63);
			color[44][0] = new Color(107, 68, 99);
			color[53][0] = new Color(186, 168, 84);
			color1 = new Color(190, 171, 94);
			color[151][0] = color1;
			color[154][0] = color1;
			color[274][0] = color1;
			color[328][0] = new Color(200, 246, 254);
			color[329][0] = new Color(15, 15, 15);
			color[54][0] = new Color(200, 246, 254);
			color[56][0] = new Color(43, 40, 84);
			color[75][0] = new Color(26, 26, 26);
			color[57][0] = new Color(68, 68, 76);
			color1 = new Color(142, 66, 66);
			color[58][0] = color1;
			color[76][0] = color1;
			color1 = new Color(92, 68, 73);
			color[59][0] = color1;
			color[120][0] = color1;
			color[60][0] = new Color(143, 215, 29);
			color[61][0] = new Color(135, 196, 26);
			color[74][0] = new Color(96, 197, 27);
			color[62][0] = new Color(121, 176, 24);
			color[233][0] = new Color(107, 182, 29);
			color[63][0] = new Color(110, 140, 182);
			color[64][0] = new Color(196, 96, 114);
			color[65][0] = new Color(56, 150, 97);
			color[66][0] = new Color(160, 118, 58);
			color[67][0] = new Color(140, 58, 166);
			color[68][0] = new Color(125, 191, 197);
			color[70][0] = new Color(93, 127, 255);
			color1 = new Color(182, 175, 130);
			color[71][0] = color1;
			color[72][0] = color1;
			color[190][0] = color1;
			color1 = new Color(73, 120, 17);
			color[80][0] = color1;
			color[188][0] = color1;
			color1 = new Color(11, 80, 143);
			color[107][0] = color1;
			color[121][0] = color1;
			color1 = new Color(91, 169, 169);
			color[108][0] = color1;
			color[122][0] = color1;
			color1 = new Color(128, 26, 52);
			color[111][0] = color1;
			color[150][0] = color1;
			color[109][0] = new Color(78, 193, 227);
			color[110][0] = new Color(48, 186, 135);
			color[113][0] = new Color(48, 208, 234);
			color[115][0] = new Color(33, 171, 207);
			color[112][0] = new Color(103, 98, 122);
			color1 = new Color(238, 225, 218);
			color[116][0] = color1;
			color[118][0] = color1;
			color[117][0] = new Color(181, 172, 190);
			color[119][0] = new Color(107, 92, 108);
			color[123][0] = new Color(106, 107, 118);
			color[124][0] = new Color(73, 51, 36);
			color[131][0] = new Color(52, 52, 52);
			color[145][0] = new Color(192, 30, 30);
			color[146][0] = new Color(43, 192, 30);
			color1 = new Color(211, 236, 241);
			color[147][0] = color1;
			color[148][0] = color1;
			color[152][0] = new Color(128, 133, 184);
			color[153][0] = new Color(239, 141, 126);
			color[155][0] = new Color(131, 162, 161);
			color[156][0] = new Color(170, 171, 157);
			color[157][0] = new Color(104, 100, 126);
			color1 = new Color(145, 81, 85);
			color[158][0] = color1;
			color[232][0] = color1;
			color[159][0] = new Color(148, 133, 98);
			color[160][0] = new Color(200, 0, 0);
			color[160][1] = new Color(0, 200, 0);
			color[160][2] = new Color(0, 0, 200);
			color[161][0] = new Color(144, 195, 232);
			color[162][0] = new Color(184, 219, 240);
			color[163][0] = new Color(174, 145, 214);
			color[164][0] = new Color(218, 182, 204);
			color[170][0] = new Color(27, 109, 69);
			color[171][0] = new Color(33, 135, 85);
			color1 = new Color(129, 125, 93);
			color[166][0] = color1;
			color[175][0] = color1;
			color[167][0] = new Color(62, 82, 114);
			color1 = new Color(132, 157, 127);
			color[168][0] = color1;
			color[176][0] = color1;
			color1 = new Color(152, 171, 198);
			color[169][0] = color1;
			color[177][0] = color1;
			color[179][0] = new Color(49, 134, 114);
			color[180][0] = new Color(126, 134, 49);
			color[181][0] = new Color(134, 59, 49);
			color[182][0] = new Color(43, 86, 140);
			color[183][0] = new Color(121, 49, 134);
			color[381][0] = new Color(254, 121, 2);
			color[189][0] = new Color(223, 255, 255);
			color[193][0] = new Color(56, 121, 255);
			color[194][0] = new Color(157, 157, 107);
			color[195][0] = new Color(134, 22, 34);
			color[196][0] = new Color(147, 144, 178);
			color[197][0] = new Color(97, 200, 225);
			color[198][0] = new Color(62, 61, 52);
			color[199][0] = new Color(208, 80, 80);
			color[201][0] = new Color(203, 61, 64);
			color[205][0] = new Color(186, 50, 52);
			color[200][0] = new Color(216, 152, 144);
			color[202][0] = new Color(213, 178, 28);
			color[203][0] = new Color(128, 44, 45);
			color[204][0] = new Color(125, 55, 65);
			color[206][0] = new Color(124, 175, 201);
			color[208][0] = new Color(88, 105, 118);
			color[211][0] = new Color(191, 233, 115);
			color[213][0] = new Color(137, 120, 67);
			color[214][0] = new Color(103, 103, 103);
			color[221][0] = new Color(239, 90, 50);
			color[222][0] = new Color(231, 96, 228);
			color[223][0] = new Color(57, 85, 101);
			color[224][0] = new Color(107, 132, 139);
			color[225][0] = new Color(227, 125, 22);
			color[226][0] = new Color(141, 56, 0);
			color[229][0] = new Color(255, 156, 12);
			color[230][0] = new Color(131, 79, 13);
			color[234][0] = new Color(53, 44, 41);
			color[235][0] = new Color(214, 184, 46);
			color[236][0] = new Color(149, 232, 87);
			color[237][0] = new Color(255, 241, 51);
			color[238][0] = new Color(225, 128, 206);
			color[243][0] = new Color(198, 196, 170);
			color[248][0] = new Color(219, 71, 38);
			color[249][0] = new Color(235, 38, 231);
			color[250][0] = new Color(86, 85, 92);
			color[251][0] = new Color(235, 150, 23);
			color[252][0] = new Color(153, 131, 44);
			color[253][0] = new Color(57, 48, 97);
			color[254][0] = new Color(248, 158, 92);
			color[255][0] = new Color(107, 49, 154);
			color[256][0] = new Color(154, 148, 49);
			color[257][0] = new Color(49, 49, 154);
			color[258][0] = new Color(49, 154, 68);
			color[259][0] = new Color(154, 49, 77);
			color[260][0] = new Color(85, 89, 118);
			color[261][0] = new Color(154, 83, 49);
			color[262][0] = new Color(221, 79, 255);
			color[263][0] = new Color(250, 255, 79);
			color[264][0] = new Color(79, 102, 255);
			color[265][0] = new Color(79, 255, 89);
			color[266][0] = new Color(255, 79, 79);
			color[267][0] = new Color(240, 240, 247);
			color[268][0] = new Color(255, 145, 79);
			color[287][0] = new Color(79, 128, 17);
			color1 = new Color(122, 217, 232);
			color[275][0] = color1;
			color[276][0] = color1;
			color[277][0] = color1;
			color[278][0] = color1;
			color[279][0] = color1;
			color[280][0] = color1;
			color[281][0] = color1;
			color[282][0] = color1;
			color[285][0] = color1;
			color[286][0] = color1;
			color[288][0] = color1;
			color[289][0] = color1;
			color[290][0] = color1;
			color[291][0] = color1;
			color[292][0] = color1;
			color[293][0] = color1;
			color[294][0] = color1;
			color[295][0] = color1;
			color[296][0] = color1;
			color[297][0] = color1;
			color[298][0] = color1;
			color[299][0] = color1;
			color[309][0] = color1;
			color[310][0] = color1;
			color[413][0] = color1;
			color[339][0] = color1;
			color[358][0] = color1;
			color[359][0] = color1;
			color[360][0] = color1;
			color[361][0] = color1;
			color[362][0] = color1;
			color[363][0] = color1;
			color[364][0] = color1;
			color[391][0] = color1;
			color[392][0] = color1;
			color[393][0] = color1;
			color[394][0] = color1;
			color[414][0] = color1;
			color[408][0] = new Color(85, 83, 82);
			color[409][0] = new Color(85, 83, 82);
			color[415][0] = new Color(249, 75, 7);
			color[416][0] = new Color(0, 160, 170);
			color[417][0] = new Color(160, 87, 234);
			color[418][0] = new Color(22, 173, 254);
			color[311][0] = new Color(117, 61, 25);
			color[312][0] = new Color(204, 93, 73);
			color[313][0] = new Color(87, 150, 154);
			color[4][0] = new Color(253, 221, 3);
			color[4][1] = new Color(253, 221, 3);
			color1 = new Color(253, 221, 3);
			color[93][0] = color1;
			color[33][0] = color1;
			color[174][0] = color1;
			color[100][0] = color1;
			color[98][0] = color1;
			color[173][0] = color1;
			color1 = new Color(119, 105, 79);
			color[11][0] = color1;
			color[10][0] = color1;
			color1 = new Color(191, 142, 111);
			color[14][0] = color1;
			color[15][0] = color1;
			color[18][0] = color1;
			color[19][0] = color1;
			color[55][0] = color1;
			color[79][0] = color1;
			color[86][0] = color1;
			color[87][0] = color1;
			color[88][0] = color1;
			color[89][0] = color1;
			color[94][0] = color1;
			color[101][0] = color1;
			color[104][0] = color1;
			color[106][0] = color1;
			color[114][0] = color1;
			color[128][0] = color1;
			color[139][0] = color1;
			color[172][0] = color1;
			color[216][0] = color1;
			color[269][0] = color1;
			color[334][0] = color1;
			color[377][0] = color1;
			color[380][0] = color1;
			color[395][0] = color1;
			color[12][0] = new Color(174, 24, 69);
			color[13][0] = new Color(133, 213, 247);
			color1 = new Color(144, 148, 144);
			color[17][0] = color1;
			color[90][0] = color1;
			color[96][0] = color1;
			color[97][0] = color1;
			color[99][0] = color1;
			color[132][0] = color1;
			color[142][0] = color1;
			color[143][0] = color1;
			color[144][0] = color1;
			color[207][0] = color1;
			color[209][0] = color1;
			color[212][0] = color1;
			color[217][0] = color1;
			color[218][0] = color1;
			color[219][0] = color1;
			color[220][0] = color1;
			color[228][0] = color1;
			color[300][0] = color1;
			color[301][0] = color1;
			color[302][0] = color1;
			color[303][0] = color1;
			color[304][0] = color1;
			color[305][0] = color1;
			color[306][0] = color1;
			color[307][0] = color1;
			color[308][0] = color1;
			color[349][0] = new Color(144, 148, 144);
			color[105][0] = new Color(144, 148, 144);
			color[105][1] = new Color(177, 92, 31);
			color[105][2] = new Color(201, 188, 170);
			color[137][0] = new Color(144, 148, 144);
			color[137][1] = new Color(141, 56, 0);
			color[16][0] = new Color(140, 130, 116);
			color[26][0] = new Color(119, 101, 125);
			color[26][1] = new Color(214, 127, 133);
			color[36][0] = new Color(230, 89, 92);
			color[28][0] = new Color(151, 79, 80);
			color[28][1] = new Color(90, 139, 140);
			color[28][2] = new Color(192, 136, 70);
			color[28][3] = new Color(203, 185, 151);
			color[28][4] = new Color(73, 56, 41);
			color[28][5] = new Color(148, 159, 67);
			color[28][6] = new Color(138, 172, 67);
			color[28][7] = new Color(226, 122, 47);
			color[28][8] = new Color(198, 87, 93);
			color[29][0] = new Color(175, 105, 128);
			color[51][0] = new Color(192, 202, 203);
			color[31][0] = new Color(141, 120, 168);
			color[31][1] = new Color(212, 105, 105);
			color[32][0] = new Color(151, 135, 183);
			color[42][0] = new Color(251, 235, 127);
			color[50][0] = new Color(170, 48, 114);
			color[85][0] = new Color(192, 192, 192);
			color[69][0] = new Color(190, 150, 92);
			color[77][0] = new Color(238, 85, 70);
			color[81][0] = new Color(245, 133, 191);
			color[78][0] = new Color(121, 110, 97);
			color[141][0] = new Color(192, 59, 59);
			color[129][0] = new Color(255, 117, 224);
			color[126][0] = new Color(159, 209, 229);
			color[125][0] = new Color(141, 175, 255);
			color[103][0] = new Color(141, 98, 77);
			color[95][0] = new Color(255, 162, 31);
			color[92][0] = new Color(213, 229, 237);
			color[91][0] = new Color(13, 88, 130);
			color[215][0] = new Color(254, 121, 2);
			color[316][0] = new Color(157, 176, 226);
			color[317][0] = new Color(118, 227, 129);
			color[318][0] = new Color(227, 118, 215);
			color[319][0] = new Color(96, 68, 48);
			color[320][0] = new Color(203, 185, 151);
			color[321][0] = new Color(96, 77, 64);
			color[322][0] = new Color(198, 170, 104);
			color[149][0] = new Color(220, 50, 50);
			color[149][1] = new Color(0, 220, 50);
			color[149][2] = new Color(50, 50, 220);
			color[133][0] = new Color(231, 53, 56);
			color[133][1] = new Color(192, 189, 221);
			color[134][0] = new Color(166, 187, 153);
			color[134][1] = new Color(241, 129, 249);
			color[102][0] = new Color(229, 212, 73);
			color[49][0] = new Color(89, 201, 255);
			color[35][0] = new Color(226, 145, 30);
			color[34][0] = new Color(235, 166, 135);
			color[136][0] = new Color(213, 203, 204);
			color[231][0] = new Color(224, 194, 101);
			color[239][0] = new Color(224, 194, 101);
			color[240][0] = new Color(120, 85, 60);
			color[240][1] = new Color(99, 50, 30);
			color[240][2] = new Color(153, 153, 117);
			color[240][3] = new Color(112, 84, 56);
			color[240][4] = new Color(234, 231, 226);
			color[241][0] = new Color(77, 74, 72);
			color[244][0] = new Color(200, 245, 253);
			color1 = new Color(99, 50, 30);
			color[242][0] = color1;
			color[245][0] = color1;
			color[246][0] = color1;
			color[242][1] = new Color(185, 142, 97);
			color[247][0] = new Color(140, 150, 150);
			color[271][0] = new Color(107, 250, 255);
			color[270][0] = new Color(187, 255, 107);
			color[314][0] = new Color(181, 164, 125);
			color[324][0] = new Color(228, 213, 173);
			color[351][0] = new Color(31, 31, 31);
			color[21][0] = new Color(174, 129, 92);
			color[21][1] = new Color(233, 207, 94);
			color[21][2] = new Color(137, 128, 200);
			color[21][3] = new Color(160, 160, 160);
			color[21][4] = new Color(106, 210, 255);
			color[27][0] = new Color(54, 154, 54);
			color[27][1] = new Color(226, 196, 49);
			color1 = new Color(246, 197, 26);
			color[82][0] = color1;
			color[83][0] = color1;
			color[84][0] = color1;
			color1 = new Color(76, 150, 216);
			color[82][1] = color1;
			color[83][1] = color1;
			color[84][1] = color1;
			color1 = new Color(185, 214, 42);
			color[82][2] = color1;
			color[83][2] = color1;
			color[84][2] = color1;
			color1 = new Color(167, 203, 37);
			color[82][3] = color1;
			color[83][3] = color1;
			color[84][3] = color1;
			color1 = new Color(72, 145, 125);
			color[82][4] = color1;
			color[83][4] = color1;
			color[84][4] = color1;
			color1 = new Color(177, 69, 49);
			color[82][5] = color1;
			color[83][5] = color1;
			color[84][5] = color1;
			color1 = new Color(40, 152, 240);
			color[82][6] = color1;
			color[83][6] = color1;
			color[84][6] = color1;
			color[165][0] = new Color(115, 173, 229);
			color[165][1] = new Color(100, 100, 100);
			color[165][2] = new Color(152, 152, 152);
			color[165][3] = new Color(227, 125, 22);
			color[178][0] = new Color(208, 94, 201);
			color[178][1] = new Color(233, 146, 69);
			color[178][2] = new Color(71, 146, 251);
			color[178][3] = new Color(60, 226, 133);
			color[178][4] = new Color(250, 30, 71);
			color[178][5] = new Color(166, 176, 204);
			color[178][6] = new Color(255, 217, 120);
			color[184][0] = new Color(29, 106, 88);
			color[184][1] = new Color(94, 100, 36);
			color[184][2] = new Color(96, 44, 40);
			color[184][3] = new Color(34, 63, 102);
			color[184][4] = new Color(79, 35, 95);
			color[184][5] = new Color(253, 62, 3);
			color1 = new Color(99, 99, 99);
			color[185][0] = color1;
			color[186][0] = color1;
			color[187][0] = color1;
			color1 = new Color(114, 81, 56);
			color[185][1] = color1;
			color[186][1] = color1;
			color[187][1] = color1;
			color1 = new Color(133, 133, 101);
			color[185][2] = color1;
			color[186][2] = color1;
			color[187][2] = color1;
			color1 = new Color(151, 200, 211);
			color[185][3] = color1;
			color[186][3] = color1;
			color[187][3] = color1;
			color1 = new Color(177, 183, 161);
			color[185][4] = color1;
			color[186][4] = color1;
			color[187][4] = color1;
			color1 = new Color(134, 114, 38);
			color[185][5] = color1;
			color[186][5] = color1;
			color[187][5] = color1;
			color1 = new Color(82, 62, 66);
			color[185][6] = color1;
			color[186][6] = color1;
			color[187][6] = color1;
			color1 = new Color(143, 117, 121);
			color[185][7] = color1;
			color[186][7] = color1;
			color[187][7] = color1;
			color1 = new Color(177, 92, 31);
			color[185][8] = color1;
			color[186][8] = color1;
			color[187][8] = color1;
			color1 = new Color(85, 73, 87);
			color[185][9] = color1;
			color[186][9] = color1;
			color[187][9] = color1;
			color[227][0] = new Color(74, 197, 155);
			color[227][1] = new Color(54, 153, 88);
			color[227][2] = new Color(63, 126, 207);
			color[227][3] = new Color(240, 180, 4);
			color[227][4] = new Color(45, 68, 168);
			color[227][5] = new Color(61, 92, 0);
			color[227][6] = new Color(216, 112, 152);
			color[227][7] = new Color(200, 40, 24);
			color[227][8] = new Color(113, 45, 133);
			color[227][9] = new Color(235, 137, 2);
			color[227][10] = new Color(41, 152, 135);
			color[227][11] = new Color(198, 19, 78);
			color[373][0] = new Color(9, 61, 191);
			color[374][0] = new Color(253, 32, 3);
			color[375][0] = new Color(255, 156, 12);
			color[323][0] = new Color(182, 141, 86);
			color[325][0] = new Color(129, 125, 93);
			color[326][0] = new Color(9, 61, 191);
			color[327][0] = new Color(253, 32, 3);
			color[330][0] = new Color(226, 118, 76);
			color[331][0] = new Color(161, 172, 173);
			color[332][0] = new Color(204, 181, 72);
			color[333][0] = new Color(190, 190, 178);
			color[335][0] = new Color(217, 174, 137);
			color[336][0] = new Color(253, 62, 3);
			color[337][0] = new Color(144, 148, 144);
			color[338][0] = new Color(85, 255, 160);
			color[315][0] = new Color(235, 114, 80);
			color[340][0] = new Color(96, 248, 2);
			color[341][0] = new Color(105, 74, 202);
			color[342][0] = new Color(29, 240, 255);
			color[343][0] = new Color(254, 202, 80);
			color[344][0] = new Color(131, 252, 245);
			color[345][0] = new Color(255, 156, 12);
			color[346][0] = new Color(149, 212, 89);
			color[347][0] = new Color(236, 74, 79);
			color[348][0] = new Color(44, 26, 233);
			color[350][0] = new Color(55, 97, 155);
			color[352][0] = new Color(238, 97, 94);
			color[354][0] = new Color(141, 107, 89);
			color[355][0] = new Color(141, 107, 89);
			color[356][0] = new Color(233, 203, 24);
			color[357][0] = new Color(168, 178, 204);
			color[367][0] = new Color(168, 178, 204);
			color[365][0] = new Color(146, 136, 205);
			color[366][0] = new Color(223, 232, 233);
			color[368][0] = new Color(50, 46, 104);
			color[369][0] = new Color(50, 46, 104);
			color[370][0] = new Color(127, 116, 194);
			color[372][0] = new Color(252, 128, 201);
			color[371][0] = new Color(249, 101, 189);
			color[376][0] = new Color(160, 120, 92);
			color[378][0] = new Color(160, 120, 100);
			color[379][0] = new Color(251, 209, 240);
			color[382][0] = new Color(28, 216, 94);
			color[383][0] = new Color(221, 136, 144);
			color[384][0] = new Color(131, 206, 12);
			color[385][0] = new Color(87, 21, 144);
			color[386][0] = new Color(127, 92, 69);
			color[387][0] = new Color(127, 92, 69);
			color[388][0] = new Color(127, 92, 69);
			color[389][0] = new Color(127, 92, 69);
			color[390][0] = new Color(253, 32, 3);
			color[397][0] = new Color(212, 192, 100);
			color[396][0] = new Color(198, 124, 78);
			color[398][0] = new Color(100, 82, 126);
			color[399][0] = new Color(77, 76, 66);
			color[400][0] = new Color(96, 68, 117);
			color[401][0] = new Color(68, 60, 51);
			color[402][0] = new Color(174, 168, 186);
			color[403][0] = new Color(205, 152, 186);
			color[404][0] = new Color(140, 84, 60);
			color[405][0] = new Color(140, 140, 140);
			color[406][0] = new Color(120, 120, 120);
			color[407][0] = new Color(255, 227, 132);
			color[411][0] = new Color(227, 46, 46);
			color[410][0] = new Color(75, 139, 166);
			color[412][0] = new Color(75, 139, 166);
			Color[] colorArray = new Color[] { new Color(9, 61, 191), new Color(253, 32, 3), new Color(254, 194, 20) };
			Color[][] colorArray1 = new Color[225][];
			for (int j = 0; j < 225; j++)
			{
				colorArray1[j] = new Color[2];
			}
			colorArray1[158][0] = new Color(107, 49, 154);
			colorArray1[163][0] = new Color(154, 148, 49);
			colorArray1[162][0] = new Color(49, 49, 154);
			colorArray1[160][0] = new Color(49, 154, 68);
			colorArray1[161][0] = new Color(154, 49, 77);
			colorArray1[159][0] = new Color(85, 89, 118);
			colorArray1[157][0] = new Color(154, 83, 49);
			colorArray1[154][0] = new Color(221, 79, 255);
			colorArray1[166][0] = new Color(250, 255, 79);
			colorArray1[165][0] = new Color(79, 102, 255);
			colorArray1[156][0] = new Color(79, 255, 89);
			colorArray1[164][0] = new Color(255, 79, 79);
			colorArray1[155][0] = new Color(240, 240, 247);
			colorArray1[153][0] = new Color(255, 145, 79);
			colorArray1[169][0] = new Color(5, 5, 5);
			colorArray1[224][0] = new Color(57, 55, 52);
			colorArray1[170][0] = new Color(59, 39, 22);
			colorArray1[171][0] = new Color(59, 39, 22);
			color1 = new Color(52, 52, 52);
			colorArray1[1][0] = color1;
			colorArray1[53][0] = color1;
			colorArray1[52][0] = color1;
			colorArray1[51][0] = color1;
			colorArray1[50][0] = color1;
			colorArray1[49][0] = color1;
			colorArray1[48][0] = color1;
			colorArray1[44][0] = color1;
			colorArray1[5][0] = color1;
			color1 = new Color(88, 61, 46);
			colorArray1[2][0] = color1;
			colorArray1[16][0] = color1;
			colorArray1[59][0] = color1;
			colorArray1[3][0] = new Color(61, 58, 78);
			colorArray1[4][0] = new Color(73, 51, 36);
			colorArray1[6][0] = new Color(91, 30, 30);
			color1 = new Color(27, 31, 42);
			colorArray1[7][0] = color1;
			colorArray1[17][0] = color1;
			color1 = new Color(32, 40, 45);
			colorArray1[94][0] = color1;
			colorArray1[100][0] = color1;
			color1 = new Color(44, 41, 50);
			colorArray1[95][0] = color1;
			colorArray1[101][0] = color1;
			color1 = new Color(31, 39, 26);
			colorArray1[8][0] = color1;
			colorArray1[18][0] = color1;
			color1 = new Color(36, 45, 44);
			colorArray1[98][0] = color1;
			colorArray1[104][0] = color1;
			color1 = new Color(38, 49, 50);
			colorArray1[99][0] = color1;
			colorArray1[105][0] = color1;
			color1 = new Color(41, 28, 36);
			colorArray1[9][0] = color1;
			colorArray1[19][0] = color1;
			color1 = new Color(72, 50, 77);
			colorArray1[96][0] = color1;
			colorArray1[102][0] = color1;
			color1 = new Color(78, 50, 69);
			colorArray1[97][0] = color1;
			colorArray1[103][0] = color1;
			colorArray1[10][0] = new Color(74, 62, 12);
			colorArray1[11][0] = new Color(46, 56, 59);
			colorArray1[12][0] = new Color(75, 32, 11);
			colorArray1[13][0] = new Color(67, 37, 37);
			color1 = new Color(15, 15, 15);
			colorArray1[14][0] = color1;
			colorArray1[20][0] = color1;
			colorArray1[15][0] = new Color(52, 43, 45);
			colorArray1[22][0] = new Color(113, 99, 99);
			colorArray1[23][0] = new Color(38, 38, 43);
			colorArray1[24][0] = new Color(53, 39, 41);
			colorArray1[25][0] = new Color(11, 35, 62);
			colorArray1[26][0] = new Color(21, 63, 70);
			colorArray1[27][0] = new Color(88, 61, 46);
			colorArray1[27][1] = new Color(52, 52, 52);
			colorArray1[28][0] = new Color(81, 84, 101);
			colorArray1[29][0] = new Color(88, 23, 23);
			colorArray1[30][0] = new Color(28, 88, 23);
			colorArray1[31][0] = new Color(78, 87, 99);
			color1 = new Color(69, 67, 41);
			colorArray1[34][0] = color1;
			colorArray1[37][0] = color1;
			colorArray1[32][0] = new Color(86, 17, 40);
			colorArray1[33][0] = new Color(49, 47, 83);
			colorArray1[35][0] = new Color(51, 51, 70);
			colorArray1[36][0] = new Color(87, 59, 55);
			colorArray1[38][0] = new Color(49, 57, 49);
			colorArray1[39][0] = new Color(78, 79, 73);
			colorArray1[45][0] = new Color(60, 59, 51);
			colorArray1[46][0] = new Color(48, 57, 47);
			colorArray1[47][0] = new Color(71, 77, 85);
			colorArray1[40][0] = new Color(85, 102, 103);
			colorArray1[41][0] = new Color(52, 50, 62);
			colorArray1[42][0] = new Color(71, 42, 44);
			colorArray1[43][0] = new Color(73, 66, 50);
			colorArray1[54][0] = new Color(40, 56, 50);
			colorArray1[55][0] = new Color(49, 48, 36);
			colorArray1[56][0] = new Color(43, 33, 32);
			colorArray1[57][0] = new Color(31, 40, 49);
			colorArray1[58][0] = new Color(48, 35, 52);
			colorArray1[60][0] = new Color(1, 52, 20);
			colorArray1[61][0] = new Color(55, 39, 26);
			colorArray1[62][0] = new Color(39, 33, 26);
			colorArray1[69][0] = new Color(43, 42, 68);
			colorArray1[70][0] = new Color(30, 70, 80);
			color1 = new Color(30, 80, 48);
			colorArray1[63][0] = color1;
			colorArray1[65][0] = color1;
			colorArray1[66][0] = color1;
			colorArray1[68][0] = color1;
			color1 = new Color(53, 80, 30);
			colorArray1[64][0] = color1;
			colorArray1[67][0] = color1;
			colorArray1[78][0] = new Color(63, 39, 26);
			colorArray1[71][0] = new Color(78, 105, 135);
			colorArray1[72][0] = new Color(52, 84, 12);
			colorArray1[73][0] = new Color(190, 204, 223);
			color1 = new Color(64, 62, 80);
			colorArray1[74][0] = color1;
			colorArray1[80][0] = color1;
			colorArray1[75][0] = new Color(65, 65, 35);
			colorArray1[76][0] = new Color(20, 46, 104);
			colorArray1[77][0] = new Color(61, 13, 16);
			colorArray1[79][0] = new Color(51, 47, 96);
			colorArray1[81][0] = new Color(101, 51, 51);
			colorArray1[82][0] = new Color(77, 64, 34);
			colorArray1[83][0] = new Color(62, 38, 41);
			colorArray1[84][0] = new Color(48, 78, 93);
			colorArray1[85][0] = new Color(54, 63, 69);
			color1 = new Color(138, 73, 38);
			colorArray1[86][0] = color1;
			colorArray1[108][0] = color1;
			color1 = new Color(50, 15, 8);
			colorArray1[87][0] = color1;
			colorArray1[112][0] = color1;
			colorArray1[109][0] = new Color(94, 25, 17);
			colorArray1[110][0] = new Color(125, 36, 122);
			colorArray1[111][0] = new Color(51, 35, 27);
			colorArray1[113][0] = new Color(135, 58, 0);
			colorArray1[114][0] = new Color(65, 52, 15);
			colorArray1[115][0] = new Color(39, 42, 51);
			colorArray1[116][0] = new Color(89, 26, 27);
			colorArray1[117][0] = new Color(126, 123, 115);
			colorArray1[118][0] = new Color(8, 50, 19);
			colorArray1[119][0] = new Color(95, 21, 24);
			colorArray1[120][0] = new Color(17, 31, 65);
			colorArray1[121][0] = new Color(192, 173, 143);
			colorArray1[122][0] = new Color(114, 114, 131);
			colorArray1[123][0] = new Color(136, 119, 7);
			colorArray1[124][0] = new Color(8, 72, 3);
			colorArray1[125][0] = new Color(117, 132, 82);
			colorArray1[126][0] = new Color(100, 102, 114);
			colorArray1[127][0] = new Color(30, 118, 226);
			colorArray1[128][0] = new Color(93, 6, 102);
			colorArray1[129][0] = new Color(64, 40, 169);
			colorArray1[130][0] = new Color(39, 34, 180);
			colorArray1[131][0] = new Color(87, 94, 125);
			colorArray1[132][0] = new Color(6, 6, 6);
			colorArray1[133][0] = new Color(69, 72, 186);
			colorArray1[134][0] = new Color(130, 62, 16);
			colorArray1[135][0] = new Color(22, 123, 163);
			colorArray1[136][0] = new Color(40, 86, 151);
			colorArray1[137][0] = new Color(183, 75, 15);
			colorArray1[138][0] = new Color(83, 80, 100);
			colorArray1[139][0] = new Color(115, 65, 68);
			colorArray1[140][0] = new Color(119, 108, 81);
			colorArray1[141][0] = new Color(59, 67, 71);
			colorArray1[142][0] = new Color(17, 172, 143);
			colorArray1[143][0] = new Color(90, 112, 105);
			colorArray1[144][0] = new Color(62, 28, 87);
			colorArray1[146][0] = new Color(120, 59, 19);
			colorArray1[147][0] = new Color(59, 59, 59);
			colorArray1[148][0] = new Color(229, 218, 161);
			colorArray1[149][0] = new Color(73, 59, 50);
			colorArray1[151][0] = new Color(102, 75, 34);
			colorArray1[167][0] = new Color(70, 68, 51);
			colorArray1[172][0] = new Color(163, 96, 0);
			colorArray1[173][0] = new Color(94, 163, 46);
			colorArray1[174][0] = new Color(117, 32, 59);
			colorArray1[175][0] = new Color(20, 11, 203);
			colorArray1[176][0] = new Color(74, 69, 88);
			colorArray1[177][0] = new Color(60, 30, 30);
			colorArray1[183][0] = new Color(111, 117, 135);
			colorArray1[179][0] = new Color(111, 117, 135);
			colorArray1[178][0] = new Color(111, 117, 135);
			colorArray1[184][0] = new Color(25, 23, 54);
			colorArray1[181][0] = new Color(25, 23, 54);
			colorArray1[180][0] = new Color(25, 23, 54);
			colorArray1[182][0] = new Color(74, 71, 129);
			colorArray1[185][0] = new Color(52, 52, 52);
			colorArray1[186][0] = new Color(38, 9, 66);
			colorArray1[216][0] = new Color(158, 100, 64);
			colorArray1[217][0] = new Color(62, 45, 75);
			colorArray1[218][0] = new Color(57, 14, 12);
			colorArray1[219][0] = new Color(96, 72, 133);
			colorArray1[187][0] = new Color(149, 80, 51);
			colorArray1[220][0] = new Color(67, 55, 80);
			colorArray1[221][0] = new Color(64, 37, 29);
			colorArray1[222][0] = new Color(70, 51, 91);
			colorArray1[188][0] = new Color(82, 63, 80);
			colorArray1[189][0] = new Color(65, 61, 77);
			colorArray1[190][0] = new Color(64, 65, 92);
			colorArray1[191][0] = new Color(76, 53, 84);
			colorArray1[192][0] = new Color(144, 67, 52);
			colorArray1[193][0] = new Color(149, 48, 48);
			colorArray1[194][0] = new Color(111, 32, 36);
			colorArray1[195][0] = new Color(147, 48, 55);
			colorArray1[196][0] = new Color(97, 67, 51);
			colorArray1[197][0] = new Color(112, 80, 62);
			colorArray1[198][0] = new Color(88, 61, 46);
			colorArray1[199][0] = new Color(127, 94, 76);
			colorArray1[200][0] = new Color(143, 50, 123);
			colorArray1[201][0] = new Color(136, 120, 131);
			colorArray1[202][0] = new Color(219, 92, 143);
			colorArray1[203][0] = new Color(113, 64, 150);
			colorArray1[204][0] = new Color(74, 67, 60);
			colorArray1[205][0] = new Color(60, 78, 59);
			colorArray1[206][0] = new Color(0, 54, 21);
			colorArray1[207][0] = new Color(74, 97, 72);
			colorArray1[208][0] = new Color(40, 37, 35);
			colorArray1[209][0] = new Color(77, 63, 66);
			colorArray1[210][0] = new Color(111, 6, 6);
			colorArray1[211][0] = new Color(88, 67, 59);
			colorArray1[212][0] = new Color(88, 87, 80);
			colorArray1[213][0] = new Color(71, 71, 67);
			colorArray1[214][0] = new Color(76, 52, 60);
			colorArray1[215][0] = new Color(89, 48, 59);
			colorArray1[223][0] = new Color(51, 18, 4);
			Color[] color2 = new Color[256];
			Color color3 = new Color(50, 40, 255);
			Color color4 = new Color(145, 185, 255);
			for (int k = 0; k < (int)color2.Length; k++)
			{
				float length = (float)k / (float)((int)color2.Length);
				float single = 1f - length;
				color2[k] = new Color((int)((float)color3.R * single + (float)color4.R * length), (int)((float)color3.G * single + (float)color4.G * length), (int)((float)color3.B * single + (float)color4.B * length));
			}
			Color[] colorArray2 = new Color[256];
			Color color5 = new Color(88, 61, 46);
			Color color6 = new Color(37, 78, 123);
			for (int l = 0; l < (int)colorArray2.Length; l++)
			{
				float single1 = (float)l / 255f;
				float single2 = 1f - single1;
				colorArray2[l] = new Color((int)((float)color5.R * single2 + (float)color6.R * single1), (int)((float)color5.G * single2 + (float)color6.G * single1), (int)((float)color5.B * single2 + (float)color6.B * single1));
			}
			Color[] colorArray3 = new Color[256];
			Color color7 = new Color(74, 67, 60);
			color6 = new Color(53, 70, 97);
			for (int m = 0; m < (int)colorArray3.Length; m++)
			{
				float single3 = (float)m / 255f;
				float single4 = 1f - single3;
				colorArray3[m] = new Color((int)((float)color7.R * single4 + (float)color6.R * single3), (int)((float)color7.G * single4 + (float)color6.G * single3), (int)((float)color7.B * single4 + (float)color6.B * single3));
			}
			Color color8 = new Color(50, 44, 38);
			int num = 0;
			MapHelper.tileOptionCounts = new int[419];
			for (int n = 0; n < 419; n++)
			{
				Color[] colorArray4 = color[n];
				int num1 = 0;
				while (num1 < 12 && !(colorArray4[num1] == Color.Transparent))
				{
					num1++;
				}
				MapHelper.tileOptionCounts[n] = num1;
				num = num + num1;
			}
			MapHelper.wallOptionCounts = new int[225];
			for (int o = 0; o < 225; o++)
			{
				Color[] colorArray5 = colorArray1[o];
				int num2 = 0;
				while (num2 < 2 && !(colorArray5[num2] == Color.Transparent))
				{
					num2++;
				}
				MapHelper.wallOptionCounts[o] = num2;
				num = num + num2;
			}
			num = num + 773;
			MapHelper.colorLookup = new Color[num];
			MapHelper.colorLookup[0] = Color.Transparent;
			ushort num3 = 1;
			MapHelper.tilePosition = num3;
			MapHelper.tileLookup = new ushort[419];
			for (int p = 0; p < 419; p++)
			{
				if (MapHelper.tileOptionCounts[p] <= 0)
				{
					MapHelper.tileLookup[p] = 0;
				}
				else
				{
					Color[] colorArray6 = color[p];
					MapHelper.tileLookup[p] = num3;
					for (int q = 0; q < MapHelper.tileOptionCounts[p]; q++)
					{
						MapHelper.colorLookup[num3] = color[p][q];
						num3 = (ushort)(num3 + 1);
					}
				}
			}
			MapHelper.wallPosition = num3;
			MapHelper.wallLookup = new ushort[225];
			MapHelper.wallRangeStart = num3;
			for (int r = 0; r < 225; r++)
			{
				if (MapHelper.wallOptionCounts[r] <= 0)
				{
					MapHelper.wallLookup[r] = 0;
				}
				else
				{
					Color[] colorArray7 = colorArray1[r];
					MapHelper.wallLookup[r] = num3;
					for (int s = 0; s < MapHelper.wallOptionCounts[r]; s++)
					{
						MapHelper.colorLookup[num3] = colorArray1[r][s];
						num3 = (ushort)(num3 + 1);
					}
				}
			}
			MapHelper.wallRangeEnd = num3;
			MapHelper.liquidPosition = num3;
			for (int t = 0; t < 3; t++)
			{
				MapHelper.colorLookup[num3] = colorArray[t];
				num3 = (ushort)(num3 + 1);
			}
			MapHelper.skyPosition = num3;
			for (int u = 0; u < 256; u++)
			{
				MapHelper.colorLookup[num3] = color2[u];
				num3 = (ushort)(num3 + 1);
			}
			MapHelper.dirtPosition = num3;
			for (int v = 0; v < 256; v++)
			{
				MapHelper.colorLookup[num3] = colorArray2[v];
				num3 = (ushort)(num3 + 1);
			}
			MapHelper.rockPosition = num3;
			for (int w = 0; w < 256; w++)
			{
				MapHelper.colorLookup[num3] = colorArray3[w];
				num3 = (ushort)(num3 + 1);
			}
			MapHelper.hellPosition = num3;
			MapHelper.colorLookup[num3] = color8;
			MapHelper.snowTypes = new ushort[] { MapHelper.tileLookup[147], MapHelper.tileLookup[161], MapHelper.tileLookup[162], MapHelper.tileLookup[163], MapHelper.tileLookup[164], MapHelper.tileLookup[200] };
		}

		public static void LoadMapVersion1(BinaryReader fileIO, int release)
		{
			MapHelper.OldMapHelper oldMapHelper = new MapHelper.OldMapHelper();
			int num;
			int num1;
			string str = fileIO.ReadString();
			int num2 = fileIO.ReadInt32();
			int num3 = fileIO.ReadInt32();
			int num4 = fileIO.ReadInt32();
			if (str != Main.worldName || num2 != Main.worldID || num4 != Main.maxTilesX || num3 != Main.maxTilesY)
			{
				throw new Exception("Map meta-data is invalid.");
			}
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float single = (float)i / (float)Main.maxTilesX;
				object[] objArray = new object[] { Lang.gen[67], " ", (int)(single * 100f + 1f), "%" };
				Main.statusText = string.Concat(objArray);
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					if (!fileIO.ReadBoolean())
					{
						j = j + fileIO.ReadInt16();
					}
					else
					{
						if (release <= 77)
						{
							num = fileIO.ReadByte();
						}
						else
						{
							num = fileIO.ReadUInt16();
						}
						byte num5 = fileIO.ReadByte();
						oldMapHelper.misc = fileIO.ReadByte();
						if (release < 50)
						{
							oldMapHelper.misc2 = 0;
						}
						else
						{
							oldMapHelper.misc2 = fileIO.ReadByte();
						}
						bool flag = false;
						int num6 = oldMapHelper.option();
						if (oldMapHelper.active())
						{
							num1 = num6 + MapHelper.tileLookup[num];
						}
						else if (oldMapHelper.water())
						{
							num1 = MapHelper.liquidPosition;
						}
						else if (oldMapHelper.lava())
						{
							num1 = MapHelper.liquidPosition + 1;
						}
						else if (oldMapHelper.honey())
						{
							num1 = MapHelper.liquidPosition + 2;
						}
						else if (oldMapHelper.wall())
						{
							num1 = num6 + MapHelper.wallLookup[num];
						}
						else if ((double)j < Main.worldSurface)
						{
							flag = true;
							int num7 = (byte)(256 * ((double)j / Main.worldSurface));
							num1 = MapHelper.skyPosition + num7;
						}
						else if ((double)j < Main.rockLayer)
						{
							flag = true;
							if (num > 255)
							{
								num = 255;
							}
							num1 = num + MapHelper.dirtPosition;
						}
						else if (j >= Main.maxTilesY - 200)
						{
							num1 = MapHelper.hellPosition;
						}
						else
						{
							flag = true;
							if (num > 255)
							{
								num = 255;
							}
							num1 = num + MapHelper.rockPosition;
						}
						MapTile mapTile = MapTile.Create((ushort)num1, num5, 0);
						Main.Map.SetTile(i, j, ref mapTile);
						int num8 = fileIO.ReadInt16();
						if (num5 != 255)
						{
							while (num8 > 0)
							{
								j++;
								num8--;
								num5 = fileIO.ReadByte();
								if (num5 <= 18)
								{
									continue;
								}
								mapTile.Light = num5;
								if (flag)
								{
									if ((double)j < Main.worldSurface)
									{
										flag = true;
										int num9 = (byte)(256 * ((double)j / Main.worldSurface));
										num1 = MapHelper.skyPosition + num9;
									}
									else if ((double)j < Main.rockLayer)
									{
										flag = true;
										num1 = num + MapHelper.dirtPosition;
									}
									else if (j >= Main.maxTilesY - 200)
									{
										flag = true;
										num1 = MapHelper.hellPosition;
									}
									else
									{
										flag = true;
										num1 = num + MapHelper.rockPosition;
									}
									mapTile.Type = (ushort)num1;
								}
								Main.Map.SetTile(i, j, ref mapTile);
							}
						}
						else
						{
							while (num8 > 0)
							{
								num8--;
								j++;
								if (flag)
								{
									if ((double)j < Main.worldSurface)
									{
										flag = true;
										int num10 = (byte)(256 * ((double)j / Main.worldSurface));
										num1 = MapHelper.skyPosition + num10;
									}
									else if ((double)j < Main.rockLayer)
									{
										flag = true;
										num1 = num + MapHelper.dirtPosition;
									}
									else if (j >= Main.maxTilesY - 200)
									{
										flag = true;
										num1 = MapHelper.hellPosition;
									}
									else
									{
										flag = true;
										num1 = num + MapHelper.rockPosition;
									}
									mapTile.Type = (ushort)num1;
								}
								Main.Map.SetTile(i, j, ref mapTile);
							}
						}
					}
				}
			}
		}

		public static void LoadMapVersion2(BinaryReader fileIO, int release)
		{
			BinaryReader binaryReader;
			int i;
			byte num;
			ushort num1;
			byte num2;
			bool flag;
			int num3;
			if (release < 135)
			{
				Main.MapFileMetadata = FileMetadata.FromCurrentSettings(FileType.Map);
			}
			else
			{
				Main.MapFileMetadata = FileMetadata.Read(fileIO, FileType.Map);
			}
			string str = fileIO.ReadString();
			int num4 = fileIO.ReadInt32();
			int num5 = fileIO.ReadInt32();
			int num6 = fileIO.ReadInt32();
			if (str != Main.worldName || num4 != Main.worldID || num6 != Main.maxTilesX || num5 != Main.maxTilesY)
			{
				throw new Exception("Map meta-data is invalid.");
			}
			short num7 = fileIO.ReadInt16();
			short num8 = fileIO.ReadInt16();
			short num9 = fileIO.ReadInt16();
			short num10 = fileIO.ReadInt16();
			short num11 = fileIO.ReadInt16();
			short num12 = fileIO.ReadInt16();
			bool[] flagArray = new bool[num7];
			byte num13 = 0;
			byte num14 = 128;
			for (i = 0; i < num7; i++)
			{
				if (num14 != 128)
				{
					num14 = (byte)(num14 << 1);
				}
				else
				{
					num13 = fileIO.ReadByte();
					num14 = 1;
				}
				if ((num13 & num14) == num14)
				{
					flagArray[i] = true;
				}
			}
			bool[] flagArray1 = new bool[num8];
			num13 = 0;
			num14 = 128;
			for (i = 0; i < num8; i++)
			{
				if (num14 != 128)
				{
					num14 = (byte)(num14 << 1);
				}
				else
				{
					num13 = fileIO.ReadByte();
					num14 = 1;
				}
				if ((num13 & num14) == num14)
				{
					flagArray1[i] = true;
				}
			}
			byte[] numArray = new byte[num7];
			ushort num15 = 0;
			for (i = 0; i < num7; i++)
			{
				if (!flagArray[i])
				{
					numArray[i] = 1;
				}
				else
				{
					numArray[i] = fileIO.ReadByte();
				}
				num15 = (ushort)(num15 + numArray[i]);
			}
			byte[] numArray1 = new byte[num8];
			ushort num16 = 0;
			for (i = 0; i < num8; i++)
			{
				if (!flagArray1[i])
				{
					numArray1[i] = 1;
				}
				else
				{
					numArray1[i] = fileIO.ReadByte();
				}
				num16 = (ushort)(num16 + numArray1[i]);
			}
			int num17 = num15 + num16 + num9 + num10 + num11 + num12 + 2;
			ushort[] numArray2 = new ushort[num17];
			numArray2[0] = 0;
			ushort num18 = 1;
			ushort num19 = 1;
			ushort num20 = num19;
			for (i = 0; i < 419; i++)
			{
				if (i >= num7)
				{
					num18 = (ushort)(num18 + (ushort)MapHelper.tileOptionCounts[i]);
				}
				else
				{
					int num21 = numArray[i];
					int num22 = MapHelper.tileOptionCounts[i];
					for (int j = 0; j < num22; j++)
					{
						if (j < num21)
						{
							numArray2[num19] = num18;
							num19 = (ushort)(num19 + 1);
						}
						num18 = (ushort)(num18 + 1);
					}
				}
			}
			ushort num23 = num19;
			for (i = 0; i < 225; i++)
			{
				if (i >= num8)
				{
					num18 = (ushort)(num18 + (ushort)MapHelper.wallOptionCounts[i]);
				}
				else
				{
					int num24 = numArray1[i];
					int num25 = MapHelper.wallOptionCounts[i];
					for (int k = 0; k < num25; k++)
					{
						if (k < num24)
						{
							numArray2[num19] = num18;
							num19 = (ushort)(num19 + 1);
						}
						num18 = (ushort)(num18 + 1);
					}
				}
			}
			ushort num26 = num19;
			for (i = 0; i < 3; i++)
			{
				if (i < num9)
				{
					numArray2[num19] = num18;
					num19 = (ushort)(num19 + 1);
				}
				num18 = (ushort)(num18 + 1);
			}
			ushort num27 = num19;
			for (i = 0; i < 256; i++)
			{
				if (i < num10)
				{
					numArray2[num19] = num18;
					num19 = (ushort)(num19 + 1);
				}
				num18 = (ushort)(num18 + 1);
			}
			ushort num28 = num19;
			for (i = 0; i < 256; i++)
			{
				if (i < num11)
				{
					numArray2[num19] = num18;
					num19 = (ushort)(num19 + 1);
				}
				num18 = (ushort)(num18 + 1);
			}
			ushort num29 = num19;
			for (i = 0; i < 256; i++)
			{
				if (i < num12)
				{
					numArray2[num19] = num18;
					num19 = (ushort)(num19 + 1);
				}
				num18 = (ushort)(num18 + 1);
			}
			ushort num30 = num19;
			numArray2[num19] = num18;
			binaryReader = (release < 93 ? new BinaryReader(fileIO.BaseStream) : new BinaryReader(new DeflateStream(fileIO.BaseStream, CompressionMode.Decompress)));
			for (int l = 0; l < Main.maxTilesY; l++)
			{
				float single = (float)l / (float)Main.maxTilesY;
				object[] objArray = new object[] { Lang.gen[67], " ", (int)(single * 100f + 1f), "%" };
				Main.statusText = string.Concat(objArray);
				for (int m = 0; m < Main.maxTilesX; m++)
				{
					byte num31 = binaryReader.ReadByte();
					if ((num31 & 1) != 1)
					{
						num = 0;
					}
					else
					{
						num = binaryReader.ReadByte();
					}
					byte num32 = (byte)((num31 & 14) >> 1);
					switch (num32)
					{
						case 0:
						{
							flag = false;
							break;
						}
						case 1:
						case 2:
						case 7:
						{
							flag = true;
							break;
						}
						case 3:
						case 4:
						case 5:
						{
							flag = false;
							break;
						}
						case 6:
						{
							flag = false;
							break;
						}
						default:
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						num1 = 0;
					}
					else if ((num31 & 16) != 16)
					{
						num1 = binaryReader.ReadByte();
					}
					else
					{
						num1 = binaryReader.ReadUInt16();
					}
					if ((num31 & 32) != 32)
					{
						num2 = 255;
					}
					else
					{
						num2 = binaryReader.ReadByte();
					}
					switch ((byte)((num31 & 192) >> 6))
					{
						case 0:
						{
							num3 = 0;
							break;
						}
						case 1:
						{
							num3 = binaryReader.ReadByte();
							break;
						}
						case 2:
						{
							num3 = binaryReader.ReadInt16();
							break;
						}
						default:
						{
							num3 = 0;
							break;
						}
					}
					if (num32 != 0)
					{
						switch (num32)
						{
							case 1:
							{
								num1 = (ushort)(num1 + num20);
								break;
							}
							case 2:
							{
								num1 = (ushort)(num1 + num23);
								break;
							}
							case 3:
							case 4:
							case 5:
							{
								num1 = (ushort)(num1 + (ushort)(num26 + (num32 - 3)));
								break;
							}
							case 6:
							{
								if ((double)l >= Main.worldSurface)
								{
									num1 = num30;
									break;
								}
								else
								{
									ushort num33 = (ushort)((double)num10 * ((double)l / Main.worldSurface));
									num1 = (ushort)(num1 + (ushort)(num27 + num33));
									break;
								}
							}
							case 7:
							{
								if ((double)l >= Main.rockLayer)
								{
									num1 = (ushort)(num1 + num29);
									break;
								}
								else
								{
									num1 = (ushort)(num1 + num28);
									break;
								}
							}
						}
						MapTile mapTile = MapTile.Create(numArray2[num1], num2, (byte)(num >> 1 & 31));
						Main.Map.SetTile(m, l, ref mapTile);
						if (num2 != 255)
						{
							while (num3 > 0)
							{
								m++;
								mapTile = mapTile.WithLight(binaryReader.ReadByte());
								Main.Map.SetTile(m, l, ref mapTile);
								num3--;
							}
						}
						else
						{
							while (num3 > 0)
							{
								m++;
								Main.Map.SetTile(m, l, ref mapTile);
								num3--;
							}
						}
					}
					else
					{
						m = m + num3;
					}
				}
			}
			binaryReader.Close();
		}

		public static int LookupCount()
		{
			return (int)MapHelper.colorLookup.Length;
		}

		private static void MapColor(ushort type, ref Color oldColor, byte colorType)
		{
			Color color = WorldGen.paintColor((int)colorType);
			float r = (float)oldColor.R / 255f;
			float g = (float)oldColor.G / 255f;
			float b = (float)oldColor.B / 255f;
			if (g > r)
			{
				float single = r;
				r = g;
				g = single;
			}
			if (b > r)
			{
				float single1 = r;
				r = b;
				b = single1;
			}
			if (colorType == 29)
			{
				float single2 = b * 0.3f;
				oldColor.R = (byte)((float)color.R * single2);
				oldColor.G = (byte)((float)color.G * single2);
				oldColor.B = (byte)((float)color.B * single2);
				return;
			}
			if (colorType != 30)
			{
				float single3 = r;
				oldColor.R = (byte)((float)color.R * single3);
				oldColor.G = (byte)((float)color.G * single3);
				oldColor.B = (byte)((float)color.B * single3);
				return;
			}
			if (type < MapHelper.wallRangeStart || type > MapHelper.wallRangeEnd)
			{
				oldColor.R = (byte)(255 - oldColor.R);
				oldColor.G = (byte)(255 - oldColor.G);
				oldColor.B = (byte)(255 - oldColor.B);
				return;
			}
			oldColor.R = (byte)((float)(255 - oldColor.R) * 0.5f);
			oldColor.G = (byte)((float)(255 - oldColor.G) * 0.5f);
			oldColor.B = (byte)((float)(255 - oldColor.B) * 0.5f);
		}

		public static void SaveMap()
		{
			int i;
			int num;
			int num1;
			ushort type;
			int num2;
			bool isCloudSave = Main.ActivePlayerFileData.IsCloudSave;
			if (isCloudSave && SocialAPI.Cloud == null)
			{
				return;
			}
			if (!Main.mapEnabled || MapHelper.saveLock)
			{
				return;
			}
			string str = Main.playerPathName.Substring(0, Main.playerPathName.Length - 4);
			lock (MapHelper.padlock)
			{
				try
				{
					MapHelper.saveLock = true;
					try
					{
						if (!isCloudSave)
						{
							Directory.CreateDirectory(str);
						}
					}
					catch
					{
					}
					object[] directorySeparatorChar = new object[] { str, Path.DirectorySeparatorChar, Main.worldID, ".map" };
					str = string.Concat(directorySeparatorChar);
					(new Stopwatch()).Start();
					bool flag = false;
					if (!Main.gameMenu)
					{
						flag = true;
					}
					using (MemoryStream memoryStream = new MemoryStream(4000))
					{
						using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
						{
							using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
							{
								int num3 = 0;
								byte[] light = new byte[16384];
								binaryWriter.Write(Main.curRelease);
								Main.MapFileMetadata.IncrementAndWrite(binaryWriter);
								binaryWriter.Write(Main.worldName);
								binaryWriter.Write(Main.worldID);
								binaryWriter.Write(Main.maxTilesY);
								binaryWriter.Write(Main.maxTilesX);
								binaryWriter.Write((short)419);
								binaryWriter.Write((short)225);
								binaryWriter.Write((short)3);
								binaryWriter.Write((short)256);
								binaryWriter.Write((short)256);
								binaryWriter.Write((short)256);
								byte num4 = 1;
								byte num5 = 0;
								for (i = 0; i < 419; i++)
								{
									if (MapHelper.tileOptionCounts[i] != 1)
									{
										num5 = (byte)(num5 | num4);
									}
									if (num4 != 128)
									{
										num4 = (byte)(num4 << 1);
									}
									else
									{
										binaryWriter.Write(num5);
										num5 = 0;
										num4 = 1;
									}
								}
								if (num4 != 1)
								{
									binaryWriter.Write(num5);
								}
								i = 0;
								num4 = 1;
								num5 = 0;
								while (i < 225)
								{
									if (MapHelper.wallOptionCounts[i] != 1)
									{
										num5 = (byte)(num5 | num4);
									}
									if (num4 != 128)
									{
										num4 = (byte)(num4 << 1);
									}
									else
									{
										binaryWriter.Write(num5);
										num5 = 0;
										num4 = 1;
									}
									i++;
								}
								if (num4 != 1)
								{
									binaryWriter.Write(num5);
								}
								for (i = 0; i < 419; i++)
								{
									if (MapHelper.tileOptionCounts[i] != 1)
									{
										binaryWriter.Write((byte)MapHelper.tileOptionCounts[i]);
									}
								}
								for (i = 0; i < 225; i++)
								{
									if (MapHelper.wallOptionCounts[i] != 1)
									{
										binaryWriter.Write((byte)MapHelper.wallOptionCounts[i]);
									}
								}
								binaryWriter.Flush();
								for (int j = 0; j < Main.maxTilesY; j++)
								{
									if (!flag)
									{
										float single = (float)j / (float)Main.maxTilesY;
										object[] objArray = new object[] { Lang.gen[66], " ", (int)(single * 100f + 1f), "%" };
										Main.statusText = string.Concat(objArray);
									}
									for (int k = 0; k < Main.maxTilesX; k++)
									{
										MapTile item = Main.Map[k, j];
										int num6 = 0;
										byte num7 = (byte)num6;
										byte num8 = (byte)num6;
										int num9 = 0;
										bool flag1 = true;
										bool flag2 = true;
										int num10 = 0;
										int num11 = 0;
										byte color = 0;
										if (item.Light > 18)
										{
											color = item.Color;
											type = item.Type;
											if (type < MapHelper.wallPosition)
											{
												num1 = 1;
												type = (ushort)(type - MapHelper.tilePosition);
											}
											else if (type < MapHelper.liquidPosition)
											{
												num1 = 2;
												type = (ushort)(type - MapHelper.wallPosition);
											}
											else if (type < MapHelper.skyPosition)
											{
												num1 = 3 + (type - MapHelper.liquidPosition);
												flag1 = false;
											}
											else if (type < MapHelper.dirtPosition)
											{
												num1 = 6;
												flag2 = false;
												flag1 = false;
											}
											else if (type >= MapHelper.hellPosition)
											{
												num1 = 6;
												flag1 = false;
											}
											else
											{
												num1 = 7;
												type = (type >= MapHelper.rockPosition ? (ushort)(type - MapHelper.rockPosition) : (ushort)(type - MapHelper.dirtPosition));
											}
											if (item.Light == 255)
											{
												flag2 = false;
											}
											if (!flag2)
											{
												num9 = 0;
												num = k + 1;
												num2 = Main.maxTilesX - k - 1;
												while (num2 > 0)
												{
													MapTile mapTile = Main.Map[num, j];
													if (!item.Equals(ref mapTile))
													{
														break;
													}
													num2--;
													num9++;
													num++;
												}
											}
											else
											{
												num9 = 0;
												num = k + 1;
												num2 = Main.maxTilesX - k - 1;
												num10 = num;
												while (num2 > 0)
												{
													MapTile item1 = Main.Map[num, j];
													if (!item.EqualsWithoutLight(ref item1))
													{
														num11 = num;
														goto Label0;
													}
													else
													{
														num2--;
														num9++;
														num++;
													}
												}
											}
										}
										else
										{
											flag2 = false;
											flag1 = false;
											num1 = 0;
											type = 0;
											num9 = 0;
											num = k + 1;
											num2 = Main.maxTilesX - k - 1;
											while (num2 > 0)
											{
												if (Main.Map[num, j].Light > 18)
												{
													goto Label0;
												}
												num9++;
												num2--;
												num++;
											}
										}
									Label0:
										if (color > 0)
										{
											num7 = (byte)(num7 | (byte)(color << 1));
										}
										if (num7 != 0)
										{
											num8 = (byte)(num8 | 1);
										}
										num8 = (byte)(num8 | (byte)(num1 << 1));
										if (flag1 && type > 255)
										{
											num8 = (byte)(num8 | 16);
										}
										if (flag2)
										{
											num8 = (byte)(num8 | 32);
										}
										if (num9 > 0)
										{
											num8 = (num9 <= 255 ? (byte)(num8 | 64) : (byte)(num8 | 128));
										}
										light[num3] = num8;
										num3++;
										if (num7 != 0)
										{
											light[num3] = num7;
											num3++;
										}
										if (flag1)
										{
											light[num3] = (byte)type;
											num3++;
											if (type > 255)
											{
												light[num3] = (byte)(type >> 8);
												num3++;
											}
										}
										if (flag2)
										{
											light[num3] = item.Light;
											num3++;
										}
										if (num9 > 0)
										{
											light[num3] = (byte)num9;
											num3++;
											if (num9 > 255)
											{
												light[num3] = (byte)(num9 >> 8);
												num3++;
											}
										}
										for (int l = num10; l < num11; l++)
										{
											light[num3] = Main.Map[l, j].Light;
											num3++;
										}
										k = k + num9;
										if (num3 >= 4096)
										{
											deflateStream.Write(light, 0, num3);
											num3 = 0;
										}
									}
								}
								if (num3 > 0)
								{
									deflateStream.Write(light, 0, num3);
								}
								deflateStream.Dispose();
								FileUtilities.WriteAllBytes(str, memoryStream.ToArray(), isCloudSave);
							}
						}
					}
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
					{
						streamWriter.WriteLine(DateTime.Now);
						streamWriter.WriteLine(exception);
						streamWriter.WriteLine("");
					}
				}
				MapHelper.saveLock = false;
			}
		}

		public static int TileToLookup(int tileType, int option)
		{
			return MapHelper.tileLookup[tileType] + option;
		}

		private struct OldMapHelper
		{
			public byte misc;

			public byte misc2;

			public bool active()
			{
				if ((this.misc & 1) == 1)
				{
					return true;
				}
				return false;
			}

			public bool changed()
			{
				if ((this.misc & 8) == 8)
				{
					return true;
				}
				return false;
			}

			public byte color()
			{
				return (byte)((this.misc2 & 30) >> 1);
			}

			public bool honey()
			{
				if ((this.misc2 & 64) == 64)
				{
					return true;
				}
				return false;
			}

			public bool lava()
			{
				if ((this.misc & 4) == 4)
				{
					return true;
				}
				return false;
			}

			public byte option()
			{
				byte num = 0;
				if ((this.misc & 32) == 32)
				{
					num = (byte)(num + 1);
				}
				if ((this.misc & 64) == 64)
				{
					num = (byte)(num + 2);
				}
				if ((this.misc & 128) == 128)
				{
					num = (byte)(num + 4);
				}
				if ((this.misc2 & 1) == 1)
				{
					num = (byte)(num + 8);
				}
				return num;
			}

			public bool wall()
			{
				if ((this.misc & 16) == 16)
				{
					return true;
				}
				return false;
			}

			public bool water()
			{
				if ((this.misc & 2) == 2)
				{
					return true;
				}
				return false;
			}
		}
	}
}