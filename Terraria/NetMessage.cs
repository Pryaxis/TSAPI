namespace Terraria
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using Hooks;

    public class NetMessage
    {
        public static messageBuffer[] buffer = new messageBuffer[0x101];

        public static void BootPlayer(int plr, string msg)
        {
            SendData(2, plr, -1, msg, 0, 0f, 0f, 0f, 0);
        }

        public static void CheckBytes(int i = 0x100)
        {
            lock (buffer[i])
            {
                int startIndex = 0;
                if (buffer[i].totalData >= 4)
                {
                    if (buffer[i].messageLength == 0)
                    {
                        buffer[i].messageLength = BitConverter.ToInt32(buffer[i].readBuffer, 0) + 4;
                    }
                    while ((buffer[i].totalData >= (buffer[i].messageLength + startIndex)) && (buffer[i].messageLength > 0))
                    {
                        if (!Main.ignoreErrors)
                        {
                            buffer[i].GetData(startIndex + 4, buffer[i].messageLength - 4);
                        }
                        else
                        {
                            try
                            {
                                buffer[i].GetData(startIndex + 4, buffer[i].messageLength - 4);
                            }
                            catch
                            {
                            }
                        }
                        startIndex += buffer[i].messageLength;
                        if ((buffer[i].totalData - startIndex) >= 4)
                        {
                            buffer[i].messageLength = BitConverter.ToInt32(buffer[i].readBuffer, startIndex) + 4;
                        }
                        else
                        {
                            buffer[i].messageLength = 0;
                        }
                    }
                    if (startIndex == buffer[i].totalData)
                    {
                        buffer[i].totalData = 0;
                    }
                    else if (startIndex > 0)
                    {
                        Buffer.BlockCopy(buffer[i].readBuffer, startIndex, buffer[i].readBuffer, 0, buffer[i].totalData - startIndex);
                        messageBuffer buffer1 = buffer[i];
                        buffer1.totalData -= startIndex;
                    }
                    buffer[i].checkBytes = false;
                }
            }
        }

        public static void greetPlayer(int plr)
        {
            if (Main.motd == "")
            {
                SendData(0x19, plr, -1, "Welcome to " + Main.worldName + "!", 0xff, 255f, 240f, 20f, 0);
            }
            else
            {
                SendData(0x19, plr, -1, Main.motd, 0xff, 255f, 240f, 20f, 0);
            }
            string str = "";
            for (int i = 0; i < 0xff; i++)
            {
                if (Main.player[i].active)
                {
                    if (str == "")
                    {
                        str = str + Main.player[i].name;
                    }
                    else
                    {
                        str = str + ", " + Main.player[i].name;
                    }
                }
            }
            SendData(0x19, plr, -1, "Current players: " + str + ".", 0xff, 255f, 240f, 20f, 0);
        }

        public static void RecieveBytes(byte[] bytes, int streamLength, int i = 0x100)
        {
            lock (buffer[i])
            {
                try
                {
                    Buffer.BlockCopy(bytes, 0, buffer[i].readBuffer, buffer[i].totalData, streamLength);
                    messageBuffer buffer1 = buffer[i];
                    buffer1.totalData += streamLength;
                    buffer[i].checkBytes = true;
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

        public static void SendBytes(ServerSock sock, byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            if (NetHooks.OnSendBytes(sock, buffer, offset, count))
            {
                return;
            }
            sock.networkStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public static void SendData(int msgType, int remoteClient = -1, int ignoreClient = -1, string text = "", int number = 0, float number2 = 0f, float number3 = 0f, float number4 = 0f, int number5 = 0)
        {
            int index = 0x100;
            if ((Main.netMode == 2) && (remoteClient >= 0))
            {
                index = remoteClient;
            }
            lock (buffer[index])
            {
                if (!NetHooks.OnSendData(ref msgType, ref remoteClient, ref ignoreClient, ref text, ref number, ref number2, ref number3, ref number4, ref number5))
                {
                    int count = 5;
                    int num3 = count;
                    if (msgType == 1)
                    {
                        byte[] bytes = BitConverter.GetBytes(msgType);
                        byte[] src = Encoding.ASCII.GetBytes("Terraria" + Main.curRelease);
                        count += src.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(bytes, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(src, 0, buffer[index].writeBuffer, 5, src.Length);
                    }
                    else if (msgType == 2)
                    {
                        byte[] buffer4 = BitConverter.GetBytes(msgType);
                        byte[] buffer5 = Encoding.ASCII.GetBytes(text);
                        count += buffer5.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer4, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer5, 0, buffer[index].writeBuffer, 5, buffer5.Length);
                        if (Main.dedServ)
                        {
                            Console.WriteLine(Netplay.serverSock[index].tcpClient.Client.RemoteEndPoint.ToString() + " was booted: " + text);
                        }
                    }
                    else if (msgType == 3)
                    {
                        byte[] buffer7 = BitConverter.GetBytes(msgType);
                        byte[] buffer8 = BitConverter.GetBytes(remoteClient);
                        count += buffer8.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer7, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer8, 0, buffer[index].writeBuffer, 5, buffer8.Length);
                    }
                    else if (msgType == 4)
                    {
                        byte[] buffer10 = BitConverter.GetBytes(msgType);
                        byte num4 = (byte) number;
                        byte hair = (byte) Main.player[num4].hair;
                        byte num6 = 0;
                        if (Main.player[num4].male)
                        {
                            num6 = 1;
                        }
                        byte[] buffer11 = Encoding.ASCII.GetBytes(text);
                        count += (0x18 + buffer11.Length) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer10, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num4;
                        num3++;
                        buffer[index].writeBuffer[6] = hair;
                        num3++;
                        buffer[index].writeBuffer[7] = num6;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].hairColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].hairColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].hairColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].skinColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].skinColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].skinColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].eyeColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].eyeColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].eyeColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].shirtColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].shirtColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].shirtColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].underShirtColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].underShirtColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].underShirtColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].pantsColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].pantsColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].pantsColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].shoeColor.R;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].shoeColor.G;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].shoeColor.B;
                        num3++;
                        buffer[index].writeBuffer[num3] = Main.player[num4].difficulty;
                        num3++;
                        Buffer.BlockCopy(buffer11, 0, buffer[index].writeBuffer, num3, buffer11.Length);
                    }
                    else if (msgType == 5)
                    {
                        byte stack;
                        byte[] buffer14;
                        byte[] buffer13 = BitConverter.GetBytes(msgType);
                        byte num7 = (byte) number;
                        byte num8 = (byte) number2;
                        if (number2 < 49f)
                        {
                            if (((Main.player[number].inventory[(int) number2].name == "") || (Main.player[number].inventory[(int) number2].stack == 0)) || (Main.player[number].inventory[(int) number2].type == 0))
                            {
                                Main.player[number].inventory[(int) number2].netID = 0;
                            }
                            stack = (byte) Main.player[number].inventory[(int) number2].stack;
                            buffer14 = BitConverter.GetBytes((short) Main.player[number].inventory[(int) number2].netID);
                            if (Main.player[number].inventory[(int) number2].stack < 0)
                            {
                                stack = 0;
                            }
                        }
                        else
                        {
                            if (((Main.player[number].armor[(((int) number2) - 0x30) - 1].name == "") || (Main.player[number].armor[(((int) number2) - 0x30) - 1].stack == 0)) || (Main.player[number].armor[(((int) number2) - 0x30) - 1].type == 0))
                            {
                                Main.player[number].armor[(((int) number2) - 0x30) - 1].SetDefaults(0, false);
                            }
                            stack = (byte) Main.player[number].armor[(((int) number2) - 0x30) - 1].stack;
                            buffer14 = BitConverter.GetBytes((short) Main.player[number].armor[(((int) number2) - 0x30) - 1].netID);
                            if (Main.player[number].armor[(((int) number2) - 0x30) - 1].stack < 0)
                            {
                                stack = 0;
                            }
                        }
                        byte num10 = (byte) number3;
                        count += 4 + buffer14.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer13, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num7;
                        num3++;
                        buffer[index].writeBuffer[6] = num8;
                        num3++;
                        buffer[index].writeBuffer[7] = stack;
                        num3++;
                        buffer[index].writeBuffer[8] = num10;
                        num3++;
                        Buffer.BlockCopy(buffer14, 0, buffer[index].writeBuffer, num3, buffer14.Length);
                    }
                    else if (msgType == 6)
                    {
                        byte[] buffer16 = BitConverter.GetBytes(msgType);
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer16, 0, buffer[index].writeBuffer, 4, 1);
                    }
                    else if (msgType == 7)
                    {
                        byte[] buffer18 = BitConverter.GetBytes(msgType);
                        byte[] buffer19 = BitConverter.GetBytes((int) Main.time);
                        byte num11 = 0;
                        if (Main.dayTime)
                        {
                            num11 = 1;
                        }
                        byte moonPhase = (byte) Main.moonPhase;
                        byte num13 = 0;
                        if (Main.bloodMoon)
                        {
                            num13 = 1;
                        }
                        byte[] buffer20 = BitConverter.GetBytes(Main.maxTilesX);
                        byte[] buffer21 = BitConverter.GetBytes(Main.maxTilesY);
                        byte[] buffer22 = BitConverter.GetBytes(Main.spawnTileX);
                        byte[] buffer23 = BitConverter.GetBytes(Main.spawnTileY);
                        byte[] buffer24 = BitConverter.GetBytes((int) Main.worldSurface);
                        byte[] buffer25 = BitConverter.GetBytes((int) Main.rockLayer);
                        byte[] buffer26 = BitConverter.GetBytes(Main.worldID);
                        byte[] buffer27 = Encoding.ASCII.GetBytes(Main.worldName);
                        byte num14 = 0;
                        if (WorldGen.shadowOrbSmashed)
                        {
                            num14 = (byte) (num14 + 1);
                        }
                        if (NPC.downedBoss1)
                        {
                            num14 = (byte) (num14 + 2);
                        }
                        if (NPC.downedBoss2)
                        {
                            num14 = (byte) (num14 + 4);
                        }
                        if (NPC.downedBoss3)
                        {
                            num14 = (byte) (num14 + 8);
                        }
                        if (Main.hardMode)
                        {
                            num14 = (byte) (num14 + 0x10);
                        }
                        if (NPC.downedClown)
                        {
                            num14 = (byte) (num14 + 0x20);
                        }
                        count += (((((((((((buffer19.Length + 1) + 1) + 1) + buffer20.Length) + buffer21.Length) + buffer22.Length) + buffer23.Length) + buffer24.Length) + buffer25.Length) + buffer26.Length) + 1) + buffer27.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer18, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer19, 0, buffer[index].writeBuffer, 5, buffer19.Length);
                        num3 += buffer19.Length;
                        buffer[index].writeBuffer[num3] = num11;
                        num3++;
                        buffer[index].writeBuffer[num3] = moonPhase;
                        num3++;
                        buffer[index].writeBuffer[num3] = num13;
                        num3++;
                        Buffer.BlockCopy(buffer20, 0, buffer[index].writeBuffer, num3, buffer20.Length);
                        num3 += buffer20.Length;
                        Buffer.BlockCopy(buffer21, 0, buffer[index].writeBuffer, num3, buffer21.Length);
                        num3 += buffer21.Length;
                        Buffer.BlockCopy(buffer22, 0, buffer[index].writeBuffer, num3, buffer22.Length);
                        num3 += buffer22.Length;
                        Buffer.BlockCopy(buffer23, 0, buffer[index].writeBuffer, num3, buffer23.Length);
                        num3 += buffer23.Length;
                        Buffer.BlockCopy(buffer24, 0, buffer[index].writeBuffer, num3, buffer24.Length);
                        num3 += buffer24.Length;
                        Buffer.BlockCopy(buffer25, 0, buffer[index].writeBuffer, num3, buffer25.Length);
                        num3 += buffer25.Length;
                        Buffer.BlockCopy(buffer26, 0, buffer[index].writeBuffer, num3, buffer26.Length);
                        num3 += buffer26.Length;
                        buffer[index].writeBuffer[num3] = num14;
                        num3++;
                        Buffer.BlockCopy(buffer27, 0, buffer[index].writeBuffer, num3, buffer27.Length);
                        num3 += buffer27.Length;
                    }
                    else if (msgType == 8)
                    {
                        byte[] buffer29 = BitConverter.GetBytes(msgType);
                        byte[] buffer30 = BitConverter.GetBytes(number);
                        byte[] buffer31 = BitConverter.GetBytes((int) number2);
                        count += buffer30.Length + buffer31.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer29, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer30, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer31, 0, buffer[index].writeBuffer, num3, 4);
                    }
                    else if (msgType == 9)
                    {
                        byte[] buffer33 = BitConverter.GetBytes(msgType);
                        byte[] buffer34 = BitConverter.GetBytes(number);
                        byte[] buffer35 = Encoding.ASCII.GetBytes(text);
                        count += buffer34.Length + buffer35.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer33, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer34, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer35, 0, buffer[index].writeBuffer, num3, buffer35.Length);
                    }
                    else if (msgType == 10)
                    {
                        short num15 = (short) number;
                        int num16 = (int) number2;
                        int num17 = (int) number3;
                        Buffer.BlockCopy(BitConverter.GetBytes(msgType), 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(BitConverter.GetBytes(num15), 0, buffer[index].writeBuffer, num3, 2);
                        num3 += 2;
                        Buffer.BlockCopy(BitConverter.GetBytes(num16), 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(BitConverter.GetBytes(num17), 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        for (int i = num16; i < (num16 + num15); i++)
                        {
                            byte num19 = 0;
                            if (Main.tile[i, num17].active)
                            {
                                num19 = (byte) (num19 + 1);
                            }
                            if (Main.tile[i, num17].wall > 0)
                            {
                                num19 = (byte) (num19 + 4);
                            }
                            if (Main.tile[i, num17].liquid > 0)
                            {
                                num19 = (byte) (num19 + 8);
                            }
                            if (Main.tile[i, num17].wire)
                            {
                                num19 = (byte) (num19 + 0x10);
                            }
                            buffer[index].writeBuffer[num3] = num19;
                            num3++;
                            byte[] buffer41 = BitConverter.GetBytes(Main.tile[i, num17].frameX);
                            byte[] buffer42 = BitConverter.GetBytes(Main.tile[i, num17].frameY);
                            byte wall = Main.tile[i, num17].wall;
                            if (Main.tile[i, num17].active)
                            {
                                buffer[index].writeBuffer[num3] = Main.tile[i, num17].type;
                                num3++;
                                if (Main.tileFrameImportant[Main.tile[i, num17].type])
                                {
                                    Buffer.BlockCopy(buffer41, 0, buffer[index].writeBuffer, num3, 2);
                                    num3 += 2;
                                    Buffer.BlockCopy(buffer42, 0, buffer[index].writeBuffer, num3, 2);
                                    num3 += 2;
                                }
                            }
                            if (wall > 0)
                            {
                                buffer[index].writeBuffer[num3] = wall;
                                num3++;
                            }
                            if (Main.tile[i, num17].liquid > 0)
                            {
                                buffer[index].writeBuffer[num3] = Main.tile[i, num17].liquid;
                                num3++;
                                byte num21 = 0;
                                if (Main.tile[i, num17].lava)
                                {
                                    num21 = 1;
                                }
                                buffer[index].writeBuffer[num3] = num21;
                                num3++;
                            }
                            short num22 = 1;
                            while (((i + num22) < (num16 + num15)) && Main.tile[i, num17].isTheSameAs(Main.tile[i + num22, num17]))
                            {
                                num22 = (short) (num22 + 1);
                            }
                            num22 = (short) (num22 - 1);
                            Buffer.BlockCopy(BitConverter.GetBytes(num22), 0, buffer[index].writeBuffer, num3, 2);
                            num3 += 2;
                            i += num22;
                        }
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (num3 - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        count = num3;
                    }
                    else if (msgType == 11)
                    {
                        byte[] buffer45 = BitConverter.GetBytes(msgType);
                        byte[] buffer46 = BitConverter.GetBytes(number);
                        byte[] buffer47 = BitConverter.GetBytes((int) number2);
                        byte[] buffer48 = BitConverter.GetBytes((int) number3);
                        byte[] buffer49 = BitConverter.GetBytes((int) number4);
                        count += ((buffer46.Length + buffer47.Length) + buffer48.Length) + buffer49.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer45, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer46, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer47, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer48, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer49, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                    }
                    else if (msgType == 12)
                    {
                        byte[] buffer51 = BitConverter.GetBytes(msgType);
                        byte num23 = (byte) number;
                        byte[] buffer52 = BitConverter.GetBytes(Main.player[num23].SpawnX);
                        byte[] buffer53 = BitConverter.GetBytes(Main.player[num23].SpawnY);
                        count += (1 + buffer52.Length) + buffer53.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer51, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num23;
                        num3++;
                        Buffer.BlockCopy(buffer52, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer53, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                    }
                    else if (msgType == 13)
                    {
                        byte[] buffer55 = BitConverter.GetBytes(msgType);
                        byte num24 = (byte) number;
                        byte num25 = 0;
                        if (Main.player[num24].controlUp)
                        {
                            num25 = (byte) (num25 + 1);
                        }
                        if (Main.player[num24].controlDown)
                        {
                            num25 = (byte) (num25 + 2);
                        }
                        if (Main.player[num24].controlLeft)
                        {
                            num25 = (byte) (num25 + 4);
                        }
                        if (Main.player[num24].controlRight)
                        {
                            num25 = (byte) (num25 + 8);
                        }
                        if (Main.player[num24].controlJump)
                        {
                            num25 = (byte) (num25 + 0x10);
                        }
                        if (Main.player[num24].controlUseItem)
                        {
                            num25 = (byte) (num25 + 0x20);
                        }
                        if (Main.player[num24].direction == 1)
                        {
                            num25 = (byte) (num25 + 0x40);
                        }
                        byte selectedItem = (byte) Main.player[num24].selectedItem;
                        byte[] buffer56 = BitConverter.GetBytes(Main.player[number].position.X);
                        byte[] buffer57 = BitConverter.GetBytes(Main.player[number].position.Y);
                        byte[] buffer58 = BitConverter.GetBytes(Main.player[number].velocity.X);
                        byte[] buffer59 = BitConverter.GetBytes(Main.player[number].velocity.Y);
                        count += (((3 + buffer56.Length) + buffer57.Length) + buffer58.Length) + buffer59.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer55, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num24;
                        num3++;
                        buffer[index].writeBuffer[6] = num25;
                        num3++;
                        buffer[index].writeBuffer[7] = selectedItem;
                        num3++;
                        Buffer.BlockCopy(buffer56, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer57, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer58, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer59, 0, buffer[index].writeBuffer, num3, 4);
                    }
                    else if (msgType == 14)
                    {
                        byte[] buffer61 = BitConverter.GetBytes(msgType);
                        byte num27 = (byte) number;
                        byte num28 = (byte) number2;
                        count += 2;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer61, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num27;
                        buffer[index].writeBuffer[6] = num28;
                    }
                    else if (msgType == 15)
                    {
                        byte[] buffer63 = BitConverter.GetBytes(msgType);
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer63, 0, buffer[index].writeBuffer, 4, 1);
                    }
                    else if (msgType == 0x10)
                    {
                        byte[] buffer65 = BitConverter.GetBytes(msgType);
                        byte num29 = (byte) number;
                        byte[] buffer66 = BitConverter.GetBytes((short) Main.player[num29].statLife);
                        byte[] buffer67 = BitConverter.GetBytes((short) Main.player[num29].statLifeMax);
                        count += (1 + buffer66.Length) + buffer67.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer65, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num29;
                        num3++;
                        Buffer.BlockCopy(buffer66, 0, buffer[index].writeBuffer, num3, 2);
                        num3 += 2;
                        Buffer.BlockCopy(buffer67, 0, buffer[index].writeBuffer, num3, 2);
                    }
                    else if (msgType == 0x11)
                    {
                        byte[] buffer69 = BitConverter.GetBytes(msgType);
                        byte num30 = (byte) number;
                        byte[] buffer70 = BitConverter.GetBytes((int) number2);
                        byte[] buffer71 = BitConverter.GetBytes((int) number3);
                        byte num31 = (byte) number4;
                        count += (((1 + buffer70.Length) + buffer71.Length) + 1) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer69, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num30;
                        num3++;
                        Buffer.BlockCopy(buffer70, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer71, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        buffer[index].writeBuffer[num3] = num31;
                        num3++;
                        buffer[index].writeBuffer[num3] = (byte) number5;
                    }
                    else if (msgType == 0x12)
                    {
                        byte[] buffer73 = BitConverter.GetBytes(msgType);
                        BitConverter.GetBytes((int) Main.time);
                        byte num32 = 0;
                        if (Main.dayTime)
                        {
                            num32 = 1;
                        }
                        byte[] buffer74 = BitConverter.GetBytes((int) Main.time);
                        byte[] buffer75 = BitConverter.GetBytes(Main.sunModY);
                        byte[] buffer76 = BitConverter.GetBytes(Main.moonModY);
                        count += ((1 + buffer74.Length) + buffer75.Length) + buffer76.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer73, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num32;
                        num3++;
                        Buffer.BlockCopy(buffer74, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer75, 0, buffer[index].writeBuffer, num3, 2);
                        num3 += 2;
                        Buffer.BlockCopy(buffer76, 0, buffer[index].writeBuffer, num3, 2);
                        num3 += 2;
                    }
                    else if (msgType == 0x13)
                    {
                        byte[] buffer78 = BitConverter.GetBytes(msgType);
                        byte num33 = (byte) number;
                        byte[] buffer79 = BitConverter.GetBytes((int) number2);
                        byte[] buffer80 = BitConverter.GetBytes((int) number3);
                        byte num34 = 0;
                        if (number4 == 1f)
                        {
                            num34 = 1;
                        }
                        count += ((1 + buffer79.Length) + buffer80.Length) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer78, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num33;
                        num3++;
                        Buffer.BlockCopy(buffer79, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer80, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        buffer[index].writeBuffer[num3] = num34;
                    }
                    else if (msgType == 20)
                    {
                        short num35 = (short) number;
                        int num36 = (int) number2;
                        int num37 = (int) number3;
                        Buffer.BlockCopy(BitConverter.GetBytes(msgType), 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(BitConverter.GetBytes(num35), 0, buffer[index].writeBuffer, num3, 2);
                        num3 += 2;
                        Buffer.BlockCopy(BitConverter.GetBytes(num36), 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(BitConverter.GetBytes(num37), 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        for (int j = num36; j < (num36 + num35); j++)
                        {
                            for (int k = num37; k < (num37 + num35); k++)
                            {
                                byte num40 = 0;
                                if (Main.tile[j, k].active)
                                {
                                    num40 = (byte) (num40 + 1);
                                }
                                if (Main.tile[j, k].wall > 0)
                                {
                                    num40 = (byte) (num40 + 4);
                                }
                                if ((Main.tile[j, k].liquid > 0) && (Main.netMode == 2))
                                {
                                    num40 = (byte) (num40 + 8);
                                }
                                if (Main.tile[j, k].wire)
                                {
                                    num40 = (byte) (num40 + 0x10);
                                }
                                buffer[index].writeBuffer[num3] = num40;
                                num3++;
                                byte[] buffer86 = BitConverter.GetBytes(Main.tile[j, k].frameX);
                                byte[] buffer87 = BitConverter.GetBytes(Main.tile[j, k].frameY);
                                byte num41 = Main.tile[j, k].wall;
                                if (Main.tile[j, k].active)
                                {
                                    buffer[index].writeBuffer[num3] = Main.tile[j, k].type;
                                    num3++;
                                    if (Main.tileFrameImportant[Main.tile[j, k].type])
                                    {
                                        Buffer.BlockCopy(buffer86, 0, buffer[index].writeBuffer, num3, 2);
                                        num3 += 2;
                                        Buffer.BlockCopy(buffer87, 0, buffer[index].writeBuffer, num3, 2);
                                        num3 += 2;
                                    }
                                }
                                if (num41 > 0)
                                {
                                    buffer[index].writeBuffer[num3] = num41;
                                    num3++;
                                }
                                if ((Main.tile[j, k].liquid > 0) && (Main.netMode == 2))
                                {
                                    buffer[index].writeBuffer[num3] = Main.tile[j, k].liquid;
                                    num3++;
                                    byte num42 = 0;
                                    if (Main.tile[j, k].lava)
                                    {
                                        num42 = 1;
                                    }
                                    buffer[index].writeBuffer[num3] = num42;
                                    num3++;
                                }
                            }
                        }
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (num3 - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        count = num3;
                    }
                    else if (msgType == 0x15)
                    {
                        byte[] buffer89 = BitConverter.GetBytes(msgType);
                        byte[] buffer90 = BitConverter.GetBytes((short) number);
                        byte[] buffer91 = BitConverter.GetBytes(Main.item[number].position.X);
                        byte[] buffer92 = BitConverter.GetBytes(Main.item[number].position.Y);
                        byte[] buffer93 = BitConverter.GetBytes(Main.item[number].velocity.X);
                        byte[] buffer94 = BitConverter.GetBytes(Main.item[number].velocity.Y);
                        byte num43 = (byte) Main.item[number].stack;
                        byte prefix = Main.item[number].prefix;
                        short netID = 0;
                        if (Main.item[number].active && (Main.item[number].stack > 0))
                        {
                            netID = (short) Main.item[number].netID;
                        }
                        byte[] buffer95 = BitConverter.GetBytes(netID);
                        count += ((((((buffer90.Length + buffer91.Length) + buffer92.Length) + buffer93.Length) + buffer94.Length) + 1) + buffer95.Length) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer89, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer90, 0, buffer[index].writeBuffer, num3, buffer90.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer91, 0, buffer[index].writeBuffer, num3, buffer91.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer92, 0, buffer[index].writeBuffer, num3, buffer92.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer93, 0, buffer[index].writeBuffer, num3, buffer93.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer94, 0, buffer[index].writeBuffer, num3, buffer94.Length);
                        num3 += 4;
                        buffer[index].writeBuffer[num3] = num43;
                        num3++;
                        buffer[index].writeBuffer[num3] = prefix;
                        num3++;
                        Buffer.BlockCopy(buffer95, 0, buffer[index].writeBuffer, num3, buffer95.Length);
                    }
                    else if (msgType == 0x16)
                    {
                        byte[] buffer97 = BitConverter.GetBytes(msgType);
                        byte[] buffer98 = BitConverter.GetBytes((short) number);
                        byte owner = (byte) Main.item[number].owner;
                        count += buffer98.Length + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer97, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer98, 0, buffer[index].writeBuffer, num3, buffer98.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = owner;
                    }
                    else if (msgType == 0x17)
                    {
                        byte[] buffer100 = BitConverter.GetBytes(msgType);
                        byte[] buffer101 = BitConverter.GetBytes((short) number);
                        byte[] buffer102 = BitConverter.GetBytes(Main.npc[number].position.X);
                        byte[] buffer103 = BitConverter.GetBytes(Main.npc[number].position.Y);
                        byte[] buffer104 = BitConverter.GetBytes(Main.npc[number].velocity.X);
                        byte[] buffer105 = BitConverter.GetBytes(Main.npc[number].velocity.Y);
                        byte[] buffer106 = BitConverter.GetBytes((short) Main.npc[number].target);
                        byte[] buffer107 = BitConverter.GetBytes(Main.npc[number].life);
                        if (!Main.npc[number].active)
                        {
                            buffer107 = BitConverter.GetBytes(0);
                        }
                        if (!Main.npc[number].active || (Main.npc[number].life <= 0))
                        {
                            Main.npc[number].netSkip = 0;
                        }
                        if (Main.npc[number].name == null)
                        {
                            Main.npc[number].name = "";
                        }
                        byte[] buffer108 = BitConverter.GetBytes((short) Main.npc[number].netID);
                        count += (((((((((buffer101.Length + buffer102.Length) + buffer103.Length) + buffer104.Length) + buffer105.Length) + buffer106.Length) + buffer107.Length) + (NPC.maxAI*4)) + buffer108.Length) + 1) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer100, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer101, 0, buffer[index].writeBuffer, num3, buffer101.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer102, 0, buffer[index].writeBuffer, num3, buffer102.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer103, 0, buffer[index].writeBuffer, num3, buffer103.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer104, 0, buffer[index].writeBuffer, num3, buffer104.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer105, 0, buffer[index].writeBuffer, num3, buffer105.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer106, 0, buffer[index].writeBuffer, num3, buffer106.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = (byte) (Main.npc[number].direction + 1);
                        num3++;
                        buffer[index].writeBuffer[num3] = (byte) (Main.npc[number].directionY + 1);
                        num3++;
                        Buffer.BlockCopy(buffer107, 0, buffer[index].writeBuffer, num3, buffer107.Length);
                        num3 += 4;
                        for (int m = 0; m < NPC.maxAI; m++)
                        {
                            byte[] buffer110 = BitConverter.GetBytes(Main.npc[number].ai[m]);
                            Buffer.BlockCopy(buffer110, 0, buffer[index].writeBuffer, num3, buffer110.Length);
                            num3 += 4;
                        }
                        Buffer.BlockCopy(buffer108, 0, buffer[index].writeBuffer, num3, buffer108.Length);
                    }
                    else if (msgType == 0x18)
                    {
                        byte[] buffer111 = BitConverter.GetBytes(msgType);
                        byte[] buffer112 = BitConverter.GetBytes((short) number);
                        byte num48 = (byte) number2;
                        count += buffer112.Length + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer111, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer112, 0, buffer[index].writeBuffer, num3, buffer112.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = num48;
                    }
                    else if (msgType == 0x19)
                    {
                        byte[] buffer114 = BitConverter.GetBytes(msgType);
                        byte num49 = (byte) number;
                        byte[] buffer115 = Encoding.ASCII.GetBytes(text);
                        byte num50 = (byte) number2;
                        byte num51 = (byte) number3;
                        byte num52 = (byte) number4;
                        count += (1 + buffer115.Length) + 3;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer114, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num49;
                        num3++;
                        buffer[index].writeBuffer[num3] = num50;
                        num3++;
                        buffer[index].writeBuffer[num3] = num51;
                        num3++;
                        buffer[index].writeBuffer[num3] = num52;
                        num3++;
                        Buffer.BlockCopy(buffer115, 0, buffer[index].writeBuffer, num3, buffer115.Length);
                    }
                    else if (msgType == 0x1a)
                    {
                        byte[] buffer117 = BitConverter.GetBytes(msgType);
                        byte num53 = (byte) number;
                        byte num54 = (byte) (number2 + 1f);
                        byte[] buffer118 = BitConverter.GetBytes((short) number3);
                        byte[] buffer119 = Encoding.ASCII.GetBytes(text);
                        byte num55 = (byte) number4;
                        byte num56 = (byte) number5;
                        count += (((2 + buffer118.Length) + 1) + buffer119.Length) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer117, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num53;
                        num3++;
                        buffer[index].writeBuffer[num3] = num54;
                        num3++;
                        Buffer.BlockCopy(buffer118, 0, buffer[index].writeBuffer, num3, buffer118.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = num55;
                        num3++;
                        buffer[index].writeBuffer[num3] = num56;
                        num3++;
                        Buffer.BlockCopy(buffer119, 0, buffer[index].writeBuffer, num3, buffer119.Length);
                    }
                    else if (msgType == 0x1b)
                    {
                        byte[] buffer121 = BitConverter.GetBytes(msgType);
                        byte[] buffer122 = BitConverter.GetBytes((short) Main.projectile[number].identity);
                        byte[] buffer123 = BitConverter.GetBytes(Main.projectile[number].position.X);
                        byte[] buffer124 = BitConverter.GetBytes(Main.projectile[number].position.Y);
                        byte[] buffer125 = BitConverter.GetBytes(Main.projectile[number].velocity.X);
                        byte[] buffer126 = BitConverter.GetBytes(Main.projectile[number].velocity.Y);
                        byte[] buffer127 = BitConverter.GetBytes(Main.projectile[number].knockBack);
                        byte[] buffer128 = BitConverter.GetBytes((short) Main.projectile[number].damage);
                        Buffer.BlockCopy(buffer121, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer122, 0, buffer[index].writeBuffer, num3, buffer122.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer123, 0, buffer[index].writeBuffer, num3, buffer123.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer124, 0, buffer[index].writeBuffer, num3, buffer124.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer125, 0, buffer[index].writeBuffer, num3, buffer125.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer126, 0, buffer[index].writeBuffer, num3, buffer126.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer127, 0, buffer[index].writeBuffer, num3, buffer127.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer128, 0, buffer[index].writeBuffer, num3, buffer128.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = (byte) Main.projectile[number].owner;
                        num3++;
                        buffer[index].writeBuffer[num3] = (byte) Main.projectile[number].type;
                        num3++;
                        for (int n = 0; n < Projectile.maxAI; n++)
                        {
                            byte[] buffer129 = BitConverter.GetBytes(Main.projectile[number].ai[n]);
                            Buffer.BlockCopy(buffer129, 0, buffer[index].writeBuffer, num3, buffer129.Length);
                            num3 += 4;
                        }
                        count += num3;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                    }
                    else if (msgType == 0x1c)
                    {
                        byte[] buffer131 = BitConverter.GetBytes(msgType);
                        byte[] buffer132 = BitConverter.GetBytes((short) number);
                        byte[] buffer133 = BitConverter.GetBytes((short) number2);
                        byte[] buffer134 = BitConverter.GetBytes(number3);
                        byte num58 = (byte) (number4 + 1f);
                        byte num59 = (byte) number5;
                        count += (((buffer132.Length + buffer133.Length) + buffer134.Length) + 1) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer131, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer132, 0, buffer[index].writeBuffer, num3, buffer132.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer133, 0, buffer[index].writeBuffer, num3, buffer133.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer134, 0, buffer[index].writeBuffer, num3, buffer134.Length);
                        num3 += 4;
                        buffer[index].writeBuffer[num3] = num58;
                        num3++;
                        buffer[index].writeBuffer[num3] = num59;
                    }
                    else if (msgType == 0x1d)
                    {
                        byte[] buffer136 = BitConverter.GetBytes(msgType);
                        byte[] buffer137 = BitConverter.GetBytes((short) number);
                        byte num60 = (byte) number2;
                        count += buffer137.Length + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer136, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer137, 0, buffer[index].writeBuffer, num3, buffer137.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = num60;
                    }
                    else if (msgType == 30)
                    {
                        byte[] buffer139 = BitConverter.GetBytes(msgType);
                        byte num61 = (byte) number;
                        byte num62 = 0;
                        if (Main.player[num61].hostile)
                        {
                            num62 = 1;
                        }
                        count += 2;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer139, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num61;
                        num3++;
                        buffer[index].writeBuffer[num3] = num62;
                    }
                    else if (msgType == 0x1f)
                    {
                        byte[] buffer141 = BitConverter.GetBytes(msgType);
                        byte[] buffer142 = BitConverter.GetBytes(number);
                        byte[] buffer143 = BitConverter.GetBytes((int) number2);
                        count += buffer142.Length + buffer143.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer141, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer142, 0, buffer[index].writeBuffer, num3, buffer142.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer143, 0, buffer[index].writeBuffer, num3, buffer143.Length);
                    }
                    else if (msgType == 0x20)
                    {
                        byte[] buffer147;
                        byte[] buffer145 = BitConverter.GetBytes(msgType);
                        byte[] buffer146 = BitConverter.GetBytes((short) number);
                        byte num63 = (byte) number2;
                        byte num64 = (byte) Main.chest[number].item[(int) number2].stack;
                        byte num65 = Main.chest[number].item[(int) number2].prefix;
                        if (Main.chest[number].item[(int) number2].name == null)
                        {
                            buffer147 = BitConverter.GetBytes((short) 0);
                        }
                        else
                        {
                            buffer147 = BitConverter.GetBytes((short) Main.chest[number].item[(int) number2].netID);
                        }
                        count += (((buffer146.Length + 1) + 1) + 1) + buffer147.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer145, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer146, 0, buffer[index].writeBuffer, num3, buffer146.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = num63;
                        num3++;
                        buffer[index].writeBuffer[num3] = num64;
                        num3++;
                        buffer[index].writeBuffer[num3] = num65;
                        num3++;
                        Buffer.BlockCopy(buffer147, 0, buffer[index].writeBuffer, num3, buffer147.Length);
                    }
                    else if (msgType == 0x21)
                    {
                        byte[] buffer151;
                        byte[] buffer152;
                        byte[] buffer149 = BitConverter.GetBytes(msgType);
                        byte[] buffer150 = BitConverter.GetBytes((short) number);
                        if (number > -1)
                        {
                            buffer151 = BitConverter.GetBytes(Main.chest[number].x);
                            buffer152 = BitConverter.GetBytes(Main.chest[number].y);
                        }
                        else
                        {
                            buffer151 = BitConverter.GetBytes(0);
                            buffer152 = BitConverter.GetBytes(0);
                        }
                        count += (buffer150.Length + buffer151.Length) + buffer152.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer149, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer150, 0, buffer[index].writeBuffer, num3, buffer150.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer151, 0, buffer[index].writeBuffer, num3, buffer151.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer152, 0, buffer[index].writeBuffer, num3, buffer152.Length);
                    }
                    else if (msgType == 0x22)
                    {
                        byte[] buffer154 = BitConverter.GetBytes(msgType);
                        byte[] buffer155 = BitConverter.GetBytes(number);
                        byte[] buffer156 = BitConverter.GetBytes((int) number2);
                        count += buffer155.Length + buffer156.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer154, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer155, 0, buffer[index].writeBuffer, num3, buffer155.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer156, 0, buffer[index].writeBuffer, num3, buffer156.Length);
                    }
                    else if (msgType == 0x23)
                    {
                        byte[] buffer158 = BitConverter.GetBytes(msgType);
                        byte num66 = (byte) number;
                        byte[] buffer159 = BitConverter.GetBytes((short) number2);
                        count += 1 + buffer159.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer158, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num66;
                        num3++;
                        Buffer.BlockCopy(buffer159, 0, buffer[index].writeBuffer, num3, 2);
                    }
                    else if (msgType == 0x24)
                    {
                        byte[] buffer161 = BitConverter.GetBytes(msgType);
                        byte num67 = (byte) number;
                        byte num68 = 0;
                        if (Main.player[num67].zoneEvil)
                        {
                            num68 = 1;
                        }
                        byte num69 = 0;
                        if (Main.player[num67].zoneMeteor)
                        {
                            num69 = 1;
                        }
                        byte num70 = 0;
                        if (Main.player[num67].zoneDungeon)
                        {
                            num70 = 1;
                        }
                        byte num71 = 0;
                        if (Main.player[num67].zoneJungle)
                        {
                            num71 = 1;
                        }
                        byte num72 = 0;
                        if (Main.player[num67].zoneHoly)
                        {
                            num72 = 1;
                        }
                        count += 6;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer161, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num67;
                        num3++;
                        buffer[index].writeBuffer[num3] = num68;
                        num3++;
                        buffer[index].writeBuffer[num3] = num69;
                        num3++;
                        buffer[index].writeBuffer[num3] = num70;
                        num3++;
                        buffer[index].writeBuffer[num3] = num71;
                        num3++;
                        buffer[index].writeBuffer[num3] = num72;
                        num3++;
                    }
                    else if (msgType == 0x25)
                    {
                        byte[] buffer163 = BitConverter.GetBytes(msgType);
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer163, 0, buffer[index].writeBuffer, 4, 1);
                    }
                    else if (msgType == 0x26)
                    {
                        byte[] buffer165 = BitConverter.GetBytes(msgType);
                        byte[] buffer166 = Encoding.ASCII.GetBytes(text);
                        count += buffer166.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer165, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer166, 0, buffer[index].writeBuffer, num3, buffer166.Length);
                    }
                    else if (msgType == 0x27)
                    {
                        byte[] buffer168 = BitConverter.GetBytes(msgType);
                        byte[] buffer169 = BitConverter.GetBytes((short) number);
                        count += buffer169.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer168, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer169, 0, buffer[index].writeBuffer, num3, buffer169.Length);
                    }
                    else if (msgType == 40)
                    {
                        byte[] buffer171 = BitConverter.GetBytes(msgType);
                        byte num73 = (byte) number;
                        byte[] buffer172 = BitConverter.GetBytes((short) Main.player[num73].talkNPC);
                        count += 1 + buffer172.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer171, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num73;
                        num3++;
                        Buffer.BlockCopy(buffer172, 0, buffer[index].writeBuffer, num3, buffer172.Length);
                        num3 += 2;
                    }
                    else if (msgType == 0x29)
                    {
                        byte[] buffer174 = BitConverter.GetBytes(msgType);
                        byte num74 = (byte) number;
                        byte[] buffer175 = BitConverter.GetBytes(Main.player[num74].itemRotation);
                        byte[] buffer176 = BitConverter.GetBytes((short) Main.player[num74].itemAnimation);
                        count += (1 + buffer175.Length) + buffer176.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer174, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num74;
                        num3++;
                        Buffer.BlockCopy(buffer175, 0, buffer[index].writeBuffer, num3, buffer175.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer176, 0, buffer[index].writeBuffer, num3, buffer176.Length);
                    }
                    else if (msgType == 0x2a)
                    {
                        byte[] buffer178 = BitConverter.GetBytes(msgType);
                        byte num75 = (byte) number;
                        byte[] buffer179 = BitConverter.GetBytes((short) Main.player[num75].statMana);
                        byte[] buffer180 = BitConverter.GetBytes((short) Main.player[num75].statManaMax);
                        count += (1 + buffer179.Length) + buffer180.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer178, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num75;
                        num3++;
                        Buffer.BlockCopy(buffer179, 0, buffer[index].writeBuffer, num3, 2);
                        num3 += 2;
                        Buffer.BlockCopy(buffer180, 0, buffer[index].writeBuffer, num3, 2);
                    }
                    else if (msgType == 0x2b)
                    {
                        byte[] buffer182 = BitConverter.GetBytes(msgType);
                        byte num76 = (byte) number;
                        byte[] buffer183 = BitConverter.GetBytes((short) number2);
                        count += 1 + buffer183.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer182, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num76;
                        num3++;
                        Buffer.BlockCopy(buffer183, 0, buffer[index].writeBuffer, num3, 2);
                    }
                    else if (msgType == 0x2c)
                    {
                        byte[] buffer185 = BitConverter.GetBytes(msgType);
                        byte num77 = (byte) number;
                        byte num78 = (byte) (number2 + 1f);
                        byte[] buffer186 = BitConverter.GetBytes((short) number3);
                        byte num79 = (byte) number4;
                        byte[] buffer187 = Encoding.ASCII.GetBytes(text);
                        count += ((2 + buffer186.Length) + 1) + buffer187.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer185, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num77;
                        num3++;
                        buffer[index].writeBuffer[num3] = num78;
                        num3++;
                        Buffer.BlockCopy(buffer186, 0, buffer[index].writeBuffer, num3, buffer186.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = num79;
                        num3++;
                        Buffer.BlockCopy(buffer187, 0, buffer[index].writeBuffer, num3, buffer187.Length);
                        num3 += buffer187.Length;
                    }
                    else if (msgType == 0x2d)
                    {
                        byte[] buffer189 = BitConverter.GetBytes(msgType);
                        byte num80 = (byte) number;
                        byte team = (byte) Main.player[num80].team;
                        count += 2;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer189, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[5] = num80;
                        num3++;
                        buffer[index].writeBuffer[num3] = team;
                    }
                    else if (msgType == 0x2e)
                    {
                        byte[] buffer191 = BitConverter.GetBytes(msgType);
                        byte[] buffer192 = BitConverter.GetBytes(number);
                        byte[] buffer193 = BitConverter.GetBytes((int) number2);
                        count += buffer192.Length + buffer193.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer191, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer192, 0, buffer[index].writeBuffer, num3, buffer192.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer193, 0, buffer[index].writeBuffer, num3, buffer193.Length);
                    }
                    else if (msgType == 0x2f)
                    {
                        byte[] buffer195 = BitConverter.GetBytes(msgType);
                        byte[] buffer196 = BitConverter.GetBytes((short) number);
                        byte[] buffer197 = BitConverter.GetBytes(Main.sign[number].x);
                        byte[] buffer198 = BitConverter.GetBytes(Main.sign[number].y);
                        byte[] buffer199 = Encoding.ASCII.GetBytes(Main.sign[number].text);
                        count += ((buffer196.Length + buffer197.Length) + buffer198.Length) + buffer199.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer195, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer196, 0, buffer[index].writeBuffer, num3, buffer196.Length);
                        num3 += buffer196.Length;
                        Buffer.BlockCopy(buffer197, 0, buffer[index].writeBuffer, num3, buffer197.Length);
                        num3 += buffer197.Length;
                        Buffer.BlockCopy(buffer198, 0, buffer[index].writeBuffer, num3, buffer198.Length);
                        num3 += buffer198.Length;
                        Buffer.BlockCopy(buffer199, 0, buffer[index].writeBuffer, num3, buffer199.Length);
                        num3 += buffer199.Length;
                    }
                    else if (msgType == 0x30)
                    {
                        byte[] buffer201 = BitConverter.GetBytes(msgType);
                        byte[] buffer202 = BitConverter.GetBytes(number);
                        byte[] buffer203 = BitConverter.GetBytes((int) number2);
                        byte liquid = Main.tile[number, (int) number2].liquid;
                        byte num83 = 0;
                        if (Main.tile[number, (int) number2].lava)
                        {
                            num83 = 1;
                        }
                        count += ((buffer202.Length + buffer203.Length) + 1) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer201, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer202, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer203, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        buffer[index].writeBuffer[num3] = liquid;
                        num3++;
                        buffer[index].writeBuffer[num3] = num83;
                        num3++;
                    }
                    else if (msgType == 0x31)
                    {
                        byte[] buffer205 = BitConverter.GetBytes(msgType);
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer205, 0, buffer[index].writeBuffer, 4, 1);
                    }
                    else if (msgType == 50)
                    {
                        byte[] buffer207 = BitConverter.GetBytes(msgType);
                        byte num84 = (byte) number;
                        count += 11;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer207, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num84;
                        num3++;
                        for (int num85 = 0; num85 < 10; num85++)
                        {
                            buffer[index].writeBuffer[num3] = (byte) Main.player[num84].buffType[num85];
                            num3++;
                        }
                    }
                    else if (msgType == 0x33)
                    {
                        byte[] buffer209 = BitConverter.GetBytes(msgType);
                        count += 2;
                        byte num86 = (byte) number;
                        byte num87 = (byte) number2;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer209, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num86;
                        num3++;
                        buffer[index].writeBuffer[num3] = num87;
                    }
                    else if (msgType == 0x34)
                    {
                        byte[] buffer211 = BitConverter.GetBytes(msgType);
                        byte num88 = (byte) number;
                        byte num89 = (byte) number2;
                        byte[] buffer212 = BitConverter.GetBytes((int) number3);
                        byte[] buffer213 = BitConverter.GetBytes((int) number4);
                        count += (2 + buffer212.Length) + buffer213.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer211, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num88;
                        num3++;
                        buffer[index].writeBuffer[num3] = num89;
                        num3++;
                        Buffer.BlockCopy(buffer212, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                        Buffer.BlockCopy(buffer213, 0, buffer[index].writeBuffer, num3, 4);
                        num3 += 4;
                    }
                    else if (msgType == 0x35)
                    {
                        byte[] buffer215 = BitConverter.GetBytes(msgType);
                        byte[] buffer216 = BitConverter.GetBytes((short) number);
                        byte num90 = (byte) number2;
                        byte[] buffer217 = BitConverter.GetBytes((short) number3);
                        count += (buffer216.Length + 1) + buffer217.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer215, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer216, 0, buffer[index].writeBuffer, num3, buffer216.Length);
                        num3 += buffer216.Length;
                        buffer[index].writeBuffer[num3] = num90;
                        num3++;
                        Buffer.BlockCopy(buffer217, 0, buffer[index].writeBuffer, num3, buffer217.Length);
                        num3 += buffer217.Length;
                    }
                    else if (msgType == 0x36)
                    {
                        byte[] buffer219 = BitConverter.GetBytes(msgType);
                        byte[] buffer220 = BitConverter.GetBytes((short) number);
                        count += buffer220.Length + 15;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer219, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer220, 0, buffer[index].writeBuffer, num3, buffer220.Length);
                        num3 += buffer220.Length;
                        for (int num91 = 0; num91 < 5; num91++)
                        {
                            buffer[index].writeBuffer[num3] = (byte) Main.npc[(short) number].buffType[num91];
                            num3++;
                            byte[] buffer222 = BitConverter.GetBytes(Main.npc[(short) number].buffTime[num91]);
                            Buffer.BlockCopy(buffer222, 0, buffer[index].writeBuffer, num3, buffer222.Length);
                            num3 += buffer222.Length;
                        }
                    }
                    else if (msgType == 0x37)
                    {
                        byte[] buffer223 = BitConverter.GetBytes(msgType);
                        byte num92 = (byte) number;
                        byte num93 = (byte) number2;
                        byte[] buffer224 = BitConverter.GetBytes((short) number3);
                        count += 2 + buffer224.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer223, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num92;
                        num3++;
                        buffer[index].writeBuffer[num3] = num93;
                        num3++;
                        Buffer.BlockCopy(buffer224, 0, buffer[index].writeBuffer, num3, buffer224.Length);
                        num3 += buffer224.Length;
                    }
                    else if (msgType == 0x38)
                    {
                        byte[] buffer226 = BitConverter.GetBytes(msgType);
                        byte[] buffer227 = BitConverter.GetBytes((short) number);
                        byte[] buffer228 = Encoding.ASCII.GetBytes(Main.chrName[number]);
                        count += buffer227.Length + buffer228.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer226, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer227, 0, buffer[index].writeBuffer, num3, buffer227.Length);
                        num3 += buffer227.Length;
                        Buffer.BlockCopy(buffer228, 0, buffer[index].writeBuffer, num3, buffer228.Length);
                    }
                    else if (msgType == 0x39)
                    {
                        byte[] buffer230 = BitConverter.GetBytes(msgType);
                        count += 2;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer230, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = WorldGen.tGood;
                        num3++;
                        buffer[index].writeBuffer[num3] = WorldGen.tEvil;
                    }
                    else if (msgType == 0x3a)
                    {
                        byte[] buffer232 = BitConverter.GetBytes(msgType);
                        byte num94 = (byte) number;
                        byte[] buffer233 = BitConverter.GetBytes(number2);
                        count += 1 + buffer233.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer232, 0, buffer[index].writeBuffer, 4, 1);
                        buffer[index].writeBuffer[num3] = num94;
                        num3++;
                        Buffer.BlockCopy(buffer233, 0, buffer[index].writeBuffer, num3, buffer233.Length);
                    }
                    else if (msgType == 0x3b)
                    {
                        byte[] buffer235 = BitConverter.GetBytes(msgType);
                        byte[] buffer236 = BitConverter.GetBytes(number);
                        byte[] buffer237 = BitConverter.GetBytes((int) number2);
                        count += buffer236.Length + buffer237.Length;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer235, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer236, 0, buffer[index].writeBuffer, num3, buffer236.Length);
                        num3 += 4;
                        Buffer.BlockCopy(buffer237, 0, buffer[index].writeBuffer, num3, buffer237.Length);
                    }
                    else if (msgType == 60)
                    {
                        byte[] buffer239 = BitConverter.GetBytes(msgType);
                        byte[] buffer240 = BitConverter.GetBytes((short) number);
                        byte[] buffer241 = BitConverter.GetBytes((short) number2);
                        byte[] buffer242 = BitConverter.GetBytes((short) number3);
                        byte num95 = (byte) number4;
                        count += ((buffer240.Length + buffer241.Length) + buffer242.Length) + 1;
                        Buffer.BlockCopy(BitConverter.GetBytes((int) (count - 4)), 0, buffer[index].writeBuffer, 0, 4);
                        Buffer.BlockCopy(buffer239, 0, buffer[index].writeBuffer, 4, 1);
                        Buffer.BlockCopy(buffer240, 0, buffer[index].writeBuffer, num3, buffer240.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer241, 0, buffer[index].writeBuffer, num3, buffer241.Length);
                        num3 += 2;
                        Buffer.BlockCopy(buffer242, 0, buffer[index].writeBuffer, num3, buffer242.Length);
                        num3 += 2;
                        buffer[index].writeBuffer[num3] = num95;
                        num3++;
                    }
                    if (Main.netMode == 1)
                    {
                        if (Netplay.clientSock.tcpClient.Connected)
                        {
                            try
                            {
                                messageBuffer buffer1 = buffer[index];
                                buffer1.spamCount++;
                                Main.txMsg++;
                                Main.txData += count;
                                Main.txMsgType[msgType]++;
                                Main.txDataType[msgType] += count;
                                Netplay.clientSock.networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.clientSock.ClientWriteCallBack), Netplay.clientSock.networkStream);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (remoteClient == -1)
                    {
                        if (msgType == 20)
                        {
                            for (int num96 = 0; num96 < 0x100; num96++)
                            {
                                if (((num96 != ignoreClient) && (buffer[num96].broadcast || ((Netplay.serverSock[num96].state >= 3) && (msgType == 10)))) && (Netplay.serverSock[num96].tcpClient.Connected && Netplay.serverSock[num96].SectionRange(number, (int) number2, (int) number3)))
                                {
                                    try
                                    {
                                        messageBuffer buffer245 = buffer[num96];
                                        buffer245.spamCount++;
                                        Main.txMsg++;
                                        Main.txData += count;
                                        Main.txMsgType[msgType]++;
                                        Main.txDataType[msgType] += count;
                                        NetMessage.SendBytes(Netplay.serverSock[num96], buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num96].ServerWriteCallBack), Netplay.serverSock[num96].networkStream);
                                        //Netplay.serverSock[num96].networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num96].ServerWriteCallBack), Netplay.serverSock[num96].networkStream);
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        else if (msgType == 0x1c)
                        {
                            int num99 = number;
                            for (int num100 = 0; num100 < 0x100; num100++)
                            {
                                if (((num100 != ignoreClient) && (buffer[num100].broadcast || ((Netplay.serverSock[num100].state >= 3) && (msgType == 10)))) && Netplay.serverSock[num100].tcpClient.Connected)
                                {
                                    bool flag2 = false;
                                    if (Main.npc[num99].life <= 0)
                                    {
                                        flag2 = true;
                                    }
                                    else
                                    {
                                        Rectangle rectangle4;
                                        Rectangle rectangle3 = new Rectangle((int) Main.player[num100].position.X, (int) Main.player[num100].position.Y, Main.player[num100].width, Main.player[num100].height);
                                        rectangle4 = new Rectangle()
                                                         {
                                                             X = (int) Main.npc[num99].position.X - 0xbb8,
                                                             Y = (int) Main.npc[num99].position.Y - 0xbb8,
                                                             Width = Main.npc[num99].width + 0x1770,
                                                             Height = Main.npc[num99].height + 0x1770
                                                             //WARNING: possible error?
                                                         };
                                        if (rectangle3.Intersects(rectangle4))
                                        {
                                            flag2 = true;
                                        }
                                    }
                                    if (flag2)
                                    {
                                        try
                                        {
                                            messageBuffer buffer246 = buffer[num100];
                                            buffer246.spamCount++;
                                            Main.txMsg++;
                                            Main.txData += count;
                                            Main.txMsgType[msgType]++;
                                            Main.txDataType[msgType] += count;
                                            NetMessage.SendBytes(Netplay.serverSock[num100], buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num100].ServerWriteCallBack), Netplay.serverSock[num100].networkStream);
                                            //Netplay.serverSock[num100].networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num100].ServerWriteCallBack), Netplay.serverSock[num100].networkStream);
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
                            int num101 = number;
                            for (int num102 = 0; num102 < 0x100; num102++)
                            {
                                if (((num102 != ignoreClient) && (buffer[num102].broadcast || ((Netplay.serverSock[num102].state >= 3) && (msgType == 10)))) && Netplay.serverSock[num102].tcpClient.Connected)
                                {
                                    bool flag3 = false;
                                    if (Main.player[num101].netSkip > 0)
                                    {
                                        Rectangle rectangle6;
                                        Rectangle rectangle5 = new Rectangle((int) Main.player[num102].position.X, (int) Main.player[num102].position.Y, Main.player[num102].width, Main.player[num102].height);
                                        rectangle6 = new Rectangle()
                                                         {
                                                             X = (int) Main.player[num101].position.X - 0x9c4,
                                                             Y = (int) Main.player[num101].position.Y - 0x9c4,
                                                             Width = Main.player[num101].width + 0x1388,
                                                             Height = Main.player[num101].height + 0x1388
                                                             //WARNING: possible error?
                                                         };
                                        if (rectangle5.Intersects(rectangle6))
                                        {
                                            flag3 = true;
                                        }
                                    }
                                    else
                                    {
                                        flag3 = true;
                                    }
                                    if (flag3)
                                    {
                                        try
                                        {
                                            messageBuffer buffer247 = buffer[num102];
                                            buffer247.spamCount++;
                                            Main.txMsg++;
                                            Main.txData += count;
                                            Main.txMsgType[msgType]++;
                                            Main.txDataType[msgType] += count;
                                            NetMessage.SendBytes(Netplay.serverSock[num102], buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num102].ServerWriteCallBack), Netplay.serverSock[num102].networkStream);
                                            //Netplay.serverSock[num102].networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num102].ServerWriteCallBack), Netplay.serverSock[num102].networkStream);
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                            Player player1 = Main.player[num101];
                            player1.netSkip++;
                            if (Main.player[num101].netSkip > 2)
                            {
                                Main.player[num101].netSkip = 0;
                            }
                        }
                        else if (msgType == 0x1b)
                        {
                            int num103 = number;
                            for (int num104 = 0; num104 < 0x100; num104++)
                            {
                                if (((num104 != ignoreClient) && (buffer[num104].broadcast || ((Netplay.serverSock[num104].state >= 3) && (msgType == 10)))) && Netplay.serverSock[num104].tcpClient.Connected)
                                {
                                    bool flag4 = false;
                                    if (Main.projectile[num103].type == 12)
                                    {
                                        flag4 = true;
                                    }
                                    else
                                    {
                                        Rectangle rectangle8;
                                        Rectangle rectangle7 = new Rectangle((int) Main.player[num104].position.X, (int) Main.player[num104].position.Y, Main.player[num104].width, Main.player[num104].height);
                                        rectangle8 = new Rectangle()
                                                         {
                                                             X = (int) Main.projectile[num103].position.X - 0x1388,
                                                             Y = (int) Main.projectile[num103].position.Y - 0x1388,
                                                             Width = Main.projectile[num103].width + 0x2710,
                                                             Height = Main.projectile[num103].height + 0x2710
                                                             //WARNING: possible error?
                                                         };
                                        if (rectangle7.Intersects(rectangle8))
                                        {
                                            flag4 = true;
                                        }
                                    }
                                    if (flag4)
                                    {
                                        try
                                        {
                                            messageBuffer buffer248 = buffer[num104];
                                            buffer248.spamCount++;
                                            Main.txMsg++;
                                            Main.txData += count;
                                            Main.txMsgType[msgType]++;
                                            Main.txDataType[msgType] += count;
                                            NetMessage.SendBytes(Netplay.serverSock[num104], buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num104].ServerWriteCallBack), Netplay.serverSock[num104].networkStream);
                                            //Netplay.serverSock[num104].networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num104].ServerWriteCallBack), Netplay.serverSock[num104].networkStream);
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
                            for (int num105 = 0; num105 < 0x100; num105++)
                            {
                                if (((num105 != ignoreClient) && (buffer[num105].broadcast || ((Netplay.serverSock[num105].state >= 3) && (msgType == 10)))) && Netplay.serverSock[num105].tcpClient.Connected)
                                {
                                    try
                                    {
                                        messageBuffer buffer249 = buffer[num105];
                                        buffer249.spamCount++;
                                        Main.txMsg++;
                                        Main.txData += count;
                                        Main.txMsgType[msgType]++;
                                        Main.txDataType[msgType] += count;
                                        NetMessage.SendBytes(Netplay.serverSock[num105], buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num105].ServerWriteCallBack), Netplay.serverSock[num105].networkStream);
                                        //Netplay.serverSock[num105].networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[num105].ServerWriteCallBack), Netplay.serverSock[num105].networkStream);
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
                            messageBuffer buffer250 = buffer[remoteClient];
                            buffer250.spamCount++;
                            Main.txMsg++;
                            Main.txData += count;
                            Main.txMsgType[msgType]++;
                            Main.txDataType[msgType] += count;
                            NetMessage.SendBytes(Netplay.serverSock[remoteClient], buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[remoteClient].ServerWriteCallBack), Netplay.serverSock[remoteClient].networkStream);
                            //Netplay.serverSock[remoteClient].networkStream.BeginWrite(buffer[index].writeBuffer, 0, count, new AsyncCallback(Netplay.serverSock[remoteClient].ServerWriteCallBack), Netplay.serverSock[remoteClient].networkStream);
                        }
                        catch
                        {
                        }
                    }
                    if (Main.verboseNetplay)
                    {
                        for (int num106 = 0; num106 < count; num106++)
                        {
                        }
                        for (int num107 = 0; num107 < count; num107++)
                        {
                            byte num1 = buffer[index].writeBuffer[num107];
                        }
                    }
                    buffer[index].writeLocked = false;
                    if ((msgType == 0x13) && (Main.netMode == 1))
                    {
                        int size = 5;
                        SendTileSquare(index, (int) number2, (int) number3, size);
                    }
                    if ((msgType == 2) && (Main.netMode == 2))
                    {
                        Netplay.serverSock[index].kill = true;
                    }
                }
            }
        }

        public static void SendSection(int whoAmi, int sectionX, int sectionY)
        {
            if (Main.netMode == 2)
            {
                try
                {
                    if (((sectionX >= 0) && (sectionY >= 0)) && ((sectionX < Main.maxSectionsX) && (sectionY < Main.maxSectionsY)))
                    {
                        Netplay.serverSock[whoAmi].tileSection[sectionX, sectionY] = true;
                        int num = sectionX * 200;
                        int num2 = sectionY * 150;
                        for (int i = num2; i < (num2 + 150); i++)
                        {
                            SendData(10, whoAmi, -1, "", 200, (float)num, (float)i, 0f, 0);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public static void SendTileSquare(int whoAmi, int tileX, int tileY, int size)
        {
            int num = (size - 1) / 2;
            SendData(20, whoAmi, -1, "", size, (float)(tileX - num), (float)(tileY - num), 0f, 0);
        }

        public static void sendWater(int x, int y)
        {
            if (Main.netMode == 1)
            {
                SendData(0x30, -1, -1, "", x, (float)y, 0f, 0f, 0);
            }
            else
            {
                for (int i = 0; i < 0x100; i++)
                {
                    if ((buffer[i].broadcast || (Netplay.serverSock[i].state >= 3)) && Netplay.serverSock[i].tcpClient.Connected)
                    {
                        int num2 = x / 200;
                        int num3 = y / 150;
                        if (Netplay.serverSock[i].tileSection[num2, num3])
                        {
                            SendData(0x30, i, -1, "", x, (float)y, 0f, 0f, 0);
                        }
                    }
                }
            }
        }

        public static void syncPlayers()
        {
            bool flag = false;
            for (int i = 0; i < 0xff; i++)
            {
                int num2 = 0;
                if (Main.player[i].active)
                {
                    num2 = 1;
                }
                if (Netplay.serverSock[i].state == 10)
                {
                    if (Main.autoShutdown && !flag)
                    {
                        string str = Netplay.serverSock[i].tcpClient.Client.RemoteEndPoint.ToString();
                        string str2 = str;
                        for (int m = 0; m < str.Length; m++)
                        {
                            if (str.Substring(m, 1) == ":")
                            {
                                str2 = str.Substring(0, m);
                            }
                        }
                        if (str2 == "127.0.0.1")
                        {
                            flag = true;
                        }
                    }
                    SendData(14, -1, i, "", i, (float)num2, 0f, 0f, 0);
                    SendData(4, -1, i, Main.player[i].name, i, 0f, 0f, 0f, 0);
                    SendData(13, -1, i, "", i, 0f, 0f, 0f, 0);
                    SendData(0x10, -1, i, "", i, 0f, 0f, 0f, 0);
                    SendData(30, -1, i, "", i, 0f, 0f, 0f, 0);
                    SendData(0x2d, -1, i, "", i, 0f, 0f, 0f, 0);
                    SendData(0x2a, -1, i, "", i, 0f, 0f, 0f, 0);
                    SendData(50, -1, i, "", i, 0f, 0f, 0f, 0);
                    for (int k = 0; k < 0x31; k++)
                    {
                        SendData(5, -1, i, Main.player[i].inventory[k].name, i, (float)k, (float)Main.player[i].inventory[k].prefix, 0f, 0);
                    }
                    SendData(5, -1, i, Main.player[i].armor[0].name, i, 49f, (float)Main.player[i].armor[0].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[1].name, i, 50f, (float)Main.player[i].armor[1].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[2].name, i, 51f, (float)Main.player[i].armor[2].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[3].name, i, 52f, (float)Main.player[i].armor[3].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[4].name, i, 53f, (float)Main.player[i].armor[4].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[5].name, i, 54f, (float)Main.player[i].armor[5].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[6].name, i, 55f, (float)Main.player[i].armor[6].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[7].name, i, 56f, (float)Main.player[i].armor[7].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[8].name, i, 57f, (float)Main.player[i].armor[8].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[9].name, i, 58f, (float)Main.player[i].armor[9].prefix, 0f, 0);
                    SendData(5, -1, i, Main.player[i].armor[10].name, i, 59f, (float)Main.player[i].armor[10].prefix, 0f, 0);
                    if (!Netplay.serverSock[i].announced)
                    {
                        Netplay.serverSock[i].announced = true;
                        SendData(0x19, -1, i, Main.player[i].name + " has joined.", 0xff, 255f, 240f, 20f, 0);
                        if (Main.dedServ)
                        {
                            Console.WriteLine(Main.player[i].name + " has joined.");
                        }
                    }
                }
                else
                {
                    num2 = 0;
                    SendData(14, -1, i, "", i, (float)num2, 0f, 0f, 0);
                    if (Netplay.serverSock[i].announced)
                    {
                        Netplay.serverSock[i].announced = false;
                        SendData(0x19, -1, i, Netplay.serverSock[i].oldName + " has left.", 0xff, 255f, 240f, 20f, 0);
                        if (Main.dedServ)
                        {
                            Console.WriteLine(Netplay.serverSock[i].oldName + " has left.");
                        }
                    }
                }
            }
            for (int j = 0; j < 200; j++)
            {
                if ((Main.npc[j].active && Main.npc[j].townNPC) && (NPC.TypeToNum(Main.npc[j].type) != -1))
                {
                    int num6 = 0;
                    if (Main.npc[j].homeless)
                    {
                        num6 = 1;
                    }
                    SendData(60, -1, -1, "", j, (float)Main.npc[j].homeTileX, (float)Main.npc[j].homeTileY, (float)num6, 0);
                }
            }
            if (Main.autoShutdown && !flag)
            {
                WorldGen.saveWorld(false);
                Netplay.disconnect = true;
            }
        }
    }
}

