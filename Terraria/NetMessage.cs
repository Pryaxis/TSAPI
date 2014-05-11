using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using TerrariaApi.Server;
namespace Terraria
{
	public class NetMessage
	{
		public static MessageBuffer[] buffer = new MessageBuffer[257];
		public static void SendBytes(ServerSock sock, byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            try
            {
	            if (ServerApi.Hooks.InvokeNetSendBytes(sock, buffer, offset, count))
	            {
		            return;
	            }
				if (Main.runningMono)
					sock.networkStream.Write(buffer, offset, count);
				else
					sock.networkStream.BeginWrite(buffer, offset, count, callback, state);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} had an exception thrown when trying to send data.", sock.tcpClient.Client.RemoteEndPoint);
                Console.WriteLine(e);
                sock.kill = true;
            }
        }
		public static void SendData(int msgType, int remoteClient = -1, int ignoreClient = -1, string text = "", int number = 0, float number2 = 0f, float number3 = 0f, float number4 = 0f, int number5 = 0)
		{
			if (Main.netMode == 0)
			{
				return;
			}
			int num = 256;
			if (Main.netMode == 2 && remoteClient >= 0)
			{
				num = remoteClient;
			}
			if (!ServerApi.Hooks.InvokeNetSendData(ref msgType, ref remoteClient, ref ignoreClient, ref text, ref number,
				ref number2, ref number3, ref number4, ref number5))
			{
				lock (NetMessage.buffer[num].writeBuffer)
				{
					MemoryStream output = new MemoryStream(NetMessage.buffer[num].writeBuffer);
					BinaryWriter binaryWriter = new BinaryWriter(output);
					long position = binaryWriter.BaseStream.Position;
					binaryWriter.BaseStream.Position += 2L;
					binaryWriter.Write((byte)msgType);
					switch (msgType)
					{
						case 1:
							binaryWriter.Write("Terraria" + Main.curRelease);
							break;
						case 2:
							binaryWriter.Write(text);
							if (Main.dedServ)
							{
								Console.WriteLine(Netplay.serverSock[num].tcpClient.Client.RemoteEndPoint.ToString() + " was booted: " + text);
							}
							break;
						case 3:
							binaryWriter.Write((byte)remoteClient);
							break;
						case 4:
							{
								Player player = Main.player[number];
								binaryWriter.Write((byte)number);
								binaryWriter.Write((byte)(player.male ? 0 : 1));
								binaryWriter.Write((byte)player.hair);
								binaryWriter.Write(text);
								binaryWriter.Write(player.hairDye);
								binaryWriter.Write(player.hideVisual);
								binaryWriter.WriteRGB(player.hairColor);
								binaryWriter.WriteRGB(player.skinColor);
								binaryWriter.WriteRGB(player.eyeColor);
								binaryWriter.WriteRGB(player.shirtColor);
								binaryWriter.WriteRGB(player.underShirtColor);
								binaryWriter.WriteRGB(player.pantsColor);
								binaryWriter.WriteRGB(player.shoeColor);
								binaryWriter.Write(player.difficulty);
								break;
							}
						case 5:
							{
								binaryWriter.Write((byte)number);
								binaryWriter.Write((byte)number2);
								Player player2 = Main.player[number];
								Item item;
								if (number2 < 59f)
								{
									item = player2.inventory[(int)number2];
								}
								else if (number2 >= 75f && number2 <= 82f)
								{
									item = player2.dye[(int)number2 - 58 - 17];
								}
								else
								{
									item = player2.armor[(int)number2 - 58 - 1];
								}
								if (item.name == "" || item.stack == 0 || item.type == 0)
								{
									item.SetDefaults(0, false);
								}
								int num2 = item.stack;
								int netID = item.netID;
								if (num2 < 0)
								{
									num2 = 0;
								}
								binaryWriter.Write((short)num2);
								binaryWriter.Write((byte)number3);
								binaryWriter.Write((short)netID);
								break;
							}
						case 7:
							{
								binaryWriter.Write((int)Main.time);
								BitsByte bb = 0;
								bb[0] = Main.dayTime;
								bb[1] = Main.bloodMoon;
								bb[2] = Main.eclipse;
								binaryWriter.Write(bb);
								binaryWriter.Write((byte)Main.moonPhase);
								binaryWriter.Write((short)Main.maxTilesX);
								binaryWriter.Write((short)Main.maxTilesY);
								binaryWriter.Write((short)Main.spawnTileX);
								binaryWriter.Write((short)Main.spawnTileY);
								binaryWriter.Write((short)Main.worldSurface);
								binaryWriter.Write((short)Main.rockLayer);
								binaryWriter.Write(Main.worldID);
								binaryWriter.Write(Main.worldName);
								binaryWriter.Write((byte)Main.moonType);
								binaryWriter.Write((byte)WorldGen.treeBG);
								binaryWriter.Write((byte)WorldGen.corruptBG);
								binaryWriter.Write((byte)WorldGen.jungleBG);
								binaryWriter.Write((byte)WorldGen.snowBG);
								binaryWriter.Write((byte)WorldGen.hallowBG);
								binaryWriter.Write((byte)WorldGen.crimsonBG);
								binaryWriter.Write((byte)WorldGen.desertBG);
								binaryWriter.Write((byte)WorldGen.oceanBG);
								binaryWriter.Write((byte)Main.iceBackStyle);
								binaryWriter.Write((byte)Main.jungleBackStyle);
								binaryWriter.Write((byte)Main.hellBackStyle);
								binaryWriter.Write(Main.windSpeedSet);
								binaryWriter.Write((byte)Main.numClouds);
								for (int i = 0; i < 3; i++)
								{
									binaryWriter.Write(Main.treeX[i]);
								}
								for (int j = 0; j < 4; j++)
								{
									binaryWriter.Write((byte)Main.treeStyle[j]);
								}
								for (int k = 0; k < 3; k++)
								{
									binaryWriter.Write(Main.caveBackX[k]);
								}
								for (int l = 0; l < 4; l++)
								{
									binaryWriter.Write((byte)Main.caveBackStyle[l]);
								}
								if (!Main.raining)
								{
									Main.maxRaining = 0f;
								}
								binaryWriter.Write(Main.maxRaining);
								BitsByte bb2 = 0;
								bb2[0] = WorldGen.shadowOrbSmashed;
								bb2[1] = NPC.downedBoss1;
								bb2[2] = NPC.downedBoss2;
								bb2[3] = NPC.downedBoss3;
								bb2[4] = Main.hardMode;
								bb2[5] = NPC.downedClown;
								bb2[7] = NPC.downedPlantBoss;
								binaryWriter.Write(bb2);
								BitsByte bb3 = 0;
								bb3[0] = NPC.downedMechBoss1;
								bb3[1] = NPC.downedMechBoss2;
								bb3[2] = NPC.downedMechBoss3;
								bb3[3] = NPC.downedMechBossAny;
								bb3[4] = (Main.cloudBGActive >= 1f);
								bb3[5] = WorldGen.crimson;
								bb3[6] = Main.pumpkinMoon;
								bb3[7] = Main.snowMoon;
								binaryWriter.Write(bb3);
								break;
							}
						case 8:
							binaryWriter.Write(number);
							binaryWriter.Write((int)number2);
							break;
						case 9:
							binaryWriter.Write(number);
							binaryWriter.Write(text);
							break;
						case 10:
							{
								int num3 = NetMessage.CompressTileBlock(number, (int)number2, (short)number3, (short)number4, NetMessage.buffer[num].writeBuffer, (int)binaryWriter.BaseStream.Position, true);
								binaryWriter.BaseStream.Position += (long)num3;
								break;
							}
						case 11:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((short)number4);
							break;
						case 12:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)Main.player[number].SpawnX);
							binaryWriter.Write((short)Main.player[number].SpawnY);
							break;
						case 13:
							{
								Player player3 = Main.player[number];
								binaryWriter.Write((byte)number);
								BitsByte bb4 = 0;
								bb4[0] = player3.controlUp;
								bb4[1] = player3.controlDown;
								bb4[2] = player3.controlLeft;
								bb4[3] = player3.controlRight;
								bb4[4] = player3.controlJump;
								bb4[5] = player3.controlUseItem;
								bb4[6] = (player3.direction == 1);
								binaryWriter.Write(bb4);
								BitsByte bb5 = 0;
								bb5[0] = player3.pulley;
								bb5[1] = (player3.pulley && player3.pulleyDir == 2);
								bb5[2] = (player3.velocity != Vector2.Zero);
								binaryWriter.Write(bb5);
								binaryWriter.Write((byte)player3.selectedItem);
								binaryWriter.WriteVector2(player3.position);
								binaryWriter.WriteVector2(player3.velocity);
								break;
							}
						case 14:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)number2);
							break;
						case 16:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)Main.player[number].statLife);
							binaryWriter.Write((short)Main.player[number].statLifeMax);
							break;
						case 17:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((short)number4);
							binaryWriter.Write((byte)number5);
							break;
						case 18:
							binaryWriter.Write((byte)(Main.dayTime ? 1 : 0));
							binaryWriter.Write((int)Main.time);
							binaryWriter.Write(Main.sunModY);
							binaryWriter.Write(Main.moonModY);
							break;
						case 19:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((byte)((number4 == 1f) ? 1 : 0));
							break;
						case 20:
							{
								int num4 = (int)number2;
								int num5 = (int)number3;
								binaryWriter.Write((short)number);
								binaryWriter.Write((short)num4);
								binaryWriter.Write((short)num5);
								for (int m = num4; m < num4 + number; m++)
								{
									for (int n = num5; n < num5 + number; n++)
									{
										BitsByte bb6 = 0;
										BitsByte bb7 = 0;
										byte b = 0;
										byte b2 = 0;
										Tile tile = Main.tile[m, n];
										bb6[0] = tile.active();
										bb6[2] = (tile.wall > 0);
										bb6[3] = (tile.liquid > 0 && Main.netMode == 2);
										bb6[4] = tile.wire();
										bb6[5] = tile.halfBrick();
										bb6[6] = tile.actuator();
										bb6[7] = tile.inActive();
										bb7[0] = tile.wire2();
										bb7[1] = tile.wire3();
										if (tile.active() && tile.color() > 0)
										{
											bb7[2] = true;
											b = tile.color();
										}
										if (tile.wall > 0 && tile.wallColor() > 0)
										{
											bb7[3] = true;
											b2 = tile.wallColor();
										}
										bb7 += (byte)(tile.slope() << 4);
										binaryWriter.Write(bb6);
										binaryWriter.Write(bb7);
										if (b > 0)
										{
											binaryWriter.Write(b);
										}
										if (b2 > 0)
										{
											binaryWriter.Write(b2);
										}
										if (tile.active())
										{
											binaryWriter.Write(tile.type);
											if (Main.tileFrameImportant[(int)tile.type])
											{
												binaryWriter.Write(tile.frameX);
												binaryWriter.Write(tile.frameY);
											}
										}
										if (tile.wall > 0)
										{
											binaryWriter.Write(tile.wall);
										}
										if (tile.liquid > 0 && Main.netMode == 2)
										{
											binaryWriter.Write(tile.liquid);
											binaryWriter.Write(tile.liquidType());
										}
									}
								}
								break;
							}
						case 21:
							{
								Item item2 = Main.item[number];
								binaryWriter.Write((short)number);
								binaryWriter.WriteVector2(item2.position);
								binaryWriter.WriteVector2(item2.velocity);
								binaryWriter.Write((short)item2.stack);
								binaryWriter.Write(item2.prefix);
								binaryWriter.Write((byte)number2);
								short value = 0;
								if (item2.active && item2.stack > 0)
								{
									value = (short)item2.netID;
								}
								binaryWriter.Write(value);
								break;
							}
						case 22:
							binaryWriter.Write((short)number);
							binaryWriter.Write((byte)Main.item[number].owner);
							break;
						case 23:
							{
								NPC nPC = Main.npc[number];
								binaryWriter.Write((short)number);
								binaryWriter.WriteVector2(nPC.position);
								binaryWriter.WriteVector2(nPC.velocity);
								binaryWriter.Write((byte)nPC.target);
								int num6 = nPC.life;
								if (!nPC.active)
								{
									num6 = 0;
								}
								if (!nPC.active || nPC.life <= 0)
								{
									nPC.netSkip = 0;
								}
								if (nPC.name == null)
								{
									nPC.name = "";
								}
								short value2 = (short)nPC.netID;
								bool[] array = new bool[4];
								BitsByte bb8 = 0;
								bb8[0] = (nPC.direction > 0);
								bb8[1] = (nPC.directionY > 0);
								bb8[2] = (array[0] = (nPC.ai[0] != 0f));
								bb8[3] = (array[1] = (nPC.ai[1] != 0f));
								bb8[4] = (array[2] = (nPC.ai[2] != 0f));
								bb8[5] = (array[3] = (nPC.ai[3] != 0f));
								bb8[6] = (nPC.spriteDirection > 0);
								bb8[7] = (num6 == nPC.lifeMax);
								binaryWriter.Write(bb8);
								for (int num7 = 0; num7 < NPC.maxAI; num7++)
								{
									if (array[num7])
									{
										binaryWriter.Write(nPC.ai[num7]);
									}
								}
								binaryWriter.Write(value2);
								if (!bb8[7])
								{
									if (Main.npcLifeBytes[nPC.netID] == 2)
									{
										binaryWriter.Write((short)num6);
									}
									else if (Main.npcLifeBytes[nPC.netID] == 4)
									{
										binaryWriter.Write(num6);
									}
									else
									{
										binaryWriter.Write((sbyte)num6);
									}
								}
								if (Main.npcCatchable[nPC.type])
								{
									binaryWriter.Write((byte)nPC.releaseOwner);
								}
								break;
							}
						case 24:
							binaryWriter.Write((short)number);
							binaryWriter.Write((byte)number2);
							break;
						case 25:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)number2);
							binaryWriter.Write((byte)number3);
							binaryWriter.Write((byte)number4);
							binaryWriter.Write(text);
							break;
						case 26:
							{
								binaryWriter.Write((byte)number);
								binaryWriter.Write((byte)(number2 + 1f));
								binaryWriter.Write((short)number3);
								binaryWriter.Write(text);
								BitsByte bb9 = 0;
								bb9[0] = (number4 == 1f);
								bb9[1] = (number5 == 1);
								binaryWriter.Write(bb9);
								break;
							}
						case 27:
							{
								Projectile projectile = Main.projectile[number];
								binaryWriter.Write((short)projectile.identity);
								binaryWriter.WriteVector2(projectile.position);
								binaryWriter.WriteVector2(projectile.velocity);
								binaryWriter.Write(projectile.knockBack);
								binaryWriter.Write((short)projectile.damage);
								binaryWriter.Write((byte)projectile.owner);
								binaryWriter.Write((short)projectile.type);
								BitsByte bb10 = 0;
								for (int num8 = 0; num8 < Projectile.maxAI; num8++)
								{
									if (projectile.ai[num8] != 0f)
									{
										bb10[num8] = true;
									}
								}
								binaryWriter.Write(bb10);
								for (int num9 = 0; num9 < Projectile.maxAI; num9++)
								{
									if (bb10[num9])
									{
										binaryWriter.Write(projectile.ai[num9]);
									}
								}
								break;
							}
						case 28:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write(number3);
							binaryWriter.Write((byte)(number4 + 1f));
							binaryWriter.Write((byte)number5);
							break;
						case 29:
							binaryWriter.Write((short)number);
							binaryWriter.Write((byte)number2);
							break;
						case 30:
							binaryWriter.Write((byte)number);
							binaryWriter.Write(Main.player[number].hostile);
							break;
						case 31:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							break;
						case 32:
							{
								Item item3 = Main.chest[number].item[(int)((byte)number2)];
								binaryWriter.Write((short)number);
								binaryWriter.Write((byte)number2);
								short value3 = (short)item3.netID;
								if (item3.name == null)
								{
									value3 = 0;
								}
								binaryWriter.Write((short)item3.stack);
								binaryWriter.Write(item3.prefix);
								binaryWriter.Write(value3);
								break;
							}
						case 33:
							{
								int num10 = 0;
								int num11 = 0;
								int num12 = 0;
								string text2 = null;
								if (number > -1)
								{
									num10 = Main.chest[number].x;
									num11 = Main.chest[number].y;
								}
								if (number2 == 1f)
								{
									num12 = (int)((byte)text.Length);
									if (num12 == 0 || num12 > 20)
									{
										num12 = 255;
									}
									else
									{
										text2 = text;
									}
								}
								binaryWriter.Write((short)number);
								binaryWriter.Write((short)num10);
								binaryWriter.Write((short)num11);
								binaryWriter.Write((byte)num12);
								if (text2 != null)
								{
									binaryWriter.Write(text2);
								}
								break;
							}
						case 34:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((short)number4);
							if (Main.netMode == 2)
							{
								Netplay.GetSectionX((int)number2);
								Netplay.GetSectionY((int)number3);
								binaryWriter.Write((short)number5);
							}
							break;
						case 35:
						case 66:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)number2);
							break;
						case 36:
							{
								Player player4 = Main.player[number];
								binaryWriter.Write((byte)number);
								BitsByte bb11 = 0;
								bb11[0] = player4.zoneEvil;
								bb11[1] = player4.zoneMeteor;
								bb11[2] = player4.zoneDungeon;
								bb11[3] = player4.zoneJungle;
								bb11[4] = player4.zoneHoly;
								bb11[5] = player4.zoneSnow;
								bb11[6] = player4.zoneBlood;
								bb11[7] = player4.zoneCandle;
								binaryWriter.Write(bb11);
								break;
							}
						case 38:
							binaryWriter.Write(text);
							break;
						case 39:
							binaryWriter.Write((short)number);
							break;
						case 40:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)Main.player[number].talkNPC);
							break;
						case 41:
							binaryWriter.Write((byte)number);
							binaryWriter.Write(Main.player[number].itemRotation);
							binaryWriter.Write((short)Main.player[number].itemAnimation);
							break;
						case 42:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)Main.player[number].statMana);
							binaryWriter.Write((short)Main.player[number].statManaMax);
							break;
						case 43:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((short)number2);
							break;
						case 44:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)(number2 + 1f));
							binaryWriter.Write((short)number3);
							binaryWriter.Write((byte)number4);
							binaryWriter.Write(text);
							break;
						case 45:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)Main.player[number].team);
							break;
						case 46:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							break;
						case 47:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)Main.sign[number].x);
							binaryWriter.Write((short)Main.sign[number].y);
							binaryWriter.Write(Main.sign[number].text);
							break;
						case 48:
							{
								Tile tile2 = Main.tile[number, (int)number2];
								binaryWriter.Write((short)number);
								binaryWriter.Write((short)number2);
								binaryWriter.Write(tile2.liquid);
								binaryWriter.Write(tile2.liquidType());
								break;
							}
						case 50:
							binaryWriter.Write((byte)number);
							for (int num13 = 0; num13 < 22; num13++)
							{
								binaryWriter.Write((byte)Main.player[number].buffType[num13]);
							}
							break;
						case 51:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)number2);
							break;
						case 52:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((short)number4);
							break;
						case 53:
							binaryWriter.Write((short)number);
							binaryWriter.Write((byte)number2);
							binaryWriter.Write((short)number3);
							break;
						case 54:
							binaryWriter.Write((short)number);
							for (int num14 = 0; num14 < 5; num14++)
							{
								binaryWriter.Write((byte)Main.npc[number].buffType[num14]);
								binaryWriter.Write((short)Main.npc[number].buffTime[num14]);
							}
							break;
						case 55:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)number2);
							binaryWriter.Write((short)number3);
							break;
						case 56:
							{
								string value4 = null;
								if (Main.netMode == 2)
								{
									value4 = Main.npc[number].displayName;
								}
								else if (Main.netMode == 1)
								{
									value4 = text;
								}
								binaryWriter.Write((short)number);
								binaryWriter.Write(value4);
								break;
							}
						case 57:
							binaryWriter.Write(WorldGen.tGood);
							binaryWriter.Write(WorldGen.tEvil);
							binaryWriter.Write(WorldGen.tBlood);
							break;
						case 58:
							binaryWriter.Write((byte)number);
							binaryWriter.Write(number2);
							break;
						case 59:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							break;
						case 60:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((byte)number4);
							break;
						case 61:
							binaryWriter.Write(number);
							binaryWriter.Write((int)number2);
							break;
						case 62:
							binaryWriter.Write((byte)number);
							binaryWriter.Write((byte)number2);
							break;
						case 63:
						case 64:
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((byte)number3);
							break;
						case 65:
							{
								BitsByte bb12 = 0;
								bb12[0] = ((number & 1) == 1);
								bb12[1] = ((number & 2) == 2);
								bb12[2] = ((number5 & 1) == 1);
								bb12[3] = ((number5 & 2) == 2);
								binaryWriter.Write(bb12);
								binaryWriter.Write((short)number2);
								binaryWriter.Write(number3);
								binaryWriter.Write(number4);
								break;
							}
						case 68:
							binaryWriter.Write(Main.clientUUID);
							break;
						case 69:
							Netplay.GetSectionX((int)number2);
							Netplay.GetSectionY((int)number3);
							binaryWriter.Write((short)number);
							binaryWriter.Write((short)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write(text);
							break;
						case 70:
							binaryWriter.Write((short)number);
							binaryWriter.Write((byte)number2);
							break;
						case 71:
							binaryWriter.Write(number);
							binaryWriter.Write((int)number2);
							binaryWriter.Write((short)number3);
							binaryWriter.Write((byte)number4);
							break;
						case 72:
							for (int num15 = 0; num15 < Chest.maxItems; num15++)
							{
								binaryWriter.Write((short)Main.travelShop[num15]);
							}
							break;
						case 74:
							{
								binaryWriter.Write((byte)Main.anglerQuest);
								bool value5 = Main.anglerWhoFinishedToday.Contains(text);
								binaryWriter.Write(value5);
								break;
							}
						case 76:
							binaryWriter.Write((byte)number);
							binaryWriter.Write(Main.player[number].anglerQuestsFinished);
							break;
					}
					int num16 = (int)binaryWriter.BaseStream.Position;
					binaryWriter.BaseStream.Position = position;
					binaryWriter.Write((short)num16);
					binaryWriter.BaseStream.Position = (long)num16;
					if (Main.netMode == 1)
					{
						if (!Netplay.clientSock.tcpClient.Connected)
						{
							goto IL_22E9;
						}
						try
						{
							NetMessage.buffer[num].spamCount++;
							Main.txMsg++;
							Main.txData += num16;
							Main.txMsgType[msgType]++;
							Main.txDataType[msgType] += num16;
							Netplay.clientSock.networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.clientSock.ClientWriteCallBack), Netplay.clientSock.networkStream);
							goto IL_22E9;
						}
						catch
						{
							goto IL_22E9;
						}
					}
					if (remoteClient == -1)
					{
						if (msgType == 34 || msgType == 69)
						{
							for (int num17 = 0; num17 < 256; num17++)
							{
								if (num17 != ignoreClient && NetMessage.buffer[num17].broadcast && Netplay.serverSock[num17].tcpClient.Connected)
								{
									try
									{
										NetMessage.buffer[num17].spamCount++;
										Main.txMsg++;
										Main.txData += num16;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num16;
										Netplay.serverSock[num17].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num17].ServerWriteCallBack), Netplay.serverSock[num17].networkStream);
									}
									catch
									{
									}
								}
							}
						}
						else if (msgType == 20)
						{
							for (int num18 = 0; num18 < 256; num18++)
							{
								if (num18 != ignoreClient && NetMessage.buffer[num18].broadcast && Netplay.serverSock[num18].tcpClient.Connected && Netplay.serverSock[num18].SectionRange(number, (int)number2, (int)number3))
								{
									try
									{
										NetMessage.buffer[num18].spamCount++;
										Main.txMsg++;
										Main.txData += num16;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num16;
										Netplay.serverSock[num18].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num18].ServerWriteCallBack), Netplay.serverSock[num18].networkStream);
									}
									catch
									{
									}
								}
							}
						}
						else if (msgType == 23)
						{
							NPC nPC2 = Main.npc[number];
							for (int num19 = 0; num19 < 256; num19++)
							{
								if (num19 != ignoreClient && NetMessage.buffer[num19].broadcast && Netplay.serverSock[num19].tcpClient.Connected)
								{
									bool flag2 = false;
									if (nPC2.boss || nPC2.netAlways || nPC2.townNPC || !nPC2.active)
									{
										flag2 = true;
									}
									else if (nPC2.netSkip <= 0)
									{
										Rectangle rect = Main.player[num19].getRect();
										Rectangle rect2 = nPC2.getRect();
										rect2.X -= 2500;
										rect2.Y -= 2500;
										rect2.Width += 5000;
										rect2.Height += 5000;
										if (rect.Intersects(rect2))
										{
											flag2 = true;
										}
									}
									else
									{
										flag2 = true;
									}
									if (flag2)
									{
										try
										{
											NetMessage.buffer[num19].spamCount++;
											Main.txMsg++;
											Main.txData += num16;
											Main.txMsgType[msgType]++;
											Main.txDataType[msgType] += num16;
											Netplay.serverSock[num19].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num19].ServerWriteCallBack), Netplay.serverSock[num19].networkStream);
										}
										catch
										{
										}
									}
								}
							}
							nPC2.netSkip++;
							if (nPC2.netSkip > 4)
							{
								nPC2.netSkip = 0;
							}
						}
						else if (msgType == 28)
						{
							NPC nPC3 = Main.npc[number];
							for (int num20 = 0; num20 < 256; num20++)
							{
								if (num20 != ignoreClient && NetMessage.buffer[num20].broadcast && Netplay.serverSock[num20].tcpClient.Connected)
								{
									bool flag3 = false;
									if (nPC3.life <= 0)
									{
										flag3 = true;
									}
									else
									{
										Rectangle rect3 = Main.player[num20].getRect();
										Rectangle rect4 = nPC3.getRect();
										rect4.X -= 3000;
										rect4.Y -= 3000;
										rect4.Width += 6000;
										rect4.Height += 6000;
										if (rect3.Intersects(rect4))
										{
											flag3 = true;
										}
									}
									if (flag3)
									{
										try
										{
											NetMessage.buffer[num20].spamCount++;
											Main.txMsg++;
											Main.txData += num16;
											Main.txMsgType[msgType]++;
											Main.txDataType[msgType] += num16;
											Netplay.serverSock[num20].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num20].ServerWriteCallBack), Netplay.serverSock[num20].networkStream);
										}
										catch
										{
										}
									}
								}
							}
						}
						else if (msgType == 13)
						{
							for (int num21 = 0; num21 < 256; num21++)
							{
								if (num21 != ignoreClient && NetMessage.buffer[num21].broadcast && Netplay.serverSock[num21].tcpClient.Connected)
								{
									try
									{
										NetMessage.buffer[num21].spamCount++;
										Main.txMsg++;
										Main.txData += num16;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num16;
										Netplay.serverSock[num21].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num21].ServerWriteCallBack), Netplay.serverSock[num21].networkStream);
									}
									catch
									{
									}
								}
							}
							Main.player[number].netSkip++;
							if (Main.player[number].netSkip > 2)
							{
								Main.player[number].netSkip = 0;
							}
						}
						else if (msgType == 27)
						{
							Projectile projectile2 = Main.projectile[number];
							for (int num22 = 0; num22 < 256; num22++)
							{
								if (num22 != ignoreClient && NetMessage.buffer[num22].broadcast && Netplay.serverSock[num22].tcpClient.Connected)
								{
									bool flag4 = false;
									if (projectile2.type == 12 || Main.projPet[projectile2.type] || projectile2.aiStyle == 11 || projectile2.netImportant)
									{
										flag4 = true;
									}
									else
									{
										Rectangle rect5 = Main.player[num22].getRect();
										Rectangle rect6 = projectile2.getRect();
										rect6.X -= 5000;
										rect6.Y -= 5000;
										rect6.Width += 10000;
										rect6.Height += 10000;
										if (rect5.Intersects(rect6))
										{
											flag4 = true;
										}
									}
									if (flag4)
									{
										try
										{
											NetMessage.buffer[num22].spamCount++;
											Main.txMsg++;
											Main.txData += num16;
											Main.txMsgType[msgType]++;
											Main.txDataType[msgType] += num16;
											Netplay.serverSock[num22].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num22].ServerWriteCallBack), Netplay.serverSock[num22].networkStream);
										}
										catch
										{
										}
									}
								}
							}
						}
						else
						{
							for (int num23 = 0; num23 < 256; num23++)
							{
								if (num23 != ignoreClient && (NetMessage.buffer[num23].broadcast || (Netplay.serverSock[num23].state >= 3 && msgType == 10)) && Netplay.serverSock[num23].tcpClient.Connected)
								{
									try
									{
										NetMessage.buffer[num23].spamCount++;
										Main.txMsg++;
										Main.txData += num16;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num16;
										Netplay.serverSock[num23].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[num23].ServerWriteCallBack), Netplay.serverSock[num23].networkStream);
									}
									catch
									{
									}
								}
							}
						}
					}
					else if (Netplay.serverSock[remoteClient].tcpClient.Connected)
					{
						try
						{
							NetMessage.buffer[remoteClient].spamCount++;
							Main.txMsg++;
							Main.txData += num16;
							Main.txMsgType[msgType]++;
							Main.txDataType[msgType] += num16;
							Netplay.serverSock[remoteClient].networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num16, new AsyncCallback(Netplay.serverSock[remoteClient].ServerWriteCallBack), Netplay.serverSock[remoteClient].networkStream);
						}
						catch
						{
						}
					}
				IL_22E9:
					if (Main.verboseNetplay)
					{
						for (int num24 = 0; num24 < num16; num24++)
						{
						}
						for (int num25 = 0; num25 < num16; num25++)
						{
							byte arg_2315_0 = NetMessage.buffer[num].writeBuffer[num25];
						}
					}
					NetMessage.buffer[num].writeLocked = false;
					if (msgType == 19 && Main.netMode == 1)
					{
						NetMessage.SendTileSquare(num, (int)number2, (int)number3, 5);
					}
					if (msgType == 2 && Main.netMode == 2)
					{
						Netplay.serverSock[num].kill = true;
					}
				}
			}
		}
		public static int CompressTileBlock(int xStart, int yStart, short width, short height, byte[] buffer, int bufferStart, bool packChests)
		{
			int result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(xStart);
					binaryWriter.Write(yStart);
					binaryWriter.Write(width);
					binaryWriter.Write(height);
					NetMessage.CompressTileBlock_Inner(binaryWriter, xStart, yStart, (int)width, (int)height, packChests);
					int num = buffer.Length;
					if ((long)bufferStart + memoryStream.Length > (long)num)
					{
						result = (int)((long)(num - bufferStart) + memoryStream.Length);
					}
					else
					{
						memoryStream.Position = 0L;
						MemoryStream memoryStream2 = new MemoryStream();
						using (DeflateStream deflateStream = new DeflateStream(memoryStream2, CompressionMode.Compress, true))
						{
							memoryStream.CopyTo(deflateStream);
							deflateStream.Flush();
							deflateStream.Close();
							deflateStream.Dispose();
						}
						if (memoryStream.Length <= memoryStream2.Length)
						{
							memoryStream.Position = 0L;
							buffer[bufferStart] = 0;
							bufferStart++;
							memoryStream.Read(buffer, bufferStart, (int)memoryStream.Length);
							result = (int)memoryStream.Length + 1;
						}
						else
						{
							memoryStream2.Position = 0L;
							buffer[bufferStart] = 1;
							bufferStart++;
							memoryStream2.Read(buffer, bufferStart, (int)memoryStream2.Length);
							result = (int)memoryStream2.Length + 1;
						}
					}
				}
			}
			return result;
		}
		public static void CompressTileBlock_Inner(BinaryWriter writer, int xStart, int yStart, int width, int height, bool packChests)
		{
			short[] array = null;
			short num = 0;
			if (packChests)
			{
				array = new short[1000];
			}
			short num2 = 0;
			int num3 = 0;
			int num4 = 0;
			byte b = 0;
			byte[] array2 = new byte[13];
			Tile tile = null;
			for (int i = yStart; i < yStart + height; i++)
			{
				for (int j = xStart; j < xStart + width; j++)
				{
					Tile tile2 = Main.tile[j, i];
					if (tile2.isTheSameAs(tile))
					{
						num2 += 1;
					}
					else
					{
						if (tile != null)
						{
							if (num2 > 0)
							{
								array2[num3] = (byte)(num2 & 255);
								num3++;
								if (num2 > 255)
								{
									b |= 128;
									array2[num3] = (byte)(((int)num2 & 65280) >> 8);
									num3++;
								}
								else
								{
									b |= 64;
								}
							}
							array2[num4] = b;
							writer.Write(array2, num4, num3 - num4);
							num2 = 0;
						}
						num3 = 3;
						byte b3;
						byte b2 = b = (b3 = 0);
						if (tile2.active())
						{
							b |= 2;
							array2[num3] = (byte)tile2.type;
							num3++;
							if (tile2.type > 255)
							{
								array2[num3] = (byte)(tile2.type >> 8);
								num3++;
								b |= 32;
							}
							if (tile2.type == 21 && packChests && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
							{
								short num5 = (short)Chest.FindChest(j, i);
								if (num5 != -1)
								{
									array[(int)num] = num5;
									num += 1;
								}
							}
							if (Main.tileFrameImportant[(int)tile2.type])
							{
								array2[num3] = (byte)(tile2.frameX & 255);
								num3++;
								array2[num3] = (byte)(((int)tile2.frameX & 65280) >> 8);
								num3++;
								array2[num3] = (byte)(tile2.frameY & 255);
								num3++;
								array2[num3] = (byte)(((int)tile2.frameY & 65280) >> 8);
								num3++;
							}
							if (tile2.color() != 0)
							{
								b3 |= 8;
								array2[num3] = tile2.color();
								num3++;
							}
						}
						if (tile2.wall != 0)
						{
							b |= 4;
							array2[num3] = tile2.wall;
							num3++;
							if (tile2.wallColor() != 0)
							{
								b3 |= 16;
								array2[num3] = tile2.wallColor();
								num3++;
							}
						}
						if (tile2.liquid != 0)
						{
							if (tile2.lava())
							{
								b |= 16;
							}
							else if (tile2.honey())
							{
								b |= 24;
							}
							else
							{
								b |= 8;
							}
							array2[num3] = tile2.liquid;
							num3++;
						}
						if (tile2.wire())
						{
							b2 |= 2;
						}
						if (tile2.wire2())
						{
							b2 |= 4;
						}
						if (tile2.wire3())
						{
							b2 |= 8;
						}
						int num6;
						if (tile2.halfBrick())
						{
							num6 = 16;
						}
						else if (tile2.slope() != 0)
						{
							num6 = (int)(tile2.slope() + 1) << 4;
						}
						else
						{
							num6 = 0;
						}
						b2 |= (byte)num6;
						if (tile2.actuator())
						{
							b3 |= 2;
						}
						if (tile2.inActive())
						{
							b3 |= 4;
						}
						num4 = 2;
						if (b3 != 0)
						{
							b2 |= 1;
							array2[num4] = b3;
							num4--;
						}
						if (b2 != 0)
						{
							b |= 1;
							array2[num4] = b2;
							num4--;
						}
						tile = tile2;
					}
				}
			}
			if (num2 > 0)
			{
				array2[num3] = (byte)(num2 & 255);
				num3++;
				if (num2 > 255)
				{
					b |= 128;
					array2[num3] = (byte)(((int)num2 & 65280) >> 8);
					num3++;
				}
				else
				{
					b |= 64;
				}
			}
			array2[num4] = b;
			writer.Write(array2, num4, num3 - num4);
			if (!packChests)
			{
				return;
			}
			writer.Write(num);
			for (int k = 0; k < (int)num; k++)
			{
				Chest chest = Main.chest[(int)array[k]];
				writer.Write(array[k]);
				writer.Write((short)chest.x);
				writer.Write((short)chest.y);
				writer.Write(chest.name);
			}
		}
		public static void DecompressTileBlock(byte[] buffer, int bufferStart, int bufferLength, bool packedChests)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(buffer, bufferStart, bufferLength);
				memoryStream.Position = 0L;
				bool flag = memoryStream.ReadByte() != 0;
				MemoryStream memoryStream3;
				if (flag)
				{
					MemoryStream memoryStream2 = new MemoryStream();
					using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress, true))
					{
						deflateStream.CopyTo(memoryStream2);
						deflateStream.Close();
					}
					memoryStream3 = memoryStream2;
					memoryStream3.Position = 0L;
				}
				else
				{
					memoryStream3 = memoryStream;
					memoryStream3.Position = 1L;
				}
				using (BinaryReader binaryReader = new BinaryReader(memoryStream3))
				{
					int xStart = binaryReader.ReadInt32();
					int yStart = binaryReader.ReadInt32();
					short width = binaryReader.ReadInt16();
					short height = binaryReader.ReadInt16();
					NetMessage.DecompressTileBlock_Inner(binaryReader, xStart, yStart, (int)width, (int)height, packedChests);
				}
			}
		}
		public static void DecompressTileBlock_Inner(BinaryReader reader, int xStart, int yStart, int width, int height, bool packedChests)
		{
			Tile tile = null;
			int num = 0;
			for (int i = yStart; i < yStart + height; i++)
			{
				for (int j = xStart; j < xStart + width; j++)
				{
					if (num != 0)
					{
						num--;
						if (Main.tile[j, i] == null)
						{
							Main.tile[j, i] = new Tile(tile);
						}
						else
						{
							Main.tile[j, i].CopyFrom(tile);
						}
					}
					else
					{
						byte b2;
						byte b = b2 = 0;
						tile = Main.tile[j, i];
						if (tile == null)
						{
							tile = new Tile();
							Main.tile[j, i] = tile;
						}
						else
						{
							tile.Clear();
						}
						byte b3 = reader.ReadByte();
						if ((b3 & 1) == 1)
						{
							b2 = reader.ReadByte();
							if ((b2 & 1) == 1)
							{
								b = reader.ReadByte();
							}
						}
						bool flag = tile.active();
						byte b4;
						if ((b3 & 2) == 2)
						{
							tile.active(true);
							ushort type = tile.type;
							int num2;
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
							if (Main.tileFrameImportant[num2])
							{
								tile.frameX = reader.ReadInt16();
								tile.frameY = reader.ReadInt16();
							}
							else if (!flag || tile.type != type)
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
						if (b4 == 0)
						{
							num = 0;
						}
						else if (b4 == 1)
						{
							num = (int)reader.ReadByte();
						}
						else
						{
							num = (int)reader.ReadInt16();
						}
					}
				}
			}
			short num3 = reader.ReadInt16();
			for (int k = 0; k < (int)num3; k++)
			{
				short num4 = reader.ReadInt16();
				short x = reader.ReadInt16();
				short y = reader.ReadInt16();
				string name = reader.ReadString();
				if (num4 >= 0 && num4 < 1000)
				{
					if (Main.chest[(int)num4] == null)
					{
						Main.chest[(int)num4] = new Chest(false);
					}
					Main.chest[(int)num4].name = name;
					Main.chest[(int)num4].x = (int)x;
					Main.chest[(int)num4].y = (int)y;
				}
			}
		}
		public static void RecieveBytes(byte[] bytes, int streamLength, int i = 256)
		{
			lock (NetMessage.buffer[i].readBuffer)
			{
				try
				{
					Buffer.BlockCopy(bytes, 0, NetMessage.buffer[i].readBuffer, NetMessage.buffer[i].totalData, streamLength);
					NetMessage.buffer[i].totalData += streamLength;
					NetMessage.buffer[i].checkBytes = true;
				}
				catch
				{
					if (Main.netMode == 1)
					{
						Main.menuMode = 15;
						Main.statusText = "Bad header lead to a read buffer overflow.";
						Netplay.disconnect = true;
					}
					else
					{
						Netplay.serverSock[i].kill = true;
					}
				}
			}
		}
		public static void CheckBytes(int i = 256)
		{
			lock (NetMessage.buffer[i].readBuffer)
			{
				int num = 0;
				int num2 = 2;
				if (NetMessage.buffer[i].totalData >= num2)
				{
					if (NetMessage.buffer[i].messageLength == 0)
					{
						NetMessage.buffer[i].messageLength = (int)BitConverter.ToUInt16(NetMessage.buffer[i].readBuffer, 0);
					}
					while (NetMessage.buffer[i].totalData >= NetMessage.buffer[i].messageLength + num && NetMessage.buffer[i].messageLength > 0)
					{
						if (!Main.ignoreErrors)
						{
							NetMessage.buffer[i].GetData(num + num2, NetMessage.buffer[i].messageLength - num2);
						}
						else
						{
							try
							{
								NetMessage.buffer[i].GetData(num + num2, NetMessage.buffer[i].messageLength - num2);
							}
							catch
							{
							}
						}
						num += NetMessage.buffer[i].messageLength;
						if (NetMessage.buffer[i].totalData - num >= num2)
						{
							NetMessage.buffer[i].messageLength = (int)BitConverter.ToUInt16(NetMessage.buffer[i].readBuffer, num);
						}
						else
						{
							NetMessage.buffer[i].messageLength = 0;
						}
					}
					if (num == NetMessage.buffer[i].totalData)
					{
						NetMessage.buffer[i].totalData = 0;
					}
					else if (num > 0)
					{
						Buffer.BlockCopy(NetMessage.buffer[i].readBuffer, num, NetMessage.buffer[i].readBuffer, 0, NetMessage.buffer[i].totalData - num);
						NetMessage.buffer[i].totalData -= num;
					}
					NetMessage.buffer[i].checkBytes = false;
				}
			}
		}
		public static void BootPlayer(int plr, string msg)
		{
			NetMessage.SendData(2, plr, -1, msg, 0, 0f, 0f, 0f, 0);
		}
		public static void SendTileSquare(int whoAmi, int tileX, int tileY, int size)
		{
			int num = (size - 1) / 2;
			NetMessage.SendData(20, whoAmi, -1, "", size, (float)(tileX - num), (float)(tileY - num), 0f, 0);
		}
		public static void SendTravelShop()
		{
			if (Main.netMode == 2)
			{
				NetMessage.SendData(72, -1, -1, "", 0, 0f, 0f, 0f, 0);
			}
		}
		public static void SendAnglerQuest()
		{
			if (Main.netMode != 2)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				if (Netplay.serverSock[i].state == 10)
				{
					NetMessage.SendData(74, i, -1, Main.player[i].name, Main.anglerQuest, 0f, 0f, 0f, 0);
				}
			}
		}
		public static void SendSection(int whoAmi, int sectionX, int sectionY, bool skipSent = false)
		{
			if (Main.netMode != 2)
			{
				return;
			}
			try
			{
				if (sectionX >= 0 && sectionY >= 0 && sectionX < Main.maxSectionsX && sectionY < Main.maxSectionsY)
				{
					if (!skipSent || !Netplay.serverSock[whoAmi].tileSection[sectionX, sectionY])
					{
						Netplay.serverSock[whoAmi].tileSection[sectionX, sectionY] = true;
						int number = sectionX * 200;
						int num = sectionY * 150;
						int num2 = 150;
						for (int i = num; i < num + 150; i += num2)
						{
							NetMessage.SendData(10, whoAmi, -1, "", number, (float)i, 200f, (float)num2, 0);
						}
						for (int j = 0; j < 200; j++)
						{
							if (Main.npc[j].active && Main.npc[j].townNPC)
							{
								int sectionX2 = Netplay.GetSectionX((int)(Main.npc[j].position.X / 16f));
								int sectionY2 = Netplay.GetSectionY((int)(Main.npc[j].position.Y / 16f));
								if (sectionX2 == sectionX && sectionY2 == sectionY)
								{
									NetMessage.SendData(23, whoAmi, -1, "", j, 0f, 0f, 0f, 0);
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		public static void greetPlayer(int plr)
		{
			if (ServerApi.Hooks.InvokeNetGreetPlayer(plr))
				return;

			if (Main.motd == "")
			{
				NetMessage.SendData(25, plr, -1, Lang.mp[18] + " " + Main.worldName + "!", 255, 255f, 240f, 20f, 0);
			}
			else
			{
				NetMessage.SendData(25, plr, -1, Main.motd, 255, 255f, 240f, 20f, 0);
			}
			string text = "";
			for (int i = 0; i < 255; i++)
			{
				if (Main.player[i].active)
				{
					if (text == "")
					{
						text += Main.player[i].name;
					}
					else
					{
						text = text + ", " + Main.player[i].name;
					}
				}
			}
			NetMessage.SendData(25, plr, -1, "Current players: " + text + ".", 255, 255f, 240f, 20f, 0);
		}
		public static void sendWater(int x, int y)
		{
			if (Main.netMode == 1)
			{
				NetMessage.SendData(48, -1, -1, "", x, (float)y, 0f, 0f, 0);
				return;
			}
			for (int i = 0; i < 256; i++)
			{
				if ((NetMessage.buffer[i].broadcast || Netplay.serverSock[i].state >= 3) && Netplay.serverSock[i].tcpClient.Connected)
				{
					int num = x / 200;
					int num2 = y / 150;
					if (Netplay.serverSock[i].tileSection[num, num2])
					{
						NetMessage.SendData(48, i, -1, "", x, (float)y, 0f, 0f, 0);
					}
				}
			}
		}

		public static void PlayerLeft(int who)
		{
			NetMessage.SendData(14, -1, who, "", who, (float)0, 0f, 0f, 0);
			if (Netplay.serverSock[who].announced)
			{
				Netplay.serverSock[who].announced = false;
			}
		}

		public static void PlayerJoin(int i)
		{
			NetMessage.SendData(14, -1, i, "", i, (float) 1, 0f, 0f, 0);
			NetMessage.SendData(4, -1, i, Main.player[i].name, i, 0f, 0f, 0f, 0);
			NetMessage.SendData(13, -1, i, "", i, 0f, 0f, 0f, 0);
			NetMessage.SendData(16, -1, i, "", i, 0f, 0f, 0f, 0);
			NetMessage.SendData(30, -1, i, "", i, 0f, 0f, 0f, 0);
			NetMessage.SendData(45, -1, i, "", i, 0f, 0f, 0f, 0);
			NetMessage.SendData(42, -1, i, "", i, 0f, 0f, 0f, 0);
			NetMessage.SendData(50, -1, i, "", i, 0f, 0f, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].inventory[Main.player[i].selectedItem].name, i, (float) Main.player[i].selectedItem,
					(float) Main.player[i].inventory[Main.player[i].selectedItem].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[0].name, i, 59f, (float) Main.player[i].armor[0].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[1].name, i, 60f, (float) Main.player[i].armor[1].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[2].name, i, 61f, (float) Main.player[i].armor[2].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[3].name, i, 62f, (float) Main.player[i].armor[3].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[4].name, i, 63f, (float) Main.player[i].armor[4].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[5].name, i, 64f, (float) Main.player[i].armor[5].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[6].name, i, 65f, (float) Main.player[i].armor[6].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[7].name, i, 66f, (float) Main.player[i].armor[7].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[8].name, i, 67f, (float) Main.player[i].armor[8].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[9].name, i, 68f, (float) Main.player[i].armor[9].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[10].name, i, 69f, (float) Main.player[i].armor[10].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[11].name, i, 70f, (float) Main.player[i].armor[11].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[12].name, i, 71f, (float) Main.player[i].armor[12].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[13].name, i, 72f, (float) Main.player[i].armor[13].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[14].name, i, 73f, (float) Main.player[i].armor[14].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].armor[15].name, i, 74f, (float) Main.player[i].armor[15].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[0].name, i, 75f, (float) Main.player[i].dye[0].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[1].name, i, 76f, (float) Main.player[i].dye[1].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[2].name, i, 77f, (float) Main.player[i].dye[2].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[3].name, i, 78f, (float) Main.player[i].dye[3].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[4].name, i, 79f, (float) Main.player[i].dye[4].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[5].name, i, 80f, (float) Main.player[i].dye[5].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[6].name, i, 81f, (float) Main.player[i].dye[6].prefix, 0f, 0);
			NetMessage.SendData(5, -1, i, Main.player[i].dye[7].name, i, 82f, (float) Main.player[i].dye[7].prefix, 0f, 0);

			for (int j = 0; j < 255; j++)
			{
				if(j == i)
					continue;
				
				int num = 0;
				if (Main.player[j].active)
				{
					num = 1;
				}
				if (Netplay.serverSock[j].state == 10)
				{
					NetMessage.SendData(14, i, j, "", j, (float) 1, 0f, 0f, 0);
					NetMessage.SendData(4, i, j, Main.player[j].name, j, 0f, 0f, 0f, 0);
					NetMessage.SendData(13, i, j, "", j, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, i, j, "", j, 0f, 0f, 0f, 0);
					NetMessage.SendData(30, i, j, "", j, 0f, 0f, 0f, 0);
					NetMessage.SendData(45, i, j, "", j, 0f, 0f, 0f, 0);
					NetMessage.SendData(42, i, j, "", j, 0f, 0f, 0f, 0);
					NetMessage.SendData(50, i, j, "", j, 0f, 0f, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].inventory[Main.player[j].selectedItem].name, j, (float) Main.player[j].selectedItem,
							(float) Main.player[j].inventory[Main.player[j].selectedItem].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[0].name, j, 59f, (float) Main.player[j].armor[0].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[1].name, j, 60f, (float) Main.player[j].armor[1].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[2].name, j, 61f, (float) Main.player[j].armor[2].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[3].name, j, 62f, (float) Main.player[j].armor[3].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[4].name, j, 63f, (float) Main.player[j].armor[4].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[5].name, j, 64f, (float) Main.player[j].armor[5].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[6].name, j, 65f, (float) Main.player[j].armor[6].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[7].name, j, 66f, (float) Main.player[j].armor[7].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[8].name, j, 67f, (float) Main.player[j].armor[8].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[9].name, j, 68f, (float) Main.player[j].armor[9].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[10].name, j, 69f, (float) Main.player[j].armor[10].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[11].name, j, 70f, (float) Main.player[j].armor[11].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[12].name, j, 71f, (float) Main.player[j].armor[12].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[13].name, j, 72f, (float) Main.player[j].armor[13].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[14].name, j, 73f, (float) Main.player[j].armor[14].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].armor[15].name, j, 74f, (float) Main.player[j].armor[15].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[0].name, j, 75f, (float) Main.player[j].dye[0].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[1].name, j, 76f, (float) Main.player[j].dye[1].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[2].name, j, 77f, (float) Main.player[j].dye[2].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[3].name, j, 78f, (float) Main.player[j].dye[3].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[4].name, j, 79f, (float) Main.player[j].dye[4].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[5].name, j, 80f, (float) Main.player[j].dye[5].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[6].name, j, 81f, (float) Main.player[j].dye[6].prefix, 0f, 0);
					NetMessage.SendData(5, i, j, Main.player[j].dye[7].name, j, 82f, (float) Main.player[j].dye[7].prefix, 0f, 0);
				}
			}

			if (!Netplay.serverSock[i].announced)
			{
				Netplay.serverSock[i].announced = true;
			}

			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active && Main.npc[l].townNPC && NPC.TypeToNum(Main.npc[l].type) != -1)
				{
					int num2 = 0;
					if (Main.npc[l].homeless)
					{
						num2 = 1;
					}
					NetMessage.SendData(60, i, -1, "", l, (float)Main.npc[l].homeTileX, (float)Main.npc[l].homeTileY, (float)num2, 0);
				}
			}
			for (int m = 0; m < 200; m++)
			{
				if (Main.npc[m].active && Main.npc[m].type == 368)
				{
					NetMessage.SendData(72, i, -1, "", 0, 0f, 0f, 0f, 0);
					break;
				}
			}

			NetMessage.SendData(74, i, -1, Main.player[i].name, Main.anglerQuest, 0f, 0f, 0f, 0);
		}

		public static void syncPlayers()
		{
			bool flag = false;
			for (int i = 0; i < 255; i++)
			{
				int num = 0;
				if (Main.player[i].active)
				{
					num = 1;
				}
				if (Netplay.serverSock[i].state == 10)
				{
					if (Main.autoShutdown && !flag)
					{
						string text = Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint.ToString();
						string a = text;
						for (int j = 0; j < text.Length; j++)
						{
							if (text.Substring(j, 1) == ":")
							{
								a = text.Substring(0, j);
							}
						}
						if (a == "127.0.0.1")
						{
							flag = true;
						}
					}
					NetMessage.SendData(14, -1, i, "", i, (float)num, 0f, 0f, 0);
					NetMessage.SendData(4, -1, i, Main.player[i].name, i, 0f, 0f, 0f, 0);
					NetMessage.SendData(13, -1, i, "", i, 0f, 0f, 0f, 0);
					NetMessage.SendData(16, -1, i, "", i, 0f, 0f, 0f, 0);
					NetMessage.SendData(30, -1, i, "", i, 0f, 0f, 0f, 0);
					NetMessage.SendData(45, -1, i, "", i, 0f, 0f, 0f, 0);
					NetMessage.SendData(42, -1, i, "", i, 0f, 0f, 0f, 0);
					NetMessage.SendData(50, -1, i, "", i, 0f, 0f, 0f, 0);
					for (int k = 0; k < 59; k++)
					{
						NetMessage.SendData(5, -1, i, Main.player[i].inventory[k].name, i, (float)k, (float)Main.player[i].inventory[k].prefix, 0f, 0);
					}
					NetMessage.SendData(5, -1, i, Main.player[i].armor[0].name, i, 59f, (float)Main.player[i].armor[0].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[1].name, i, 60f, (float)Main.player[i].armor[1].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[2].name, i, 61f, (float)Main.player[i].armor[2].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[3].name, i, 62f, (float)Main.player[i].armor[3].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[4].name, i, 63f, (float)Main.player[i].armor[4].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[5].name, i, 64f, (float)Main.player[i].armor[5].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[6].name, i, 65f, (float)Main.player[i].armor[6].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[7].name, i, 66f, (float)Main.player[i].armor[7].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[8].name, i, 67f, (float)Main.player[i].armor[8].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[9].name, i, 68f, (float)Main.player[i].armor[9].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[10].name, i, 69f, (float)Main.player[i].armor[10].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[11].name, i, 70f, (float)Main.player[i].armor[11].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[12].name, i, 71f, (float)Main.player[i].armor[12].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[13].name, i, 72f, (float)Main.player[i].armor[13].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[14].name, i, 73f, (float)Main.player[i].armor[14].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].armor[15].name, i, 74f, (float)Main.player[i].armor[15].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[0].name, i, 75f, (float)Main.player[i].dye[0].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[1].name, i, 76f, (float)Main.player[i].dye[1].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[2].name, i, 77f, (float)Main.player[i].dye[2].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[3].name, i, 78f, (float)Main.player[i].dye[3].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[4].name, i, 79f, (float)Main.player[i].dye[4].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[5].name, i, 80f, (float)Main.player[i].dye[5].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[6].name, i, 81f, (float)Main.player[i].dye[6].prefix, 0f, 0);
					NetMessage.SendData(5, -1, i, Main.player[i].dye[7].name, i, 82f, (float)Main.player[i].dye[7].prefix, 0f, 0);
					if (!Netplay.serverSock[i].announced)
					{
						Netplay.serverSock[i].announced = true;
					}
				}
				else
				{
					num = 0;
					NetMessage.SendData(14, -1, i, "", i, (float)num, 0f, 0f, 0);
					if (Netplay.serverSock[i].announced)
					{
						Netplay.serverSock[i].announced = false;
					}
				}
			}
			for (int l = 0; l < 200; l++)
			{
				if (Main.npc[l].active && Main.npc[l].townNPC && NPC.TypeToNum(Main.npc[l].type) != -1)
				{
					int num2 = 0;
					if (Main.npc[l].homeless)
					{
						num2 = 1;
					}
					NetMessage.SendData(60, -1, -1, "", l, (float)Main.npc[l].homeTileX, (float)Main.npc[l].homeTileY, (float)num2, 0);
				}
			}
			for (int m = 0; m < 200; m++)
			{
				if (Main.npc[m].active && Main.npc[m].type == 368)
				{
					NetMessage.SendTravelShop();
					break;
				}
			}
			NetMessage.SendAnglerQuest();
			if (Main.autoShutdown && !flag)
			{
				WorldFile.saveWorld(false);
				Netplay.disconnect = true;
			}
		}
	}
}
