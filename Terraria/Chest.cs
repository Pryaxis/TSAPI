using System;

namespace Terraria
{
	public class Chest
	{
		public const int MaxNameLength = 20;
		public static int deferredChestID;
		public static Chest deferredChest;
		public static int maxChestTypes = 31;
		public static int[] typeToIcon = new int[Chest.maxChestTypes];
		public static int[] itemSpawn = new int[Chest.maxChestTypes];
		public static int maxItems = 40;
		public Item[] item;
		public int x;
		public int y;
		public bool bankChest;
		public string name;
		public Chest(bool bank = false)
		{
			this.item = new Item[Chest.maxItems];
			this.bankChest = bank;
			this.name = string.Empty;
		}
		public static void Initialize()
		{
			Chest.typeToIcon[0] = (Chest.itemSpawn[0] = 48);
			Chest.typeToIcon[1] = (Chest.itemSpawn[1] = 306);
			Chest.typeToIcon[2] = 327;
			Chest.itemSpawn[2] = 306;
			Chest.typeToIcon[3] = (Chest.itemSpawn[3] = 328);
			Chest.typeToIcon[4] = 329;
			Chest.itemSpawn[4] = 328;
			Chest.typeToIcon[5] = (Chest.itemSpawn[5] = 343);
			Chest.typeToIcon[6] = (Chest.itemSpawn[6] = 348);
			Chest.typeToIcon[7] = (Chest.itemSpawn[7] = 625);
			Chest.typeToIcon[8] = (Chest.itemSpawn[8] = 626);
			Chest.typeToIcon[9] = (Chest.itemSpawn[9] = 627);
			Chest.typeToIcon[10] = (Chest.itemSpawn[10] = 680);
			Chest.typeToIcon[11] = (Chest.itemSpawn[11] = 681);
			Chest.typeToIcon[12] = (Chest.itemSpawn[12] = 831);
			Chest.typeToIcon[13] = (Chest.itemSpawn[13] = 838);
			Chest.typeToIcon[14] = (Chest.itemSpawn[14] = 914);
			Chest.typeToIcon[15] = (Chest.itemSpawn[15] = 952);
			Chest.typeToIcon[16] = (Chest.itemSpawn[16] = 1142);
			Chest.typeToIcon[17] = (Chest.itemSpawn[17] = 1298);
			Chest.typeToIcon[18] = (Chest.itemSpawn[18] = 1528);
			Chest.typeToIcon[19] = (Chest.itemSpawn[19] = 1529);
			Chest.typeToIcon[20] = (Chest.itemSpawn[20] = 1530);
			Chest.typeToIcon[21] = (Chest.itemSpawn[21] = 1531);
			Chest.typeToIcon[22] = (Chest.itemSpawn[22] = 1532);
			Chest.typeToIcon[23] = 1533;
			Chest.itemSpawn[23] = 1528;
			Chest.typeToIcon[24] = 1534;
			Chest.itemSpawn[24] = 1529;
			Chest.typeToIcon[25] = 1535;
			Chest.itemSpawn[25] = 1530;
			Chest.typeToIcon[26] = 1536;
			Chest.itemSpawn[26] = 1531;
			Chest.typeToIcon[27] = 1537;
			Chest.itemSpawn[27] = 1532;
			Chest.typeToIcon[28] = (Chest.itemSpawn[28] = 2230);
			Chest.typeToIcon[29] = (Chest.itemSpawn[29] = 2249);
			Chest.typeToIcon[30] = (Chest.itemSpawn[30] = 2250);
		}
		public object Clone()
		{
			return base.MemberwiseClone();
		}
		public static void Unlock(int X, int Y)
		{
			Main.PlaySound(22, X * 16, Y * 16, 1);
			for (int i = X; i <= X + 1; i++)
			{
				for (int j = Y; j <= Y + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						Main.tile[i, j] = new Tile();
					}
					if ((Main.tile[i, j].frameX >= 72 && Main.tile[i, j].frameX <= 106) || (Main.tile[i, j].frameX >= 144 && Main.tile[i, j].frameX <= 178))
					{
						Tile expr_A3 = Main.tile[i, j];
						expr_A3.frameX = (short)(expr_A3.frameX - 36);
						for (int k = 0; k < 4; k++)
						{
							Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 11, 0f, 0f, 0, default(Color), 1f);
						}
					}
					else if (Main.tile[i, j].frameX >= 828 && Main.tile[i, j].frameX <= 990)
					{
						Tile expr_134 = Main.tile[i, j];
						expr_134.frameX = (short)(expr_134.frameX - 180);
						for (int l = 0; l < 4; l++)
						{
							Dust.NewDust(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16, 11, 0f, 0f, 0, default(Color), 1f);
						}
					}
				}
			}
		}
		public static int UsingChest(int i)
		{
			if (Main.chest[i] != null)
			{
				for (int j = 0; j < 255; j++)
				{
					if (Main.player[j].active && Main.player[j].chest == i)
					{
						return j;
					}
				}
			}
			return -1;
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
		public static int CreateChest(int X, int Y, int id = -1)
		{
			int num = id;
			if (num == -1)
			{
				for (int i = 0; i < 1000; i++)
				{
					if (Main.chest[i] != null)
					{
						if (Main.chest[i].x == X && Main.chest[i].y == Y)
						{
							return -1;
						}
					}
					else if (num == -1)
					{
						num = i;
					}
				}
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
			for (int j = 0; j < Chest.maxItems; j++)
			{
				Main.chest[num].item[j] = new Item();
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
					for (int j = 0; j < Chest.maxItems; j++)
					{
						if (chest.item[j] != null && chest.item[j].type > 0 && chest.item[j].stack > 0)
						{
							return false;
						}
					}
					Main.chest[i] = null;
					return true;
				}
			}
			return true;
		}
		public static void DestroyChestDirect(int X, int Y, int id)
		{
			Chest chest = Main.chest[id];
			if (chest == null)
			{
				return;
			}
			if (chest.x != X || chest.y != Y)
			{
				return;
			}
			Main.chest[id] = null;
		}
		public void AddShop(Item newItem)
		{
			int i = 0;
			while (i < 39)
			{
				if (this.item[i] == null || this.item[i].type == 0)
				{
					this.item[i] = newItem.Clone();
					this.item[i].buyOnce = true;
					if (this.item[i].value <= 0)
					{
						break;
					}
					this.item[i].value = this.item[i].value / 5;
					if (this.item[i].value < 1)
					{
						this.item[i].value = 1;
						return;
					}
					break;
				}
				else
				{
					i++;
				}
			}
		}
		public static void SetupTravelShop()
		{
			for (int i = 0; i < Chest.maxItems; i++)
			{
				Main.travelShop[i] = 0;
			}
			int num = Main.rand.Next(4, 7);
			if (Main.rand.Next(5) == 0)
			{
				num++;
			}
			if (Main.rand.Next(10) == 0)
			{
				num++;
			}
			if (Main.rand.Next(20) == 0)
			{
				num++;
			}
			if (Main.rand.Next(40) == 0)
			{
				num++;
			}
			int num2 = 0;
			int j = 0;
			int[] array = new int[]
			{
				100,
				200,
				300,
				400,
				500,
				800
			};
			while (j < num)
			{
				int num3 = 0;
				if (Main.rand.Next(array[5]) == 0)
				{
					num3 = 1987;
				}
				if (Main.rand.Next(array[4]) == 0 && Main.hardMode)
				{
					num3 = 2270;
				}
				if (Main.rand.Next(array[4]) == 0)
				{
					num3 = 2278;
				}
				if (Main.rand.Next(array[4]) == 0)
				{
					num3 = 2271;
				}
				if (Main.rand.Next(array[3]) == 0 && Main.hardMode && NPC.downedPlantBoss)
				{
					num3 = 2223;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2272;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2219;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2276;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2284;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2285;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2286;
				}
				if (Main.rand.Next(array[3]) == 0)
				{
					num3 = 2287;
				}
				if (Main.rand.Next(array[2]) == 0 && WorldGen.shadowOrbSmashed)
				{
					num3 = 2269;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2177;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 1988;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2275;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2279;
				}
				if (Main.rand.Next(array[2]) == 0)
				{
					num3 = 2277;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2214;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2215;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2216;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2217;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2273;
				}
				if (Main.rand.Next(array[1]) == 0)
				{
					num3 = 2274;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2266;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2267;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2268;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2258;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2242;
				}
				if (Main.rand.Next(array[0]) == 0)
				{
					num3 = 2260;
				}
				if (num3 != 0)
				{
					for (int k = 0; k < Chest.maxItems; k++)
					{
						if (Main.travelShop[k] == num3)
						{
							num3 = 0;
							break;
						}
					}
				}
				if (num3 != 0)
				{
					j++;
					Main.travelShop[num2] = num3;
					num2++;
					if (num3 == 2260)
					{
						Main.travelShop[num2] = 2261;
						num2++;
						Main.travelShop[num2] = 2262;
						num2++;
					}
				}
			}
		}
		public void SetupShop(int type)
		{
			for (int i = 0; i < Chest.maxItems; i++)
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
				if (Main.player[Main.myPlayer].zoneSnow)
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
				for (int j = 0; j < 58; j++)
				{
					if (Main.player[Main.myPlayer].inventory[j].type == 930)
					{
						this.item[num].SetDefaults(931, false);
						num++;
						this.item[num].SetDefaults(1614, false);
						num++;
						break;
					}
				}
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1786, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1348, false);
					num++;
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
				if ((NPC.downedBoss2 && !Main.dayTime) || Main.hardMode)
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
				if (Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						this.item[num].SetDefaults(2171, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(67, false);
						num++;
						this.item[num].SetDefaults(59, false);
						num++;
					}
				}
				else
				{
					this.item[num].SetDefaults("Purification Powder");
					num++;
					this.item[num].SetDefaults("Grass Seeds");
					num++;
					this.item[num].SetDefaults("Sunflower");
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
				}
				if (Main.player[Main.myPlayer].zoneSnow)
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
				this.item[num].SetDefaults(849, false);
				num++;
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
				for (int k = 1873; k < 1906; k++)
				{
					this.item[num].SetDefaults(k, false);
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
				}
				num++;
				this.item[num].SetDefaults(1181, false);
				num++;
				this.item[num].SetDefaults(783, false);
				num++;
			}
			else if (type == 11)
			{
				this.item[num].SetDefaults(779, false);
				num++;
				if (Main.moonPhase >= 4)
				{
					this.item[num].SetDefaults(748, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(839, false);
					num++;
					this.item[num].SetDefaults(840, false);
					num++;
					this.item[num].SetDefaults(841, false);
					num++;
				}
				if (Main.dayTime)
				{
					this.item[num].SetDefaults(998, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(995, false);
					num++;
				}
				if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3)
				{
					this.item[num].SetDefaults(2203, false);
					num++;
				}
				if (WorldGen.crimson)
				{
					this.item[num].SetDefaults(2193, false);
					num++;
				}
				this.item[num].SetDefaults(1263, false);
				num++;
				if (Main.eclipse || Main.bloodMoon)
				{
					if (WorldGen.crimson)
					{
						this.item[num].SetDefaults(784, false);
						num++;
					}
					else
					{
						this.item[num].SetDefaults(782, false);
						num++;
					}
				}
				else if (Main.player[Main.myPlayer].zoneHoly)
				{
					this.item[num].SetDefaults(781, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(780, false);
					num++;
				}
				if (Main.hardMode)
				{
					this.item[num].SetDefaults(1344, false);
				}
				num++;
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
				this.item[num].SetDefaults(1120, false);
				num++;
				if (Main.netMode == 1)
				{
					this.item[num].SetDefaults(1969, false);
				}
				num++;
				if (Main.halloween)
				{
					this.item[num].SetDefaults(1741, false);
					num++;
				}
			}
			else if (type == 13)
			{
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
				if (Main.hardMode)
				{
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
			}
			else if (type == 15)
			{
				this.item[num].SetDefaults(1071, false);
				num++;
				this.item[num].SetDefaults(1072, false);
				num++;
				this.item[num].SetDefaults(1100, false);
				num++;
				for (int l = 1073; l <= 1084; l++)
				{
					this.item[num].SetDefaults(l, false);
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
				else if (Main.moonPhase <= 5)
				{
					this.item[num].SetDefaults(1483, false);
					num++;
				}
				else
				{
					this.item[num].SetDefaults(1484, false);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneBlood)
				{
					this.item[num].SetDefaults(1492, false);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneEvil)
				{
					this.item[num].SetDefaults(1488, false);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneHoly)
				{
					this.item[num].SetDefaults(1489, false);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneJungle)
				{
					this.item[num].SetDefaults(1486, false);
					num++;
				}
				if (Main.player[Main.myPlayer].zoneSnow)
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
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.34999999403953552)
				{
					this.item[num].SetDefaults(1485, false);
					num++;
				}
				if ((double)(Main.player[Main.myPlayer].position.Y / 16f) < Main.worldSurface * 0.34999999403953552 && Main.hardMode)
				{
					this.item[num].SetDefaults(1494, false);
					num++;
				}
				if (Main.xMas)
				{
					for (int m = 1948; m <= 1957; m++)
					{
						this.item[num].SetDefaults(m, false);
						num++;
					}
				}
				for (int n = 2158; n <= 2160; n++)
				{
					if (num < 39)
					{
						this.item[num].SetDefaults(n, false);
					}
					num++;
				}
				for (int num2 = 2008; num2 <= 2014; num2++)
				{
					if (num < 39)
					{
						this.item[num].SetDefaults(num2, false);
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
						if (Main.player[Main.myPlayer].zoneJungle)
						{
							this.item[num].SetDefaults(1167, false);
							num++;
						}
					}
					this.item[num].SetDefaults(1339, false);
					num++;
				}
				if (Main.hardMode && Main.player[Main.myPlayer].zoneJungle)
				{
					this.item[num].SetDefaults(1171, false);
					num++;
					if (!Main.dayTime)
					{
						this.item[num].SetDefaults(1162, false);
						num++;
					}
				}
				if (Main.hardMode && NPC.downedPlantBoss)
				{
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
				}
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
				int num3 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
				if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0 && (num3 < 380 || num3 > Main.maxTilesX - 380))
				{
					this.item[num].SetDefaults(1180, false);
					num++;
				}
				if (Main.hardMode && NPC.downedMechBossAny && NPC.AnyNPCs(208))
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
				}
				num++;
				int num4 = 0;
				for (int num5 = 0; num5 < 54; num5++)
				{
					if (Main.player[Main.myPlayer].inventory[num5].type == 71)
					{
						num4 += Main.player[Main.myPlayer].inventory[num5].stack;
					}
					if (Main.player[Main.myPlayer].inventory[num5].type == 72)
					{
						num4 += Main.player[Main.myPlayer].inventory[num5].stack * 100;
					}
					if (Main.player[Main.myPlayer].inventory[num5].type == 73)
					{
						num4 += Main.player[Main.myPlayer].inventory[num5].stack * 10000;
					}
					if (Main.player[Main.myPlayer].inventory[num5].type == 74)
					{
						num4 += Main.player[Main.myPlayer].inventory[num5].stack * 1000000;
					}
				}
				if (num4 >= 1000000)
				{
					this.item[num].SetDefaults(1980, false);
					num++;
				}
				if ((Main.moonPhase % 2 == 0 && Main.dayTime) || (Main.moonPhase % 2 == 1 && !Main.dayTime))
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
				if (NPC.AnyNPCs(208))
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
			}
			else if (type == 19)
			{
				for (int num6 = 0; num6 < Chest.maxItems; num6++)
				{
					if (Main.travelShop[num6] != 0)
					{
						this.item[num].netDefaults(Main.travelShop[num6]);
						num++;
					}
				}
			}
			if (Main.player[Main.myPlayer].discount)
			{
				for (int num7 = 0; num7 < num; num7++)
				{
					this.item[num7].value = (int)((float)this.item[num7].value * 0.8f);
				}
			}
		}
	}
}
