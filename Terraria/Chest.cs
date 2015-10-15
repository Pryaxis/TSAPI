
using System;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ObjectData;

namespace Terraria
{
	public class Chest
	{
		public const int maxChestTypes = 52;

		public const int maxDresserTypes = 28;

		public const int maxItems = 40;

		public const int MaxNameLength = 20;

		public static int[] chestTypeToIcon;

		public static int[] chestItemSpawn;

		public static int[] dresserTypeToIcon;

		public static int[] dresserItemSpawn;

		public Item[] item;

		public int x;

		public int y;

		public bool bankChest;

		public string name;

		public int frameCounter;

		public int frame;

		static Chest()
		{
			Chest.chestTypeToIcon = new int[52];
			Chest.chestItemSpawn = new int[52];
			Chest.dresserTypeToIcon = new int[28];
			Chest.dresserItemSpawn = new int[28];
		}

		public Chest(bool bank = false)
		{
			this.item = new Item[40];
			this.bankChest = bank;
			this.name = string.Empty;
		}

		public void AddShop(Item newItem)
		{
			int num = 0;
			while (num < 39)
			{
				if (this.item[num] == null || this.item[num].type == 0)
				{
					this.item[num] = newItem.Clone();
					this.item[num].favorited = false;
					this.item[num].buyOnce = true;
					if (this.item[num].@value <= 0)
					{
						break;
					}
					this.item[num].@value = this.item[num].@value / 5;
					if (this.item[num].@value >= 1)
					{
						break;
					}
					this.item[num].@value = 1;
					return;
				}
				else
				{
					num++;
				}
			}
		}

		public static int AfterPlacement_Hook(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			Point16 point16 = new Point16(x, y);
			TileObjectData.OriginToTopLeft(type, style, ref point16);
			int num = Chest.FindEmptyChest(point16.X, point16.Y, 21, 0, 1);
			if (num == -1)
			{
				return -1;
			}
			if (Main.netMode != 1)
			{
				Chest chest = new Chest(false)
				{
					x = point16.X,
					y = point16.Y
				};
				for (int i = 0; i < 40; i++)
				{
					chest.item[i] = new Item();
				}
				Main.chest[num] = chest;
			}
			else if (type != 21)
			{
				NetMessage.SendData((int)PacketTypes.TileKill, -1, -1, "", 2, (float)x, (float)y, (float)style, 0, 0, 0);
			}
			else
			{
				NetMessage.SendData((int)PacketTypes.TileKill, -1, -1, "", 0, (float)x, (float)y, (float)style, 0, 0, 0);
			}
			return num;
		}

		public static bool CanDestroyChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null && chest.x == X && chest.y == Y)
				{
					for (int j = 0; j < 40; j++)
					{
						if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
						{
							return false;
						}
					}
					return true;
				}
			}
			return true;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public static int CreateChest(int X, int Y, int id = -1)
		{
			int num = id;
			if (num == -1)
			{
				num = Chest.FindEmptyChest(X, Y, 21, 0, 1);
				if (num == -1)
				{
					return -1;
				}
				if (Main.netMode == 1)
				{
					return num;
				}
			}
			Main.chest[num] = new Chest(false);
			Main.chest[num].x = X;
			Main.chest[num].y = Y;
			for (int i = 0; i < 40; i++)
			{
				Main.chest[num].item[i] = new Item();
			}
			return num;
		}

		public static bool DestroyChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null && chest.x == X && chest.y == Y)
				{
					for (int j = 0; j < 40; j++)
					{
						if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
						{
							return false;
						}
					}
					Main.chest[i] = null;
					if (Main.player[Main.myPlayer].chest == i)
					{
						Main.player[Main.myPlayer].chest = -1;
					}
					return true;
				}
			}
			return true;
		}

		public static void DestroyChestDirect(int X, int Y, int id)
		{
			if (id < 0 || id >= (int)Main.chest.Length)
			{
				return;
			}
			try
			{
				Chest chest = Main.chest[id];
				if (chest != null)
				{
					if (chest.x == X && chest.y == Y)
					{
						Main.chest[id] = null;
						if (Main.player[Main.myPlayer].chest == id)
						{
							Main.player[Main.myPlayer].chest = -1;
						}
					}
				}
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
		}

		public static int FindChest(int X, int Y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.chest[i] != null && Main.chest[i].x == X && Main.chest[i].y == Y)
				{
					return i;
				}
			}
			return -1;
		}

		public static int FindEmptyChest(int x, int y, int type = 21, int style = 0, int direction = 1)
		{
			int num = -1;
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					if (chest.x == x && chest.y == y)
					{
						return -1;
					}
				}
				else if (num == -1)
				{
					num = i;
				}
			}
			return num;
		}

		public static void Initialize()
		{
			int num = 48;
			int num1 = num;
			Chest.chestItemSpawn[0] = num;
			Chest.chestTypeToIcon[0] = num1;
			int num2 = 306;
			int num3 = num2;
			Chest.chestItemSpawn[1] = num2;
			Chest.chestTypeToIcon[1] = num3;
			Chest.chestTypeToIcon[2] = 327;
			Chest.chestItemSpawn[2] = 306;
			int num4 = 328;
			int num5 = num4;
			Chest.chestItemSpawn[3] = num4;
			Chest.chestTypeToIcon[3] = num5;
			Chest.chestTypeToIcon[4] = 329;
			Chest.chestItemSpawn[4] = 328;
			int num6 = 343;
			int num7 = num6;
			Chest.chestItemSpawn[5] = num6;
			Chest.chestTypeToIcon[5] = num7;
			int num8 = 348;
			int num9 = num8;
			Chest.chestItemSpawn[6] = num8;
			Chest.chestTypeToIcon[6] = num9;
			int num10 = 625;
			int num11 = num10;
			Chest.chestItemSpawn[7] = num10;
			Chest.chestTypeToIcon[7] = num11;
			int num12 = 626;
			int num13 = num12;
			Chest.chestItemSpawn[8] = num12;
			Chest.chestTypeToIcon[8] = num13;
			int num14 = 627;
			int num15 = num14;
			Chest.chestItemSpawn[9] = num14;
			Chest.chestTypeToIcon[9] = num15;
			int num16 = 680;
			int num17 = num16;
			Chest.chestItemSpawn[10] = num16;
			Chest.chestTypeToIcon[10] = num17;
			int num18 = 681;
			int num19 = num18;
			Chest.chestItemSpawn[11] = num18;
			Chest.chestTypeToIcon[11] = num19;
			int num20 = 831;
			int num21 = num20;
			Chest.chestItemSpawn[12] = num20;
			Chest.chestTypeToIcon[12] = num21;
			int num22 = 838;
			int num23 = num22;
			Chest.chestItemSpawn[13] = num22;
			Chest.chestTypeToIcon[13] = num23;
			int num24 = 914;
			int num25 = num24;
			Chest.chestItemSpawn[14] = num24;
			Chest.chestTypeToIcon[14] = num25;
			int num26 = 952;
			int num27 = num26;
			Chest.chestItemSpawn[15] = num26;
			Chest.chestTypeToIcon[15] = num27;
			int num28 = 1142;
			int num29 = num28;
			Chest.chestItemSpawn[16] = num28;
			Chest.chestTypeToIcon[16] = num29;
			int num30 = 1298;
			int num31 = num30;
			Chest.chestItemSpawn[17] = num30;
			Chest.chestTypeToIcon[17] = num31;
			int num32 = 1528;
			int num33 = num32;
			Chest.chestItemSpawn[18] = num32;
			Chest.chestTypeToIcon[18] = num33;
			int num34 = 1529;
			int num35 = num34;
			Chest.chestItemSpawn[19] = num34;
			Chest.chestTypeToIcon[19] = num35;
			int num36 = 1530;
			int num37 = num36;
			Chest.chestItemSpawn[20] = num36;
			Chest.chestTypeToIcon[20] = num37;
			int num38 = 1531;
			int num39 = num38;
			Chest.chestItemSpawn[21] = num38;
			Chest.chestTypeToIcon[21] = num39;
			int num40 = 1532;
			int num41 = num40;
			Chest.chestItemSpawn[22] = num40;
			Chest.chestTypeToIcon[22] = num41;
			Chest.chestTypeToIcon[23] = 1533;
			Chest.chestItemSpawn[23] = 1528;
			Chest.chestTypeToIcon[24] = 1534;
			Chest.chestItemSpawn[24] = 1529;
			Chest.chestTypeToIcon[25] = 1535;
			Chest.chestItemSpawn[25] = 1530;
			Chest.chestTypeToIcon[26] = 1536;
			Chest.chestItemSpawn[26] = 1531;
			Chest.chestTypeToIcon[27] = 1537;
			Chest.chestItemSpawn[27] = 1532;
			int num42 = 2230;
			int num43 = num42;
			Chest.chestItemSpawn[28] = num42;
			Chest.chestTypeToIcon[28] = num43;
			int num44 = 2249;
			int num45 = num44;
			Chest.chestItemSpawn[29] = num44;
			Chest.chestTypeToIcon[29] = num45;
			int num46 = 2250;
			int num47 = num46;
			Chest.chestItemSpawn[30] = num46;
			Chest.chestTypeToIcon[30] = num47;
			int num48 = 2526;
			int num49 = num48;
			Chest.chestItemSpawn[31] = num48;
			Chest.chestTypeToIcon[31] = num49;
			int num50 = 2544;
			int num51 = num50;
			Chest.chestItemSpawn[32] = num50;
			Chest.chestTypeToIcon[32] = num51;
			int num52 = 2559;
			int num53 = num52;
			Chest.chestItemSpawn[33] = num52;
			Chest.chestTypeToIcon[33] = num53;
			int num54 = 2574;
			int num55 = num54;
			Chest.chestItemSpawn[34] = num54;
			Chest.chestTypeToIcon[34] = num55;
			int num56 = 2612;
			int num57 = num56;
			Chest.chestItemSpawn[35] = num56;
			Chest.chestTypeToIcon[35] = num57;
			Chest.chestTypeToIcon[36] = 327;
			Chest.chestItemSpawn[36] = 2612;
			int num58 = 2613;
			int num59 = num58;
			Chest.chestItemSpawn[37] = num58;
			Chest.chestTypeToIcon[37] = num59;
			Chest.chestTypeToIcon[38] = 327;
			Chest.chestItemSpawn[38] = 2613;
			int num60 = 2614;
			int num61 = num60;
			Chest.chestItemSpawn[39] = num60;
			Chest.chestTypeToIcon[39] = num61;
			Chest.chestTypeToIcon[40] = 327;
			Chest.chestItemSpawn[40] = 2614;
			int num62 = 2615;
			int num63 = num62;
			Chest.chestItemSpawn[41] = num62;
			Chest.chestTypeToIcon[41] = num63;
			int num64 = 2616;
			int num65 = num64;
			Chest.chestItemSpawn[42] = num64;
			Chest.chestTypeToIcon[42] = num65;
			int num66 = 2617;
			int num67 = num66;
			Chest.chestItemSpawn[43] = num66;
			Chest.chestTypeToIcon[43] = num67;
			int num68 = 2618;
			int num69 = num68;
			Chest.chestItemSpawn[44] = num68;
			Chest.chestTypeToIcon[44] = num69;
			int num70 = 2619;
			int num71 = num70;
			Chest.chestItemSpawn[45] = num70;
			Chest.chestTypeToIcon[45] = num71;
			int num72 = 2620;
			int num73 = num72;
			Chest.chestItemSpawn[46] = num72;
			Chest.chestTypeToIcon[46] = num73;
			int num74 = 2748;
			int num75 = num74;
			Chest.chestItemSpawn[47] = num74;
			Chest.chestTypeToIcon[47] = num75;
			int num76 = 2814;
			int num77 = num76;
			Chest.chestItemSpawn[48] = num76;
			Chest.chestTypeToIcon[48] = num77;
			int num78 = 3180;
			int num79 = num78;
			Chest.chestItemSpawn[49] = num78;
			Chest.chestTypeToIcon[49] = num79;
			int num80 = 3125;
			int num81 = num80;
			Chest.chestItemSpawn[50] = num80;
			Chest.chestTypeToIcon[50] = num81;
			int num82 = 3181;
			int num83 = num82;
			Chest.chestItemSpawn[51] = num82;
			Chest.chestTypeToIcon[51] = num83;
			int num84 = 334;
			int num85 = num84;
			Chest.dresserItemSpawn[0] = num84;
			Chest.dresserTypeToIcon[0] = num85;
			int num86 = 647;
			int num87 = num86;
			Chest.dresserItemSpawn[1] = num86;
			Chest.dresserTypeToIcon[1] = num87;
			int num88 = 648;
			int num89 = num88;
			Chest.dresserItemSpawn[2] = num88;
			Chest.dresserTypeToIcon[2] = num89;
			int num90 = 649;
			int num91 = num90;
			Chest.dresserItemSpawn[3] = num90;
			Chest.dresserTypeToIcon[3] = num91;
			int num92 = 918;
			int num93 = num92;
			Chest.dresserItemSpawn[4] = num92;
			Chest.dresserTypeToIcon[4] = num93;
			int num94 = 2386;
			int num95 = num94;
			Chest.dresserItemSpawn[5] = num94;
			Chest.dresserTypeToIcon[5] = num95;
			int num96 = 2387;
			int num97 = num96;
			Chest.dresserItemSpawn[6] = num96;
			Chest.dresserTypeToIcon[6] = num97;
			int num98 = 2388;
			int num99 = num98;
			Chest.dresserItemSpawn[7] = num98;
			Chest.dresserTypeToIcon[7] = num99;
			int num100 = 2389;
			int num101 = num100;
			Chest.dresserItemSpawn[8] = num100;
			Chest.dresserTypeToIcon[8] = num101;
			int num102 = 2390;
			int num103 = num102;
			Chest.dresserItemSpawn[9] = num102;
			Chest.dresserTypeToIcon[9] = num103;
			int num104 = 2391;
			int num105 = num104;
			Chest.dresserItemSpawn[10] = num104;
			Chest.dresserTypeToIcon[10] = num105;
			int num106 = 2392;
			int num107 = num106;
			Chest.dresserItemSpawn[11] = num106;
			Chest.dresserTypeToIcon[11] = num107;
			int num108 = 2393;
			int num109 = num108;
			Chest.dresserItemSpawn[12] = num108;
			Chest.dresserTypeToIcon[12] = num109;
			int num110 = 2394;
			int num111 = num110;
			Chest.dresserItemSpawn[13] = num110;
			Chest.dresserTypeToIcon[13] = num111;
			int num112 = 2395;
			int num113 = num112;
			Chest.dresserItemSpawn[14] = num112;
			Chest.dresserTypeToIcon[14] = num113;
			int num114 = 2396;
			int num115 = num114;
			Chest.dresserItemSpawn[15] = num114;
			Chest.dresserTypeToIcon[15] = num115;
			int num116 = 2529;
			int num117 = num116;
			Chest.dresserItemSpawn[16] = num116;
			Chest.dresserTypeToIcon[16] = num117;
			int num118 = 2545;
			int num119 = num118;
			Chest.dresserItemSpawn[17] = num118;
			Chest.dresserTypeToIcon[17] = num119;
			int num120 = 2562;
			int num121 = num120;
			Chest.dresserItemSpawn[18] = num120;
			Chest.dresserTypeToIcon[18] = num121;
			int num122 = 2577;
			num1 = num122;
			Chest.dresserItemSpawn[19] = num122;
			Chest.dresserTypeToIcon[19] = num1;
			int num123 = 2637;
			num1 = num123;
			Chest.dresserItemSpawn[20] = num123;
			Chest.dresserTypeToIcon[20] = num1;
			int num124 = 2638;
			num1 = num124;
			Chest.dresserItemSpawn[21] = num124;
			Chest.dresserTypeToIcon[21] = num1;
			int num125 = 2639;
			num1 = num125;
			Chest.dresserItemSpawn[22] = num125;
			Chest.dresserTypeToIcon[22] = num1;
			int num126 = 2640;
			num1 = num126;
			Chest.dresserItemSpawn[23] = num126;
			Chest.dresserTypeToIcon[23] = num1;
			int num127 = 2816;
			num1 = num127;
			Chest.dresserItemSpawn[24] = num127;
			Chest.dresserTypeToIcon[24] = num1;
			int num128 = 3132;
			num1 = num128;
			Chest.dresserItemSpawn[25] = num128;
			Chest.dresserTypeToIcon[25] = num1;
			int num129 = 3134;
			num1 = num129;
			Chest.dresserItemSpawn[26] = num129;
			Chest.dresserTypeToIcon[26] = num1;
			int num130 = 3133;
			num1 = num130;
			Chest.dresserItemSpawn[27] = num130;
			Chest.dresserTypeToIcon[27] = num1;
		}

		public static bool isLocked(int x, int y)
		{
			if (Main.tile[x, y] == null)
			{
				return true;
			}
			if (Main.tile[x, y].frameX >= 72 && Main.tile[x, y].frameX <= 106 || Main.tile[x, y].frameX >= 144 && Main.tile[x, y].frameX <= 178 || Main.tile[x, y].frameX >= 828 && Main.tile[x, y].frameX <= 1006 || Main.tile[x, y].frameX >= 1296 && Main.tile[x, y].frameX <= 1330 || Main.tile[x, y].frameX >= 1368 && Main.tile[x, y].frameX <= 1402 || Main.tile[x, y].frameX >= 1440 && Main.tile[x, y].frameX <= 1474)
			{
				return true;
			}
			return false;
		}

		private static bool IsPlayerInChest(int i)
		{
			for (int num = 0; num < 255; num++)
			{
				if (Main.player[num].chest == i)
				{
					return true;
				}
			}
			return false;
		}

		public static bool NearOtherChests(int x, int y)
		{
			for (int i = x - 25; i < x + 25; i++)
			{
				for (int j = y - 8; j < y + 8; j++)
				{
					Tile tileSafely = Framing.GetTileSafely(i, j);
					if (tileSafely.active() && tileSafely.type == 21)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static Item PutItemInNearbyChest(Item item, Vector2 position)
		{
			if (Main.netMode == 1)
			{
				return item;
			}
			for (int i = 0; i < 1000; i++)
			{
				bool flag = false;
				bool flag1 = false;
				if (Main.chest[i] != null && !Chest.IsPlayerInChest(i) && !Chest.isLocked(Main.chest[i].x, Main.chest[i].y))
				{
					Vector2 vector2 = new Vector2((float)(Main.chest[i].x * 16 + 16), (float)(Main.chest[i].y * 16 + 16));
					if ((vector2 - position).Length() < 200f)
					{
						for (int j = 0; j < (int)Main.chest[i].item.Length; j++)
						{
							if (Main.chest[i].item[j].type <= 0 || Main.chest[i].item[j].stack <= 0)
							{
								flag1 = true;
							}
							else if (item.IsTheSameAs(Main.chest[i].item[j]))
							{
								flag = true;
								int num = Main.chest[i].item[j].maxStack - Main.chest[i].item[j].stack;
								if (num > 0)
								{
									if (num > item.stack)
									{
										num = item.stack;
									}
									Item item1 = item;
									item1.stack = item1.stack - num;
									Item item2 = Main.chest[i].item[j];
									item2.stack = item2.stack + num;
									if (item.stack <= 0)
									{
										item.SetDefaults(0, false);
										return item;
									}
								}
							}
						}
						if (flag && flag1 && item.stack > 0)
						{
							for (int k = 0; k < (int)Main.chest[i].item.Length; k++)
							{
								if (Main.chest[i].item[k].type == 0 || Main.chest[i].item[k].stack == 0)
								{
									Main.chest[i].item[k] = item.Clone();
									item.SetDefaults(0, false);
									return item;
								}
							}
						}
					}
				}
			}
			return item;
		}

		public static void ServerPlaceItem(int plr, int slot)
		{
			Main.player[plr].inventory[slot] = Chest.PutItemInNearbyChest(Main.player[plr].inventory[slot], Main.player[plr].Center);
			NetMessage.SendData((int)PacketTypes.PlayerSlot, -1, -1, "", plr, (float)slot, (float)Main.player[plr].inventory[slot].prefix, 0f, 0, 0, 0);
		}

		public void SetupShop(int type)
		{
			for (int i = 0; i < 40; i++)
			{
				this.item[i] = new Item();
			}
			int num = 0;
			if (type == 1)
			{
				this.item[num].SetDefaults("Mining Helmet");
				num++;
				this.item[num].SetDefaults("Piggy Bank");
				num++;
				this.item[num].SetDefaults("Iron Anvil");
				num++;
				this.item[num].SetDefaults(1991, false);
				num++;
				this.item[num].SetDefaults("Copper Pickaxe");
				num++;
				this.item[num].SetDefaults("Copper Axe");
				num++;
				this.item[num].SetDefaults("Torch");
				num++;
				this.item[num].SetDefaults("Lesser Healing Potion");
				num++;
				this.item[num].SetDefaults("Lesser Mana Potion");
				num++;
				this.item[num].SetDefaults("Wooden Arrow");
				num++;
				this.item[num].SetDefaults("Shuriken");
				num++;
				this.item[num].SetDefaults("Rope");
				num++;
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					this.item[num].SetDefaults(967, false);
					num++;
				}
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults("Throwing Knife");
					num++;
				}
				if (!Main.dayTime)
				{
					this.item[num].SetDefaults("Glowstick");
					num++;
				}
				if (NPC.downedBoss3)
				{
					this.item[num].SetDefaults("Safe");
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(488, false);
					num++;
				}
				int num1 = 0;
				while (num1 < 58)
				{
					if (Main.player[Main.myPlayer].inventory[num1].type != 930)
					{
						num1++;
					}
					else
					{
						this.item[num].SetDefaults(931, false);
						num++;
						this.item[num].SetDefaults(1614, false);
						num++;
						break;
					}
				}
				this.item[num].SetDefaults(1786, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1348, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(3107))
				{
					this.item[num].SetDefaults(3108, false);
					num++;
				}
				if (Main.halloween)
				{
					int num2 = num;
					num = num2 + 1;
					this.item[num2].SetDefaults(3242, false);
					int num3 = num;
					num = num3 + 1;
					this.item[num3].SetDefaults(3243, false);
					int num4 = num;
					num = num4 + 1;
					this.item[num4].SetDefaults(3244, false);
				}
			}
			else if (type == 2)
			{
				this.item[num].SetDefaults("Musket Ball");
				num++;
				if (Main.bloodMoon || Main.hardMode)
				{
					this.item[num].SetDefaults("Silver Bullet");
					num++;
				}
				if (NPC.downedBoss2 && !Main.dayTime || Main.hardMode)
				{
					this.item[num].SetDefaults(47, false);
					num++;
				}
				this.item[num].SetDefaults("Flintlock Pistol");
				num++;
				this.item[num].SetDefaults("Minishark");
				num++;
				if (!Main.dayTime)
				{
					this.item[num].SetDefaults(324, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(534, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1432, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1258))
				{
					this.item[num].SetDefaults(1261, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1835))
				{
					this.item[num].SetDefaults(1836, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(3107))
				{
					this.item[num].SetDefaults(3108, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1782))
				{
					this.item[num].SetDefaults(1783, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1784))
				{
					this.item[num].SetDefaults(1785, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1736, false);
					num++;
					this.item[num].SetDefaults(1737, false);
					num++;
					this.item[num].SetDefaults(1738, false);
					num++;
				}
			}
			else if (type == 3)
			{
				if (!Main.bloodMoon)
				{
					this.item[num].SetDefaults("Purification Powder");
					num++;
					this.item[num].SetDefaults("Grass Seeds");
					num++;
					this.item[num].SetDefaults("Sunflower");
					num++;
				}
				else if (!WorldGen.crimson)
				{
					this.item[num].SetDefaults(67, false);
					num++;
					this.item[num].SetDefaults(59, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(2171, false);
					num++;
				}
				this.item[num].SetDefaults("Acorn");
				num++;
				this.item[num].SetDefaults(114, false);
				num++;
				this.item[num].SetDefaults(1828, false);
				num++;
				this.item[num].SetDefaults(745, false);
				num++;
				this.item[num].SetDefaults(747, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(746, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(369, false);
					num++;
				}
				if (Main.shroomTiles > 50)
				{
					this.item[num].SetDefaults(194, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1853, false);
					num++;
					this.item[num].SetDefaults(1854, false);
					num++;
				}
				if (NPC.downedSlimeKing)
				{
					this.item[num].SetDefaults(3215, false);
					num++;
				}
				if (NPC.downedQueenBee)
				{
					this.item[num].SetDefaults(3216, false);
					num++;
				}
				if (NPC.downedBoss1)
				{
					this.item[num].SetDefaults(3219, false);
					num++;
				}
				if (NPC.downedBoss2)
				{
					if (!WorldGen.crimson)
					{
						this.item[num].SetDefaults(3217, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(3218, false);
						num++;
					}
				}
				if (NPC.downedBoss3)
				{
					this.item[num].SetDefaults(3220, false);
					num++;
					this.item[num].SetDefaults(3221, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(3222, false);
					num++;
				}
			}
			else if (type == 4)
			{
				this.item[num].SetDefaults("Grenade");
				num++;
				this.item[num].SetDefaults("Bomb");
				num++;
				this.item[num].SetDefaults("Dynamite");
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults("Hellfire Arrow");
					num++;
				}
				if (Main.hardMode && NPC.downedPlantBoss && NPC.downedPirates)
				{
					this.item[num].SetDefaults(937, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1347, false);
					num++;
				}
			}
			else if (type == 5)
			{
				this.item[num].SetDefaults(254, false);
				num++;
				this.item[num].SetDefaults(981, false);
				num++;
				if (Main.dayTime)
				{
					this.item[num].SetDefaults(242, false);
					num++;
				}
				if (Main.moonPhase == 0)
				{
					this.item[num].SetDefaults(245, false);
					num++;
					this.item[num].SetDefaults(246, false);
					num++;
					if (!Main.dayTime)
					{
						int num5 = num;
						num = num5 + 1;
						this.item[num5].SetDefaults(1288, false);
						int num6 = num;
						num = num6 + 1;
						this.item[num6].SetDefaults(1289, false);
					}
				}
				else if (Main.moonPhase == 1)
				{
					this.item[num].SetDefaults(325, false);
					num++;
					this.item[num].SetDefaults(326, false);
					num++;
				}
				this.item[num].SetDefaults(269, false);
				num++;
				this.item[num].SetDefaults(270, false);
				num++;
				this.item[num].SetDefaults(271, false);
				num++;
				if (NPC.downedClown)
				{
					this.item[num].SetDefaults(503, false);
					num++;
					this.item[num].SetDefaults(504, false);
					num++;
					this.item[num].SetDefaults(505, false);
					num++;
				}
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(322, false);
					num++;
					if (!Main.dayTime)
					{
						int num7 = num;
						num = num7 + 1;
						this.item[num7].SetDefaults(3362, false);
						int num8 = num;
						num = num8 + 1;
						this.item[num8].SetDefaults(3363, false);
					}
				}
				if (NPC.downedAncientCultist)
				{
					if (!Main.dayTime)
					{
						int num9 = num;
						num = num9 + 1;
						this.item[num9].SetDefaults(2857, false);
						int num10 = num;
						num = num10 + 1;
						this.item[num10].SetDefaults(2859, false);
					}
					else
					{
						int num11 = num;
						num = num11 + 1;
						this.item[num11].SetDefaults(2856, false);
						int num12 = num;
						num = num12 + 1;
						this.item[num12].SetDefaults(2858, false);
					}
				}
				if (NPC.AnyNPCs(NPCID.TaxCollector))
				{
					int num13 = num;
					num = num13 + 1;
					this.item[num13].SetDefaults(3242, false);
					int num14 = num;
					num = num14 + 1;
					this.item[num14].SetDefaults(3243, false);
					int num15 = num;
					num = num15 + 1;
					this.item[num15].SetDefaults(3244, false);
				}
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					this.item[num].SetDefaults(1429, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1740, false);
					num++;
				}
				if (Main.hardMode)
				{
					if (Main.moonPhase == 2)
					{
						this.item[num].SetDefaults(869, false);
						num++;
					}
					if (Main.moonPhase == 4)
					{
						this.item[num].SetDefaults(864, false);
						num++;
						this.item[num].SetDefaults(865, false);
						num++;
					}
					if (Main.moonPhase == 6)
					{
						this.item[num].SetDefaults(873, false);
						num++;
						this.item[num].SetDefaults(874, false);
						num++;
						this.item[num].SetDefaults(875, false);
						num++;
					}
				}
				if (NPC.downedFrost)
				{
					this.item[num].SetDefaults(1275, false);
					num++;
					this.item[num].SetDefaults(1276, false);
					num++;
				}
				if (Main.halloween)
				{
					int num16 = num;
					num = num16 + 1;
					this.item[num16].SetDefaults(3246, false);
					int num17 = num;
					num = num17 + 1;
					this.item[num17].SetDefaults(3247, false);
				}
			}
			else if (type == 6)
			{
				this.item[num].SetDefaults(128, false);
				num++;
				this.item[num].SetDefaults(486, false);
				num++;
				this.item[num].SetDefaults(398, false);
				num++;
				this.item[num].SetDefaults(84, false);
				num++;
				this.item[num].SetDefaults(407, false);
				num++;
				this.item[num].SetDefaults(161, false);
				num++;
			}
			else if (type == 7)
			{
				this.item[num].SetDefaults(487, false);
				num++;
				this.item[num].SetDefaults(496, false);
				num++;
				this.item[num].SetDefaults(500, false);
				num++;
				this.item[num].SetDefaults(507, false);
				num++;
				this.item[num].SetDefaults(508, false);
				num++;
				this.item[num].SetDefaults(531, false);
				num++;
				this.item[num].SetDefaults(576, false);
				num++;
				this.item[num].SetDefaults(3186, false);
				num++;
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1739, false);
					num++;
				}
			}
			else if (type == 8)
			{
				this.item[num].SetDefaults(509, false);
				num++;
				this.item[num].SetDefaults(850, false);
				num++;
				this.item[num].SetDefaults(851, false);
				num++;
				this.item[num].SetDefaults(510, false);
				num++;
				this.item[num].SetDefaults(530, false);
				num++;
				this.item[num].SetDefaults(513, false);
				num++;
				this.item[num].SetDefaults(538, false);
				num++;
				this.item[num].SetDefaults(529, false);
				num++;
				this.item[num].SetDefaults(541, false);
				num++;
				this.item[num].SetDefaults(542, false);
				num++;
				this.item[num].SetDefaults(543, false);
				num++;
				this.item[num].SetDefaults(852, false);
				num++;
				this.item[num].SetDefaults(853, false);
				num++;
				this.item[num].SetDefaults(2739, false);
				num++;
				this.item[num].SetDefaults(849, false);
				num++;
				int num18 = num;
				num = num18 + 1;
				this.item[num18].SetDefaults(2799, false);
				if (NPC.AnyNPCs(NPCID.Angler) && Main.hardMode && Main.moonPhase == 3)
				{
					this.item[num].SetDefaults(2295, false);
					num++;
				}
			}
			else if (type == 9)
			{
				this.item[num].SetDefaults(588, false);
				num++;
				this.item[num].SetDefaults(589, false);
				num++;
				this.item[num].SetDefaults(590, false);
				num++;
				this.item[num].SetDefaults(597, false);
				num++;
				this.item[num].SetDefaults(598, false);
				num++;
				this.item[num].SetDefaults(596, false);
				num++;
				for (int j = 1873; j < 1906; j++)
				{
					this.item[num].SetDefaults(j, false);
					num++;
				}
			}
			else if (type == 10)
			{
				if (NPC.downedMechBossAny)
				{
					this.item[num].SetDefaults(756, false);
					num++;
					this.item[num].SetDefaults(787, false);
					num++;
				}
				this.item[num].SetDefaults(868, false);
				num++;
				if (NPC.downedPlantBoss)
				{
					this.item[num].SetDefaults(1551, false);
					num++;
				}
				this.item[num].SetDefaults(1181, false);
				num++;
				this.item[num].SetDefaults(783, false);
				num++;
			}
			else if (type == 11)
			{
				this.item[num].SetDefaults(779, false);
				num++;
				if (Main.moonPhase < 4)
				{
					this.item[num].SetDefaults(839, false);
					num++;
					this.item[num].SetDefaults(840, false);
					num++;
					this.item[num].SetDefaults(841, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(748, false);
					num++;
				}
				if (NPC.downedGolemBoss)
				{
					this.item[num].SetDefaults(948, false);
					num++;
				}
				this.item[num].SetDefaults(995, false);
				num++;
				if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3)
				{
					this.item[num].SetDefaults(2203, false);
					num++;
				}
				if (WorldGen.crimson)
				{
					this.item[num].SetDefaults(2886, false);
					num++;
					this.item[num].SetDefaults(2193, false);
					num++;
				}
				this.item[num].SetDefaults(1263, false);
				num++;
				if (!Main.eclipse && !Main.bloodMoon)
				{
					if (!Main.player[Main.myPlayer].ZoneHoly)
					{
						this.item[num].SetDefaults(780, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(781, false);
						num++;
					}
				}
				else if (!WorldGen.crimson)
				{
					this.item[num].SetDefaults(782, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(784, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1344, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1742, false);
					num++;
				}
			}
			else if (type == 12)
			{
				this.item[num].SetDefaults(1037, false);
				num++;
				this.item[num].SetDefaults(2874, false);
				num++;
				this.item[num].SetDefaults(1120, false);
				num++;
				if (Main.netMode == 1)
				{
					this.item[num].SetDefaults(1969, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(3248, false);
					num++;
					this.item[num].SetDefaults(1741, false);
					num++;
				}
				if (Main.moonPhase == 0)
				{
					this.item[num].SetDefaults(2871, false);
					num++;
					this.item[num].SetDefaults(2872, false);
					num++;
				}
			}
			else if (type == 13)
			{
				this.item[num].SetDefaults(859, false);
				num++;
				this.item[num].SetDefaults(1000, false);
				num++;
				this.item[num].SetDefaults(1168, false);
				num++;
				this.item[num].SetDefaults(1449, false);
				num++;
				this.item[num].SetDefaults(1345, false);
				num++;
				this.item[num].SetDefaults(1450, false);
				num++;
				int num19 = num;
				num = num19 + 1;
				this.item[num19].SetDefaults(3253, false);
				int num20 = num;
				num = num20 + 1;
				this.item[num20].SetDefaults(2700, false);
				int num21 = num;
				num = num21 + 1;
				this.item[num21].SetDefaults(2738, false);
				if (Main.player[Main.myPlayer].HasItem(3548))
				{
					this.item[num].SetDefaults(3548, false);
					num++;
				}
				if (NPC.AnyNPCs(NPCID.Pirate))
				{
					int num22 = num;
					num = num22 + 1;
					this.item[num22].SetDefaults(3369, false);
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(3214, false);
					num++;
					this.item[num].SetDefaults(2868, false);
					num++;
					this.item[num].SetDefaults(970, false);
					num++;
					this.item[num].SetDefaults(971, false);
					num++;
					this.item[num].SetDefaults(972, false);
					num++;
					this.item[num].SetDefaults(973, false);
					num++;
				}
			}
			else if (type == 14)
			{
				this.item[num].SetDefaults(771, false);
				num++;
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(772, false);
					num++;
				}
				if (!Main.dayTime || Main.eclipse)
				{
					this.item[num].SetDefaults(773, false);
					num++;
				}
				if (Main.eclipse)
				{
					this.item[num].SetDefaults(774, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(760, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1346, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1743, false);
					num++;
					this.item[num].SetDefaults(1744, false);
					num++;
					this.item[num].SetDefaults(1745, false);
					num++;
				}
				if (NPC.downedMartians)
				{
					int num23 = num;
					num = num23 + 1;
					this.item[num23].SetDefaults(2862, false);
					int num24 = num;
					num = num24 + 1;
					this.item[num24].SetDefaults(3109, false);
				}
			}
			else if (type == 15)
			{
				this.item[num].SetDefaults(1071, false);
				num++;
				this.item[num].SetDefaults(1072, false);
				num++;
				this.item[num].SetDefaults(1100, false);
				num++;
				for (int k = 1073; k <= 1084; k++)
				{
					this.item[num].SetDefaults(k, false);
					num++;
				}
				this.item[num].SetDefaults(1097, false);
				num++;
				this.item[num].SetDefaults(1099, false);
				num++;
				this.item[num].SetDefaults(1098, false);
				num++;
				this.item[num].SetDefaults(1966, false);
				num++;
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1967, false);
					num++;
					this.item[num].SetDefaults(1968, false);
					num++;
				}
				this.item[num].SetDefaults(1490, false);
				num++;
				if (Main.moonPhase <= 1)
				{
					this.item[num].SetDefaults(1481, false);
					num++;
				}
				else if (Main.moonPhase <= 3)
				{
					this.item[num].SetDefaults(1482, false);
					num++;
				}
				else if (Main.moonPhase > 5)
				{
					this.item[num].SetDefaults(1484, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(1483, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneCrimson)
				{
					this.item[num].SetDefaults(1492, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneCorrupt)
				{
					this.item[num].SetDefaults(1488, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneHoly)
				{
					this.item[num].SetDefaults(1489, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneJungle)
				{
					this.item[num].SetDefaults(1486, false);
					num++;
				}
				if (Main.player[Main.myPlayer].ZoneSnow)
				{
					this.item[num].SetDefaults(1487, false);
					num++;
				}
				if (Main.sandTiles > 1000)
				{
					this.item[num].SetDefaults(1491, false);
					num++;
				}
				if (Main.bloodMoon)
				{
					this.item[num].SetDefaults(1493, false);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.349999994039536)
				{
					this.item[num].SetDefaults(1485, false);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.349999994039536 && Main.hardMode)
				{
					this.item[num].SetDefaults(1494, false);
					num++;
				}
				if (Main.xMas)
				{
					for (int l = 1948; l <= 1957; l++)
					{
						this.item[num].SetDefaults(l, false);
						num++;
					}
				}
				for (int m = 2158; m <= 2160; m++)
				{
					if (num < 39)
					{
						this.item[num].SetDefaults(m, false);
					}
					num++;
				}
				for (int n = 2008; n <= 2014; n++)
				{
					if (num < 39)
					{
						this.item[num].SetDefaults(n, false);
					}
					num++;
				}
			}
			else if (type == 16)
			{
				this.item[num].SetDefaults(1430, false);
				num++;
				this.item[num].SetDefaults(986, false);
				num++;
				if (NPC.AnyNPCs(NPCID.Wizard))
				{
					int num25 = num;
					num = num25 + 1;
					this.item[num25].SetDefaults(2999, false);
				}
				if (Main.hardMode && NPC.downedPlantBoss)
				{
					if (Main.player[Main.myPlayer].HasItem(1157))
					{
						this.item[num].SetDefaults(1159, false);
						num++;
						this.item[num].SetDefaults(1160, false);
						num++;
						this.item[num].SetDefaults(1161, false);
						num++;
						if (!Main.dayTime)
						{
							this.item[num].SetDefaults(1158, false);
							num++;
						}
						if (Main.player[Main.myPlayer].ZoneJungle)
						{
							this.item[num].SetDefaults(1167, false);
							num++;
						}
					}
					this.item[num].SetDefaults(1339, false);
					num++;
				}
				if (Main.hardMode && Main.player[Main.myPlayer].ZoneJungle)
				{
					this.item[num].SetDefaults(1171, false);
					num++;
					if (!Main.dayTime)
					{
						this.item[num].SetDefaults(1162, false);
						num++;
					}
				}
				this.item[num].SetDefaults(909, false);
				num++;
				this.item[num].SetDefaults(910, false);
				num++;
				this.item[num].SetDefaults(940, false);
				num++;
				this.item[num].SetDefaults(941, false);
				num++;
				this.item[num].SetDefaults(942, false);
				num++;
				this.item[num].SetDefaults(943, false);
				num++;
				this.item[num].SetDefaults(944, false);
				num++;
				this.item[num].SetDefaults(945, false);
				num++;
				if (Main.player[Main.myPlayer].HasItem(1835))
				{
					this.item[num].SetDefaults(1836, false);
					num++;
				}
				if (Main.player[Main.myPlayer].HasItem(1258))
				{
					this.item[num].SetDefaults(1261, false);
					num++;
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1791, false);
					num++;
				}
			}
			else if (type == 17)
			{
				this.item[num].SetDefaults(928, false);
				num++;
				this.item[num].SetDefaults(929, false);
				num++;
				this.item[num].SetDefaults(876, false);
				num++;
				this.item[num].SetDefaults(877, false);
				num++;
				this.item[num].SetDefaults(878, false);
				num++;
				this.item[num].SetDefaults(2434, false);
				num++;
				int x = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
				if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10 && (x < 380 || x > Main.maxTilesX - 380))
				{
					this.item[num].SetDefaults(1180, false);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBossAny && NPC.AnyNPCs(NPCID.PartyGirl))
				{
					this.item[num].SetDefaults(1337, false);
					num++;
				}
			}
			else if (type == 18)
			{
				this.item[num].SetDefaults(1990, false);
				num++;
				this.item[num].SetDefaults(1979, false);
				num++;
				if (Main.player[Main.myPlayer].statLifeMax >= 400)
				{
					this.item[num].SetDefaults(1977, false);
					num++;
				}
				if (Main.player[Main.myPlayer].statManaMax >= 200)
				{
					this.item[num].SetDefaults(1978, false);
					num++;
				}
				long num26 = (long)0;
				for (int o = 0; o < 54; o++)
				{
					if (Main.player[Main.myPlayer].inventory[o].type == 71)
					{
						num26 = num26 + (long)Main.player[Main.myPlayer].inventory[o].stack;
					}
					if (Main.player[Main.myPlayer].inventory[o].type == 72)
					{
						num26 = num26 + (long)(Main.player[Main.myPlayer].inventory[o].stack * 100);
					}
					if (Main.player[Main.myPlayer].inventory[o].type == 73)
					{
						num26 = num26 + (long)(Main.player[Main.myPlayer].inventory[o].stack * 10000);
					}
					if (Main.player[Main.myPlayer].inventory[o].type == 74)
					{
						num26 = num26 + (long)(Main.player[Main.myPlayer].inventory[o].stack * 1000000);
					}
				}
				if (num26 >= (long)1000000)
				{
					this.item[num].SetDefaults(1980, false);
					num++;
				}
				if (Main.moonPhase % 2 == 0 && Main.dayTime || Main.moonPhase % 2 == 1 && !Main.dayTime)
				{
					this.item[num].SetDefaults(1981, false);
					num++;
				}
				if (Main.player[Main.myPlayer].team != 0)
				{
					this.item[num].SetDefaults(1982, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1983, false);
					num++;
				}
				if (NPC.AnyNPCs(NPCID.PartyGirl))
				{
					this.item[num].SetDefaults(1984, false);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
				{
					this.item[num].SetDefaults(1985, false);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBossAny)
				{
					this.item[num].SetDefaults(1986, false);
					num++;
				}
				if (Main.hardMode && NPC.downedMartians)
				{
					this.item[num].SetDefaults(2863, false);
					num++;
					this.item[num].SetDefaults(3259, false);
					num++;
				}
			}
			else if (type == 19)
			{
				for (int p = 0; p < 40; p++)
				{
					if (Main.travelShop[p] != 0)
					{
						this.item[num].netDefaults(Main.travelShop[p]);
						num++;
					}
				}
			}
			else if (type == 20)
			{
				if (Main.moonPhase % 2 != 0)
				{
					this.item[num].SetDefaults(28, false);
				}
				else
				{
					this.item[num].SetDefaults(3001, false);
				}
				num++;
				if (!Main.dayTime || Main.moonPhase == 0)
				{
					this.item[num].SetDefaults(3002, false);
				}
				else
				{
					this.item[num].SetDefaults(282, false);
				}
				num++;
				if (Main.time % 60 * 60 * 6 > 10800)
				{
					this.item[num].SetDefaults(8, false);
				}
				else
				{
					this.item[num].SetDefaults(3004, false);
				}
				num++;
				if (Main.moonPhase == 0 || Main.moonPhase == 1 || Main.moonPhase == 4 || Main.moonPhase == 5)
				{
					this.item[num].SetDefaults(3003, false);
				}
				else
				{
					this.item[num].SetDefaults(40, false);
				}
				num++;
				if (Main.moonPhase % 4 == 0)
				{
					this.item[num].SetDefaults(3310, false);
				}
				else if (Main.moonPhase % 4 == 1)
				{
					this.item[num].SetDefaults(3313, false);
				}
				else if (Main.moonPhase % 4 != 2)
				{
					this.item[num].SetDefaults(3311, false);
				}
				else
				{
					this.item[num].SetDefaults(3312, false);
				}
				num++;
				this.item[num].SetDefaults(166, false);
				num++;
				this.item[num].SetDefaults(965, false);
				num++;
				if (Main.hardMode)
				{
					if (Main.moonPhase >= 4)
					{
						this.item[num].SetDefaults(3315, false);
					}
					else
					{
						this.item[num].SetDefaults(3316, false);
					}
					num++;
					this.item[num].SetDefaults(3334, false);
					num++;
					if (Main.bloodMoon)
					{
						this.item[num].SetDefaults(3258, false);
						num++;
					}
				}
				if (Main.moonPhase == 0 && !Main.dayTime)
				{
					this.item[num].SetDefaults(3043, false);
					num++;
				}
			}
			if (Main.player[Main.myPlayer].discount)
			{
				for (int q = 0; q < num; q++)
				{
					this.item[q].@value = (int)((float)this.item[q].@value * 0.8f);
				}
			}
		}

		public static void SetupTravelShop()
		{
			for (int i = 0; i < 40; i++)
			{
				Main.travelShop[i] = 0;
			}
			int num = Main.rand.Next(4, 7);
			if (Main.rand.Next(4) == 0)
			{
				num++;
			}
			if (Main.rand.Next(8) == 0)
			{
				num++;
			}
			if (Main.rand.Next(16) == 0)
			{
				num++;
			}
			if (Main.rand.Next(32) == 0)
			{
				num++;
			}
			if (Main.expertMode && Main.rand.Next(2) == 0)
			{
				num++;
			}
			int num1 = 0;
			int num2 = 0;
			int[] numArray = new int[] { 100, 200, 300, 400, 500, 600 };
			while (num2 < num)
			{
				int num3 = 0;
				if (Main.rand.Next(numArray[4]) == 0)
				{
					num3 = 3309;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 3314;
				}
				if (Main.rand.Next(numArray[5]) == 0)
				{
					num3 = 1987;
				}
				if (Main.rand.Next(numArray[4]) == 0 && Main.hardMode)
				{
					num3 = 2270;
				}
				if (Main.rand.Next(numArray[4]) == 0)
				{
					num3 = 2278;
				}
				if (Main.rand.Next(numArray[4]) == 0)
				{
					num3 = 2271;
				}
				if (Main.rand.Next(numArray[3]) == 0 && Main.hardMode && NPC.downedPlantBoss)
				{
					num3 = 2223;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2272;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2219;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2276;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2284;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2285;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2286;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2287;
				}
				if (Main.rand.Next(numArray[3]) == 0)
				{
					num3 = 2296;
				}
				if (Main.rand.Next(numArray[2]) == 0 && WorldGen.shadowOrbSmashed)
				{
					num3 = 2269;
				}
				if (Main.rand.Next(numArray[2]) == 0)
				{
					num3 = 2177;
				}
				if (Main.rand.Next(numArray[2]) == 0)
				{
					num3 = 1988;
				}
				if (Main.rand.Next(numArray[2]) == 0)
				{
					num3 = 2275;
				}
				if (Main.rand.Next(numArray[2]) == 0)
				{
					num3 = 2279;
				}
				if (Main.rand.Next(numArray[2]) == 0)
				{
					num3 = 2277;
				}
				if (Main.rand.Next(numArray[2]) == 0 && NPC.downedBoss1)
				{
					num3 = 3262;
				}
				if (Main.rand.Next(numArray[2]) == 0 && NPC.downedMechBossAny)
				{
					num3 = 3284;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMoonlord)
				{
					num3 = 3596;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMartians)
				{
					num3 = 2865;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMartians)
				{
					num3 = 2866;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.hardMode && NPC.downedMartians)
				{
					num3 = 2867;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
				{
					num3 = 3055;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
				{
					num3 = 3056;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
				{
					num3 = 3057;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
				{
					num3 = 3058;
				}
				if (Main.rand.Next(numArray[2]) == 0 && Main.xMas)
				{
					num3 = 3059;
				}
				if (Main.rand.Next(numArray[1]) == 0)
				{
					num3 = 2214;
				}
				if (Main.rand.Next(numArray[1]) == 0)
				{
					num3 = 2215;
				}
				if (Main.rand.Next(numArray[1]) == 0)
				{
					num3 = 2216;
				}
				if (Main.rand.Next(numArray[1]) == 0)
				{
					num3 = 2217;
				}
				if (Main.rand.Next(numArray[1]) == 0)
				{
					num3 = 2273;
				}
				if (Main.rand.Next(numArray[1]) == 0)
				{
					num3 = 2274;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2266;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2267;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2268;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2281 + Main.rand.Next(3);
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2258;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2242;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 2260;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 3119;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 3118;
				}
				if (Main.rand.Next(numArray[0]) == 0)
				{
					num3 = 3099;
				}
				if (num3 != 0)
				{
					int num4 = 0;
					while (num4 < 40)
					{
						if (Main.travelShop[num4] != num3)
						{
							num4++;
						}
						else
						{
							num3 = 0;
							break;
						}
					}
				}
				if (num3 == 0)
				{
					continue;
				}
				num2++;
				Main.travelShop[num1] = num3;
				num1++;
				if (num3 != 2260)
				{
					continue;
				}
				Main.travelShop[num1] = 2261;
				num1++;
				Main.travelShop[num1] = 2262;
				num1++;
			}
		}

		public override string ToString()
		{
			int num = 0;
			for (int i = 0; i < (int)this.item.Length; i++)
			{
				if (this.item[i].stack > 0)
				{
					num++;
				}
			}
			return string.Format("{{X: {0}, Y: {1}, Count: {2}}}", this.x, this.y, num);
		}

		public static bool Unlock(int X, int Y)
		{
			short num;
			if (Main.tile[X, Y] == null)
			{
				return false;
			}
			int num2 = Main.tile[X, Y].frameX / 36;
			switch (num2)
			{
				case 2:
				{
					num = 36;
					AchievementsHelper.NotifyProgressionEvent(19);
					break;
				}
				case 3:
				{
					return false;
				}
				case 4:
				{
					num = 36;
					break;
				}
				default:
				{
					switch (num2)
					{
						case 23:
						case 24:
						case 25:
						case 26:
						case 27:
						{
							if (!NPC.downedPlantBoss)
							{
								return false;
							}
							num = 180;
							AchievementsHelper.NotifyProgressionEvent(20);
							break;
						}
						default:
						{
							switch (num2)
							{
								case 36:
								case 38:
								case 40:
								{
									num = 36;
									break;
								}
								case 37:
								case 39:
								{
									return false;
								}
								default:
								{
									return false;
								}
							}
							break;
						}
					}
					break;
				}
			}
			for (int i = X; i <= X + 1; i++)
			{
				for (int j = Y; j <= Y + 1; j++)
				{
					Tile tile = Main.tile[i, j];
					tile.frameX = (short)(tile.frameX - num);
				}
			}
			return true;
		}

		public static void UpdateChestFrames()
		{
		}

		public static int UsingChest(int i)
		{
			if (Main.chest[i] != null)
			{
				for (int num = 0; num < 255; num++)
				{
					if (Main.player[num].active && Main.player[num].chest == i)
					{
						return num;
					}
				}
			}
			return -1;
		}
	}
}
