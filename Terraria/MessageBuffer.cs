
using System;
using System.Collections.Generic;
using System.IO;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
using Terraria.Net;
using Terraria.Net.Sockets;
using TerrariaApi.Server;

namespace Terraria
{
	public class MessageBuffer
	{
		public const int readBufferMax = 131070;

		public const int writeBufferMax = 131070;

		public bool broadcast;

		public byte[] readBuffer = new byte[131070];

		//public byte[] writeBuffer = new byte[131070];

		public bool writeLocked;

		public int messageLength;

		public int totalData;

		public int whoAmI;

		public int spamCount;

		public int maxSpam;

		public bool checkBytes;

		public MemoryStream readerStream;

		//public MemoryStream writerStream;

		public BinaryReader reader;

		//public BinaryWriter writer;

		public MessageBuffer()
		{
		}

		public void GetData(int start, int length)
		{
			List<Point> points;
			List<Point> points1;
			int num;
			TileEntity tileEntity;
			if (this.whoAmI >= 256)
			{
				Netplay.Connection.TimeOutTimer = 0;
			}
			else
			{
				Netplay.Clients[this.whoAmI].TimeOutTimer = 0;
			}
			byte num1 = 0;
			int num2 = 0;
			num2 = start + 1;
			num1 = this.readBuffer[start];
			if (ServerApi.Hooks.InvokeNetGetData(ref num1, this, ref num2, ref length))
			{
				return;
			}
			Main.rxMsg = Main.rxMsg + 1;
			Main.rxData = Main.rxData + length;
			if (Main.netMode == 1 && Netplay.Connection.StatusMax > 0)
			{
				RemoteServer connection = Netplay.Connection;
				connection.StatusCount = connection.StatusCount + 1;
			}
			if (Main.verboseNetplay)
			{
				int num3 = start;
				while (num3 < start + length)
				{
					num3++;
				}
				for (int i = start; i < start + length; i++)
				{
					byte num4 = this.readBuffer[i];
				}
			}
			if (Main.netMode == 2 && num1 != 38 && Netplay.Clients[this.whoAmI].State == -1)
			{
				NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0f, 0f, 0f, 0, 0, 0);
				return;
			}
			if (Main.netMode == 2 && Netplay.Clients[this.whoAmI].State < 10 && num1 > 12 && num1 != 93 && num1 != 16 && num1 != 42 && num1 != 50 && num1 != 38 && num1 != 68)
			{
				NetMessage.BootPlayer(this.whoAmI, Lang.mp[2]);
			}
			if (this.reader == null)
			{
				this.ResetReader();
			}
			this.reader.BaseStream.Position = (long)num2;
			byte num5 = num1;

//			Console.WriteLine("Received: {0}", num5);

			switch (num5)
			{
				case 1:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					if (Main.dedServ && Netplay.IsBanned(Netplay.Clients[this.whoAmI].Socket.GetRemoteAddress()))
					{
						NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[3], 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					if (Netplay.Clients[this.whoAmI].State != 0)
					{
						return;
					}
					if (this.reader.ReadString() != string.Concat("Terraria", Main.curRelease))
					{
						NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[4], 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					if (string.IsNullOrEmpty(Netplay.ServerPassword))
					{
						Netplay.Clients[this.whoAmI].State = 1;
						NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					Netplay.Clients[this.whoAmI].State = -1;
					NetMessage.SendData(37, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 2:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					Netplay.disconnect = true;
					Main.statusText = this.reader.ReadString();
					return;
				}
				case 3:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					if (Netplay.Connection.State == 1)
					{
						Netplay.Connection.State = 2;
					}
					int num6 = this.reader.ReadByte();
					if (num6 != Main.myPlayer)
					{
						Main.player[num6] = Main.ActivePlayerFileData.Player;
						Main.player[Main.myPlayer] = new Player();
					}
					Main.player[num6].whoAmI = num6;
					Main.myPlayer = num6;
					Player player = Main.player[num6];
					NetMessage.SendData(4, -1, -1, player.name, num6, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(68, -1, -1, "", num6, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(16, -1, -1, "", num6, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(42, -1, -1, "", num6, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(50, -1, -1, "", num6, 0f, 0f, 0f, 0, 0, 0);
					for (int j = 0; j < 59; j++)
					{
						NetMessage.SendData(5, -1, -1, player.inventory[j].name, num6, (float)j, (float)player.inventory[j].prefix, 0f, 0, 0, 0);
					}
					for (int k = 0; k < (int)player.armor.Length; k++)
					{
						NetMessage.SendData(5, -1, -1, player.armor[k].name, num6, (float)(59 + k), (float)player.armor[k].prefix, 0f, 0, 0, 0);
					}
					for (int l = 0; l < (int)player.dye.Length; l++)
					{
						NetMessage.SendData(5, -1, -1, player.dye[l].name, num6, (float)(58 + (int)player.armor.Length + 1 + l), (float)player.dye[l].prefix, 0f, 0, 0, 0);
					}
					for (int m = 0; m < (int)player.miscEquips.Length; m++)
					{
						NetMessage.SendData(5, -1, -1, "", num6, (float)(58 + (int)player.armor.Length + (int)player.dye.Length + 1 + m), (float)player.miscEquips[m].prefix, 0f, 0, 0, 0);
					}
					for (int n = 0; n < (int)player.miscDyes.Length; n++)
					{
						NetMessage.SendData(5, -1, -1, "", num6, (float)(58 + (int)player.armor.Length + (int)player.dye.Length + (int)player.miscEquips.Length + 1 + n), (float)player.miscDyes[n].prefix, 0f, 0, 0, 0);
					}
					for (int o = 0; o < (int)player.bank.item.Length; o++)
					{
						NetMessage.SendData(5, -1, -1, "", num6, (float)(58 + (int)player.armor.Length + (int)player.dye.Length + (int)player.miscEquips.Length + (int)player.miscDyes.Length + 1 + o), (float)player.bank.item[o].prefix, 0f, 0, 0, 0);
					}
					for (int p = 0; p < (int)player.bank2.item.Length; p++)
					{
						NetMessage.SendData(5, -1, -1, "", num6, (float)(58 + (int)player.armor.Length + (int)player.dye.Length + (int)player.miscEquips.Length + (int)player.miscDyes.Length + (int)player.bank.item.Length + 1 + p), (float)player.bank2.item[p].prefix, 0f, 0, 0, 0);
					}
					NetMessage.SendData(6, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					if (Netplay.Connection.State != 2)
					{
						return;
					}
					Netplay.Connection.State = 3;
					return;
				}
				case 4:
				{
					int num7 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num7 = this.whoAmI;
					}
					if (num7 == Main.myPlayer && !Main.ServerSideCharacter)
					{
						return;
					}
					Player item1 = Main.player[num7];
					item1.whoAmI = num7;
					item1.skinVariant = this.reader.ReadByte();
					item1.skinVariant = (int)MathHelper.Clamp((float)item1.skinVariant, 0f, 7f);
					item1.hair = this.reader.ReadByte();
					if (item1.hair >= 134)
					{
						item1.hair = 0;
					}
					item1.name = this.reader.ReadString().Trim().Trim();
					item1.hairDye = this.reader.ReadByte();
					BitsByte bitsByte = this.reader.ReadByte();
					for (int q = 0; q < 8; q++)
					{
						item1.hideVisual[q] = bitsByte[q];
					}
					bitsByte = this.reader.ReadByte();
					for (int r = 0; r < 2; r++)
					{
						item1.hideVisual[r + 8] = bitsByte[r];
					}
					item1.hideMisc = this.reader.ReadByte();
					item1.hairColor = this.reader.ReadRGB();
					item1.skinColor = this.reader.ReadRGB();
					item1.eyeColor = this.reader.ReadRGB();
					item1.shirtColor = this.reader.ReadRGB();
					item1.underShirtColor = this.reader.ReadRGB();
					item1.pantsColor = this.reader.ReadRGB();
					item1.shoeColor = this.reader.ReadRGB();
					BitsByte bitsByte1 = this.reader.ReadByte();
					item1.difficulty = 0;
					if (bitsByte1[0])
					{
						Player player1 = item1;
						player1.difficulty = (byte)(player1.difficulty + 1);
					}
					if (bitsByte1[1])
					{
						Player player2 = item1;
						player2.difficulty = (byte)(player2.difficulty + 2);
					}
					item1.extraAccessory = bitsByte1[2];
					if (Main.netMode != 2)
					{
						return;
					}
					bool flag = false;
					if (Netplay.Clients[this.whoAmI].State < 10)
					{
						for (int s = 0; s < 255; s++)
						{
							if (s != num7 && item1.name == Main.player[s].name && Netplay.Clients[s].IsActive)
							{
								flag = true;
							}
						}
					}
					if (flag)
					{
						if (!ServerApi.Hooks.InvokeNetNameCollision(num7, item1.name))
						{
							NetMessage.SendData(2, this.whoAmI, -1, string.Concat(item1.name, " ", Lang.mp[5]), 0, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
					if (item1.name.Length > Player.nameLen)
					{
						NetMessage.SendData(2, this.whoAmI, -1, "Name is too long.", 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					if (item1.name == "")
					{
						NetMessage.SendData(2, this.whoAmI, -1, "Empty name.", 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					Netplay.Clients[this.whoAmI].Name = item1.name;
					Netplay.Clients[this.whoAmI].Name = item1.name;
					NetMessage.SendData(4, -1, this.whoAmI, item1.name, num7, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 5:
				{
					int num8 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num8 = this.whoAmI;
					}
					if (num8 == Main.myPlayer && !Main.ServerSideCharacter && !Main.player[num8].IsStackingItems())
					{
						return;
					}
					Player item1 = Main.player[num8];
					lock (item1)
					{
						int num9 = this.reader.ReadByte();
						int num10 = this.reader.ReadInt16();
						int num11 = this.reader.ReadByte();
						int num12 = this.reader.ReadInt16();
						Item[] itemArray = null;
						int num13 = 0;
						bool flag1 = false;
						if (num9 > 58 + (int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length + (int)item1.miscDyes.Length + (int)item1.bank.item.Length + (int)item1.bank2.item.Length)
						{
							flag1 = true;
						}
						else if (num9 > 58 + (int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length + (int)item1.miscDyes.Length + (int)item1.bank.item.Length)
						{
							num13 = num9 - 58 - ((int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length + (int)item1.miscDyes.Length + (int)item1.bank.item.Length) - 1;
							itemArray = item1.bank2.item;
						}
						else if (num9 > 58 + (int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length + (int)item1.miscDyes.Length)
						{
							num13 = num9 - 58 - ((int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length + (int)item1.miscDyes.Length) - 1;
							itemArray = item1.bank.item;
						}
						else if (num9 > 58 + (int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length)
						{
							num13 = num9 - 58 - ((int)item1.armor.Length + (int)item1.dye.Length + (int)item1.miscEquips.Length) - 1;
							itemArray = item1.miscDyes;
						}
						else if (num9 > 58 + (int)item1.armor.Length + (int)item1.dye.Length)
						{
							num13 = num9 - 58 - ((int)item1.armor.Length + (int)item1.dye.Length) - 1;
							itemArray = item1.miscEquips;
						}
						else if (num9 > 58 + (int)item1.armor.Length)
						{
							num13 = num9 - 58 - (int)item1.armor.Length - 1;
							itemArray = item1.dye;
						}
						else if (num9 <= 58)
						{
							num13 = num9;
							itemArray = item1.inventory;
						}
						else
						{
							num13 = num9 - 58 - 1;
							itemArray = item1.armor;
						}
						if (flag1)
						{
							item1.trashItem = new Item();
							item1.trashItem.netDefaults(num12);
							item1.trashItem.stack = num10;
							item1.trashItem.Prefix(num11);
						}
						else if (num9 > 58)
						{
							itemArray[num13] = new Item();
							itemArray[num13].netDefaults(num12);
							itemArray[num13].stack = num10;
							itemArray[num13].Prefix(num11);
						}
						else
						{
							int num14 = itemArray[num13].type;
							int num15 = itemArray[num13].stack;
							itemArray[num13] = new Item();
							itemArray[num13].netDefaults(num12);
							itemArray[num13].stack = num10;
							itemArray[num13].Prefix(num11);
							if (num8 == Main.myPlayer && num13 == 58)
							{
								Main.mouseItem = itemArray[num13].Clone();
							}
							if (num8 == Main.myPlayer && Main.netMode == 1)
							{
								Main.player[num8].inventoryChestStack[num9] = false;
							}
						}
						if (Main.netMode == 2 && num8 == this.whoAmI)
						{
							NetMessage.SendData(5, -1, this.whoAmI, "", num8, (float)num9, (float)num11, 0f, 0, 0, 0);
						}
						return;
					}
				}
				case 6:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					if (Netplay.Clients[this.whoAmI].State == 1)
					{
						Netplay.Clients[this.whoAmI].State = 2;
						Netplay.Clients[this.whoAmI].ResetSections();
					}
					NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					Main.SyncAnInvasion(this.whoAmI);
					return;
				}
				case 7:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					Main.time = (double)this.reader.ReadInt32();
					BitsByte bitsByte2 = this.reader.ReadByte();
					Main.dayTime = bitsByte2[0];
					Main.bloodMoon = bitsByte2[1];
					Main.eclipse = bitsByte2[2];
					Main.moonPhase = this.reader.ReadByte();
					Main.maxTilesX = this.reader.ReadInt16();
					Main.maxTilesY = this.reader.ReadInt16();
					Main.spawnTileX = this.reader.ReadInt16();
					Main.spawnTileY = this.reader.ReadInt16();
					Main.worldSurface = (double)this.reader.ReadInt16();
					Main.rockLayer = (double)this.reader.ReadInt16();
					Main.worldID = this.reader.ReadInt32();
					Main.worldName = this.reader.ReadString();
					Main.moonType = this.reader.ReadByte();
					WorldGen.setBG(0, (int)this.reader.ReadByte());
					WorldGen.setBG(1, (int)this.reader.ReadByte());
					WorldGen.setBG(2, (int)this.reader.ReadByte());
					WorldGen.setBG(3, (int)this.reader.ReadByte());
					WorldGen.setBG(4, (int)this.reader.ReadByte());
					WorldGen.setBG(5, (int)this.reader.ReadByte());
					WorldGen.setBG(6, (int)this.reader.ReadByte());
					WorldGen.setBG(7, (int)this.reader.ReadByte());
					Main.iceBackStyle = this.reader.ReadByte();
					Main.jungleBackStyle = this.reader.ReadByte();
					Main.hellBackStyle = this.reader.ReadByte();
					Main.windSpeedSet = this.reader.ReadSingle();
					Main.numClouds = this.reader.ReadByte();
					for (int t = 0; t < 3; t++)
					{
						Main.treeX[t] = this.reader.ReadInt32();
					}
					for (int u = 0; u < 4; u++)
					{
						Main.treeStyle[u] = this.reader.ReadByte();
					}
					for (int v = 0; v < 3; v++)
					{
						Main.caveBackX[v] = this.reader.ReadInt32();
					}
					for (int w = 0; w < 4; w++)
					{
						Main.caveBackStyle[w] = this.reader.ReadByte();
					}
					Main.maxRaining = this.reader.ReadSingle();
					Main.raining = Main.maxRaining > 0f;
					BitsByte bitsByte3 = this.reader.ReadByte();
					WorldGen.shadowOrbSmashed = bitsByte3[0];
					NPC.downedBoss1 = bitsByte3[1];
					NPC.downedBoss2 = bitsByte3[2];
					NPC.downedBoss3 = bitsByte3[3];
					Main.hardMode = bitsByte3[4];
					NPC.downedClown = bitsByte3[5];
					Main.ServerSideCharacter = bitsByte3[6];
					NPC.downedPlantBoss = bitsByte3[7];
					BitsByte bitsByte4 = this.reader.ReadByte();
					NPC.downedMechBoss1 = bitsByte4[0];
					NPC.downedMechBoss2 = bitsByte4[1];
					NPC.downedMechBoss3 = bitsByte4[2];
					NPC.downedMechBossAny = bitsByte4[3];
					float cloudbg = 0;
					if (bitsByte4[4])
					{
						cloudbg = 1;
					}
					Main.cloudBGActive = (float)cloudbg;
					WorldGen.crimson = bitsByte4[5];
					Main.pumpkinMoon = bitsByte4[6];
					Main.snowMoon = bitsByte4[7];
					BitsByte bitsByte5 = this.reader.ReadByte();
					Main.expertMode = bitsByte5[0];
					Main.fastForwardTime = bitsByte5[1];
					Main.UpdateSundial();
					bool flag1 = bitsByte5[2];
					NPC.downedSlimeKing = bitsByte5[3];
					NPC.downedQueenBee = bitsByte5[4];
					NPC.downedFishron = bitsByte5[5];
					NPC.downedMartians = bitsByte5[6];
					NPC.downedAncientCultist = bitsByte5[7];
					BitsByte bitsByte6 = this.reader.ReadByte();
					NPC.downedMoonlord = bitsByte6[0];
					NPC.downedHalloweenKing = bitsByte6[1];
					NPC.downedHalloweenTree = bitsByte6[2];
					NPC.downedChristmasIceQueen = bitsByte6[3];
					NPC.downedChristmasSantank = bitsByte6[4];
					NPC.downedChristmasTree = bitsByte6[5];
					if (!flag1)
					{
						Main.StopSlimeRain(true);
					}
					else
					{
						Main.StartSlimeRain(true);
					}
					Main.invasionType = this.reader.ReadSByte();
					Main.LobbyId = this.reader.ReadUInt64();
					if (Netplay.Connection.State != 3)
						return;
					Netplay.Connection.State = 4;
					return;
				}
				case 8:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int sectionX = this.reader.ReadInt32();
					int sectionY = this.reader.ReadInt32();
					bool flag2 = true;
					if (sectionX == -1 || sectionY == -1)
					{
						flag2 = false;
					}
					else if (sectionX < 10 || sectionX > Main.maxTilesX - 10)
					{
						flag2 = false;
					}
					else if (sectionY < 10 || sectionY > Main.maxTilesY - 10)
					{
						flag2 = false;
					}
					int sectionX1 = Netplay.GetSectionX(Main.spawnTileX) - 2;
					int sectionY1 = Netplay.GetSectionY(Main.spawnTileY) - 1;
					int num16 = sectionX1 + 5;
					int num17 = sectionY1 + 3;
					if (sectionX1 < 0)
					{
						sectionX1 = 0;
					}
					if (num16 >= Main.maxSectionsX)
					{
						num16 = Main.maxSectionsX - 1;
					}
					if (sectionY1 < 0)
					{
						sectionY1 = 0;
					}
					if (num17 >= Main.maxSectionsY)
					{
						num17 = Main.maxSectionsY - 1;
					}
					int count = (num16 - sectionX1) * (num17 - sectionY1);
					List<Point> points2 = new List<Point>();
					for (int x = sectionX1; x < num16; x++)
					{
						for (int y = sectionY1; y < num17; y++)
						{
							points2.Add(new Point(x, y));
						}
					}
					int num18 = -1;
					int num19 = -1;
					if (flag2)
					{
						sectionX = Netplay.GetSectionX(sectionX) - 2;
						sectionY = Netplay.GetSectionY(sectionY) - 1;
						num18 = sectionX + 5;
						num19 = sectionY + 3;
						if (sectionX < 0)
						{
							sectionX = 0;
						}
						if (num18 >= Main.maxSectionsX)
						{
							num18 = Main.maxSectionsX - 1;
						}
						if (sectionY < 0)
						{
							sectionY = 0;
						}
						if (num19 >= Main.maxSectionsY)
						{
							num19 = Main.maxSectionsY - 1;
						}
						for (int a = sectionX; a < num18; a++)
						{
							for (int b = sectionY; b < num19; b++)
							{
								if (a < sectionX1 || a >= num16 || b < sectionY1 || b >= num17)
								{
									points2.Add(new Point(a, b));
									count++;
								}
							}
						}
					}
					int num20 = 1;
					PortalHelper.SyncPortalsOnPlayerJoin(this.whoAmI, 1, points2, out points, out points1);
					count = count + points.Count;
					if (Netplay.Clients[this.whoAmI].State == 2)
					{
						Netplay.Clients[this.whoAmI].State = 3;
					}
					NetMessage.SendData(9, this.whoAmI, -1, Lang.inter[44], count, 0f, 0f, 0f, 0, 0, 0);
					Netplay.Clients[this.whoAmI].StatusText2 = "is receiving tile data";
					RemoteClient clients = Netplay.Clients[this.whoAmI];
					clients.StatusMax = clients.StatusMax + count;
					for (int c = sectionX1; c < num16; c++)
					{
						for (int d = sectionY1; d < num17; d++)
						{
							NetMessage.SendSection(this.whoAmI, c, d, false);
						}
					}
					NetMessage.SendData(11, this.whoAmI, -1, "", sectionX1, (float)sectionY1, (float)(num16 - 1), (float)(num17 - 1), 0, 0, 0);
					if (flag2)
					{
						for (int e = sectionX; e < num18; e++)
						{
							for (int f = sectionY; f < num19; f++)
							{
								NetMessage.SendSection(this.whoAmI, e, f, true);
							}
						}
						NetMessage.SendData(11, this.whoAmI, -1, "", sectionX, (float)sectionY, (float)(num18 - 1), (float)(num19 - 1), 0, 0, 0);
					}
					for (int g = 0; g < points.Count; g++)
					{
						NetMessage.SendSection(this.whoAmI, points[g].X, points[g].Y, true);
					}
					for (int h = 0; h < points1.Count; h++)
					{
						NetMessage.SendData(11, this.whoAmI, -1, "", points1[h].X - num20, (float)(points1[h].Y - num20), (float)(points1[h].X + num20 + 1), (float)(points1[h].Y + num20 + 1), 0, 0, 0);
					}
					for (int i1 = 0; i1 < 400; i1++)
					{
						if (Main.item[i1].active)
						{
							NetMessage.SendData(21, this.whoAmI, -1, "", i1, 0f, 0f, 0f, 0, 0, 0);
							NetMessage.SendData(22, this.whoAmI, -1, "", i1, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					for (int j1 = 0; j1 < 200; j1++)
					{
						if (Main.npc[j1].active)
						{
							NetMessage.SendData(23, this.whoAmI, -1, "", j1, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					for (int k1 = 0; k1 < 1000; k1++)
					{
						if (Main.projectile[k1].active && (Main.projPet[Main.projectile[k1].type] || Main.projectile[k1].netImportant))
						{
							NetMessage.SendData(27, this.whoAmI, -1, "", k1, 0f, 0f, 0f, 0, 0, 0);
						}
					}
					for (int l1 = 0; l1 < 251; l1++)
					{
						NetMessage.SendData(83, this.whoAmI, -1, "", l1, 0f, 0f, 0f, 0, 0, 0);
					}
					NetMessage.SendData(49, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(57, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(103, -1, -1, "", NPC.MoonLordCountdown, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(101, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 9:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					RemoteServer statusMax = Netplay.Connection;
					statusMax.StatusMax = statusMax.StatusMax + this.reader.ReadInt32();
					Netplay.Connection.StatusText = this.reader.ReadString();
					return;
				}
				case 10:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					NetMessage.DecompressTileBlock(this.readBuffer, num2, length);
					return;
				}
				case 11:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					WorldGen.SectionTileFrame(this.reader.ReadInt16(), this.reader.ReadInt16(), this.reader.ReadInt16(), this.reader.ReadInt16());
					return;
				}
				case 12:
				{
					int num21 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num21 = this.whoAmI;
					}
					Player player4 = Main.player[num21];
					player4.SpawnX = this.reader.ReadInt16();
					player4.SpawnY = this.reader.ReadInt16();
					player4.Spawn();
					if (num21 == Main.myPlayer && Main.netMode != 2)
					{
						Main.ActivePlayerFileData.StartPlayTimer();
						Player.EnterWorld(Main.player[Main.myPlayer]);
					}
					if (Main.netMode != 2 || Netplay.Clients[this.whoAmI].State < 3)
					{
						return;
					}
					if (Netplay.Clients[this.whoAmI].State != 3)
					{
						NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					Netplay.Clients[this.whoAmI].State = 10;
					NetMessage.greetPlayer(this.whoAmI);
					NetMessage.buffer[this.whoAmI].broadcast = true;
					//NetMessage.syncPlayers();
					NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(74, this.whoAmI, -1, Main.player[this.whoAmI].name, Main.anglerQuest, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 13:
				{
					int num22 = this.reader.ReadByte();
					if (num22 == Main.myPlayer && !Main.ServerSideCharacter)
					{
						return;
					}
					if (Main.netMode == 2)
					{
						num22 = this.whoAmI;
					}
					Player item2 = Main.player[num22];
					BitsByte bitsByte7 = this.reader.ReadByte();
					item2.controlUp = bitsByte7[0];
					item2.controlDown = bitsByte7[1];
					item2.controlLeft = bitsByte7[2];
					item2.controlRight = bitsByte7[3];
					item2.controlJump = bitsByte7[4];
					item2.controlUseItem = bitsByte7[5];
					item2.direction = (bitsByte7[6] ? 1 : -1);
					BitsByte bitsByte8 = this.reader.ReadByte();
					if (!bitsByte8[0])
					{
						item2.pulley = false;
					}
					else
					{
						item2.pulley = true;
						item2.pulleyDir = (byte)((bitsByte8[1] ? 2 : 1));
					}
					item2.selectedItem = this.reader.ReadByte();
					item2.position = this.reader.ReadVector2();
					if (bitsByte8[2])
					{
						item2.velocity = this.reader.ReadVector2();
					}
					item2.vortexStealthActive = bitsByte8[3];
					item2.gravDir = (float)((bitsByte8[4] ? 1 : -1));
					if (Main.netMode != 2 || Netplay.Clients[this.whoAmI].State != 10)
					{
						return;
					}
					NetMessage.SendData(13, -1, this.whoAmI, "", num22, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 14:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num23 = this.reader.ReadByte();
					if (this.reader.ReadByte() != 1)
					{
						Main.player[num23].active = false;
						return;
					}
					if (!Main.player[num23].active)
					{
						Main.player[num23] = new Player();
					}
					Main.player[num23].active = true;
					return;
				}
				case 15:
				case 67:
				case 93:
				case 94:
				case 98:
				{
					return;
				}
				case 16:
				{
					int num24 = this.reader.ReadByte();
					if (num24 == Main.myPlayer && !Main.ServerSideCharacter)
					{
						return;
					}
					if (Main.netMode == 2)
					{
						num24 = this.whoAmI;
					}
					Player player5 = Main.player[num24];
					player5.statLife = this.reader.ReadInt16();
					player5.statLifeMax = this.reader.ReadInt16();
					if (player5.statLifeMax < 100)
					{
						player5.statLifeMax = 100;
					}
					player5.dead = player5.statLife <= 0;
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(16, -1, this.whoAmI, "", num24, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 17:
				{
					byte num25 = this.reader.ReadByte();
					int num26 = this.reader.ReadInt16();
					int num27 = this.reader.ReadInt16();
					short num28 = this.reader.ReadInt16();
					int num29 = this.reader.ReadByte();
					bool flag3 = num28 == 1;
					if (!WorldGen.InWorld(num26, num27, 3))
					{
						return;
					}
					if (Main.tile[num26, num27] == null)
					{
						Main.tile[num26, num27] = new Tile();
					}
					if (Main.netMode == 2)
					{
						if (!flag3)
						{
							if (num25 == 0 || num25 == 2 || num25 == 4)
							{
								RemoteClient spamDeleteBlock = Netplay.Clients[this.whoAmI];
								spamDeleteBlock.SpamDeleteBlock = spamDeleteBlock.SpamDeleteBlock + 1f;
							}
							if (num25 == 1 || num25 == 3)
							{
								RemoteClient spamAddBlock = Netplay.Clients[this.whoAmI];
								spamAddBlock.SpamAddBlock = spamAddBlock.SpamAddBlock + 1f;
							}
						}
						if (!Netplay.Clients[this.whoAmI].TileSections[Netplay.GetSectionX(num26), Netplay.GetSectionY(num27)])
						{
							flag3 = true;
						}
					}
					if (num25 == 0)
					{
						WorldGen.KillTile(num26, num27, flag3, false, false);
					}
					if (num25 == 1)
					{
						WorldGen.PlaceTile(num26, num27, num28, false, true, -1, num29);
					}
					if (num25 == 2)
					{
						WorldGen.KillWall(num26, num27, flag3);
					}
					if (num25 == 3)
					{
						WorldGen.PlaceWall(num26, num27, num28, false);
					}
					if (num25 == 4)
					{
						WorldGen.KillTile(num26, num27, flag3, false, true);
					}
					if (num25 == 5)
					{
						WorldGen.PlaceWire(num26, num27);
					}
					if (num25 == 6)
					{
						WorldGen.KillWire(num26, num27);
					}
					if (num25 == 7)
					{
						WorldGen.PoundTile(num26, num27);
					}
					if (num25 == 8)
					{
						WorldGen.PlaceActuator(num26, num27);
					}
					if (num25 == 9)
					{
						WorldGen.KillActuator(num26, num27);
					}
					if (num25 == 10)
					{
						WorldGen.PlaceWire2(num26, num27);
					}
					if (num25 == 11)
					{
						WorldGen.KillWire2(num26, num27);
					}
					if (num25 == 12)
					{
						WorldGen.PlaceWire3(num26, num27);
					}
					if (num25 == 13)
					{
						WorldGen.KillWire3(num26, num27);
					}
					if (num25 == 14)
					{
						WorldGen.SlopeTile(num26, num27, num28);
					}
					if (num25 == 15)
					{
						Minecart.FrameTrack(num26, num27, true, false);
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(17, -1, this.whoAmI, "", (int)num25, (float)num26, (float)num27, (float)num28, num29, 0, 0);
					if (num25 != 1 || num28 != 53)
					{
						return;
					}
					NetMessage.SendTileSquare(-1, num26, num27, 1);
					return;
				}
				case 18:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					Main.dayTime = this.reader.ReadByte() == 1;
					Main.time = (double)this.reader.ReadInt32();
					Main.sunModY = this.reader.ReadInt16();
					Main.moonModY = this.reader.ReadInt16();
					return;
				}
				case 19:
				{
					byte num30 = this.reader.ReadByte();
					int num31 = this.reader.ReadInt16();
					int num32 = this.reader.ReadInt16();
					int num33 = (this.reader.ReadByte() == 0 ? -1 : 1);
					if (num30 == 0)
					{
						WorldGen.OpenDoor(num31, num32, num33);
					}
					else if (num30 == 1)
					{
						WorldGen.CloseDoor(num31, num32, true);
					}
					else if (num30 == 2)
					{
						WorldGen.ShiftTrapdoor(num31, num32, num33 == 1, 1);
					}
					else if (num30 == 3)
					{
						WorldGen.ShiftTrapdoor(num31, num32, num33 == 1, 0);
					}
					else if (num30 == 4)
					{
						WorldGen.ShiftTallGate(num31, num32, false);
					}
					else if (num30 == 5)
					{
						WorldGen.ShiftTallGate(num31, num32, true);
					}
					if (Main.netMode != 2)
					{
						return;
					}
					int num34 = this.whoAmI;
					byte num35 = num30;
					float single = (float)num31;
					float single1 = (float)num32;
					//not sure what this does
					float variable = 0;
					if (num33 == 1)
					{
						variable = 1;
					}
					NetMessage.SendData(19, -1, num34, "", (int)num35, single, single1, (float)variable, 0, 0, 0);
					return;
				}
				case 20:
				{
					short num36 = this.reader.ReadInt16();
					int num37 = this.reader.ReadInt16();
					int num38 = this.reader.ReadInt16();
					if (!WorldGen.InWorld(num37, num38, 3))
					{
						return;
					}
					BitsByte bitsByte9 = 0;
					BitsByte bitsByte10 = 0;
					Tile tile = null;
					for (int l1 = num37; l1 < num37 + num36; l1++)
					{
						for (int m1 = num38; m1 < num38 + num36; m1++)
						{
							if (Main.tile[l1, m1] == null)
							{
								Main.tile[l1, m1] = new Tile();
							}
							tile = Main.tile[l1, m1];
							bool flag4 = tile.active();
							bitsByte9 = this.reader.ReadByte();
							bitsByte10 = this.reader.ReadByte();
							tile.active(bitsByte9[0]);
							Tile tile1 = tile;
							byte wall = 0;
							if (bitsByte9[2])
							{
								wall = 1;
							}
							tile1.wall = wall;
							bool item3 = bitsByte9[3];
							if (Main.netMode != 2)
							{
								Tile tile2 = tile;
								byte liquid = 0;
								if (item3)
								{
									liquid = 1;
								}
								tile2.liquid = liquid;
							}
							tile.wire(bitsByte9[4]);
							tile.halfBrick(bitsByte9[5]);
							tile.actuator(bitsByte9[6]);
							tile.inActive(bitsByte9[7]);
							tile.wire2(bitsByte10[0]);
							tile.wire3(bitsByte10[1]);
							if (bitsByte10[2])
							{
								tile.color(this.reader.ReadByte());
							}
							if (bitsByte10[3])
							{
								tile.wallColor(this.reader.ReadByte());
							}
							if (tile.active())
							{
								int num39 = tile.type;
								tile.type = this.reader.ReadUInt16();
								if (Main.tileFrameImportant[tile.type])
								{
									tile.frameX = this.reader.ReadInt16();
									tile.frameY = this.reader.ReadInt16();
								}
								else if (!flag4 || tile.type != num39)
								{
									tile.frameX = -1;
									tile.frameY = -1;
								}
								byte num40 = 0;
								if (bitsByte10[4])
								{
									num40 = (byte)(num40 + 1);
								}
								if (bitsByte10[5])
								{
									num40 = (byte)(num40 + 2);
								}
								if (bitsByte10[6])
								{
									num40 = (byte)(num40 + 4);
								}
								tile.slope(num40);
							}
							if (tile.wall > 0)
							{
								tile.wall = this.reader.ReadByte();
							}
							if (item3)
							{
								tile.liquid = this.reader.ReadByte();
								tile.liquidType((int)this.reader.ReadByte());
							}
						}
					}
					WorldGen.RangeFrame(num37, num38, num37 + num36, num38 + num36);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData((int)num1, -1, this.whoAmI, "", num36, (float)num37, (float)num38, 0f, 0, 0, 0);
					return;
				}
				case 21:
				case 90:
				{
					int num41 = this.reader.ReadInt16();
					Vector2 vector2 = this.reader.ReadVector2();
					Vector2 vector21 = this.reader.ReadVector2();
					int num42 = this.reader.ReadInt16();
					int num43 = this.reader.ReadByte();
					int num44 = this.reader.ReadByte();
					int num45 = this.reader.ReadInt16();
					if (Main.netMode == 1)
					{
						if (num45 == 0)
						{
							Main.item[num41].active = false;
							return;
						}
						Item item4 = Main.item[num41];
						item4.netDefaults(num45);
						item4.Prefix(num43);
						item4.stack = num42;
						item4.position = vector2;
						item4.velocity = vector21;
						item4.active = true;
						if (num1 == 90)
						{
							item4.instanced = true;
							item4.owner = Main.myPlayer;
							item4.keepTime = 600;
						}
						item4.wet = Collision.WetCollision(item4.position, item4.width, item4.height);
						return;
					}
					if (Main.itemLockoutTime[num41] > 0)
					{
						return;
					}
					if (num45 != 0)
					{
						bool flag5 = false;
						if (num41 == 400)
						{
							flag5 = true;
						}
						if (flag5)
						{
							Item item5 = new Item();
							item5.netDefaults(num45);
							num41 = Item.NewItem((int)vector2.X, (int)vector2.Y, item5.width, item5.height, item5.type, num42, true, 0, false);
						}
						Item item6 = Main.item[num41];
						item6.netDefaults(num45);
						item6.Prefix(num43);
						item6.stack = num42;
						item6.position = vector2;
						item6.velocity = vector21;
						item6.active = true;
						item6.owner = Main.myPlayer;
						if (!flag5)
						{
							NetMessage.SendData(21, -1, this.whoAmI, "", num41, 0f, 0f, 0f, 0, 0, 0);
							return;
						}
						NetMessage.SendData(21, -1, -1, "", num41, 0f, 0f, 0f, 0, 0, 0);
						if (num44 == 0)
						{
							Main.item[num41].ownIgnore = this.whoAmI;
							Main.item[num41].ownTime = 100;
						}
						Main.item[num41].FindOwner(num41);
						return;
					}
					if (num41 >= 400)
					{
						return;
					}
					Main.item[num41].active = false;
					NetMessage.SendData(21, -1, -1, "", num41, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 22:
				{
					int num46 = this.reader.ReadInt16();
					int num47 = this.reader.ReadByte();
					if (Main.netMode == 2 && Main.item[num46].owner != this.whoAmI)
					{
						return;
					}
					Main.item[num46].owner = num47;
					if (num47 != Main.myPlayer)
					{
						Main.item[num46].keepTime = 0;
					}
					else
					{
						Main.item[num46].keepTime = 15;
					}
					if (Main.netMode != 2)
					{
						return;
					}
					Main.item[num46].owner = 255;
					Main.item[num46].keepTime = 15;
					NetMessage.SendData(22, -1, -1, "", num46, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 23:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num48 = this.reader.ReadInt16();
					Vector2 vector22 = this.reader.ReadVector2();
					Vector2 vector23 = this.reader.ReadVector2();
					int num49 = this.reader.ReadByte();
					BitsByte bitsByte11 = this.reader.ReadByte();
					float[] singleArray = new float[NPC.maxAI];
					for (int n1 = 0; n1 < NPC.maxAI; n1++)
					{
						if (!bitsByte11[n1 + 2])
						{
							singleArray[n1] = 0f;
						}
						else
						{
							singleArray[n1] = this.reader.ReadSingle();
						}
					}
					int num50 = this.reader.ReadInt16();
					int num51 = 0;
					if (!bitsByte11[7])
					{
						if (Main.npcLifeBytes[num50] == 2)
						{
							num51 = this.reader.ReadInt16();
						}
						else if (Main.npcLifeBytes[num50] != 4)
						{
							num51 = this.reader.ReadSByte();
						}
						else
						{
							num51 = this.reader.ReadInt32();
						}
					}
					int num52 = -1;
					NPC nPC = Main.npc[num48];
					if (!nPC.active || nPC.netID != num50)
					{
						if (nPC.active)
						{
							num52 = nPC.type;
						}
						nPC.active = true;
						nPC.netDefaults(num50);
					}
					nPC.position = vector22;
					nPC.velocity = vector23;
					nPC.target = num49;
					nPC.direction = (bitsByte11[0] ? 1 : -1);
					nPC.directionY = (bitsByte11[1] ? 1 : -1);
					nPC.spriteDirection = (bitsByte11[6] ? 1 : -1);
					if (!bitsByte11[7])
					{
						nPC.life = num51;
					}
					else
					{
						int num53 = nPC.lifeMax;
						int num54 = num53;
						nPC.life = num53;
						num51 = num54;
					}
					if (num51 <= 0)
					{
						nPC.active = false;
					}
					for (int o1 = 0; o1 < NPC.maxAI; o1++)
					{
						nPC.ai[o1] = singleArray[o1];
					}
					if (num50 == 262)
					{
						NPC.plantBoss = num48;
					}
					if (num50 == 245)
					{
						NPC.golemBoss = num48;
					}
					if (!Main.npcCatchable[nPC.type])
					{
						return;
					}
					nPC.releaseOwner = this.reader.ReadByte();
					return;
				}
				case 24:
				{
					int num55 = this.reader.ReadInt16();
					int num56 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num56 = this.whoAmI;
					}
					Player player6 = Main.player[num56];
					Main.npc[num55].StrikeNPC(player6.inventory[player6.selectedItem].damage, player6.inventory[player6.selectedItem].knockBack, player6.direction, false, false, false);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(24, -1, this.whoAmI, "", num55, (float)num56, 0f, 0f, 0, 0, 0);
					NetMessage.SendData(23, -1, -1, "", num55, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 25:
				{
					int num57 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num57 = this.whoAmI;
					}
					Color color = this.reader.ReadRGB();
					if (Main.netMode == 2)
					{
						color = new Color(255, 255, 255);
					}
					string str = this.reader.ReadString();
					if (Main.netMode != 2)
					{
						return;
					}
					string lower = str.ToLower();
					if (lower == Lang.mp[6] || lower == Lang.mp[21])
					{
						string str2 = "";
						for (int p1 = 0; p1 < 255; p1++)
						{
							if (Main.player[p1].active)
							{
								str2 = (str2 != "" ? string.Concat(str2, ", ", Main.player[p1].name) : Main.player[p1].name);
							}
						}
						NetMessage.SendData(25, this.whoAmI, -1, string.Concat(Lang.mp[7], " ", str2, "."), 255, 255f, 240f, 20f, 0, 0, 0);
						return;
					}
					if (lower.StartsWith("/me "))
					{
						NetMessage.SendData(25, -1, -1, string.Concat("*", Main.player[this.whoAmI].name, " ", str.Substring(4)), 255, 200f, 100f, 0f, 0, 0, 0);
						return;
					}
					if (lower == Lang.mp[8])
					{
						object[] objArray = new object[] { "*", Main.player[this.whoAmI].name, " ", Lang.mp[9], " ", Main.rand.Next(1, 101) };
						NetMessage.SendData(25, -1, -1, string.Concat(objArray), 255, 255f, 240f, 20f, 0, 0, 0);
						return;
					}
					if (lower.StartsWith("/p "))
					{
						int num58 = Main.player[this.whoAmI].team;
						color = Main.teamColor[num58];
						if (num58 == 0)
						{
							NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[10], 255, 255f, 240f, 20f, 0, 0, 0);
							return;
						}
						for (int q1 = 0; q1 < 255; q1++)
						{
							if (Main.player[q1].team == num58)
							{
								NetMessage.SendData(25, q1, -1, str.Substring(3), num57, (float)color.R, (float)color.G, (float)color.B, 0, 0, 0);
							}
						}
						return;
					}
					if (Main.player[this.whoAmI].difficulty == 2)
					{
						color = Main.hcColor;
					}
					else if (Main.player[this.whoAmI].difficulty == 1)
					{
						color = Main.mcColor;
					}
					NetMessage.SendData(25, -1, -1, str, num57, (float)color.R, (float)color.G, (float)color.B, 0, 0, 0);
					if (!Main.dedServ)
					{
						return;
					}
					Console.WriteLine(string.Concat("<", Main.player[this.whoAmI].name, "> ", str));
					return;
				}
				case 26:
				{
					int num59 = this.reader.ReadByte();
					if (Main.netMode == 2 && this.whoAmI != num59 && (!Main.player[num59].hostile || !Main.player[this.whoAmI].hostile))
					{
						return;
					}
					int num60 = this.reader.ReadByte() - 1;
					int num61 = this.reader.ReadInt16();
					string str3 = this.reader.ReadString();
					BitsByte bitsByte12 = this.reader.ReadByte();
					bool flag6 = bitsByte12[0];
					bool item7 = bitsByte12[1];
					Main.player[num59].Hurt(num61, num60, flag6, true, str3, item7);
					if (Main.netMode != 2)
					{
						return;
					}
					int num62 = this.whoAmI;
					string str4 = str3;
					int num63 = num59;
					float single2 = (float)num60;
					float single3 = (float)num61;
					float crit = 0;
					if (flag6)
					{
						crit = 1;
					}
					NetMessage.SendData(26, -1, num62, str4, num63, single2, single3, crit, (item7 ? 1 : 0), 0, 0);

					return;
				}
				case 27:
				{
					int num64 = this.reader.ReadInt16();
					Vector2 vector24 = this.reader.ReadVector2();
					Vector2 vector25 = this.reader.ReadVector2();
					float single4 = this.reader.ReadSingle();
					int num65 = this.reader.ReadInt16();
					int num66 = this.reader.ReadByte();
					int num67 = this.reader.ReadInt16();

					// If the projectile is of an invalid type, this is most likely a fake packet
					if (num67 < 0 || num67 >= Main.maxProjectileTypes)
						return;

					BitsByte bitsByte13 = this.reader.ReadByte();
					float[] singleArray1 = new float[Projectile.maxAI];
					for (int r1 = 0; r1 < Projectile.maxAI; r1++)
					{
						if (!bitsByte13[r1])
						{
							singleArray1[r1] = 0f;
						}
						else
						{
							singleArray1[r1] = this.reader.ReadSingle();
						}
					}
					if (Main.netMode == 2)
					{
						num66 = this.whoAmI;
						if (Main.projHostile[num67])
						{
							return;
						}
					}
					int num68 = 1000;
					int num69 = 0;
					while (num69 < 1000)
					{
						if (Main.projectile[num69].owner != num66 || Main.projectile[num69].identity != num64 || !Main.projectile[num69].active)
						{
							num69++;
						}
						else
						{
							num68 = num69;
							break;
						}
					}
					if (num68 == 1000)
					{
						int num70 = 0;
						while (num70 < 1000)
						{
							if (Main.projectile[num70].active)
							{
								num70++;
							}
							else
							{
								num68 = num70;
								break;
							}
						}
					}
					Projectile projectile = Main.projectile[num68];
					if (!projectile.active || projectile.type != num67)
					{
						projectile.SetDefaults(num67);
						if (Main.netMode == 2)
						{
							RemoteClient spamProjectile = Netplay.Clients[this.whoAmI];
							spamProjectile.SpamProjectile = spamProjectile.SpamProjectile + 1f;
						}
					}
					projectile.identity = num64;
					projectile.position = vector24;
					projectile.velocity = vector25;
					projectile.type = num67;
					projectile.damage = num65;
					projectile.knockBack = single4;
					projectile.owner = num66;
					for (int s1 = 0; s1 < Projectile.maxAI; s1++)
					{
						projectile.ai[s1] = singleArray1[s1];
					}
					projectile.ProjectileFixDesperation(num66);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(27, -1, this.whoAmI, "", num68, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 28:
				{
					int num71 = this.reader.ReadInt16();
					int num72 = this.reader.ReadInt16();
					float single5 = this.reader.ReadSingle();
					int num73 = this.reader.ReadByte() - 1;
					byte num74 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						Main.npc[num71].PlayerInteraction(this.whoAmI);
					}
					if (num72 < 0)
					{
						Main.npc[num71].life = 0;
						Main.npc[num71].HitEffect(0, 10);
						Main.npc[num71].active = false;
					}
					else
					{
						Main.npc[num71].StrikeNPC(num72, single5, num73, num74 == 1, false, true);
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(28, -1, this.whoAmI, "", num71, (float)num72, single5, (float)num73, (int)num74, 0, 0);
					if (Main.npc[num71].life > 0)
					{
						Main.npc[num71].netUpdate = true;
						return;
					}
					NetMessage.SendData(23, -1, -1, "", num71, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 29:
				{
					int num75 = this.reader.ReadInt16();
					int num76 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num76 = this.whoAmI;
					}
					int num77 = 0;
					while (num77 < 1000)
					{
						if (Main.projectile[num77].owner != num76 || Main.projectile[num77].identity != num75 || !Main.projectile[num77].active)
						{
							num77++;
						}
						else
						{
							Main.projectile[num77].Kill();
							break;
						}
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(29, -1, this.whoAmI, "", num75, (float)num76, 0f, 0f, 0, 0, 0);
					return;
				}
				case 30:
				{
					int num78 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num78 = this.whoAmI;
					}
					bool flag7 = this.reader.ReadBoolean();
					Main.player[num78].hostile = flag7;
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(30, -1, this.whoAmI, "", num78, 0f, 0f, 0f, 0, 0, 0);
					string str5 = string.Concat(" ", Lang.mp[(flag7 ? 11 : 12)]);
					Color color1 = Main.teamColor[Main.player[num78].team];
					NetMessage.SendData(25, -1, -1, string.Concat(Main.player[num78].name, str5), 255, (float)color1.R, (float)color1.G, (float)color1.B, 0, 0, 0);
					return;
				}
				case 31:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int num79 = this.reader.ReadInt16();
					int num80 = this.reader.ReadInt16();
					int num81 = Chest.FindChest(num79, num80);
					if (num81 <= -1 || Chest.UsingChest(num81) != -1)
					{
						return;
					}
					for (int t1 = 0; t1 < 40; t1++)
					{
						NetMessage.SendData(32, this.whoAmI, -1, "", num81, (float)t1, 0f, 0f, 0, 0, 0);
					}
					NetMessage.SendData(33, this.whoAmI, -1, "", num81, 0f, 0f, 0f, 0, 0, 0);
					Main.player[this.whoAmI].chest = num81;
					if (Main.myPlayer == this.whoAmI)
					{
						Main.recBigList = false;
					}
					Recipe.FindRecipes();
					NetMessage.SendData(80, -1, this.whoAmI, "", this.whoAmI, (float)num81, 0f, 0f, 0, 0, 0);
					if (Main.tile[num79, num80].frameX < 36 || Main.tile[num79, num80].frameX >= 72)
					{
						return;
					}
					AchievementsHelper.HandleSpecialEvent(Main.player[this.whoAmI], 16);
					return;
				}
				case 32:
				{
					int num82 = this.reader.ReadInt16();
					int num83 = this.reader.ReadByte();
					int num84 = this.reader.ReadInt16();
					int num85 = this.reader.ReadByte();
					int num86 = this.reader.ReadInt16();
					if (Main.chest[num82] == null)
					{
						Main.chest[num82] = new Chest(false);
					}
					if (Main.chest[num82].item[num83] == null)
					{
						Main.chest[num82].item[num83] = new Item();
					}
					Main.chest[num82].item[num83].netDefaults(num86);
					Main.chest[num82].item[num83].Prefix(num85);
					Main.chest[num82].item[num83].stack = num84;
					Recipe.FindRecipes();
					return;
				}
				case 33:
				{
					int num87 = this.reader.ReadInt16();
					int num88 = this.reader.ReadInt16();
					int num89 = this.reader.ReadInt16();
					int num90 = this.reader.ReadByte();
					string empty = string.Empty;
					if (num90 != 0)
					{
						if (num90 <= 20)
						{
							empty = this.reader.ReadString();
						}
						else if (num90 != 255)
						{
							num90 = 0;
						}
					}
					if (Main.netMode != 1)
					{
						if (num90 != 0)
						{
							int num91 = Main.player[this.whoAmI].chest;
							Chest chest = Main.chest[num91];
							chest.name = empty;
							NetMessage.SendData(69, -1, this.whoAmI, empty, num91, (float)chest.x, (float)chest.y, 0f, 0, 0, 0);
						}
						Main.player[this.whoAmI].chest = num87;
						Recipe.FindRecipes();
						NetMessage.SendData(80, -1, this.whoAmI, "", this.whoAmI, (float)num87, 0f, 0f, 0, 0, 0);
						return;
					}
					Player player7 = Main.player[Main.myPlayer];
					if (player7.chest == -1)
					{
						Main.playerInventory = true;
					}
					else if (player7.chest != num87 && num87 != -1)
					{
						Main.playerInventory = true;
						Main.recBigList = false;
					}
					else if (player7.chest != -1 && num87 == -1)
					{
						Main.recBigList = false;
					}
					player7.chest = num87;
					player7.chestX = num88;
					player7.chestY = num89;
					Recipe.FindRecipes();
					return;
				}
				case 34:
				{
					byte num92 = this.reader.ReadByte();
					int num93 = this.reader.ReadInt16();
					int num94 = this.reader.ReadInt16();
					int num95 = this.reader.ReadInt16();
					if (Main.netMode != 2)
					{
						int num96 = this.reader.ReadInt16();
						if (num92 == 0)
						{
							if (num96 == -1)
							{
								WorldGen.KillTile(num93, num94, false, false, false);
								return;
							}
							WorldGen.PlaceChestDirect(num93, num94, 21, num95, num96);
							return;
						}
						if (num92 != 2)
						{
							Chest.DestroyChestDirect(num93, num94, num96);
							WorldGen.KillTile(num93, num94, false, false, false);
							return;
						}
						if (num96 == -1)
						{
							WorldGen.KillTile(num93, num94, false, false, false);
							return;
						}
						WorldGen.PlaceDresserDirect(num93, num94, 88, num95, num96);
						return;
					}
					if (num92 == 0)
					{
						int num97 = WorldGen.PlaceChest(num93, num94, 21, false, num95);
						if (num97 != -1)
						{
							NetMessage.SendData(34, -1, -1, "", (int)num92, (float)num93, (float)num94, (float)num95, num97, 0, 0);
							return;
						}
						NetMessage.SendData(34, this.whoAmI, -1, "", (int)num92, (float)num93, (float)num94, (float)num95, num97, 0, 0);
						Item.NewItem(num93 * 16, num94 * 16, 32, 32, Chest.chestItemSpawn[num95], 1, true, 0, false);
						return;
					}
					if (num92 == 2)
					{
						int num98 = WorldGen.PlaceChest(num93, num94, 88, false, num95);
						if (num98 != -1)
						{
							NetMessage.SendData(34, -1, -1, "", (int)num92, (float)num93, (float)num94, (float)num95, num98, 0, 0);
							return;
						}
						NetMessage.SendData(34, this.whoAmI, -1, "", (int)num92, (float)num93, (float)num94, (float)num95, num98, 0, 0);
						Item.NewItem(num93 * 16, num94 * 16, 32, 32, Chest.dresserItemSpawn[num95], 1, true, 0, false);
						return;
					}
					Tile tile3 = Main.tile[num93, num94];
					if (tile3.type != 21 || num92 != 1)
					{
						if (tile3.type != 88 || num92 != 3)
						{
							return;
						}
						num93 = num93 - tile3.frameX % 54 / 18;
						if (tile3.frameY % 36 != 0)
						{
							num94--;
						}
						int num99 = Chest.FindChest(num93, num94);
						WorldGen.KillTile(num93, num94, false, false, false);
						if (tile3.active())
						{
							return;
						}
						NetMessage.SendData(34, -1, -1, "", (int)num92, (float)num93, (float)num94, 0f, num99, 0, 0);
						return;
					}
					else
					{
						if (tile3.frameX % 36 != 0)
						{
							num93--;
						}
						if (tile3.frameY % 36 != 0)
						{
							num94--;
						}
						int num100 = Chest.FindChest(num93, num94);
						WorldGen.KillTile(num93, num94, false, false, false);
						if (tile3.active())
						{
							return;
						}
						NetMessage.SendData(34, -1, -1, "", (int)num92, (float)num93, (float)num94, 0f, num100, 0, 0);
						return;
					}
				}
				case 35:
				{
					int num101 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num101 = this.whoAmI;
					}
					int num102 = this.reader.ReadInt16();
					if (num101 != Main.myPlayer || Main.ServerSideCharacter)
					{
						Main.player[num101].HealEffect(num102, true);
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(35, -1, this.whoAmI, "", num101, (float)num102, 0f, 0f, 0, 0, 0);
					return;
				}
				case 36:
				{
					int num103 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num103 = this.whoAmI;
					}
					Player player8 = Main.player[num103];
					player8.zone1 = this.reader.ReadByte();
					player8.zone2 = this.reader.ReadByte();
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(36, -1, this.whoAmI, "", num103, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 37:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					if (!Main.autoPass)
					{
						Netplay.ServerPassword = "";
						Main.menuMode = 31;
						return;
					}
					NetMessage.SendData(38, -1, -1, Netplay.ServerPassword, 0, 0f, 0f, 0f, 0, 0, 0);
					Main.autoPass = false;
					return;
				}
				case 38:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					if (this.reader.ReadString() != Netplay.ServerPassword)
					{
						NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
					Netplay.Clients[this.whoAmI].State = 1;
					NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 39:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num104 = this.reader.ReadInt16();
					Main.item[num104].owner = 255;
					NetMessage.SendData(22, -1, -1, "", num104, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 40:
				{
					int num105 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num105 = this.whoAmI;
					}
					int num106 = this.reader.ReadInt16();
					Main.player[num105].talkNPC = num106;
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(40, -1, this.whoAmI, "", num105, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 41:
				{
					int num107 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num107 = this.whoAmI;
					}
					Player player9 = Main.player[num107];
					float single6 = this.reader.ReadSingle();
					int num108 = this.reader.ReadInt16();
					player9.itemRotation = single6;
					player9.itemAnimation = num108;
					player9.channel = player9.inventory[player9.selectedItem].channel;
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(41, -1, this.whoAmI, "", num107, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 42:
				{
					int num109 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num109 = this.whoAmI;
					}
					else if (Main.myPlayer == num109 && !Main.ServerSideCharacter)
					{
						return;
					}
					int num110 = this.reader.ReadInt16();
					int num111 = this.reader.ReadInt16();
					Main.player[num109].statMana = num110;
					Main.player[num109].statManaMax = num111;
					return;
				}
				case 43:
				{
					int num112 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num112 = this.whoAmI;
					}
					int num113 = this.reader.ReadInt16();
					if (num112 != Main.myPlayer)
					{
						Main.player[num112].ManaEffect(num113);
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(43, -1, this.whoAmI, "", num112, (float)num113, 0f, 0f, 0, 0, 0);
					return;
				}
				case 44:
				{
					int num114 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num114 = this.whoAmI;
					}
					int num115 = this.reader.ReadByte() - 1;
					int num116 = this.reader.ReadInt16();
					byte num117 = this.reader.ReadByte();
					string str6 = this.reader.ReadString();
					Main.player[num114].KillMe((double)num116, num115, num117 == 1, str6);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(44, -1, this.whoAmI, str6, num114, (float)num115, (float)num116, (float)num117, 0, 0, 0);
					return;
				}
				case 45:
				{
					int num118 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num118 = this.whoAmI;
					}
					int num119 = this.reader.ReadByte();
					Player player10 = Main.player[num118];
					int num120 = player10.team;
					player10.team = num119;
					Color color2 = Main.teamColor[num119];
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(45, -1, this.whoAmI, "", num118, 0f, 0f, 0f, 0, 0, 0);
					string str7 = string.Concat(" ", Lang.mp[13 + num119]);
					if (num119 == 5)
					{
						str7 = string.Concat(" ", Lang.mp[22]);
					}
					for (int u1 = 0; u1 < 255; u1++)
					{
						if (u1 == this.whoAmI || num120 > 0 && Main.player[u1].team == num120 || num119 > 0 && Main.player[u1].team == num119)
						{
							NetMessage.SendData(25, u1, -1, string.Concat(player10.name, str7), 255, (float)color2.R, (float)color2.G, (float)color2.B, 0, 0, 0);
						}
					}
					return;
				}
				case 46:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int num121 = this.reader.ReadInt16();
					int num122 = this.reader.ReadInt16();
					int num123 = Sign.ReadSign(num121, num122, true);
					if (num123 < 0)
					{
						return;
					}
					NetMessage.SendData(47, this.whoAmI, -1, "", num123, (float)this.whoAmI, 0f, 0f, 0, 0, 0);
					return;
				}
				case 47:
				{
					int num124 = this.reader.ReadInt16();
					int num125 = this.reader.ReadInt16();
					int num126 = this.reader.ReadInt16();
					string str8 = this.reader.ReadString();
					string str9 = "";
					if (Main.sign[num124] != null)
					{
						str9 = Main.sign[num124].text;
					}
					Main.sign[num124] = new Sign();
					Main.sign[num124].x = num125;
					Main.sign[num124].y = num126;
					Sign.TextSign(num124, str8);
					int num127 = this.reader.ReadByte();
					if (Main.netMode == 2 && str9 != str8)
					{
						num127 = this.whoAmI;
						NetMessage.SendData(47, -1, this.whoAmI, "", num124, (float)num127, 0f, 0f, 0, 0, 0);
					}
					if (Main.netMode != 1 || num127 != Main.myPlayer || Main.sign[num124] == null)
					{
						return;
					}
					Main.playerInventory = false;
					Main.player[Main.myPlayer].talkNPC = -1;
					Main.npcChatCornerItem = 0;
					Main.editSign = false;
					Main.player[Main.myPlayer].sign = num124;
					Main.npcChatText = Main.sign[num124].text;
					return;
				}
				case 48:
				{
					int num128 = this.reader.ReadInt16();
					int num129 = this.reader.ReadInt16();
					byte num130 = this.reader.ReadByte();
					byte num131 = this.reader.ReadByte();
					if (Main.netMode == 2 && Netplay.spamCheck)
					{
						int num132 = this.whoAmI;
						int x1 = (int)(Main.player[num132].position.X + (float)(Main.player[num132].width / 2));
						int y1 = (int)(Main.player[num132].position.Y + (float)(Main.player[num132].height / 2));
						int num133 = 10;
						int num134 = x1 - num133;
						int num135 = x1 + num133;
						int num136 = y1 - num133;
						int num137 = y1 + num133;
						if (num128 < num134 || num128 > num135 || num129 < num136 || num129 > num137)
						{
							NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
							return;
						}
					}
					if (Main.tile[num128, num129] == null)
					{
						Main.tile[num128, num129] = new Tile();
					}
					lock (Main.tile[num128, num129])
					{
						Main.tile[num128, num129].liquid = num130;
						Main.tile[num128, num129].liquidType((int)num131);
						if (Main.netMode == 2)
						{
							WorldGen.SquareTileFrame(num128, num129, true);
						}
						return;
					}
				}
				case 49:
				{
					if (Netplay.Connection.State != 6)
					{
						return;
					}
					Netplay.Connection.State = 10;
					Main.ActivePlayerFileData.StartPlayTimer();
					Player.EnterWorld(Main.player[Main.myPlayer]);
					Main.player[Main.myPlayer].Spawn();
					return;
				}
				case 50:
				{
					int num138 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num138 = this.whoAmI;
					}
					else if (num138 == Main.myPlayer && !Main.ServerSideCharacter)
					{
						return;
					}
					Player player11 = Main.player[num138];
					for (int v1 = 0; v1 < 22; v1++)
					{
						player11.buffType[v1] = this.reader.ReadByte();
						if (player11.buffType[v1] <= 0)
						{
							player11.buffTime[v1] = 0;
						}
						else
						{
							player11.buffTime[v1] = 60;
						}
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(50, -1, this.whoAmI, "", num138, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 51:
				{
					byte num139 = this.reader.ReadByte();
					byte num140 = this.reader.ReadByte();
					if (num140 == 1)
					{
						NPC.SpawnSkeletron();
						return;
					}
					if (num140 == 2)
					{
						if (Main.netMode == 2)
						{
							NetMessage.SendData(51, -1, this.whoAmI, "", (int)num139, (float)num140, 0f, 0f, 0, 0, 0);
							return;
						}
						return;
					}
					if (num140 != 3)
					{
						if (num140 != 4)
						{
							return;
						}
						Main.npc[num139].BigMimicSpawnSmoke();
						return;
					}
					else
					{
						if (Main.netMode != 2)
						{
							return;
						}
						Main.Sundialing();
						return;
					}
				}
				case 52:
				{
					int ldap = (int)this.reader.ReadByte();
					int ad = (int)this.reader.ReadInt16();
					int winfs = (int)this.reader.ReadInt16();
					if (ldap == 1)
					{
						Chest.Unlock(ad, winfs);
						if (Main.netMode == 2)
						{
							NetMessage.SendData(52, -1, this.whoAmI, "", 0, (float)ldap, (float)ad, (float)winfs, 0, 0, 0);
							NetMessage.SendTileSquare(-1, ad, winfs, 2);
						}
					}
					if (ldap != 2)
					{
						return;
					}
					WorldGen.UnlockDoor(ad, winfs);
					if (Main.netMode == 2)
					{
						NetMessage.SendData(52, -1, this.whoAmI, "", 0, (float)ldap, (float)ad, (float)winfs, 0, 0, 0);
						NetMessage.SendTileSquare(-1, ad, winfs, 2);
						return;
					}
					return;
				}
				case 53:
				{
					int num145 = this.reader.ReadInt16();
					int num146 = this.reader.ReadByte();
					int num147 = this.reader.ReadInt16();
					Main.npc[num145].AddBuff(num146, num147, true);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(54, -1, -1, "", num145, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 54:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num148 = this.reader.ReadInt16();
					NPC nPC1 = Main.npc[num148];
					for (int w1 = 0; w1 < 5; w1++)
					{
						nPC1.buffType[w1] = this.reader.ReadByte();
						nPC1.buffTime[w1] = this.reader.ReadInt16();
					}
					return;
				}
				case 55:
				{
					int num149 = this.reader.ReadByte();
					int num150 = this.reader.ReadByte();
					int num151 = this.reader.ReadInt16();
					if (Main.netMode == 2 && num149 != this.whoAmI && !Main.pvpBuff[num150])
					{
						return;
					}
					if (Main.netMode == 1 && num149 == Main.myPlayer)
					{
						Main.player[num149].AddBuff(num150, num151, true);
						return;
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(55, num149, -1, "", num149, (float)num150, (float)num151, 0f, 0, 0, 0);
					return;
				}
				case 56:
				{
					int num152 = this.reader.ReadInt16();
					if (num152 < 0 || num152 >= 200)
					{
						return;
					}
					if (Main.netMode == 1)
					{
						Main.npc[num152].displayName = this.reader.ReadString();
						return;
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(56, this.whoAmI, -1, Main.npc[num152].displayName, num152, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 57:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					WorldGen.tGood = this.reader.ReadByte();
					WorldGen.tEvil = this.reader.ReadByte();
					WorldGen.tBlood = this.reader.ReadByte();
					return;
				}
				case 58:
				{
					int num153 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num153 = this.whoAmI;
					}
					float single7 = this.reader.ReadSingle();
					if (Main.netMode == 2)
					{
						NetMessage.SendData(58, -1, this.whoAmI, "", this.whoAmI, single7, 0f, 0f, 0, 0, 0);
						return;
					}
					Player player12 = Main.player[num153];
					Main.harpNote = single7;
					int num154 = 26;
					if (player12.inventory[player12.selectedItem].type == 507)
					{
						num154 = 35;
					}
					return;
				}
				case 59:
				{
					int num155 = this.reader.ReadInt16();
					int num156 = this.reader.ReadInt16();
					Wiring.HitSwitch(num155, num156);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(59, -1, this.whoAmI, "", num155, (float)num156, 0f, 0f, 0, 0, 0);
					return;
				}
				case 60:
				{
					int num157 = this.reader.ReadInt16();
					int num158 = this.reader.ReadInt16();
					int num159 = this.reader.ReadInt16();
					byte num160 = this.reader.ReadByte();
					if (num157 >= 200)
					{
						NetMessage.BootPlayer(this.whoAmI, "cheating attempt detected: Invalid kick-out");
						return;
					}
					if (Main.netMode != 1)
					{
						if (num160 == 0)
						{
							WorldGen.kickOut(num157);
							return;
						}
						WorldGen.moveRoom(num158, num159, num157);
						return;
					}
					Main.npc[num157].homeless = num160 == 1;
					Main.npc[num157].homeTileX = num158;
					Main.npc[num157].homeTileY = num159;
					return;
				}
				case 61:
				{
					int num161 = this.reader.ReadInt32();
					int num162 = this.reader.ReadInt32();
					if (Main.netMode != 2)
					{
						return;
					}
					if (num162 >= 0 && num162 < 540 && NPCID.Sets.MPAllowedEnemies[num162])
					{
						if (num162 == 75)
						{
							for (int x11 = 0; x11 < 200; x11++)
							{
								if (!Main.npc[x11].townNPC)
								{
									Main.npc[x11].active = false;
								}
							}
						}
						if (NPC.AnyNPCs(num162))
						{
							return;
						}
						NPC.SpawnOnPlayer(num161, num162);
						return;
					}
					else if (num162 == -4)
					{
						if (Main.dayTime)
						{
							return;
						}
						NetMessage.SendData(25, -1, -1, Lang.misc[31], 255, 50f, 255f, 130f, 0, 0, 0);
						Main.startPumpkinMoon();
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(78, -1, -1, "", 0, 1f, 2f, 1f, 0, 0, 0);
						return;
					}
					else if (num162 == -5)
					{
						if (Main.dayTime)
						{
							return;
						}
						NetMessage.SendData(25, -1, -1, Lang.misc[34], 255, 50f, 255f, 130f, 0, 0, 0);
						Main.startSnowMoon();
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						NetMessage.SendData(78, -1, -1, "", 0, 1f, 1f, 1f, 0, 0, 0);
						return;
					}
					else if (num162 != -6)
					{
						if (num162 == -7)
						{
							NetMessage.SendData(25, -1, -1, "martian moon toggled", 255, 50f, 255f, 130f, 0, 0, 0);
							Main.invasionDelay = 0;
							Main.StartInvasion(4);
							NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
							NetMessage.SendData(78, -1, -1, "", 0, 1f, (float)(Main.invasionType + 2), 0f, 0, 0, 0);
							return;
						}
						if (num162 >= 0)
						{
							return;
						}
						int num163 = 1;
						if (num162 > -5)
						{
							num163 = -num162;
						}
						if (num163 > 0 && Main.invasionType == 0)
						{
							Main.invasionDelay = 0;
							Main.StartInvasion(num163);
						}
						NetMessage.SendData(78, -1, -1, "", 0, 1f, (float)(Main.invasionType + 2), 0f, 0, 0, 0);
						return;
					}
					else
					{
						if (!Main.dayTime)
						{
							return;
						}
						NetMessage.SendData(25, -1, -1, Lang.misc[20], 255, 50f, 255f, 130f, 0, 0, 0);
						Main.eclipse = true;
						NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
						return;
					}
				}
				case 62:
				{
					int num164 = this.reader.ReadByte();
					int num165 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num164 = this.whoAmI;
					}
					if (num165 == 1)
					{
						Main.player[num164].NinjaDodge();
					}
					if (num165 == 2)
					{
						Main.player[num164].ShadowDodge();
					}
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(62, -1, this.whoAmI, "", num164, (float)num165, 0f, 0f, 0, 0, 0);
					return;
				}
				case 63:
				{
					int num166 = this.reader.ReadInt16();
					int num167 = this.reader.ReadInt16();
					byte num168 = this.reader.ReadByte();
					WorldGen.paintTile(num166, num167, num168, false);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(63, -1, this.whoAmI, "", num166, (float)num167, (float)num168, 0f, 0, 0, 0);
					return;
				}
				case 64:
				{
					int num169 = this.reader.ReadInt16();
					int num170 = this.reader.ReadInt16();
					byte num171 = this.reader.ReadByte();
					WorldGen.paintWall(num169, num170, num171, false);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(64, -1, this.whoAmI, "", num169, (float)num170, (float)num171, 0f, 0, 0, 0);
					return;
				}
				case 65:
				{
					BitsByte bitsByte14 = this.reader.ReadByte();
					int num172 = this.reader.ReadInt16();
					if (Main.netMode == 2)
					{
						num172 = this.whoAmI;
					}
					Vector2 vector26 = this.reader.ReadVector2();
					int num173 = 0;
					int num174 = 0;
					if (bitsByte14[0])
					{
						num173++;
					}
					if (bitsByte14[1])
					{
						num173 = num173 + 2;
					}
					if (bitsByte14[2])
					{
						num174++;
					}
					if (bitsByte14[3])
					{
						num174 = num174 + 2;
					}
					if (num173 == 0)
					{
						Main.player[num172].Teleport(vector26, num174, 0);
					}
					else if (num173 == 1)
					{
						Main.npc[num172].Teleport(vector26, num174, 0);
					}
					else if (num173 == 2)
					{
						Main.player[num172].Teleport(vector26, num174, 0);
						if (Main.netMode == 2)
						{
							RemoteClient.CheckSection(this.whoAmI, vector26, 1);
							NetMessage.SendData(65, -1, -1, "", 0, (float)num172, vector26.X, vector26.Y, num174, 0, 0);
							int num175 = -1;
							float single8 = 9999f;
							for (int y11 = 0; y11 < 255; y11++)
							{
								if (Main.player[y11].active && y11 != this.whoAmI)
								{
									Vector2 vector27 = Main.player[y11].position - Main.player[this.whoAmI].position;
									if (vector27.Length() < single8)
									{
										single8 = vector27.Length();
										num175 = y11;
									}
								}
							}
							if (num175 >= 0)
							{
								NetMessage.SendData(25, -1, -1, string.Concat(Main.player[this.whoAmI].name, " has teleported to ", Main.player[num175].name), 255, 250f, 250f, 0f, 0, 0, 0);
							}
						}
					}
					if (Main.netMode != 2 || num173 != 0)
					{
						return;
					}
					NetMessage.SendData(65, -1, this.whoAmI, "", 0, (float)num172, vector26.X, vector26.Y, num174, 0, 0);
					return;
				}
				case 66:
				{
					int num176 = this.reader.ReadByte();
					int num177 = this.reader.ReadInt16();
					if (num177 <= 0)
					{
						return;
					}
					Player player13 = Main.player[num176];
					Player player14 = player13;
					player14.statLife = player14.statLife + num177;
					if (player13.statLife > player13.statLifeMax2)
					{
						player13.statLife = player13.statLifeMax2;
					}
					player13.HealEffect(num177, false);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(66, -1, this.whoAmI, "", num176, (float)num177, 0f, 0f, 0, 0, 0);
					return;
				}
				case 68:
				{
					this.reader.ReadString();
					return;
				}
				case 69:
				{
					int num178 = this.reader.ReadInt16();
					int num179 = this.reader.ReadInt16();
					int num180 = this.reader.ReadInt16();
					if (Main.netMode == 1)
					{
						if (num178 < 0 || num178 >= 1000)
						{
							return;
						}
						Chest chest1 = Main.chest[num178];
						if (chest1 == null)
						{
							chest1 = new Chest(false)
							{
								x = num179,
								y = num180
							};
							Main.chest[num178] = chest1;
						}
						else if (chest1.x != num179 || chest1.y != num180)
						{
							return;
						}
						chest1.name = this.reader.ReadString();
						return;
					}
					if (num178 < -1 || num178 >= 1000)
					{
						return;
					}
					if (num178 == -1)
					{
						num178 = Chest.FindChest(num179, num180);
						if (num178 == -1)
						{
							return;
						}
					}
					Chest chest2 = Main.chest[num178];
					if (chest2.x != num179 || chest2.y != num180)
					{
						return;
					}
					NetMessage.SendData(69, this.whoAmI, -1, chest2.name, num178, (float)num179, (float)num180, 0f, 0, 0, 0);
					return;
				}
				case 70:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int num181 = this.reader.ReadInt16();
					int num182 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num182 = this.whoAmI;
					}
					if (num181 < 200 && num181 >= 0)
					{
						NPC.CatchNPC(num181, num182);
						return;
					}
					return;
				}
				case 71:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int num183 = this.reader.ReadInt32();
					int num184 = this.reader.ReadInt32();
					int num185 = this.reader.ReadInt16();
					byte num186 = this.reader.ReadByte();
					NPC.ReleaseNPC(num183, num184, num185, (int)num186, this.whoAmI);
					return;
				}
				case 72:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					for (int a1 = 0; a1 < 40; a1++)
					{
						Main.travelShop[a1] = this.reader.ReadInt16();
					}
					return;
				}
				case 73:
				{
					Main.player[this.whoAmI].TeleportationPotion();
					return;
				}
				case 74:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					Main.anglerQuest = this.reader.ReadByte();
					Main.anglerQuestFinished = this.reader.ReadBoolean();
					return;
				}
				case 75:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					string str10 = Main.player[this.whoAmI].name;
					if (Main.anglerWhoFinishedToday.Contains(str10))
					{
						return;
					}
					Main.anglerWhoFinishedToday.Add(str10);
					return;
				}
				case 76:
				{
					int num187 = this.reader.ReadByte();
					if (num187 == Main.myPlayer && !Main.ServerSideCharacter)
					{
						return;
					}
					if (Main.netMode == 2)
					{
						num187 = this.whoAmI;
					}
					Main.player[num187].anglerQuestsFinished = this.reader.ReadInt32();
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(76, -1, this.whoAmI, "", num187, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 77:
				{
					short num188 = this.reader.ReadInt16();
					ushort num189 = this.reader.ReadUInt16();
					short num190 = this.reader.ReadInt16();
					Animation.NewTemporaryAnimation(num188, num189, num190, this.reader.ReadInt16());
					return;
				}
				case 78:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					Main.ReportInvasionProgress(this.reader.ReadInt16(), this.reader.ReadInt16(), this.reader.ReadSByte(), this.reader.ReadSByte());
					return;
				}
				case 79:
				{
					int num191 = this.reader.ReadInt16();
					int num192 = this.reader.ReadInt16();
					short num193 = this.reader.ReadInt16();
					int num194 = this.reader.ReadByte();
					int num195 = this.reader.ReadByte();
					int num196 = this.reader.ReadSByte();
					num = (!this.reader.ReadBoolean() ? -1 : 1);
					if (Main.netMode == 2)
					{
						RemoteClient remoteClient = Netplay.Clients[this.whoAmI];
						remoteClient.SpamAddBlock = remoteClient.SpamAddBlock + 1f;
						if (!Netplay.Clients[this.whoAmI].TileSections[Netplay.GetSectionX(num191), Netplay.GetSectionY(num192)])
						{
							return;
						}
					}
					WorldGen.PlaceObject(num191, num192, num193, false, num194, num195, num196, num);
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendObjectPlacment(this.whoAmI, num191, num192, num193, num194, num195, num196, num);
					return;
				}
				case 80:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num197 = this.reader.ReadByte();
					int num198 = this.reader.ReadInt16();
					Main.player[num197].chest = num198;
					Recipe.FindRecipes();
					return;
				}
				case 81:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num199 = (int)this.reader.ReadSingle();
					int num200 = (int)this.reader.ReadSingle();
					Color color3 = this.reader.ReadRGB();
					string str11 = this.reader.ReadString();
					CombatText.NewText(new Rectangle(num199, num200, 0, 0), color3, str11, false, false);
					return;
				}
				case 82:
				{
					NetManager.Instance.Read(this.reader, this.whoAmI);
					return;
				}
				case 83:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num201 = this.reader.ReadInt16();
					int num202 = this.reader.ReadInt32();
					if (num201 < 0 || num201 >= 251)
					{
						return;
					}
					NPC.killCount[num201] = num202;
					return;
				}
				case 84:
				{
					byte num203 = this.reader.ReadByte();
					float single9 = this.reader.ReadSingle();
					Main.player[num203].stealth = single9;
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(84, -1, this.whoAmI, "", (int)num203, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 85:
				{
					int num204 = this.whoAmI;
					byte num205 = this.reader.ReadByte();
					if (Main.netMode != 2 || num204 >= 255 || num205 >= 58)
					{
						return;
					}
					Chest.ServerPlaceItem(this.whoAmI, (int)num205);
					return;
				}
				case 86:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num206 = this.reader.ReadInt32();
					if (this.reader.ReadBoolean())
					{
						TileEntity tileEntity1 = TileEntity.Read(this.reader);
						TileEntity.ByID[tileEntity1.ID] = tileEntity1;
						TileEntity.ByPosition[tileEntity1.Position] = tileEntity1;
						return;
					}
					if (!TileEntity.ByID.TryGetValue(num206, out tileEntity) || !(tileEntity is TETrainingDummy) && !(tileEntity is TEItemFrame))
					{
						return;
					}
					TileEntity.ByID.Remove(num206);
					TileEntity.ByPosition.Remove(tileEntity.Position);
					return;
				}
				case 87:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int num207 = this.reader.ReadInt16();
					int num208 = this.reader.ReadInt16();
					int num209 = this.reader.ReadByte();
					if (num207 < 0 || num207 >= Main.maxTilesX)
					{
						return;
					}
					if (num208 < 0 || num208 >= Main.maxTilesY)
					{
						return;
					}
					if (TileEntity.ByPosition.ContainsKey(new Point16(num207, num208)))
					{
						return;
					}
					switch (num209)
					{
						case 0:
						{
							if (!TETrainingDummy.ValidTile(num207, num208))
							{
								return;
							}
							TETrainingDummy.Place(num207, num208);
							return;
						}
						case 1:
						{
							if (!TEItemFrame.ValidTile(num207, num208))
							{
								return;
							}
							int num210 = TEItemFrame.Place(num207, num208);
							NetMessage.SendData(86, -1, -1, "", num210, (float)num207, (float)num208, 0f, 0, 0, 0);
							return;
						}
						default:
						{
							return;
						}
					}
				}
				case 88:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int num211 = this.reader.ReadInt16();
					if (num211 < 0 || num211 > 400)
					{
						return;
					}
					Item item8 = Main.item[num211];
					if (this.reader.ReadByte() == 0)
					{
						return;
					}
					item8.color.PackedValue = this.reader.ReadUInt32();
					return;
				}
				case 89:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					int num212 = this.reader.ReadInt16();
					int num213 = this.reader.ReadInt16();
					int num214 = this.reader.ReadInt16();
					int num215 = this.reader.ReadByte();
					int num216 = this.reader.ReadInt16();
					TEItemFrame.TryPlacing(num212, num213, num214, num215, num216);
					return;
				}
				case 91:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					int emoteBubble = this.reader.ReadInt32();
					int num217 = this.reader.ReadByte();
					if (num217 != 255)
					{
						int num218 = this.reader.ReadUInt16();
						int num219 = this.reader.ReadByte();
						int num220 = this.reader.ReadByte();
						int num221 = 0;
						if (num220 < 0)
						{
							num221 = this.reader.ReadInt16();
						}
						/*WorldUIAnchor worldUIAnchor = EmoteBubble.DeserializeNetAnchor(num217, num218);
						lock (EmoteBubble.byID)
						{
							if (EmoteBubble.byID.ContainsKey(emoteBubble))
							{
								EmoteBubble.byID[emoteBubble].lifeTime = num219;
								EmoteBubble.byID[emoteBubble].lifeTimeStart = num219;
								EmoteBubble.byID[emoteBubble].emote = num220;
								EmoteBubble.byID[emoteBubble].anchor = worldUIAnchor;
							}
							else
							{
								EmoteBubble.byID[emoteBubble] = new EmoteBubble(num220, worldUIAnchor, num219);
							}
							EmoteBubble.byID[emoteBubble].ID = emoteBubble;
							EmoteBubble.byID[emoteBubble].metadata = num221;
							return;
						}*/
					}
					/*else
					{
						if (!EmoteBubble.byID.ContainsKey(emoteBubble))
						{
							return;
						}
						EmoteBubble.byID.Remove(emoteBubble);
						return;
					}*/
					return;
				}
				case 92:
				{
					int num222 = this.reader.ReadInt16();
					float single10 = this.reader.ReadSingle();
					float single11 = this.reader.ReadSingle();
					float single12 = this.reader.ReadSingle();
					if (Main.netMode == 1)
					{
						Main.npc[num222].extraValue = single10;
						return;
					}
					NPC nPC2 = Main.npc[num222];
					nPC2.extraValue = nPC2.extraValue + single10;
					NetMessage.SendData(92, -1, -1, "", num222, Main.npc[num222].extraValue, single11, single12, 0, 0, 0);
					return;
				}
				case 95:
				{
					if (Main.netMode != 2)
					{
						return;
					}
					ushort num223 = this.reader.ReadUInt16();
					if (num223 < 0 || num223 >= 1000)
					{
						return;
					}
					Projectile projectile1 = Main.projectile[num223];
					if (projectile1.type != 602)
					{
						return;
					}
					projectile1.Kill();
					if (Main.netMode == 0)
					{
						return;
					}
					NetMessage.SendData(29, -1, -1, "", projectile1.whoAmI, (float)projectile1.owner, 0f, 0f, 0, 0, 0);
					return;
				}
				case 96:
				{
					int num224 = this.reader.ReadByte();
					Player player15 = Main.player[num224];
					int num225 = this.reader.ReadInt16();
					Vector2 vector28 = this.reader.ReadVector2();
					Vector2 vector29 = this.reader.ReadVector2();
					player15.lastPortalColorIndex = num225 + (num225 % 2 == 0 ? 1 : -1);
					player15.Teleport(vector28, 4, num225);
					player15.velocity = vector29;
					return;
				}
				case 97:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					AchievementsHelper.NotifyNPCKilledDirect(Main.player[Main.myPlayer], this.reader.ReadInt16());
					return;
				}
				case 99:
				{
					int num226 = this.reader.ReadByte();
					if (Main.netMode == 2)
					{
						num226 = this.whoAmI;
					}
					Player player16 = Main.player[num226];
					player16.MinionTargetPoint = this.reader.ReadVector2();
					if (Main.netMode != 2)
					{
						return;
					}
					NetMessage.SendData(99, -1, this.whoAmI, "", num226, 0f, 0f, 0f, 0, 0, 0);
					return;
				}
				case 100:
				{
					int num227 = this.reader.ReadUInt16();
					NPC nPC3 = Main.npc[num227];
					int num228 = this.reader.ReadInt16();
					Vector2 vector210 = this.reader.ReadVector2();
					Vector2 vector211 = this.reader.ReadVector2();
					nPC3.lastPortalColorIndex = num228 + (num228 % 2 == 0 ? 1 : -1);
					nPC3.Teleport(vector210, 4, num228);
					nPC3.velocity = vector211;
					return;
				}
				case 101:
				{
					if (Main.netMode == 2)
					{
						return;
					}
					NPC.ShieldStrengthTowerSolar = this.reader.ReadUInt16();
					NPC.ShieldStrengthTowerVortex = this.reader.ReadUInt16();
					NPC.ShieldStrengthTowerNebula = this.reader.ReadUInt16();
					NPC.ShieldStrengthTowerStardust = this.reader.ReadUInt16();
					return;
				}
				case 102:
				{
					int num229 = this.reader.ReadByte();
					byte num230 = this.reader.ReadByte();
					Vector2 vector212 = this.reader.ReadVector2();
					if (Main.netMode == 2)
					{
						num229 = this.whoAmI;
						NetMessage.SendData(102, -1, -1, "", num229, (float)num230, vector212.X, vector212.Y, 0, 0, 0);
						return;
					}
					Player player17 = Main.player[num229];
					for (int b1 = 0; b1 < 255; b1++)
					{
						Player player18 = Main.player[b1];
						if (player18.active && !player18.dead && (player17.team == 0 || player17.team == player18.team) && player18.Distance(vector212) < 700f)
						{
							Vector2 center = player17.Center - player18.Center;
							Vector2 vector213 = Vector2.Normalize(center);
							if (!vector213.HasNaNs())
							{
								int num231 = 90;
								float single13 = 0f;
								float single14 = 0.209439516f;
								Vector2 vector214 = new Vector2(0f, -8f);
								Vector2 vector215 = new Vector2(-3f);
								float single15 = 0f;
								float single16 = 0.005f;
								num5 = num230;
								if (num5 == 173)
								{
									num231 = 90;
								}
								else if (num5 == 176)
								{
									num231 = 88;
								}
								else if (num5 == 179)
								{
									num231 = 86;
								}
							}
							player18.NebulaLevelup((int)num230);
						}
					}
					return;
				}
				case 103:
				{
					if (Main.netMode != 1)
					{
						return;
					}
					NPC.MoonLordCountdown = this.reader.ReadInt32();
					return;
				}
				case 104:
				{
					if (Main.netMode != 1 || Main.npcShop <= 0)
					{
						return;
					}
					Item[] itemArray = Main.instance.shop[Main.npcShop].item;
					int num234 = this.reader.ReadByte();
					int num235 = this.reader.ReadInt16();
					int num236 = this.reader.ReadInt16();
					int num237 = this.reader.ReadByte();
					int num238 = this.reader.ReadInt32();
					BitsByte bitsByte15 = this.reader.ReadByte();
					if (num234 >= (int)itemArray.Length)
					{
						return;
					}
					itemArray[num234] = new Item();
					itemArray[num234].netDefaults(num235);
					itemArray[num234].stack = num236;
					itemArray[num234].Prefix(num237);
					itemArray[num234].value = num238;
					itemArray[num234].buyOnce = bitsByte15[0];
					return;
				}
				default:
				{
					return;
				}
			}
		}

		public void Reset()
		{
			this.readBuffer = new byte[131070];
			//this.writeBuffer = new byte[131070];
			this.writeLocked = false;
			this.messageLength = 0;
			this.totalData = 0;
			this.spamCount = 0;
			this.broadcast = false;
			this.checkBytes = false;
			this.ResetReader();
			this.ResetWriter();
		}

		public void ResetReader()
		{
			lock (this)
			{
				if (this.readerStream != null)
				{
					this.readerStream.Close();
				}
				this.readerStream = new MemoryStream(this.readBuffer);
				this.reader = new BinaryReader(this.readerStream);
			}
		}

		public void ResetWriter()
		{
			//lock (this)
			//{
			//	if (this.writerStream != null)
			//	{
			//		this.writerStream.Close();
			//	}
			//	this.writerStream = new MemoryStream(this.writeBuffer);
			//	this.writer = new BinaryWriter(this.writerStream);
			//}
		}
	}
}