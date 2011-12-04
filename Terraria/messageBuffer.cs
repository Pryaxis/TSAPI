namespace Terraria
{
    using System;
    using System.Text;
    using Hooks;

    public class messageBuffer
    {
        public bool broadcast;
        public bool checkBytes;
        public int maxSpam;
        public int messageLength;
        public byte[] readBuffer = new byte[0xffff];
        public const int readBufferMax = 0xffff;
        public int spamCount;
        public int totalData;
        public int whoAmI;
        public byte[] writeBuffer = new byte[0xffff];
        public const int writeBufferMax = 0xffff;
        public bool writeLocked;

        public void GetData(int start, int length)
        {
            byte num66;
            int num67;
            int num68;
            int num69;
            int num175;
            int num176;
            int team;
            string str12;
            int num178;
            if (this.whoAmI < 0x100)
            {
                Netplay.serverSock[this.whoAmI].timeOut = 0;
            }
            else
            {
                Netplay.clientSock.timeOut = 0;
            }
            byte index = 0;
            int startIndex = 0;
            startIndex = start + 1;
            index = this.readBuffer[start];
            if (NetHooks.OnGetData(ref index, this, ref startIndex, ref length))
            {
                return;
            }
            Main.rxMsg++;
            Main.rxData += length;
            Main.rxMsgType[index]++;
            Main.rxDataType[index] += length;
            if ((Main.netMode == 1) && (Netplay.clientSock.statusMax > 0))
            {
                Netplay.clientSock.statusCount++;
            }
            if (Main.verboseNetplay)
            {
                for (int i = start; i < (start + length); i++)
                {
                }
                for (int j = start; j < (start + length); j++)
                {
                    byte num1 = this.readBuffer[j];
                }
            }
            if (((Main.netMode == 2) && (index != 0x26)) && (Netplay.serverSock[this.whoAmI].state == -1))
            {
                NetMessage.SendData(2, this.whoAmI, -1, "Incorrect password.", 0, 0f, 0f, 0f, 0);
                return;
            }
            if ((((Main.netMode == 2) && (Netplay.serverSock[this.whoAmI].state < 10)) && ((index > 12) && (index != 0x10))) && (((index != 0x2a) && (index != 50)) && (index != 0x26)))
            {
                NetMessage.BootPlayer(this.whoAmI, "Invalid operation at this state.");
            }
            if ((index == 1) && (Main.netMode == 2))
            {
                if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
                {
                    NetMessage.SendData(2, this.whoAmI, -1, "You are banned from this server.", 0, 0f, 0f, 0f, 0);
                    return;
                }
                if (Netplay.serverSock[this.whoAmI].state == 0)
                {
                    if (Encoding.ASCII.GetString(this.readBuffer, start + 1, length - 1) == ("Terraria" + Main.curRelease))
                    {
                        if ((Netplay.password == null) || (Netplay.password == ""))
                        {
                            Netplay.serverSock[this.whoAmI].state = 1;
                            NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                            return;
                        }
                        Netplay.serverSock[this.whoAmI].state = -1;
                        NetMessage.SendData(0x25, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    NetMessage.SendData(2, this.whoAmI, -1, "You are not using the same version as this server.", 0, 0f, 0f, 0f, 0);
                    return;
                }
                return;
            }
            if ((index == 2) && (Main.netMode == 1))
            {
                Netplay.disconnect = true;
                Main.statusText = Encoding.ASCII.GetString(this.readBuffer, start + 1, length - 1);
                return;
            }
            if ((index == 3) && (Main.netMode == 1))
            {
                if (Netplay.clientSock.state == 1)
                {
                    Netplay.clientSock.state = 2;
                }
                int num5 = this.readBuffer[start + 1];
                if (num5 != Main.myPlayer)
                {
                    Main.player[num5] = (Player)Main.player[Main.myPlayer].Clone();
                    Main.player[Main.myPlayer] = new Player();
                    Main.player[num5].whoAmi = num5;
                    Main.myPlayer = num5;
                }
                NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(0x10, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(0x2a, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                for (int k = 0; k < 0x31; k++)
                {
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
                }
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
                NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
                NetMessage.SendData(6, -1, -1, "", 0, 0f, 0f, 0f, 0);
                if (Netplay.clientSock.state == 2)
                {
                    Netplay.clientSock.state = 3;
                    return;
                }
                return;
            }
            switch (index)
            {
                case 5:
                    {
                        int whoAmI = this.readBuffer[start + 1];
                        if (Main.netMode == 2)
                        {
                            whoAmI = this.whoAmI;
                        }
                        if (whoAmI == Main.myPlayer)
                        {
                            return;
                        }
                        lock (Main.player[whoAmI])
                        {
                            int num13 = this.readBuffer[start + 2];
                            int num14 = this.readBuffer[start + 3];
                            byte pre = this.readBuffer[start + 4];
                            int type = BitConverter.ToInt16(this.readBuffer, start + 5);
                            if (num13 < 0x31)
                            {
                                Main.player[whoAmI].inventory[num13] = new Item();
                                Main.player[whoAmI].inventory[num13].netDefaults(type);
                                Main.player[whoAmI].inventory[num13].stack = num14;
                                Main.player[whoAmI].inventory[num13].Prefix(pre);
                            }
                            else
                            {
                                Main.player[whoAmI].armor[(num13 - 0x30) - 1] = new Item();
                                Main.player[whoAmI].armor[(num13 - 0x30) - 1].netDefaults(type);
                                Main.player[whoAmI].armor[(num13 - 0x30) - 1].stack = num14;
                                Main.player[whoAmI].armor[(num13 - 0x30) - 1].Prefix(pre);
                            }
                            if ((Main.netMode == 2) && (whoAmI == this.whoAmI))
                            {
                                NetMessage.SendData(5, -1, this.whoAmI, "", whoAmI, (float)num13, (float)pre, 0f, 0);
                            }
                            return;
                        }
                        break;
                    }
                case 6:
                    if (Main.netMode == 2)
                    {
                        if (Netplay.serverSock[this.whoAmI].state == 1)
                        {
                            Netplay.serverSock[this.whoAmI].state = 2;
                        }
                        NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    return;

                case 7:
                    if (Main.netMode == 1)
                    {
                        Main.time = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.dayTime = false;
                        if (this.readBuffer[startIndex] == 1)
                        {
                            Main.dayTime = true;
                        }
                        startIndex++;
                        Main.moonPhase = this.readBuffer[startIndex];
                        startIndex++;
                        int num17 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num17 == 1)
                        {
                            Main.bloodMoon = true;
                        }
                        else
                        {
                            Main.bloodMoon = false;
                        }
                        Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.worldSurface = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.rockLayer = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        Main.worldID = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        byte num18 = this.readBuffer[startIndex];
                        if ((num18 & 1) == 1)
                        {
                            WorldGen.shadowOrbSmashed = true;
                        }
                        if ((num18 & 2) == 2)
                        {
                            NPC.downedBoss1 = true;
                        }
                        if ((num18 & 4) == 4)
                        {
                            NPC.downedBoss2 = true;
                        }
                        if ((num18 & 8) == 8)
                        {
                            NPC.downedBoss3 = true;
                        }
                        if ((num18 & 0x10) == 0x10)
                        {
                            Main.hardMode = true;
                        }
                        if ((num18 & 0x20) == 0x20)
                        {
                            NPC.downedClown = true;
                        }
                        startIndex++;
                        Main.worldName = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                        if (Netplay.clientSock.state == 3)
                        {
                            Netplay.clientSock.state = 4;
                            return;
                        }
                    }
                    return;

                case 4:
                    {
                        bool flag = false;
                        int num7 = this.readBuffer[start + 1];
                        if (Main.netMode == 2)
                        {
                            num7 = this.whoAmI;
                        }
                        if (num7 != Main.myPlayer)
                        {
                            int num8 = this.readBuffer[start + 2];
                            if (num8 >= 0x24)
                            {
                                num8 = 0;
                            }
                            Main.player[num7].hair = num8;
                            Main.player[num7].whoAmi = num7;
                            startIndex += 2;
                            byte num9 = this.readBuffer[startIndex];
                            startIndex++;
                            if (num9 == 1)
                            {
                                Main.player[num7].male = true;
                            }
                            else
                            {
                                Main.player[num7].male = false;
                            }
                            Main.player[num7].hairColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].hairColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].hairColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].skinColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].skinColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].skinColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].eyeColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].eyeColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].eyeColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].shirtColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].shirtColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].shirtColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].underShirtColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].underShirtColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].underShirtColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].pantsColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].pantsColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].pantsColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].shoeColor.R = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].shoeColor.G = this.readBuffer[startIndex];
                            startIndex++;
                            Main.player[num7].shoeColor.B = this.readBuffer[startIndex];
                            startIndex++;
                            byte num10 = this.readBuffer[startIndex];
                            Main.player[num7].difficulty = num10;
                            startIndex++;
                            string text = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start).Trim();
                            Main.player[num7].name = text.Trim();
                            if (Main.netMode == 2)
                            {
                                if (Netplay.serverSock[this.whoAmI].state < 10)
                                {
                                    for (int m = 0; m < 0xff; m++)
                                    {
                                        if (((m != num7) && (text == Main.player[m].name)) && Netplay.serverSock[m].active)
                                        {
                                            flag = true;
                                        }
                                    }
                                }
                                if (flag)
                                {
                                    NetMessage.SendData(2, this.whoAmI, -1, text + " is already on this server.", 0, 0f, 0f, 0f, 0);
                                    return;
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
                                NetMessage.SendData(4, -1, this.whoAmI, text, num7, 0f, 0f, 0f, 0);
                                return;
                            }
                        }
                        return;
                    }
                case 8:
                    if (Main.netMode == 2)
                    {
                        int x = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        int y = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        bool flag3 = true;
                        if ((x == -1) || (y == -1))
                        {
                            flag3 = false;
                        }
                        else if ((x < 10) || (x > (Main.maxTilesX - 10)))
                        {
                            flag3 = false;
                        }
                        else if ((y < 10) || (y > (Main.maxTilesY - 10)))
                        {
                            flag3 = false;
                        }
                        int number = 0x546;
                        if (flag3)
                        {
                            number *= 2;
                        }
                        if (Netplay.serverSock[this.whoAmI].state == 2)
                        {
                            Netplay.serverSock[this.whoAmI].state = 3;
                        }
                        NetMessage.SendData(9, this.whoAmI, -1, "Receiving tile data", number, 0f, 0f, 0f, 0);
                        Netplay.serverSock[this.whoAmI].statusText2 = "is receiving tile data";
                        ServerSock sock1 = Netplay.serverSock[this.whoAmI];
                        sock1.statusMax += number;
                        int sectionX = Netplay.GetSectionX(Main.spawnTileX);
                        int sectionY = Netplay.GetSectionY(Main.spawnTileY);
                        for (int n = sectionX - 2; n < (sectionX + 3); n++)
                        {
                            for (int num25 = sectionY - 1; num25 < (sectionY + 2); num25++)
                            {
                                NetMessage.SendSection(this.whoAmI, n, num25);
                            }
                        }
                        if (flag3)
                        {
                            x = Netplay.GetSectionX(x);
                            y = Netplay.GetSectionY(y);
                            for (int num26 = x - 2; num26 < (x + 3); num26++)
                            {
                                for (int num27 = y - 1; num27 < (y + 2); num27++)
                                {
                                    NetMessage.SendSection(this.whoAmI, num26, num27);
                                }
                            }
                            NetMessage.SendData(11, this.whoAmI, -1, "", x - 2, (float)(y - 1), (float)(x + 2), (float)(y + 1), 0);
                        }
                        NetMessage.SendData(11, this.whoAmI, -1, "", sectionX - 2, (float)(sectionY - 1), (float)(sectionX + 2), (float)(sectionY + 1), 0);
                        for (int num28 = 0; num28 < 200; num28++)
                        {
                            if (Main.item[num28].active)
                            {
                                NetMessage.SendData(0x15, this.whoAmI, -1, "", num28, 0f, 0f, 0f, 0);
                                NetMessage.SendData(0x16, this.whoAmI, -1, "", num28, 0f, 0f, 0f, 0);
                            }
                        }
                        for (int num29 = 0; num29 < 200; num29++)
                        {
                            if (Main.npc[num29].active)
                            {
                                NetMessage.SendData(0x17, this.whoAmI, -1, "", num29, 0f, 0f, 0f, 0);
                            }
                        }
                        NetMessage.SendData(0x31, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x39, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x11, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x12, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x13, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 20, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x16, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x26, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x36, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x6b, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x6c, 0f, 0f, 0f, 0);
                        NetMessage.SendData(0x38, this.whoAmI, -1, "", 0x7c, 0f, 0f, 0f, 0);
                        return;
                    }
                    return;

                case 9:
                    if (Main.netMode == 1)
                    {
                        int num30 = BitConverter.ToInt32(this.readBuffer, start + 1);
                        string str3 = Encoding.ASCII.GetString(this.readBuffer, start + 5, length - 5);
                        Netplay.clientSock.statusMax += num30;
                        Netplay.clientSock.statusText = str3;
                        return;
                    }
                    return;
            }
            if ((index == 10) && (Main.netMode == 1))
            {
                short num31 = BitConverter.ToInt16(this.readBuffer, start + 1);
                int num32 = BitConverter.ToInt32(this.readBuffer, start + 3);
                int num33 = BitConverter.ToInt32(this.readBuffer, start + 7);
                startIndex = start + 11;
                for (int num35 = num32; num35 < (num32 + num31); num35++)
                {
                    if (Main.tile[num35, num33] == null)
                    {
                        //Main.tile[num35, num33] = new Tile();
                    }
                    byte num34 = this.readBuffer[startIndex];
                    startIndex++;
                    bool active = Main.tile[num35, num33].active;
                    if ((num34 & 1) == 1)
                    {
                        Main.tile[num35, num33].active = true;
                    }
                    else
                    {
                        Main.tile[num35, num33].active = false;
                    }
                    int num223 = num34 & 2;
                    if ((num34 & 4) == 4)
                    {
                        Main.tile[num35, num33].wall = 1;
                    }
                    else
                    {
                        Main.tile[num35, num33].wall = 0;
                    }
                    if ((num34 & 8) == 8)
                    {
                        Main.tile[num35, num33].liquid = 1;
                    }
                    else
                    {
                        Main.tile[num35, num33].liquid = 0;
                    }
                    if ((num34 & 0x10) == 0x10)
                    {
                        Main.tile[num35, num33].wire = true;
                    }
                    else
                    {
                        Main.tile[num35, num33].wire = false;
                    }
                    if (Main.tile[num35, num33].active)
                    {
                        int num36 = Main.tile[num35, num33].type;
                        Main.tile[num35, num33].type = this.readBuffer[startIndex];
                        startIndex++;
                        if (Main.tileFrameImportant[Main.tile[num35, num33].type])
                        {
                            Main.tile[num35, num33].frameX = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                            Main.tile[num35, num33].frameY = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                        }
                        else if (!active || (Main.tile[num35, num33].type != num36))
                        {
                            Main.tile[num35, num33].frameX = -1;
                            Main.tile[num35, num33].frameY = -1;
                        }
                    }
                    if (Main.tile[num35, num33].wall > 0)
                    {
                        Main.tile[num35, num33].wall = this.readBuffer[startIndex];
                        startIndex++;
                    }
                    if (Main.tile[num35, num33].liquid > 0)
                    {
                        Main.tile[num35, num33].liquid = this.readBuffer[startIndex];
                        startIndex++;
                        byte num37 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num37 == 1)
                        {
                            Main.tile[num35, num33].lava = true;
                        }
                        else
                        {
                            Main.tile[num35, num33].lava = false;
                        }
                    }
                    short num38 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 2;
                    int num39 = num35;
                    while (num38 > 0)
                    {
                        num39++;
                        num38 = (short)(num38 - 1);
                        if (Main.tile[num39, num33] == null)
                        {
                            //Main.tile[num39, num33] = new Tile();
                        }
                        Main.tile[num39, num33].active = Main.tile[num35, num33].active;
                        Main.tile[num39, num33].type = Main.tile[num35, num33].type;
                        Main.tile[num39, num33].wall = Main.tile[num35, num33].wall;
                        Main.tile[num39, num33].wire = Main.tile[num35, num33].wire;
                        if (Main.tileFrameImportant[Main.tile[num39, num33].type])
                        {
                            Main.tile[num39, num33].frameX = Main.tile[num35, num33].frameX;
                            Main.tile[num39, num33].frameY = Main.tile[num35, num33].frameY;
                        }
                        else
                        {
                            Main.tile[num39, num33].frameX = -1;
                            Main.tile[num39, num33].frameY = -1;
                        }
                        Main.tile[num39, num33].liquid = Main.tile[num35, num33].liquid;
                        Main.tile[num39, num33].lava = Main.tile[num35, num33].lava;
                    }
                    num35 = num39;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(index, -1, this.whoAmI, "", num31, (float)num32, (float)num33, 0f, 0);
                    return;
                }
                return;
            }
            if (index == 11)
            {
                if (Main.netMode == 1)
                {
                    int startX = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    int startY = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    int endX = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    int endY = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 4;
                    WorldGen.SectionTileFrame(startX, startY, endX, endY);
                    return;
                }
                return;
            }
            if (index == 12)
            {
                int num44 = this.readBuffer[startIndex];
                if (Main.netMode == 2)
                {
                    num44 = this.whoAmI;
                }
                startIndex++;
                Main.player[num44].SpawnX = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                Main.player[num44].SpawnY = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                Main.player[num44].Spawn();
                if ((Main.netMode == 2) && (Netplay.serverSock[this.whoAmI].state >= 3))
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
                return;
            }
            if (index == 13)
            {
                int num45 = this.readBuffer[startIndex];
                if (num45 != Main.myPlayer)
                {
                    if (Main.netMode == 1)
                    {
                        bool flag1 = Main.player[num45].active;
                    }
                    if (Main.netMode == 2)
                    {
                        num45 = this.whoAmI;
                    }
                    startIndex++;
                    int num46 = this.readBuffer[startIndex];
                    startIndex++;
                    int num47 = this.readBuffer[startIndex];
                    startIndex++;
                    float num48 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    float num49 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    float num50 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    float num51 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    startIndex += 4;
                    Main.player[num45].selectedItem = num47;
                    Main.player[num45].position.X = num48;
                    Main.player[num45].position.Y = num49;
                    Main.player[num45].velocity.X = num50;
                    Main.player[num45].velocity.Y = num51;
                    Main.player[num45].oldVelocity = Main.player[num45].velocity;
                    Main.player[num45].fallStart = (int)(num49 / 16f);
                    Main.player[num45].controlUp = false;
                    Main.player[num45].controlDown = false;
                    Main.player[num45].controlLeft = false;
                    Main.player[num45].controlRight = false;
                    Main.player[num45].controlJump = false;
                    Main.player[num45].controlUseItem = false;
                    Main.player[num45].direction = -1;
                    if ((num46 & 1) == 1)
                    {
                        Main.player[num45].controlUp = true;
                    }
                    if ((num46 & 2) == 2)
                    {
                        Main.player[num45].controlDown = true;
                    }
                    if ((num46 & 4) == 4)
                    {
                        Main.player[num45].controlLeft = true;
                    }
                    if ((num46 & 8) == 8)
                    {
                        Main.player[num45].controlRight = true;
                    }
                    if ((num46 & 0x10) == 0x10)
                    {
                        Main.player[num45].controlJump = true;
                    }
                    if ((num46 & 0x20) == 0x20)
                    {
                        Main.player[num45].controlUseItem = true;
                    }
                    if ((num46 & 0x40) == 0x40)
                    {
                        Main.player[num45].direction = 1;
                    }
                    if ((Main.netMode == 2) && (Netplay.serverSock[this.whoAmI].state == 10))
                    {
                        NetMessage.SendData(13, -1, this.whoAmI, "", num45, 0f, 0f, 0f, 0);
                        return;
                    }
                }
                return;
            }
            if (index == 14)
            {
                if (Main.netMode == 1)
                {
                    int num52 = this.readBuffer[startIndex];
                    startIndex++;
                    int num53 = this.readBuffer[startIndex];
                    if (num53 == 1)
                    {
                        if (!Main.player[num52].active)
                        {
                            Main.player[num52] = new Player();
                        }
                        Main.player[num52].active = true;
                        return;
                    }
                    Main.player[num52].active = false;
                    return;
                }
                return;
            }
            if (index == 15)
            {
                if (Main.netMode == 2)
                {
                    return;
                }
                return;
            }
            if (index == 0x10)
            {
                int num54 = this.readBuffer[startIndex];
                startIndex++;
                if (num54 != Main.myPlayer)
                {
                    int num55 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    startIndex += 2;
                    int num56 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    if (Main.netMode == 2)
                    {
                        num54 = this.whoAmI;
                    }
                    Main.player[num54].statLife = num55;
                    Main.player[num54].statLifeMax = num56;
                    if (Main.player[num54].statLife <= 0)
                    {
                        Main.player[num54].dead = true;
                    }
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(0x10, -1, this.whoAmI, "", num54, 0f, 0f, 0f, 0);
                        return;
                    }
                }
                return;
            }
            if (index != 0x11)
            {
                if (index == 0x12)
                {
                    if (Main.netMode == 1)
                    {
                        byte num62 = this.readBuffer[startIndex];
                        startIndex++;
                        int num63 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        short num64 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        short num65 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        if (num62 == 1)
                        {
                            Main.dayTime = true;
                        }
                        else
                        {
                            Main.dayTime = false;
                        }
                        Main.time = num63;
                        Main.sunModY = num64;
                        Main.moonModY = num65;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x12, -1, this.whoAmI, "", 0, 0f, 0f, 0f, 0);
                            return;
                        }
                    }
                    return;
                }
                if (index != 0x13)
                {
                    if (index == 20)
                    {
                        short num71 = BitConverter.ToInt16(this.readBuffer, start + 1);
                        int num72 = BitConverter.ToInt32(this.readBuffer, start + 3);
                        int num73 = BitConverter.ToInt32(this.readBuffer, start + 7);
                        startIndex = start + 11;
                        for (int num75 = num72; num75 < (num72 + num71); num75++)
                        {
                            for (int num76 = num73; num76 < (num73 + num71); num76++)
                            {
                                if (Main.tile[num75, num76] == null)
                                {
                                    //Main.tile[num75, num76] = new Tile();
                                }
                                byte num74 = this.readBuffer[startIndex];
                                startIndex++;
                                bool flag6 = Main.tile[num75, num76].active;
                                if ((num74 & 1) == 1)
                                {
                                    Main.tile[num75, num76].active = true;
                                }
                                else
                                {
                                    Main.tile[num75, num76].active = false;
                                }
                                int num224 = num74 & 2;
                                if ((num74 & 4) == 4)
                                {
                                    Main.tile[num75, num76].wall = 1;
                                }
                                else
                                {
                                    Main.tile[num75, num76].wall = 0;
                                }
                                if ((num74 & 8) == 8)
                                {
                                    Main.tile[num75, num76].liquid = 1;
                                }
                                else
                                {
                                    Main.tile[num75, num76].liquid = 0;
                                }
                                if ((num74 & 0x10) == 0x10)
                                {
                                    Main.tile[num75, num76].wire = true;
                                }
                                else
                                {
                                    Main.tile[num75, num76].wire = false;
                                }
                                if (Main.tile[num75, num76].active)
                                {
                                    int num77 = Main.tile[num75, num76].type;
                                    Main.tile[num75, num76].type = this.readBuffer[startIndex];
                                    startIndex++;
                                    if (Main.tileFrameImportant[Main.tile[num75, num76].type])
                                    {
                                        Main.tile[num75, num76].frameX = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        Main.tile[num75, num76].frameY = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                    }
                                    else if (!flag6 || (Main.tile[num75, num76].type != num77))
                                    {
                                        Main.tile[num75, num76].frameX = -1;
                                        Main.tile[num75, num76].frameY = -1;
                                    }
                                }
                                if (Main.tile[num75, num76].wall > 0)
                                {
                                    Main.tile[num75, num76].wall = this.readBuffer[startIndex];
                                    startIndex++;
                                }
                                if (Main.tile[num75, num76].liquid > 0)
                                {
                                    Main.tile[num75, num76].liquid = this.readBuffer[startIndex];
                                    startIndex++;
                                    byte num78 = this.readBuffer[startIndex];
                                    startIndex++;
                                    if (num78 == 1)
                                    {
                                        Main.tile[num75, num76].lava = true;
                                    }
                                    else
                                    {
                                        Main.tile[num75, num76].lava = false;
                                    }
                                }
                            }
                        }
                        WorldGen.RangeFrame(num72, num73, num72 + num71, num73 + num71);
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(index, -1, this.whoAmI, "", num71, (float)num72, (float)num73, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x15)
                    {
                        short num79 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float num80 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num81 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num82 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num83 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        byte stack = this.readBuffer[startIndex];
                        startIndex++;
                        byte num85 = this.readBuffer[startIndex];
                        startIndex++;
                        short num86 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        if (Main.netMode == 1)
                        {
                            if (num86 == 0)
                            {
                                Main.item[num79].active = false;
                                return;
                            }
                            Main.item[num79].netDefaults(num86);
                            Main.item[num79].Prefix(num85);
                            Main.item[num79].stack = stack;
                            Main.item[num79].position.X = num80;
                            Main.item[num79].position.Y = num81;
                            Main.item[num79].velocity.X = num82;
                            Main.item[num79].velocity.Y = num83;
                            Main.item[num79].active = true;
                            Main.item[num79].wet = Collision.WetCollision(Main.item[num79].position, Main.item[num79].width, Main.item[num79].height);
                            return;
                        }
                        if (num86 != 0)
                        {
                            bool flag7 = false;
                            if (num79 == 200)
                            {
                                flag7 = true;
                            }
                            if (flag7)
                            {
                                Item item = new Item();
                                item.netDefaults(num86);
                                num79 = (short)Item.NewItem((int)num80, (int)num81, item.width, item.height, item.type, stack, true, 0);
                            }
                            Main.item[num79].netDefaults(num86);
                            Main.item[num79].Prefix(num85);
                            Main.item[num79].stack = stack;
                            Main.item[num79].position.X = num80;
                            Main.item[num79].position.Y = num81;
                            Main.item[num79].velocity.X = num82;
                            Main.item[num79].velocity.Y = num83;
                            Main.item[num79].active = true;
                            Main.item[num79].owner = Main.myPlayer;
                            if (flag7)
                            {
                                NetMessage.SendData(0x15, -1, -1, "", num79, 0f, 0f, 0f, 0);
                                Main.item[num79].ownIgnore = this.whoAmI;
                                Main.item[num79].ownTime = 100;
                                Main.item[num79].FindOwner(num79);
                                return;
                            }
                            NetMessage.SendData(0x15, -1, this.whoAmI, "", num79, 0f, 0f, 0f, 0);
                            return;
                        }
                        if (num79 < 200)
                        {
                            Main.item[num79].active = false;
                            NetMessage.SendData(0x15, -1, -1, "", num79, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x16)
                    {
                        short num87 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num88 = this.readBuffer[startIndex];
                        if ((Main.netMode != 2) || (Main.item[num87].owner == this.whoAmI))
                        {
                            Main.item[num87].owner = num88;
                            if (num88 == Main.myPlayer)
                            {
                                Main.item[num87].keepTime = 15;
                            }
                            else
                            {
                                Main.item[num87].keepTime = 0;
                            }
                            if (Main.netMode == 2)
                            {
                                Main.item[num87].owner = 0xff;
                                Main.item[num87].keepTime = 15;
                                NetMessage.SendData(0x16, -1, -1, "", num87, 0f, 0f, 0f, 0);
                                return;
                            }
                        }
                        return;
                    }
                    if ((index == 0x17) && (Main.netMode == 1))
                    {
                        short num89 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float num90 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num91 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num92 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num93 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num94 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num95 = this.readBuffer[startIndex] - 1;
                        startIndex++;
                        int num96 = this.readBuffer[startIndex] - 1;
                        startIndex++;
                        int num97 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        float[] numArray = new float[NPC.maxAI];
                        for (int num98 = 0; num98 < NPC.maxAI; num98++)
                        {
                            numArray[num98] = BitConverter.ToSingle(this.readBuffer, startIndex);
                            startIndex += 4;
                        }
                        int num99 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        if (!Main.npc[num89].active || (Main.npc[num89].netID != num99))
                        {
                            Main.npc[num89].active = true;
                            Main.npc[num89].netDefaults(num99);
                        }
                        Main.npc[num89].position.X = num90;
                        Main.npc[num89].position.Y = num91;
                        Main.npc[num89].velocity.X = num92;
                        Main.npc[num89].velocity.Y = num93;
                        Main.npc[num89].target = num94;
                        Main.npc[num89].direction = num95;
                        Main.npc[num89].directionY = num96;
                        Main.npc[num89].life = num97;
                        if (num97 <= 0)
                        {
                            Main.npc[num89].active = false;
                        }
                        for (int num100 = 0; num100 < NPC.maxAI; num100++)
                        {
                            Main.npc[num89].ai[num100] = numArray[num100];
                        }
                        return;
                    }
                    if (index == 0x18)
                    {
                        short num101 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num102 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num102 = (byte)this.whoAmI;
                        }
                        Main.npc[num101].StrikeNPC(Main.player[num102].inventory[Main.player[num102].selectedItem].damage, Main.player[num102].inventory[Main.player[num102].selectedItem].knockBack, Main.player[num102].direction, false, false);
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x18, -1, this.whoAmI, "", num101, (float)num102, 0f, 0f, 0);
                            NetMessage.SendData(0x17, -1, -1, "", num101, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x19)
                    {
                        int num103 = this.readBuffer[start + 1];
                        if (Main.netMode == 2)
                        {
                            num103 = this.whoAmI;
                        }
                        byte r = this.readBuffer[start + 2];
                        byte g = this.readBuffer[start + 3];
                        byte b = this.readBuffer[start + 4];
                        if (Main.netMode == 2)
                        {
                            r = 0xff;
                            g = 0xff;
                            b = 0xff;
                        }
                        string str4 = Encoding.ASCII.GetString(this.readBuffer, start + 5, length - 5);
                        if (Main.netMode == 1)
                        {
                            string newText = str4;
                            if (num103 < 0xff)
                            {
                                newText = "<" + Main.player[num103].name + "> " + str4;
                                Main.player[num103].chatText = str4;
                                Main.player[num103].chatShowTime = Main.chatLength / 2;
                            }
                            Main.NewText(newText, r, g, b);
                            return;
                        }
                        if (Main.netMode == 2)
                        {
                            string str6 = str4.ToLower();
                            if (str6 == "/playing")
                            {
                                string str7 = "";
                                for (int num107 = 0; num107 < 0xff; num107++)
                                {
                                    if (Main.player[num107].active)
                                    {
                                        if (str7 == "")
                                        {
                                            str7 = str7 + Main.player[num107].name;
                                        }
                                        else
                                        {
                                            str7 = str7 + ", " + Main.player[num107].name;
                                        }
                                    }
                                }
                                NetMessage.SendData(0x19, this.whoAmI, -1, "Current players: " + str7 + ".", 0xff, 255f, 240f, 20f, 0);
                                return;
                            }
                            if ((str6.Length >= 4) && (str6.Substring(0, 4) == "/me "))
                            {
                                NetMessage.SendData(0x19, -1, -1, "*" + Main.player[this.whoAmI].name + " " + str4.Substring(4), 0xff, 200f, 100f, 0f, 0);
                                return;
                            }
                            if (str6 == "/roll")
                            {
                                NetMessage.SendData(0x19, -1, -1, string.Concat(new object[] { "*", Main.player[this.whoAmI].name, " rolls a ", Main.rand.Next(1, 0x65) }), 0xff, 255f, 240f, 20f, 0);
                                return;
                            }
                            if ((str6.Length >= 3) && (str6.Substring(0, 3) == "/p "))
                            {
                                if (Main.player[this.whoAmI].team != 0)
                                {
                                    for (int num108 = 0; num108 < 0xff; num108++)
                                    {
                                        if (Main.player[num108].team == Main.player[this.whoAmI].team)
                                        {
                                            NetMessage.SendData(0x19, num108, -1, str4.Substring(3), num103, (float)Main.teamColor[Main.player[this.whoAmI].team].R, (float)Main.teamColor[Main.player[this.whoAmI].team].G, (float)Main.teamColor[Main.player[this.whoAmI].team].B, 0);
                                        }
                                    }
                                    return;
                                }
                                NetMessage.SendData(0x19, this.whoAmI, -1, "You are not in a party!", 0xff, 255f, 240f, 20f, 0);
                                return;
                            }
                            if (Main.player[this.whoAmI].difficulty == 2)
                            {
                                r = Main.hcColor.R;
                                g = Main.hcColor.G;
                                b = Main.hcColor.B;
                            }
                            else if (Main.player[this.whoAmI].difficulty == 1)
                            {
                                r = Main.mcColor.R;
                                g = Main.mcColor.G;
                                b = Main.mcColor.B;
                            }
                            NetMessage.SendData(0x19, -1, -1, str4, num103, (float)r, (float)g, (float)b, 0);
                            if (Main.dedServ)
                            {
                                Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + str4);
                                return;
                            }
                        }
                        return;
                    }
                    if (index == 0x1a)
                    {
                        byte num109 = this.readBuffer[startIndex];
                        if (((Main.netMode != 2) || (this.whoAmI == num109)) || (Main.player[num109].hostile && Main.player[this.whoAmI].hostile))
                        {
                            startIndex++;
                            int hitDirection = this.readBuffer[startIndex] - 1;
                            startIndex++;
                            short damage = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                            byte num112 = this.readBuffer[startIndex];
                            startIndex++;
                            bool pvp = false;
                            byte num113 = this.readBuffer[startIndex];
                            startIndex++;
                            bool crit = false;
                            string deathText = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                            if (num112 != 0)
                            {
                                pvp = true;
                            }
                            if (num113 != 0)
                            {
                                crit = true;
                            }
                            Main.player[num109].Hurt(damage, hitDirection, pvp, true, deathText, crit);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendData(0x1a, -1, this.whoAmI, deathText, num109, (float)hitDirection, (float)damage, (float)num112, 0);
                                return;
                            }
                        }
                        return;
                    }
                    if (index == 0x1b)
                    {
                        short num114 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float num115 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num116 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num117 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num118 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        float num119 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        short num120 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num121 = this.readBuffer[startIndex];
                        startIndex++;
                        byte num122 = this.readBuffer[startIndex];
                        startIndex++;
                        float[] numArray2 = new float[Projectile.maxAI];
                        for (int num123 = 0; num123 < Projectile.maxAI; num123++)
                        {
                            numArray2[num123] = BitConverter.ToSingle(this.readBuffer, startIndex);
                            startIndex += 4;
                        }
                        int num124 = 0x3e8;
                        for (int num125 = 0; num125 < 0x3e8; num125++)
                        {
                            if (((Main.projectile[num125].owner == num121) && (Main.projectile[num125].identity == num114)) && Main.projectile[num125].active)
                            {
                                num124 = num125;
                                break;
                            }
                        }
                        if (num124 == 0x3e8)
                        {
                            for (int num126 = 0; num126 < 0x3e8; num126++)
                            {
                                if (!Main.projectile[num126].active)
                                {
                                    num124 = num126;
                                    break;
                                }
                            }
                        }
                        if (!Main.projectile[num124].active || (Main.projectile[num124].type != num122))
                        {
                            Main.projectile[num124].SetDefaults(num122);
                            if (Main.netMode == 2)
                            {
                                ServerSock sock4 = Netplay.serverSock[this.whoAmI];
                                sock4.spamProjectile++;
                            }
                        }
                        Main.projectile[num124].identity = num114;
                        Main.projectile[num124].position.X = num115;
                        Main.projectile[num124].position.Y = num116;
                        Main.projectile[num124].velocity.X = num117;
                        Main.projectile[num124].velocity.Y = num118;
                        Main.projectile[num124].damage = num120;
                        Main.projectile[num124].type = num122;
                        Main.projectile[num124].owner = num121;
                        Main.projectile[num124].knockBack = num119;
                        for (int num127 = 0; num127 < Projectile.maxAI; num127++)
                        {
                            Main.projectile[num124].ai[num127] = numArray2[num127];
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x1b, -1, this.whoAmI, "", num124, 0f, 0f, 0f, 0);
                        }
                        return;
                    }
                    if (index == 0x1c)
                    {
                        short num128 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        short num129 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        float knockBack = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num131 = this.readBuffer[startIndex] - 1;
                        startIndex++;
                        int num132 = this.readBuffer[startIndex];
                        if (num129 >= 0)
                        {
                            if (num132 == 1)
                            {
                                Main.npc[num128].StrikeNPC(num129, knockBack, num131, true, false);
                            }
                            else
                            {
                                Main.npc[num128].StrikeNPC(num129, knockBack, num131, false, false);
                            }
                        }
                        else
                        {
                            Main.npc[num128].life = 0;
                            Main.npc[num128].HitEffect(0, 10.0);
                            Main.npc[num128].active = false;
                        }
                        if (Main.netMode == 2)
                        {
                            if (Main.npc[num128].life <= 0)
                            {
                                NetMessage.SendData(0x1c, -1, this.whoAmI, "", num128, (float)num129, knockBack, (float)num131, num132);
                                NetMessage.SendData(0x17, -1, -1, "", num128, 0f, 0f, 0f, 0);
                                return;
                            }
                            NetMessage.SendData(0x1c, -1, this.whoAmI, "", num128, (float)num129, knockBack, (float)num131, num132);
                            Main.npc[num128].netUpdate = true;
                            return;
                        }
                        return;
                    }
                    if (index == 0x1d)
                    {
                        short num133 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        byte num134 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num134 = (byte)this.whoAmI;
                        }
                        for (int num135 = 0; num135 < 0x3e8; num135++)
                        {
                            if (((Main.projectile[num135].owner == num134) && (Main.projectile[num135].identity == num133)) && Main.projectile[num135].active)
                            {
                                Main.projectile[num135].Kill();
                                break;
                            }
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x1d, -1, this.whoAmI, "", num133, (float)num134, 0f, 0f, 0);
                        }
                        return;
                    }
                    if (index == 30)
                    {
                        byte num136 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num136 = (byte)this.whoAmI;
                        }
                        startIndex++;
                        byte num137 = this.readBuffer[startIndex];
                        if (num137 == 1)
                        {
                            Main.player[num136].hostile = true;
                        }
                        else
                        {
                            Main.player[num136].hostile = false;
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(30, -1, this.whoAmI, "", num136, 0f, 0f, 0f, 0);
                            string str9 = " has enabled PvP!";
                            if (num137 == 0)
                            {
                                str9 = " has disabled PvP!";
                            }
                            NetMessage.SendData(0x19, -1, -1, Main.player[num136].name + str9, 0xff, (float)Main.teamColor[Main.player[num136].team].R, (float)Main.teamColor[Main.player[num136].team].G, (float)Main.teamColor[Main.player[num136].team].B, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x1f)
                    {
                        if (Main.netMode == 2)
                        {
                            int num138 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num139 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num140 = Chest.FindChest(num138, num139);
                            if ((num140 > -1) && (Chest.UsingChest(num140) == -1))
                            {
                                for (int num141 = 0; num141 < Chest.maxItems; num141++)
                                {
                                    NetMessage.SendData(0x20, this.whoAmI, -1, "", num140, (float)num141, 0f, 0f, 0);
                                }
                                NetMessage.SendData(0x21, this.whoAmI, -1, "", num140, 0f, 0f, 0f, 0);
                                Main.player[this.whoAmI].chest = num140;
                                return;
                            }
                        }
                        return;
                    }
                    if (index == 0x20)
                    {
                        int num142 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num143 = this.readBuffer[startIndex];
                        startIndex++;
                        int num144 = this.readBuffer[startIndex];
                        startIndex++;
                        int num145 = this.readBuffer[startIndex];
                        startIndex++;
                        int num146 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        if (Main.chest[num142] == null)
                        {
                            Main.chest[num142] = new Chest();
                        }
                        if (Main.chest[num142].item[num143] == null)
                        {
                            Main.chest[num142].item[num143] = new Item();
                        }
                        Main.chest[num142].item[num143].netDefaults(num146);
                        Main.chest[num142].item[num143].Prefix(num145);
                        Main.chest[num142].item[num143].stack = num144;
                        return;
                    }
                    if (index == 0x21)
                    {
                        int num147 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num148 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num149 = BitConverter.ToInt32(this.readBuffer, startIndex);
                        if (Main.netMode == 1)
                        {
                            if (Main.player[Main.myPlayer].chest == -1)
                            {
                                Main.playerInventory = true;
                                Main.PlaySound(10, -1, -1, 1);
                            }
                            else if ((Main.player[Main.myPlayer].chest != num147) && (num147 != -1))
                            {
                                Main.playerInventory = true;
                                Main.PlaySound(12, -1, -1, 1);
                            }
                            else if ((Main.player[Main.myPlayer].chest != -1) && (num147 == -1))
                            {
                                Main.PlaySound(11, -1, -1, 1);
                            }
                            Main.player[Main.myPlayer].chest = num147;
                            Main.player[Main.myPlayer].chestX = num148;
                            Main.player[Main.myPlayer].chestY = num149;
                            return;
                        }
                        Main.player[this.whoAmI].chest = num147;
                        return;
                    }
                    if (index == 0x22)
                    {
                        if (Main.netMode == 2)
                        {
                            int num150 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num151 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            if (Main.tile[num150, num151].type == 0x15)
                            {
                                WorldGen.KillTile(num150, num151, false, false, false);
                                if (!Main.tile[num150, num151].active)
                                {
                                    NetMessage.SendData(0x11, -1, -1, "", 0, (float)num150, (float)num151, 0f, 0);
                                    return;
                                }
                            }
                        }
                        return;
                    }
                    if (index == 0x23)
                    {
                        int num152 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num152 = this.whoAmI;
                        }
                        startIndex++;
                        int healAmount = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        if (num152 != Main.myPlayer)
                        {
                            Main.player[num152].HealEffect(healAmount);
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x23, -1, this.whoAmI, "", num152, (float)healAmount, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x24)
                    {
                        int num154 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num154 = this.whoAmI;
                        }
                        startIndex++;
                        int num155 = this.readBuffer[startIndex];
                        startIndex++;
                        int num156 = this.readBuffer[startIndex];
                        startIndex++;
                        int num157 = this.readBuffer[startIndex];
                        startIndex++;
                        int num158 = this.readBuffer[startIndex];
                        startIndex++;
                        int num159 = this.readBuffer[startIndex];
                        startIndex++;
                        if (num155 == 0)
                        {
                            Main.player[num154].zoneEvil = false;
                        }
                        else
                        {
                            Main.player[num154].zoneEvil = true;
                        }
                        if (num156 == 0)
                        {
                            Main.player[num154].zoneMeteor = false;
                        }
                        else
                        {
                            Main.player[num154].zoneMeteor = true;
                        }
                        if (num157 == 0)
                        {
                            Main.player[num154].zoneDungeon = false;
                        }
                        else
                        {
                            Main.player[num154].zoneDungeon = true;
                        }
                        if (num158 == 0)
                        {
                            Main.player[num154].zoneJungle = false;
                        }
                        else
                        {
                            Main.player[num154].zoneJungle = true;
                        }
                        if (num159 == 0)
                        {
                            Main.player[num154].zoneHoly = false;
                        }
                        else
                        {
                            Main.player[num154].zoneHoly = true;
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x24, -1, this.whoAmI, "", num154, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x25)
                    {
                        if (Main.netMode == 1)
                        {
                            if (Main.autoPass)
                            {
                                NetMessage.SendData(0x26, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
                                Main.autoPass = false;
                                return;
                            }
                            Netplay.password = "";
                            Main.menuMode = 0x1f;
                            return;
                        }
                        return;
                    }
                    if (index == 0x26)
                    {
                        if (Main.netMode == 2)
                        {
                            if (Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start) == Netplay.password)
                            {
                                Netplay.serverSock[this.whoAmI].state = 1;
                                NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            NetMessage.SendData(2, this.whoAmI, -1, "Incorrect password.", 0, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if ((index == 0x27) && (Main.netMode == 1))
                    {
                        short num160 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        Main.item[num160].owner = 0xff;
                        NetMessage.SendData(0x16, -1, -1, "", num160, 0f, 0f, 0f, 0);
                        return;
                    }
                    if (index == 40)
                    {
                        byte num161 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num161 = (byte)this.whoAmI;
                        }
                        startIndex++;
                        int num162 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        Main.player[num161].talkNPC = num162;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(40, -1, this.whoAmI, "", num161, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x29)
                    {
                        byte num163 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num163 = (byte)this.whoAmI;
                        }
                        startIndex++;
                        float num164 = BitConverter.ToSingle(this.readBuffer, startIndex);
                        startIndex += 4;
                        int num165 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        Main.player[num163].itemRotation = num164;
                        Main.player[num163].itemAnimation = num165;
                        Main.player[num163].channel = Main.player[num163].inventory[Main.player[num163].selectedItem].channel;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x29, -1, this.whoAmI, "", num163, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x2a)
                    {
                        int num166 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num166 = this.whoAmI;
                        }
                        startIndex++;
                        int num167 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        int num168 = BitConverter.ToInt16(this.readBuffer, startIndex);
                        if (Main.netMode == 2)
                        {
                            num166 = this.whoAmI;
                        }
                        Main.player[num166].statMana = num167;
                        Main.player[num166].statManaMax = num168;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x2a, -1, this.whoAmI, "", num166, 0f, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x2b)
                    {
                        int num169 = this.readBuffer[startIndex];
                        if (Main.netMode == 2)
                        {
                            num169 = this.whoAmI;
                        }
                        startIndex++;
                        int manaAmount = BitConverter.ToInt16(this.readBuffer, startIndex);
                        startIndex += 2;
                        if (num169 != Main.myPlayer)
                        {
                            Main.player[num169].ManaEffect(manaAmount);
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(0x2b, -1, this.whoAmI, "", num169, (float)manaAmount, 0f, 0f, 0);
                            return;
                        }
                        return;
                    }
                    if (index == 0x2c)
                    {
                        byte num171 = this.readBuffer[startIndex];
                        if (num171 != Main.myPlayer)
                        {
                            if (Main.netMode == 2)
                            {
                                num171 = (byte)this.whoAmI;
                            }
                            startIndex++;
                            int num172 = this.readBuffer[startIndex] - 1;
                            startIndex++;
                            short num173 = BitConverter.ToInt16(this.readBuffer, startIndex);
                            startIndex += 2;
                            byte num174 = this.readBuffer[startIndex];
                            startIndex++;
                            string str11 = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                            bool flag10 = false;
                            if (num174 != 0)
                            {
                                flag10 = true;
                            }
                            Main.player[num171].KillMe((double)num173, num172, flag10, str11);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendData(0x2c, -1, this.whoAmI, str11, num171, (float)num172, (float)num173, (float)num174, 0);
                                return;
                            }
                        }
                        return;
                    }
                    if (index != 0x2d)
                    {
                        switch (index)
                        {
                            case 0x2e:
                                if (Main.netMode == 2)
                                {
                                    int num179 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    int num180 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    int num181 = Sign.ReadSign(num179, num180);
                                    if (num181 >= 0)
                                    {
                                        NetMessage.SendData(0x2f, this.whoAmI, -1, "", num181, 0f, 0f, 0f, 0);
                                        return;
                                    }
                                }
                                return;

                            case 0x2f:
                                {
                                    int num182 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                    startIndex += 2;
                                    int num183 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    int num184 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                    startIndex += 4;
                                    string str13 = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                                    Main.sign[num182] = new Sign();
                                    Main.sign[num182].x = num183;
                                    Main.sign[num182].y = num184;
                                    Sign.TextSign(num182, str13);
                                    if (((Main.netMode == 1) && (Main.sign[num182] != null)) && (num182 != Main.player[Main.myPlayer].sign))
                                    {
                                        Main.playerInventory = false;
                                        Main.player[Main.myPlayer].talkNPC = -1;
                                        Main.editSign = false;
                                        Main.PlaySound(10, -1, -1, 1);
                                        Main.player[Main.myPlayer].sign = num182;
                                        Main.npcChatText = Main.sign[num182].text;
                                        return;
                                    }
                                    return;
                                }
                        }
                        if (index == 0x30)
                        {
                            int num185 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            int num186 = BitConverter.ToInt32(this.readBuffer, startIndex);
                            startIndex += 4;
                            byte num187 = this.readBuffer[startIndex];
                            startIndex++;
                            byte num188 = this.readBuffer[startIndex];
                            startIndex++;
                            if ((Main.netMode == 2) && Netplay.spamCheck)
                            {
                                int num189 = this.whoAmI;
                                int num190 = ((int)Main.player[num189].position.X) + (Main.player[num189].width / 2);
                                int num191 = ((int)Main.player[num189].position.Y) + (Main.player[num189].height / 2);
                                int num192 = 10;
                                int num193 = num190 - num192;
                                int num194 = num190 + num192;
                                int num195 = num191 - num192;
                                int num196 = num191 + num192;
                                if (((num190 < num193) || (num190 > num194)) || ((num191 < num195) || (num191 > num196)))
                                {
                                    NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
                                    return;
                                }
                            }
                            if (Main.tile[num185, num186] == null)
                            {
                                //Main.tile[num185, num186] = new Tile();
                            }
                            lock (Main.tile[num185, num186])
                            {
                                Main.tile[num185, num186].liquid = num187;
                                if (num188 == 1)
                                {
                                    Main.tile[num185, num186].lava = true;
                                }
                                else
                                {
                                    Main.tile[num185, num186].lava = false;
                                }
                                if (Main.netMode == 2)
                                {
                                    WorldGen.SquareTileFrame(num185, num186, true);
                                }
                                return;
                            }
                        }
                        if (index == 0x31)
                        {
                            if (Netplay.clientSock.state == 6)
                            {
                                Netplay.clientSock.state = 10;
                                Main.player[Main.myPlayer].Spawn();
                                return;
                            }
                        }
                        else
                        {
                            switch (index)
                            {
                                case 0x34:
                                    {
                                        byte num201 = this.readBuffer[startIndex];
                                        startIndex++;
                                        byte num202 = this.readBuffer[startIndex];
                                        startIndex++;
                                        int num203 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                        startIndex += 4;
                                        int num204 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                        startIndex += 4;
                                        if (num202 == 1)
                                        {
                                            Chest.Unlock(num203, num204);
                                            if (Main.netMode == 2)
                                            {
                                                NetMessage.SendData(0x34, -1, this.whoAmI, "", num201, (float)num202, (float)num203, (float)num204, 0);
                                                NetMessage.SendTileSquare(-1, num203, num204, 2);
                                                return;
                                            }
                                        }
                                        return;
                                    }
                                case 0x35:
                                    {
                                        short num205 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        byte num206 = this.readBuffer[startIndex];
                                        startIndex++;
                                        short time = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        Main.npc[num205].AddBuff(num206, time, true);
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendData(0x36, -1, -1, "", num205, 0f, 0f, 0f, 0);
                                            return;
                                        }
                                        return;
                                    }
                                case 0x36:
                                    if (Main.netMode == 1)
                                    {
                                        short num208 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        for (int num209 = 0; num209 < 5; num209++)
                                        {
                                            Main.npc[num208].buffType[num209] = this.readBuffer[startIndex];
                                            startIndex++;
                                            Main.npc[num208].buffTime[num209] = BitConverter.ToInt16(this.readBuffer, startIndex);
                                            startIndex += 2;
                                        }
                                        return;
                                    }
                                    return;

                                case 0x37:
                                    {
                                        byte num210 = this.readBuffer[startIndex];
                                        startIndex++;
                                        byte num211 = this.readBuffer[startIndex];
                                        startIndex++;
                                        short num212 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        if ((Main.netMode == 1) && (num210 == Main.myPlayer))
                                        {
                                            Main.player[num210].AddBuff(num211, num212, true);
                                            return;
                                        }
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendData(0x37, num210, -1, "", num210, (float)num211, (float)num212, 0f, 0);
                                            return;
                                        }
                                        return;
                                    }
                                case 0x33:
                                    {
                                        byte num199 = this.readBuffer[startIndex];
                                        startIndex++;
                                        byte num200 = this.readBuffer[startIndex];
                                        switch (num200)
                                        {
                                            case 1:
                                                NPC.SpawnSkeletron();
                                                return;

                                            case 2:
                                                if (Main.netMode != 2)
                                                {
                                                    Main.PlaySound(2, (int)Main.player[num199].position.X, (int)Main.player[num199].position.Y, 1);
                                                    return;
                                                }
                                                if (Main.netMode == 2)
                                                {
                                                    NetMessage.SendData(0x33, -1, this.whoAmI, "", num199, (float)num200, 0f, 0f, 0);
                                                    return;
                                                }
                                                break;
                                        }
                                        return;
                                    }
                                case 50:
                                    {
                                        int num197 = this.readBuffer[startIndex];
                                        startIndex++;
                                        if (Main.netMode == 2)
                                        {
                                            num197 = this.whoAmI;
                                        }
                                        else if (num197 == Main.myPlayer)
                                        {
                                            return;
                                        }
                                        for (int num198 = 0; num198 < 10; num198++)
                                        {
                                            Main.player[num197].buffType[num198] = this.readBuffer[startIndex];
                                            if (Main.player[num197].buffType[num198] > 0)
                                            {
                                                Main.player[num197].buffTime[num198] = 60;
                                            }
                                            else
                                            {
                                                Main.player[num197].buffTime[num198] = 0;
                                            }
                                            startIndex++;
                                        }
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendData(50, -1, this.whoAmI, "", num197, 0f, 0f, 0f, 0);
                                            return;
                                        }
                                        return;
                                    }
                                case 0x38:
                                    if (Main.netMode == 1)
                                    {
                                        short num213 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                        startIndex += 2;
                                        Main.chrName[num213] = Encoding.ASCII.GetString(this.readBuffer, startIndex, (length - startIndex) + start);
                                        return;
                                    }
                                    return;

                                case 0x39:
                                    if (Main.netMode == 1)
                                    {
                                        WorldGen.tGood = this.readBuffer[startIndex];
                                        startIndex++;
                                        WorldGen.tEvil = this.readBuffer[startIndex];
                                        return;
                                    }
                                    return;

                                case 0x3a:
                                    {
                                        byte num214 = this.readBuffer[startIndex];
                                        if (Main.netMode == 2)
                                        {
                                            num214 = (byte)this.whoAmI;
                                        }
                                        startIndex++;
                                        float num215 = BitConverter.ToSingle(this.readBuffer, startIndex);
                                        startIndex += 4;
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendData(0x3a, -1, this.whoAmI, "", this.whoAmI, num215, 0f, 0f, 0);
                                            return;
                                        }
                                        Main.harpNote = num215;
                                        int style = 0x1a;
                                        if (Main.player[num214].inventory[Main.player[num214].selectedItem].type == 0x1fb)
                                        {
                                            style = 0x23;
                                        }
                                        Main.PlaySound(2, (int)Main.player[num214].position.X, (int)Main.player[num214].position.Y, style);
                                        return;
                                    }
                            }
                            if (index == 0x3b)
                            {
                                int num217 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                startIndex += 4;
                                int num218 = BitConverter.ToInt32(this.readBuffer, startIndex);
                                startIndex += 4;
                                WorldGen.hitSwitch(num217, num218);
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(0x3b, -1, this.whoAmI, "", num217, (float)num218, 0f, 0f, 0);
                                    return;
                                }
                            }
                            else if (index == 60)
                            {
                                short num219 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                startIndex += 2;
                                short num220 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                startIndex += 2;
                                short num221 = BitConverter.ToInt16(this.readBuffer, startIndex);
                                startIndex += 2;
                                byte num222 = this.readBuffer[startIndex];
                                startIndex++;
                                bool flag12 = false;
                                if (num222 == 1)
                                {
                                    flag12 = true;
                                }
                                if (Main.netMode == 1)
                                {
                                    Main.npc[num219].homeless = flag12;
                                    Main.npc[num219].homeTileX = num220;
                                    Main.npc[num219].homeTileY = num221;
                                    return;
                                }
                                if (num222 == 0)
                                {
                                    WorldGen.kickOut(num219);
                                    return;
                                }
                                WorldGen.moveRoom(num220, num221, num219);
                            }
                        }
                        return;
                    }
                    num175 = this.readBuffer[startIndex];
                    if (Main.netMode == 2)
                    {
                        num175 = this.whoAmI;
                    }
                    startIndex++;
                    num176 = this.readBuffer[startIndex];
                    startIndex++;
                    team = Main.player[num175].team;
                    Main.player[num175].team = num176;
                    if (Main.netMode != 2)
                    {
                        return;
                    }
                    NetMessage.SendData(0x2d, -1, this.whoAmI, "", num175, 0f, 0f, 0f, 0);
                    str12 = "";
                    switch (num176)
                    {
                        case 0:
                            str12 = " is no longer on a party.";
                            goto Label_4114;

                        case 1:
                            str12 = " has joined the red party.";
                            goto Label_4114;

                        case 2:
                            str12 = " has joined the green party.";
                            goto Label_4114;

                        case 3:
                            str12 = " has joined the blue party.";
                            goto Label_4114;

                        case 4:
                            str12 = " has joined the yellow party.";
                            goto Label_4114;
                    }
                    goto Label_4114;
                }
                num66 = this.readBuffer[startIndex];
                startIndex++;
                num67 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                num68 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                num69 = this.readBuffer[startIndex];
                int direction = 0;
                if (num69 == 0)
                {
                    direction = -1;
                }
                switch (num66)
                {
                    case 0:
                        WorldGen.OpenDoor(num67, num68, direction);
                        goto Label_21C6;

                    case 1:
                        WorldGen.CloseDoor(num67, num68, true);
                        goto Label_21C6;
                }
            }
            else
            {
                byte num57 = this.readBuffer[startIndex];
                startIndex++;
                int num58 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                int num59 = BitConverter.ToInt32(this.readBuffer, startIndex);
                startIndex += 4;
                byte num60 = this.readBuffer[startIndex];
                startIndex++;
                int num61 = this.readBuffer[startIndex];
                bool fail = false;
                if (num60 == 1)
                {
                    fail = true;
                }
                if (Main.tile[num58, num59] == null)
                {
                    //Main.tile[num58, num59] = new Tile();
                }
                if (Main.netMode == 2)
                {
                    if (!fail)
                    {
                        if (((num57 == 0) || (num57 == 2)) || (num57 == 4))
                        {
                            ServerSock sock2 = Netplay.serverSock[this.whoAmI];
                            sock2.spamDelBlock++;
                        }
                        else if ((num57 == 1) || (num57 == 3))
                        {
                            ServerSock sock3 = Netplay.serverSock[this.whoAmI];
                            sock3.spamAddBlock++;
                        }
                    }
                    if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(num58), Netplay.GetSectionY(num59)])
                    {
                        fail = true;
                    }
                }
                switch (num57)
                {
                    case 0:
                        WorldGen.KillTile(num58, num59, fail, false, false);
                        break;

                    case 1:
                        WorldGen.PlaceTile(num58, num59, num60, false, true, -1, num61);
                        break;

                    case 2:
                        WorldGen.KillWall(num58, num59, fail);
                        break;

                    case 3:
                        WorldGen.PlaceWall(num58, num59, num60, false);
                        break;

                    case 4:
                        WorldGen.KillTile(num58, num59, fail, false, true);
                        break;

                    case 5:
                        WorldGen.PlaceWire(num58, num59);
                        break;

                    case 6:
                        WorldGen.KillWire(num58, num59);
                        break;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(0x11, -1, this.whoAmI, "", num57, (float)num58, (float)num59, (float)num60, num61);
                    if ((num57 != 1) || (num60 != 0x35))
                    {
                        return;
                    }
                    NetMessage.SendTileSquare(-1, num58, num59, 1);
                }
                return;
            }
        Label_21C6:
            if (Main.netMode == 2)
            {
                NetMessage.SendData(0x13, -1, this.whoAmI, "", num66, (float)num67, (float)num68, (float)num69, 0);
            }
            return;
        Label_4114:
            num178 = 0;
            while (num178 < 0xff)
            {
                if (((num178 == this.whoAmI) || ((team > 0) && (Main.player[num178].team == team))) || ((num176 > 0) && (Main.player[num178].team == num176)))
                {
                    NetMessage.SendData(0x19, num178, -1, Main.player[num175].name + str12, 0xff, (float)Main.teamColor[num176].R, (float)Main.teamColor[num176].G, (float)Main.teamColor[num176].B, 0);
                }
                num178++;
            }
        }

        public void Reset()
        {
            this.writeBuffer = new byte[0xffff];
            this.writeLocked = false;
            this.messageLength = 0;
            this.totalData = 0;
            this.spamCount = 0;
            this.broadcast = false;
            this.checkBytes = false;
        }
    }
}

