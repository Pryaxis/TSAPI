using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using TerrariaApi.Server;

namespace Terraria.IO
{
	public class WorldFile
	{
		private static object padlock;

		public static double tempTime;

		private static bool Temp_Sandstorm_Happening = false;

		private static float Temp_Sandstorm_IntendedSeverity = 0f;

		private static float Temp_Sandstorm_Severity = 0f;

		private static int Temp_Sandstorm_TimeLeft = 0;

		public static bool tempRaining;

		public static float tempMaxRain;

		public static int tempRainTime;

		public static bool tempDayTime;

		public static bool tempBloodMoon;

		public static bool tempEclipse;

		public static int tempMoonPhase;

		public static int tempCultistDelay;

		public static int versionNumber;

		public static bool IsWorldOnCloud;

		public static bool tempPartyGenuine = false;

		public static bool tempPartyManual = false;

		public static int tempPartyCooldown = 0;

		public static List<int> tempPartyCelebratingNPCs = new List<int>();

		private static bool HasCache;

		private static bool? CachedDayTime;

		private static double? CachedTime;

		private static bool? Cached_Sandstorm_Happening = null;

		private static float? Cached_Sandstorm_IntendedSeverity = null;

		private static float? Cached_Sandstorm_Severity = null;

		private static int? Cached_Sandstorm_TimeLeft = null;

		private static int? CachedMoonPhase;

		private static bool? CachedBloodMoon;

		private static bool? CachedEclipse;

		private static int? CachedCultistDelay;

		private static bool? CachedPartyGenuine = null;

		private static bool? CachedPartyManual = null;

		private static int? CachedPartyDaysOnCooldown = null;

		private static List<int> CachedCelebratingNPCs = new List<int>();

		static WorldFile()
		{
			WorldFile.padlock = new object();
			WorldFile.tempTime = Main.time;
			WorldFile.tempRaining = false;
			WorldFile.tempMaxRain = 0f;
			WorldFile.tempRainTime = 0;
			WorldFile.tempDayTime = Main.dayTime;
			WorldFile.tempBloodMoon = Main.bloodMoon;
			WorldFile.tempEclipse = Main.eclipse;
			WorldFile.tempMoonPhase = Main.moonPhase;
			WorldFile.tempCultistDelay = CultistRitual.delay;
			WorldFile.IsWorldOnCloud = false;
			WorldFile.HasCache = false;
			WorldFile.CachedDayTime = null;
			WorldFile.CachedTime = null;
			WorldFile.CachedMoonPhase = null;
			WorldFile.CachedBloodMoon = null;
			WorldFile.CachedEclipse = null;
			WorldFile.CachedCultistDelay = null;
		}

		public WorldFile()
		{
		}

		public static void CacheSaveTime()
		{
			WorldFile.HasCache = true;
			WorldFile.CachedDayTime = new bool?(Main.dayTime);
			WorldFile.CachedTime = new double?(Main.time);
			WorldFile.CachedMoonPhase = new int?(Main.moonPhase);
			WorldFile.CachedBloodMoon = new bool?(Main.bloodMoon);
			WorldFile.CachedEclipse = new bool?(Main.eclipse);
			WorldFile.CachedCultistDelay = new int?(CultistRitual.delay);
			WorldFile.CachedPartyGenuine = new bool?(BirthdayParty.GenuineParty);
			WorldFile.CachedPartyManual = new bool?(BirthdayParty.ManualParty);
			WorldFile.CachedPartyDaysOnCooldown = new int?(BirthdayParty.PartyDaysOnCooldown);
			WorldFile.CachedCelebratingNPCs.Clear();
			WorldFile.CachedCelebratingNPCs.AddRange(BirthdayParty.CelebratingNPCs);
			WorldFile.Cached_Sandstorm_Happening = new bool?(Sandstorm.Happening);
			WorldFile.Cached_Sandstorm_TimeLeft = new int?(Sandstorm.TimeLeft);
			WorldFile.Cached_Sandstorm_Severity = new float?(Sandstorm.Severity);
			WorldFile.Cached_Sandstorm_IntendedSeverity = new float?(Sandstorm.IntendedSeverity);
		}

		public static WorldFileData CreateMetadata(string name, bool isExpertMode)
		{
			WorldFileData worldFileDatum = new WorldFileData(Main.GetWorldPathFromName(name))
			{
				Name = name,
				IsExpertMode = isExpertMode,
				CreationTime = DateTime.Now,
				Metadata = FileMetadata.FromCurrentSettings(FileType.World),
				WorldGeneratorVersion = 790273982465uL,
				UniqueId = Guid.NewGuid()
			};
			if (Main.DefaultSeed == "")
			{
				worldFileDatum.SetSeedToRandom();
			}
			else
			{
				worldFileDatum.SetSeed(Main.DefaultSeed);
			}
			return worldFileDatum;
		}

		public static void FixDresserChests()
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					if (tile.active() && tile.type == 88 && tile.frameX % 54 == 0 && tile.frameY % 36 == 0)
					{
						Chest.CreateChest(i, j, -1);
					}
				}
			}
		}

		public static WorldFileData GetAllMetadata(string file)
		{
			Stream memoryStream;
			if (file == null || !File.Exists(file))
			{
				return null;
			}
			try
			{
				WorldFileData worldFileDatum = new WorldFileData(file);

				memoryStream = new FileStream(file, FileMode.Open);

				using (Stream stream = memoryStream)
				{
					using (BinaryReader binaryReader = new BinaryReader(stream))
					{
						int num = binaryReader.ReadInt32();
						if (num < 135)
						{
							worldFileDatum.Metadata = FileMetadata.FromCurrentSettings(FileType.World);
						}
						else
						{
							worldFileDatum.Metadata = FileMetadata.Read(binaryReader, FileType.World);
						}
						if (num <= 184)
						{
							binaryReader.ReadInt16();
							stream.Position = (long)binaryReader.ReadInt32();
							worldFileDatum.Name = binaryReader.ReadString();
							if (num >= 179)
							{
								string seed;
								if (num == 179)
								{
									seed = binaryReader.ReadInt32().ToString();
								}
								else
								{
									seed = binaryReader.ReadString();
								}
								worldFileDatum.SetSeed(seed);
								worldFileDatum.WorldGeneratorVersion = binaryReader.ReadUInt64();
							}
							else
							{
								worldFileDatum.SetSeedToEmpty();
								worldFileDatum.WorldGeneratorVersion = 0uL;
							}
							if (num >= 181)
							{
								worldFileDatum.UniqueId = new Guid(binaryReader.ReadBytes(16));
							}
							else
							{
								worldFileDatum.UniqueId = Guid.Empty;
							}
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							int num1 = binaryReader.ReadInt32();
							worldFileDatum.SetWorldSize(binaryReader.ReadInt32(), num1);
							worldFileDatum.IsExpertMode = (num < 112 ? false : binaryReader.ReadBoolean());
							if (num >= 141)
							{
								worldFileDatum.CreationTime = DateTime.FromBinary(binaryReader.ReadInt64());
							}
							else
							{
								worldFileDatum.CreationTime = File.GetCreationTime(file);
							}
							binaryReader.ReadByte();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadDouble();
							binaryReader.ReadDouble();
							binaryReader.ReadDouble();
							binaryReader.ReadBoolean();
							binaryReader.ReadInt32();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							worldFileDatum.HasCrimson = binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							if (num >= 118)
							{
								binaryReader.ReadBoolean();
							}
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadBoolean();
							binaryReader.ReadByte();
							binaryReader.ReadInt32();
							worldFileDatum.IsHardMode = binaryReader.ReadBoolean();
							return worldFileDatum;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception during world metadata load.");
				Console.WriteLine("If you are using -autocreate, it is safe to ignore this.");
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

#endif
			}
			return new WorldFileData();
		}

		public static FileMetadata GetFileMetadata(string file)
		{
			FileMetadata fileMetadatum;
			if (file == null)
			{
				return null;
			}
			try
			{
				using (Stream stream = new FileStream(file, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(stream))
					{
						fileMetadatum = (binaryReader.ReadInt32() < 135 ? FileMetadata.FromCurrentSettings(FileType.World) : FileMetadata.Read(binaryReader, FileType.World));
					}
				}
			}
			catch
			{
			}
			return null;
		}

		public static bool GetWorldDifficulty(string WorldFileName)
		{
			if (WorldFileName == null)
			{
				return false;
			}
			try
			{
				using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						int num = binaryReader.ReadInt32();
						if (num >= 135)
						{
							binaryReader.BaseStream.Position += 20L;
						}
						if (num >= 112 && num <= 184)
						{
							binaryReader.ReadInt16();
							fileStream.Position = (long)binaryReader.ReadInt32();
							binaryReader.ReadString();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							binaryReader.ReadInt32();
							return binaryReader.ReadBoolean();
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
			return false;
		}

		public static string GetWorldName(string WorldFileName)
		{
			if (WorldFileName == null)
			{
				return string.Empty;
			}
			try
			{
				using (FileStream fileStream = new FileStream(WorldFileName, FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						int num = binaryReader.ReadInt32();
						if (num > 0 && num <= 184)
						{
							string text;
							string result;
							if (num <= 87)
							{
								text = binaryReader.ReadString();
								binaryReader.Close();
								result = text;
								return result;
							}
							if (num >= 135)
							{
								binaryReader.BaseStream.Position += 20L;
							}
							binaryReader.ReadInt16();
							fileStream.Position = (long)binaryReader.ReadInt32();
							text = binaryReader.ReadString();
							binaryReader.Close();
							result = text;
							return result;
						}
					}
				}
			}
			catch
			{
			}
			string[] array = WorldFileName.Split(new char[]
			{
				Path.DirectorySeparatorChar
			});
			string text2 = array[array.Length - 1];
			return text2.Substring(0, text2.Length - 4);
		}

		public static bool IsValidWorld(string file, bool cloudSave)
		{
			return WorldFile.GetFileMetadata(file) != null;
		}

		private static void LoadChests(BinaryReader reader)
		{
			short num;
			int i;
			int j;
			int num1;
			int num2;
			Chest chest = null;
			int num3 = reader.ReadInt16();
			int num4 = reader.ReadInt16();
			if (num4 >= 40)
			{
				num1 = 40;
				num2 = num4 - 40;
			}
			else
			{
				num1 = num4;
				num2 = 0;
			}
			for (i = 0; i < num3; i++)
			{
				chest = new Chest(false)
				{
					x = reader.ReadInt32(),
					y = reader.ReadInt32(),
					name = reader.ReadString()
				};
				for (j = 0; j < num1; j++)
				{
					num = reader.ReadInt16();
					Item item = new Item();
					if (num > 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.stack = num;
						item.Prefix((int)reader.ReadByte());
					}
					else if (num < 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.Prefix((int)reader.ReadByte());
						item.stack = 1;
					}
					chest.item[j] = item;
				}
				for (j = 0; j < num2; j++)
				{
					num = reader.ReadInt16();
					if (num > 0)
					{
						reader.ReadInt32();
						reader.ReadByte();
					}
				}
				Main.chest[i] = chest;
			}
			while (i < 1000)
			{
				Main.chest[i] = null;
				i++;
			}
			if (WorldFile.versionNumber < 115)
			{
				WorldFile.FixDresserChests();
			}
		}

		private static void LoadDummies(BinaryReader reader)
		{
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				TargetDummy.dummies[i] = new TargetDummy(reader.ReadInt16(), reader.ReadInt16());
			}
			for (int j = num; j < 1000; j++)
			{
				TargetDummy.dummies[j] = null;
			}
		}

		private static bool LoadFileFormatHeader(BinaryReader reader, out bool[] importance, out int[] positions)
		{
			int i;
			importance = null;
			positions = null;
			int num = reader.ReadInt32();
			WorldFile.versionNumber = num;
			if (num < 135)
			{
				Main.WorldFileMetadata = FileMetadata.FromCurrentSettings(FileType.World);
			}
			else
			{
				try
				{
					Main.WorldFileMetadata = FileMetadata.Read(reader, FileType.World);
				}
				catch (Exception fileFormatException1)
				{
					Console.WriteLine(Language.GetTextValue("Error.UnableToLoadWorld:"));
					Console.WriteLine(fileFormatException1);
					return false;
				}
			}
			short num1 = reader.ReadInt16();
			positions = new int[num1];
			for (i = 0; i < num1; i++)
			{
				positions[i] = reader.ReadInt32();
			}
			short num2 = reader.ReadInt16();
			importance = new bool[num2];
			byte num3 = 0;
			byte num4 = 128;
			for (i = 0; i < num2; i++)
			{
				if (num4 != 128)
				{
					num4 = (byte)(num4 << 1);
				}
				else
				{
					num3 = reader.ReadByte();
					num4 = 1;
				}
				if ((num3 & num4) == num4)
				{
					importance[i] = true;
				}
			}
			return true;
		}

		private static int LoadFooter(BinaryReader reader)
		{
			if (!reader.ReadBoolean())
			{
				return 6;
			}
			if (reader.ReadString() != Main.worldName)
			{
				return 6;
			}
			if (reader.ReadInt32() != Main.worldID)
			{
				return 6;
			}
			return 0;
		}

		private static void LoadHeader(BinaryReader reader)
		{
			int num = WorldFile.versionNumber;
			Main.worldName = reader.ReadString();
			if (num >= 179)
			{
				string seed;
				if (num == 179)
				{
					seed = reader.ReadInt32().ToString();
				}
				else
				{
					seed = reader.ReadString();
				}
				Main.ActiveWorldFileData.SetSeed(seed);
				Main.ActiveWorldFileData.WorldGeneratorVersion = reader.ReadUInt64();
			}
			if (num >= 181)
			{
				Main.ActiveWorldFileData.UniqueId = new Guid(reader.ReadBytes(16));
			}
			else
			{
				Main.ActiveWorldFileData.UniqueId = Guid.NewGuid();
			}
			Main.worldID = reader.ReadInt32();
			Main.leftWorld = (float)reader.ReadInt32();
			Main.rightWorld = (float)reader.ReadInt32();
			Main.topWorld = (float)reader.ReadInt32();
			Main.bottomWorld = (float)reader.ReadInt32();
			Main.maxTilesY = reader.ReadInt32();
			Main.maxTilesX = reader.ReadInt32();
			WorldGen.clearWorld();
			if (num < 112)
			{
				Main.expertMode = false;
			}
			else
			{
				Main.expertMode = reader.ReadBoolean();
			}
			if (num >= 141)
			{
				Main.ActiveWorldFileData.CreationTime = DateTime.FromBinary(reader.ReadInt64());
			}
			Main.moonType = reader.ReadByte();
			Main.treeX[0] = reader.ReadInt32();
			Main.treeX[1] = reader.ReadInt32();
			Main.treeX[2] = reader.ReadInt32();
			Main.treeStyle[0] = reader.ReadInt32();
			Main.treeStyle[1] = reader.ReadInt32();
			Main.treeStyle[2] = reader.ReadInt32();
			Main.treeStyle[3] = reader.ReadInt32();
			Main.caveBackX[0] = reader.ReadInt32();
			Main.caveBackX[1] = reader.ReadInt32();
			Main.caveBackX[2] = reader.ReadInt32();
			Main.caveBackStyle[0] = reader.ReadInt32();
			Main.caveBackStyle[1] = reader.ReadInt32();
			Main.caveBackStyle[2] = reader.ReadInt32();
			Main.caveBackStyle[3] = reader.ReadInt32();
			Main.iceBackStyle = reader.ReadInt32();
			Main.jungleBackStyle = reader.ReadInt32();
			Main.hellBackStyle = reader.ReadInt32();
			Main.spawnTileX = reader.ReadInt32();
			Main.spawnTileY = reader.ReadInt32();
			Main.worldSurface = reader.ReadDouble();
			Main.rockLayer = reader.ReadDouble();
			WorldFile.tempTime = reader.ReadDouble();
			WorldFile.tempDayTime = reader.ReadBoolean();
			WorldFile.tempMoonPhase = reader.ReadInt32();
			WorldFile.tempBloodMoon = reader.ReadBoolean();
			WorldFile.tempEclipse = reader.ReadBoolean();
			Main.eclipse = WorldFile.tempEclipse;
			Main.dungeonX = reader.ReadInt32();
			Main.dungeonY = reader.ReadInt32();
			WorldGen.crimson = reader.ReadBoolean();
			NPC.downedBoss1 = reader.ReadBoolean();
			NPC.downedBoss2 = reader.ReadBoolean();
			NPC.downedBoss3 = reader.ReadBoolean();
			NPC.downedQueenBee = reader.ReadBoolean();
			NPC.downedMechBoss1 = reader.ReadBoolean();
			NPC.downedMechBoss2 = reader.ReadBoolean();
			NPC.downedMechBoss3 = reader.ReadBoolean();
			NPC.downedMechBossAny = reader.ReadBoolean();
			NPC.downedPlantBoss = reader.ReadBoolean();
			NPC.downedGolemBoss = reader.ReadBoolean();
			if (num >= 118)
			{
				NPC.downedSlimeKing = reader.ReadBoolean();
			}
			NPC.savedGoblin = reader.ReadBoolean();
			NPC.savedWizard = reader.ReadBoolean();
			NPC.savedMech = reader.ReadBoolean();
			NPC.downedGoblins = reader.ReadBoolean();
			NPC.downedClown = reader.ReadBoolean();
			NPC.downedFrost = reader.ReadBoolean();
			NPC.downedPirates = reader.ReadBoolean();
			WorldGen.shadowOrbSmashed = reader.ReadBoolean();
			WorldGen.spawnMeteor = reader.ReadBoolean();
			WorldGen.shadowOrbCount = reader.ReadByte();
			WorldGen.altarCount = reader.ReadInt32();
			Main.hardMode = reader.ReadBoolean();
			Main.invasionDelay = reader.ReadInt32();
			Main.invasionSize = reader.ReadInt32();
			Main.invasionType = reader.ReadInt32();
			Main.invasionX = reader.ReadDouble();
			if (num >= 118)
			{
				Main.slimeRainTime = reader.ReadDouble();
			}
			if (num >= 113)
			{
				Main.sundialCooldown = reader.ReadByte();
			}
			WorldFile.tempRaining = reader.ReadBoolean();
			WorldFile.tempRainTime = reader.ReadInt32();
			WorldFile.tempMaxRain = reader.ReadSingle();
			WorldGen.oreTier1 = reader.ReadInt32();
			WorldGen.oreTier2 = reader.ReadInt32();
			WorldGen.oreTier3 = reader.ReadInt32();
			WorldGen.setBG(0, (int)reader.ReadByte());
			WorldGen.setBG(1, (int)reader.ReadByte());
			WorldGen.setBG(2, (int)reader.ReadByte());
			WorldGen.setBG(3, (int)reader.ReadByte());
			WorldGen.setBG(4, (int)reader.ReadByte());
			WorldGen.setBG(5, (int)reader.ReadByte());
			WorldGen.setBG(6, (int)reader.ReadByte());
			WorldGen.setBG(7, (int)reader.ReadByte());
			Main.cloudBGActive = (float)reader.ReadInt32();
			Main.cloudBGAlpha = ((double)Main.cloudBGActive < 1 ? 0f : 1f);
			Main.cloudBGActive = (float)(-WorldGen.genRand.Next(8640, 86400));
			Main.numClouds = reader.ReadInt16();
			Main.windSpeedSet = reader.ReadSingle();
			Main.windSpeed = Main.windSpeedSet;
			if (num < 95)
			{
				return;
			}
			Main.anglerWhoFinishedToday.Clear();
			for (int i = reader.ReadInt32(); i > 0; i--)
			{
				Main.anglerWhoFinishedToday.Add(reader.ReadString());
			}
			if (num < 99)
			{
				return;
			}
			NPC.savedAngler = reader.ReadBoolean();
			if (num < 101)
			{
				return;
			}
			Main.anglerQuest = reader.ReadInt32();
			if (num < 104)
			{
				return;
			}
			NPC.savedStylist = reader.ReadBoolean();
			if (num >= 129)
			{
				NPC.savedTaxCollector = reader.ReadBoolean();
			}
			if (num >= 107)
			{
				Main.invasionSizeStart = reader.ReadInt32();
			}
			else if (Main.invasionType > 0 && Main.invasionSize > 0)
			{
				Main.FakeLoadInvasionStart();
			}
			if (num >= 108)
			{
				WorldFile.tempCultistDelay = reader.ReadInt32();
			}
			else
			{
				WorldFile.tempCultistDelay = 86400;
			}
			if (num < 109)
			{
				return;
			}
			int num1 = reader.ReadInt16();
			for (int j = 0; j < num1; j++)
			{
				if (j >= Main.maxNPCTypes)
				{
					reader.ReadInt32();
				}
				else
				{
					NPC.killCount[j] = reader.ReadInt32();
				}
			}
			if (num < 128)
			{
				return;
			}
			Main.fastForwardTime = reader.ReadBoolean();
			Main.UpdateSundial();
			if (num < 131)
			{
				return;
			}
			NPC.downedFishron = reader.ReadBoolean();
			NPC.downedMartians = reader.ReadBoolean();
			NPC.downedAncientCultist = reader.ReadBoolean();
			NPC.downedMoonlord = reader.ReadBoolean();
			NPC.downedHalloweenKing = reader.ReadBoolean();
			NPC.downedHalloweenTree = reader.ReadBoolean();
			NPC.downedChristmasIceQueen = reader.ReadBoolean();
			NPC.downedChristmasSantank = reader.ReadBoolean();
			NPC.downedChristmasTree = reader.ReadBoolean();
			if (num < 140)
			{
				return;
			}
			NPC.downedTowerSolar = reader.ReadBoolean();
			NPC.downedTowerVortex = reader.ReadBoolean();
			NPC.downedTowerNebula = reader.ReadBoolean();
			NPC.downedTowerStardust = reader.ReadBoolean();
			NPC.TowerActiveSolar = reader.ReadBoolean();
			NPC.TowerActiveVortex = reader.ReadBoolean();
			NPC.TowerActiveNebula = reader.ReadBoolean();
			NPC.TowerActiveStardust = reader.ReadBoolean();
			NPC.LunarApocalypseIsUp = reader.ReadBoolean();
			if (NPC.TowerActiveSolar)
			{
				NPC.ShieldStrengthTowerSolar = NPC.ShieldStrengthTowerMax;
			}
			if (NPC.TowerActiveVortex)
			{
				NPC.ShieldStrengthTowerVortex = NPC.ShieldStrengthTowerMax;
			}
			if (NPC.TowerActiveNebula)
			{
				NPC.ShieldStrengthTowerNebula = NPC.ShieldStrengthTowerMax;
			}
			if (NPC.TowerActiveStardust)
			{
				NPC.ShieldStrengthTowerStardust = NPC.ShieldStrengthTowerMax;
			}
			if (num < 170)
			{
				WorldFile.tempPartyManual = false;
				WorldFile.tempPartyGenuine = false;
				WorldFile.tempPartyCooldown = 0;
				WorldFile.tempPartyCelebratingNPCs.Clear();
			}
			else
			{
				WorldFile.tempPartyManual = reader.ReadBoolean();
				WorldFile.tempPartyGenuine = reader.ReadBoolean();
				WorldFile.tempPartyCooldown = reader.ReadInt32();
				int num3 = reader.ReadInt32();
				WorldFile.tempPartyCelebratingNPCs.Clear();
				for (int k = 0; k < num3; k++)
				{
					WorldFile.tempPartyCelebratingNPCs.Add(reader.ReadInt32());
				}
			}
			if (num < 174)
			{
				WorldFile.Temp_Sandstorm_Happening = false;
				WorldFile.Temp_Sandstorm_TimeLeft = 0;
				WorldFile.Temp_Sandstorm_Severity = 0f;
				WorldFile.Temp_Sandstorm_IntendedSeverity = 0f;
				return;
			}
			else
			{
				WorldFile.Temp_Sandstorm_Happening = reader.ReadBoolean();
				WorldFile.Temp_Sandstorm_TimeLeft = reader.ReadInt32();
				WorldFile.Temp_Sandstorm_Severity = reader.ReadSingle();
				WorldFile.Temp_Sandstorm_IntendedSeverity = reader.ReadSingle();
			}
			DD2Event.Load(reader, num);
		}

		private static void LoadNPCs(BinaryReader reader)
		{
			bool i;
			NPC nPC;
			int num = 0;
			for (i = reader.ReadBoolean(); i; i = reader.ReadBoolean())
			{
				nPC = Main.npc[num];
				nPC.SetDefaults(reader.ReadString());
				nPC.displayName = reader.ReadString();
				nPC.position.X = reader.ReadSingle();
				nPC.position.Y = reader.ReadSingle();
				nPC.homeless = reader.ReadBoolean();
				nPC.homeTileX = reader.ReadInt32();
				nPC.homeTileY = reader.ReadInt32();
				num++;
			}
			if (WorldFile.versionNumber < 140)
			{
				return;
			}
			for (i = reader.ReadBoolean(); i; i = reader.ReadBoolean())
			{
				nPC = Main.npc[num];
				nPC.SetDefaults(reader.ReadString());
				nPC.position = reader.ReadVector2();
				num++;
			}
		}

		private static void LoadSigns(BinaryReader reader)
		{
			short num = reader.ReadInt16();
			int i;
			for (i = 0; i < (int)num; i++)
			{
				string text = reader.ReadString();
				int num2 = reader.ReadInt32();
				int num3 = reader.ReadInt32();
				Tile tile = Main.tile[num2, num3];
				Sign sign;
				if (tile.active() && Main.tileSign[(int)tile.type])
				{
					sign = new Sign();
					sign.text = text;
					sign.x = num2;
					sign.y = num3;
				}
				else
				{
					sign = null;
				}
				Main.sign[i] = sign;
			}
			List<Point16> list = new List<Point16>();
			for (int j = 0; j < 1000; j++)
			{
				if (Main.sign[j] != null)
				{
					Point16 item = new Point16(Main.sign[j].x, Main.sign[j].y);
					if (list.Contains(item))
					{
						Main.sign[j] = null;
					}
					else
					{
						list.Add(item);
					}
				}
			}
			while (i < 1000)
			{
				Main.sign[i] = null;
				i++;
			}
		}

		private static void LoadTileEntities(BinaryReader reader)
		{
			TileEntity.ByID.Clear();
			TileEntity.ByPosition.Clear();
			int num = reader.ReadInt32();
			int num1 = 0;
			for (int i = 0; i < num; i++)
			{
				TileEntity tileEntity = TileEntity.Read(reader);
				tileEntity.ID = num1++;
				TileEntity.ByID[tileEntity.ID] = tileEntity;
				TileEntity tileEntity2;
				if (TileEntity.ByPosition.TryGetValue(tileEntity.Position, out tileEntity2))
				{
					TileEntity.ByID.Remove(tileEntity2.ID);
				}
				TileEntity.ByPosition[tileEntity.Position] = tileEntity;
			}
			TileEntity.TileEntitiesNextID = num;
			List<Point16> list = new List<Point16>();
			foreach (KeyValuePair<Point16, TileEntity> current in TileEntity.ByPosition)
			{
				if (!WorldGen.InWorld((int)current.Value.Position.X, (int)current.Value.Position.Y, 1))
				{
					list.Add(current.Value.Position);
				}
				else
				{
					if (current.Value.type == 0 && !TETrainingDummy.ValidTile((int)current.Value.Position.X, (int)current.Value.Position.Y))
					{
						list.Add(current.Value.Position);
					}
					if (current.Value.type == 2 && !TELogicSensor.ValidTile((int)current.Value.Position.X, (int)current.Value.Position.Y))
					{
						list.Add(current.Value.Position);
					}
					if (current.Value.type == 1 && !TEItemFrame.ValidTile((int)current.Value.Position.X, (int)current.Value.Position.Y))
					{
						list.Add(current.Value.Position);
					}
				}
			}
			try
			{
				foreach (Point16 current2 in list)
				{
					TileEntity tileEntity3 = TileEntity.ByPosition[current2];
					if (TileEntity.ByID.ContainsKey(tileEntity3.ID))
					{
						TileEntity.ByID.Remove(tileEntity3.ID);
					}
					if (TileEntity.ByPosition.ContainsKey(current2))
					{
						TileEntity.ByPosition.Remove(current2);
					}
				}
			}
			catch
			{
			}
		}
		private static int SaveWeightedPressurePlates(BinaryWriter writer)
		{
			writer.Write(PressurePlateHelper.PressurePlatesPressed.Count);
			foreach (KeyValuePair<Point, bool[]> current in PressurePlateHelper.PressurePlatesPressed)
			{
				writer.Write(current.Key.X);
				writer.Write(current.Key.Y);
			}
			return (int)writer.BaseStream.Position;
		}

		private static void LoadWeightedPressurePlates(BinaryReader reader)
		{
			PressurePlateHelper.Reset();
			PressurePlateHelper.NeedsFirstUpdate = true;
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				Point key = new Point(reader.ReadInt32(), reader.ReadInt32());
				PressurePlateHelper.PressurePlatesPressed.Add(key, new bool[255]);
			}
		}

		public static void loadWorld()
		{
			int num;
			Main.checkXMas();
			Main.checkHalloween();
			if (!FileUtilities.Exists(Main.worldPathName) && Main.autoGen)
			{
				int length = Main.worldPathName.Length - 1;
				while (length >= 0)
				{
					if (Main.worldPathName.Substring(length, 1) != string.Concat(Path.DirectorySeparatorChar))
					{
						length--;
					}
					else
					{
						string str = Main.worldPathName.Substring(0, length);
						Directory.CreateDirectory(str);
						break;
					}
				}
				WorldGen.clearWorld();
				WorldGen.generateWorld(-1, null);
				WorldFile.saveWorld();
			}
			byte[] numArray = FileUtilities.ReadAllBytes(Main.worldPathName);
			using (MemoryStream memoryStream = new MemoryStream(numArray))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					try
					{
						WorldGen.loadFailed = false;
						WorldGen.loadSuccess = false;
						int num1 = binaryReader.ReadInt32();
						WorldFile.versionNumber = num1;
						num = (num1 > 87 ? WorldFile.LoadWorld_Version2(binaryReader) : WorldFile.LoadWorld_Version1(binaryReader));
						if (num1 < 141)
						{
							Main.ActiveWorldFileData.CreationTime = File.GetCreationTime(Main.worldPathName);
						}
						binaryReader.Close();
						memoryStream.Close();
						if (num == 0)
						{
							WorldGen.loadSuccess = true;
						}
						else
						{
							WorldGen.loadFailed = true;
						}
						if (WorldGen.loadFailed || !WorldGen.loadSuccess)
						{
							return;
						}
						else
						{
							WorldGen.gen = true;
							WorldGen.waterLine = Main.maxTilesY;
							Liquid.QuickWater(2, -1, -1);
							WorldGen.WaterCheck();
							int num2 = 0;
							Liquid.quickSettle = true;
							int num3 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
							float single = 0f;
							while (Liquid.numLiquid > 0 && num2 < 100000)
							{
								num2++;
								float single1 = (float)((float)(num3 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float)num3);
								if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num3)
								{
									num3 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
								}
								if (single1 <= single)
								{
									single1 = single;
								}
								else
								{
									single = single1;
								}
								object[] objArray = new object[] { Lang.gen[27], " ", (int)(single1 * 100f / 2f + 50f), "%" };
								Main.statusText = string.Concat(objArray);
								Liquid.UpdateLiquid();
							}
							Liquid.quickSettle = false;
							Main.weatherCounter = WorldGen.genRand.Next(3600, 18000);
							Cloud.resetClouds();
							WorldGen.WaterCheck();
							WorldGen.gen = false;
							NPC.setFireFlyChance();
							Main.InitLifeBytes();
							if (Main.slimeRainTime > 0)
							{
								Main.StartSlimeRain(false);
							}
							NPC.setWorldMonsters();
						}
					}
					catch
					{
						WorldGen.loadFailed = true;
						WorldGen.loadSuccess = false;
						try
						{
							binaryReader.Close();
							memoryStream.Close();
						}
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}
						return;
					}
				}
			}
			if (WorldFile.OnWorldLoad != null)
			{
				WorldFile.OnWorldLoad();
			}
		}

		public static int LoadWorld_Version1(BinaryReader fileIO)
		{
			int num = WorldFile.versionNumber;
			if (num > 184)
			{
				return 1;
			}
			Main.worldName = fileIO.ReadString();
			Main.worldID = fileIO.ReadInt32();
			Main.leftWorld = (float)fileIO.ReadInt32();
			Main.rightWorld = (float)fileIO.ReadInt32();
			Main.topWorld = (float)fileIO.ReadInt32();
			Main.bottomWorld = (float)fileIO.ReadInt32();
			Main.maxTilesY = fileIO.ReadInt32();
			Main.maxTilesX = fileIO.ReadInt32();
			if (num < 112)
			{
				Main.expertMode = false;
			}
			else
			{
				Main.expertMode = fileIO.ReadBoolean();
			}
			if (num < 63)
			{
				WorldGen.RandomizeMoonState();
			}
			else
			{
				Main.moonType = fileIO.ReadByte();
			}
			WorldGen.clearWorld();
			if (num >= 44)
			{
				Main.treeX[0] = fileIO.ReadInt32();
				Main.treeX[1] = fileIO.ReadInt32();
				Main.treeX[2] = fileIO.ReadInt32();
				Main.treeStyle[0] = fileIO.ReadInt32();
				Main.treeStyle[1] = fileIO.ReadInt32();
				Main.treeStyle[2] = fileIO.ReadInt32();
				Main.treeStyle[3] = fileIO.ReadInt32();
			}
			if (num < 60)
			{
				WorldGen.RandomizeCaveBackgrounds();
			}
			else
			{
				Main.caveBackX[0] = fileIO.ReadInt32();
				Main.caveBackX[1] = fileIO.ReadInt32();
				Main.caveBackX[2] = fileIO.ReadInt32();
				Main.caveBackStyle[0] = fileIO.ReadInt32();
				Main.caveBackStyle[1] = fileIO.ReadInt32();
				Main.caveBackStyle[2] = fileIO.ReadInt32();
				Main.caveBackStyle[3] = fileIO.ReadInt32();
				Main.iceBackStyle = fileIO.ReadInt32();
				if (num >= 61)
				{
					Main.jungleBackStyle = fileIO.ReadInt32();
					Main.hellBackStyle = fileIO.ReadInt32();
				}
			}
			Main.spawnTileX = fileIO.ReadInt32();
			Main.spawnTileY = fileIO.ReadInt32();
			Main.worldSurface = fileIO.ReadDouble();
			Main.rockLayer = fileIO.ReadDouble();
			WorldFile.tempTime = fileIO.ReadDouble();
			WorldFile.tempDayTime = fileIO.ReadBoolean();
			WorldFile.tempMoonPhase = fileIO.ReadInt32();
			WorldFile.tempBloodMoon = fileIO.ReadBoolean();
			if (num >= 112)
			{
				WorldFile.tempEclipse = fileIO.ReadBoolean();
				Main.eclipse = WorldFile.tempEclipse;
			}
			Main.dungeonX = fileIO.ReadInt32();
			Main.dungeonY = fileIO.ReadInt32();
			if (num < 56)
			{
				WorldGen.crimson = false;
			}
			else
			{
				WorldGen.crimson = fileIO.ReadBoolean();
			}
			NPC.downedBoss1 = fileIO.ReadBoolean();
			NPC.downedBoss2 = fileIO.ReadBoolean();
			NPC.downedBoss3 = fileIO.ReadBoolean();
			if (num >= 66)
			{
				NPC.downedQueenBee = fileIO.ReadBoolean();
			}
			if (num >= 44)
			{
				NPC.downedMechBoss1 = fileIO.ReadBoolean();
				NPC.downedMechBoss2 = fileIO.ReadBoolean();
				NPC.downedMechBoss3 = fileIO.ReadBoolean();
				NPC.downedMechBossAny = fileIO.ReadBoolean();
			}
			if (num >= 64)
			{
				NPC.downedPlantBoss = fileIO.ReadBoolean();
				NPC.downedGolemBoss = fileIO.ReadBoolean();
			}
			if (num >= 29)
			{
				NPC.savedGoblin = fileIO.ReadBoolean();
				NPC.savedWizard = fileIO.ReadBoolean();
				if (num >= 34)
				{
					NPC.savedMech = fileIO.ReadBoolean();
					if (num >= 80)
					{
						NPC.savedStylist = fileIO.ReadBoolean();
					}
				}
				if (num >= 129)
				{
					NPC.savedTaxCollector = fileIO.ReadBoolean();
				}
				NPC.downedGoblins = fileIO.ReadBoolean();
			}
			if (num >= 32)
			{
				NPC.downedClown = fileIO.ReadBoolean();
			}
			if (num >= 37)
			{
				NPC.downedFrost = fileIO.ReadBoolean();
			}
			if (num >= 56)
			{
				NPC.downedPirates = fileIO.ReadBoolean();
			}
			WorldGen.shadowOrbSmashed = fileIO.ReadBoolean();
			WorldGen.spawnMeteor = fileIO.ReadBoolean();
			WorldGen.shadowOrbCount = fileIO.ReadByte();
			if (num >= 23)
			{
				WorldGen.altarCount = fileIO.ReadInt32();
				Main.hardMode = fileIO.ReadBoolean();
			}
			Main.invasionDelay = fileIO.ReadInt32();
			Main.invasionSize = fileIO.ReadInt32();
			Main.invasionType = fileIO.ReadInt32();
			Main.invasionX = fileIO.ReadDouble();
			if (num >= 113)
			{
				Main.sundialCooldown = fileIO.ReadByte();
			}
			if (num >= 53)
			{
				WorldFile.tempRaining = fileIO.ReadBoolean();
				WorldFile.tempRainTime = fileIO.ReadInt32();
				WorldFile.tempMaxRain = fileIO.ReadSingle();
			}
			if (num >= 54)
			{
				WorldGen.oreTier1 = fileIO.ReadInt32();
				WorldGen.oreTier2 = fileIO.ReadInt32();
				WorldGen.oreTier3 = fileIO.ReadInt32();
			}
			else if (num < 23 || WorldGen.altarCount != 0)
			{
				WorldGen.oreTier1 = 107;
				WorldGen.oreTier2 = 108;
				WorldGen.oreTier3 = 111;
			}
			else
			{
				WorldGen.oreTier1 = -1;
				WorldGen.oreTier2 = -1;
				WorldGen.oreTier3 = -1;
			}
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			if (num >= 55)
			{
				num1 = fileIO.ReadByte();
				num2 = fileIO.ReadByte();
				num3 = fileIO.ReadByte();
			}
			if (num >= 60)
			{
				num4 = fileIO.ReadByte();
				num5 = fileIO.ReadByte();
				num6 = fileIO.ReadByte();
				num7 = fileIO.ReadByte();
				num8 = fileIO.ReadByte();
			}
			WorldGen.setBG(0, num1);
			WorldGen.setBG(1, num2);
			WorldGen.setBG(2, num3);
			WorldGen.setBG(3, num4);
			WorldGen.setBG(4, num5);
			WorldGen.setBG(5, num6);
			WorldGen.setBG(6, num7);
			WorldGen.setBG(7, num8);
			if (num < 60)
			{
				Main.cloudBGActive = (float)(-WorldGen.genRand.Next(8640, 86400));
			}
			else
			{
				Main.cloudBGActive = (float)fileIO.ReadInt32();
				if (Main.cloudBGActive < 1f)
				{
					Main.cloudBGAlpha = 0f;
				}
				else
				{
					Main.cloudBGAlpha = 1f;
				}
			}
			if (num < 62)
			{
				WorldGen.RandomizeWeather();
			}
			else
			{
				Main.numClouds = fileIO.ReadInt16();
				Main.windSpeedSet = fileIO.ReadSingle();
				Main.windSpeed = Main.windSpeedSet;
			}
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float single = (float)i / (float)Main.maxTilesX;
				object[] objArray = new object[] { Lang.gen[51], " ", (int)(single * 100f + 1f), "%" };
				Main.statusText = string.Concat(objArray);
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					int num9 = -1;
					tile.active(fileIO.ReadBoolean());
					if (tile.active())
					{
						if (num <= 77)
						{
							num9 = fileIO.ReadByte();
						}
						else
						{
							num9 = fileIO.ReadUInt16();
						}
						tile.type = (ushort)num9;
						if (tile.type == 127)
						{
							tile.active(false);
						}
						if (num < 72 && (tile.type == 35 || tile.type == 36 || tile.type == 170 || tile.type == 171 || tile.type == 172))
						{
							tile.frameX = fileIO.ReadInt16();
							tile.frameY = fileIO.ReadInt16();
						}
						else if (!Main.tileFrameImportant[num9])
						{
							tile.frameX = -1;
							tile.frameY = -1;
						}
						else if (num < 28 && num9 == 4)
						{
							tile.frameX = 0;
							tile.frameY = 0;
						}
						else if (num >= 40 || tile.type != 19)
						{
							tile.frameX = fileIO.ReadInt16();
							tile.frameY = fileIO.ReadInt16();
							if (tile.type == 144)
							{
								tile.frameY = 0;
							}
						}
						else
						{
							tile.frameX = 0;
							tile.frameY = 0;
						}
						if (num >= 48 && fileIO.ReadBoolean())
						{
							tile.color(fileIO.ReadByte());
						}
					}
					if (num <= 25)
					{
						fileIO.ReadBoolean();
					}
					if (fileIO.ReadBoolean())
					{
						tile.wall = fileIO.ReadByte();
						if (num >= 48 && fileIO.ReadBoolean())
						{
							tile.wallColor(fileIO.ReadByte());
						}
					}
					if (fileIO.ReadBoolean())
					{
						tile.liquid = fileIO.ReadByte();
						tile.lava(fileIO.ReadBoolean());
						if (num >= 51)
						{
							tile.honey(fileIO.ReadBoolean());
						}
					}
					if (num >= 33)
					{
						tile.wire(fileIO.ReadBoolean());
					}
					if (num >= 43)
					{
						tile.wire2(fileIO.ReadBoolean());
						tile.wire3(fileIO.ReadBoolean());
					}
					if (num >= 41)
					{
						tile.halfBrick(fileIO.ReadBoolean());
						if (!Main.tileSolid[tile.type])
						{
							tile.halfBrick(false);
						}
						if (num >= 49)
						{
							tile.slope(fileIO.ReadByte());
							if (!Main.tileSolid[tile.type])
							{
								tile.slope(0);
							}
						}
					}
					if (num >= 42)
					{
						tile.actuator(fileIO.ReadBoolean());
						tile.inActive(fileIO.ReadBoolean());
					}
					int num10 = 0;
					if (num >= 25)
					{
						num10 = fileIO.ReadInt16();
					}
					if (num9 != -1)
					{
						if ((double)j > Main.worldSurface)
						{
							WorldGen.tileCounts[num9] = WorldGen.tileCounts[num9] + num10 + 1;
						}
						else if ((double)(j + num10) > Main.worldSurface)
						{
							int num11 = (int)(Main.worldSurface - (double)j + 1);
							int num12 = num10 + 1 - num11;
							WorldGen.tileCounts[num9] = WorldGen.tileCounts[num9] + num11 * 5 + num12;
						}
						else
						{
							WorldGen.tileCounts[num9] = WorldGen.tileCounts[num9] + (num10 + 1) * 5;
						}
					}
					if (num10 > 0)
					{
						for (int k = j + 1; k < j + num10 + 1; k++)
						{
							Main.tile[i, k].CopyFrom(Main.tile[i, j]);
						}
						j = j + num10;
					}
				}
			}
			WorldGen.AddUpAlignmentCounts(true);
			if (num < 67)
			{
				WorldGen.FixSunflowers();
			}
			if (num < 72)
			{
				WorldGen.FixChands();
			}
			int num13 = 40;
			if (num < 58)
			{
				num13 = 20;
			}
			for (int l = 0; l < 1000; l++)
			{
				if (fileIO.ReadBoolean())
				{
					Main.chest[l] = new Chest(false);
					Main.chest[l].x = fileIO.ReadInt32();
					Main.chest[l].y = fileIO.ReadInt32();
					if (num >= 85)
					{
						string str = fileIO.ReadString();
						if (str.Length > 20)
						{
							str = str.Substring(0, 20);
						}
						Main.chest[l].name = str;
					}
					for (int m = 0; m < 40; m++)
					{
						Main.chest[l].item[m] = new Item();
						if (m < num13)
						{
							int num14 = 0;
							if (num < 59)
							{
								num14 = fileIO.ReadByte();
							}
							else
							{
								num14 = fileIO.ReadInt16();
							}
							if (num14 > 0)
							{
								if (num < 38)
								{
									string str1 = Item.VersionName(fileIO.ReadString(), num);
									Main.chest[l].item[m].SetDefaults(str1);
								}
								else
								{
									Main.chest[l].item[m].netDefaults(fileIO.ReadInt32());
								}
								Main.chest[l].item[m].stack = num14;
								if (num >= 36)
								{
									Main.chest[l].item[m].Prefix((int)fileIO.ReadByte());
								}
							}
						}
					}
				}
			}
			for (int n = 0; n < 1000; n++)
			{
				if (fileIO.ReadBoolean())
				{
					string str2 = fileIO.ReadString();
					int num15 = fileIO.ReadInt32();
					int num16 = fileIO.ReadInt32();
					if (Main.tile[num15, num16].active() && (Main.tile[num15, num16].type == 55 || Main.tile[num15, num16].type == 85))
					{
						Main.sign[n] = new Sign();
						Main.sign[n].x = num15;
						Main.sign[n].y = num16;
						Main.sign[n].text = str2;
					}
				}
			}
			bool flag = fileIO.ReadBoolean();
			int num17 = 0;
			while (flag)
			{
				Main.npc[num17].SetDefaults(fileIO.ReadString());
				if (num >= 83)
				{
					Main.npc[num17].displayName = fileIO.ReadString();
				}
				Main.npc[num17].position.X = fileIO.ReadSingle();
				Main.npc[num17].position.Y = fileIO.ReadSingle();
				Main.npc[num17].homeless = fileIO.ReadBoolean();
				Main.npc[num17].homeTileX = fileIO.ReadInt32();
				Main.npc[num17].homeTileY = fileIO.ReadInt32();
				flag = fileIO.ReadBoolean();
				num17++;
			}
			if (num >= 31 && num <= 83)
			{
				NPC.setNPCName(fileIO.ReadString(), 17, true);
				NPC.setNPCName(fileIO.ReadString(), 18, true);
				NPC.setNPCName(fileIO.ReadString(), 19, true);
				NPC.setNPCName(fileIO.ReadString(), 20, true);
				NPC.setNPCName(fileIO.ReadString(), 22, true);
				NPC.setNPCName(fileIO.ReadString(), 54, true);
				NPC.setNPCName(fileIO.ReadString(), 38, true);
				NPC.setNPCName(fileIO.ReadString(), 107, true);
				NPC.setNPCName(fileIO.ReadString(), 108, true);
				if (num >= 35)
				{
					NPC.setNPCName(fileIO.ReadString(), 124, true);
					if (num >= 65)
					{
						NPC.setNPCName(fileIO.ReadString(), 160, true);
						NPC.setNPCName(fileIO.ReadString(), 178, true);
						NPC.setNPCName(fileIO.ReadString(), 207, true);
						NPC.setNPCName(fileIO.ReadString(), 208, true);
						NPC.setNPCName(fileIO.ReadString(), 209, true);
						NPC.setNPCName(fileIO.ReadString(), 227, true);
						NPC.setNPCName(fileIO.ReadString(), 228, true);
						NPC.setNPCName(fileIO.ReadString(), 229, true);
						if (num >= 79)
						{
							NPC.setNPCName(fileIO.ReadString(), 353, true);
						}
					}
				}
			}
			if (Main.invasionType > 0 && Main.invasionSize > 0)
			{
				Main.FakeLoadInvasionStart();
			}
			if (num < 7)
			{
				return 0;
			}
			bool flag1 = fileIO.ReadBoolean();
			string str3 = fileIO.ReadString();
			int num18 = fileIO.ReadInt32();
			if (flag1 && (str3 == Main.worldName || num18 == Main.worldID))
			{
				return 0;
			}
			return 2;
		}

		public static int LoadWorld_Version2(BinaryReader reader)
		{
			bool[] flagArray;
			int[] numArray;
			reader.BaseStream.Position = (long)0;
			if (!WorldFile.LoadFileFormatHeader(reader, out flagArray, out numArray))
			{
				return 5;
			}
			if (reader.BaseStream.Position != (long)numArray[0])
			{
				return 5;
			}
			WorldFile.LoadHeader(reader);
			if (reader.BaseStream.Position != (long)numArray[1])
			{
				return 5;
			}
			WorldFile.LoadWorldTiles(reader, flagArray);
			if (reader.BaseStream.Position != (long)numArray[2])
			{
				return 5;
			}
			WorldFile.LoadChests(reader);
			if (reader.BaseStream.Position != (long)numArray[3])
			{
				return 5;
			}
			WorldFile.LoadSigns(reader);
			if (reader.BaseStream.Position != (long)numArray[4])
			{
				return 5;
			}
			WorldFile.LoadNPCs(reader);
			if (reader.BaseStream.Position != (long)numArray[5])
			{
				return 5;
			}
			if (WorldFile.versionNumber >= 116)
			{
				if (WorldFile.versionNumber >= 122)
				{
					WorldFile.LoadTileEntities(reader);
					if (reader.BaseStream.Position != (long)numArray[6])
					{
						return 5;
					}
				}
				else
				{
					WorldFile.LoadDummies(reader);
					if (reader.BaseStream.Position != (long)numArray[6])
					{
						return 5;
					}
				}
			}
			if (WorldFile.versionNumber >= 170)
			{
				WorldFile.LoadWeightedPressurePlates(reader);
				if (reader.BaseStream.Position != (long)numArray[7])
				{
					return 5;
				}
			}
			return WorldFile.LoadFooter(reader);
		}

		private static void LoadWorldTiles(BinaryReader reader, bool[] importance)
		{
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num = (float)i / (float)Main.maxTilesX;
				Main.statusText = string.Concat(new object[]
				{
					Lang.gen[51],
					" ",
					(int)((double)num * 100.0 + 1.0),
					"%"
				});
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					int num2 = -1;
					byte b2;
					byte b = b2 = 0;
					Tile tile = Main.tile[i, j];
					byte b3 = reader.ReadByte();
					if ((b3 & 1) == 1)
					{
						b2 = reader.ReadByte();
						if ((b2 & 1) == 1)
						{
							b = reader.ReadByte();
						}
					}
					byte b4;
					if ((b3 & 2) == 2)
					{
						tile.active(true);
						if ((b3 & 32) == 32)
						{
							b4 = reader.ReadByte();
							num2 = (int)reader.ReadByte();
							num2 = (num2 << 8 | (int)b4);
						}
						else
						{
							num2 = (int)reader.ReadByte();
						}
						tile.type = (ushort)num2;
						if (importance[num2])
						{
							tile.frameX = reader.ReadInt16();
							tile.frameY = reader.ReadInt16();
							if (tile.type == 144)
							{
								tile.frameY = 0;
							}
						}
						else
						{
							tile.frameX = -1;
							tile.frameY = -1;
						}
						if ((b & 8) == 8)
						{
							tile.color(reader.ReadByte());
						}
					}
					if ((b3 & 4) == 4)
					{
						tile.wall = reader.ReadByte();
						if ((b & 16) == 16)
						{
							tile.wallColor(reader.ReadByte());
						}
					}
					b4 = (byte)((b3 & 24) >> 3);
					if (b4 != 0)
					{
						tile.liquid = reader.ReadByte();
						if (b4 > 1)
						{
							if (b4 == 2)
							{
								tile.lava(true);
							}
							else
							{
								tile.honey(true);
							}
						}
					}
					if (b2 > 1)
					{
						if ((b2 & 2) == 2)
						{
							tile.wire(true);
						}
						if ((b2 & 4) == 4)
						{
							tile.wire2(true);
						}
						if ((b2 & 8) == 8)
						{
							tile.wire3(true);
						}
						b4 = (byte)((b2 & 112) >> 4);
						if (b4 != 0 && Main.tileSolid[(int)tile.type])
						{
							if (b4 == 1)
							{
								tile.halfBrick(true);
							}
							else
							{
								tile.slope((byte)(b4 - 1));
							}
						}
					}
					if (b > 0)
					{
						if ((b & 2) == 2)
						{
							tile.actuator(true);
						}
						if ((b & 4) == 4)
						{
							tile.inActive(true);
						}
						if ((b & 32) == 32)
						{
							tile.wire4(true);
						}
					}
					b4 = (byte)((b3 & 192) >> 6);
					int k;
					if (b4 == 0)
					{
						k = 0;
					}
					else if (b4 == 1)
					{
						k = (int)reader.ReadByte();
					}
					else
					{
						k = (int)reader.ReadInt16();
					}
					if (num2 != -1)
					{
						if ((double)j <= Main.worldSurface)
						{
							if ((double)(j + k) <= Main.worldSurface)
							{
								WorldGen.tileCounts[num2] += (k + 1) * 5;
							}
							else
							{
								int num3 = (int)(Main.worldSurface - (double)j + 1.0);
								int num4 = k + 1 - num3;
								WorldGen.tileCounts[num2] += num3 * 5 + num4;
							}
						}
						else
						{
							WorldGen.tileCounts[num2] += k + 1;
						}
					}
					while (k > 0)
					{
						j++;
						Main.tile[i, j].CopyFrom(tile);
						k--;
					}
				}
			}
			WorldGen.AddUpAlignmentCounts(true);
			if (WorldFile.versionNumber < 105)
			{
				WorldGen.FixHearts();
			}
		}

		public static void ResetTemps()
		{
			WorldFile.tempRaining = false;
			WorldFile.tempMaxRain = 0f;
			WorldFile.tempRainTime = 0;
			WorldFile.tempDayTime = true;
			WorldFile.tempBloodMoon = false;
			WorldFile.tempEclipse = false;
			WorldFile.tempMoonPhase = 0;
			Main.anglerWhoFinishedToday.Clear();
			Main.anglerQuestFinished = false;
		}

		private static void ResetTempsToDayTime()
		{
			WorldFile.tempDayTime = true;
			WorldFile.tempTime = 13500.0;
			WorldFile.tempMoonPhase = 0;
			WorldFile.tempBloodMoon = false;
			WorldFile.tempEclipse = false;
			WorldFile.tempCultistDelay = 86400;
			WorldFile.tempPartyManual = false;
			WorldFile.tempPartyGenuine = false;
			WorldFile.tempPartyCooldown = 0;
			WorldFile.tempPartyCelebratingNPCs.Clear();
			WorldFile.Temp_Sandstorm_Happening = false;
			WorldFile.Temp_Sandstorm_TimeLeft = 0;
			WorldFile.Temp_Sandstorm_Severity = 0f;
			WorldFile.Temp_Sandstorm_IntendedSeverity = 0f;
		}

		private static int SaveChests(BinaryWriter writer)
		{
			Chest chest;
			int i;
			short num = 0;
			for (i = 0; i < 1000; i++)
			{
				chest = Main.chest[i];
				if (chest != null)
				{
					bool flag = false;
					for (int j = chest.x; j <= chest.x + 1; j++)
					{
						int num1 = chest.y;
						while (num1 <= chest.y + 1)
						{
							if (j < 0 || num1 < 0 || j >= Main.maxTilesX || num1 >= Main.maxTilesY)
							{
								flag = true;
								break;
							}
							else
							{
								Tile tile = Main.tile[j, num1];
								if (!tile.active() || !Main.tileContainer[tile.type])
								{
									flag = true;
									break;
								}
								else
								{
									num1++;
								}
							}
						}
					}
					if (!flag)
					{
						num = (short)(num + 1);
					}
					else
					{
						Main.chest[i] = null;
					}
				}
			}
			writer.Write(num);
			writer.Write((short)40);
			for (i = 0; i < 1000; i++)
			{
				chest = Main.chest[i];
				if (chest != null)
				{
					writer.Write(chest.x);
					writer.Write(chest.y);
					writer.Write(chest.name);
					for (int k = 0; k < 40; k++)
					{
						Item item = chest.item[k];
						if (item != null)
						{
							if (item.stack > item.maxStack)
							{
								item.stack = item.maxStack;
							}
							if (item.stack < 0)
							{
								item.stack = 1;
							}
							writer.Write((short)item.stack);
							if (item.stack > 0)
							{
								writer.Write(item.netID);
								writer.Write(item.prefix);
							}
						}
						else
						{
							writer.Write((short)0);
						}
					}
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveDummies(BinaryWriter writer)
		{
			TargetDummy targetDummy;
			int num = 0;
			for (int i = 0; i < 1000; i++)
			{
				targetDummy = TargetDummy.dummies[i];
				if (targetDummy != null)
				{
					num++;
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				targetDummy = TargetDummy.dummies[j];
				if (targetDummy != null)
				{
					writer.Write(targetDummy.x);
					writer.Write(targetDummy.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveFileFormatHeader(BinaryWriter writer)
		{
			short num = Main.maxTileSets;
			short num2 = 10;
			writer.Write(Main.curRelease);
			Main.WorldFileMetadata.IncrementAndWrite(writer);
			writer.Write(num2);
			for (int i = 0; i < (int)num2; i++)
			{
				writer.Write(0);
			}
			writer.Write(num);
			byte b = 0;
			byte b2 = 1;
			for (int i = 0; i < (int)num; i++)
			{
				if (Main.tileFrameImportant[i])
				{
					b |= b2;
				}
				if (b2 == 128)
				{
					writer.Write(b);
					b = 0;
					b2 = 1;
				}
				else
				{
					b2 = (byte)(b2 << 1);
				}
			}
			if (b2 != 1)
			{
				writer.Write(b);
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveFooter(BinaryWriter writer)
		{
			writer.Write(true);
			writer.Write(Main.worldName);
			writer.Write(Main.worldID);
			return (int)writer.BaseStream.Position;
		}

		private static int SaveHeaderPointers(BinaryWriter writer, int[] pointers)
		{
			writer.BaseStream.Position = (long)0;
			writer.Write(184);
			Stream baseStream = writer.BaseStream;
			baseStream.Position = baseStream.Position + (long)20;
			writer.Write((short)((int)pointers.Length));
			for (int i = 0; i < (int)pointers.Length; i++)
			{
				writer.Write(pointers[i]);
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveNPCs(BinaryWriter writer)
		{
			for (int i = 0; i < (int)Main.npc.Length; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && nPC.townNPC && nPC.type != 368)
				{
					writer.Write(nPC.active);
					writer.Write(nPC.name);
					writer.Write(nPC.displayName);
					writer.Write(nPC.position.X);
					writer.Write(nPC.position.Y);
					writer.Write(nPC.homeless);
					writer.Write(nPC.homeTileX);
					writer.Write(nPC.homeTileY);
				}
			}
			writer.Write(false);
			for (int j = 0; j < (int)Main.npc.Length; j++)
			{
				NPC nPC1 = Main.npc[j];
				if (nPC1.active && NPCID.Sets.SavesAndLoads[nPC1.type])
				{
					writer.Write(nPC1.active);
					writer.Write(nPC1.name);
					writer.WriteVector2(nPC1.position);
				}
			}
			writer.Write(false);
			return (int)writer.BaseStream.Position;
		}

		private static int SaveSigns(BinaryWriter writer)
		{
			Sign sign;
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				sign = Main.sign[i];
				if (sign != null && sign.text != null)
				{
					num = (short)(num + 1);
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				sign = Main.sign[j];
				if (sign != null && sign.text != null)
				{
					writer.Write(sign.text);
					writer.Write(sign.x);
					writer.Write(sign.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		private static int SaveTileEntities(BinaryWriter writer)
		{
			writer.Write(TileEntity.ByID.Count);
			foreach (KeyValuePair<int, TileEntity> byID in TileEntity.ByID)
			{
				TileEntity.Write(writer, byID.Value);
			}
			return (int)writer.BaseStream.Position;
		}

		public static void saveWorld()
		{
			WorldFile.saveWorld(false);
		}

		public static void saveWorld(bool resetTime = false)
		{
			if (ServerApi.Hooks.InvokeWorldSave(resetTime))
			{
				return;
			}
			if (Main.worldName == "")
			{
				Main.worldName = "World";
			}
			if (WorldGen.saveLock)
			{
#if DEBUG
				Console.WriteLine("WorldGen.saveLock was true, and save was aborted");
#endif
				return;
			}
			WorldGen.saveLock = true;
			while (WorldGen.IsGeneratingHardMode)
			{
				Main.statusText = Lang.gen[48];
			}
			lock (WorldFile.padlock)
			{
				try
				{
					Directory.CreateDirectory(Main.WorldPath);
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();
#endif
				}
				if (Main.skipMenu)
				{
					return;
				}
				if (WorldFile.HasCache)
				{
					WorldFile.SetTempToCache();
				}
				else
				{
					WorldFile.SetTempToOngoing();
				}
				if (resetTime)
				{
					WorldFile.ResetTempsToDayTime();
				}
				if (Main.worldPathName == null)
				{
					return;
				}
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				byte[] array = null;
				int num = 0;
				using (MemoryStream memoryStream = new MemoryStream(7000000))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
					{
						WorldFile.SaveWorld_Version2(binaryWriter);
					}
					array = memoryStream.ToArray();
					num = array.Length;
				}
				if (array == null)
				{
					return;
				}
				byte[] array2 = null;
				if (FileUtilities.Exists(Main.worldPathName))
				{
					array2 = FileUtilities.ReadAllBytes(Main.worldPathName);
				}
				FileUtilities.Write(Main.worldPathName, array, num);
				array = FileUtilities.ReadAllBytes(Main.worldPathName);
				string text = null;
				using (MemoryStream memoryStream2 = new MemoryStream(array, 0, num, false))
				{
					using (BinaryReader binaryReader = new BinaryReader(memoryStream2))
					{
						if (!Main.validateSaves || WorldFile.validateWorld(binaryReader))
						{
							if (array2 != null)
							{
								text = Main.worldPathName + ".bak";
								Main.statusText = Lang.gen[50];
							}
						}
						else
						{
							text = Main.worldPathName;
						}
					}
				}
				if (text != null && array2 != null)
				{
					FileUtilities.WriteAllBytes(text, array2);
				}
				WorldGen.saveLock = false;
			}
			Main.serverGenLock = false;
		}

		public static void SaveWorld_Version2(BinaryWriter writer)
		{
			int[] array = new int[10];
			array[0] = WorldFile.SaveFileFormatHeader(writer);
			array[1] = WorldFile.SaveWorldHeader(writer);
			array[2] = WorldFile.SaveWorldTiles(writer);
			array[3] = WorldFile.SaveChests(writer);
			array[4] = WorldFile.SaveSigns(writer);
			array[5] = WorldFile.SaveNPCs(writer);
			array[6] = WorldFile.SaveTileEntities(writer);
			array[7] = WorldFile.SaveWeightedPressurePlates(writer);
			WorldFile.SaveFooter(writer);
			WorldFile.SaveHeaderPointers(writer, array);
		}

		private static int SaveWorldHeader(BinaryWriter writer)
		{
			writer.Write(Main.worldName);
			writer.Write(Main.ActiveWorldFileData.SeedText);
			writer.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
			writer.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
			writer.Write(Main.worldID);
			writer.Write((int)Main.leftWorld);
			writer.Write((int)Main.rightWorld);
			writer.Write((int)Main.topWorld);
			writer.Write((int)Main.bottomWorld);
			writer.Write(Main.maxTilesY);
			writer.Write(Main.maxTilesX);
			writer.Write(Main.expertMode);
			writer.Write(Main.ActiveWorldFileData.CreationTime.ToBinary());
			writer.Write((byte)Main.moonType);
			writer.Write(Main.treeX[0]);
			writer.Write(Main.treeX[1]);
			writer.Write(Main.treeX[2]);
			writer.Write(Main.treeStyle[0]);
			writer.Write(Main.treeStyle[1]);
			writer.Write(Main.treeStyle[2]);
			writer.Write(Main.treeStyle[3]);
			writer.Write(Main.caveBackX[0]);
			writer.Write(Main.caveBackX[1]);
			writer.Write(Main.caveBackX[2]);
			writer.Write(Main.caveBackStyle[0]);
			writer.Write(Main.caveBackStyle[1]);
			writer.Write(Main.caveBackStyle[2]);
			writer.Write(Main.caveBackStyle[3]);
			writer.Write(Main.iceBackStyle);
			writer.Write(Main.jungleBackStyle);
			writer.Write(Main.hellBackStyle);
			writer.Write(Main.spawnTileX);
			writer.Write(Main.spawnTileY);
			writer.Write(Main.worldSurface);
			writer.Write(Main.rockLayer);
			writer.Write(WorldFile.tempTime);
			writer.Write(WorldFile.tempDayTime);
			writer.Write(WorldFile.tempMoonPhase);
			writer.Write(WorldFile.tempBloodMoon);
			writer.Write(WorldFile.tempEclipse);
			writer.Write(Main.dungeonX);
			writer.Write(Main.dungeonY);
			writer.Write(WorldGen.crimson);
			writer.Write(NPC.downedBoss1);
			writer.Write(NPC.downedBoss2);
			writer.Write(NPC.downedBoss3);
			writer.Write(NPC.downedQueenBee);
			writer.Write(NPC.downedMechBoss1);
			writer.Write(NPC.downedMechBoss2);
			writer.Write(NPC.downedMechBoss3);
			writer.Write(NPC.downedMechBossAny);
			writer.Write(NPC.downedPlantBoss);
			writer.Write(NPC.downedGolemBoss);
			writer.Write(NPC.downedSlimeKing);
			writer.Write(NPC.savedGoblin);
			writer.Write(NPC.savedWizard);
			writer.Write(NPC.savedMech);
			writer.Write(NPC.downedGoblins);
			writer.Write(NPC.downedClown);
			writer.Write(NPC.downedFrost);
			writer.Write(NPC.downedPirates);
			writer.Write(WorldGen.shadowOrbSmashed);
			writer.Write(WorldGen.spawnMeteor);
			writer.Write((byte)WorldGen.shadowOrbCount);
			writer.Write(WorldGen.altarCount);
			writer.Write(Main.hardMode);
			writer.Write(Main.invasionDelay);
			writer.Write(Main.invasionSize);
			writer.Write(Main.invasionType);
			writer.Write(Main.invasionX);
			writer.Write((double)Main.slimeRainTime);
			writer.Write((byte)Main.sundialCooldown);
			writer.Write(WorldFile.tempRaining);
			writer.Write(WorldFile.tempRainTime);
			writer.Write(WorldFile.tempMaxRain);
			writer.Write(WorldGen.oreTier1);
			writer.Write(WorldGen.oreTier2);
			writer.Write(WorldGen.oreTier3);
			writer.Write((byte)WorldGen.treeBG);
			writer.Write((byte)WorldGen.corruptBG);
			writer.Write((byte)WorldGen.jungleBG);
			writer.Write((byte)WorldGen.snowBG);
			writer.Write((byte)WorldGen.hallowBG);
			writer.Write((byte)WorldGen.crimsonBG);
			writer.Write((byte)WorldGen.desertBG);
			writer.Write((byte)WorldGen.oceanBG);
			writer.Write((int)Main.cloudBGActive);
			writer.Write((short)Main.numClouds);
			writer.Write(Main.windSpeedSet);
			writer.Write(Main.anglerWhoFinishedToday.Count);
			for (int i = 0; i < Main.anglerWhoFinishedToday.Count; i++)
			{
				writer.Write(Main.anglerWhoFinishedToday[i]);
			}
			writer.Write(NPC.savedAngler);
			writer.Write(Main.anglerQuest);
			writer.Write(NPC.savedStylist);
			writer.Write(NPC.savedTaxCollector);
			writer.Write(Main.invasionSizeStart);
			writer.Write(WorldFile.tempCultistDelay);
			writer.Write((short)Main.maxNPCTypes);
			for (int j = 0; j < Main.maxNPCTypes; j++)
			{
				writer.Write(NPC.killCount[j]);
			}
			writer.Write(Main.fastForwardTime);
			writer.Write(NPC.downedFishron);
			writer.Write(NPC.downedMartians);
			writer.Write(NPC.downedAncientCultist);
			writer.Write(NPC.downedMoonlord);
			writer.Write(NPC.downedHalloweenKing);
			writer.Write(NPC.downedHalloweenTree);
			writer.Write(NPC.downedChristmasIceQueen);
			writer.Write(NPC.downedChristmasSantank);
			writer.Write(NPC.downedChristmasTree);
			writer.Write(NPC.downedTowerSolar);
			writer.Write(NPC.downedTowerVortex);
			writer.Write(NPC.downedTowerNebula);
			writer.Write(NPC.downedTowerStardust);
			writer.Write(NPC.TowerActiveSolar);
			writer.Write(NPC.TowerActiveVortex);
			writer.Write(NPC.TowerActiveNebula);
			writer.Write(NPC.TowerActiveStardust);
			writer.Write(NPC.LunarApocalypseIsUp);
			writer.Write(WorldFile.tempPartyManual);
			writer.Write(WorldFile.tempPartyGenuine);
			writer.Write(WorldFile.tempPartyCooldown);
			writer.Write(WorldFile.tempPartyCelebratingNPCs.Count);
			for (int k = 0; k < WorldFile.tempPartyCelebratingNPCs.Count; k++)
			{
				writer.Write(WorldFile.tempPartyCelebratingNPCs[k]);
			}
			writer.Write(WorldFile.Temp_Sandstorm_Happening);
			writer.Write(WorldFile.Temp_Sandstorm_TimeLeft);
			writer.Write(WorldFile.Temp_Sandstorm_Severity);
			writer.Write(WorldFile.Temp_Sandstorm_IntendedSeverity);
			writer.Write(NPC.savedBartender);
			DD2Event.Save(writer);
			return (int)writer.BaseStream.Position;
		}

		private static int SaveWorldTiles(BinaryWriter writer)
		{
			byte[] array = new byte[13];
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num = (float)i / (float)Main.maxTilesX;
				Main.statusText = string.Concat(new object[]
				{
					Lang.gen[49],
					" ",
					(int)(num * 100f + 1f),
					"%"
				});
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					int num2 = 3;
					byte b3;
					byte b2;
					byte b = b2 = (b3 = 0);
					bool flag = false;
					if (tile.active())
					{
						flag = true;
						if (tile.type == 127)
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (!tile.active())
							{
								flag = false;
								if (Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0, 0, 0);
								}
							}
						}
					}
					if (flag)
					{
						b2 |= 2;
						if (tile.type == 127)
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (!tile.active() && Main.netMode != 0)
							{
								NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0, 0, 0);
							}
						}
						array[num2] = (byte)tile.type;
						num2++;
						if (tile.type > 255)
						{
							array[num2] = (byte)(tile.type >> 8);
							num2++;
							b2 |= 32;
						}
						if (Main.tileFrameImportant[(int)tile.type])
						{
							array[num2] = (byte)(tile.frameX & 255);
							num2++;
							array[num2] = (byte)(((int)tile.frameX & 65280) >> 8);
							num2++;
							array[num2] = (byte)(tile.frameY & 255);
							num2++;
							array[num2] = (byte)(((int)tile.frameY & 65280) >> 8);
							num2++;
						}
						if (tile.color() != 0)
						{
							b3 |= 8;
							array[num2] = tile.color();
							num2++;
						}
					}
					if (tile.wall != 0)
					{
						b2 |= 4;
						array[num2] = tile.wall;
						num2++;
						if (tile.wallColor() != 0)
						{
							b3 |= 16;
							array[num2] = tile.wallColor();
							num2++;
						}
					}
					if (tile.liquid != 0)
					{
						if (tile.lava())
						{
							b2 |= 16;
						}
						else if (tile.honey())
						{
							b2 |= 24;
						}
						else
						{
							b2 |= 8;
						}
						array[num2] = tile.liquid;
						num2++;
					}
					if (tile.wire())
					{
						b |= 2;
					}
					if (tile.wire2())
					{
						b |= 4;
					}
					if (tile.wire3())
					{
						b |= 8;
					}
					int num3;
					if (tile.halfBrick())
					{
						num3 = 16;
					}
					else if (tile.slope() != 0)
					{
						num3 = (int)(tile.slope() + 1) << 4;
					}
					else
					{
						num3 = 0;
					}
					b |= (byte)num3;
					if (tile.actuator())
					{
						b3 |= 2;
					}
					if (tile.inActive())
					{
						b3 |= 4;
					}
					if (tile.wire4())
					{
						b3 |= 32;
					}
					int num4 = 2;
					if (b3 != 0)
					{
						b |= 1;
						array[num4] = b3;
						num4--;
					}
					if (b != 0)
					{
						b2 |= 1;
						array[num4] = b;
						num4--;
					}
					short num5 = 0;
					int num6 = j + 1;
					int num7 = Main.maxTilesY - j - 1;
					while (num7 > 0 && tile.isTheSameAs(Main.tile[i, num6]))
					{
						num5 += 1;
						num7--;
						num6++;
					}
					j += (int)num5;
					if (num5 > 0)
					{
						array[num2] = (byte)(num5 & 255);
						num2++;
						if (num5 > 255)
						{
							b2 |= 128;
							array[num2] = (byte)(((int)num5 & 65280) >> 8);
							num2++;
						}
						else
						{
							b2 |= 64;
						}
					}
					array[num4] = b2;
					writer.Write(array, num4, num2 - num4);
				}
			}
			return (int)writer.BaseStream.Position;
		}

		public static void SetOngoingToTemps()
		{
			Main.dayTime = WorldFile.tempDayTime;
			Main.time = WorldFile.tempTime;
			Main.moonPhase = WorldFile.tempMoonPhase;
			Main.bloodMoon = WorldFile.tempBloodMoon;
			Main.eclipse = WorldFile.tempEclipse;
			Main.raining = WorldFile.tempRaining;
			Main.rainTime = WorldFile.tempRainTime;
			Main.maxRaining = WorldFile.tempMaxRain;
			Main.cloudAlpha = WorldFile.tempMaxRain;
			CultistRitual.delay = WorldFile.tempCultistDelay;
			BirthdayParty.ManualParty = WorldFile.tempPartyManual;
			BirthdayParty.GenuineParty = WorldFile.tempPartyGenuine;
			BirthdayParty.PartyDaysOnCooldown = WorldFile.tempPartyCooldown;
			BirthdayParty.CelebratingNPCs.Clear();
			BirthdayParty.CelebratingNPCs.AddRange(WorldFile.tempPartyCelebratingNPCs);
			Sandstorm.Happening = WorldFile.Temp_Sandstorm_Happening;
			Sandstorm.TimeLeft = WorldFile.Temp_Sandstorm_TimeLeft;
			Sandstorm.Severity = WorldFile.Temp_Sandstorm_Severity;
			Sandstorm.IntendedSeverity = WorldFile.Temp_Sandstorm_IntendedSeverity;
		}

		private static void SetTempToCache()
		{
			WorldFile.HasCache = false;
			WorldFile.tempDayTime = WorldFile.CachedDayTime.Value;
			WorldFile.tempTime = WorldFile.CachedTime.Value;
			WorldFile.tempMoonPhase = WorldFile.CachedMoonPhase.Value;
			WorldFile.tempBloodMoon = WorldFile.CachedBloodMoon.Value;
			WorldFile.tempEclipse = WorldFile.CachedEclipse.Value;
			WorldFile.tempCultistDelay = WorldFile.CachedCultistDelay.Value;
			WorldFile.tempPartyManual = WorldFile.CachedPartyManual.Value;
			WorldFile.tempPartyGenuine = WorldFile.CachedPartyGenuine.Value;
			WorldFile.tempPartyCooldown = WorldFile.CachedPartyDaysOnCooldown.Value;
			WorldFile.tempPartyCelebratingNPCs.Clear();
			WorldFile.tempPartyCelebratingNPCs.AddRange(WorldFile.CachedCelebratingNPCs);
			WorldFile.Temp_Sandstorm_Happening = WorldFile.Cached_Sandstorm_Happening.Value;
			WorldFile.Temp_Sandstorm_TimeLeft = WorldFile.Cached_Sandstorm_TimeLeft.Value;
			WorldFile.Temp_Sandstorm_Severity = WorldFile.Cached_Sandstorm_Severity.Value;
			WorldFile.Temp_Sandstorm_IntendedSeverity = WorldFile.Cached_Sandstorm_IntendedSeverity.Value;
		}

		private static void SetTempToOngoing()
		{
			WorldFile.tempDayTime = Main.dayTime;
			WorldFile.tempTime = Main.time;
			WorldFile.tempMoonPhase = Main.moonPhase;
			WorldFile.tempBloodMoon = Main.bloodMoon;
			WorldFile.tempEclipse = Main.eclipse;
			WorldFile.tempCultistDelay = CultistRitual.delay;
			WorldFile.tempPartyManual = BirthdayParty.ManualParty;
			WorldFile.tempPartyGenuine = BirthdayParty.GenuineParty;
			WorldFile.tempPartyCooldown = BirthdayParty.PartyDaysOnCooldown;
			WorldFile.tempPartyCelebratingNPCs.Clear();
			WorldFile.tempPartyCelebratingNPCs.AddRange(BirthdayParty.CelebratingNPCs);
			WorldFile.Temp_Sandstorm_Happening = Sandstorm.Happening;
			WorldFile.Temp_Sandstorm_TimeLeft = Sandstorm.TimeLeft;
			WorldFile.Temp_Sandstorm_Severity = Sandstorm.Severity;
			WorldFile.Temp_Sandstorm_IntendedSeverity = Sandstorm.IntendedSeverity;
		}

		public static bool validateWorld(BinaryReader fileIO)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			bool result;
			try
			{
				Stream baseStream = fileIO.BaseStream;
				int num = fileIO.ReadInt32();
				if (num == 0 || num > 184)
				{
					result = false;
				}
				else
				{
					baseStream.Position = 0L;
					bool[] array;
					int[] array2;
					if (!WorldFile.LoadFileFormatHeader(fileIO, out array, out array2))
					{
						result = false;
					}
					else
					{
						string b = fileIO.ReadString();
						if (num >= 179)
						{
							if (num == 179)
							{
								fileIO.ReadInt32();
							}
							else
							{
								fileIO.ReadString();
							}
							fileIO.ReadUInt64();
						}
						if (num >= 181)
						{
							fileIO.ReadBytes(16);
						}
						int num2 = fileIO.ReadInt32();
						fileIO.ReadInt32();
						fileIO.ReadInt32();
						fileIO.ReadInt32();
						fileIO.ReadInt32();
						int num3 = fileIO.ReadInt32();
						int num4 = fileIO.ReadInt32();
						baseStream.Position = (long)array2[1];
						for (int i = 0; i < num4; i++)
						{
							float num5 = (float)i / (float)Main.maxTilesX;
							Main.statusText = string.Concat(new object[]
							{
								Lang.gen[73],
								" ",
								(int)(num5 * 100f + 1f),
								"%"
							});
							for (int j = 0; j < num3; j++)
							{
								byte b2 = 0;
								byte b3 = fileIO.ReadByte();
								if ((b3 & 1) == 1)
								{
									byte b4 = fileIO.ReadByte();
									if ((b4 & 1) == 1)
									{
										b2 = fileIO.ReadByte();
									}
								}
								byte b5;
								if ((b3 & 2) == 2)
								{
									int num6;
									if ((b3 & 32) == 32)
									{
										b5 = fileIO.ReadByte();
										num6 = (int)fileIO.ReadByte();
										num6 = (num6 << 8 | (int)b5);
									}
									else
									{
										num6 = (int)fileIO.ReadByte();
									}
									if (array[num6])
									{
										fileIO.ReadInt16();
										fileIO.ReadInt16();
									}
									if ((b2 & 8) == 8)
									{
										fileIO.ReadByte();
									}
								}
								if ((b3 & 4) == 4)
								{
									fileIO.ReadByte();
									if ((b2 & 16) == 16)
									{
										fileIO.ReadByte();
									}
								}
								if ((b3 & 24) >> 3 != 0)
								{
									fileIO.ReadByte();
								}
								b5 = (byte)((b3 & 192) >> 6);
								int num7;
								if (b5 == 0)
								{
									num7 = 0;
								}
								else if (b5 == 1)
								{
									num7 = (int)fileIO.ReadByte();
								}
								else
								{
									num7 = (int)fileIO.ReadInt16();
								}
								j += num7;
							}
						}
						if (baseStream.Position != (long)array2[2])
						{
							result = false;
						}
						else
						{
							int num8 = (int)fileIO.ReadInt16();
							int num9 = (int)fileIO.ReadInt16();
							for (int k = 0; k < num8; k++)
							{
								fileIO.ReadInt32();
								fileIO.ReadInt32();
								fileIO.ReadString();
								for (int l = 0; l < num9; l++)
								{
									int num10 = (int)fileIO.ReadInt16();
									if (num10 > 0)
									{
										fileIO.ReadInt32();
										fileIO.ReadByte();
									}
								}
							}
							if (baseStream.Position != (long)array2[3])
							{
								result = false;
							}
							else
							{
								int num11 = (int)fileIO.ReadInt16();
								for (int m = 0; m < num11; m++)
								{
									fileIO.ReadString();
									fileIO.ReadInt32();
									fileIO.ReadInt32();
								}
								if (baseStream.Position != (long)array2[4])
								{
									result = false;
								}
								else
								{
									bool flag = fileIO.ReadBoolean();
									while (flag)
									{
										fileIO.ReadString();
										fileIO.ReadString();
										fileIO.ReadSingle();
										fileIO.ReadSingle();
										fileIO.ReadBoolean();
										fileIO.ReadInt32();
										fileIO.ReadInt32();
										flag = fileIO.ReadBoolean();
									}
									flag = fileIO.ReadBoolean();
									while (flag)
									{
										fileIO.ReadString();
										fileIO.ReadSingle();
										fileIO.ReadSingle();
										flag = fileIO.ReadBoolean();
									}
									if (baseStream.Position != (long)array2[5])
									{
										result = false;
									}
									else
									{
										if (WorldFile.versionNumber >= 116 && WorldFile.versionNumber <= 121)
										{
											int num12 = fileIO.ReadInt32();
											for (int n = 0; n < num12; n++)
											{
												fileIO.ReadInt16();
												fileIO.ReadInt16();
											}
											if (baseStream.Position != (long)array2[6])
											{
												result = false;
												return result;
											}
										}
										if (WorldFile.versionNumber >= 122)
										{
											int num13 = fileIO.ReadInt32();
											for (int num14 = 0; num14 < num13; num14++)
											{
												TileEntity.Read(fileIO, false);
											}
										}
										if (WorldFile.versionNumber >= 170)
										{
											int num15 = fileIO.ReadInt32();
											for (int num16 = 0; num16 < num15; num16++)
											{
												fileIO.ReadInt64();
											}
										}
										bool flag2 = fileIO.ReadBoolean();
										string a = fileIO.ReadString();
										int num17 = fileIO.ReadInt32();
										bool flag3 = false;
										if (flag2 && (a == b || num17 == num2))
										{
											flag3 = true;
										}
										result = flag3;
									}
								}
							}
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
				result = false;
			}
			return result;
		}

		public static event Action OnWorldLoad;
	}
}
