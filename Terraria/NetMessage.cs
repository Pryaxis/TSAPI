using System;
using System.IO;
using System.IO.Compression;
using System.Text;
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
			if (!ServerApi.Hooks.InvokeNetSendData(ref msgType, ref remoteClient, ref ignoreClient, ref text, ref number,
					ref number2, ref number3, ref number4, ref number5))
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
			lock (NetMessage.buffer[num])
			{
				int num2 = 5;
				int num3 = num2;
				if (msgType == 1)
				{
					byte[] bytes = BitConverter.GetBytes(msgType);
					byte[] bytes2 = Encoding.UTF8.GetBytes("Terraria" + Main.curRelease);
					num2 += bytes2.Length;
					byte[] bytes3 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes3, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes2, 0, NetMessage.buffer[num].writeBuffer, 5, bytes2.Length);
				}
				else if (msgType == 2)
				{
					byte[] bytes4 = BitConverter.GetBytes(msgType);
					byte[] bytes5 = Encoding.UTF8.GetBytes(text);
					num2 += bytes5.Length;
					byte[] bytes6 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes6, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes4, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes5, 0, NetMessage.buffer[num].writeBuffer, 5, bytes5.Length);
					if (Main.dedServ)
					{
						Console.WriteLine(Netplay.serverSock[num].tcpClient.Client.RemoteEndPoint.ToString() + " was booted: " + text);
					}
				}
				else if (msgType == 3)
				{
					byte[] bytes7 = BitConverter.GetBytes(msgType);
					byte[] bytes8 = BitConverter.GetBytes(remoteClient);
					num2 += bytes8.Length;
					byte[] bytes9 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes9, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes7, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes8, 0, NetMessage.buffer[num].writeBuffer, 5, bytes8.Length);
				}
				else if (msgType == 4)
				{
					byte[] bytes10 = BitConverter.GetBytes(msgType);
					byte b = (byte)number;
					byte b2 = (byte)Main.player[(int)b].hair;
					byte b3 = 0;
					if (Main.player[(int)b].male)
					{
						b3 = 1;
					}
					byte[] bytes11 = Encoding.UTF8.GetBytes(text);
					num2 += 24 + bytes11.Length + 1 + 1 + 1;
					byte[] bytes12 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes12, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes10, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b;
					num3++;
					NetMessage.buffer[num].writeBuffer[6] = b2;
					num3++;
					NetMessage.buffer[num].writeBuffer[7] = b3;
					num3++;
					NetMessage.buffer[num].writeBuffer[8] = Main.player[(int)b].hairDye;
					num3++;
					NetMessage.buffer[num].writeBuffer[9] = Main.player[(int)b].hideVisual;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].hairColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].hairColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].hairColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].skinColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].skinColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].skinColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].eyeColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].eyeColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].eyeColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].shirtColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].shirtColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].shirtColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].underShirtColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].underShirtColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].underShirtColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].pantsColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].pantsColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].pantsColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].shoeColor.R;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].shoeColor.G;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].shoeColor.B;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = Main.player[(int)b].difficulty;
					num3++;
					Buffer.BlockCopy(bytes11, 0, NetMessage.buffer[num].writeBuffer, num3, bytes11.Length);
				}
				else if (msgType == 5)
				{
					byte[] bytes13 = BitConverter.GetBytes(msgType);
					byte b4 = (byte)number;
					byte b5 = (byte)number2;
					short num4;
					byte[] bytes14;
					if (number2 < 59f)
					{
						if (Main.player[number].inventory[(int)number2].name == "" || Main.player[number].inventory[(int)number2].stack == 0 || Main.player[number].inventory[(int)number2].type == 0)
						{
							Main.player[number].inventory[(int)number2].netID = 0;
						}
						num4 = (short)Main.player[number].inventory[(int)number2].stack;
						bytes14 = BitConverter.GetBytes((short)Main.player[number].inventory[(int)number2].netID);
					}
					else if (number2 >= 75f && number2 <= 82f)
					{
						int num5 = (int)number2 - 58 - 17;
						if (Main.player[number].dye[num5].name == "" || Main.player[number].dye[num5].stack == 0 || Main.player[number].dye[num5].type == 0)
						{
							Main.player[number].dye[num5].SetDefaults(0, false);
						}
						num4 = (short)Main.player[number].dye[num5].stack;
						bytes14 = BitConverter.GetBytes((short)Main.player[number].dye[num5].netID);
					}
					else
					{
						if (Main.player[number].armor[(int)number2 - 58 - 1].name == "" || Main.player[number].armor[(int)number2 - 58 - 1].stack == 0 || Main.player[number].armor[(int)number2 - 58 - 1].type == 0)
						{
							Main.player[number].armor[(int)number2 - 58 - 1].SetDefaults(0, false);
						}
						num4 = (short)Main.player[number].armor[(int)number2 - 58 - 1].stack;
						bytes14 = BitConverter.GetBytes((short)Main.player[number].armor[(int)number2 - 58 - 1].netID);
					}
					if (num4 < 0)
					{
						num4 = 0;
					}
					byte[] bytes15 = BitConverter.GetBytes(num4);
					byte b6 = (byte)number3;
					num2 += 4 + bytes14.Length + 1;
					byte[] bytes16 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes16, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes13, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b4;
					num3++;
					NetMessage.buffer[num].writeBuffer[6] = b5;
					num3++;
					Buffer.BlockCopy(bytes15, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[9] = b6;
					num3++;
					Buffer.BlockCopy(bytes14, 0, NetMessage.buffer[num].writeBuffer, num3, bytes14.Length);
				}
				else if (msgType == 6)
				{
					byte[] bytes17 = BitConverter.GetBytes(msgType);
					byte[] bytes18 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes18, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes17, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
				}
				else if (msgType == 7)
				{
					byte[] bytes19 = BitConverter.GetBytes(msgType);
					byte[] bytes20 = BitConverter.GetBytes((int)Main.time);
					byte b7 = 0;
					if (Main.dayTime)
					{
						b7 = 1;
					}
					byte b8 = (byte)Main.moonPhase;
					byte b9 = 0;
					if (Main.bloodMoon)
					{
						b9 = 1;
					}
					byte b10 = 0;
					if (Main.eclipse)
					{
						b10 = 1;
					}
					byte[] bytes21 = BitConverter.GetBytes(Main.maxTilesX);
					byte[] bytes22 = BitConverter.GetBytes(Main.maxTilesY);
					byte[] bytes23 = BitConverter.GetBytes(Main.spawnTileX);
					byte[] bytes24 = BitConverter.GetBytes(Main.spawnTileY);
					byte[] bytes25 = BitConverter.GetBytes((int)Main.worldSurface);
					byte[] bytes26 = BitConverter.GetBytes((int)Main.rockLayer);
					byte[] bytes27 = BitConverter.GetBytes(Main.worldID);
					byte[] bytes28 = Encoding.UTF8.GetBytes(Main.worldName);
					byte b11 = 0;
					byte b12 = 0;
					byte b13 = (byte)WorldGen.treeBG;
					byte b14 = (byte)WorldGen.corruptBG;
					byte b15 = (byte)WorldGen.jungleBG;
					byte b16 = (byte)WorldGen.snowBG;
					byte b17 = (byte)WorldGen.hallowBG;
					byte b18 = (byte)WorldGen.crimsonBG;
					byte b19 = (byte)WorldGen.desertBG;
					byte b20 = (byte)WorldGen.oceanBG;
					byte[] bytes29 = BitConverter.GetBytes(Main.windSpeedSet);
					byte b21 = (byte)Main.numClouds;
					byte[] bytes30 = BitConverter.GetBytes(Main.treeX[0]);
					byte[] bytes31 = BitConverter.GetBytes(Main.treeX[1]);
					byte[] bytes32 = BitConverter.GetBytes(Main.treeX[2]);
					byte b22 = (byte)Main.treeStyle[0];
					byte b23 = (byte)Main.treeStyle[1];
					byte b24 = (byte)Main.treeStyle[2];
					byte b25 = (byte)Main.treeStyle[3];
					byte[] bytes33 = BitConverter.GetBytes(Main.caveBackX[0]);
					byte[] bytes34 = BitConverter.GetBytes(Main.caveBackX[1]);
					byte[] bytes35 = BitConverter.GetBytes(Main.caveBackX[2]);
					byte b26 = (byte)Main.caveBackStyle[0];
					byte b27 = (byte)Main.caveBackStyle[1];
					byte b28 = (byte)Main.caveBackStyle[2];
					byte b29 = (byte)Main.caveBackStyle[3];
					if (!Main.raining)
					{
						Main.maxRaining = 0f;
					}
					byte[] bytes36 = BitConverter.GetBytes(Main.maxRaining);
					if (WorldGen.shadowOrbSmashed)
					{
						b11 = (byte)(b11 + 1);
					}
					if (NPC.downedBoss1)
					{
						b11 = (byte)(b11 + 2);
					}
					if (NPC.downedBoss2)
					{
						b11 = (byte)(b11 + 4);
					}
					if (NPC.downedBoss3)
					{
						b11 = (byte)(b11 + 8);
					}
					if (Main.hardMode)
					{
						b11 = (byte)(b11 + 16);
					}
					if (NPC.downedClown)
					{
						b11 = (byte)(b11 + 32);
					}
					if (NPC.downedPlantBoss)
					{
						b11 = (byte)(b11 + 128);
					}
					if (NPC.downedMechBoss1)
					{
						b12 = (byte)(b12 + 1);
					}
					if (NPC.downedMechBoss2)
					{
						b12 = (byte)(b12 + 2);
					}
					if (NPC.downedMechBoss3)
					{
						b12 = (byte)(b12 + 4);
					}
					if (NPC.downedMechBossAny)
					{
						b12 = (byte)(b12 + 8);
					}
					if (Main.cloudBGActive >= 1f)
					{
						b12 = (byte)(b12 + 16);
					}
					if (WorldGen.crimson)
					{
						b12 = (byte)(b12 + 32);
					}
					if (Main.pumpkinMoon)
					{
						b12 = (byte)(b12 + 64);
					}
					if (Main.snowMoon)
					{
						b12 = (byte)(b12 + 128);
					}
					num2 += bytes20.Length + 1 + 1 + 1 + 1 + 1 + bytes21.Length + bytes22.Length + bytes23.Length + bytes24.Length + bytes25.Length + bytes26.Length + bytes27.Length + 1 + bytes28.Length + 12 + 4 + 1 + 3 + 5 + 12 + 4 + 3 + 4 + 1 + 1;
					num2 += 3;
					byte[] bytes37 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes37, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes19, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes20, 0, NetMessage.buffer[num].writeBuffer, 5, bytes20.Length);
					num3 += bytes20.Length;
					NetMessage.buffer[num].writeBuffer[num3] = b7;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b8;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b9;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b10;
					num3++;
					Buffer.BlockCopy(bytes21, 0, NetMessage.buffer[num].writeBuffer, num3, bytes21.Length);
					num3 += bytes21.Length;
					Buffer.BlockCopy(bytes22, 0, NetMessage.buffer[num].writeBuffer, num3, bytes22.Length);
					num3 += bytes22.Length;
					Buffer.BlockCopy(bytes23, 0, NetMessage.buffer[num].writeBuffer, num3, bytes23.Length);
					num3 += bytes23.Length;
					Buffer.BlockCopy(bytes24, 0, NetMessage.buffer[num].writeBuffer, num3, bytes24.Length);
					num3 += bytes24.Length;
					Buffer.BlockCopy(bytes25, 0, NetMessage.buffer[num].writeBuffer, num3, bytes25.Length);
					num3 += bytes25.Length;
					Buffer.BlockCopy(bytes26, 0, NetMessage.buffer[num].writeBuffer, num3, bytes26.Length);
					num3 += bytes26.Length;
					Buffer.BlockCopy(bytes27, 0, NetMessage.buffer[num].writeBuffer, num3, bytes27.Length);
					num3 += bytes27.Length;
					NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.moonType;
					num3++;
					Buffer.BlockCopy(bytes30, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes31, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes32, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b22;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b23;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b24;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b25;
					num3++;
					Buffer.BlockCopy(bytes33, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes34, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes35, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b26;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b27;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b28;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b29;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b13;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b14;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b15;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b16;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b17;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b18;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b19;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b20;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.iceBackStyle;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.jungleBackStyle;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.hellBackStyle;
					num3++;
					Buffer.BlockCopy(bytes29, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b21;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b11;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b12;
					num3++;
					Buffer.BlockCopy(bytes36, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes28, 0, NetMessage.buffer[num].writeBuffer, num3, bytes28.Length);
					num3 += bytes28.Length;
				}
				else if (msgType == 8)
				{
					byte[] bytes38 = BitConverter.GetBytes(msgType);
					byte[] bytes39 = BitConverter.GetBytes(number);
					byte[] bytes40 = BitConverter.GetBytes((int)number2);
					num2 += bytes39.Length + bytes40.Length;
					byte[] bytes41 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes41, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes38, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes39, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes40, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
				}
				else if (msgType == 9)
				{
					byte[] bytes42 = BitConverter.GetBytes(msgType);
					byte[] bytes43 = BitConverter.GetBytes(number);
					byte[] bytes44 = Encoding.UTF8.GetBytes(text);
					num2 += bytes43.Length + bytes44.Length;
					byte[] bytes45 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes45, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes42, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes43, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes44, 0, NetMessage.buffer[num].writeBuffer, num3, bytes44.Length);
				}
				else if (msgType == 10)
				{
					int yStart = (int)number2;
					short width = (short)number3;
					short height = (short)number4;
					byte[] bytes46 = BitConverter.GetBytes(msgType);
					Buffer.BlockCopy(bytes46, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					int num6 = NetMessage.CompressTileBlock(number, yStart, width, height, NetMessage.buffer[num].writeBuffer, num3, true);
					num3 += num6;
					num2 = num3;
					byte[] bytes47 = BitConverter.GetBytes(num3 - 4);
					Buffer.BlockCopy(bytes47, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					num2 = num3;
				}
				else if (msgType == 11)
				{
					byte[] bytes48 = BitConverter.GetBytes(msgType);
					byte[] bytes49 = BitConverter.GetBytes(number);
					byte[] bytes50 = BitConverter.GetBytes((int)number2);
					byte[] bytes51 = BitConverter.GetBytes((int)number3);
					byte[] bytes52 = BitConverter.GetBytes((int)number4);
					num2 += bytes49.Length + bytes50.Length + bytes51.Length + bytes52.Length;
					byte[] bytes53 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes53, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes48, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes49, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes50, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes51, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes52, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
				}
				else if (msgType == 12)
				{
					byte[] bytes54 = BitConverter.GetBytes(msgType);
					byte b30 = (byte)number;
					byte[] bytes55 = BitConverter.GetBytes(Main.player[(int)b30].SpawnX);
					byte[] bytes56 = BitConverter.GetBytes(Main.player[(int)b30].SpawnY);
					num2 += 1 + bytes55.Length + bytes56.Length;
					byte[] bytes57 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes57, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes54, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b30;
					num3++;
					Buffer.BlockCopy(bytes55, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes56, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
				}
				else if (msgType == 13)
				{
					byte[] bytes58 = BitConverter.GetBytes(msgType);
					byte b31 = (byte)number;
					byte b32 = 0;
					if (Main.player[(int)b31].controlUp)
					{
						b32 = (byte)(b32 + 1);
					}
					if (Main.player[(int)b31].controlDown)
					{
						b32 = (byte)(b32 + 2);
					}
					if (Main.player[(int)b31].controlLeft)
					{
						b32 = (byte)(b32 + 4);
					}
					if (Main.player[(int)b31].controlRight)
					{
						b32 = (byte)(b32 + 8);
					}
					if (Main.player[(int)b31].controlJump)
					{
						b32 = (byte)(b32 + 16);
					}
					if (Main.player[(int)b31].controlUseItem)
					{
						b32 = (byte)(b32 + 32);
					}
					if (Main.player[(int)b31].direction == 1)
					{
						b32 = (byte)(b32 + 64);
					}
					byte b33 = (byte)Main.player[(int)b31].selectedItem;
					byte[] bytes59 = BitConverter.GetBytes(Main.player[number].position.X);
					byte[] bytes60 = BitConverter.GetBytes(Main.player[number].position.Y);
					byte[] bytes61 = BitConverter.GetBytes(Main.player[number].velocity.X);
					byte[] bytes62 = BitConverter.GetBytes(Main.player[number].velocity.Y);
					byte b34 = 0;
					if (Main.player[(int)b31].pulley)
					{
						b34 = (byte)(b34 + 1);
						if (Main.player[(int)b31].pulleyDir == 2)
						{
							b34 = (byte)(b34 + 2);
						}
					}
					num2 += 3 + bytes59.Length + bytes60.Length + bytes61.Length + bytes62.Length + 1;
					byte[] bytes63 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes63, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes58, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b31;
					num3++;
					NetMessage.buffer[num].writeBuffer[6] = b32;
					num3++;
					NetMessage.buffer[num].writeBuffer[7] = b33;
					num3++;
					Buffer.BlockCopy(bytes59, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes60, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes61, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes62, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b34;
					num3++;
				}
				else if (msgType == 14)
				{
					byte[] bytes64 = BitConverter.GetBytes(msgType);
					byte b35 = (byte)number;
					byte b36 = (byte)number2;
					num2 += 2;
					byte[] bytes65 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes65, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes64, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b35;
					NetMessage.buffer[num].writeBuffer[6] = b36;
				}
				else if (msgType == 15)
				{
					byte[] bytes66 = BitConverter.GetBytes(msgType);
					byte[] bytes67 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes67, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes66, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
				}
				else if (msgType == 16)
				{
					byte[] bytes68 = BitConverter.GetBytes(msgType);
					byte b37 = (byte)number;
					byte[] bytes69 = BitConverter.GetBytes((short)Main.player[(int)b37].statLife);
					byte[] bytes70 = BitConverter.GetBytes((short)Main.player[(int)b37].statLifeMax);
					num2 += 1 + bytes69.Length + bytes70.Length;
					byte[] bytes71 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes71, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes68, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b37;
					num3++;
					Buffer.BlockCopy(bytes69, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
					Buffer.BlockCopy(bytes70, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
				}
				else if (msgType == 17)
				{
					byte[] bytes72 = BitConverter.GetBytes(msgType);
					byte b38 = (byte)number;
					byte[] bytes73 = BitConverter.GetBytes((int)number2);
					byte[] bytes74 = BitConverter.GetBytes((int)number3);
					byte[] bytes75 = BitConverter.GetBytes((short)number4);
					num2 += 1 + bytes73.Length + bytes74.Length + 1 + 2;
					byte[] bytes76 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes76, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes72, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b38;
					num3++;
					Buffer.BlockCopy(bytes73, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes74, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes75, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = (byte)number5;
				}
				else if (msgType == 18)
				{
					byte[] bytes77 = BitConverter.GetBytes(msgType);
					BitConverter.GetBytes((int)Main.time);
					byte b39 = 0;
					if (Main.dayTime)
					{
						b39 = 1;
					}
					byte[] bytes78 = BitConverter.GetBytes((int)Main.time);
					byte[] bytes79 = BitConverter.GetBytes(Main.sunModY);
					byte[] bytes80 = BitConverter.GetBytes(Main.moonModY);
					num2 += 1 + bytes78.Length + bytes79.Length + bytes80.Length;
					byte[] bytes81 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes81, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes77, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b39;
					num3++;
					Buffer.BlockCopy(bytes78, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes79, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
					Buffer.BlockCopy(bytes80, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
				}
				else if (msgType == 19)
				{
					byte[] bytes82 = BitConverter.GetBytes(msgType);
					byte b40 = (byte)number;
					byte[] bytes83 = BitConverter.GetBytes((int)number2);
					byte[] bytes84 = BitConverter.GetBytes((int)number3);
					byte b41 = 0;
					if (number4 == 1f)
					{
						b41 = 1;
					}
					num2 += 1 + bytes83.Length + bytes84.Length + 1;
					byte[] bytes85 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes85, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes82, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b40;
					num3++;
					Buffer.BlockCopy(bytes83, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes84, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b41;
				}
				else if (msgType == 20)
				{
					short num7 = (short)number;
					int num8 = (int)number2;
					int num9 = (int)number3;
					byte[] bytes86 = BitConverter.GetBytes(msgType);
					Buffer.BlockCopy(bytes86, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					byte[] bytes87 = BitConverter.GetBytes(num7);
					Buffer.BlockCopy(bytes87, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
					byte[] bytes88 = BitConverter.GetBytes(num8);
					Buffer.BlockCopy(bytes88, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					byte[] bytes89 = BitConverter.GetBytes(num9);
					Buffer.BlockCopy(bytes89, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					for (int i = num8; i < num8 + (int)num7; i++)
					{
						for (int j = num9; j < num9 + (int)num7; j++)
						{
							byte b42 = 0;
							byte b43 = 0;
							byte b44 = 0;
							byte b45 = 0;
							if (Main.tile[i, j].active())
							{
								b42 = (byte)(b42 + 1);
							}
							if (Main.tile[i, j].wall > 0)
							{
								b42 = (byte)(b42 + 4);
							}
							if (Main.tile[i, j].liquid > 0 && Main.netMode == 2)
							{
								b42 = (byte)(b42 + 8);
							}
							if (Main.tile[i, j].wire())
							{
								b42 = (byte)(b42 + 16);
							}
							if (Main.tile[i, j].halfBrick())
							{
								b42 = (byte)(b42 + 32);
							}
							if (Main.tile[i, j].actuator())
							{
								b42 = (byte)(b42 + 64);
							}
							if (Main.tile[i, j].inActive())
							{
								b42 = (byte)(b42 + 128);
							}
							if (Main.tile[i, j].wire2())
							{
								b43 = (byte)(b43 + 1);
							}
							if (Main.tile[i, j].wire3())
							{
								b43 = (byte)(b43 + 2);
							}
							b43 = (byte)(b43 + (byte)(Main.tile[i, j].slope() << 4));
							if (Main.tile[i, j].active() && Main.tile[i, j].color() > 0)
							{
								b43 = (byte)(b43 + 4);
								b44 = Main.tile[i, j].color();
							}
							if (Main.tile[i, j].wall > 0 && Main.tile[i, j].wallColor() > 0)
							{
								b43 = (byte)(b43 + 8);
								b45 = Main.tile[i, j].wallColor();
							}
							NetMessage.buffer[num].writeBuffer[num3] = b42;
							num3++;
							NetMessage.buffer[num].writeBuffer[num3] = b43;
							num3++;
							if (b44 > 0)
							{
								NetMessage.buffer[num].writeBuffer[num3] = b44;
								num3++;
							}
							if (b45 > 0)
							{
								NetMessage.buffer[num].writeBuffer[num3] = b45;
								num3++;
							}
							byte[] bytes90 = BitConverter.GetBytes(Main.tile[i, j].frameX);
							byte[] bytes91 = BitConverter.GetBytes(Main.tile[i, j].frameY);
							byte wall = Main.tile[i, j].wall;
							if (Main.tile[i, j].active())
							{
								Buffer.BlockCopy(BitConverter.GetBytes(Main.tile[i, j].type), 0, NetMessage.buffer[num].writeBuffer, num3, 2);
								num3 += 2;
								if (Main.tileFrameImportant[(int)Main.tile[i, j].type])
								{
									Buffer.BlockCopy(bytes90, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
									num3 += 2;
									Buffer.BlockCopy(bytes91, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
									num3 += 2;
								}
							}
							if (wall > 0)
							{
								NetMessage.buffer[num].writeBuffer[num3] = wall;
								num3++;
							}
							if (Main.tile[i, j].liquid > 0 && Main.netMode == 2)
							{
								NetMessage.buffer[num].writeBuffer[num3] = Main.tile[i, j].liquid;
								num3++;
								byte b46 = Main.tile[i, j].liquidType();
								NetMessage.buffer[num].writeBuffer[num3] = b46;
								num3++;
							}
						}
					}
					byte[] bytes92 = BitConverter.GetBytes(num3 - 4);
					Buffer.BlockCopy(bytes92, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					num2 = num3;
				}
				else if (msgType == 21)
				{
					byte[] bytes93 = BitConverter.GetBytes(msgType);
					byte[] bytes94 = BitConverter.GetBytes((short)number);
					byte[] bytes95 = BitConverter.GetBytes(Main.item[number].position.X);
					byte[] bytes96 = BitConverter.GetBytes(Main.item[number].position.Y);
					byte[] bytes97 = BitConverter.GetBytes(Main.item[number].velocity.X);
					byte[] bytes98 = BitConverter.GetBytes(Main.item[number].velocity.Y);
					byte[] bytes99 = BitConverter.GetBytes((short)Main.item[number].stack);
					byte prefix = Main.item[number].prefix;
					byte b47 = (byte)number2;
					short value = 0;
					if (Main.item[number].active && Main.item[number].stack > 0)
					{
						value = (short)Main.item[number].netID;
					}
					byte[] bytes100 = BitConverter.GetBytes(value);
					num2 += bytes94.Length + bytes95.Length + bytes96.Length + bytes97.Length + bytes98.Length + 1 + bytes100.Length + 1 + 1 + 1;
					byte[] bytes101 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes101, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes93, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes94, 0, NetMessage.buffer[num].writeBuffer, num3, bytes94.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes95, 0, NetMessage.buffer[num].writeBuffer, num3, bytes95.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes96, 0, NetMessage.buffer[num].writeBuffer, num3, bytes96.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes97, 0, NetMessage.buffer[num].writeBuffer, num3, bytes97.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes98, 0, NetMessage.buffer[num].writeBuffer, num3, bytes98.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes99, 0, NetMessage.buffer[num].writeBuffer, num3, bytes99.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = prefix;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b47;
					num3++;
					Buffer.BlockCopy(bytes100, 0, NetMessage.buffer[num].writeBuffer, num3, bytes100.Length);
				}
				else if (msgType == 22)
				{
					byte[] bytes102 = BitConverter.GetBytes(msgType);
					byte[] bytes103 = BitConverter.GetBytes((short)number);
					byte b48 = (byte)Main.item[number].owner;
					num2 += bytes103.Length + 1;
					byte[] bytes104 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes104, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes102, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes103, 0, NetMessage.buffer[num].writeBuffer, num3, bytes103.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b48;
				}
				else if (msgType == 23)
				{
					byte[] bytes105 = BitConverter.GetBytes(msgType);
					byte[] bytes106 = BitConverter.GetBytes((short)number);
					byte[] bytes107 = BitConverter.GetBytes(Main.npc[number].position.X);
					byte[] bytes108 = BitConverter.GetBytes(Main.npc[number].position.Y);
					byte[] bytes109 = BitConverter.GetBytes(Main.npc[number].velocity.X);
					byte[] bytes110 = BitConverter.GetBytes(Main.npc[number].velocity.Y);
					byte b49 = (byte)Main.npc[number].target;
					byte[] bytes111 = BitConverter.GetBytes(Main.npc[number].life);
					if (!Main.npc[number].active)
					{
						bytes111 = BitConverter.GetBytes(0);
					}
					if (!Main.npc[number].active || Main.npc[number].life <= 0)
					{
						Main.npc[number].netSkip = 0;
					}
					if (Main.npc[number].name == null)
					{
						Main.npc[number].name = "";
					}
					byte[] bytes112 = BitConverter.GetBytes((short)Main.npc[number].netID);
					num2 += bytes106.Length + bytes107.Length + bytes108.Length + bytes109.Length + bytes110.Length + 1 + bytes111.Length + NPC.maxAI * 4 + bytes112.Length + 1 + 1;
					if (Main.npcCatchable[Main.npc[number].type])
					{
						num2++;
					}
					byte[] bytes113 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes113, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes105, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes106, 0, NetMessage.buffer[num].writeBuffer, num3, bytes106.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes107, 0, NetMessage.buffer[num].writeBuffer, num3, bytes107.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes108, 0, NetMessage.buffer[num].writeBuffer, num3, bytes108.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes109, 0, NetMessage.buffer[num].writeBuffer, num3, bytes109.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes110, 0, NetMessage.buffer[num].writeBuffer, num3, bytes110.Length);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b49;
					num3++;
					byte b50 = 0;
					if (Main.npc[number].direction > 0)
					{
						b50 = (byte)(b50 + 1);
					}
					if (Main.npc[number].directionY > 0)
					{
						b50 = (byte)(b50 + 2);
					}
					bool[] array = new bool[4];
					if (Main.npc[number].ai[3] != 0f)
					{
						b50 = (byte)(b50 + 4);
						array[3] = true;
					}
					if (Main.npc[number].ai[2] != 0f)
					{
						b50 = (byte)(b50 + 8);
						array[2] = true;
					}
					if (Main.npc[number].ai[1] != 0f)
					{
						b50 = (byte)(b50 + 16);
						array[1] = true;
					}
					if (Main.npc[number].ai[0] != 0f)
					{
						b50 = (byte)(b50 + 32);
						array[0] = true;
					}
					if (Main.npc[number].spriteDirection > 0)
					{
						b50 = (byte)(b50 + 64);
					}
					NetMessage.buffer[num].writeBuffer[num3] = b50;
					num3++;
					Buffer.BlockCopy(bytes111, 0, NetMessage.buffer[num].writeBuffer, num3, bytes111.Length);
					num3 += 4;
					for (int k = 0; k < NPC.maxAI; k++)
					{
						if (array[k])
						{
							byte[] bytes114 = BitConverter.GetBytes(Main.npc[number].ai[k]);
							Buffer.BlockCopy(bytes114, 0, NetMessage.buffer[num].writeBuffer, num3, bytes114.Length);
							num3 += 4;
						}
					}
					Buffer.BlockCopy(bytes112, 0, NetMessage.buffer[num].writeBuffer, num3, bytes112.Length);
					num3 += bytes112.Length;
					if (Main.npcCatchable[Main.npc[number].type])
					{
						NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.npc[number].releaseOwner;
						num3++;
					}
				}
				else if (msgType == 24)
				{
					byte[] bytes115 = BitConverter.GetBytes(msgType);
					byte[] bytes116 = BitConverter.GetBytes((short)number);
					byte b51 = (byte)number2;
					num2 += bytes116.Length + 1;
					byte[] bytes117 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes117, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes115, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes116, 0, NetMessage.buffer[num].writeBuffer, num3, bytes116.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b51;
				}
				else if (msgType == 25)
				{
					byte[] bytes118 = BitConverter.GetBytes(msgType);
					byte b52 = (byte)number;
					byte[] bytes119 = Encoding.UTF8.GetBytes(text);
					byte b53 = (byte)number2;
					byte b54 = (byte)number3;
					byte b55 = (byte)number4;
					num2 += 1 + bytes119.Length + 3;
					byte[] bytes120 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes120, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes118, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b52;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b53;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b54;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b55;
					num3++;
					Buffer.BlockCopy(bytes119, 0, NetMessage.buffer[num].writeBuffer, num3, bytes119.Length);
				}
				else if (msgType == 26)
				{
					byte[] bytes121 = BitConverter.GetBytes(msgType);
					byte b56 = (byte)number;
					byte b57 = (byte)(number2 + 1f);
					byte[] bytes122 = BitConverter.GetBytes((short)number3);
					byte[] bytes123 = Encoding.UTF8.GetBytes(text);
					byte b58 = (byte)number4;
					byte b59 = (byte)number5;
					num2 += 2 + bytes122.Length + 1 + bytes123.Length + 1;
					byte[] bytes124 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes124, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes121, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b56;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b57;
					num3++;
					Buffer.BlockCopy(bytes122, 0, NetMessage.buffer[num].writeBuffer, num3, bytes122.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b58;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b59;
					num3++;
					Buffer.BlockCopy(bytes123, 0, NetMessage.buffer[num].writeBuffer, num3, bytes123.Length);
				}
				else if (msgType == 27)
				{
					byte[] bytes125 = BitConverter.GetBytes(msgType);
					byte[] bytes126 = BitConverter.GetBytes((short)Main.projectile[number].identity);
					byte[] bytes127 = BitConverter.GetBytes(Main.projectile[number].position.X);
					byte[] bytes128 = BitConverter.GetBytes(Main.projectile[number].position.Y);
					byte[] bytes129 = BitConverter.GetBytes(Main.projectile[number].velocity.X);
					byte[] bytes130 = BitConverter.GetBytes(Main.projectile[number].velocity.Y);
					byte[] bytes131 = BitConverter.GetBytes(Main.projectile[number].knockBack);
					byte[] bytes132 = BitConverter.GetBytes((short)Main.projectile[number].damage);
					byte[] bytes133 = BitConverter.GetBytes((short)Main.projectile[number].type);
					Buffer.BlockCopy(bytes125, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes126, 0, NetMessage.buffer[num].writeBuffer, num3, bytes126.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes127, 0, NetMessage.buffer[num].writeBuffer, num3, bytes127.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes128, 0, NetMessage.buffer[num].writeBuffer, num3, bytes128.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes129, 0, NetMessage.buffer[num].writeBuffer, num3, bytes129.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes130, 0, NetMessage.buffer[num].writeBuffer, num3, bytes130.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes131, 0, NetMessage.buffer[num].writeBuffer, num3, bytes131.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes132, 0, NetMessage.buffer[num].writeBuffer, num3, bytes132.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.projectile[number].owner;
					num3++;
					Buffer.BlockCopy(bytes133, 0, NetMessage.buffer[num].writeBuffer, num3, bytes133.Length);
					num3 += 2;
					for (int l = 0; l < Projectile.maxAI; l++)
					{
						byte[] bytes134 = BitConverter.GetBytes(Main.projectile[number].ai[l]);
						Buffer.BlockCopy(bytes134, 0, NetMessage.buffer[num].writeBuffer, num3, bytes134.Length);
						num3 += 4;
					}
					num2 += num3;
					byte[] bytes135 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes135, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
				}
				else if (msgType == 28)
				{
					byte[] bytes136 = BitConverter.GetBytes(msgType);
					byte[] bytes137 = BitConverter.GetBytes((short)number);
					byte[] bytes138 = BitConverter.GetBytes((short)number2);
					byte[] bytes139 = BitConverter.GetBytes(number3);
					byte b60 = (byte)(number4 + 1f);
					byte b61 = (byte)number5;
					num2 += bytes137.Length + bytes138.Length + bytes139.Length + 1 + 1;
					byte[] bytes140 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes140, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes136, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes137, 0, NetMessage.buffer[num].writeBuffer, num3, bytes137.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes138, 0, NetMessage.buffer[num].writeBuffer, num3, bytes138.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes139, 0, NetMessage.buffer[num].writeBuffer, num3, bytes139.Length);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b60;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b61;
				}
				else if (msgType == 29)
				{
					byte[] bytes141 = BitConverter.GetBytes(msgType);
					byte[] bytes142 = BitConverter.GetBytes((short)number);
					byte b62 = (byte)number2;
					num2 += bytes142.Length + 1;
					byte[] bytes143 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes143, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes141, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes142, 0, NetMessage.buffer[num].writeBuffer, num3, bytes142.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b62;
				}
				else if (msgType == 30)
				{
					byte[] bytes144 = BitConverter.GetBytes(msgType);
					byte b63 = (byte)number;
					byte b64 = 0;
					if (Main.player[(int)b63].hostile)
					{
						b64 = 1;
					}
					num2 += 2;
					byte[] bytes145 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes145, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes144, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b63;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b64;
				}
				else if (msgType == 31)
				{
					byte[] bytes146 = BitConverter.GetBytes(msgType);
					byte[] bytes147 = BitConverter.GetBytes(number);
					byte[] bytes148 = BitConverter.GetBytes((int)number2);
					num2 += bytes147.Length + bytes148.Length;
					byte[] bytes149 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes149, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes146, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes147, 0, NetMessage.buffer[num].writeBuffer, num3, bytes147.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes148, 0, NetMessage.buffer[num].writeBuffer, num3, bytes148.Length);
				}
				else if (msgType == 32)
				{
					byte[] bytes150 = BitConverter.GetBytes(msgType);
					byte[] bytes151 = BitConverter.GetBytes((short)number);
					byte b65 = (byte)number2;
					byte[] bytes152 = BitConverter.GetBytes(Main.chest[number].item[(int)number2].stack);
					byte prefix2 = Main.chest[number].item[(int)number2].prefix;
					byte[] bytes153;
					if (Main.chest[number].item[(int)number2].name == null)
					{
						bytes153 = BitConverter.GetBytes(0);
					}
					else
					{
						bytes153 = BitConverter.GetBytes((short)Main.chest[number].item[(int)number2].netID);
					}
					num2 += bytes151.Length + 1 + 1 + bytes152.Length + bytes153.Length;
					byte[] bytes154 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes154, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes150, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes151, 0, NetMessage.buffer[num].writeBuffer, num3, bytes151.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b65;
					num3++;
					Buffer.BlockCopy(bytes152, 0, NetMessage.buffer[num].writeBuffer, num3, bytes152.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = prefix2;
					num3++;
					Buffer.BlockCopy(bytes153, 0, NetMessage.buffer[num].writeBuffer, num3, bytes153.Length);
				}
				else if (msgType == 33)
				{
					byte[] bytes155 = BitConverter.GetBytes(msgType);
					byte[] bytes156 = BitConverter.GetBytes((short)number);
					byte b66 = 0;
					byte[] array2 = null;
					byte[] bytes157;
					byte[] bytes158;
					if (number > -1)
					{
						bytes157 = BitConverter.GetBytes(Main.chest[number].x);
						bytes158 = BitConverter.GetBytes(Main.chest[number].y);
					}
					else
					{
						bytes157 = BitConverter.GetBytes(0);
						bytes158 = BitConverter.GetBytes(0);
					}
					if (number2 == 1f)
					{
						b66 = (byte)text.Length;
						if (b66 == 0 || b66 > 20)
						{
							b66 = 255;
						}
						else
						{
							array2 = Encoding.UTF8.GetBytes(text);
						}
					}
					num2 += bytes156.Length + bytes157.Length + bytes158.Length + 1;
					if (array2 != null)
					{
						num2 += array2.Length;
					}
					byte[] bytes159 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes159, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes155, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes156, 0, NetMessage.buffer[num].writeBuffer, num3, bytes156.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes157, 0, NetMessage.buffer[num].writeBuffer, num3, bytes157.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes158, 0, NetMessage.buffer[num].writeBuffer, num3, bytes158.Length);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = b66;
					num3++;
					if (array2 != null)
					{
						Buffer.BlockCopy(array2, 0, NetMessage.buffer[num].writeBuffer, num3, array2.Length);
					}
				}
				else if (msgType == 34)
				{
					byte[] bytes160 = BitConverter.GetBytes(msgType);
					byte b67 = (byte)number;
					byte[] bytes161 = BitConverter.GetBytes((short)number2);
					byte[] bytes162 = BitConverter.GetBytes((short)number3);
					num2 += bytes161.Length + bytes162.Length + 1;
					NetMessage.buffer[num].writeBuffer[num3] = b67;
					num3++;
					Buffer.BlockCopy(bytes161, 0, NetMessage.buffer[num].writeBuffer, num3, bytes161.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes162, 0, NetMessage.buffer[num].writeBuffer, num3, bytes162.Length);
					num3 += 2;
					byte[] bytes163 = BitConverter.GetBytes((short)number4);
					Buffer.BlockCopy(bytes163, 0, NetMessage.buffer[num].writeBuffer, num3, bytes163.Length);
					num3 += bytes163.Length;
					num2 += bytes163.Length;
					if (Main.netMode == 2)
					{
						Netplay.GetSectionX((int)number2);
						Netplay.GetSectionY((int)number3);
						byte[] bytes164 = BitConverter.GetBytes((short)number5);
						Buffer.BlockCopy(bytes164, 0, NetMessage.buffer[num].writeBuffer, num3, bytes164.Length);
						num3 += bytes164.Length;
						num2 += bytes164.Length;
					}
					byte[] bytes165 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes165, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes160, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
				}
				else if (msgType == 35 || msgType == 66)
				{
					byte[] bytes166 = BitConverter.GetBytes(msgType);
					byte b68 = (byte)number;
					byte[] bytes167 = BitConverter.GetBytes((short)number2);
					num2 += 1 + bytes167.Length;
					byte[] bytes168 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes168, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes166, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b68;
					num3++;
					Buffer.BlockCopy(bytes167, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
				}
				else if (msgType == 36)
				{
					byte[] bytes169 = BitConverter.GetBytes(msgType);
					byte b69 = (byte)number;
					byte b70 = 0;
					if (Main.player[(int)b69].zoneEvil)
					{
						b70 = (byte)(b70 + 1);
					}
					if (Main.player[(int)b69].zoneMeteor)
					{
						b70 = (byte)(b70 + 2);
					}
					if (Main.player[(int)b69].zoneDungeon)
					{
						b70 = (byte)(b70 + 4);
					}
					if (Main.player[(int)b69].zoneJungle)
					{
						b70 = (byte)(b70 + 8);
					}
					if (Main.player[(int)b69].zoneHoly)
					{
						b70 = (byte)(b70 + 16);
					}
					if (Main.player[(int)b69].zoneSnow)
					{
						b70 = (byte)(b70 + 32);
					}
					if (Main.player[(int)b69].zoneBlood)
					{
						b70 = (byte)(b70 + 64);
					}
					if (Main.player[(int)b69].zoneCandle)
					{
						b70 = (byte)(b70 + 128);
					}
					num2 += 2;
					byte[] bytes170 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes170, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes169, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b69;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b70;
					num3++;
				}
				else if (msgType == 37)
				{
					byte[] bytes171 = BitConverter.GetBytes(msgType);
					byte[] bytes172 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes172, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes171, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
				}
				else if (msgType == 38)
				{
					byte[] bytes173 = BitConverter.GetBytes(msgType);
					byte[] bytes174 = Encoding.UTF8.GetBytes(text);
					num2 += bytes174.Length;
					byte[] bytes175 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes175, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes173, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes174, 0, NetMessage.buffer[num].writeBuffer, num3, bytes174.Length);
				}
				else if (msgType == 39)
				{
					byte[] bytes176 = BitConverter.GetBytes(msgType);
					byte[] bytes177 = BitConverter.GetBytes((short)number);
					num2 += bytes177.Length;
					byte[] bytes178 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes178, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes176, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes177, 0, NetMessage.buffer[num].writeBuffer, num3, bytes177.Length);
				}
				else if (msgType == 40)
				{
					byte[] bytes179 = BitConverter.GetBytes(msgType);
					byte b71 = (byte)number;
					byte[] bytes180 = BitConverter.GetBytes((short)Main.player[(int)b71].talkNPC);
					num2 += 1 + bytes180.Length;
					byte[] bytes181 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes181, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes179, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b71;
					num3++;
					Buffer.BlockCopy(bytes180, 0, NetMessage.buffer[num].writeBuffer, num3, bytes180.Length);
					num3 += 2;
				}
				else if (msgType == 41)
				{
					byte[] bytes182 = BitConverter.GetBytes(msgType);
					byte b72 = (byte)number;
					byte[] bytes183 = BitConverter.GetBytes(Main.player[(int)b72].itemRotation);
					byte[] bytes184 = BitConverter.GetBytes((short)Main.player[(int)b72].itemAnimation);
					num2 += 1 + bytes183.Length + bytes184.Length;
					byte[] bytes185 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes185, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes182, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b72;
					num3++;
					Buffer.BlockCopy(bytes183, 0, NetMessage.buffer[num].writeBuffer, num3, bytes183.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes184, 0, NetMessage.buffer[num].writeBuffer, num3, bytes184.Length);
				}
				else if (msgType == 42)
				{
					byte[] bytes186 = BitConverter.GetBytes(msgType);
					byte b73 = (byte)number;
					byte[] bytes187 = BitConverter.GetBytes((short)Main.player[(int)b73].statMana);
					byte[] bytes188 = BitConverter.GetBytes((short)Main.player[(int)b73].statManaMax);
					num2 += 1 + bytes187.Length + bytes188.Length;
					byte[] bytes189 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes189, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes186, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b73;
					num3++;
					Buffer.BlockCopy(bytes187, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
					num3 += 2;
					Buffer.BlockCopy(bytes188, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
				}
				else if (msgType == 43)
				{
					byte[] bytes190 = BitConverter.GetBytes(msgType);
					byte b74 = (byte)number;
					byte[] bytes191 = BitConverter.GetBytes((short)number2);
					num2 += 1 + bytes191.Length;
					byte[] bytes192 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes192, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes190, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b74;
					num3++;
					Buffer.BlockCopy(bytes191, 0, NetMessage.buffer[num].writeBuffer, num3, 2);
				}
				else if (msgType == 44)
				{
					byte[] bytes193 = BitConverter.GetBytes(msgType);
					byte b75 = (byte)number;
					byte b76 = (byte)(number2 + 1f);
					byte[] bytes194 = BitConverter.GetBytes((short)number3);
					byte b77 = (byte)number4;
					byte[] bytes195 = Encoding.UTF8.GetBytes(text);
					num2 += 2 + bytes194.Length + 1 + bytes195.Length;
					byte[] bytes196 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes196, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes193, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b75;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b76;
					num3++;
					Buffer.BlockCopy(bytes194, 0, NetMessage.buffer[num].writeBuffer, num3, bytes194.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b77;
					num3++;
					Buffer.BlockCopy(bytes195, 0, NetMessage.buffer[num].writeBuffer, num3, bytes195.Length);
					num3 += bytes195.Length;
				}
				else if (msgType == 45)
				{
					byte[] bytes197 = BitConverter.GetBytes(msgType);
					byte b78 = (byte)number;
					byte b79 = (byte)Main.player[(int)b78].team;
					num2 += 2;
					byte[] bytes198 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes198, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes197, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[5] = b78;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b79;
				}
				else if (msgType == 46)
				{
					byte[] bytes199 = BitConverter.GetBytes(msgType);
					byte[] bytes200 = BitConverter.GetBytes(number);
					byte[] bytes201 = BitConverter.GetBytes((int)number2);
					num2 += bytes200.Length + bytes201.Length;
					byte[] bytes202 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes202, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes199, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes200, 0, NetMessage.buffer[num].writeBuffer, num3, bytes200.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes201, 0, NetMessage.buffer[num].writeBuffer, num3, bytes201.Length);
				}
				else if (msgType == 47)
				{
					byte[] bytes203 = BitConverter.GetBytes(msgType);
					byte[] bytes204 = BitConverter.GetBytes((short)number);
					byte[] bytes205 = BitConverter.GetBytes(Main.sign[number].x);
					byte[] bytes206 = BitConverter.GetBytes(Main.sign[number].y);
					byte[] bytes207 = Encoding.UTF8.GetBytes(Main.sign[number].text);
					num2 += bytes204.Length + bytes205.Length + bytes206.Length + bytes207.Length;
					byte[] bytes208 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes208, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes203, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes204, 0, NetMessage.buffer[num].writeBuffer, num3, bytes204.Length);
					num3 += bytes204.Length;
					Buffer.BlockCopy(bytes205, 0, NetMessage.buffer[num].writeBuffer, num3, bytes205.Length);
					num3 += bytes205.Length;
					Buffer.BlockCopy(bytes206, 0, NetMessage.buffer[num].writeBuffer, num3, bytes206.Length);
					num3 += bytes206.Length;
					Buffer.BlockCopy(bytes207, 0, NetMessage.buffer[num].writeBuffer, num3, bytes207.Length);
					num3 += bytes207.Length;
				}
				else if (msgType == 48)
				{
					byte[] bytes209 = BitConverter.GetBytes(msgType);
					byte[] bytes210 = BitConverter.GetBytes(number);
					byte[] bytes211 = BitConverter.GetBytes((int)number2);
					byte liquid = Main.tile[number, (int)number2].liquid;
					byte b80 = Main.tile[number, (int)number2].liquidType();
					num2 += bytes210.Length + bytes211.Length + 1 + 1;
					byte[] bytes212 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes212, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes209, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes210, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes211, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					NetMessage.buffer[num].writeBuffer[num3] = liquid;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b80;
					num3++;
				}
				else if (msgType == 49)
				{
					byte[] bytes213 = BitConverter.GetBytes(msgType);
					byte[] bytes214 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes214, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes213, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
				}
				else if (msgType == 50)
				{
					byte[] bytes215 = BitConverter.GetBytes(msgType);
					byte b81 = (byte)number;
					num2 += 23;
					byte[] bytes216 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes216, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes215, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b81;
					num3++;
					for (int m = 0; m < 22; m++)
					{
						NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.player[(int)b81].buffType[m];
						num3++;
					}
				}
				else if (msgType == 51)
				{
					byte[] bytes217 = BitConverter.GetBytes(msgType);
					num2 += 2;
					byte b82 = (byte)number;
					byte b83 = (byte)number2;
					byte[] bytes218 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes218, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes217, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b82;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b83;
				}
				else if (msgType == 52)
				{
					byte[] bytes219 = BitConverter.GetBytes(msgType);
					byte b84 = (byte)number;
					byte b85 = (byte)number2;
					byte[] bytes220 = BitConverter.GetBytes((int)number3);
					byte[] bytes221 = BitConverter.GetBytes((int)number4);
					num2 += 2 + bytes220.Length + bytes221.Length;
					byte[] bytes222 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes222, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes219, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b84;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b85;
					num3++;
					Buffer.BlockCopy(bytes220, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
					Buffer.BlockCopy(bytes221, 0, NetMessage.buffer[num].writeBuffer, num3, 4);
					num3 += 4;
				}
				else if (msgType == 53)
				{
					byte[] bytes223 = BitConverter.GetBytes(msgType);
					byte[] bytes224 = BitConverter.GetBytes((short)number);
					byte b86 = (byte)number2;
					byte[] bytes225 = BitConverter.GetBytes((short)number3);
					num2 += bytes224.Length + 1 + bytes225.Length;
					byte[] bytes226 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes226, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes223, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes224, 0, NetMessage.buffer[num].writeBuffer, num3, bytes224.Length);
					num3 += bytes224.Length;
					NetMessage.buffer[num].writeBuffer[num3] = b86;
					num3++;
					Buffer.BlockCopy(bytes225, 0, NetMessage.buffer[num].writeBuffer, num3, bytes225.Length);
					num3 += bytes225.Length;
				}
				else if (msgType == 54)
				{
					byte[] bytes227 = BitConverter.GetBytes(msgType);
					byte[] bytes228 = BitConverter.GetBytes((short)number);
					num2 += bytes228.Length + 15;
					byte[] bytes229 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes229, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes227, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes228, 0, NetMessage.buffer[num].writeBuffer, num3, bytes228.Length);
					num3 += bytes228.Length;
					for (int n = 0; n < 5; n++)
					{
						NetMessage.buffer[num].writeBuffer[num3] = (byte)Main.npc[(int)((short)number)].buffType[n];
						num3++;
						byte[] bytes230 = BitConverter.GetBytes((short)Main.npc[number].buffTime[n]);
						Buffer.BlockCopy(bytes230, 0, NetMessage.buffer[num].writeBuffer, num3, bytes230.Length);
						num3 += bytes230.Length;
					}
				}
				else if (msgType == 55)
				{
					byte[] bytes231 = BitConverter.GetBytes(msgType);
					byte b87 = (byte)number;
					byte b88 = (byte)number2;
					byte[] bytes232 = BitConverter.GetBytes((short)number3);
					num2 += 2 + bytes232.Length;
					byte[] bytes233 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes233, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes231, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b87;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = b88;
					num3++;
					Buffer.BlockCopy(bytes232, 0, NetMessage.buffer[num].writeBuffer, num3, bytes232.Length);
					num3 += bytes232.Length;
				}
				else if (msgType == 56)
				{
					byte[] bytes234 = BitConverter.GetBytes(msgType);
					byte[] bytes235 = BitConverter.GetBytes((short)number);
					byte[] array3 = null;
					if (Main.netMode == 2)
					{
						array3 = Encoding.UTF8.GetBytes(Main.npc[number].displayName);
					}
					else if (Main.netMode == 1)
					{
						array3 = Encoding.UTF8.GetBytes(text);
					}
					num2 += bytes235.Length + array3.Length;
					byte[] bytes236 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes236, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes234, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes235, 0, NetMessage.buffer[num].writeBuffer, num3, bytes235.Length);
					num3 += bytes235.Length;
					Buffer.BlockCopy(array3, 0, NetMessage.buffer[num].writeBuffer, num3, array3.Length);
				}
				else if (msgType == 57)
				{
					byte[] bytes237 = BitConverter.GetBytes(msgType);
					num2 += 3;
					byte[] bytes238 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes238, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes237, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = WorldGen.tGood;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = WorldGen.tEvil;
					num3++;
					NetMessage.buffer[num].writeBuffer[num3] = WorldGen.tBlood;
				}
				else if (msgType == 58)
				{
					byte[] bytes239 = BitConverter.GetBytes(msgType);
					byte b89 = (byte)number;
					byte[] bytes240 = BitConverter.GetBytes(number2);
					num2 += 1 + bytes240.Length;
					byte[] bytes241 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes241, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes239, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b89;
					num3++;
					Buffer.BlockCopy(bytes240, 0, NetMessage.buffer[num].writeBuffer, num3, bytes240.Length);
				}
				else if (msgType == 59)
				{
					byte[] bytes242 = BitConverter.GetBytes(msgType);
					byte[] bytes243 = BitConverter.GetBytes(number);
					byte[] bytes244 = BitConverter.GetBytes((int)number2);
					num2 += bytes243.Length + bytes244.Length;
					byte[] bytes245 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes245, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes242, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes243, 0, NetMessage.buffer[num].writeBuffer, num3, bytes243.Length);
					num3 += 4;
					Buffer.BlockCopy(bytes244, 0, NetMessage.buffer[num].writeBuffer, num3, bytes244.Length);
				}
				else if (msgType == 60)
				{
					byte[] bytes246 = BitConverter.GetBytes(msgType);
					byte[] bytes247 = BitConverter.GetBytes((short)number);
					byte[] bytes248 = BitConverter.GetBytes((short)number2);
					byte[] bytes249 = BitConverter.GetBytes((short)number3);
					byte b90 = (byte)number4;
					num2 += bytes247.Length + bytes248.Length + bytes249.Length + 1;
					byte[] bytes250 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes250, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes246, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes247, 0, NetMessage.buffer[num].writeBuffer, num3, bytes247.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes248, 0, NetMessage.buffer[num].writeBuffer, num3, bytes248.Length);
					num3 += 2;
					Buffer.BlockCopy(bytes249, 0, NetMessage.buffer[num].writeBuffer, num3, bytes249.Length);
					num3 += 2;
					NetMessage.buffer[num].writeBuffer[num3] = b90;
					num3++;
				}
				else if (msgType == 61)
				{
					byte[] bytes251 = BitConverter.GetBytes(msgType);
					byte[] bytes252 = BitConverter.GetBytes(number);
					byte[] bytes253 = BitConverter.GetBytes((int)number2);
					num2 += bytes252.Length + bytes253.Length;
					byte[] bytes254 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes254, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes251, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes252, 0, NetMessage.buffer[num].writeBuffer, num3, bytes252.Length);
					num3 += bytes252.Length;
					Buffer.BlockCopy(bytes253, 0, NetMessage.buffer[num].writeBuffer, num3, bytes253.Length);
				}
				else if (msgType == 62)
				{
					byte[] bytes255 = BitConverter.GetBytes(msgType);
					byte[] bytes256 = BitConverter.GetBytes(number);
					byte[] bytes257 = BitConverter.GetBytes((int)number2);
					num2 += bytes256.Length + bytes257.Length;
					byte[] bytes258 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes258, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes255, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes256, 0, NetMessage.buffer[num].writeBuffer, num3, bytes256.Length);
					num3 += bytes256.Length;
					Buffer.BlockCopy(bytes257, 0, NetMessage.buffer[num].writeBuffer, num3, bytes257.Length);
				}
				else if (msgType == 63)
				{
					byte[] bytes259 = BitConverter.GetBytes(msgType);
					byte[] bytes260 = BitConverter.GetBytes(number);
					byte[] bytes261 = BitConverter.GetBytes((int)number2);
					byte b91 = (byte)number3;
					num2 += bytes260.Length + bytes261.Length + 1;
					byte[] bytes262 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes262, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes259, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes260, 0, NetMessage.buffer[num].writeBuffer, num3, bytes260.Length);
					num3 += bytes260.Length;
					Buffer.BlockCopy(bytes261, 0, NetMessage.buffer[num].writeBuffer, num3, bytes261.Length);
					num3 += bytes261.Length;
					NetMessage.buffer[num].writeBuffer[num3] = b91;
					num3++;
				}
				else if (msgType == 64)
				{
					byte[] bytes263 = BitConverter.GetBytes(msgType);
					byte[] bytes264 = BitConverter.GetBytes(number);
					byte[] bytes265 = BitConverter.GetBytes((int)number2);
					byte b92 = (byte)number3;
					num2 += bytes264.Length + bytes265.Length + 1;
					byte[] bytes266 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes266, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes263, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					Buffer.BlockCopy(bytes264, 0, NetMessage.buffer[num].writeBuffer, num3, bytes264.Length);
					num3 += bytes264.Length;
					Buffer.BlockCopy(bytes265, 0, NetMessage.buffer[num].writeBuffer, num3, bytes265.Length);
					num3 += bytes265.Length;
					NetMessage.buffer[num].writeBuffer[num3] = b92;
					num3++;
				}
				else if (msgType == 65)
				{
					byte[] bytes267 = BitConverter.GetBytes(msgType);
					byte b93 = 0;
					byte[] bytes268 = BitConverter.GetBytes((short)number2);
					byte[] bytes269 = BitConverter.GetBytes(number3);
					byte[] bytes270 = BitConverter.GetBytes(number4);
					if ((number & 1) == 1)
					{
						b93 = (byte)(b93 + 1);
					}
					if ((number & 2) == 2)
					{
						b93 = (byte)(b93 + 2);
					}
					if ((number5 & 1) == 1)
					{
						b93 = (byte)(b93 + 4);
					}
					if ((number5 & 2) == 2)
					{
						b93 = (byte)(b93 + 8);
					}
					num2 += 1 + bytes268.Length + bytes269.Length + bytes270.Length;
					byte[] bytes271 = BitConverter.GetBytes(num2 - 4);
					Buffer.BlockCopy(bytes271, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
					Buffer.BlockCopy(bytes267, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					NetMessage.buffer[num].writeBuffer[num3] = b93;
					num3++;
					Buffer.BlockCopy(bytes268, 0, NetMessage.buffer[num].writeBuffer, num3, bytes268.Length);
					num3 += bytes268.Length;
					Buffer.BlockCopy(bytes269, 0, NetMessage.buffer[num].writeBuffer, num3, bytes269.Length);
					num3 += bytes269.Length;
					Buffer.BlockCopy(bytes270, 0, NetMessage.buffer[num].writeBuffer, num3, bytes270.Length);
					num3 += bytes270.Length;
				}
				else if (msgType != 67)
				{
					if (msgType == 68)
					{
						byte[] bytes272 = BitConverter.GetBytes(msgType);
						byte[] bytes273 = Encoding.UTF8.GetBytes(Main.clientUUID);
						num2 += bytes273.Length;
						byte[] bytes274 = BitConverter.GetBytes(num2 - 4);
						Buffer.BlockCopy(bytes274, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
						Buffer.BlockCopy(bytes272, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
						Buffer.BlockCopy(bytes273, 0, NetMessage.buffer[num].writeBuffer, 5, bytes273.Length);
					}
					else if (msgType == 69)
					{
						byte[] bytes275 = BitConverter.GetBytes(msgType);
						byte[] bytes276 = BitConverter.GetBytes((short)number);
						byte[] bytes277 = BitConverter.GetBytes((short)number2);
						byte[] bytes278 = BitConverter.GetBytes((short)number3);
						Netplay.GetSectionX((int)number2);
						Netplay.GetSectionY((int)number3);
						Buffer.BlockCopy(bytes276, 0, NetMessage.buffer[num].writeBuffer, num3, bytes276.Length);
						num3 += bytes276.Length;
						Buffer.BlockCopy(bytes277, 0, NetMessage.buffer[num].writeBuffer, num3, bytes277.Length);
						num3 += bytes277.Length;
						Buffer.BlockCopy(bytes278, 0, NetMessage.buffer[num].writeBuffer, num3, bytes278.Length);
						num3 += bytes278.Length;
						num2 += bytes276.Length + bytes277.Length + bytes278.Length;
						byte b94 = (byte)text.Length;
						byte[] bytes279 = Encoding.UTF8.GetBytes(text);
						NetMessage.buffer[num].writeBuffer[num3] = b94;
						num3++;
						Buffer.BlockCopy(bytes279, 0, NetMessage.buffer[num].writeBuffer, num3, bytes279.Length);
						num3 += bytes279.Length;
						num2 += 1 + bytes279.Length;
						byte[] bytes280 = BitConverter.GetBytes(num2 - 4);
						Buffer.BlockCopy(bytes280, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
						Buffer.BlockCopy(bytes275, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
					}
					else if (msgType == 70)
					{
						byte[] bytes281 = BitConverter.GetBytes(msgType);
						byte[] bytes282 = BitConverter.GetBytes((short)number);
						num2 += bytes282.Length;
						byte[] bytes283 = BitConverter.GetBytes(num2 - 4);
						Buffer.BlockCopy(bytes283, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
						Buffer.BlockCopy(bytes281, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
						Buffer.BlockCopy(bytes282, 0, NetMessage.buffer[num].writeBuffer, num3, bytes282.Length);
						num3 += bytes282.Length;
					}
					else if (msgType == 71)
					{
						byte[] bytes284 = BitConverter.GetBytes(msgType);
						byte[] bytes285 = BitConverter.GetBytes(number);
						byte[] bytes286 = BitConverter.GetBytes((int)number2);
						byte[] bytes287 = BitConverter.GetBytes((short)number3);
						byte b95 = (byte)number4;
						num2 += bytes285.Length + bytes286.Length + bytes287.Length + 1;
						byte[] bytes288 = BitConverter.GetBytes(num2 - 4);
						Buffer.BlockCopy(bytes288, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
						Buffer.BlockCopy(bytes284, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
						Buffer.BlockCopy(bytes285, 0, NetMessage.buffer[num].writeBuffer, num3, bytes285.Length);
						num3 += bytes285.Length;
						Buffer.BlockCopy(bytes286, 0, NetMessage.buffer[num].writeBuffer, num3, bytes286.Length);
						num3 += bytes286.Length;
						Buffer.BlockCopy(bytes287, 0, NetMessage.buffer[num].writeBuffer, num3, bytes287.Length);
						num3 += bytes287.Length;
						NetMessage.buffer[num].writeBuffer[num3] = b95;
						num3++;
					}
					else if (msgType == 72)
					{
						byte[] bytes289 = BitConverter.GetBytes(msgType);
						num2 += Chest.maxItems * 4;
						byte[] bytes290 = BitConverter.GetBytes(num2 - 4);
						Buffer.BlockCopy(bytes290, 0, NetMessage.buffer[num].writeBuffer, 0, 4);
						Buffer.BlockCopy(bytes289, 0, NetMessage.buffer[num].writeBuffer, 4, 1);
						for (int num10 = 0; num10 < Chest.maxItems; num10++)
						{
							byte[] bytes291 = BitConverter.GetBytes((short)Main.travelShop[num10]);
							Buffer.BlockCopy(bytes291, 0, NetMessage.buffer[num].writeBuffer, num3, bytes291.Length);
							num3 += 2;
						}
					}
				}
				if (Main.netMode == 1)
				{
					if (!Netplay.clientSock.tcpClient.Connected)
					{
						goto IL_5E67;
					}
					try
					{
						NetMessage.buffer[num].spamCount++;
						Main.txMsg++;
						Main.txData += num2;
						Main.txMsgType[msgType]++;
						Main.txDataType[msgType] += num2;
						Netplay.clientSock.networkStream.BeginWrite(NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.clientSock.ClientWriteCallBack), Netplay.clientSock.networkStream);
						goto IL_5E67;
					}
					catch
					{
						goto IL_5E67;
					}
				}
				if (remoteClient == -1)
				{
					if (msgType == 34 || msgType == 69)
					{
						for (int num11 = 0; num11 < 256; num11++)
						{
							if (num11 != ignoreClient && NetMessage.buffer[num11].broadcast && Netplay.serverSock[num11].tcpClient.Connected)
							{
								try
								{
									NetMessage.buffer[num11].spamCount++;
									Main.txMsg++;
									Main.txData += num2;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num2;
									SendBytes(Netplay.serverSock[num11], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num11].ServerWriteCallBack), Netplay.serverSock[num11].networkStream);
								}
								catch
								{
								}
							}
						}
					}
					else if (msgType == 20)
					{
						for (int num12 = 0; num12 < 256; num12++)
						{
							if (num12 != ignoreClient && (NetMessage.buffer[num12].broadcast || (Netplay.serverSock[num12].state >= 3 && msgType == 10)) && Netplay.serverSock[num12].tcpClient.Connected && Netplay.serverSock[num12].SectionRange(number, (int)number2, (int)number3))
							{
								try
								{
									NetMessage.buffer[num12].spamCount++;
									Main.txMsg++;
									Main.txData += num2;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num2;
									SendBytes(Netplay.serverSock[num12], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num12].ServerWriteCallBack), Netplay.serverSock[num12].networkStream);
								}
								catch
								{
								}
							}
						}
					}
					else if (msgType == 23)
					{
						for (int num13 = 0; num13 < 256; num13++)
						{
							if (num13 != ignoreClient && (NetMessage.buffer[num13].broadcast || (Netplay.serverSock[num13].state >= 3 && msgType == 10)) && Netplay.serverSock[num13].tcpClient.Connected)
							{
								bool flag2 = false;
								if (Main.npc[number].boss || Main.npc[number].netAlways || Main.npc[number].townNPC || !Main.npc[number].active)
								{
									flag2 = true;
								}
								else if (Main.npc[number].netSkip <= 0)
								{
									Rectangle rectangle = new Rectangle((int)Main.player[num13].position.X, (int)Main.player[num13].position.Y, Main.player[num13].width, Main.player[num13].height);
									Rectangle value2 = new Rectangle((int)Main.npc[number].position.X, (int)Main.npc[number].position.Y, Main.npc[number].width, Main.npc[number].height);
									value2.X -= 2500;
									value2.Y -= 2500;
									value2.Width += 5000;
									value2.Height += 5000;
									if (rectangle.Intersects(value2))
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
										NetMessage.buffer[num13].spamCount++;
										Main.txMsg++;
										Main.txData += num2;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num2;
										SendBytes(Netplay.serverSock[num13], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num13].ServerWriteCallBack), Netplay.serverSock[num13].networkStream);
									}
									catch
									{
									}
								}
							}
						}
						Main.npc[number].netSkip++;
						if (Main.npc[number].netSkip > 4)
						{
							Main.npc[number].netSkip = 0;
						}
					}
					else if (msgType == 28)
					{
						for (int num14 = 0; num14 < 256; num14++)
						{
							if (num14 != ignoreClient && (NetMessage.buffer[num14].broadcast || (Netplay.serverSock[num14].state >= 3 && msgType == 10)) && Netplay.serverSock[num14].tcpClient.Connected)
							{
								bool flag3 = false;
								if (Main.npc[number].life <= 0)
								{
									flag3 = true;
								}
								else
								{
									Rectangle rectangle2 = new Rectangle((int)Main.player[num14].position.X, (int)Main.player[num14].position.Y, Main.player[num14].width, Main.player[num14].height);
									Rectangle value3 = new Rectangle((int)Main.npc[number].position.X, (int)Main.npc[number].position.Y, Main.npc[number].width, Main.npc[number].height);
									value3.X -= 3000;
									value3.Y -= 3000;
									value3.Width += 6000;
									value3.Height += 6000;
									if (rectangle2.Intersects(value3))
									{
										flag3 = true;
									}
								}
								if (flag3)
								{
									try
									{
										NetMessage.buffer[num14].spamCount++;
										Main.txMsg++;
										Main.txData += num2;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num2;
										SendBytes(Netplay.serverSock[num14], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num14].ServerWriteCallBack), Netplay.serverSock[num14].networkStream);
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
						for (int num15 = 0; num15 < 256; num15++)
						{
							if (num15 != ignoreClient && (NetMessage.buffer[num15].broadcast || (Netplay.serverSock[num15].state >= 3 && msgType == 10)) && Netplay.serverSock[num15].tcpClient.Connected)
							{
								bool flag4 = true;
								if (flag4)
								{
									try
									{
										NetMessage.buffer[num15].spamCount++;
										Main.txMsg++;
										Main.txData += num2;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num2;
										SendBytes(Netplay.serverSock[num15], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num15].ServerWriteCallBack), Netplay.serverSock[num15].networkStream);
									}
									catch
									{
									}
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
						for (int num16 = 0; num16 < 256; num16++)
						{
							if (num16 != ignoreClient && (NetMessage.buffer[num16].broadcast || (Netplay.serverSock[num16].state >= 3 && msgType == 10)) && Netplay.serverSock[num16].tcpClient.Connected)
							{
								bool flag5 = false;
								if (Main.projectile[number].type == 12 || Main.projPet[Main.projectile[number].type] || Main.projectile[number].aiStyle == 11 || Main.projPet[Main.projectile[number].type] || Main.projectile[number].netImportant)
								{
									flag5 = true;
								}
								else
								{
									Rectangle rectangle3 = new Rectangle((int)Main.player[num16].position.X, (int)Main.player[num16].position.Y, Main.player[num16].width, Main.player[num16].height);
									Rectangle value4 = new Rectangle((int)Main.projectile[number].position.X, (int)Main.projectile[number].position.Y, Main.projectile[number].width, Main.projectile[number].height);
									value4.X -= 5000;
									value4.Y -= 5000;
									value4.Width += 10000;
									value4.Height += 10000;
									if (rectangle3.Intersects(value4))
									{
										flag5 = true;
									}
								}
								if (flag5)
								{
									try
									{
										NetMessage.buffer[num16].spamCount++;
										Main.txMsg++;
										Main.txData += num2;
										Main.txMsgType[msgType]++;
										Main.txDataType[msgType] += num2;
										SendBytes(Netplay.serverSock[num16], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num16].ServerWriteCallBack), Netplay.serverSock[num16].networkStream);
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
						for (int num17 = 0; num17 < 256; num17++)
						{
							if (num17 != ignoreClient && (NetMessage.buffer[num17].broadcast || (Netplay.serverSock[num17].state >= 3 && msgType == 10)) && Netplay.serverSock[num17].tcpClient.Connected)
							{
								try
								{
									NetMessage.buffer[num17].spamCount++;
									Main.txMsg++;
									Main.txData += num2;
									Main.txMsgType[msgType]++;
									Main.txDataType[msgType] += num2;
									SendBytes(Netplay.serverSock[num17], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[num17].ServerWriteCallBack), Netplay.serverSock[num17].networkStream);
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
						Main.txData += num2;
						Main.txMsgType[msgType]++;
						Main.txDataType[msgType] += num2;
						SendBytes(Netplay.serverSock[remoteClient], NetMessage.buffer[num].writeBuffer, 0, num2, new AsyncCallback(Netplay.serverSock[remoteClient].ServerWriteCallBack), Netplay.serverSock[remoteClient].networkStream);
					}
					catch
					{
					}
				}
				IL_5E67:
				if (Main.verboseNetplay)
				{
					for (int num18 = 0; num18 < num2; num18++)
					{
					}
					for (int num19 = 0; num19 < num2; num19++)
					{
						byte arg_5E9E_0 = NetMessage.buffer[num].writeBuffer[num19];
					}
				}
				NetMessage.buffer[num].writeLocked = false;
				if (msgType == 19 && Main.netMode == 1)
				{
					int size = 5;
					NetMessage.SendTileSquare(num, (int)number2, (int)number3, size);
				}
				if (msgType == 2 && Main.netMode == 2)
				{
					Netplay.serverSock[num].kill = true;
				}
			}}
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
						num2 = (short)(num2 + 1);
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
									b = (byte)(b | 128);
									array2[num3] = (byte)(((int)num2 & 65280) >> 8);
									num3++;
								}
								else
								{
									b = (byte)(b | 64);
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
							b = (byte)(b | 2);
							array2[num3] = (byte)tile2.type;
							num3++;
							if (tile2.type > 255)
							{
								array2[num3] = (byte)(tile2.type >> 8);
								num3++;
								b = (byte)(b | 32);
							}
							if (tile2.type == 21 && packChests && tile2.frameX % 36 == 0 && tile2.frameY % 36 == 0)
							{
								short num5 = (short)Chest.FindChest(j, i);
								if (num5 != -1)
								{
									array[(int)num] = num5;
									num = (short)(num + 1);
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
								b3 = (byte)(b3 | 8);
								array2[num3] = tile2.color();
								num3++;
							}
						}
						if (tile2.wall != 0)
						{
							b = (byte)(b | 4);
							array2[num3] = tile2.wall;
							num3++;
							if (tile2.wallColor() != 0)
							{
								b3 = (byte)(b3 | 16);
								array2[num3] = tile2.wallColor();
								num3++;
							}
						}
						if (tile2.liquid != 0)
						{
							if (tile2.lava())
							{
								b = (byte)(b | 16);
							}
							else if (tile2.honey())
							{
								b = (byte)(b | 24);
							}
							else
							{
								b = (byte)(b | 8);
							}
							array2[num3] = tile2.liquid;
							num3++;
						}
						if (tile2.wire())
						{
							b2 = (byte)(b2 | 2);
						}
						if (tile2.wire2())
						{
							b2 = (byte)(b2 | 4);
						}
						if (tile2.wire3())
						{
							b2 = (byte)(b2 | 8);
						}
						int num6;
						if (tile2.halfBrick())
						{
							num6 = 16;
						}
						else if (tile2.slope() != 0)
						{
							num6 = tile2.slope() + 1 << 4;
						}
						else
						{
							num6 = 0;
						}
						b2 = (byte)(b2 | (byte)num6);
						if (tile2.actuator())
						{
							b3 = (byte)(b3 | 2);
						}
						if (tile2.inActive())
						{
							b3 = (byte)(b3 | 4);
						}
						num4 = 2;
						if (b3 != 0)
						{
							b2 = (byte)(b2 | 1);
							array2[num4] = b3;
							num4--;
						}
						if (b2 != 0)
						{
							b = (byte)(b | 1);
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
					b = (byte)(b | 128);
					array2[num3] = (byte)(((int)num2 & 65280) >> 8);
					num3++;
				}
				else
				{
					b = (byte)(b | 64);
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
			lock (NetMessage.buffer[i])
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
			lock (NetMessage.buffer[i])
			{
				int num = 0;
				if (NetMessage.buffer[i].totalData >= 4)
				{
					if (NetMessage.buffer[i].messageLength == 0)
					{
						NetMessage.buffer[i].messageLength = BitConverter.ToInt32(NetMessage.buffer[i].readBuffer, 0) + 4;
					}
					while (NetMessage.buffer[i].totalData >= NetMessage.buffer[i].messageLength + num && NetMessage.buffer[i].messageLength > 0)
					{
						if (!Main.ignoreErrors)
						{
							NetMessage.buffer[i].GetData(num + 4, NetMessage.buffer[i].messageLength - 4);
						}
						else
						{
							try
							{
								NetMessage.buffer[i].GetData(num + 4, NetMessage.buffer[i].messageLength - 4);
							}
							catch
							{
							}
						}
						num += NetMessage.buffer[i].messageLength;
						if (NetMessage.buffer[i].totalData - num >= 4)
						{
							NetMessage.buffer[i].messageLength = BitConverter.ToInt32(NetMessage.buffer[i].readBuffer, num) + 4;
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
			if (Main.autoShutdown && !flag)
			{
				WorldFile.saveWorld(false);
				Netplay.disconnect = true;
			}
		}
	}
}
