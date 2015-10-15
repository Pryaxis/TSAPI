using System;
using System.Diagnostics;
using System.IO;
using TerrariaApi.Server;
namespace Terraria
{
	public class WorldFile
	{
		private static object padlock = new object();
		public static double tempTime = Main.time;
		public static bool tempRaining = false;
		public static float tempMaxRain = 0f;
		public static int tempRainTime = 0;
		public static bool tempDayTime = Main.dayTime;
		public static bool tempBloodMoon = Main.bloodMoon;
		public static bool tempEclipse = Main.eclipse;
		public static int tempMoonPhase = Main.moonPhase;
		public static int versionNumber;
		public static void loadWorld()
		{
			Main.checkXMas();
			Main.checkHalloween();
			if (!File.Exists(Main.worldPathName) && Main.autoGen)
			{
				for (int i = Main.worldPathName.Length - 1; i >= 0; i--)
				{
					if (Main.worldPathName.Substring(i, 1) == string.Concat(Path.DirectorySeparatorChar))
					{
						string path = Main.worldPathName.Substring(0, i);
						Directory.CreateDirectory(path);
						break;
					}
				}
				WorldGen.clearWorld();
				WorldGen.generateWorld(-1);
				WorldFile.saveWorld(false);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			using (FileStream fileStream = new FileStream(Main.worldPathName, FileMode.Open))
			{
				using (BinaryReader binaryReader = new BinaryReader(fileStream))
				{
					try
					{
						WorldGen.loadFailed = false;
						WorldGen.loadSuccess = false;
						int num = binaryReader.ReadInt32();
						WorldFile.versionNumber = num;
						int num2;
						if (num <= 87)
						{
							num2 = WorldFile.LoadWorld_Version1(binaryReader);
						}
						else
						{
							num2 = WorldFile.LoadWorld_Version2(binaryReader);
						}
						binaryReader.Close();
						fileStream.Close();
						if (num2 != 0)
						{
							WorldGen.loadFailed = true;
						}
						else
						{
							WorldGen.loadSuccess = true;
						}
						if (!WorldGen.loadFailed && WorldGen.loadSuccess)
						{
							WorldGen.gen = true;
							WorldGen.waterLine = Main.maxTilesY;
							Liquid.QuickWater(2, -1, -1);
							WorldGen.WaterCheck();
							int num3 = 0;
							Liquid.quickSettle = true;
							int num4 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
							float num5 = 0f;
							while (Liquid.numLiquid > 0 && num3 < 100000)
							{
								num3++;
								float num6 = (float)(num4 - (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer)) / (float)num4;
								if (Liquid.numLiquid + LiquidBuffer.numLiquidBuffer > num4)
								{
									num4 = Liquid.numLiquid + LiquidBuffer.numLiquidBuffer;
								}
								if (num6 > num5)
								{
									num5 = num6;
								}
								else
								{
									num6 = num5;
								}
								Main.statusText = string.Concat(new object[]
								{
									Lang.gen[27],
									" ",
									(int)(num6 * 100f / 2f + 50f),
									"%"
								});
								Liquid.UpdateLiquid();
							}
							Liquid.quickSettle = false;
							Main.weatherCounter = WorldGen.genRand.Next(3600, 18000);
							WorldGen.WaterCheck();
							WorldGen.gen = false;
							NPC.setFireFlyChance();
						}
					}
					catch
					{
						WorldGen.loadFailed = true;
						WorldGen.loadSuccess = false;
						try
						{
							binaryReader.Close();
							fileStream.Close();
						}
						catch
						{
						}
					}
				}
			}
		}

		public static void saveWorld(bool resetTime = false)
		{
			if (ServerApi.Hooks.InvokeWorldSave(resetTime))
			{
				return;
			}
			RealSaveWorld(resetTime);
		}

		public static void RealSaveWorld(bool resetTime = false)
		{
			if (Main.worldName == "")
			{
				Main.worldName = "World";
			}
			if (WorldGen.saveLock)
			{
				return;
			}
			WorldGen.saveLock = true;
			while (WorldGen.hardLock)
			{
				Main.statusText = Lang.gen[48];
			}
			lock (WorldFile.padlock)
			{
				try
				{
					Directory.CreateDirectory(Main.WorldPath);
				}
				catch
				{
				}
				if (!Main.skipMenu)
				{
					WorldFile.tempDayTime = Main.dayTime;
					WorldFile.tempTime = Main.time;
					WorldFile.tempMoonPhase = Main.moonPhase;
					WorldFile.tempBloodMoon = Main.bloodMoon;
					WorldFile.tempEclipse = Main.eclipse;
					if (resetTime)
					{
						WorldFile.tempDayTime = true;
						WorldFile.tempTime = 13500.0;
						WorldFile.tempMoonPhase = 0;
						WorldFile.tempBloodMoon = false;
						WorldFile.tempEclipse = false;
					}
					if (Main.worldPathName != null)
					{
						Stopwatch stopwatch = new Stopwatch();
						stopwatch.Start();
						string text = Main.worldPathName + ".sav";
						WorldFile.SaveWorld_Version2(text);
						if (!Main.validateSaves || WorldFile.validateWorld(text))
						{
							if (File.Exists(Main.worldPathName))
							{
								Main.statusText = Lang.gen[50];
								string destFileName = Main.worldPathName + ".bak";
								File.Copy(Main.worldPathName, destFileName, true);
							}
							File.Copy(text, Main.worldPathName, true);
							File.Delete(text);
						}
						else
						{
							File.Delete(text);
						}
						WorldGen.saveLock = false;
					}
				}
			}
		}
		public static int LoadWorld_Version1(BinaryReader fileIO)
		{
			int num = WorldFile.versionNumber;
			if (num > Main.curRelease)
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
			if (num >= 63)
			{
				Main.moonType = (int)fileIO.ReadByte();
			}
			else
			{
				WorldGen.randMoon();
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
			if (num >= 60)
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
			else
			{
				WorldGen.setCaveBacks();
			}
			Main.spawnTileX = fileIO.ReadInt32();
			Main.spawnTileY = fileIO.ReadInt32();
			Main.worldSurface = fileIO.ReadDouble();
			Main.rockLayer = fileIO.ReadDouble();
			WorldFile.tempTime = fileIO.ReadDouble();
			WorldFile.tempDayTime = fileIO.ReadBoolean();
			WorldFile.tempMoonPhase = fileIO.ReadInt32();
			WorldFile.tempBloodMoon = fileIO.ReadBoolean();
			if (num >= 70)
			{
				WorldFile.tempEclipse = fileIO.ReadBoolean();
				Main.eclipse = WorldFile.tempEclipse;
			}
			Main.dungeonX = fileIO.ReadInt32();
			Main.dungeonY = fileIO.ReadInt32();
			if (num >= 56)
			{
				WorldGen.crimson = fileIO.ReadBoolean();
			}
			else
			{
				WorldGen.crimson = false;
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
			WorldGen.shadowOrbCount = (int)fileIO.ReadByte();
			if (num >= 23)
			{
				WorldGen.altarCount = fileIO.ReadInt32();
				Main.hardMode = fileIO.ReadBoolean();
			}
			Main.invasionDelay = fileIO.ReadInt32();
			Main.invasionSize = fileIO.ReadInt32();
			Main.invasionType = fileIO.ReadInt32();
			Main.invasionX = fileIO.ReadDouble();
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
			else if (num >= 23 && WorldGen.altarCount == 0)
			{
				WorldGen.oreTier1 = -1;
				WorldGen.oreTier2 = -1;
				WorldGen.oreTier3 = -1;
			}
			else
			{
				WorldGen.oreTier1 = 107;
				WorldGen.oreTier2 = 108;
				WorldGen.oreTier3 = 111;
			}
			int style = 0;
			int style2 = 0;
			int style3 = 0;
			int style4 = 0;
			int style5 = 0;
			int style6 = 0;
			int style7 = 0;
			int style8 = 0;
			if (num >= 55)
			{
				style = (int)fileIO.ReadByte();
				style2 = (int)fileIO.ReadByte();
				style3 = (int)fileIO.ReadByte();
			}
			if (num >= 60)
			{
				style4 = (int)fileIO.ReadByte();
				style5 = (int)fileIO.ReadByte();
				style6 = (int)fileIO.ReadByte();
				style7 = (int)fileIO.ReadByte();
				style8 = (int)fileIO.ReadByte();
			}
			WorldGen.setBG(0, style);
			WorldGen.setBG(1, style2);
			WorldGen.setBG(2, style3);
			WorldGen.setBG(3, style4);
			WorldGen.setBG(4, style5);
			WorldGen.setBG(5, style6);
			WorldGen.setBG(6, style7);
			WorldGen.setBG(7, style8);
			if (num >= 60)
			{
				Main.cloudBGActive = (float)fileIO.ReadInt32();
				if (Main.cloudBGActive >= 1f)
				{
					Main.cloudBGAlpha = 1f;
				}
				else
				{
					Main.cloudBGAlpha = 0f;
				}
			}
			else
			{
				Main.cloudBGActive = (float)(-(float)WorldGen.genRand.Next(8640, 86400));
			}
			if (num >= 62)
			{
				Main.numClouds = (int)fileIO.ReadInt16();
				Main.windSpeedSet = fileIO.ReadSingle();
				Main.windSpeed = Main.windSpeedSet;
			}
			else
			{
				WorldGen.RandomWeather();
			}
			for (int i = 0; i < Main.maxTilesX; i++)
			{
				float num2 = (float)i / (float)Main.maxTilesX;
				Main.statusText = string.Concat(new object[]
				{
					Lang.gen[51],
					" ",
					(int)(num2 * 100f + 1f),
					"%"
				});
				for (int j = 0; j < Main.maxTilesY; j++)
				{
					Tile tile = Main.tile[i, j];
					int num3 = -1;
					tile.active(fileIO.ReadBoolean());
					if (tile.active())
					{
						if (num > 77)
						{
							num3 = (int)fileIO.ReadUInt16();
						}
						else
						{
							num3 = (int)fileIO.ReadByte();
						}
						tile.type = (ushort)num3;
						if (tile.type == TileID.MagicalIceBlock)
						{
							tile.active(false);
						}
						if (num < 72 && (tile.type == TileID.Jackolanterns || tile.type == TileID.Presents || tile.type == TileID.PineTree || tile.type == TileID.ChristmasTree || tile.type == TileID.Sinks))
						{
							tile.frameX = fileIO.ReadInt16();
							tile.frameY = fileIO.ReadInt16();
						}
						else if (Main.tileFrameImportant[num3])
						{
							if (num < 28 && num3 == 4)
							{
								tile.frameX = 0;
								tile.frameY = 0;
							}
							else if (num < 40 && tile.type == TileID.Platforms)
							{
								tile.frameX = 0;
								tile.frameY = 0;
							}
							else
							{
								tile.frameX = fileIO.ReadInt16();
								tile.frameY = fileIO.ReadInt16();
								if (tile.type == TileID.Timers)
								{
									tile.frameY = 0;
								}
							}
						}
						else
						{
							tile.frameX = -1;
							tile.frameY = -1;
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
						if (!Main.tileSolid[(int)tile.type])
						{
							tile.halfBrick(false);
						}
						if (num >= 49)
						{
							tile.slope(fileIO.ReadByte());
							if (!Main.tileSolid[(int)tile.type])
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
					int num4 = 0;
					if (num >= 25)
					{
						num4 = (int)fileIO.ReadInt16();
					}
					if (num3 != -1)
					{
						if ((double)j <= Main.worldSurface)
						{
							if ((double)(j + num4) <= Main.worldSurface)
							{
								WorldGen.tileCounts[num3] += (num4 + 1) * 5;
							}
							else
							{
								int num5 = (int)(Main.worldSurface - (double)j + 1.0);
								int num6 = num4 + 1 - num5;
								WorldGen.tileCounts[num3] += num5 * 5 + num6;
							}
						}
						else
						{
							WorldGen.tileCounts[num3] += num4 + 1;
						}
					}
					if (num4 > 0)
					{
						for (int k = j + 1; k < j + num4 + 1; k++)
						{
							Main.tile[i, k].CopyFrom(Main.tile[i, j]);
						}
						j += num4;
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
			int num7 = 40;
			if (num < 58)
			{
				num7 = 20;
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
						string text = fileIO.ReadString();
						if (text.Length > 20)
						{
							text = text.Substring(0, 20);
						}
						Main.chest[l].name = text;
					}
					for (int m = 0; m < 40; m++)
					{
						Main.chest[l].item[m] = new Item();
						if (m < num7)
						{
							int num8;
							if (num >= 59)
							{
								num8 = (int)fileIO.ReadInt16();
							}
							else
							{
								num8 = (int)fileIO.ReadByte();
							}
							if (num8 > 0)
							{
								if (num >= 38)
								{
									Main.chest[l].item[m].netDefaults(fileIO.ReadInt32());
								}
								else
								{
									string defaults = Item.VersionName(fileIO.ReadString(), num);
									Main.chest[l].item[m].SetDefaults(defaults);
								}
								Main.chest[l].item[m].stack = num8;
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
					string text2 = fileIO.ReadString();
					int num9 = fileIO.ReadInt32();
					int num10 = fileIO.ReadInt32();
					if (Main.tile[num9, num10].active() && (Main.tile[num9, num10].type == TileID.Signs || Main.tile[num9, num10].type == TileID.Tombstones))
					{
						Main.sign[n] = new Sign();
						Main.sign[n].x = num9;
						Main.sign[n].y = num10;
						Main.sign[n].text = text2;
					}
				}
			}
			bool flag = fileIO.ReadBoolean();
			int num11 = 0;
			while (flag)
			{
				Main.npc[num11].SetDefaults(fileIO.ReadString());
				if (num >= 83)
				{
					Main.npc[num11].displayName = fileIO.ReadString();
				}
				Main.npc[num11].position.X = fileIO.ReadSingle();
				Main.npc[num11].position.Y = fileIO.ReadSingle();
				Main.npc[num11].homeless = fileIO.ReadBoolean();
				Main.npc[num11].homeTileX = fileIO.ReadInt32();
				Main.npc[num11].homeTileY = fileIO.ReadInt32();
				flag = fileIO.ReadBoolean();
				num11++;
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
			if (num < 7)
			{
				return 0;
			}
			bool flag2 = fileIO.ReadBoolean();
			string a = fileIO.ReadString();
			int num12 = fileIO.ReadInt32();
			if (flag2 && (a == Main.worldName || num12 == Main.worldID))
			{
				return 0;
			}
			return 2;
		}
		public static void SaveWorld_Version2(string world)
		{
			FileStream fileStream = new FileStream(world, FileMode.Create, FileAccess.Write);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			int[] array = new int[10];
			array[0] = WorldFile.SaveFileFormatHeader(binaryWriter);
			array[1] = WorldFile.SaveWorldHeader(binaryWriter);
			array[2] = WorldFile.SaveWorldTiles(binaryWriter);
			array[3] = WorldFile.SaveChests(binaryWriter);
			array[4] = WorldFile.SaveSigns(binaryWriter);
			array[5] = WorldFile.SaveNPCs(binaryWriter);
			WorldFile.SaveFooter(binaryWriter);
			WorldFile.SaveHeaderPointers(binaryWriter, array);
			binaryWriter.Close();
			fileStream.Close();
		}
		private static int SaveFileFormatHeader(BinaryWriter writer)
		{
			short num = 340;
			short num2 = 10;
			writer.Write(Main.curRelease);
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
		private static int SaveHeaderPointers(BinaryWriter writer, int[] pointers)
		{
			writer.BaseStream.Position = 0L;
			writer.Write(Main.curRelease);
			writer.Write((short)pointers.Length);
			for (int i = 0; i < pointers.Length; i++)
			{
				writer.Write(pointers[i]);
			}
			return (int)writer.BaseStream.Position;
		}
		private static int SaveWorldHeader(BinaryWriter writer)
		{
			writer.Write(Main.worldName);
			writer.Write(Main.worldID);
			writer.Write((int)Main.leftWorld);
			writer.Write((int)Main.rightWorld);
			writer.Write((int)Main.topWorld);
			writer.Write((int)Main.bottomWorld);
			writer.Write(Main.maxTilesY);
			writer.Write(Main.maxTilesX);
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
					if (tile.active())
					{
						b2 |= 2;
						if (tile.type == TileID.MagicalIceBlock)
						{
							WorldGen.KillTile(i, j, false, false, false);
							if (!tile.active() && Main.netMode != 0)
							{
								NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 0, (float)i, (float)j, 0f, 0);
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
					if (tile.wall != WallID.None)
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
		private static int SaveChests(BinaryWriter writer)
		{
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					bool flag = false;
					for (int j = chest.x; j <= chest.x + 1; j++)
					{
						for (int k = chest.y; k <= chest.y + 1; k++)
						{
							if (j < 0 || k < 0 || j >= Main.maxTilesX || k >= Main.maxTilesY)
							{
								flag = true;
								break;
							}
							Tile tile = Main.tile[j, k];
							if (!tile.active() || tile.type != TileID.Containers)
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						Main.chest[i] = null;
					}
					else
					{
						num += 1;
					}
				}
			}
			writer.Write(num);
			writer.Write((short)Chest.maxItems);
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null)
				{
					writer.Write(chest.x);
					writer.Write(chest.y);
					writer.Write(chest.name);
					for (int l = 0; l < Chest.maxItems; l++)
					{
						Item item = chest.item[l];
						if (item == null)
						{
							writer.Write(0);
						}
						else
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
					}
				}
			}
			return (int)writer.BaseStream.Position;
		}
		private static int SaveSigns(BinaryWriter writer)
		{
			short num = 0;
			for (int i = 0; i < 1000; i++)
			{
				Sign sign = Main.sign[i];
				if (sign != null && sign.text != null)
				{
					num += 1;
				}
			}
			writer.Write(num);
			for (int j = 0; j < 1000; j++)
			{
				Sign sign = Main.sign[j];
				if (sign != null && sign.text != null)
				{
					writer.Write(sign.text);
					writer.Write(sign.x);
					writer.Write(sign.y);
				}
			}
			return (int)writer.BaseStream.Position;
		}
		private static int SaveNPCs(BinaryWriter writer)
		{
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && (nPC.townNPC & nPC.type != 368))
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
			return (int)writer.BaseStream.Position;
		}
		private static int SaveFooter(BinaryWriter writer)
		{
			writer.Write(true);
			writer.Write(Main.worldName);
			writer.Write(Main.worldID);
			return (int)writer.BaseStream.Position;
		}
		public static int LoadWorld_Version2(BinaryReader reader)
		{
			reader.BaseStream.Position = 0L;
			bool[] importance;
			int[] array;
			if (!WorldFile.LoadFileFormatHeader(reader, out importance, out array))
			{
				return 5;
			}
			if (reader.BaseStream.Position != (long)array[0])
			{
				return 5;
			}
			WorldFile.LoadHeader(reader);
			if (reader.BaseStream.Position != (long)array[1])
			{
				return 5;
			}
			WorldFile.LoadWorldTiles(reader, importance);
			if (reader.BaseStream.Position != (long)array[2])
			{
				return 5;
			}
			WorldFile.LoadChests(reader);
			if (reader.BaseStream.Position != (long)array[3])
			{
				return 5;
			}
			WorldFile.LoadSigns(reader);
			if (reader.BaseStream.Position != (long)array[4])
			{
				return 5;
			}
			WorldFile.LoadNPCs(reader);
			if (reader.BaseStream.Position != (long)array[5])
			{
				return 5;
			}
			return WorldFile.LoadFooter(reader);
		}
		private static bool LoadFileFormatHeader(BinaryReader reader, out bool[] importance, out int[] positions)
		{
			importance = null;
			positions = null;
			int num = reader.ReadInt32();
			WorldFile.versionNumber = num;
			short num2 = reader.ReadInt16();
			positions = new int[(int)num2];
			for (int i = 0; i < (int)num2; i++)
			{
				positions[i] = reader.ReadInt32();
			}
			short num3 = reader.ReadInt16();
			importance = new bool[(int)num3];
			byte b = 0;
			byte b2 = 128;
			for (int i = 0; i < (int)num3; i++)
			{
				if (b2 == 128)
				{
					b = reader.ReadByte();
					b2 = 1;
				}
				else
				{
					b2 = (byte)(b2 << 1);
				}
				if ((b & b2) == b2)
				{
					importance[i] = true;
				}
			}
			return true;
		}
		private static void LoadHeader(BinaryReader reader)
		{
			int num = WorldFile.versionNumber;
			Main.worldName = reader.ReadString();
			Main.worldID = reader.ReadInt32();
			Main.leftWorld = (float)reader.ReadInt32();
			Main.rightWorld = (float)reader.ReadInt32();
			Main.topWorld = (float)reader.ReadInt32();
			Main.bottomWorld = (float)reader.ReadInt32();
			Main.maxTilesY = reader.ReadInt32();
			Main.maxTilesX = reader.ReadInt32();
			WorldGen.clearWorld();
			Main.moonType = (int)reader.ReadByte();
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
			NPC.savedGoblin = reader.ReadBoolean();
			NPC.savedWizard = reader.ReadBoolean();
			NPC.savedMech = reader.ReadBoolean();
			NPC.downedGoblins = reader.ReadBoolean();
			NPC.downedClown = reader.ReadBoolean();
			NPC.downedFrost = reader.ReadBoolean();
			NPC.downedPirates = reader.ReadBoolean();
			WorldGen.shadowOrbSmashed = reader.ReadBoolean();
			WorldGen.spawnMeteor = reader.ReadBoolean();
			WorldGen.shadowOrbCount = (int)reader.ReadByte();
			WorldGen.altarCount = reader.ReadInt32();
			Main.hardMode = reader.ReadBoolean();
			Main.invasionDelay = reader.ReadInt32();
			Main.invasionSize = reader.ReadInt32();
			Main.invasionType = reader.ReadInt32();
			Main.invasionX = reader.ReadDouble();
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
			Main.cloudBGAlpha = (((double)Main.cloudBGActive < 1.0) ? 0f : 1f);
			Main.cloudBGActive = (float)(-(float)WorldGen.genRand.Next(8640, 86400));
			Main.numClouds = (int)reader.ReadInt16();
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
							if (tile.type == TileID.Timers)
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
		}
		private static void LoadChests(BinaryReader reader)
		{
			int num = (int)reader.ReadInt16();
			int num2 = (int)reader.ReadInt16();
			int num3;
			int num4;
			if (num2 < Chest.maxItems)
			{
				num3 = num2;
				num4 = 0;
			}
			else
			{
				num3 = Chest.maxItems;
				num4 = num2 - Chest.maxItems;
			}
			int i;
			for (i = 0; i < num; i++)
			{
				Chest chest = new Chest(false);
				chest.x = reader.ReadInt32();
				chest.y = reader.ReadInt32();
				chest.name = reader.ReadString();
				for (int j = 0; j < num3; j++)
				{
					short num5 = reader.ReadInt16();
					Item item = new Item();
					if (num5 > 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.stack = (int)num5;
						item.Prefix((int)reader.ReadByte());
					}
					else if (num5 < 0)
					{
						item.netDefaults(reader.ReadInt32());
						item.Prefix((int)reader.ReadByte());
						item.stack = 1;
					}
					chest.item[j] = item;
				}
				for (int j = 0; j < num4; j++)
				{
					short num5 = reader.ReadInt16();
					if (num5 > 0)
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
				if (tile.active() && (tile.type == TileID.Signs || tile.type == TileID.Tombstones))
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
			while (i < 1000)
			{
				Main.sign[i] = null;
				i++;
			}
		}
		private static void LoadNPCs(BinaryReader reader)
		{
			int num = 0;
			bool flag = reader.ReadBoolean();
			while (flag)
			{
				NPC nPC = Main.npc[num];
				nPC.SetDefaults(reader.ReadString());
				nPC.displayName = reader.ReadString();
				nPC.position.X = reader.ReadSingle();
				nPC.position.Y = reader.ReadSingle();
				nPC.homeless = reader.ReadBoolean();
				nPC.homeTileX = reader.ReadInt32();
				nPC.homeTileY = reader.ReadInt32();
				num++;
				flag = reader.ReadBoolean();
			}
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
		public static bool validateWorld(string validatePath)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			bool result;
			using (FileStream fileStream = new FileStream(validatePath, FileMode.Open))
			{
				using (BinaryReader binaryReader = new BinaryReader(fileStream))
				{
					try
					{
						int num = binaryReader.ReadInt32();
						if (num != 0)
						{
							if (num <= Main.curRelease)
							{
								fileStream.Position = 0L;
								bool[] array;
								int[] array2;
								if (!WorldFile.LoadFileFormatHeader(binaryReader, out array, out array2))
								{
									result = false;
									return result;
								}
								string b = binaryReader.ReadString();
								int num2 = binaryReader.ReadInt32();
								binaryReader.ReadInt32();
								binaryReader.ReadInt32();
								binaryReader.ReadInt32();
								binaryReader.ReadInt32();
								int num3 = binaryReader.ReadInt32();
								int num4 = binaryReader.ReadInt32();
								fileStream.Position = (long)array2[1];
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
										byte b3 = binaryReader.ReadByte();
										if ((b3 & 1) == 1)
										{
											byte b4 = binaryReader.ReadByte();
											if ((b4 & 1) == 1)
											{
												b2 = binaryReader.ReadByte();
											}
										}
										byte b5;
										if ((b3 & 2) == 2)
										{
											int num6;
											if ((b3 & 32) == 32)
											{
												b5 = binaryReader.ReadByte();
												num6 = (int)binaryReader.ReadByte();
												num6 = (num6 << 8 | (int)b5);
											}
											else
											{
												num6 = (int)binaryReader.ReadByte();
											}
											if (array[num6])
											{
												binaryReader.ReadInt16();
												binaryReader.ReadInt16();
											}
											if ((b2 & 8) == 8)
											{
												binaryReader.ReadByte();
											}
										}
										if ((b3 & 4) == 4)
										{
											binaryReader.ReadByte();
											if ((b2 & 16) == 16)
											{
												binaryReader.ReadByte();
											}
										}
										if ((b3 & 24) >> 3 != 0)
										{
											binaryReader.ReadByte();
										}
										b5 = (byte)((b3 & 192) >> 6);
										int num7;
										if (b5 == 0)
										{
											num7 = 0;
										}
										else if (b5 == 1)
										{
											num7 = (int)binaryReader.ReadByte();
										}
										else
										{
											num7 = (int)binaryReader.ReadInt16();
										}
										j += num7;
									}
								}
								if (fileStream.Position != (long)array2[2])
								{
									result = false;
									return result;
								}
								int num8 = (int)binaryReader.ReadInt16();
								int num9 = (int)binaryReader.ReadInt16();
								for (int k = 0; k < num8; k++)
								{
									binaryReader.ReadInt32();
									binaryReader.ReadInt32();
									binaryReader.ReadString();
									for (int l = 0; l < num9; l++)
									{
										int num10 = (int)binaryReader.ReadInt16();
										if (num10 > 0)
										{
											binaryReader.ReadInt32();
											binaryReader.ReadByte();
										}
									}
								}
								if (fileStream.Position != (long)array2[3])
								{
									result = false;
									return result;
								}
								int num11 = (int)binaryReader.ReadInt16();
								for (int m = 0; m < num11; m++)
								{
									binaryReader.ReadString();
									binaryReader.ReadInt32();
									binaryReader.ReadInt32();
								}
								if (fileStream.Position != (long)array2[4])
								{
									result = false;
									return result;
								}
								bool flag = binaryReader.ReadBoolean();
								while (flag)
								{
									binaryReader.ReadString();
									binaryReader.ReadString();
									binaryReader.ReadSingle();
									binaryReader.ReadSingle();
									binaryReader.ReadBoolean();
									binaryReader.ReadInt32();
									binaryReader.ReadInt32();
									flag = binaryReader.ReadBoolean();
								}
								if (fileStream.Position != (long)array2[5])
								{
									result = false;
									return result;
								}
								bool flag2 = binaryReader.ReadBoolean();
								string a = binaryReader.ReadString();
								int num12 = binaryReader.ReadInt32();
								bool flag3 = false;
								if (flag2 && (a == b || num12 == num2))
								{
									flag3 = true;
								}
								binaryReader.Close();
								fileStream.Close();
								result = flag3;
								return result;
							}
						}
						try
						{
							binaryReader.Close();
							fileStream.Close();
						}
						catch
						{
						}
						result = false;
					}
					catch (Exception value)
					{
						using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
						{
							streamWriter.WriteLine(DateTime.Now);
							streamWriter.WriteLine(value);
							streamWriter.WriteLine("");
						}
						try
						{
							binaryReader.Close();
							fileStream.Close();
						}
						catch
						{
						}
						result = false;
					}
				}
			}
			return result;
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
						if (num > 0 && num <= Main.curRelease)
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
	}
}
