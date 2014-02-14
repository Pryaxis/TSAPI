using System;
using System.Text;
using TerrariaApi.Server;

namespace Terraria
{
	public class MessageBuffer
	{
		public const int readBufferMax = 65535;
		public const int writeBufferMax = 65535;
		public bool broadcast;
		public byte[] readBuffer = new byte[65535];
		public byte[] writeBuffer = new byte[65535];
		public bool writeLocked;
		public int messageLength;
		public int totalData;
		public int whoAmI;
		public int spamCount;
		public int maxSpam;
		public bool checkBytes;
		public void Reset()
		{
			this.writeBuffer = new byte[65535];
			this.writeLocked = false;
			this.messageLength = 0;
			this.totalData = 0;
			this.spamCount = 0;
			this.broadcast = false;
			this.checkBytes = false;
		}
		public void GetData(int start, int length)
		{
			if (this.whoAmI < 256)
			{
				Netplay.serverSock[this.whoAmI].timeOut = 0;
			}
			else
			{
				Netplay.clientSock.timeOut = 0;
			}
			int num = start + 1;
			byte b = this.readBuffer[start];
			if (ServerApi.Hooks.InvokeNetGetData(ref b, this, ref num, ref length))
			{
				return;
			}
			Main.rxMsg++;
			Main.rxData += length;
			Main.rxMsgType[(int)b]++;
			Main.rxDataType[(int)b] += length;
			if (Main.netMode == 1 && Netplay.clientSock.statusMax > 0)
			{
				Netplay.clientSock.statusCount++;
			}
			if (Main.verboseNetplay)
			{
				for (int i = start; i < start + length; i++)
				{
				}
				for (int j = start; j < start + length; j++)
				{
					byte arg_CD_0 = this.readBuffer[j];
				}
			}
			if (Main.netMode == 2 && b != 38 && Netplay.serverSock[this.whoAmI].state == -1)
			{
				NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0f, 0f, 0f, 0);
				return;
			}
			if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state < 10 && b > 12 && b != 16 && b != 42 && b != 50 && b != 38 && b != 68)
			{
				NetMessage.BootPlayer(this.whoAmI, Lang.mp[2]);
			}
			if (b == 1 && Main.netMode == 2)
			{
				if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
				{
					NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[3], 0, 0f, 0f, 0f, 0);
					return;
				}
				if (Netplay.serverSock[this.whoAmI].state == 0)
				{
					string @string = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
					if (!(@string == "Terraria" + Main.curRelease))
					{
						NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[4], 0, 0f, 0f, 0f, 0);
						return;
					}
					if (Netplay.password == null || Netplay.password == "")
					{
						Netplay.serverSock[this.whoAmI].state = 1;
						NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
						return;
					}
					Netplay.serverSock[this.whoAmI].state = -1;
					NetMessage.SendData(37, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
					return;
				}
			}
			else
			{
				if (b == 2 && Main.netMode == 1)
				{
					Netplay.disconnect = true;
					Main.statusText = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
					return;
				}
				if (b == 3 && Main.netMode == 1)
				{
					if (Netplay.clientSock.state == 1)
					{
						Netplay.clientSock.state = 2;
					}
					int num2 = (int)this.readBuffer[start + 1];
					if (num2 != Main.myPlayer)
					{
						Main.player[num2] = (Player)Main.player[Main.myPlayer].Clone();
						Main.player[Main.myPlayer] = new Player();
						Main.player[num2].whoAmi = num2;
						Main.myPlayer = num2;
					}
					NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(68, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
					for (int k = 0; k < 59; k++)
					{
						NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
					}
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 60f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 61f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 62f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 63f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 64f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 65f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 66f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 67f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 68f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 69f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[11].name, Main.myPlayer, 70f, (float)Main.player[Main.myPlayer].armor[11].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[12].name, Main.myPlayer, 71f, (float)Main.player[Main.myPlayer].armor[12].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[13].name, Main.myPlayer, 72f, (float)Main.player[Main.myPlayer].armor[13].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[14].name, Main.myPlayer, 73f, (float)Main.player[Main.myPlayer].armor[14].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[15].name, Main.myPlayer, 74f, (float)Main.player[Main.myPlayer].armor[15].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[0].name, Main.myPlayer, 75f, (float)Main.player[Main.myPlayer].dye[0].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[1].name, Main.myPlayer, 76f, (float)Main.player[Main.myPlayer].dye[1].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[2].name, Main.myPlayer, 77f, (float)Main.player[Main.myPlayer].dye[2].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[3].name, Main.myPlayer, 78f, (float)Main.player[Main.myPlayer].dye[3].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[4].name, Main.myPlayer, 79f, (float)Main.player[Main.myPlayer].dye[4].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[5].name, Main.myPlayer, 80f, (float)Main.player[Main.myPlayer].dye[5].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[6].name, Main.myPlayer, 81f, (float)Main.player[Main.myPlayer].dye[6].prefix, 0f, 0);
					NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].dye[7].name, Main.myPlayer, 82f, (float)Main.player[Main.myPlayer].dye[7].prefix, 0f, 0);
					NetMessage.SendData(6, -1, -1, "", 0, 0f, 0f, 0f, 0);
					if (Netplay.clientSock.state == 2)
					{
						Netplay.clientSock.state = 3;
						return;
					}
				}
				else if (b == 4)
				{
					bool flag = false;
					int num3 = (int)this.readBuffer[start + 1];
					if (Main.netMode == 2)
					{
						num3 = this.whoAmI;
					}
					if (num3 == Main.myPlayer && !Main.ServerSideCharacter)
					{
						return;
					}
					int num4 = (int)this.readBuffer[start + 2];
					if (num4 >= 123)
					{
						num4 = 0;
					}
					Main.player[num3].hair = num4;
					Main.player[num3].whoAmi = num3;
					num += 2;
					byte b2 = this.readBuffer[num];
					num++;
					if (b2 == 1)
					{
						Main.player[num3].male = true;
					}
					else
					{
						Main.player[num3].male = false;
					}
					Main.player[num3].hairDye = this.readBuffer[num];
					num++;
					Main.player[num3].hideVisual = this.readBuffer[num];
					num++;
					Main.player[num3].hairColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].hairColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].hairColor.B = this.readBuffer[num];
					num++;
					Main.player[num3].skinColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].skinColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].skinColor.B = this.readBuffer[num];
					num++;
					Main.player[num3].eyeColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].eyeColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].eyeColor.B = this.readBuffer[num];
					num++;
					Main.player[num3].shirtColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].shirtColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].shirtColor.B = this.readBuffer[num];
					num++;
					Main.player[num3].underShirtColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].underShirtColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].underShirtColor.B = this.readBuffer[num];
					num++;
					Main.player[num3].pantsColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].pantsColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].pantsColor.B = this.readBuffer[num];
					num++;
					Main.player[num3].shoeColor.R = this.readBuffer[num];
					num++;
					Main.player[num3].shoeColor.G = this.readBuffer[num];
					num++;
					Main.player[num3].shoeColor.B = this.readBuffer[num];
					num++;
					byte difficulty = this.readBuffer[num];
					Main.player[num3].difficulty = difficulty;
					num++;
					string text = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
					text = text.Trim();
					Main.player[num3].name = text.Trim();
					if (Main.netMode == 2)
					{
						if (Netplay.serverSock[this.whoAmI].state < 10)
						{
							for (int l = 0; l < 255; l++)
							{
								if (l != num3 && text == Main.player[l].name && Netplay.serverSock[l].active)
								{
									flag = true;
								}
							}
						}
						if (flag)
						{
							if (!ServerApi.Hooks.InvokeNetNameCollision(num3, text))
							{
								NetMessage.SendData(2, this.whoAmI, -1, text + " " + Lang.mp[5], 0, 0f, 0f, 0f, 0);
								return;
							}
						}
						if (text.Length > Player.nameLen)
						{
							NetMessage.SendData(2, this.whoAmI, -1, "Name is too long.", 0, 0f, 0f, 0f, 0);
							return;
						}
						if (text == "")
						{
							NetMessage.SendData(2, this.whoAmI, -1, "Empty name.", 0, 0f, 0f, 0f, 0);
							return;
						}
						Netplay.serverSock[this.whoAmI].oldName = text;
						Netplay.serverSock[this.whoAmI].name = text;
						NetMessage.SendData(4, -1, this.whoAmI, text, num3, 0f, 0f, 0f, 0);
						return;
					}
				}
				else
				{
					if (b == 5)
					{
						int num5 = (int)this.readBuffer[start + 1];
						if (Main.netMode == 2)
						{
							num5 = this.whoAmI;
						}
						if (num5 == Main.myPlayer && !Main.ServerSideCharacter)
						{
							return;
						}
						lock (Main.player[num5])
						{
							int num6 = (int)this.readBuffer[start + 2];
							int stack = (int)BitConverter.ToInt16(this.readBuffer, start + 3);
							byte b3 = this.readBuffer[start + 5];
							int type = (int)BitConverter.ToInt16(this.readBuffer, start + 6);
							if (num6 < 59)
							{
								Main.player[num5].inventory[num6] = new Item();
								Main.player[num5].inventory[num6].netDefaults(type);
								Main.player[num5].inventory[num6].stack = stack;
								Main.player[num5].inventory[num6].Prefix((int)b3);
								if (num5 == Main.myPlayer && num6 == 58)
								{
									Main.mouseItem = Main.player[num5].inventory[num6].Clone();
								}
							}
							else if (num6 >= 75 && num6 <= 82)
							{
								int num7 = num6 - 58 - 17;
								Main.player[num5].dye[num7] = new Item();
								Main.player[num5].dye[num7].netDefaults(type);
								Main.player[num5].dye[num7].stack = stack;
								Main.player[num5].dye[num7].Prefix((int)b3);
							}
							else
							{
								Main.player[num5].armor[num6 - 58 - 1] = new Item();
								Main.player[num5].armor[num6 - 58 - 1].netDefaults(type);
								Main.player[num5].armor[num6 - 58 - 1].stack = stack;
								Main.player[num5].armor[num6 - 58 - 1].Prefix((int)b3);
							}
							if (Main.netMode == 2 && num5 == this.whoAmI)
							{
								NetMessage.SendData(5, -1, this.whoAmI, "", num5, (float)num6, (float)b3, 0f, 0);
							}
							return;
						}
					}
					if (b == 6)
					{
						if (Main.netMode == 2)
						{
							if (Netplay.serverSock[this.whoAmI].state == 1)
							{
								Netplay.serverSock[this.whoAmI].state = 2;
							}
							NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							return;
						}
					}
					else if (b == 7)
					{
						if (Main.netMode == 1)
						{
							Main.time = (double)BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.dayTime = false;
							if (this.readBuffer[num] == 1)
							{
								Main.dayTime = true;
							}
							num++;
							Main.moonPhase = (int)this.readBuffer[num];
							num++;
							int num8 = (int)this.readBuffer[num];
							num++;
							int num9 = (int)this.readBuffer[num];
							num++;
							if (num8 == 1)
							{
								Main.bloodMoon = true;
							}
							else
							{
								Main.bloodMoon = false;
							}
							if (num9 == 1)
							{
								Main.eclipse = true;
							}
							else
							{
								Main.eclipse = false;
							}
							Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.worldSurface = (double)BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.rockLayer = (double)BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.worldID = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.moonType = (int)this.readBuffer[num];
							num++;
							Main.treeX[0] = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.treeX[1] = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.treeX[2] = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.treeStyle[0] = (int)this.readBuffer[num];
							num++;
							Main.treeStyle[1] = (int)this.readBuffer[num];
							num++;
							Main.treeStyle[2] = (int)this.readBuffer[num];
							num++;
							Main.treeStyle[3] = (int)this.readBuffer[num];
							num++;
							Main.caveBackX[0] = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.caveBackX[1] = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.caveBackX[2] = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.caveBackStyle[0] = (int)this.readBuffer[num];
							num++;
							Main.caveBackStyle[1] = (int)this.readBuffer[num];
							num++;
							Main.caveBackStyle[2] = (int)this.readBuffer[num];
							num++;
							Main.caveBackStyle[3] = (int)this.readBuffer[num];
							num++;
							byte style = this.readBuffer[num];
							num++;
							byte style2 = this.readBuffer[num];
							num++;
							byte style3 = this.readBuffer[num];
							num++;
							byte style4 = this.readBuffer[num];
							num++;
							byte style5 = this.readBuffer[num];
							num++;
							byte style6 = this.readBuffer[num];
							num++;
							byte style7 = this.readBuffer[num];
							num++;
							byte style8 = this.readBuffer[num];
							num++;
							WorldGen.setBG(0, (int)style);
							WorldGen.setBG(1, (int)style2);
							WorldGen.setBG(2, (int)style3);
							WorldGen.setBG(3, (int)style4);
							WorldGen.setBG(4, (int)style5);
							WorldGen.setBG(5, (int)style6);
							WorldGen.setBG(6, (int)style7);
							WorldGen.setBG(7, (int)style8);
							Main.iceBackStyle = (int)this.readBuffer[num];
							num++;
							Main.jungleBackStyle = (int)this.readBuffer[num];
							num++;
							Main.hellBackStyle = (int)this.readBuffer[num];
							num++;
							Main.windSpeedSet = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							Main.numClouds = (int)this.readBuffer[num];
							num++;
							byte b4 = this.readBuffer[num];
							num++;
							byte b5 = this.readBuffer[num];
							num++;
							float num10 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							Main.maxRaining = num10;
							if (num10 > 0f)
							{
								Main.raining = true;
							}
							else
							{
								Main.raining = false;
							}
							bool flag3 = false;
							bool crimson = false;
							if ((b4 & 1) == 1)
							{
								WorldGen.shadowOrbSmashed = true;
							}
							if ((b4 & 2) == 2)
							{
								NPC.downedBoss1 = true;
							}
							if ((b4 & 4) == 4)
							{
								NPC.downedBoss2 = true;
							}
							if ((b4 & 8) == 8)
							{
								NPC.downedBoss3 = true;
							}
							if ((b4 & 16) == 16)
							{
								Main.hardMode = true;
							}
							if ((b4 & 32) == 32)
							{
								NPC.downedClown = true;
							}
							if ((b4 & 64) == 64)
							{
								Main.ServerSideCharacter = true;
							}
							if ((b4 & 128) == 128)
							{
								NPC.downedPlantBoss = true;
							}
							if ((b5 & 1) == 1)
							{
								NPC.downedMechBoss1 = true;
							}
							if ((b5 & 2) == 2)
							{
								NPC.downedMechBoss2 = true;
							}
							if ((b5 & 4) == 4)
							{
								NPC.downedMechBoss3 = true;
							}
							if ((b5 & 8) == 8)
							{
								NPC.downedMechBossAny = true;
							}
							if ((b5 & 16) == 16)
							{
								flag3 = true;
							}
							if ((b5 & 32) == 32)
							{
								crimson = true;
							}
							if ((b5 & 64) == 64)
							{
								Main.pumpkinMoon = true;
							}
							else
							{
								Main.pumpkinMoon = false;
							}
							if ((b5 & 128) == 128)
							{
								Main.snowMoon = true;
							}
							else
							{
								Main.snowMoon = false;
							}
							if (flag3)
							{
								Main.cloudBGActive = 1f;
							}
							if (!flag3)
							{
								Main.cloudBGActive = 0f;
							}
							WorldGen.crimson = crimson;
							Main.worldName = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
							if (Netplay.clientSock.state == 3)
							{
								Netplay.clientSock.state = 4;
								return;
							}
						}
					}
					else if (b == 8)
					{
						if (Main.netMode == 2)
						{
							int num11 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num12 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							bool flag4 = true;
							if (num11 == -1 || num12 == -1)
							{
								flag4 = false;
							}
							else if (num11 < 10 || num11 > Main.maxTilesX - 10)
							{
								flag4 = false;
							}
							else if (num12 < 10 || num12 > Main.maxTilesY - 10)
							{
								flag4 = false;
							}
							int num13 = -1;
							int num14 = -1;
							int num15 = Netplay.GetSectionX(Main.spawnTileX) - 2;
							int num16 = Netplay.GetSectionY(Main.spawnTileY) - 1;
							int num17 = num15 + 5;
							int num18 = num16 + 3;
							if (num15 < 0)
							{
								num15 = 0;
							}
							if (num17 >= Main.maxSectionsX)
							{
								num17 = Main.maxSectionsX - 1;
							}
							if (num16 < 0)
							{
								num16 = 0;
							}
							if (num18 >= Main.maxSectionsY)
							{
								num18 = Main.maxSectionsY - 1;
							}
							int num19 = (num17 - num15) * (num18 - num16);
							if (flag4)
							{
								num11 = Netplay.GetSectionX(num11) - 2;
								num12 = Netplay.GetSectionY(num12) - 1;
								num13 = num11 + 5;
								num14 = num12 + 3;
								if (num15 < 0)
								{
									num15 = 0;
								}
								if (num17 >= Main.maxSectionsX)
								{
									num17 = Main.maxSectionsX - 1;
								}
								if (num16 < 0)
								{
									num16 = 0;
								}
								if (num18 >= Main.maxSectionsY)
								{
									num18 = Main.maxSectionsY - 1;
								}
								for (int m = num11; m < num13; m++)
								{
									for (int n = num12; n < num14; n++)
									{
										if (m < num15 || m >= num17 || n < num16 || n >= num18)
										{
											num19++;
										}
									}
								}
							}
							if (Netplay.serverSock[this.whoAmI].state == 2)
							{
								Netplay.serverSock[this.whoAmI].state = 3;
							}
							NetMessage.SendData(9, this.whoAmI, -1, Lang.inter[44], num19, 0f, 0f, 0f, 0);
							Netplay.serverSock[this.whoAmI].statusText2 = "is receiving tile data";
							Netplay.serverSock[this.whoAmI].statusMax += num19;
							for (int num20 = num15; num20 < num17; num20++)
							{
								for (int num21 = num16; num21 < num18; num21++)
								{
									NetMessage.SendSection(this.whoAmI, num20, num21, false);
								}
							}
							if (flag4)
							{
								for (int num22 = num11; num22 < num13; num22++)
								{
									for (int num23 = num12; num23 < num14; num23++)
									{
										NetMessage.SendSection(this.whoAmI, num22, num23, true);
									}
								}
								NetMessage.SendData(11, this.whoAmI, -1, "", num11, (float)num12, (float)(num13 - 1), (float)(num14 - 1), 0);
							}
							NetMessage.SendData(11, this.whoAmI, -1, "", num15, (float)num16, (float)(num17 - 1), (float)(num18 - 1), 0);
							for (int num24 = 0; num24 < 400; num24++)
							{
								if (Main.item[num24].active)
								{
									NetMessage.SendData(21, this.whoAmI, -1, "", num24, 0f, 0f, 0f, 0);
									NetMessage.SendData(22, this.whoAmI, -1, "", num24, 0f, 0f, 0f, 0);
								}
							}
							for (int num25 = 0; num25 < 200; num25++)
							{
								if (Main.npc[num25].active)
								{
									NetMessage.SendData(23, this.whoAmI, -1, "", num25, 0f, 0f, 0f, 0);
								}
							}
							for (int num26 = 0; num26 < 1000; num26++)
							{
								if (Main.projectile[num26].active && (Main.projPet[Main.projectile[num26].type] || Main.projectile[num26].netImportant))
								{
									NetMessage.SendData(27, this.whoAmI, -1, "", num26, 0f, 0f, 0f, 0);
								}
							}
							NetMessage.SendData(49, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							NetMessage.SendData(57, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
							return;
						}
					}
					else if (b == 9)
					{
						if (Main.netMode == 1)
						{
							int num27 = BitConverter.ToInt32(this.readBuffer, start + 1);
							string string2 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
							Netplay.clientSock.statusMax += num27;
							Netplay.clientSock.statusText = string2;
							return;
						}
					}
					else
					{
						if (b == 10 && Main.netMode == 1)
						{
							num = start + 1;
							NetMessage.DecompressTileBlock(this.readBuffer, num, length, true);
							return;
						}
						if (b == 11)
						{
							if (Main.netMode == 1)
							{
								int startX = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 4;
								int startY = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 4;
								int endX = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 4;
								int endY = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 4;
								WorldGen.SectionTileFrame(startX, startY, endX, endY);
								return;
							}
						}
						else if (b == 12)
						{
							int num28 = (int)this.readBuffer[num];
							if (Main.netMode == 2)
							{
								num28 = this.whoAmI;
							}
							num++;
							Main.player[num28].SpawnX = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.player[num28].SpawnY = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							Main.player[num28].Spawn();
							if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state >= 3)
							{
								if (Netplay.serverSock[this.whoAmI].state == 3)
								{
									Netplay.serverSock[this.whoAmI].state = 10;
									NetMessage.greetPlayer(this.whoAmI);
									NetMessage.buffer[this.whoAmI].broadcast = true;
									NetMessage.syncPlayers();
									NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
									return;
								}
								NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 13)
						{
							int num29 = (int)this.readBuffer[num];
							if (num29 == Main.myPlayer && !Main.ServerSideCharacter)
							{
								return;
							}
							if (Main.netMode == 1)
							{
								bool arg_1E83_0 = Main.player[num29].active;
							}
							if (Main.netMode == 2)
							{
								num29 = this.whoAmI;
							}
							num++;
							int num30 = (int)this.readBuffer[num];
							num++;
							int selectedItem = (int)this.readBuffer[num];
							num++;
							float x = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float num31 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float x2 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							byte b6 = this.readBuffer[num];
							num++;
							Main.player[num29].selectedItem = selectedItem;
							Main.player[num29].position.X = x;
							Main.player[num29].position.Y = num31;
							Main.player[num29].velocity.X = x2;
							Main.player[num29].velocity.Y = y;
							Main.player[num29].oldVelocity = Main.player[num29].velocity;
							Main.player[num29].fallStart = (int)(num31 / 16f);
							Main.player[num29].controlUp = false;
							Main.player[num29].controlDown = false;
							Main.player[num29].controlLeft = false;
							Main.player[num29].controlRight = false;
							Main.player[num29].controlJump = false;
							Main.player[num29].controlUseItem = false;
							Main.player[num29].direction = -1;
							if ((num30 & 1) == 1)
							{
								Main.player[num29].controlUp = true;
							}
							if ((num30 & 2) == 2)
							{
								Main.player[num29].controlDown = true;
							}
							if ((num30 & 4) == 4)
							{
								Main.player[num29].controlLeft = true;
							}
							if ((num30 & 8) == 8)
							{
								Main.player[num29].controlRight = true;
							}
							if ((num30 & 16) == 16)
							{
								Main.player[num29].controlJump = true;
							}
							if ((num30 & 32) == 32)
							{
								Main.player[num29].controlUseItem = true;
							}
							if ((num30 & 64) == 64)
							{
								Main.player[num29].direction = 1;
							}
							if ((b6 & 1) == 1)
							{
								Main.player[num29].pulley = true;
								if ((b6 & 2) == 2)
								{
									Main.player[num29].pulleyDir = 2;
								}
								else
								{
									Main.player[num29].pulleyDir = 1;
								}
							}
							else
							{
								Main.player[num29].pulley = false;
							}
							if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state == 10)
							{
								NetMessage.SendData(13, -1, this.whoAmI, "", num29, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 14)
						{
							if (Main.netMode == 1)
							{
								int num32 = (int)this.readBuffer[num];
								num++;
								int num33 = (int)this.readBuffer[num];
								if (num33 == 1)
								{
									if (!Main.player[num32].active)
									{
										Main.player[num32] = new Player();
									}
									Main.player[num32].active = true;
									return;
								}
								Main.player[num32].active = false;
								return;
							}
						}
						else if (b == 15)
						{
							if (Main.netMode == 2)
							{
								return;
							}
						}
						else if (b == 16)
						{
							int num34 = (int)this.readBuffer[num];
							num++;
							if (num34 == Main.myPlayer && !Main.ServerSideCharacter)
							{
								return;
							}
							int statLife = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							int num35 = (int)BitConverter.ToInt16(this.readBuffer, num);
							if (Main.netMode == 2)
							{
								num34 = this.whoAmI;
							}
							Main.player[num34].statLife = statLife;
							if (num35 < 100)
							{
								num35 = 100;
							}
							Main.player[num34].statLifeMax = num35;
							if (Main.player[num34].statLife <= 0)
							{
								Main.player[num34].dead = true;
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(16, -1, this.whoAmI, "", num34, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 17)
						{
							byte b7 = this.readBuffer[num];
							num++;
							int num36 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num37 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							short num38 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							int num39 = (int)this.readBuffer[num];
							bool flag5 = false;
							if (num38 == 1)
							{
								flag5 = true;
							}
							if (Main.tile[num36, num37] == null)
							{
								Main.tile[num36, num37] = new Tile();
							}
							if (Main.netMode == 2)
							{
								if (!flag5)
								{
									if (b7 == 0 || b7 == 2 || b7 == 4)
									{
										Netplay.serverSock[this.whoAmI].spamDelBlock += 1f;
									}
									else if (b7 == 1 || b7 == 3)
									{
										Netplay.serverSock[this.whoAmI].spamAddBlock += 1f;
									}
								}
								if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(num36), Netplay.GetSectionY(num37)])
								{
									flag5 = true;
								}
							}
							if (b7 == 0)
							{
								WorldGen.KillTile(num36, num37, flag5, false, false);
							}
							else if (b7 == 1)
							{
								WorldGen.PlaceTile(num36, num37, (int)num38, false, true, -1, num39);
							}
							else if (b7 == 2)
							{
								WorldGen.KillWall(num36, num37, flag5);
							}
							else if (b7 == 3)
							{
								WorldGen.PlaceWall(num36, num37, (int)num38, false);
							}
							else if (b7 == 4)
							{
								WorldGen.KillTile(num36, num37, flag5, false, true);
							}
							else if (b7 == 5)
							{
								WorldGen.PlaceWire(num36, num37);
							}
							else if (b7 == 6)
							{
								WorldGen.KillWire(num36, num37);
							}
							else if (b7 == 7)
							{
								WorldGen.PoundTile(num36, num37);
							}
							else if (b7 == 8)
							{
								WorldGen.PlaceActuator(num36, num37);
							}
							else if (b7 == 9)
							{
								WorldGen.KillActuator(num36, num37);
							}
							else if (b7 == 10)
							{
								WorldGen.PlaceWire2(num36, num37);
							}
							else if (b7 == 11)
							{
								WorldGen.KillWire2(num36, num37);
							}
							else if (b7 == 12)
							{
								WorldGen.PlaceWire3(num36, num37);
							}
							else if (b7 == 13)
							{
								WorldGen.KillWire3(num36, num37);
							}
							else if (b7 == 14)
							{
								WorldGen.SlopeTile(num36, num37, (int)num38);
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(17, -1, this.whoAmI, "", (int)b7, (float)num36, (float)num37, (float)num38, num39);
								if (b7 == 1 && num38 == 53)
								{
									NetMessage.SendTileSquare(-1, num36, num37, 1);
									return;
								}
							}
						}
						else if (b == 18)
						{
							if (Main.netMode == 1)
							{
								byte b8 = this.readBuffer[num];
								num++;
								int num40 = BitConverter.ToInt32(this.readBuffer, num);
								num += 4;
								short sunModY = BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								short moonModY = BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								if (b8 == 1)
								{
									Main.dayTime = true;
								}
								else
								{
									Main.dayTime = false;
								}
								Main.time = (double)num40;
								Main.sunModY = sunModY;
								Main.moonModY = moonModY;
								if (Main.netMode == 2)
								{
									NetMessage.SendData(18, -1, this.whoAmI, "", 0, 0f, 0f, 0f, 0);
									return;
								}
							}
						}
						else if (b == 19)
						{
							byte b9 = this.readBuffer[num];
							num++;
							int num41 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num42 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							int num43 = (int)this.readBuffer[num];
							int direction = 0;
							if (num43 == 0)
							{
								direction = -1;
							}
							if (b9 == 0)
							{
								WorldGen.OpenDoor(num41, num42, direction);
							}
							else if (b9 == 1)
							{
								WorldGen.CloseDoor(num41, num42, true);
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(19, -1, this.whoAmI, "", (int)b9, (float)num41, (float)num42, (float)num43, 0);
								return;
							}
						}
						else if (b == 20)
						{
							short num44 = BitConverter.ToInt16(this.readBuffer, start + 1);
							int num45 = BitConverter.ToInt32(this.readBuffer, start + 3);
							int num46 = BitConverter.ToInt32(this.readBuffer, start + 7);
							num = start + 11;
							for (int num47 = num45; num47 < num45 + (int)num44; num47++)
							{
								for (int num48 = num46; num48 < num46 + (int)num44; num48++)
								{
									if (Main.tile[num47, num48] == null)
									{
										Main.tile[num47, num48] = new Tile();
									}
									byte b10 = this.readBuffer[num];
									num++;
									byte b11 = this.readBuffer[num];
									num++;
									bool flag6 = Main.tile[num47, num48].active();
									if ((b10 & 1) == 1)
									{
										Main.tile[num47, num48].active(true);
									}
									else
									{
										Main.tile[num47, num48].active(false);
									}
									if ((b10 & 4) == 4)
									{
										Main.tile[num47, num48].wall = 1;
									}
									else
									{
										Main.tile[num47, num48].wall = 0;
									}
									bool flag7 = false;
									if ((b10 & 8) == 8)
									{
										flag7 = true;
									}
									if (Main.netMode != 2)
									{
										if (flag7)
										{
											Main.tile[num47, num48].liquid = 1;
										}
										else
										{
											Main.tile[num47, num48].liquid = 0;
										}
									}
									if ((b10 & 16) == 16)
									{
										Main.tile[num47, num48].wire(true);
									}
									else
									{
										Main.tile[num47, num48].wire(false);
									}
									if ((b10 & 32) == 32)
									{
										Main.tile[num47, num48].halfBrick(true);
									}
									else
									{
										Main.tile[num47, num48].halfBrick(false);
									}
									if ((b10 & 64) == 64)
									{
										Main.tile[num47, num48].actuator(true);
									}
									else
									{
										Main.tile[num47, num48].actuator(false);
									}
									if ((b10 & 128) == 128)
									{
										Main.tile[num47, num48].inActive(true);
									}
									else
									{
										Main.tile[num47, num48].inActive(false);
									}
									if ((b11 & 1) == 1)
									{
										Main.tile[num47, num48].wire2(true);
									}
									else
									{
										Main.tile[num47, num48].wire2(false);
									}
									if ((b11 & 2) == 2)
									{
										Main.tile[num47, num48].wire3(true);
									}
									else
									{
										Main.tile[num47, num48].wire3(false);
									}
									if ((b11 & 4) == 4)
									{
										Main.tile[num47, num48].color(this.readBuffer[num]);
										num++;
									}
									if ((b11 & 8) == 8)
									{
										Main.tile[num47, num48].wallColor(this.readBuffer[num]);
										num++;
									}
									if (Main.tile[num47, num48].active())
									{
										int type2 = (int)Main.tile[num47, num48].type;
										Main.tile[num47, num48].type = BitConverter.ToUInt16(this.readBuffer, num);
										num += 2;
										if (Main.tileFrameImportant[(int)Main.tile[num47, num48].type])
										{
											Main.tile[num47, num48].frameX = BitConverter.ToInt16(this.readBuffer, num);
											num += 2;
											Main.tile[num47, num48].frameY = BitConverter.ToInt16(this.readBuffer, num);
											num += 2;
										}
										else if (!flag6 || (int)Main.tile[num47, num48].type != type2)
										{
											Main.tile[num47, num48].frameX = -1;
											Main.tile[num47, num48].frameY = -1;
										}
										byte b12 = 0;
										if ((b11 & 16) == 16)
										{
											b12 = (byte)(b12 + 1);
										}
										if ((b11 & 32) == 32)
										{
											b12 = (byte)(b12 + 2);
										}
										if ((b11 & 64) == 64)
										{
											b12 = (byte)(b12 + 4);
										}
										Main.tile[num47, num48].slope(b12);
									}
									if (Main.tile[num47, num48].wall > 0)
									{
										Main.tile[num47, num48].wall = this.readBuffer[num];
										num++;
									}
									if (flag7)
									{
										Main.tile[num47, num48].liquid = this.readBuffer[num];
										num++;
										byte liquidType = this.readBuffer[num];
										num++;
										Main.tile[num47, num48].liquidType((int)liquidType);
									}
								}
							}
							WorldGen.RangeFrame(num45, num46, num45 + (int)num44, num46 + (int)num44);
							if (Main.netMode == 2)
							{
								NetMessage.SendData((int)b, -1, this.whoAmI, "", (int)num44, (float)num45, (float)num46, 0f, 0);
								return;
							}
						}
						else if (b == 21)
						{
							short num49 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							float num50 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float num51 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float x3 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y2 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							short stack2 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte pre = this.readBuffer[num];
							num++;
							byte b13 = this.readBuffer[num];
							num++;
							short num52 = BitConverter.ToInt16(this.readBuffer, num);
							if (Main.netMode == 1)
							{
								if (num52 == 0)
								{
									Main.item[(int)num49].active = false;
									return;
								}
								Main.item[(int)num49].netDefaults((int)num52);
								Main.item[(int)num49].Prefix((int)pre);
								Main.item[(int)num49].stack = (int)stack2;
								Main.item[(int)num49].position.X = num50;
								Main.item[(int)num49].position.Y = num51;
								Main.item[(int)num49].velocity.X = x3;
								Main.item[(int)num49].velocity.Y = y2;
								Main.item[(int)num49].active = true;
								Main.item[(int)num49].wet = Collision.WetCollision(Main.item[(int)num49].position, Main.item[(int)num49].width, Main.item[(int)num49].height);
								return;
							}
							else if (num52 == 0)
							{
								if (num49 < 400)
								{
									Main.item[(int)num49].active = false;
									NetMessage.SendData(21, -1, -1, "", (int)num49, 0f, 0f, 0f, 0);
									return;
								}
							}
							else
							{
								bool flag8 = false;
								if (num49 == 400)
								{
									flag8 = true;
								}
								if (flag8)
								{
									Item item = new Item();
									item.netDefaults((int)num52);
									num49 = (short)Item.NewItem((int)num50, (int)num51, item.width, item.height, item.type, (int)stack2, true, 0, false);
								}
								Main.item[(int)num49].netDefaults((int)num52);
								Main.item[(int)num49].Prefix((int)pre);
								Main.item[(int)num49].stack = (int)stack2;
								Main.item[(int)num49].position.X = num50;
								Main.item[(int)num49].position.Y = num51;
								Main.item[(int)num49].velocity.X = x3;
								Main.item[(int)num49].velocity.Y = y2;
								Main.item[(int)num49].active = true;
								Main.item[(int)num49].owner = Main.myPlayer;
								if (flag8)
								{
									NetMessage.SendData(21, -1, -1, "", (int)num49, 0f, 0f, 0f, 0);
									if (b13 == 0)
									{
										Main.item[(int)num49].ownIgnore = this.whoAmI;
										Main.item[(int)num49].ownTime = 100;
									}
									Main.item[(int)num49].FindOwner((int)num49);
									return;
								}
								NetMessage.SendData(21, -1, this.whoAmI, "", (int)num49, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 22)
						{
							short num53 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b14 = this.readBuffer[num];
							if (Main.netMode == 2 && Main.item[(int)num53].owner != this.whoAmI)
							{
								return;
							}
							Main.item[(int)num53].owner = (int)b14;
							if ((int)b14 == Main.myPlayer)
							{
								Main.item[(int)num53].keepTime = 15;
							}
							else
							{
								Main.item[(int)num53].keepTime = 0;
							}
							if (Main.netMode == 2)
							{
								Main.item[(int)num53].owner = 255;
								Main.item[(int)num53].keepTime = 15;
								NetMessage.SendData(22, -1, -1, "", (int)num53, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 23 && Main.netMode == 1)
						{
							short num54 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							float x4 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y3 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float x5 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y4 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							int target = (int)this.readBuffer[num];
							num++;
							byte b15 = this.readBuffer[num];
							num++;
							int direction2 = -1;
							int directionY = -1;
							if ((b15 & 1) == 1)
							{
								direction2 = 1;
							}
							if ((b15 & 2) == 2)
							{
								directionY = 1;
							}
							bool[] array = new bool[4];
							if ((b15 & 4) == 4)
							{
								array[3] = true;
							}
							if ((b15 & 8) == 8)
							{
								array[2] = true;
							}
							if ((b15 & 16) == 16)
							{
								array[1] = true;
							}
							if ((b15 & 32) == 32)
							{
								array[0] = true;
							}
							int spriteDirection = -1;
							if ((b15 & 64) == 64)
							{
								spriteDirection = 1;
							}
							int num55 = BitConverter.ToInt32(this.readBuffer, num);
							num += 4;
							float[] array2 = new float[NPC.maxAI];
							for (int num56 = 0; num56 < NPC.maxAI; num56++)
							{
								if (array[num56])
								{
									array2[num56] = BitConverter.ToSingle(this.readBuffer, num);
									num += 4;
								}
								else
								{
									array2[num56] = 0f;
								}
							}
							int num57 = (int)BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							int num58 = -1;
							if (!Main.npc[(int)num54].active || Main.npc[(int)num54].netID != num57)
							{
								if (Main.npc[(int)num54].active)
								{
									num58 = Main.npc[(int)num54].type;
								}
								Main.npc[(int)num54].active = true;
								Main.npc[(int)num54].netDefaults(num57);
							}
							Main.npc[(int)num54].position.X = x4;
							Main.npc[(int)num54].position.Y = y3;
							Main.npc[(int)num54].velocity.X = x5;
							Main.npc[(int)num54].velocity.Y = y4;
							Main.npc[(int)num54].target = target;
							Main.npc[(int)num54].direction = direction2;
							Main.npc[(int)num54].directionY = directionY;
							Main.npc[(int)num54].spriteDirection = spriteDirection;
							Main.npc[(int)num54].life = num55;
							if (num55 <= 0)
							{
								Main.npc[(int)num54].active = false;
							}
							for (int num59 = 0; num59 < NPC.maxAI; num59++)
							{
								Main.npc[(int)num54].ai[num59] = array2[num59];
							}
							if (num58 > -1 && num58 != Main.npc[(int)num54].type)
							{
								Main.npc[(int)num54].xForm(num58, Main.npc[(int)num54].type);
							}
							if (num57 == 262)
							{
								NPC.plantBoss = (int)num54;
							}
							if (num57 == 245)
							{
								NPC.golemBoss = (int)num54;
							}
							if (Main.npcCatchable[Main.npc[(int)num54].type])
							{
								byte releaseOwner = this.readBuffer[num];
								num++;
								Main.npc[(int)num54].releaseOwner = (short)releaseOwner;
								return;
							}
						}
						else if (b == 24)
						{
							short num60 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b16 = this.readBuffer[num];
							if (Main.netMode == 2)
							{
								b16 = (byte)this.whoAmI;
							}
							Main.npc[(int)num60].StrikeNPC(Main.player[(int)b16].inventory[Main.player[(int)b16].selectedItem].damage, Main.player[(int)b16].inventory[Main.player[(int)b16].selectedItem].knockBack, Main.player[(int)b16].direction, false, false);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(24, -1, this.whoAmI, "", (int)num60, (float)b16, 0f, 0f, 0);
								NetMessage.SendData(23, -1, -1, "", (int)num60, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 25)
						{
							int num61 = (int)this.readBuffer[start + 1];
							if (Main.netMode == 2)
							{
								num61 = this.whoAmI;
							}
							byte b17 = this.readBuffer[start + 2];
							byte b18 = this.readBuffer[start + 3];
							byte b19 = this.readBuffer[start + 4];
							if (Main.netMode == 2)
							{
								b17 = 255;
								b18 = 255;
								b19 = 255;
							}
							string string3 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
							if (Main.netMode == 1)
							{
								string newText = string3;
								if (num61 < 255)
								{
									newText = "<" + Main.player[num61].name + "> " + string3;
									Main.player[num61].chatText = string3;
									Main.player[num61].chatShowTime = Main.chatLength / 2;
								}
								Main.NewText(newText, b17, b18, b19, false);
								return;
							}
							if (Main.netMode == 2)
							{
								string text2 = string3.ToLower();
								if (text2 == Lang.mp[6] || text2 == Lang.mp[21])
								{
									string text3 = "";
									for (int num62 = 0; num62 < 255; num62++)
									{
										if (Main.player[num62].active)
										{
											if (text3 == "")
											{
												text3 += Main.player[num62].name;
											}
											else
											{
												text3 = text3 + ", " + Main.player[num62].name;
											}
										}
									}
									NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[7] + " " + text3 + ".", 255, 255f, 240f, 20f, 0);
									return;
								}
								if (text2.Length >= 4 && text2.Substring(0, 4) == "/me ")
								{
									NetMessage.SendData(25, -1, -1, "*" + Main.player[this.whoAmI].name + " " + string3.Substring(4), 255, 200f, 100f, 0f, 0);
									return;
								}
								if (text2 == Lang.mp[8])
								{
									NetMessage.SendData(25, -1, -1, string.Concat(new object[]
									{
										"*",
										Main.player[this.whoAmI].name,
										" ",
										Lang.mp[9],
										" ",
										Main.rand.Next(1, 101)
									}), 255, 255f, 240f, 20f, 0);
									return;
								}
								if (text2.Length >= 3 && text2.Substring(0, 3) == "/p ")
								{
									if (Main.player[this.whoAmI].team != 0)
									{
										for (int num63 = 0; num63 < 255; num63++)
										{
											if (Main.player[num63].team == Main.player[this.whoAmI].team)
											{
												NetMessage.SendData(25, num63, -1, string3.Substring(3), num61, (float)Main.teamColor[Main.player[this.whoAmI].team].R, (float)Main.teamColor[Main.player[this.whoAmI].team].G, (float)Main.teamColor[Main.player[this.whoAmI].team].B, 0);
											}
										}
										return;
									}
									NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[10], 255, 255f, 240f, 20f, 0);
									return;
								}
								else
								{
									if (Main.player[this.whoAmI].difficulty == 2)
									{
										b17 = Main.hcColor.R;
										b18 = Main.hcColor.G;
										b19 = Main.hcColor.B;
									}
									else if (Main.player[this.whoAmI].difficulty == 1)
									{
										b17 = Main.mcColor.R;
										b18 = Main.mcColor.G;
										b19 = Main.mcColor.B;
									}
									NetMessage.SendData(25, -1, -1, string3, num61, (float)b17, (float)b18, (float)b19, 0);
									if (Main.dedServ)
									{
										Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + string3);
										return;
									}
								}
							}
						}
						else if (b == 26)
						{
							byte b20 = this.readBuffer[num];
							if (Main.netMode == 2 && this.whoAmI != (int)b20 && (!Main.player[(int)b20].hostile || !Main.player[this.whoAmI].hostile))
							{
								return;
							}
							num++;
							int num64 = this.readBuffer[num] - 1;
							num++;
							short num65 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b21 = this.readBuffer[num];
							num++;
							bool pvp = false;
							byte b22 = this.readBuffer[num];
							num++;
							bool crit = false;
							string string4 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
							if (b21 != 0)
							{
								pvp = true;
							}
							if (b22 != 0)
							{
								crit = true;
							}
							Main.player[(int)b20].Hurt((int)num65, num64, pvp, true, string4, crit);
							if (Main.netMode == 2)
							{
								NetMessage.SendData(26, -1, this.whoAmI, string4, (int)b20, (float)num64, (float)num65, (float)b21, (int)b22);
								return;
							}
						}
						else if (b == 27)
						{
							short num66 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							float x6 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y5 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float x7 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float y6 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							float knockBack = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							short damage = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b23 = this.readBuffer[num];
							num++;
							short num67 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							float[] array3 = new float[Projectile.maxAI];
							if (Main.netMode == 2)
							{
								b23 = (byte)this.whoAmI;
								if (Main.projHostile[(int)num67])
								{
									return;
								}
							}
							for (int num68 = 0; num68 < Projectile.maxAI; num68++)
							{
								array3[num68] = BitConverter.ToSingle(this.readBuffer, num);
								num += 4;
							}
							int num69 = 1000;
							for (int num70 = 0; num70 < 1000; num70++)
							{
								if (Main.projectile[num70].owner == (int)b23 && Main.projectile[num70].identity == (int)num66 && Main.projectile[num70].active)
								{
									num69 = num70;
									break;
								}
							}
							if (num69 == 1000)
							{
								for (int num71 = 0; num71 < 1000; num71++)
								{
									if (!Main.projectile[num71].active)
									{
										num69 = num71;
										break;
									}
								}
							}
							if (!Main.projectile[num69].active || Main.projectile[num69].type != (int)num67)
							{
								Main.projectile[num69].SetDefaults((int)num67);
								if (Main.netMode == 2)
								{
									Netplay.serverSock[this.whoAmI].spamProjectile += 1f;
								}
							}
							Main.projectile[num69].identity = (int)num66;
							Main.projectile[num69].position.X = x6;
							Main.projectile[num69].position.Y = y5;
							Main.projectile[num69].velocity.X = x7;
							Main.projectile[num69].velocity.Y = y6;
							Main.projectile[num69].damage = (int)damage;
							Main.projectile[num69].type = (int)num67;
							Main.projectile[num69].owner = (int)b23;
							Main.projectile[num69].knockBack = knockBack;
							for (int num72 = 0; num72 < Projectile.maxAI; num72++)
							{
								Main.projectile[num69].ai[num72] = array3[num72];
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(27, -1, this.whoAmI, "", num69, 0f, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 28)
						{
							short num73 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							short num74 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							float num75 = BitConverter.ToSingle(this.readBuffer, num);
							num += 4;
							int num76 = this.readBuffer[num] - 1;
							num++;
							int num77 = (int)this.readBuffer[num];
							if (num74 >= 0)
							{
								if (num77 == 1)
								{
									Main.npc[(int)num73].StrikeNPC((int)num74, num75, num76, true, false);
								}
								else
								{
									Main.npc[(int)num73].StrikeNPC((int)num74, num75, num76, false, false);
								}
							}
							else
							{
								Main.npc[(int)num73].life = 0;
								Main.npc[(int)num73].HitEffect(0, 10.0);
								Main.npc[(int)num73].active = false;
							}
							if (Main.netMode == 2)
							{
								if (Main.npc[(int)num73].life <= 0)
								{
									NetMessage.SendData(28, -1, this.whoAmI, "", (int)num73, (float)num74, num75, (float)num76, num77);
									NetMessage.SendData(23, -1, -1, "", (int)num73, 0f, 0f, 0f, 0);
									return;
								}
								NetMessage.SendData(28, -1, this.whoAmI, "", (int)num73, (float)num74, num75, (float)num76, num77);
								Main.npc[(int)num73].netUpdate = true;
								return;
							}
						}
						else if (b == 29)
						{
							short num78 = BitConverter.ToInt16(this.readBuffer, num);
							num += 2;
							byte b24 = this.readBuffer[num];
							if (Main.netMode == 2)
							{
								b24 = (byte)this.whoAmI;
							}
							for (int num79 = 0; num79 < 1000; num79++)
							{
								if (Main.projectile[num79].owner == (int)b24 && Main.projectile[num79].identity == (int)num78 && Main.projectile[num79].active)
								{
									Main.projectile[num79].Kill();
									break;
								}
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(29, -1, this.whoAmI, "", (int)num78, (float)b24, 0f, 0f, 0);
								return;
							}
						}
						else if (b == 30)
						{
							byte b25 = this.readBuffer[num];
							if (Main.netMode == 2)
							{
								b25 = (byte)this.whoAmI;
							}
							num++;
							byte b26 = this.readBuffer[num];
							if (b26 == 1)
							{
								Main.player[(int)b25].hostile = true;
							}
							else
							{
								Main.player[(int)b25].hostile = false;
							}
							if (Main.netMode == 2)
							{
								NetMessage.SendData(30, -1, this.whoAmI, "", (int)b25, 0f, 0f, 0f, 0);
								string str = " " + Lang.mp[11];
								if (b26 == 0)
								{
									str = " " + Lang.mp[12];
								}
								NetMessage.SendData(25, -1, -1, Main.player[(int)b25].name + str, 255, (float)Main.teamColor[Main.player[(int)b25].team].R, (float)Main.teamColor[Main.player[(int)b25].team].G, (float)Main.teamColor[Main.player[(int)b25].team].B, 0);
								return;
							}
						}
						else if (b == 31)
						{
							if (Main.netMode == 2)
							{
								int x8 = BitConverter.ToInt32(this.readBuffer, num);
								num += 4;
								int y7 = BitConverter.ToInt32(this.readBuffer, num);
								num += 4;
								int num80 = Chest.FindChest(x8, y7);
								if (num80 > -1 && Chest.UsingChest(num80) == -1)
								{
									for (int num81 = 0; num81 < Chest.maxItems; num81++)
									{
										NetMessage.SendData(32, this.whoAmI, -1, "", num80, (float)num81, 0f, 0f, 0);
									}
									NetMessage.SendData(33, this.whoAmI, -1, "", num80, 0f, 0f, 0f, 0);
									Main.player[this.whoAmI].chest = num80;
									return;
								}
							}
						}
						else
						{
							if (b == 32)
							{
								int num82 = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								int num83 = (int)this.readBuffer[num];
								num++;
								int stack3 = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								int pre2 = (int)this.readBuffer[num];
								num++;
								int type3 = (int)BitConverter.ToInt16(this.readBuffer, num);
								if (Main.chest[num82] == null)
								{
									Main.chest[num82] = new Chest(false);
								}
								if (Main.chest[num82].item[num83] == null)
								{
									Main.chest[num82].item[num83] = new Item();
								}
								Main.chest[num82].item[num83].netDefaults(type3);
								Main.chest[num82].item[num83].Prefix(pre2);
								Main.chest[num82].item[num83].stack = stack3;
								return;
							}
							if (b == 33)
							{
								int num84 = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								int chestX = BitConverter.ToInt32(this.readBuffer, num);
								num += 4;
								int chestY = BitConverter.ToInt32(this.readBuffer, num);
								num += 4;
								int num85 = (int)this.readBuffer[num];
								num++;
								string text4 = string.Empty;
								if (num85 != 0)
								{
									if (num85 <= 20)
									{
										text4 = Encoding.UTF8.GetString(this.readBuffer, num, num85);
									}
									else if (num85 != 255)
									{
										num85 = 0;
									}
								}
								if (Main.netMode == 1)
								{
									if (Main.player[Main.myPlayer].chest == -1)
									{
										Main.playerInventory = true;
										Main.PlaySound(10, -1, -1, 1);
									}
									else if (Main.player[Main.myPlayer].chest != num84 && num84 != -1)
									{
										Main.playerInventory = true;
										Main.PlaySound(12, -1, -1, 1);
									}
									else if (Main.player[Main.myPlayer].chest != -1 && num84 == -1)
									{
										Main.PlaySound(11, -1, -1, 1);
									}
									Main.player[Main.myPlayer].chest = num84;
									Main.player[Main.myPlayer].chestX = chestX;
									Main.player[Main.myPlayer].chestY = chestY;
									return;
								}
								if (num85 != 0)
								{
									int chest = Main.player[this.whoAmI].chest;
									Chest chest2 = Main.chest[chest];
									chest2.name = text4;
									NetMessage.SendData(69, -1, this.whoAmI, text4, chest, (float)chest2.x, (float)chest2.y, 0f, 0);
								}
								Main.player[this.whoAmI].chest = num84;
								return;
							}
							else if (b == 34)
							{
								byte b27 = this.readBuffer[num];
								num++;
								int num86 = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								int num87 = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								short num88 = BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								if (Main.netMode == 2)
								{
									if (b27 == 0)
									{
										int num89 = WorldGen.PlaceChest(num86, num87, 21, false, (int)num88);
										if (num89 == -1)
										{
											NetMessage.SendData(34, this.whoAmI, -1, "", (int)b27, (float)num86, (float)num87, (float)num88, num89);
											Item.NewItem(num86 * 16, num87 * 16, 32, 32, Chest.itemSpawn[(int)num88], 1, true, 0, false);
											return;
										}
										NetMessage.SendData(34, -1, -1, "", (int)b27, (float)num86, (float)num87, (float)num88, num89);
										return;
									}
									else
									{
										Tile tile = Main.tile[num86, num87];
										if (tile.type == 21)
										{
											if (tile.frameX % 36 != 0)
											{
												num86--;
											}
											if (tile.frameY % 36 != 0)
											{
												num87--;
											}
											int number = Chest.FindChest(num86, num87);
											WorldGen.KillTile(num86, num87, false, false, false);
											if (!Main.tile[num86, num87].active())
											{
												NetMessage.SendData(34, -1, -1, "", (int)b27, (float)num86, (float)num87, 0f, number);
												return;
											}
										}
									}
								}
								else
								{
									short num90 = BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									if (b27 != 0)
									{
										Chest.DestroyChestDirect(num86, num87, (int)num90);
										WorldGen.KillTile(num86, num87, false, false, false);
										return;
									}
									if (num90 == -1)
									{
										WorldGen.KillTile(num86, num87, false, false, false);
										return;
									}
									WorldGen.PlaceChestDirect(num86, num87, 21, (int)num88, (int)num90);
									return;
								}
							}
							else if (b == 35)
							{
								int num91 = (int)this.readBuffer[num];
								if (Main.netMode == 2)
								{
									num91 = this.whoAmI;
								}
								num++;
								int num92 = (int)BitConverter.ToInt16(this.readBuffer, num);
								num += 2;
								if (Main.netMode == 2)
								{
									NetMessage.SendData(35, -1, this.whoAmI, "", num91, (float)num92, 0f, 0f, 0);
									return;
								}
							}
							else if (b == 36)
							{
								int num93 = (int)this.readBuffer[num];
								if (Main.netMode == 2)
								{
									num93 = this.whoAmI;
								}
								num++;
								byte b28 = this.readBuffer[num];
								num++;
								if ((b28 & 1) == 1)
								{
									Main.player[num93].zoneEvil = true;
								}
								else
								{
									Main.player[num93].zoneEvil = false;
								}
								if ((b28 & 2) == 2)
								{
									Main.player[num93].zoneMeteor = true;
								}
								else
								{
									Main.player[num93].zoneMeteor = false;
								}
								if ((b28 & 4) == 4)
								{
									Main.player[num93].zoneDungeon = true;
								}
								else
								{
									Main.player[num93].zoneDungeon = false;
								}
								if ((b28 & 8) == 8)
								{
									Main.player[num93].zoneJungle = true;
								}
								else
								{
									Main.player[num93].zoneJungle = false;
								}
								if ((b28 & 16) == 16)
								{
									Main.player[num93].zoneHoly = true;
								}
								else
								{
									Main.player[num93].zoneHoly = false;
								}
								if ((b28 & 32) == 32)
								{
									Main.player[num93].zoneSnow = true;
								}
								else
								{
									Main.player[num93].zoneSnow = false;
								}
								if ((b28 & 64) == 64)
								{
									Main.player[num93].zoneBlood = true;
								}
								else
								{
									Main.player[num93].zoneBlood = false;
								}
								if ((b28 & 128) == 128)
								{
									Main.player[num93].zoneCandle = true;
								}
								else
								{
									Main.player[num93].zoneCandle = false;
								}
								if (Main.netMode == 2)
								{
									NetMessage.SendData(36, -1, this.whoAmI, "", num93, 0f, 0f, 0f, 0);
									return;
								}
							}
							else if (b == 37)
							{
								if (Main.netMode == 1)
								{
									if (Main.autoPass)
									{
										NetMessage.SendData(38, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
										Main.autoPass = false;
										return;
									}
									Netplay.password = "";
									Main.menuMode = 31;
									return;
								}
							}
							else if (b == 38)
							{
								if (Main.netMode == 2)
								{
									string string5 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
									if (string5 == Netplay.password)
									{
										Netplay.serverSock[this.whoAmI].state = 1;
										NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
										return;
									}
									NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0f, 0f, 0f, 0);
									return;
								}
							}
							else
							{
								if (b == 39 && Main.netMode == 1)
								{
									short num94 = BitConverter.ToInt16(this.readBuffer, num);
									Main.item[(int)num94].owner = 255;
									NetMessage.SendData(22, -1, -1, "", (int)num94, 0f, 0f, 0f, 0);
									return;
								}
								if (b == 40)
								{
									byte b29 = this.readBuffer[num];
									if (Main.netMode == 2)
									{
										b29 = (byte)this.whoAmI;
									}
									num++;
									int talkNPC = (int)BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									Main.player[(int)b29].talkNPC = talkNPC;
									if (Main.netMode == 2)
									{
										NetMessage.SendData(40, -1, this.whoAmI, "", (int)b29, 0f, 0f, 0f, 0);
										return;
									}
								}
								else if (b == 41)
								{
									byte b30 = this.readBuffer[num];
									if (Main.netMode == 2)
									{
										b30 = (byte)this.whoAmI;
									}
									num++;
									float itemRotation = BitConverter.ToSingle(this.readBuffer, num);
									num += 4;
									int itemAnimation = (int)BitConverter.ToInt16(this.readBuffer, num);
									Main.player[(int)b30].itemRotation = itemRotation;
									Main.player[(int)b30].itemAnimation = itemAnimation;
									Main.player[(int)b30].channel = Main.player[(int)b30].inventory[Main.player[(int)b30].selectedItem].channel;
									if (Main.netMode == 2)
									{
										NetMessage.SendData(41, -1, this.whoAmI, "", (int)b30, 0f, 0f, 0f, 0);
										return;
									}
								}
								else if (b == 42)
								{
									int num95 = (int)this.readBuffer[num];
									if (Main.netMode == 2)
									{
										num95 = this.whoAmI;
									}
									num++;
									int statMana = (int)BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									int statManaMax = (int)BitConverter.ToInt16(this.readBuffer, num);
									if (Main.netMode == 2)
									{
										num95 = this.whoAmI;
									}
									else if (Main.myPlayer == num95 && !Main.ServerSideCharacter)
									{
										return;
									}
									Main.player[num95].statMana = statMana;
									Main.player[num95].statManaMax = statManaMax;
									if (Main.netMode == 2)
									{
										NetMessage.SendData(42, -1, this.whoAmI, "", num95, 0f, 0f, 0f, 0);
										return;
									}
								}
								else if (b == 43)
								{
									int num96 = (int)this.readBuffer[num];
									if (Main.netMode == 2)
									{
										num96 = this.whoAmI;
									}
									num++;
									int num97 = (int)BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									if (Main.netMode == 2)
									{
										NetMessage.SendData(43, -1, this.whoAmI, "", num96, (float)num97, 0f, 0f, 0);
										return;
									}
								}
								else if (b == 44)
								{
									byte b31 = this.readBuffer[num];
									if ((int)b31 == Main.myPlayer)
									{
										return;
									}
									if (Main.netMode == 2)
									{
										b31 = (byte)this.whoAmI;
									}
									num++;
									int num98 = this.readBuffer[num] - 1;
									num++;
									short num99 = BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									byte b32 = this.readBuffer[num];
									num++;
									string string6 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
									bool pvp2 = false;
									if (b32 != 0)
									{
										pvp2 = true;
									}
									Main.player[(int)b31].KillMe((double)num99, num98, pvp2, string6);
									if (Main.netMode == 2)
									{
										NetMessage.SendData(44, -1, this.whoAmI, string6, (int)b31, (float)num98, (float)num99, (float)b32, 0);
										return;
									}
								}
								else if (b == 45)
								{
									int num100 = (int)this.readBuffer[num];
									if (Main.netMode == 2)
									{
										num100 = this.whoAmI;
									}
									num++;
									int num101 = (int)this.readBuffer[num];
									num++;
									int team = Main.player[num100].team;
									Main.player[num100].team = num101;
									if (Main.netMode == 2)
									{
										NetMessage.SendData(45, -1, this.whoAmI, "", num100, 0f, 0f, 0f, 0);
										string str2 = "";
										if (num101 == 0)
										{
											str2 = " " + Lang.mp[13];
										}
										else if (num101 == 1)
										{
											str2 = " " + Lang.mp[14];
										}
										else if (num101 == 2)
										{
											str2 = " " + Lang.mp[15];
										}
										else if (num101 == 3)
										{
											str2 = " " + Lang.mp[16];
										}
										else if (num101 == 4)
										{
											str2 = " " + Lang.mp[17];
										}
										for (int num102 = 0; num102 < 255; num102++)
										{
											if (num102 == this.whoAmI || (team > 0 && Main.player[num102].team == team) || (num101 > 0 && Main.player[num102].team == num101))
											{
												NetMessage.SendData(25, num102, -1, Main.player[num100].name + str2, 255, (float)Main.teamColor[num101].R, (float)Main.teamColor[num101].G, (float)Main.teamColor[num101].B, 0);
											}
										}
										return;
									}
								}
								else if (b == 46)
								{
									if (Main.netMode == 2)
									{
										int i2 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int j2 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num103 = Sign.ReadSign(i2, j2);
										if (num103 >= 0)
										{
											NetMessage.SendData(47, this.whoAmI, -1, "", num103, 0f, 0f, 0f, 0);
											return;
										}
									}
								}
								else if (b == 47)
								{
									int num104 = (int)BitConverter.ToInt16(this.readBuffer, num);
									num += 2;
									int x9 = BitConverter.ToInt32(this.readBuffer, num);
									num += 4;
									int y8 = BitConverter.ToInt32(this.readBuffer, num);
									num += 4;
									string string7 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
									Main.sign[num104] = new Sign();
									Main.sign[num104].x = x9;
									Main.sign[num104].y = y8;
									Sign.TextSign(num104, string7);
									if (Main.netMode == 1 && Main.sign[num104] != null && num104 != Main.player[Main.myPlayer].sign)
									{
										Main.playerInventory = false;
										Main.player[Main.myPlayer].talkNPC = -1;
										Main.editSign = false;
										Main.PlaySound(10, -1, -1, 1);
										Main.player[Main.myPlayer].sign = num104;
										Main.npcChatText = Main.sign[num104].text;
										return;
									}
								}
								else
								{
									if (b == 48)
									{
										int num105 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num106 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										byte liquid = this.readBuffer[num];
										num++;
										byte liquidType2 = this.readBuffer[num];
										num++;
										if (Main.netMode == 2 && Netplay.spamCheck)
										{
											int num107 = this.whoAmI;
											int num108 = (int)(Main.player[num107].position.X + (float)(Main.player[num107].width / 2));
											int num109 = (int)(Main.player[num107].position.Y + (float)(Main.player[num107].height / 2));
											int num110 = 10;
											int num111 = num108 - num110;
											int num112 = num108 + num110;
											int num113 = num109 - num110;
											int num114 = num109 + num110;
											if (num108 < num111 || num108 > num112 || num109 < num113 || num109 > num114)
											{
												NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
												return;
											}
										}
										if (Main.tile[num105, num106] == null)
										{
											Main.tile[num105, num106] = new Tile();
										}
										lock (Main.tile[num105, num106])
										{
											Main.tile[num105, num106].liquid = liquid;
											Main.tile[num105, num106].liquidType((int)liquidType2);
											if (Main.netMode == 2)
											{
												WorldGen.SquareTileFrame(num105, num106, true);
											}
											return;
										}
									}
									if (b == 49)
									{
										if (Netplay.clientSock.state == 6)
										{
											Netplay.clientSock.state = 10;
											Main.player[Main.myPlayer].Spawn();
											return;
										}
									}
									else if (b == 50)
									{
										int num115 = (int)this.readBuffer[num];
										num++;
										if (Main.netMode == 2)
										{
											num115 = this.whoAmI;
										}
										else if (num115 == Main.myPlayer && !Main.ServerSideCharacter)
										{
											return;
										}
										for (int num116 = 0; num116 < 22; num116++)
										{
											Main.player[num115].buffType[num116] = (int)this.readBuffer[num];
											if (Main.player[num115].buffType[num116] > 0)
											{
												Main.player[num115].buffTime[num116] = 60;
											}
											else
											{
												Main.player[num115].buffTime[num116] = 0;
											}
											num++;
										}
										if (Main.netMode == 2)
										{
											NetMessage.SendData(50, -1, this.whoAmI, "", num115, 0f, 0f, 0f, 0);
											return;
										}
									}
									else if (b == 51)
									{
										byte b33 = this.readBuffer[num];
										num++;
										byte b34 = this.readBuffer[num];
										if (b34 == 1)
										{
											NPC.SpawnSkeletron();
											return;
										}
										if (b34 == 2)
										{
											if (Main.netMode != 2)
											{
												Main.PlaySound(2, (int)Main.player[(int)b33].position.X, (int)Main.player[(int)b33].position.Y, 1);
												return;
											}
											if (Main.netMode == 2)
											{
												NetMessage.SendData(51, -1, this.whoAmI, "", (int)b33, (float)b34, 0f, 0f, 0);
												return;
											}
										}
									}
									else if (b == 52)
									{
										byte number2 = this.readBuffer[num];
										num++;
										byte b35 = this.readBuffer[num];
										num++;
										int num117 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num118 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										if (b35 == 1)
										{
											Chest.Unlock(num117, num118);
											if (Main.netMode == 2)
											{
												NetMessage.SendData(52, -1, this.whoAmI, "", (int)number2, (float)b35, (float)num117, (float)num118, 0);
												NetMessage.SendTileSquare(-1, num117, num118, 2);
											}
										}
										if (b35 == 2)
										{
											WorldGen.UnlockDoor(num117, num118);
											if (Main.netMode == 2)
											{
												NetMessage.SendData(52, -1, this.whoAmI, "", (int)number2, (float)b35, (float)num117, (float)num118, 0);
												NetMessage.SendTileSquare(-1, num117, num118, 2);
												return;
											}
										}
									}
									else if (b == 53)
									{
										short num119 = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										byte type4 = this.readBuffer[num];
										num++;
										short time = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										Main.npc[(int)num119].AddBuff((int)type4, (int)time, true);
										if (Main.netMode == 2)
										{
											NetMessage.SendData(54, -1, -1, "", (int)num119, 0f, 0f, 0f, 0);
											return;
										}
									}
									else if (b == 54)
									{
										if (Main.netMode == 1)
										{
											short num120 = BitConverter.ToInt16(this.readBuffer, num);
											num += 2;
											for (int num121 = 0; num121 < 5; num121++)
											{
												Main.npc[(int)num120].buffType[num121] = (int)this.readBuffer[num];
												num++;
												Main.npc[(int)num120].buffTime[num121] = (int)BitConverter.ToInt16(this.readBuffer, num);
												num += 2;
											}
											return;
										}
									}
									else if (b == 55)
									{
										byte b36 = this.readBuffer[num];
										num++;
										byte b37 = this.readBuffer[num];
										num++;
										short num122 = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										if (Main.netMode == 2 && (int)b36 != this.whoAmI && !Main.pvpBuff[(int)b37])
										{
											return;
										}
										if (Main.netMode == 1 && (int)b36 == Main.myPlayer)
										{
											Main.player[(int)b36].AddBuff((int)b37, (int)num122, true);
											return;
										}
										if (Main.netMode == 2)
										{
											NetMessage.SendData(55, (int)b36, -1, "", (int)b36, (float)b37, (float)num122, 0f, 0);
											return;
										}
									}
									else if (b == 56)
									{
										if (Main.netMode == 1)
										{
											short num123 = BitConverter.ToInt16(this.readBuffer, num);
											if (num123 < 0 || num123 >= 200)
											{
												return;
											}
											num += 2;
											string string8 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
											Main.npc[(int)num123].displayName = string8;
											return;
										}
										else if (Main.netMode == 2)
										{
											short num124 = BitConverter.ToInt16(this.readBuffer, num);
											if (num124 < 0 || num124 >= 200)
											{
												return;
											}
											NetMessage.SendData(56, this.whoAmI, -1, Main.npc[(int)num124].displayName, (int)num124, 0f, 0f, 0f, 0);
											return;
										}
									}
									else if (b == 57)
									{
										if (Main.netMode == 1)
										{
											WorldGen.tGood = this.readBuffer[num];
											num++;
											WorldGen.tEvil = this.readBuffer[num];
											num++;
											WorldGen.tBlood = this.readBuffer[num];
											return;
										}
									}
									else if (b == 58)
									{
										byte b38 = this.readBuffer[num];
										if (Main.netMode == 2)
										{
											b38 = (byte)this.whoAmI;
										}
										num++;
										float num125 = BitConverter.ToSingle(this.readBuffer, num);
										num += 4;
										if (Main.netMode == 2)
										{
											NetMessage.SendData(58, -1, this.whoAmI, "", this.whoAmI, num125, 0f, 0f, 0);
											return;
										}
										Main.harpNote = num125;
										int style9 = 26;
										if (Main.player[(int)b38].inventory[Main.player[(int)b38].selectedItem].type == 507)
										{
											style9 = 35;
										}
										Main.PlaySound(2, (int)Main.player[(int)b38].position.X, (int)Main.player[(int)b38].position.Y, style9);
										return;
									}
									else if (b == 59)
									{
										int num126 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num127 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										WorldGen.hitSwitch(num126, num127);
										if (Main.netMode == 2)
										{
											NetMessage.SendData(59, -1, this.whoAmI, "", num126, (float)num127, 0f, 0f, 0);
											return;
										}
									}
									else if (b == 60)
									{
										short num128 = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										short num129 = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										short num130 = BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										byte b39 = this.readBuffer[num];
										num++;
										if (num128 >= 200)
										{
											NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Invalid kick-out");
											return;
										}
										bool homeless = false;
										if (b39 == 1)
										{
											homeless = true;
										}
										if (Main.netMode == 1)
										{
											Main.npc[(int)num128].homeless = homeless;
											Main.npc[(int)num128].homeTileX = (int)num129;
											Main.npc[(int)num128].homeTileY = (int)num130;
											return;
										}
										if (b39 == 0)
										{
											WorldGen.kickOut((int)num128);
											return;
										}
										WorldGen.moveRoom((int)num129, (int)num130, (int)num128);
										return;
									}
									else if (b == 61)
									{
										int plr = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num131 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										if (Main.netMode == 2)
										{
											if (num131 == 4 || num131 == 13 || num131 == 50 || num131 == 125 || num131 == 126 || num131 == 134 || num131 == 127 || num131 == 128 || num131 == 222 || num131 == 245 || num131 == 266)
											{
												bool flag10 = true;
												for (int num132 = 0; num132 < 200; num132++)
												{
													if (Main.npc[num132].active && Main.npc[num132].type == num131)
													{
														flag10 = false;
													}
												}
												if (flag10)
												{
													NPC.SpawnOnPlayer(plr, num131);
													return;
												}
											}
											else if (num131 == -4)
											{
												if (!Main.dayTime)
												{
													NetMessage.SendData(25, -1, -1, Lang.misc[31], 255, 50f, 255f, 130f, 0);
													Main.startPumpkinMoon();
													NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
													return;
												}
											}
											else if (num131 == -5)
											{
												if (!Main.dayTime)
												{
													NetMessage.SendData(25, -1, -1, Lang.misc[34], 255, 50f, 255f, 130f, 0);
													Main.startSnowMoon();
													NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
													return;
												}
											}
											else if (num131 < 0)
											{
												int num133 = -1;
												if (num131 == -1)
												{
													num133 = 1;
												}
												if (num131 == -2)
												{
													num133 = 2;
												}
												if (num131 == -3)
												{
													num133 = 3;
												}
												if (num133 > 0 && Main.invasionType == 0)
												{
													Main.invasionDelay = 0;
													Main.StartInvasion(num133);
													return;
												}
											}
										}
									}
									else if (b == 62)
									{
										int num134 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num135 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										if (Main.netMode == 2)
										{
											num134 = this.whoAmI;
										}
										if (num135 == 1)
										{
											Main.player[num134].NinjaDodge();
										}
										if (num135 == 2)
										{
											Main.player[num134].ShadowDodge();
										}
										if (Main.netMode == 2)
										{
											NetMessage.SendData(62, -1, this.whoAmI, "", num134, (float)num135, 0f, 0f, 0);
											return;
										}
									}
									else if (b == 63)
									{
										int num136 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num137 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										byte b40 = this.readBuffer[num];
										WorldGen.paintTile(num136, num137, b40, false);
										if (Main.netMode == 2)
										{
											NetMessage.SendData(63, -1, this.whoAmI, "", num136, (float)num137, (float)b40, 0f, 0);
											return;
										}
									}
									else if (b == 64)
									{
										int num138 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										int num139 = BitConverter.ToInt32(this.readBuffer, num);
										num += 4;
										byte b41 = this.readBuffer[num];
										WorldGen.paintWall(num138, num139, b41, false);
										if (Main.netMode == 2)
										{
											NetMessage.SendData(64, -1, this.whoAmI, "", num138, (float)num139, (float)b41, 0f, 0);
											return;
										}
									}
									else if (b == 65)
									{
										byte b42 = this.readBuffer[num];
										num++;
										short num140 = BitConverter.ToInt16(this.readBuffer, num);
										if (Main.netMode == 2)
										{
											num140 = (short)this.whoAmI;
										}
										num += 2;
										Vector2 newPos;
										newPos.X = BitConverter.ToSingle(this.readBuffer, num);
										num += 4;
										newPos.Y = BitConverter.ToSingle(this.readBuffer, num);
										num += 4;
										int num141 = 0;
										int num142 = 0;
										if ((b42 & 1) == 1)
										{
											num141++;
										}
										if ((b42 & 2) == 2)
										{
											num141 += 2;
										}
										if ((b42 & 4) == 4)
										{
											num142++;
										}
										if ((b42 & 8) == 8)
										{
											num142++;
										}
										if (num141 == 0)
										{
											Main.player[(int)num140].Teleport(newPos, num142);
										}
										else if (num141 == 1)
										{
											Main.npc[(int)num140].Teleport(newPos, num142);
										}
										if (Main.netMode == 2 && num141 == 0)
										{
											NetMessage.SendData(65, -1, this.whoAmI, "", 0, (float)num140, newPos.X, newPos.Y, num142);
											return;
										}
									}
									else if (b == 66)
									{
										int num143 = (int)this.readBuffer[num];
										num++;
										int num144 = (int)BitConverter.ToInt16(this.readBuffer, num);
										num += 2;
										if (num144 > 0)
										{
											Main.player[num143].statLife += num144;
											if (Main.player[num143].statLife > Main.player[num143].statLifeMax)
											{
												Main.player[num143].statLife = Main.player[num143].statLifeMax;
											}
											if (Main.netMode == 2)
											{
												NetMessage.SendData(66, -1, this.whoAmI, "", num143, (float)num144, 0f, 0f, 0);
												return;
											}
										}
									}
									else
									{
										if (b == 67)
										{
											return;
										}
										if (b == 68)
										{
											Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
											return;
										}
										if (b == 69)
										{
											short num145 = BitConverter.ToInt16(this.readBuffer, num);
											num += 2;
											short num146 = BitConverter.ToInt16(this.readBuffer, num);
											num += 2;
											short num147 = BitConverter.ToInt16(this.readBuffer, num);
											num += 2;
											if (Main.netMode == 1)
											{
												if (num145 < 0 || num145 >= 1000)
												{
													return;
												}
												Chest chest3 = Main.chest[(int)num145];
												if (chest3 == null)
												{
													chest3 = new Chest(false);
													chest3.x = (int)num146;
													chest3.y = (int)num147;
													Main.chest[(int)num145] = chest3;
												}
												else if (chest3.x != (int)num146 || chest3.y != (int)num147)
												{
													return;
												}
												byte count = this.readBuffer[num];
												num++;
												string string9 = Encoding.UTF8.GetString(this.readBuffer, num, (int)count);
												chest3.name = string9;
												return;
											}
											else
											{
												if (num145 < -1 || num145 >= 1000)
												{
													return;
												}
												if (num145 == -1)
												{
													num145 = (short)Chest.FindChest((int)num146, (int)num147);
													if (num145 == -1)
													{
														return;
													}
												}
												Chest chest4 = Main.chest[(int)num145];
												if (chest4.x != (int)num146 || chest4.y != (int)num147)
												{
													return;
												}
												NetMessage.SendData(69, this.whoAmI, -1, chest4.name, (int)num145, (float)num146, (float)num147, 0f, 0);
												return;
											}
										}
										else if (b == 70)
										{
											if (Main.netMode == 2)
											{
												int i3 = (int)BitConverter.ToInt16(this.readBuffer, num);
												NPC.CatchNPC(i3, -1);
												return;
											}
										}
										else if (b == 71)
										{
											if (Main.netMode == 2)
											{
												int x10 = BitConverter.ToInt32(this.readBuffer, num);
												num += 4;
												int y9 = BitConverter.ToInt32(this.readBuffer, num);
												num += 4;
												short type5 = BitConverter.ToInt16(this.readBuffer, num);
												num += 2;
												byte style10 = this.readBuffer[num];
												num++;
												NPC.ReleaseNPC(x10, y9, (int)type5, (int)style10, this.whoAmI);
												return;
											}
										}
										else if (b == 72 && Main.netMode == 1)
										{
											for (int num148 = 0; num148 < Chest.maxItems; num148++)
											{
												Main.travelShop[num148] = (int)BitConverter.ToInt16(this.readBuffer, num);
												num += 2;
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
}
