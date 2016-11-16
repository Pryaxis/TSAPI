using System;
using System.Collections.Generic;
using System.IO;
using Terraria.ID;
using Terraria.Localization;
using Terraria.World.Generation;

namespace Terraria.GameContent.Events
{
	public class DD2Event
	{
		public static Rectangle ArenaHitbox = default(Rectangle);
		public static bool DownedInvasionT1 = false;
		public static bool DownedInvasionT2 = false;
		public static bool DownedInvasionT3 = false;
		private static readonly Color INFO_NEW_WAVE_COLOR = new Color(175, 55, 255);
		private static readonly Color INFO_START_INVASION_COLOR = new Color(50, 255, 130);
		private const int INVASION_ID = 3;
		public static int LaneSpawnRate = 60;
		public static bool LostThisRun = false;
		public static bool Ongoing = false;
		public static int OngoingDifficulty = 0;
		public static bool WonThisRun = false;
		private static int _arenaHitboxingCooldown = 0;
		private static int _crystalsDropping_alreadyDropped = 0;
		private static int _crystalsDropping_lastWave = 0;
		private static int _crystalsDropping_toDrop = 0;
		private static List<Vector2> _deadGoblinSpots = new List<Vector2>();
		private static bool _downedDarkMageT1 = false;
		private static bool _downedOgreT2 = false;
		private static bool _spawnedBetsyT3 = false;
		private static int _timeLeftUntilSpawningBegins = 0;

		public static void AnnounceGoblinDeath(NPC n)
		{
			DD2Event._deadGoblinSpots.Add(n.Bottom);
		}

		public static bool CanRaiseGoblinsHere(Vector2 spot)
		{
			int num = 0;
			foreach (Vector2 current in DD2Event._deadGoblinSpots)
			{
				if (Vector2.DistanceSquared(current, spot) <= 640000f)
				{
					num++;
					if (num >= 3)
					{
						return true;
					}
				}
			}
			return false;
		}
		
		public static void CheckProgress(int slainMonsterID)
		{
			if (Main.netMode == 1)
			{
				return;
			}
			if (!DD2Event.Ongoing)
			{
				return;
			}
			if (DD2Event.LostThisRun || DD2Event.WonThisRun)
			{
				return;
			}
			if (DD2Event.EnemySpawningIsOnHold)
			{
				return;
			}
			int num;
			int num2;
			int num3;
			DD2Event.GetInvasionStatus(out num, out num2, out num3, false);
			float num4 = (float)DD2Event.GetMonsterPointsWorth(slainMonsterID);
			float waveKills = NPC.waveKills;
			NPC.waveKills += num4;
			num3 += (int)num4;
			bool flag = false;
			int num5 = num;
			if (NPC.waveKills >= (float)num2 && num2 != 0)
			{
				NPC.waveKills = 0f;
				NPC.waveNumber++;
				flag = true;
				DD2Event.GetInvasionStatus(out num, out num2, out num3, true);
				if (DD2Event.WonThisRun)
				{
					if ((float)num3 != waveKills && num4 != 0f)
					{
						if (Main.netMode != 1)
						{
							Main.ReportInvasionProgress(num3, num2, 3, num);
						}
						if (Main.netMode == 2)
						{
							NetMessage.SendData(78, -1, -1, "", Main.invasionProgress, (float)Main.invasionProgressMax, 3f, (float)num, 0, 0, 0);
						}
					}
					return;
				}
				int num6 = num;
				string textValue = Language.GetTextValue("DungeonDefenders2.WaveComplete");
				if (textValue != "")
				{
					WorldGen.BroadcastText(textValue, DD2Event.INFO_NEW_WAVE_COLOR);
				}
				DD2Event.SetEnemySpawningOnHold(1800);
				if (DD2Event.OngoingDifficulty == 1)
				{
					if (num6 == 5)
					{
						DD2Event.DropMedals(1);
					}
					if (num6 == 4)
					{
						DD2Event.DropMedals(1);
					}
				}
				if (DD2Event.OngoingDifficulty == 2)
				{
					if (num6 == 7)
					{
						DD2Event.DropMedals(6);
					}
					if (num6 == 6)
					{
						DD2Event.DropMedals(3);
					}
					if (num6 == 5)
					{
						DD2Event.DropMedals(1);
					}
				}
				if (DD2Event.OngoingDifficulty == 3)
				{
					if (num6 == 7)
					{
						DD2Event.DropMedals(25);
					}
					if (num6 == 6)
					{
						DD2Event.DropMedals(11);
					}
					if (num6 == 5)
					{
						DD2Event.DropMedals(3);
					}
					if (num6 == 4)
					{
						DD2Event.DropMedals(1);
					}
				}
			}
			if ((float)num3 != waveKills)
			{
				if (flag)
				{
					int num7 = 1;
					int num8 = 1;
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress(num7, num8, 3, num5);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, "", num7, (float)num8, 3f, (float)num5, 0, 0, 0);
						return;
					}
				}
				else
				{
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress(num3, num2, 3, num);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, "", Main.invasionProgress, (float)Main.invasionProgressMax, 3f, (float)num, 0, 0, 0);
					}
				}
			}
		}

		public static void ClearAllDD2EnergyCrystalsInGame()
		{
			for (int i = 0; i < 400; i++)
			{
				Item item = Main.item[i];
				if (item.active && item.type == 3822)
				{
					item.active = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(21, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		public static void ClearAllDD2HostilesInGame()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && NPCID.Sets.BelongsToInvasionOldOnesArmy[Main.npc[i].type])
				{
					Main.npc[i].active = false;
					if (Main.netMode == 2)
					{
						NetMessage.SendData(23, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		public static void ClearAllTowersInGame()
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.projectile[i].active && ProjectileID.Sets.IsADD2Turret[Main.projectile[i].type])
				{
					Main.projectile[i].Kill();
				}
			}
		}

		private static short[] Difficulty_1_GetEnemiesForWave(int wave)
		{
			DD2Event.LaneSpawnRate = 60;
			switch (wave)
			{
				case 1:
					DD2Event.LaneSpawnRate = 90;
					return new short[]
					{
					552
					};
				case 2:
					return new short[]
					{
					552,
					555
					};
				case 3:
					DD2Event.LaneSpawnRate = 55;
					return new short[]
					{
					552,
					555,
					561
					};
				case 4:
					DD2Event.LaneSpawnRate = 50;
					return new short[]
					{
					552,
					555,
					561,
					558
					};
				case 5:
					DD2Event.LaneSpawnRate = 40;
					return new short[]
					{
					552,
					555,
					561,
					558,
					564
					};
				default:
					return new short[]
					{
					552
					};
			}
		}

		private static int Difficulty_1_GetMonsterPointsWorth(int slainMonsterID)
		{
			if (NPC.waveNumber != 5 || NPC.waveKills < 139f)
			{
				switch (slainMonsterID)
				{
					case 551:
					case 552:
					case 553:
					case 554:
					case 555:
					case 556:
					case 557:
					case 558:
					case 559:
					case 560:
					case 561:
					case 562:
					case 563:
					case 564:
					case 565:
					case 568:
					case 569:
					case 570:
					case 571:
					case 572:
					case 573:
					case 574:
					case 575:
					case 576:
					case 577:
					case 578:
						if (NPC.waveNumber == 5 && NPC.waveKills == 138f)
						{
							return 1;
						}
						if (!Main.expertMode)
						{
							return 1;
						}
						return 2;
				}
				return 0;
			}
			if (slainMonsterID == 564 || slainMonsterID == 565)
			{
				DD2Event._downedDarkMageT1 = true;
				return 1;
			}
			return 0;
		}

		private static int Difficulty_1_GetRequiredWaveKills(ref int waveNumber, ref int currentKillCount, bool currentlyInCheckProgress)
		{
			switch (waveNumber)
			{
				case -1:
					return 0;
				case 1:
					return 60;
				case 2:
					return 80;
				case 3:
					return 100;
				case 4:
					DD2Event._deadGoblinSpots.Clear();
					return 120;
				case 5:
					if (!DD2Event._downedDarkMageT1 && currentKillCount > 139)
					{
						currentKillCount = 139;
					}
					return 140;
				case 6:
					waveNumber = 5;
					currentKillCount = 1;
					if (currentlyInCheckProgress)
					{
						DD2Event.StartVictoryScene();
					}
					return 1;
			}
			return 10;
		}

		private static void Difficulty_1_SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int x = (int)gateBottom.X;
			int y = (int)gateBottom.Y;
			int num = 50;
			int num2 = 6;
			if (NPC.waveNumber > 4)
			{
				num2 = 12;
			}
			else if (NPC.waveNumber > 3)
			{
				num2 = 8;
			}
			int num3 = 6;
			if (NPC.waveNumber > 4)
			{
				num3 = 8;
			}
			for (int i = 1; i < Main.ActivePlayersCount; i++)
			{
				num = (int)((double)num * 1.3);
				num2 = (int)((double)num2 * 1.3);
				num3 = (int)((double)num3 * 1.3);
			}
			switch (NPC.waveNumber)
			{
				case 1:
					if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
					{
						NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 2:
					if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
					{
						if (Main.rand.Next(7) == 0)
						{
							NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 3:
					if (Main.rand.Next(6) == 0 && NPC.CountNPCS(561) < num2)
					{
						NPC.NewNPC(x, y, 561, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
					{
						if (Main.rand.Next(5) == 0)
						{
							NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 4:
					if (Main.rand.Next(12) == 0 && NPC.CountNPCS(558) < num3)
					{
						NPC.NewNPC(x, y, 558, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(5) == 0 && NPC.CountNPCS(561) < num2)
					{
						NPC.NewNPC(x, y, 561, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
					{
						if (Main.rand.Next(5) == 0)
						{
							NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 5:
					{
						int num4;
						int num5;
						int num6;
						DD2Event.GetInvasionStatus(out num4, out num5, out num6, false);
						if ((float)num6 > (float)num5 * 0.5f && !NPC.AnyNPCs(564))
						{
							NPC.NewNPC(x, y, 564, 0, 0f, 0f, 0f, 0f, 255);
						}
						if (Main.rand.Next(10) == 0 && NPC.CountNPCS(558) < num3)
						{
							NPC.NewNPC(x, y, 558, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (Main.rand.Next(4) == 0 && NPC.CountNPCS(561) < num2)
						{
							NPC.NewNPC(x, y, 561, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (NPC.CountNPCS(552) + NPC.CountNPCS(555) < num)
						{
							if (Main.rand.Next(4) == 0)
							{
								NPC.NewNPC(x, y, 555, 0, 0f, 0f, 0f, 0f, 255);
								return;
							}
							NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						break;
					}
				default:
					NPC.NewNPC(x, y, 552, 0, 0f, 0f, 0f, 0f, 255);
					break;
			}
		}

		private static short[] Difficulty_2_GetEnemiesForWave(int wave)
		{
			DD2Event.LaneSpawnRate = 60;
			switch (wave)
			{
				case 1:
					DD2Event.LaneSpawnRate = 90;
					return new short[]
					{
					553,
					562
					};
				case 2:
					DD2Event.LaneSpawnRate = 70;
					return new short[]
					{
					553,
					562,
					572
					};
				case 3:
					return new short[]
					{
					553,
					556,
					562,
					559,
					572
					};
				case 4:
					DD2Event.LaneSpawnRate = 55;
					return new short[]
					{
					553,
					559,
					570,
					572,
					562
					};
				case 5:
					DD2Event.LaneSpawnRate = 50;
					return new short[]
					{
					553,
					556,
					559,
					572,
					574,
					570
					};
				case 6:
					DD2Event.LaneSpawnRate = 45;
					return new short[]
					{
					553,
					556,
					562,
					559,
					568,
					570,
					572,
					574
					};
				case 7:
					DD2Event.LaneSpawnRate = 42;
					return new short[]
					{
					553,
					556,
					572,
					559,
					568,
					574,
					570,
					576
					};
				default:
					return new short[]
					{
					553
					};
			}
		}

		private static int Difficulty_2_GetMonsterPointsWorth(int slainMonsterID)
		{
			if (NPC.waveNumber != 7 || NPC.waveKills < 219f)
			{
				switch (slainMonsterID)
				{
					case 551:
					case 552:
					case 553:
					case 554:
					case 555:
					case 556:
					case 557:
					case 558:
					case 559:
					case 560:
					case 561:
					case 562:
					case 563:
					case 564:
					case 565:
					case 568:
					case 569:
					case 570:
					case 571:
					case 572:
					case 573:
					case 574:
					case 575:
					case 576:
					case 577:
					case 578:
						if (NPC.waveNumber == 7 && NPC.waveKills == 218f)
						{
							return 1;
						}
						if (!Main.expertMode)
						{
							return 1;
						}
						return 2;
				}
				return 0;
			}
			if (slainMonsterID == 576 || slainMonsterID == 577)
			{
				DD2Event._downedOgreT2 = true;
				return 1;
			}
			return 0;
		}

		private static int Difficulty_2_GetRequiredWaveKills(ref int waveNumber, ref int currentKillCount, bool currentlyInCheckProgress)
		{
			switch (waveNumber)
			{
				case -1:
					return 0;
				case 1:
					return 60;
				case 2:
					return 80;
				case 3:
					return 100;
				case 4:
					return 120;
				case 5:
					return 140;
				case 6:
					return 180;
				case 7:
					if (!DD2Event._downedOgreT2 && currentKillCount > 219)
					{
						currentKillCount = 219;
					}
					return 220;
				case 8:
					waveNumber = 7;
					currentKillCount = 1;
					if (currentlyInCheckProgress)
					{
						DD2Event.StartVictoryScene();
					}
					return 1;
			}
			return 10;
		}

		private static void Difficulty_2_SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int x = (int)gateBottom.X;
			int y = (int)gateBottom.Y;
			int num = 50;
			int num2 = 5;
			if (NPC.waveNumber > 1)
			{
				num2 = 8;
			}
			if (NPC.waveNumber > 3)
			{
				num2 = 10;
			}
			if (NPC.waveNumber > 5)
			{
				num2 = 12;
			}
			int num3 = 5;
			if (NPC.waveNumber > 4)
			{
				num3 = 7;
			}
			int num4 = 2;
			int num5 = 8;
			if (NPC.waveNumber > 3)
			{
				num5 = 12;
			}
			int num6 = 3;
			if (NPC.waveNumber > 5)
			{
				num6 = 5;
			}
			for (int i = 1; i < Main.ActivePlayersCount; i++)
			{
				num = (int)((double)num * 1.3);
				num2 = (int)((double)num2 * 1.3);
				num5 = (int)((double)num * 1.3);
				num6 = (int)((double)num * 1.35);
			}
			switch (NPC.waveNumber)
			{
				case 1:
					if (Main.rand.Next(20) == 0 && NPC.CountNPCS(562) < num2)
					{
						NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(553) < num)
					{
						NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 2:
					if (Main.rand.Next(3) == 0 && NPC.CountNPCS(572) < num5)
					{
						NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(8) == 0 && NPC.CountNPCS(562) < num2)
					{
						NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(553) < num)
					{
						NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 3:
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(572) < num5)
					{
						NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(10) == 0 && NPC.CountNPCS(559) < num3)
					{
						NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(8) == 0 && NPC.CountNPCS(562) < num2)
					{
						NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
					{
						if (Main.rand.Next(4) == 0)
						{
							NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
						}
						NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 4:
					if (Main.rand.Next(10) == 0 && NPC.CountNPCS(570) < num6)
					{
						NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(12) == 0 && NPC.CountNPCS(559) < num3)
					{
						NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(6) == 0 && NPC.CountNPCS(562) < num2)
					{
						NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(3) == 0 && NPC.CountNPCS(572) < num5)
					{
						NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(553) < num)
					{
						NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 5:
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
					{
						NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(10) == 0 && NPC.CountNPCS(559) < num3)
					{
						NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(4) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
					{
						if (Main.rand.Next(2) == 0)
						{
							NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 574, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					else if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
					{
						if (Main.rand.Next(3) == 0)
						{
							NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
						}
						NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 6:
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
					{
						NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(17) == 0 && NPC.CountNPCS(568) < num4)
					{
						NPC.NewNPC(x, y, 568, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(5) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
					{
						if (Main.rand.Next(2) != 0)
						{
							NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 574, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					else
					{
						if (Main.rand.Next(9) == 0 && NPC.CountNPCS(559) < num3)
						{
							NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (Main.rand.Next(3) == 0 && NPC.CountNPCS(562) < num2)
						{
							NPC.NewNPC(x, y, 562, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
						{
							if (Main.rand.Next(3) != 0)
							{
								NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
							}
							NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
					}
					break;
				case 7:
					{
						int num7;
						int num8;
						int num9;
						DD2Event.GetInvasionStatus(out num7, out num8, out num9, false);
						if ((float)num9 > (float)num8 * 0.1f && !NPC.AnyNPCs(576))
						{
							NPC.NewNPC(x, y, 576, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (Main.rand.Next(7) == 0 && NPC.CountNPCS(570) < num6)
						{
							NPC.NewNPC(x, y, 570, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (Main.rand.Next(17) == 0 && NPC.CountNPCS(568) < num4)
						{
							NPC.NewNPC(x, y, 568, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (Main.rand.Next(7) == 0 && NPC.CountNPCS(572) + NPC.CountNPCS(574) < num5)
						{
							if (Main.rand.Next(3) != 0)
							{
								NPC.NewNPC(x, y, 572, 0, 0f, 0f, 0f, 0f, 255);
								return;
							}
							NPC.NewNPC(x, y, 574, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						else
						{
							if (Main.rand.Next(11) == 0 && NPC.CountNPCS(559) < num3)
							{
								NPC.NewNPC(x, y, 559, 0, 0f, 0f, 0f, 0f, 255);
								return;
							}
							if (NPC.CountNPCS(553) + NPC.CountNPCS(556) < num)
							{
								if (Main.rand.Next(2) == 0)
								{
									NPC.NewNPC(x, y, 556, 0, 0f, 0f, 0f, 0f, 255);
								}
								NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
								return;
							}
						}
						break;
					}
				default:
					NPC.NewNPC(x, y, 553, 0, 0f, 0f, 0f, 0f, 255);
					break;
			}
		}

		private static short[] Difficulty_3_GetEnemiesForWave(int wave)
		{
			DD2Event.LaneSpawnRate = 60;
			switch (wave)
			{
				case 1:
					DD2Event.LaneSpawnRate = 85;
					return new short[]
					{
					554,
					557,
					563
					};
				case 2:
					DD2Event.LaneSpawnRate = 75;
					return new short[]
					{
					554,
					557,
					563,
					573,
					578
					};
				case 3:
					DD2Event.LaneSpawnRate = 60;
					return new short[]
					{
					554,
					563,
					560,
					573,
					571
					};
				case 4:
					DD2Event.LaneSpawnRate = 60;
					return new short[]
					{
					554,
					560,
					571,
					573,
					563,
					575,
					565
					};
				case 5:
					DD2Event.LaneSpawnRate = 55;
					return new short[]
					{
					554,
					557,
					573,
					575,
					571,
					569,
					577
					};
				case 6:
					DD2Event.LaneSpawnRate = 60;
					return new short[]
					{
					554,
					557,
					563,
					560,
					569,
					571,
					577,
					565
					};
				case 7:
					DD2Event.LaneSpawnRate = 90;
					return new short[]
					{
					554,
					557,
					563,
					569,
					571,
					551
					};
				default:
					return new short[]
					{
					554
					};
			}
		}

		private static int Difficulty_3_GetMonsterPointsWorth(int slainMonsterID)
		{
			if (NPC.waveNumber != 7)
			{
				switch (slainMonsterID)
				{
					case 551:
					case 552:
					case 553:
					case 554:
					case 555:
					case 556:
					case 557:
					case 558:
					case 559:
					case 560:
					case 561:
					case 562:
					case 563:
					case 564:
					case 565:
					case 568:
					case 569:
					case 570:
					case 571:
					case 572:
					case 573:
					case 574:
					case 575:
					case 576:
					case 577:
					case 578:
						if (!Main.expertMode)
						{
							return 1;
						}
						return 2;
				}
				return 0;
			}
			if (slainMonsterID == 551)
			{
				return 1;
			}
			return 0;
		}

		private static int Difficulty_3_GetRequiredWaveKills(ref int waveNumber, ref int currentKillCount, bool currentlyInCheckProgress)
		{
			switch (waveNumber)
			{
				case -1:
					return 0;
				case 1:
					return 60;
				case 2:
					return 80;
				case 3:
					return 100;
				case 4:
					return 120;
				case 5:
					return 140;
				case 6:
					return 180;
				case 7:
					{
						int num = NPC.FindFirstNPC(551);
						if (num == -1)
						{
							return 1;
						}
						currentKillCount = 100 - (int)((float)Main.npc[num].life / (float)Main.npc[num].lifeMax * 100f);
						return 100;
					}
				case 8:
					waveNumber = 7;
					currentKillCount = 1;
					if (currentlyInCheckProgress)
					{
						DD2Event.StartVictoryScene();
					}
					return 1;
			}
			return 10;
		}

		private static void Difficulty_3_SpawnMonsterFromGate(Vector2 gateBottom)
		{
			int x = (int)gateBottom.X;
			int y = (int)gateBottom.Y;
			int num = 60;
			int num2 = 7;
			if (NPC.waveNumber > 1)
			{
				num2 = 9;
			}
			if (NPC.waveNumber > 3)
			{
				num2 = 12;
			}
			if (NPC.waveNumber > 5)
			{
				num2 = 15;
			}
			int num3 = 7;
			if (NPC.waveNumber > 4)
			{
				num3 = 10;
			}
			int num4 = 2;
			if (NPC.waveNumber > 5)
			{
				num4 = 3;
			}
			int num5 = 12;
			if (NPC.waveNumber > 3)
			{
				num5 = 18;
			}
			int num6 = 4;
			if (NPC.waveNumber > 5)
			{
				num6 = 6;
			}
			int num7 = 4;
			for (int i = 1; i < Main.ActivePlayersCount; i++)
			{
				num = (int)((double)num * 1.3);
				num2 = (int)((double)num2 * 1.3);
				num5 = (int)((double)num * 1.3);
				num6 = (int)((double)num * 1.35);
				num7 = (int)((double)num7 * 1.3);
			}
			switch (NPC.waveNumber)
			{
				case 1:
					if (Main.rand.Next(18) == 0 && NPC.CountNPCS(563) < num2)
					{
						NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(554) < num)
					{
						if (Main.rand.Next(7) == 0)
						{
							NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
						}
						NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 2:
					if (Main.rand.Next(3) == 0 && NPC.CountNPCS(578) < num7)
					{
						NPC.NewNPC(x, y, 578, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(563) < num2)
					{
						NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(3) == 0 && NPC.CountNPCS(573) < num5)
					{
						NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(554) < num)
					{
						if (Main.rand.Next(4) == 0)
						{
							NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
						}
						NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 3:
					if (Main.rand.Next(13) == 0 && NPC.CountNPCS(571) < num6)
					{
						NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) < num5)
					{
						NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(10) == 0 && NPC.CountNPCS(560) < num3)
					{
						NPC.NewNPC(x, y, 560, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(8) == 0 && NPC.CountNPCS(563) < num2)
					{
						NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
					{
						NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 4:
					if (Main.rand.Next(24) == 0 && !NPC.AnyNPCs(565))
					{
						NPC.NewNPC(x, y, 565, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(12) == 0 && NPC.CountNPCS(571) < num6)
					{
						NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(15) == 0 && NPC.CountNPCS(560) < num3)
					{
						NPC.NewNPC(x, y, 560, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(563) < num2)
					{
						NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(5) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
					{
						if (Main.rand.Next(3) != 0)
						{
							NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 575, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					else if (NPC.CountNPCS(554) < num)
					{
						NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 5:
					if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(577))
					{
						NPC.NewNPC(x, y, 577, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(17) == 0 && NPC.CountNPCS(569) < num4)
					{
						NPC.NewNPC(x, y, 569, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(8) == 0 && NPC.CountNPCS(571) < num6)
					{
						NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
					{
						if (Main.rand.Next(4) != 0)
						{
							NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 575, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					else if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
					{
						if (Main.rand.Next(3) == 0)
						{
							NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
						}
						NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				case 6:
					if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(577))
					{
						NPC.NewNPC(x, y, 577, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(20) == 0 && !NPC.AnyNPCs(565))
					{
						NPC.NewNPC(x, y, 565, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(12) == 0 && NPC.CountNPCS(571) < num6)
					{
						NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(25) == 0 && NPC.CountNPCS(569) < num4)
					{
						NPC.NewNPC(x, y, 569, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(7) == 0 && NPC.CountNPCS(573) + NPC.CountNPCS(575) < num5)
					{
						if (Main.rand.Next(3) != 0)
						{
							NPC.NewNPC(x, y, 573, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						NPC.NewNPC(x, y, 575, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					else
					{
						if (Main.rand.Next(10) == 0 && NPC.CountNPCS(560) < num3)
						{
							NPC.NewNPC(x, y, 560, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (Main.rand.Next(5) == 0 && NPC.CountNPCS(563) < num2)
						{
							NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
						if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
						{
							if (Main.rand.Next(3) == 0)
							{
								NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
							}
							NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
							return;
						}
					}
					break;
				case 7:
					if (Main.rand.Next(20) == 0 && NPC.CountNPCS(571) < num6)
					{
						NPC.NewNPC(x, y, 571, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(17) == 0 && NPC.CountNPCS(569) < num4)
					{
						NPC.NewNPC(x, y, 569, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (Main.rand.Next(10) == 0 && NPC.CountNPCS(563) < num2)
					{
						NPC.NewNPC(x, y, 563, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					if (NPC.CountNPCS(554) + NPC.CountNPCS(557) < num)
					{
						if (Main.rand.Next(5) == 0)
						{
							NPC.NewNPC(x, y, 557, 0, 0f, 0f, 0f, 0f, 255);
						}
						NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
						return;
					}
					break;
				default:
					NPC.NewNPC(x, y, 554, 0, 0f, 0f, 0f, 0f, 255);
					break;
			}
		}

		public static void DropMedals(int numberOfMedals)
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 548)
				{
					Main.npc[i].DropItemInstanced(Main.npc[i].position, Main.npc[i].Size, 3817, numberOfMedals, false);
				}
			}
		}

		private static void DropStarterCrystals()
		{
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 548)
				{
					for (int j = 0; j < 5; j++)
					{
						Item.NewItem(Main.npc[i].position, Main.npc[i].width, Main.npc[i].height, 3822, 2, false, 0, false, false);
					}
					return;
				}
			}
		}

		public static void FailureMessage(int client)
		{
			string textValue = Language.GetTextValue("DungeonDefenders2.BartenderWarning");
			Color color = new Color(255, 255, 0);
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, client, -1, textValue, (int)color.R, (float)color.G, (float)color.B, 0f, 0, 0, 0);
				return;
			}
			Main.NewText(textValue, color.R, color.G, color.B, false);
		}

		public static void FindArenaHitbox()
		{
			if (DD2Event._arenaHitboxingCooldown > 0)
			{
				DD2Event._arenaHitboxingCooldown--;
				return;
			}
			DD2Event._arenaHitboxingCooldown = 60;
			Vector2 vector = new Vector2(3.40282347E+38f, 3.40282347E+38f);
			Vector2 value = new Vector2(0f, 0f);
			for (int i = 0; i < 200; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && (nPC.type == 549 || nPC.type == 548))
				{
					Vector2 vector2 = nPC.TopLeft;
					if (vector.X > vector2.X)
					{
						vector.X = vector2.X;
					}
					if (vector.Y > vector2.Y)
					{
						vector.Y = vector2.Y;
					}
					vector2 = nPC.BottomRight;
					if (value.X < vector2.X)
					{
						value.X = vector2.X;
					}
					if (value.Y < vector2.Y)
					{
						value.Y = vector2.Y;
					}
				}
			}
			Vector2 value2 = new Vector2(16f, 16f) * 50f;
			vector -= value2;
			value += value2;
			Vector2 vector3 = value - vector;
			DD2Event.ArenaHitbox.X = (int)vector.X;
			DD2Event.ArenaHitbox.Y = (int)vector.Y;
			DD2Event.ArenaHitbox.Width = (int)vector3.X;
			DD2Event.ArenaHitbox.Height = (int)vector3.Y;
		}

		private static void FindProperDifficulty()
		{
			DD2Event.OngoingDifficulty = 1;
			if (DD2Event.ReadyForTier2)
			{
				DD2Event.OngoingDifficulty = 2;
			}
			if (DD2Event.ReadyForTier3)
			{
				DD2Event.OngoingDifficulty = 3;
			}
		}

		private static short[] GetEnemiesForWave(int wave)
		{
			switch (DD2Event.OngoingDifficulty)
			{
				case 2:
					return DD2Event.Difficulty_2_GetEnemiesForWave(wave);
				case 3:
					return DD2Event.Difficulty_3_GetEnemiesForWave(wave);
				default:
					return DD2Event.Difficulty_1_GetEnemiesForWave(wave);
			}
		}

		private static void GetInvasionStatus(out int currentWave, out int requiredKillCount, out int currentKillCount, bool currentlyInCheckProgress = false)
		{
			currentWave = NPC.waveNumber;
			requiredKillCount = 10;
			currentKillCount = (int)NPC.waveKills;
			switch (DD2Event.OngoingDifficulty)
			{
				case 2:
					requiredKillCount = DD2Event.Difficulty_2_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
					return;
				case 3:
					requiredKillCount = DD2Event.Difficulty_3_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
					return;
				default:
					requiredKillCount = DD2Event.Difficulty_1_GetRequiredWaveKills(ref currentWave, ref currentKillCount, currentlyInCheckProgress);
					return;
			}
		}

		private static int GetMonsterPointsWorth(int slainMonsterID)
		{
			switch (DD2Event.OngoingDifficulty)
			{
				case 2:
					return DD2Event.Difficulty_2_GetMonsterPointsWorth(slainMonsterID);
				case 3:
					return DD2Event.Difficulty_3_GetMonsterPointsWorth(slainMonsterID);
				default:
					return DD2Event.Difficulty_1_GetMonsterPointsWorth(slainMonsterID);
			}
		}

		public static void Load(BinaryReader reader, int gameVersionNumber)
		{
			if (gameVersionNumber < 178)
			{
				NPC.savedBartender = false;
				DD2Event.ResetProgressEntirely();
				return;
			}
			NPC.savedBartender = reader.ReadBoolean();
			DD2Event.DownedInvasionT1 = reader.ReadBoolean();
			DD2Event.DownedInvasionT2 = reader.ReadBoolean();
			DD2Event.DownedInvasionT3 = reader.ReadBoolean();
		}

		public static void RaiseGoblins(Vector2 spot)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (Vector2 current in DD2Event._deadGoblinSpots)
			{
				if (Vector2.DistanceSquared(current, spot) <= 722500f)
				{
					list.Add(current);
				}
			}
			foreach (Vector2 current2 in list)
			{
				DD2Event._deadGoblinSpots.Remove(current2);
			}
			int num = 0;
			foreach (Vector2 current3 in list)
			{
				Point origin = current3.ToTileCoordinates();
				origin.X += Main.rand.Next(-15, 16);
				Point point;
				if (WorldUtils.Find(origin, Searches.Chain(new Searches.Down(50), new GenCondition[]
				{
					new Conditions.IsSolid()
				}), out point))
				{
					if (DD2Event.OngoingDifficulty == 3)
					{
						NPC.NewNPC(point.X * 16 + 8, point.Y * 16, 567, 0, 0f, 0f, 0f, 0f, 255);
					}
					else
					{
						NPC.NewNPC(point.X * 16 + 8, point.Y * 16, 566, 0, 0f, 0f, 0f, 0f, 255);
					}
					if (++num >= 8)
					{
						break;
					}
				}
			}
		}

		public static void ReportEventProgress()
		{
			int progressWave;
			int progressMax;
			int progress;
			DD2Event.GetInvasionStatus(out progressWave, out progressMax, out progress, false);
			Main.ReportInvasionProgress(progress, progressMax, 3, progressWave);
		}

		public static void ReportLoss()
		{
			DD2Event.LostThisRun = true;
			DD2Event.SetEnemySpawningOnHold(30);
		}

		public static void ResetProgressEntirely()
		{
			DD2Event.DownedInvasionT1 = (DD2Event.DownedInvasionT2 = (DD2Event.DownedInvasionT3 = false));
			DD2Event.Ongoing = false;
			DD2Event.ArenaHitbox = default(Rectangle);
			DD2Event._arenaHitboxingCooldown = 0;
			DD2Event._timeLeftUntilSpawningBegins = 0;
		}

		public static void Save(BinaryWriter writer)
		{
			writer.Write(DD2Event.DownedInvasionT1);
			writer.Write(DD2Event.DownedInvasionT2);
			writer.Write(DD2Event.DownedInvasionT3);
		}

		private static void SetEnemySpawningOnHold(int forHowLong)
		{
			DD2Event._timeLeftUntilSpawningBegins = forHowLong;
			if (Main.netMode == 2)
			{
				NetMessage.SendData(116, -1, -1, "", DD2Event._timeLeftUntilSpawningBegins, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static bool ShouldBlockBuilding(Vector2 worldPosition)
		{
			return DD2Event.ArenaHitbox.Contains(worldPosition.ToPoint());
		}

		public static bool ShouldDropCrystals()
		{
			int num;
			int num2;
			int num3;
			DD2Event.GetInvasionStatus(out num, out num2, out num3, false);
			if (DD2Event._crystalsDropping_lastWave < num)
			{
				DD2Event._crystalsDropping_lastWave++;
				if (DD2Event._crystalsDropping_alreadyDropped > 0)
				{
					DD2Event._crystalsDropping_alreadyDropped -= DD2Event._crystalsDropping_toDrop;
				}
				if (DD2Event.OngoingDifficulty == 1)
				{
					switch (num)
					{
						case 1:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 2:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 3:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
						case 4:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
						case 5:
							DD2Event._crystalsDropping_toDrop = 40;
							break;
					}
				}
				else if (DD2Event.OngoingDifficulty == 2)
				{
					switch (num)
					{
						case 1:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 2:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 3:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 4:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 5:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 6:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
						case 7:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
					}
				}
				else if (DD2Event.OngoingDifficulty == 3)
				{
					switch (num)
					{
						case 1:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 2:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 3:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 4:
							DD2Event._crystalsDropping_toDrop = 20;
							break;
						case 5:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
						case 6:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
						case 7:
							DD2Event._crystalsDropping_toDrop = 30;
							break;
					}
				}
			}
			float num4 = (float)num3 / (float)num2;
			if ((float)DD2Event._crystalsDropping_alreadyDropped < (float)DD2Event._crystalsDropping_toDrop * num4)
			{
				DD2Event._crystalsDropping_alreadyDropped++;
				return true;
			}
			return false;
		}

		public static void SpawnMonsterFromGate(Vector2 gateBottom)
		{
			switch (DD2Event.OngoingDifficulty)
			{
				case 2:
					DD2Event.Difficulty_2_SpawnMonsterFromGate(gateBottom);
					return;
				case 3:
					DD2Event.Difficulty_3_SpawnMonsterFromGate(gateBottom);
					return;
				default:
					DD2Event.Difficulty_1_SpawnMonsterFromGate(gateBottom);
					return;
			}
		}

		public static void SpawnNPC(ref int newNPC)
		{
		}

		public static void StartInvasion(int difficultyOverride = -1)
		{
			if (Main.netMode != 1)
			{
				DD2Event._crystalsDropping_toDrop = 0;
				DD2Event._crystalsDropping_alreadyDropped = 0;
				DD2Event._crystalsDropping_lastWave = 0;
				DD2Event._timeLeftUntilSpawningBegins = 0;
				DD2Event.Ongoing = true;
				DD2Event.FindProperDifficulty();
				if (difficultyOverride != -1)
				{
					DD2Event.OngoingDifficulty = difficultyOverride;
				}
				DD2Event._deadGoblinSpots.Clear();
				DD2Event._downedDarkMageT1 = false;
				DD2Event._downedOgreT2 = false;
				DD2Event._spawnedBetsyT3 = false;
				DD2Event.LostThisRun = false;
				DD2Event.WonThisRun = false;
				NPC.waveKills = 0f;
				NPC.waveNumber = 1;
				DD2Event.ClearAllTowersInGame();
				string textValue = Language.GetTextValue("DungeonDefenders2.InvasionStart");
				WorldGen.BroadcastText(textValue, DD2Event.INFO_START_INVASION_COLOR);
				NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
				if (Main.netMode != 1)
				{
					Main.ReportInvasionProgress(0, 1, 3, 1);
				}
				if (Main.netMode == 2)
				{
					NetMessage.SendData(78, -1, -1, "", 0, 1f, 3f, 1f, 0, 0, 0);
				}
				DD2Event.SetEnemySpawningOnHold(300);
				DD2Event.WipeEntities();
			}
		}

		public static void StartVictoryScene()
		{
			DD2Event.WonThisRun = true;
			int num = NPC.FindFirstNPC(548);
			if (num == -1)
			{
				return;
			}
			Main.npc[num].ai[1] = 2f;
			Main.npc[num].ai[0] = 2f;
			Main.npc[num].netUpdate = true;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i] != null && Main.npc[i].active && Main.npc[i].type == 549)
				{
					Main.npc[i].ai[0] = 0f;
					Main.npc[i].ai[1] = 1f;
					Main.npc[i].netUpdate = true;
				}
			}
		}

		public static void StopInvasion(bool win = false)
		{
			if (DD2Event.Ongoing)
			{
				if (win)
				{
					DD2Event.WinInvasionInternal();
				}
				DD2Event.Ongoing = false;
				DD2Event._deadGoblinSpots.Clear();
				if (Main.netMode != 1)
				{
					NPC.waveKills = 0f;
					NPC.waveNumber = 0;
					DD2Event.WipeEntities();
					NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
				}
			}
		}

		private static void SummonBetsy()
		{
			if (DD2Event._spawnedBetsyT3)
			{
				return;
			}
			if (NPC.AnyNPCs(551))
			{
				return;
			}
			Vector2 center = new Vector2(1f, 1f);
			int num = NPC.FindFirstNPC(548);
			if (num != -1)
			{
				center = Main.npc[num].Center;
			}
			int plr = (int)Player.FindClosest(center, 1, 1);
			NPC.SpawnOnPlayer(plr, 551);
			DD2Event._spawnedBetsyT3 = true;
		}

		public static void SummonCrystal(int x, int y)
		{
			if (Main.netMode == 1)
			{
				NetMessage.SendData(113, -1, -1, "", x, (float)y, 0f, 0f, 0, 0, 0);
				return;
			}
			DD2Event.SummonCrystalDirect(x, y);
		}

		public static void SummonCrystalDirect(int x, int y)
		{
			if (NPC.AnyNPCs(548))
			{
				return;
			}
			Tile tileSafely = Framing.GetTileSafely(x, y);
			if (!tileSafely.active() || tileSafely.type != 466)
			{
				return;
			}
			Point point = new Point(x * 16, y * 16);
			point.X -= (int)(tileSafely.frameX / 18 * 16);
			point.Y -= (int)(tileSafely.frameY / 18 * 16);
			point.X += 40;
			point.Y += 64;
			DD2Event.StartInvasion(-1);
			NPC.NewNPC(point.X, point.Y, 548, 0, 0f, 0f, 0f, 0f, 255);
			DD2Event.DropStarterCrystals();
		}

		public static void SyncInvasionProgress(int toWho)
		{
			int num;
			int num2;
			int number;
			DD2Event.GetInvasionStatus(out num, out num2, out number, false);
			NetMessage.SendData(78, toWho, -1, "", number, (float)num2, 3f, (float)num, 0, 0, 0);
		}

		public static void UpdateTime()
		{
			if (!DD2Event.Ongoing && !Main.dedServ)
			{
				return;
			}
			if (Main.netMode != 1 && !NPC.AnyNPCs(548))
			{
				DD2Event.StopInvasion(false);
			}
			if (Main.netMode == 1)
			{
				if (DD2Event._timeLeftUntilSpawningBegins > 0)
				{
					DD2Event._timeLeftUntilSpawningBegins--;
				}
				if (DD2Event._timeLeftUntilSpawningBegins < 0)
				{
					DD2Event._timeLeftUntilSpawningBegins = 0;
				}
				return;
			}
			if (DD2Event._timeLeftUntilSpawningBegins > 0)
			{
				DD2Event._timeLeftUntilSpawningBegins--;
				if (DD2Event._timeLeftUntilSpawningBegins == 0)
				{
					int num;
					int progressMax;
					int progress;
					DD2Event.GetInvasionStatus(out num, out progressMax, out progress, false);
					string invasionWaveText = Lang.GetInvasionWaveText(num, DD2Event.GetEnemiesForWave(num));
					if (invasionWaveText != "")
					{
						WorldGen.BroadcastText(invasionWaveText, DD2Event.INFO_NEW_WAVE_COLOR);
					}
					if (num == 7 && DD2Event.OngoingDifficulty == 3)
					{
						DD2Event.SummonBetsy();
					}
					if (Main.netMode != 1)
					{
						Main.ReportInvasionProgress(progress, progressMax, 3, num);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendData(78, -1, -1, "", Main.invasionProgress, (float)Main.invasionProgressMax, 3f, (float)num, 0, 0, 0);
					}
				}
			}
			if (DD2Event._timeLeftUntilSpawningBegins < 0)
			{
				DD2Event._timeLeftUntilSpawningBegins = 0;
			}
		}

		private static void WinInvasionInternal()
		{
			if (DD2Event.OngoingDifficulty <= 1)
			{
				DD2Event.DownedInvasionT1 = true;
			}
			if (DD2Event.OngoingDifficulty <= 2)
			{
				DD2Event.DownedInvasionT2 = true;
			}
			if (DD2Event.OngoingDifficulty <= 3)
			{
				DD2Event.DownedInvasionT3 = true;
			}
			if (DD2Event.OngoingDifficulty == 1)
			{
				DD2Event.DropMedals(3);
			}
			if (DD2Event.OngoingDifficulty == 2)
			{
				DD2Event.DropMedals(15);
			}
			if (DD2Event.OngoingDifficulty == 3)
			{
				DD2Event.DropMedals(60);
			}
			string textValue = Language.GetTextValue("DungeonDefenders2.InvasionWin");
			WorldGen.BroadcastText(textValue, DD2Event.INFO_START_INVASION_COLOR);
		}

		public static void WipeEntities()
		{
			DD2Event.ClearAllTowersInGame();
			DD2Event.ClearAllDD2HostilesInGame();
			if (Main.netMode == 2)
			{
				NetMessage.SendData(114, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
			}
		}

		public static bool WouldFailSpawningHere(int x, int y)
		{
			Point point;
			Point point2;
			StrayMethods.CheckArenaScore(new Point(x, y).ToWorldCoordinates(8f, 8f), out point, out point2, 5, 10);
			int num = point2.X - x;
			int num2 = x - point.X;
			return num < 60 || num2 < 60;
		}

		public static bool DownedInvasionAnyDifficulty
		{
			get
			{
				return DD2Event.DownedInvasionT1 || DD2Event.DownedInvasionT2 || DD2Event.DownedInvasionT3;
			}
		}

		public static bool EnemiesShouldChasePlayers
		{
			get
			{
				bool arg_05_0 = DD2Event.Ongoing;
				return true;
			}
		}

		public static bool EnemySpawningIsOnHold
		{
			get
			{
				return DD2Event._timeLeftUntilSpawningBegins != 0;
			}
		}

		public static bool ReadyForTier2
		{
			get
			{
				return Main.hardMode && NPC.downedMechBossAny;
			}
		}

		public static bool ReadyForTier3
		{
			get
			{
				return Main.hardMode && NPC.downedGolemBoss;
			}
		}

		public static bool ReadyToFindBartender
		{
			get
			{
				return NPC.downedBoss2;
			}
		}

		public static int TimeLeftBetweenWaves
		{
			get
			{
				return DD2Event._timeLeftUntilSpawningBegins;
			}

			set
			{
				DD2Event._timeLeftUntilSpawningBegins = value;
			}
		}
	}
}
