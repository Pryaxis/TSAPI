using System;
using System.Collections.Generic;
using Terraria.GameContent.NetModules;
using Terraria.Net;
using Terraria.ObjectData;

namespace Terraria
{
	public class Liquid
	{
		public static int skipCount;

		public static int stuckCount;

		public static int stuckAmount;

		public static int cycles;

		public static int resLiquid;

		public static int maxLiquid;

		public static int numLiquid;

		public static bool stuck;

		public static bool quickFall;

		public static bool quickSettle;

		private static int wetCounter;

		public static int panicCounter;

		public static bool panicMode;

		public static int panicY;

		public int x;

		public int y;

		public int kill;

		public int delay;

		private static HashSet<int> _netChangeSet;

		private static HashSet<int> _swapNetChangeSet;

		static Liquid()
		{
			Liquid.skipCount = 0;
			Liquid.stuckCount = 0;
			Liquid.stuckAmount = 0;
			Liquid.cycles = 10;
			Liquid.resLiquid = 5000;
			Liquid.maxLiquid = 5000;
			Liquid.stuck = false;
			Liquid.quickFall = false;
			Liquid.quickSettle = false;
			Liquid.panicCounter = 0;
			Liquid.panicMode = false;
			Liquid.panicY = 0;
			Liquid._netChangeSet = new HashSet<int>();
			Liquid._swapNetChangeSet = new HashSet<int>();
		}

		public Liquid()
		{
		}

		public static void AddWater(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (Main.tile[x, y] == null)
			{
				return;
			}
			if (tile.checkingLiquid())
			{
				return;
			}
			if (x >= Main.maxTilesX - 5 || y >= Main.maxTilesY - 5)
			{
				return;
			}
			if (x < 5 || y < 5)
			{
				return;
			}
			if (tile.liquid == 0)
			{
				return;
			}
			if (Liquid.numLiquid >= Liquid.maxLiquid - 1)
			{
				LiquidBuffer.AddBuffer(x, y);
				return;
			}
			tile.checkingLiquid(true);
			Main.liquid[Liquid.numLiquid].kill = 0;
			Main.liquid[Liquid.numLiquid].x = x;
			Main.liquid[Liquid.numLiquid].y = y;
			Main.liquid[Liquid.numLiquid].delay = 0;
			tile.skipLiquid(false);
			Liquid.numLiquid = Liquid.numLiquid + 1;
			if (Main.netMode == 2)
			{
				Liquid.NetSendLiquid(x, y);
			}
			if (tile.active() && !WorldGen.gen)
			{
				bool flag = false;
				if (tile.lava())
				{
					if (TileObjectData.CheckLavaDeath(tile))
					{
						flag = true;
					}
				}
				else if (TileObjectData.CheckWaterDeath(tile))
				{
					flag = true;
				}
				if (flag)
				{
					WorldGen.KillTile(x, y, false, false, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
					}
				}
			}
		}

		public static void DelWater(int l)
		{
			int num = Main.liquid[l].x;
			int num1 = Main.liquid[l].y;
			Tile tile = Main.tile[num - 1, num1];
			Tile tile1 = Main.tile[num + 1, num1];
			Tile tile2 = Main.tile[num, num1 + 1];
			Tile tile3 = Main.tile[num, num1];
			byte num2 = 2;
			if (tile3.liquid < num2)
			{
				tile3.liquid = 0;
				if (tile.liquid >= num2)
				{
					Liquid.AddWater(num - 1, num1);
				}
				else
				{
					tile.liquid = 0;
				}
				if (tile1.liquid >= num2)
				{
					Liquid.AddWater(num + 1, num1);
				}
				else
				{
					tile1.liquid = 0;
				}
			}
			else if (tile3.liquid < 20)
			{
				if (tile.liquid < tile3.liquid && (!tile.nactive() || !Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type]) || tile1.liquid < tile3.liquid && (!tile1.nactive() || !Main.tileSolid[tile1.type] || Main.tileSolidTop[tile1.type]) || tile2.liquid < 255 && (!tile2.nactive() || !Main.tileSolid[tile2.type] || Main.tileSolidTop[tile2.type]))
				{
					tile3.liquid = 0;
				}
			}
			else if (tile2.liquid < 255 && (!tile2.nactive() || !Main.tileSolid[tile2.type] || Main.tileSolidTop[tile2.type]) && !Liquid.stuck)
			{
				Main.liquid[l].kill = 0;
				return;
			}
			if (tile3.liquid < 250 && Main.tile[num, num1 - 1].liquid > 0)
			{
				Liquid.AddWater(num, num1 - 1);
			}
			if (tile3.liquid != 0)
			{
				if (tile1.liquid > 0 && Main.tile[num + 1, num1 + 1].liquid < 250 && !Main.tile[num + 1, num1 + 1].active() || tile.liquid > 0 && Main.tile[num - 1, num1 + 1].liquid < 250 && !Main.tile[num - 1, num1 + 1].active())
				{
					Liquid.AddWater(num - 1, num1);
					Liquid.AddWater(num + 1, num1);
				}
				if (tile3.lava())
				{
					Liquid.LavaCheck(num, num1);
					for (int i = num - 1; i <= num + 1; i++)
					{
						for (int j = num1 - 1; j <= num1 + 1; j++)
						{
							Tile tile4 = Main.tile[i, j];
							if (tile4.active())
							{
								if (tile4.type == 2 || tile4.type == 23 || tile4.type == 109 || tile4.type == 199)
								{
									tile4.type = 0;
									WorldGen.SquareTileFrame(i, j, true);
									if (Main.netMode == 2)
									{
										NetMessage.SendTileSquare(-1, num, num1, 3);
									}
								}
								else if (tile4.type == 60 || tile4.type == 70)
								{
									tile4.type = 59;
									WorldGen.SquareTileFrame(i, j, true);
									if (Main.netMode == 2)
									{
										NetMessage.SendTileSquare(-1, num, num1, 3);
									}
								}
							}
						}
					}
				}
				else if (tile3.honey())
				{
					Liquid.HoneyCheck(num, num1);
				}
			}
			else
			{
				tile3.liquidType(0);
			}
			if (Main.netMode == 2)
			{
				Liquid.NetSendLiquid(num, num1);
			}
			Liquid.numLiquid = Liquid.numLiquid - 1;
			Main.tile[Main.liquid[l].x, Main.liquid[l].y].checkingLiquid(false);
			Main.liquid[l].x = Main.liquid[Liquid.numLiquid].x;
			Main.liquid[l].y = Main.liquid[Liquid.numLiquid].y;
			Main.liquid[l].kill = Main.liquid[Liquid.numLiquid].kill;
			if (Main.tileAlch[tile3.type])
			{
				WorldGen.CheckAlch(num, num1);
			}
		}

		public static void HoneyCheck(int x, int y)
		{
			Tile tile = Main.tile[x - 1, y];
			Tile tile1 = Main.tile[x + 1, y];
			Tile tile2 = Main.tile[x, y - 1];
			Tile tile3 = Main.tile[x, y + 1];
			Tile tile4 = Main.tile[x, y];
			if (tile.liquid > 0 && tile.liquidType() == 0 || tile1.liquid > 0 && tile1.liquidType() == 0 || tile2.liquid > 0 && tile2.liquidType() == 0)
			{
				int num = 0;
				if (tile.liquidType() == 0)
				{
					num = num + tile.liquid;
					tile.liquid = 0;
				}
				if (tile1.liquidType() == 0)
				{
					num = num + tile1.liquid;
					tile1.liquid = 0;
				}
				if (tile2.liquidType() == 0)
				{
					num = num + tile2.liquid;
					tile2.liquid = 0;
				}
				if (num >= 32)
				{
					if (tile4.active() && Main.tileObsidianKill[tile4.type])
					{
						WorldGen.KillTile(x, y, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
						}
					}
					if (!tile4.active())
					{
						tile4.liquid = 0;
						tile4.liquidType(0);
						WorldGen.PlaceTile(x, y, 229, true, true, -1, 0);
						WorldGen.SquareTileFrame(x, y, true);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileSquare(-1, x - 1, y - 1, 3);
							return;
						}
					}
				}
			}
			else if (tile3.liquid > 0 && tile3.liquidType() == 0)
			{
				if (Main.tileCut[tile3.type])
				{
					WorldGen.KillTile(x, y + 1, false, false, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)(y + 1), 0f, 0, 0, 0);
					}
				}
				else if (tile3.active() && Main.tileObsidianKill[tile3.type])
				{
					WorldGen.KillTile(x, y + 1, false, false, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)(y + 1), 0f, 0, 0, 0);
					}
				}
				if (!tile3.active())
				{
					if (tile4.liquid >= 32)
					{
						tile4.liquid = 0;
						tile4.liquidType(0);
						tile3.liquid = 0;
						tile3.liquidType(0);
						WorldGen.PlaceTile(x, y + 1, 229, true, true, -1, 0);
						WorldGen.SquareTileFrame(x, y + 1, true);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileSquare(-1, x - 1, y, 3);
						}
					}
					else
					{
						tile4.liquid = 0;
						tile4.liquidType(0);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileSquare(-1, x - 1, y, 3);
							return;
						}
					}
				}
			}
		}

		public static void LavaCheck(int x, int y)
		{
			Tile tile = Main.tile[x - 1, y];
			Tile tile1 = Main.tile[x + 1, y];
			Tile tile2 = Main.tile[x, y - 1];
			Tile tile3 = Main.tile[x, y + 1];
			Tile tile4 = Main.tile[x, y];
			if (tile.liquid > 0 && !tile.lava() || tile1.liquid > 0 && !tile1.lava() || tile2.liquid > 0 && !tile2.lava())
			{
				int num = 0;
				int num1 = 56;
				if (!tile.lava())
				{
					num = num + tile.liquid;
					tile.liquid = 0;
				}
				if (!tile1.lava())
				{
					num = num + tile1.liquid;
					tile1.liquid = 0;
				}
				if (!tile2.lava())
				{
					num = num + tile2.liquid;
					tile2.liquid = 0;
				}
				if (tile.honey() || tile1.honey() || tile2.honey())
				{
					num1 = 230;
				}
				if (num >= 24)
				{
					if (tile4.active() && Main.tileObsidianKill[tile4.type])
					{
						WorldGen.KillTile(x, y, false, false, false);
						if (Main.netMode == 2)
						{
							NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)y, 0f, 0, 0, 0);
						}
					}
					if (!tile4.active())
					{
						tile4.liquid = 0;
						tile4.lava(false);
						WorldGen.PlaceTile(x, y, num1, true, true, -1, 0);
						WorldGen.SquareTileFrame(x, y, true);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileSquare(-1, x - 1, y - 1, 3);
							return;
						}
					}
				}
			}
			else if (tile3.liquid > 0 && !tile3.lava())
			{
				if (Main.tileCut[tile3.type])
				{
					WorldGen.KillTile(x, y + 1, false, false, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)(y + 1), 0f, 0, 0, 0);
					}
				}
				else if (tile3.active() && Main.tileObsidianKill[tile3.type])
				{
					WorldGen.KillTile(x, y + 1, false, false, false);
					if (Main.netMode == 2)
					{
						NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)x, (float)(y + 1), 0f, 0, 0, 0);
					}
				}
				if (!tile3.active())
				{
					if (tile4.liquid >= 24)
					{
						int num2 = 56;
						if (tile3.honey())
						{
							num2 = 230;
						}
						tile4.liquid = 0;
						tile4.lava(false);
						tile3.liquid = 0;
						WorldGen.PlaceTile(x, y + 1, num2, true, true, -1, 0);
						WorldGen.SquareTileFrame(x, y + 1, true);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileSquare(-1, x - 1, y, 3);
						}
					}
					else
					{
						tile4.liquid = 0;
						tile4.liquidType(0);
						if (Main.netMode == 2)
						{
							NetMessage.SendTileSquare(-1, x - 1, y, 3);
							return;
						}
					}
				}
			}
		}

		public static void NetSendLiquid(int x, int y)
		{
			lock (Liquid._netChangeSet)
			{
				Liquid._netChangeSet.Add((x & 65535) << 16 | y & 65535);
			}
		}

		public static double QuickWater(int verbose = 0, int minY = -1, int maxY = -1)
		{
			Main.tileSolid[379] = true;
			int num = 0;
			if (minY == -1)
			{
				minY = 3;
			}
			if (maxY == -1)
			{
				maxY = Main.maxTilesY - 3;
			}
			for (int i = maxY; i >= minY; i--)
			{
				if (verbose > 0)
				{
					float single = (float)(maxY - i) / (float)(maxY - minY + 1);
					single = single / (float)verbose;
					object[] objArray = new object[] { Lang.gen[27], " ", (int)(single * 100f + 1f), "%" };
					Main.statusText = string.Concat(objArray);
				}
				else if (verbose < 0)
				{
					float single1 = (float)(maxY - i) / (float)(maxY - minY + 1);
					single1 = single1 / (float)(-verbose);
					object[] objArray1 = new object[] { Lang.gen[18], " ", (int)(single1 * 100f + 1f), "%" };
					Main.statusText = string.Concat(objArray1);
				}
				for (int j = 0; j < 2; j++)
				{
					int num1 = 2;
					int num2 = Main.maxTilesX - 2;
					int num3 = 1;
					if (j == 1)
					{
						num1 = Main.maxTilesX - 2;
						num2 = 2;
						num3 = -1;
					}
					for (int k = num1; k != num2; k = k + num3)
					{
						Tile tile = Main.tile[k, i];
						if (tile.liquid > 0)
						{
							int num4 = -num3;
							bool flag = false;
							int num5 = k;
							int num6 = i;
							byte num7 = tile.liquidType();
							bool flag1 = tile.lava();
							bool flag2 = tile.honey();
							byte num8 = tile.liquid;
							tile.liquid = 0;
							bool flag3 = true;
							int num9 = 0;
							while (flag3 && num5 > 3 && num5 < Main.maxTilesX - 3 && num6 < Main.maxTilesY - 3)
							{
								flag3 = false;
								while (Main.tile[num5, num6 + 1].liquid == 0 && num6 < Main.maxTilesY - 5 && (!Main.tile[num5, num6 + 1].nactive() || !Main.tileSolid[Main.tile[num5, num6 + 1].type] || Main.tileSolidTop[Main.tile[num5, num6 + 1].type]))
								{
									flag = true;
									num4 = num3;
									num9 = 0;
									flag3 = true;
									num6++;
									if (num6 <= WorldGen.waterLine || !WorldGen.gen || flag2)
									{
										continue;
									}
									num7 = 1;
								}
								if (Main.tile[num5, num6 + 1].liquid > 0 && Main.tile[num5, num6 + 1].liquid < 255 && Main.tile[num5, num6 + 1].liquidType() == num7)
								{
									int num10 = 255 - Main.tile[num5, num6 + 1].liquid;
									if (num10 > num8)
									{
										num10 = num8;
									}
									Tile tile1 = Main.tile[num5, num6 + 1];
									tile1.liquid = (byte)(tile1.liquid + (byte)num10);
									num8 = (byte)(num8 - (byte)num10);
									if (num8 <= 0)
									{
										num++;
										break;
									}
								}
								if (num9 == 0)
								{
									if (Main.tile[num5 + num4, num6].liquid == 0 && (!Main.tile[num5 + num4, num6].nactive() || !Main.tileSolid[Main.tile[num5 + num4, num6].type] || Main.tileSolidTop[Main.tile[num5 + num4, num6].type]))
									{
										num9 = num4;
									}
									else if (Main.tile[num5 - num4, num6].liquid == 0 && (!Main.tile[num5 - num4, num6].nactive() || !Main.tileSolid[Main.tile[num5 - num4, num6].type] || Main.tileSolidTop[Main.tile[num5 - num4, num6].type]))
									{
										num9 = -num4;
									}
								}
								if (num9 != 0 && Main.tile[num5 + num9, num6].liquid == 0 && (!Main.tile[num5 + num9, num6].nactive() || !Main.tileSolid[Main.tile[num5 + num9, num6].type] || Main.tileSolidTop[Main.tile[num5 + num9, num6].type]))
								{
									flag3 = true;
									num5 = num5 + num9;
								}
								if (!flag || flag3)
								{
									continue;
								}
								flag = false;
								flag3 = true;
								num4 = -num3;
								num9 = 0;
							}
							if (k != num5 && i != num6)
							{
								num++;
							}
							Main.tile[num5, num6].liquid = num8;
							Main.tile[num5, num6].liquidType((int)num7);
							if (Main.tile[num5 - 1, num6].liquid > 0 && Main.tile[num5 - 1, num6].lava() != flag1)
							{
								if (!flag1)
								{
									Liquid.LavaCheck(num5 - 1, num6);
								}
								else
								{
									Liquid.LavaCheck(num5, num6);
								}
							}
							else if (Main.tile[num5 + 1, num6].liquid > 0 && Main.tile[num5 + 1, num6].lava() != flag1)
							{
								if (!flag1)
								{
									Liquid.LavaCheck(num5 + 1, num6);
								}
								else
								{
									Liquid.LavaCheck(num5, num6);
								}
							}
							else if (Main.tile[num5, num6 - 1].liquid > 0 && Main.tile[num5, num6 - 1].lava() != flag1)
							{
								if (!flag1)
								{
									Liquid.LavaCheck(num5, num6 - 1);
								}
								else
								{
									Liquid.LavaCheck(num5, num6);
								}
							}
							else if (Main.tile[num5, num6 + 1].liquid > 0 && Main.tile[num5, num6 + 1].lava() != flag1)
							{
								if (!flag1)
								{
									Liquid.LavaCheck(num5, num6 + 1);
								}
								else
								{
									Liquid.LavaCheck(num5, num6);
								}
							}
							if (Main.tile[num5, num6].liquid > 0)
							{
								if (Main.tile[num5 - 1, num6].liquid > 0 && Main.tile[num5 - 1, num6].honey() != flag2)
								{
									if (!flag2)
									{
										Liquid.HoneyCheck(num5 - 1, num6);
									}
									else
									{
										Liquid.HoneyCheck(num5, num6);
									}
								}
								else if (Main.tile[num5 + 1, num6].liquid > 0 && Main.tile[num5 + 1, num6].honey() != flag2)
								{
									if (!flag2)
									{
										Liquid.HoneyCheck(num5 + 1, num6);
									}
									else
									{
										Liquid.HoneyCheck(num5, num6);
									}
								}
								else if (Main.tile[num5, num6 - 1].liquid > 0 && Main.tile[num5, num6 - 1].honey() != flag2)
								{
									if (!flag2)
									{
										Liquid.HoneyCheck(num5, num6 - 1);
									}
									else
									{
										Liquid.HoneyCheck(num5, num6);
									}
								}
								else if (Main.tile[num5, num6 + 1].liquid > 0 && Main.tile[num5, num6 + 1].honey() != flag2)
								{
									if (!flag2)
									{
										Liquid.HoneyCheck(num5, num6 + 1);
									}
									else
									{
										Liquid.HoneyCheck(num5, num6);
									}
								}
							}
						}
					}
				}
			}
			return (double)num;
		}

		public static void StartPanic()
		{
			if (!Liquid.panicMode)
			{
				WorldGen.waterLine = Main.maxTilesY;
				Liquid.numLiquid = 0;
				LiquidBuffer.numLiquidBuffer = 0;
				Liquid.panicCounter = 0;
				Liquid.panicMode = true;
				Liquid.panicY = Main.maxTilesY - 3;
				if (Main.dedServ)
				{
					Console.WriteLine("Forcing water to settle.");
				}
			}
		}

		public void Update()
		{
			Main.tileSolid[379] = true;
			Tile tile = Main.tile[this.x - 1, this.y];
			Tile tile1 = Main.tile[this.x + 1, this.y];
			Tile tile2 = Main.tile[this.x, this.y - 1];
			Tile tile3 = Main.tile[this.x, this.y + 1];
			Tile tile4 = Main.tile[this.x, this.y];
			if (tile4.nactive() && Main.tileSolid[tile4.type] && !Main.tileSolidTop[tile4.type])
			{
				ushort num = tile4.type;
				this.kill = 9;
				return;
			}
			byte num1 = tile4.liquid;
			float single = 0f;
			if (this.y > Main.maxTilesY - 200 && tile4.liquidType() == 0 && tile4.liquid > 0)
			{
				byte num2 = 2;
				if (tile4.liquid < num2)
				{
					num2 = tile4.liquid;
				}
				Tile tile5 = tile4;
				tile5.liquid = (byte)(tile5.liquid - num2);
			}
			if (tile4.liquid == 0)
			{
				this.kill = 9;
				return;
			}
			if (!tile4.lava())
			{
				if (tile.lava())
				{
					Liquid.AddWater(this.x - 1, this.y);
				}
				if (tile1.lava())
				{
					Liquid.AddWater(this.x + 1, this.y);
				}
				if (tile2.lava())
				{
					Liquid.AddWater(this.x, this.y - 1);
				}
				if (tile3.lava())
				{
					Liquid.AddWater(this.x, this.y + 1);
				}
				if (!tile4.honey())
				{
					if (tile.honey())
					{
						Liquid.AddWater(this.x - 1, this.y);
					}
					if (tile1.honey())
					{
						Liquid.AddWater(this.x + 1, this.y);
					}
					if (tile2.honey())
					{
						Liquid.AddWater(this.x, this.y - 1);
					}
					if (tile3.honey())
					{
						Liquid.AddWater(this.x, this.y + 1);
					}
				}
				else
				{
					Liquid.HoneyCheck(this.x, this.y);
					if (!Liquid.quickFall)
					{
						if (this.delay < 10)
						{
							Liquid liquid = this;
							liquid.delay = liquid.delay + 1;
							return;
						}
						this.delay = 0;
					}
				}
			}
			else
			{
				Liquid.LavaCheck(this.x, this.y);
				if (!Liquid.quickFall)
				{
					if (this.delay < 5)
					{
						Liquid liquid1 = this;
						liquid1.delay = liquid1.delay + 1;
						return;
					}
					this.delay = 0;
				}
			}
			if ((!tile3.nactive() || !Main.tileSolid[tile3.type] || Main.tileSolidTop[tile3.type]) && (tile3.liquid <= 0 || tile3.liquidType() == tile4.liquidType()) && tile3.liquid < 255)
			{
				single = (float)(255 - tile3.liquid);
				if (single > (float)tile4.liquid)
				{
					single = (float)tile4.liquid;
				}
				Tile tile6 = tile4;
				tile6.liquid = (byte)(tile6.liquid - (byte)single);
				Tile tile7 = tile3;
				tile7.liquid = (byte)(tile7.liquid + (byte)single);
				tile3.liquidType((int)tile4.liquidType());
				Liquid.AddWater(this.x, this.y + 1);
				tile3.skipLiquid(true);
				tile4.skipLiquid(true);
				if (tile4.liquid <= 250)
				{
					Liquid.AddWater(this.x - 1, this.y);
					Liquid.AddWater(this.x + 1, this.y);
				}
				else
				{
					tile4.liquid = 255;
				}
			}
			if (tile4.liquid > 0)
			{
				bool flag = true;
				bool flag1 = true;
				bool flag2 = true;
				bool flag3 = true;
				if (tile.nactive() && Main.tileSolid[tile.type] && !Main.tileSolidTop[tile.type])
				{
					flag = false;
				}
				else if (tile.liquid > 0 && tile.liquidType() != tile4.liquidType())
				{
					flag = false;
				}
				else if (Main.tile[this.x - 2, this.y].nactive() && Main.tileSolid[Main.tile[this.x - 2, this.y].type] && !Main.tileSolidTop[Main.tile[this.x - 2, this.y].type])
				{
					flag2 = false;
				}
				else if (Main.tile[this.x - 2, this.y].liquid == 0)
				{
					flag2 = false;
				}
				else if (Main.tile[this.x - 2, this.y].liquid > 0 && Main.tile[this.x - 2, this.y].liquidType() != tile4.liquidType())
				{
					flag2 = false;
				}
				if (tile1.nactive() && Main.tileSolid[tile1.type] && !Main.tileSolidTop[tile1.type])
				{
					flag1 = false;
				}
				else if (tile1.liquid > 0 && tile1.liquidType() != tile4.liquidType())
				{
					flag1 = false;
				}
				else if (Main.tile[this.x + 2, this.y].nactive() && Main.tileSolid[Main.tile[this.x + 2, this.y].type] && !Main.tileSolidTop[Main.tile[this.x + 2, this.y].type])
				{
					flag3 = false;
				}
				else if (Main.tile[this.x + 2, this.y].liquid == 0)
				{
					flag3 = false;
				}
				else if (Main.tile[this.x + 2, this.y].liquid > 0 && Main.tile[this.x + 2, this.y].liquidType() != tile4.liquidType())
				{
					flag3 = false;
				}
				int num3 = 0;
				if (tile4.liquid < 3)
				{
					num3 = -1;
				}
				if (!flag || !flag1)
				{
					if (flag)
					{
						single = (float)(tile.liquid + tile4.liquid + num3);
						single = (float)Math.Round((double)(single / 2f) + 0.001);
						if (tile.liquid != (byte)single)
						{
							tile.liquid = (byte)single;
						}
						tile.liquidType((int)tile4.liquidType());
						if (tile4.liquid != (byte)single || tile.liquid != (byte)single)
						{
							Liquid.AddWater(this.x - 1, this.y);
						}
						tile4.liquid = (byte)single;
					}
					else if (flag1)
					{
						single = (float)(tile1.liquid + tile4.liquid + num3);
						single = (float)Math.Round((double)(single / 2f) + 0.001);
						if (tile1.liquid != (byte)single)
						{
							tile1.liquid = (byte)single;
						}
						tile1.liquidType((int)tile4.liquidType());
						if (tile4.liquid != (byte)single || tile1.liquid != (byte)single)
						{
							Liquid.AddWater(this.x + 1, this.y);
						}
						tile4.liquid = (byte)single;
					}
				}
				else if (flag2 && flag3)
				{
					bool flag4 = true;
					bool flag5 = true;
					if (Main.tile[this.x - 3, this.y].nactive() && Main.tileSolid[Main.tile[this.x - 3, this.y].type] && !Main.tileSolidTop[Main.tile[this.x - 3, this.y].type])
					{
						flag4 = false;
					}
					else if (Main.tile[this.x - 3, this.y].liquid == 0)
					{
						flag4 = false;
					}
					else if (Main.tile[this.x - 3, this.y].liquidType() != tile4.liquidType())
					{
						flag4 = false;
					}
					if (Main.tile[this.x + 3, this.y].nactive() && Main.tileSolid[Main.tile[this.x + 3, this.y].type] && !Main.tileSolidTop[Main.tile[this.x + 3, this.y].type])
					{
						flag5 = false;
					}
					else if (Main.tile[this.x + 3, this.y].liquid == 0)
					{
						flag5 = false;
					}
					else if (Main.tile[this.x + 3, this.y].liquidType() != tile4.liquidType())
					{
						flag5 = false;
					}
					if (!flag4 || !flag5)
					{
						int num4 = 0;
						single = (float)(tile.liquid + tile1.liquid + Main.tile[this.x - 2, this.y].liquid + Main.tile[this.x + 2, this.y].liquid + tile4.liquid + num3);
						single = (float)Math.Round((double)(single / 5f));
						tile.liquidType((int)tile4.liquidType());
						if (tile.liquid == (byte)single)
						{
							num4++;
						}
						else
						{
							tile.liquid = (byte)single;
							Liquid.AddWater(this.x - 1, this.y);
						}
						tile1.liquidType((int)tile4.liquidType());
						if (tile1.liquid == (byte)single)
						{
							num4++;
						}
						else
						{
							tile1.liquid = (byte)single;
							Liquid.AddWater(this.x + 1, this.y);
						}
						Main.tile[this.x - 2, this.y].liquidType((int)tile4.liquidType());
						if (Main.tile[this.x - 2, this.y].liquid == (byte)single)
						{
							num4++;
						}
						else
						{
							Main.tile[this.x - 2, this.y].liquid = (byte)single;
							Liquid.AddWater(this.x - 2, this.y);
						}
						Main.tile[this.x + 2, this.y].liquidType((int)tile4.liquidType());
						if (Main.tile[this.x + 2, this.y].liquid == (byte)single)
						{
							num4++;
						}
						else
						{
							Main.tile[this.x + 2, this.y].liquid = (byte)single;
							Liquid.AddWater(this.x + 2, this.y);
						}
						if (tile.liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x - 1, this.y);
						}
						if (tile1.liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x + 1, this.y);
						}
						if (Main.tile[this.x - 2, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x - 2, this.y);
						}
						if (Main.tile[this.x + 2, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x + 2, this.y);
						}
						if (num4 != 4 || tile2.liquid <= 0)
						{
							tile4.liquid = (byte)single;
						}
					}
					else
					{
						single = (float)(tile.liquid + tile1.liquid + Main.tile[this.x - 2, this.y].liquid + Main.tile[this.x + 2, this.y].liquid + Main.tile[this.x - 3, this.y].liquid + Main.tile[this.x + 3, this.y].liquid + tile4.liquid + num3);
						single = (float)Math.Round((double)(single / 7f));
						int num5 = 0;
						tile.liquidType((int)tile4.liquidType());
						if (tile.liquid == (byte)single)
						{
							num5++;
						}
						else
						{
							tile.liquid = (byte)single;
							Liquid.AddWater(this.x - 1, this.y);
						}
						tile1.liquidType((int)tile4.liquidType());
						if (tile1.liquid == (byte)single)
						{
							num5++;
						}
						else
						{
							tile1.liquid = (byte)single;
							Liquid.AddWater(this.x + 1, this.y);
						}
						Main.tile[this.x - 2, this.y].liquidType((int)tile4.liquidType());
						if (Main.tile[this.x - 2, this.y].liquid == (byte)single)
						{
							num5++;
						}
						else
						{
							Main.tile[this.x - 2, this.y].liquid = (byte)single;
							Liquid.AddWater(this.x - 2, this.y);
						}
						Main.tile[this.x + 2, this.y].liquidType((int)tile4.liquidType());
						if (Main.tile[this.x + 2, this.y].liquid == (byte)single)
						{
							num5++;
						}
						else
						{
							Main.tile[this.x + 2, this.y].liquid = (byte)single;
							Liquid.AddWater(this.x + 2, this.y);
						}
						Main.tile[this.x - 3, this.y].liquidType((int)tile4.liquidType());
						if (Main.tile[this.x - 3, this.y].liquid == (byte)single)
						{
							num5++;
						}
						else
						{
							Main.tile[this.x - 3, this.y].liquid = (byte)single;
							Liquid.AddWater(this.x - 3, this.y);
						}
						Main.tile[this.x + 3, this.y].liquidType((int)tile4.liquidType());
						if (Main.tile[this.x + 3, this.y].liquid == (byte)single)
						{
							num5++;
						}
						else
						{
							Main.tile[this.x + 3, this.y].liquid = (byte)single;
							Liquid.AddWater(this.x + 3, this.y);
						}
						if (tile.liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x - 1, this.y);
						}
						if (tile1.liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x + 1, this.y);
						}
						if (Main.tile[this.x - 2, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x - 2, this.y);
						}
						if (Main.tile[this.x + 2, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x + 2, this.y);
						}
						if (Main.tile[this.x - 3, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x - 3, this.y);
						}
						if (Main.tile[this.x + 3, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
						{
							Liquid.AddWater(this.x + 3, this.y);
						}
						if (num5 != 6 || tile2.liquid <= 0)
						{
							tile4.liquid = (byte)single;
						}
					}
				}
				else if (flag2)
				{
					single = (float)(tile.liquid + tile1.liquid + Main.tile[this.x - 2, this.y].liquid + tile4.liquid + num3);
					single = (float)Math.Round((double)(single / 4f) + 0.001);
					tile.liquidType((int)tile4.liquidType());
					if (tile.liquid != (byte)single || tile4.liquid != (byte)single)
					{
						tile.liquid = (byte)single;
						Liquid.AddWater(this.x - 1, this.y);
					}
					tile1.liquidType((int)tile4.liquidType());
					if (tile1.liquid != (byte)single || tile4.liquid != (byte)single)
					{
						tile1.liquid = (byte)single;
						Liquid.AddWater(this.x + 1, this.y);
					}
					Main.tile[this.x - 2, this.y].liquidType((int)tile4.liquidType());
					if (Main.tile[this.x - 2, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
					{
						Main.tile[this.x - 2, this.y].liquid = (byte)single;
						Liquid.AddWater(this.x - 2, this.y);
					}
					tile4.liquid = (byte)single;
				}
				else if (!flag3)
				{
					single = (float)(tile.liquid + tile1.liquid + tile4.liquid + num3);
					single = (float)Math.Round((double)(single / 3f) + 0.001);
					tile.liquidType((int)tile4.liquidType());
					if (tile.liquid != (byte)single)
					{
						tile.liquid = (byte)single;
					}
					if (tile4.liquid != (byte)single || tile.liquid != (byte)single)
					{
						Liquid.AddWater(this.x - 1, this.y);
					}
					tile1.liquidType((int)tile4.liquidType());
					if (tile1.liquid != (byte)single)
					{
						tile1.liquid = (byte)single;
					}
					if (tile4.liquid != (byte)single || tile1.liquid != (byte)single)
					{
						Liquid.AddWater(this.x + 1, this.y);
					}
					tile4.liquid = (byte)single;
				}
				else
				{
					single = (float)(tile.liquid + tile1.liquid + Main.tile[this.x + 2, this.y].liquid + tile4.liquid + num3);
					single = (float)Math.Round((double)(single / 4f) + 0.001);
					tile.liquidType((int)tile4.liquidType());
					if (tile.liquid != (byte)single || tile4.liquid != (byte)single)
					{
						tile.liquid = (byte)single;
						Liquid.AddWater(this.x - 1, this.y);
					}
					tile1.liquidType((int)tile4.liquidType());
					if (tile1.liquid != (byte)single || tile4.liquid != (byte)single)
					{
						tile1.liquid = (byte)single;
						Liquid.AddWater(this.x + 1, this.y);
					}
					Main.tile[this.x + 2, this.y].liquidType((int)tile4.liquidType());
					if (Main.tile[this.x + 2, this.y].liquid != (byte)single || tile4.liquid != (byte)single)
					{
						Main.tile[this.x + 2, this.y].liquid = (byte)single;
						Liquid.AddWater(this.x + 2, this.y);
					}
					tile4.liquid = (byte)single;
				}
			}
			if (tile4.liquid == num1)
			{
				Liquid liquid2 = this;
				liquid2.kill = liquid2.kill + 1;
				return;
			}
			if (tile4.liquid == 254 && num1 == 255)
			{
				tile4.liquid = 255;
				Liquid liquid3 = this;
				liquid3.kill = liquid3.kill + 1;
				return;
			}
			Liquid.AddWater(this.x, this.y - 1);
			this.kill = 0;
		}

		public static void UpdateLiquid()
		{
			int num = Main.netMode;
			if (!WorldGen.gen)
			{
				if (!Liquid.panicMode)
				{
					if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer <= 4000)
					{
						Liquid.panicCounter = 0;
					}
					else
					{
						Liquid.panicCounter = Liquid.panicCounter + 1;
						if (Liquid.panicCounter > 1800 || Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > 13500)
						{
							Liquid.StartPanic();
						}
					}
				}
				if (Liquid.panicMode)
				{
					int num1 = 0;
					while (Liquid.panicY >= 3 && num1 < 5)
					{
						num1++;
						Liquid.QuickWater(0, Liquid.panicY, Liquid.panicY);
						Liquid.panicY = Liquid.panicY - 1;
						if (Liquid.panicY >= 3)
						{
							continue;
						}
						Console.WriteLine("Water has been settled.");
						Liquid.panicCounter = 0;
						Liquid.panicMode = false;
						WorldGen.WaterCheck();
						if (Main.netMode != 2)
						{
							continue;
						}
						for (int i = 0; i < 255; i++)
						{
							for (int j = 0; j < Main.maxSectionsX; j++)
							{
								for (int k = 0; k < Main.maxSectionsY; k++)
								{
									Netplay.Clients[i].TileSections[j, k] = false;
								}
							}
						}
					}
					return;
				}
			}
			if (Liquid.quickSettle || Liquid.numLiquid > 2000)
			{
				Liquid.quickFall = true;
			}
			else
			{
				Liquid.quickFall = false;
			}
			Liquid.wetCounter = Liquid.wetCounter + 1;
			int num2 = Liquid.maxLiquid / Liquid.cycles;
			int num3 = num2 * (Liquid.wetCounter - 1);
			int num4 = num2 * Liquid.wetCounter;
			if (Liquid.wetCounter == Liquid.cycles)
			{
				num4 = Liquid.numLiquid;
			}
			if (num4 > Liquid.numLiquid)
			{
				num4 = Liquid.numLiquid;
				int num5 = Main.netMode;
				Liquid.wetCounter = Liquid.cycles;
			}
			if (!Liquid.quickFall)
			{
				for (int l = num3; l < num4; l++)
				{
					if (Main.tile[Main.liquid[l].x, Main.liquid[l].y].skipLiquid())
					{
						Main.tile[Main.liquid[l].x, Main.liquid[l].y].skipLiquid(false);
					}
					else
					{
						Main.liquid[l].Update();
					}
				}
			}
			else
			{
				for (int m = num3; m < num4; m++)
				{
					Main.liquid[m].delay = 10;
					Main.liquid[m].Update();
					Main.tile[Main.liquid[m].x, Main.liquid[m].y].skipLiquid(false);
				}
			}
			if (Liquid.wetCounter >= Liquid.cycles)
			{
				Liquid.wetCounter = 0;
				for (int n = Liquid.numLiquid - 1; n >= 0; n--)
				{
					if (Main.liquid[n].kill > 4)
					{
						Liquid.DelWater(n);
					}
				}
				int num6 = Liquid.maxLiquid - (Liquid.maxLiquid - Liquid.numLiquid);
				if (num6 > LiquidBuffer.numLiquidBuffer)
				{
					num6 = LiquidBuffer.numLiquidBuffer;
				}
				for (int o = 0; o < num6; o++)
				{
					Main.tile[Main.liquidBuffer[0].x, Main.liquidBuffer[0].y].checkingLiquid(false);
					Liquid.AddWater(Main.liquidBuffer[0].x, Main.liquidBuffer[0].y);
					LiquidBuffer.DelBuffer(0);
				}
				if (Liquid.numLiquid <= 0 || Liquid.numLiquid <= Liquid.stuckAmount - 50 || Liquid.numLiquid >= Liquid.stuckAmount + 50)
				{
					Liquid.stuckCount = 0;
					Liquid.stuckAmount = Liquid.numLiquid;
				}
				else
				{
					Liquid.stuckCount = Liquid.stuckCount + 1;
					if (Liquid.stuckCount >= 10000)
					{
						Liquid.stuck = true;
						for (int p = Liquid.numLiquid - 1; p >= 0; p--)
						{
							Liquid.DelWater(p);
						}
						Liquid.stuck = false;
						Liquid.stuckCount = 0;
					}
				}
			}
			if (Main.netMode == 2 && Liquid._netChangeSet.Count > 0)
			{
				Utils.Swap<HashSet<int>>(ref Liquid._netChangeSet, ref Liquid._swapNetChangeSet);
				NetManager.Instance.Broadcast(NetLiquidModule.Serialize(Liquid._swapNetChangeSet), -1);
				Liquid._swapNetChangeSet.Clear();
			}
		}
	}
}
