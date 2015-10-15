
using System;
using Terraria;
using Terraria.ID;

namespace Terraria.GameContent.Events
{
	internal class CultistRitual
	{
		public const int delayStart = 86400;

		public const int respawnDelay = 43200;

		private const int timePerCultist = 3600;

		private const int recheckStart = 600;

		public static int delay;

		public static int recheck;

		static CultistRitual()
		{
		}

		public CultistRitual()
		{
		}

		public static bool CheckFloor(Vector2 Center, out Point[] spawnPoints)
		{
			Point[] point = new Point[4];
			int num = 0;
			Point tileCoordinates = Center.ToTileCoordinates();
			for (int i = -5; i <= 5; i = i + 2)
			{
				if (i != -1 && i != 1)
				{
					int num1 = -5;
					while (num1 < 12)
					{
						int x = tileCoordinates.X + i * 2;
						int y = tileCoordinates.Y + num1;
						if (!WorldGen.SolidTile(x, y) || Collision.SolidTiles(x - 1, x + 1, y - 3, y - 1))
						{
							num1++;
						}
						else
						{
							int num2 = num;
							num = num2 + 1;
							point[num2] = new Point(x, y);
							break;
						}
					}
				}
			}
			if (num != 4)
			{
				spawnPoints = null;
				return false;
			}
			spawnPoints = point;
			return true;
		}

		private static bool CheckRitual(int x, int y)
		{
			if (CultistRitual.delay != 0 || !Main.hardMode || !NPC.downedGolemBoss || !NPC.downedBoss3)
			{
				return false;
			}
			if (y < 7 || WorldGen.SolidTile(Main.tile[x, y - 7]))
			{
				return false;
			}
			if (NPC.AnyNPCs(NPCID.CultistTablet))
			{
				return false;
			}
			Vector2 vector2 = new Vector2((float)(x * 16 + 8), (float)(y * 16 - 64 - 8 - 27));
			Point[] pointArray = null;
			if (!CultistRitual.CheckFloor(vector2, out pointArray))
			{
				return false;
			}
			return true;
		}

		public static void CultistSlain()
		{
			CultistRitual.delay = CultistRitual.delay - 3600;
		}

		public static void TabletDestroyed()
		{
			CultistRitual.delay = 43200;
		}

		public static void TrySpawning(int x, int y)
		{
			if (WorldGen.PlayerLOS(x - 6, y) || WorldGen.PlayerLOS(x + 6, y))
			{
				return;
			}
			if (!CultistRitual.CheckRitual(x, y))
			{
				return;
			}
			NPC.NewNPC(x * 16 + 8, (y - 4) * 16 - 8, 437, 0, 0f, 0f, 0f, 0f, 255);
		}

		public static void UpdateTime()
		{
			if (Main.netMode == 1)
			{
				return;
			}
			CultistRitual.delay = CultistRitual.delay - Main.dayRate;
			if (CultistRitual.delay < 0)
			{
				CultistRitual.delay = 0;
			}
			CultistRitual.recheck = CultistRitual.recheck - Main.dayRate;
			if (CultistRitual.recheck < 0)
			{
				CultistRitual.recheck = 0;
			}
			if (CultistRitual.delay == 0 && CultistRitual.recheck == 0)
			{
				CultistRitual.recheck = 600;
				bool flag = false;
				if (!flag)
				{
					int num = 0;
					while (num < 200)
					{
						if (!Main.npc[num].active || !Main.npc[num].boss && !NPCID.Sets.TechnicallyABoss[Main.npc[num].type])
						{
							num++;
						}
						else
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					CultistRitual.recheck = CultistRitual.recheck * 6;
					return;
				}
				CultistRitual.TrySpawning(Main.dungeonX, Main.dungeonY);
			}
		}
	}
}
