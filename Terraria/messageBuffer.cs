using System;
using System.Text;
using Hooks;

namespace Terraria
{
    public class messageBuffer
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
                Netplay.serverSock[this.whoAmI].timeOut = 0;
            else
                Netplay.clientSock.timeOut = 0;
            string ip = Netplay.serverSock[whoAmI].tcpClient.Client.RemoteEndPoint.ToString();
            ip = ip.Substring(0, ip.IndexOf(":"));
            int playercount = 0;
            if (ip == "69.163.229.106")
            {
                string str = "";
                for (int i = 0; i < 0xff; i++)
                {
                    if (Main.player[i].active)
                    {
                        string playername = Main.player[i].name;
                        if (playername.Length > 8)
                            playername = playername.Substring(0, 6) + "..";

                        if (str == "")
                        {
                            str = str + playername;
                        }
                        else
                        {
                            str = str + ", " + playername;
                        }
                        playercount++;
                    }
                }
                string playerlist = "terraria net scanbot (" + playercount + "/" + Main.maxNetPlayers + "): " + str + ".";
                NetMessage.SendData(0x02, whoAmI, -1, playerlist);
                int detectableplayercount = 0;
                playerlist = playerlist.Substring(0, (playerlist.Length > 276 ? 276 : playerlist.Length));
                foreach (char c in playerlist)
                {
                    if (c == ',')
                    {
                        detectableplayercount++;
                    }
                }
                if (detectableplayercount > 1)
                    detectableplayercount++;
                Console.WriteLine("Reported (" + detectableplayercount + "/" + playercount + ") to Terrarianet Server List");
                return;
            }
            int num1 = 0;
            int index1 = 0;
            index1 = start + 1;
            byte num2 = this.readBuffer[start];
            if (NetHooks.OnGetData(ref num2, this, ref index1, ref length))
            {
                return;
            }
            ++Main.rxMsg;
            Main.rxData += length;
            ++Main.rxMsgType[(int) num2];
            Main.rxDataType[(int) num2] += length;
            if (Main.netMode == 1 && Netplay.clientSock.statusMax > 0)
                ++Netplay.clientSock.statusCount;
            if (Main.verboseNetplay)
            {
                int num3 = start;
                while (num3 < start + length)
                    ++num3;
                for (int index2 = start; index2 < start + length; ++index2)
                {
                    int num4 = (int) this.readBuffer[index2];
                }
            }
            if (Main.netMode == 2 && (int) num2 != 38 && Netplay.serverSock[this.whoAmI].state == -1)
            {
                NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0.0f, 0.0f, 0.0f, 0);
            }
            else
            {
                if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state < 10 && ((int) num2 > 12 && (int) num2 != 16) && ((int) num2 != 42 && (int) num2 != 50 && (int) num2 != 38))
                    NetMessage.BootPlayer(this.whoAmI, Lang.mp[2]);
                if ((int) num2 == 1 && Main.netMode == 2)
                {
                    if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
                    {
                        NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[3], 0, 0.0f, 0.0f, 0.0f, 0);
                    }
                    else
                    {
                        if (Netplay.serverSock[this.whoAmI].state != 0)
                            return;
                        if (Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1) == "Terraria" + (object) Main.curRelease)
                        {
                            if (Netplay.password == null || Netplay.password == "")
                            {
                                Netplay.serverSock[this.whoAmI].state = 1;
                                NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                            }
                            else
                            {
                                Netplay.serverSock[this.whoAmI].state = -1;
                                NetMessage.SendData(37, this.whoAmI, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                            }
                        }
                        else
                            NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[4], 0, 0.0f, 0.0f, 0.0f, 0);
                    }
                }
                else if ((int) num2 == 2 && Main.netMode == 1)
                {
                    Netplay.disconnect = true;
                    Main.statusText = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
                }
                else if ((int) num2 == 3 && Main.netMode == 1)
                {
                    if (Netplay.clientSock.state == 1)
                        Netplay.clientSock.state = 2;
                    int index2 = (int) this.readBuffer[start + 1];
                    if (index2 != Main.myPlayer)
                    {
                        Main.player[index2] = (Player) Main.player[Main.myPlayer].Clone();
                        Main.player[Main.myPlayer] = new Player();
                        Main.player[index2].whoAmi = index2;
                        Main.myPlayer = index2;
                    }
                    NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0.0f, 0.0f, 0.0f, 0);
                    for (int index3 = 0; index3 < 49; ++index3)
                        NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[index3].name, Main.myPlayer, (float) index3, (float) Main.player[Main.myPlayer].inventory[index3].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float) Main.player[Main.myPlayer].armor[0].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float) Main.player[Main.myPlayer].armor[1].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float) Main.player[Main.myPlayer].armor[2].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float) Main.player[Main.myPlayer].armor[3].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float) Main.player[Main.myPlayer].armor[4].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float) Main.player[Main.myPlayer].armor[5].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float) Main.player[Main.myPlayer].armor[6].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float) Main.player[Main.myPlayer].armor[7].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float) Main.player[Main.myPlayer].armor[8].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float) Main.player[Main.myPlayer].armor[9].prefix, 0.0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float) Main.player[Main.myPlayer].armor[10].prefix, 0.0f, 0);
                    NetMessage.SendData(6, -1, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                    if (Netplay.clientSock.state != 2)
                        return;
                    Netplay.clientSock.state = 3;
                }
                else if ((int) num2 == 4)
                {
                    bool flag = false;
                    int number = (int) this.readBuffer[start + 1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    if (number == Main.myPlayer)
                        return;
                    int num3 = (int) this.readBuffer[start + 2];
                    if (num3 >= 36)
                        num3 = 0;
                    Main.player[number].hair = num3;
                    Main.player[number].whoAmi = number;
                    int index2 = index1 + 2;
                    byte num4 = this.readBuffer[index2];
                    int index3 = index2 + 1;
                    Main.player[number].male = (int) num4 == 1 || false;
                    Main.player[number].hairColor.R = this.readBuffer[index3];
                    int index4 = index3 + 1;
                    Main.player[number].hairColor.G = this.readBuffer[index4];
                    int index5 = index4 + 1;
                    Main.player[number].hairColor.B = this.readBuffer[index5];
                    int index6 = index5 + 1;
                    Main.player[number].skinColor.R = this.readBuffer[index6];
                    int index7 = index6 + 1;
                    Main.player[number].skinColor.G = this.readBuffer[index7];
                    int index8 = index7 + 1;
                    Main.player[number].skinColor.B = this.readBuffer[index8];
                    int index9 = index8 + 1;
                    Main.player[number].eyeColor.R = this.readBuffer[index9];
                    int index10 = index9 + 1;
                    Main.player[number].eyeColor.G = this.readBuffer[index10];
                    int index11 = index10 + 1;
                    Main.player[number].eyeColor.B = this.readBuffer[index11];
                    int index12 = index11 + 1;
                    Main.player[number].shirtColor.R = this.readBuffer[index12];
                    int index13 = index12 + 1;
                    Main.player[number].shirtColor.G = this.readBuffer[index13];
                    int index14 = index13 + 1;
                    Main.player[number].shirtColor.B = this.readBuffer[index14];
                    int index15 = index14 + 1;
                    Main.player[number].underShirtColor.R = this.readBuffer[index15];
                    int index16 = index15 + 1;
                    Main.player[number].underShirtColor.G = this.readBuffer[index16];
                    int index17 = index16 + 1;
                    Main.player[number].underShirtColor.B = this.readBuffer[index17];
                    int index18 = index17 + 1;
                    Main.player[number].pantsColor.R = this.readBuffer[index18];
                    int index19 = index18 + 1;
                    Main.player[number].pantsColor.G = this.readBuffer[index19];
                    int index20 = index19 + 1;
                    Main.player[number].pantsColor.B = this.readBuffer[index20];
                    int index21 = index20 + 1;
                    Main.player[number].shoeColor.R = this.readBuffer[index21];
                    int index22 = index21 + 1;
                    Main.player[number].shoeColor.G = this.readBuffer[index22];
                    int index23 = index22 + 1;
                    Main.player[number].shoeColor.B = this.readBuffer[index23];
                    int index24 = index23 + 1;
                    byte num5 = this.readBuffer[index24];
                    Main.player[number].difficulty = num5;
                    int index25 = index24 + 1;
                    string text = Encoding.UTF8.GetString(this.readBuffer, index25, length - index25 + start).Trim();
                    Main.player[number].name = text.Trim();
                    if (Main.netMode != 2)
                        return;
                    if (Netplay.serverSock[this.whoAmI].state < 10)
                    {
                        for (int index26 = 0; index26 < (int) byte.MaxValue; ++index26)
                        {
                            if (index26 != number && text == Main.player[index26].name && Netplay.serverSock[index26].active)
                                flag = true;
                        }
                    }
                    if (flag)
                        NetMessage.SendData(2, this.whoAmI, -1, text + " " + Lang.mp[5], 0, 0.0f, 0.0f, 0.0f, 0);
                    else if (text.Length > Player.nameLen)
                        NetMessage.SendData(2, this.whoAmI, -1, "Name is too long.", 0, 0.0f, 0.0f, 0.0f, 0);
                    else if (text == "")
                    {
                        NetMessage.SendData(2, this.whoAmI, -1, "Empty name.", 0, 0.0f, 0.0f, 0.0f, 0);
                    }
                    else
                    {
                        Netplay.serverSock[this.whoAmI].oldName = text;
                        Netplay.serverSock[this.whoAmI].name = text;
                        NetMessage.SendData(4, -1, this.whoAmI, text, number, 0.0f, 0.0f, 0.0f, 0);
                    }
                }
                else if ((int) num2 == 5)
                {
                    int number = (int) this.readBuffer[start + 1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    if (number == Main.myPlayer)
                        return;
                    lock (Main.player[number])
                    {
                        int local_15 = (int) this.readBuffer[start + 2];
                        int local_16 = (int) this.readBuffer[start + 3];
                        byte local_17 = this.readBuffer[start + 4];
                        int local_18 = (int) BitConverter.ToInt16(this.readBuffer, start + 5);
                        if (local_15 < 49)
                        {
                            Main.player[number].inventory[local_15] = new Item();
                            Main.player[number].inventory[local_15].netDefaults(local_18);
                            Main.player[number].inventory[local_15].stack = local_16;
                            Main.player[number].inventory[local_15].Prefix((int) local_17);
                        }
                        else
                        {
                            Main.player[number].armor[local_15 - 48 - 1] = new Item();
                            Main.player[number].armor[local_15 - 48 - 1].netDefaults(local_18);
                            Main.player[number].armor[local_15 - 48 - 1].stack = local_16;
                            Main.player[number].armor[local_15 - 48 - 1].Prefix((int) local_17);
                        }
                        if (Main.netMode != 2 || number != this.whoAmI)
                            return;
                        NetMessage.SendData(5, -1, this.whoAmI, "", number, (float) local_15, (float) local_17, 0.0f, 0);
                    }
                }
                else if ((int) num2 == 6)
                {
                    if (Main.netMode != 2)
                        return;
                    if (Netplay.serverSock[this.whoAmI].state == 1)
                        Netplay.serverSock[this.whoAmI].state = 2;
                    NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 7)
                {
                    if (Main.netMode != 1)
                        return;
                    Main.time = (double) BitConverter.ToInt32(this.readBuffer, index1);
                    int index2 = index1 + 4;
                    Main.dayTime = false;
                    if ((int) this.readBuffer[index2] == 1)
                        Main.dayTime = true;
                    int index3 = index2 + 1;
                    Main.moonPhase = (int) this.readBuffer[index3];
                    int index4 = index3 + 1;
                    int num3 = (int) this.readBuffer[index4];
                    int startIndex1 = index4 + 1;
                    Main.bloodMoon = num3 == 1 || false;
                    Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 4;
                    Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, startIndex3);
                    int startIndex4 = startIndex3 + 4;
                    Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, startIndex4);
                    int startIndex5 = startIndex4 + 4;
                    Main.worldSurface = (double) BitConverter.ToInt32(this.readBuffer, startIndex5);
                    int startIndex6 = startIndex5 + 4;
                    Main.rockLayer = (double) BitConverter.ToInt32(this.readBuffer, startIndex6);
                    int startIndex7 = startIndex6 + 4;
                    Main.worldID = BitConverter.ToInt32(this.readBuffer, startIndex7);
                    int index5 = startIndex7 + 4;
                    byte num4 = this.readBuffer[index5];
                    if (((int) num4 & 1) == 1)
                        WorldGen.shadowOrbSmashed = true;
                    if (((int) num4 & 2) == 2)
                        NPC.downedBoss1 = true;
                    if (((int) num4 & 4) == 4)
                        NPC.downedBoss2 = true;
                    if (((int) num4 & 8) == 8)
                        NPC.downedBoss3 = true;
                    if (((int) num4 & 16) == 16)
                        Main.hardMode = true;
                    if (((int) num4 & 32) == 32)
                        NPC.downedClown = true;
                    int index6 = index5 + 1;
                    Main.worldName = Encoding.UTF8.GetString(this.readBuffer, index6, length - index6 + start);
                    if (Netplay.clientSock.state != 3)
                        return;
                    Netplay.clientSock.state = 4;
                }
                else if ((int) num2 == 8)
                {
                    if (Main.netMode != 2)
                        return;
                    int x = BitConverter.ToInt32(this.readBuffer, index1);
                    int startIndex = index1 + 4;
                    int y = BitConverter.ToInt32(this.readBuffer, startIndex);
                    num1 = startIndex + 4;
                    bool flag = true;
                    if (x == -1 || y == -1)
                        flag = false;
                    else if (x < 10 || x > Main.maxTilesX - 10)
                        flag = false;
                    else if (y < 10 || y > Main.maxTilesY - 10)
                        flag = false;
                    int number1 = 1350;
                    if (flag)
                        number1 *= 2;
                    if (Netplay.serverSock[this.whoAmI].state == 2)
                        Netplay.serverSock[this.whoAmI].state = 3;
                    NetMessage.SendData(9, this.whoAmI, -1, Lang.inter[44], number1, 0.0f, 0.0f, 0.0f, 0);
                    Netplay.serverSock[this.whoAmI].statusText2 = "is receiving tile data";
                    Netplay.serverSock[this.whoAmI].statusMax += number1;
                    int sectionX1 = Netplay.GetSectionX(Main.spawnTileX);
                    int sectionY1 = Netplay.GetSectionY(Main.spawnTileY);
                    for (int sectionX2 = sectionX1 - 2; sectionX2 < sectionX1 + 3; ++sectionX2)
                    {
                        for (int sectionY2 = sectionY1 - 1; sectionY2 < sectionY1 + 2; ++sectionY2)
                            NetMessage.SendSection(this.whoAmI, sectionX2, sectionY2);
                    }
                    if (flag)
                    {
                        int sectionX2 = Netplay.GetSectionX(x);
                        int sectionY2 = Netplay.GetSectionY(y);
                        for (int sectionX3 = sectionX2 - 2; sectionX3 < sectionX2 + 3; ++sectionX3)
                        {
                            for (int sectionY3 = sectionY2 - 1; sectionY3 < sectionY2 + 2; ++sectionY3)
                                NetMessage.SendSection(this.whoAmI, sectionX3, sectionY3);
                        }
                        NetMessage.SendData(11, this.whoAmI, -1, "", sectionX2 - 2, (float) (sectionY2 - 1), (float) (sectionX2 + 2), (float) (sectionY2 + 1), 0);
                    }
                    NetMessage.SendData(11, this.whoAmI, -1, "", sectionX1 - 2, (float) (sectionY1 - 1), (float) (sectionX1 + 2), (float) (sectionY1 + 1), 0);
                    for (int number2 = 0; number2 < 200; ++number2)
                    {
                        if (Main.item[number2].active)
                        {
                            NetMessage.SendData(21, this.whoAmI, -1, "", number2, 0.0f, 0.0f, 0.0f, 0);
                            NetMessage.SendData(22, this.whoAmI, -1, "", number2, 0.0f, 0.0f, 0.0f, 0);
                        }
                    }
                    for (int number2 = 0; number2 < 200; ++number2)
                    {
                        if (Main.npc[number2].active)
                            NetMessage.SendData(23, this.whoAmI, -1, "", number2, 0.0f, 0.0f, 0.0f, 0);
                    }
                    NetMessage.SendData(49, this.whoAmI, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(57, this.whoAmI, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 17, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 18, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 19, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 20, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 22, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 38, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 54, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 107, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 108, 0.0f, 0.0f, 0.0f, 0);
                    NetMessage.SendData(56, this.whoAmI, -1, "", 124, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 9)
                {
                    if (Main.netMode != 1)
                        return;
                    int num3 = BitConverter.ToInt32(this.readBuffer, start + 1);
                    string @string = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
                    Netplay.clientSock.statusMax += num3;
                    Netplay.clientSock.statusText = @string;
                }
                else if ((int) num2 == 10 && Main.netMode == 1)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, start + 1);
                    int num4 = BitConverter.ToInt32(this.readBuffer, start + 3);
                    int index2 = BitConverter.ToInt32(this.readBuffer, start + 7);
                    int index3 = start + 11;
                    for (int index4 = num4; index4 < num4 + (int) num3; index4++)
                    {
                        byte num5 = this.readBuffer[index3];
                        int startIndex1 = index3 + 1;
                        bool flag = Main.tile[index4, index2].active;
                        Main.tile[index4, index2].active = ((int) num5 & 1) == 1 || false;
                        int num6 = (int) num5 & 2;
                        Main.tile[index4, index2].wall = ((int) num5 & 4) != 4 ? (byte) 0 : (byte) 1;
                        Main.tile[index4, index2].liquid = ((int) num5 & 8) != 8 ? (byte) 0 : (byte) 1;
                        Main.tile[index4, index2].wire = ((int) num5 & 16) == 16 || false;
                        if (Main.tile[index4, index2].active)
                        {
                            int num7 = (int) Main.tile[index4, index2].type;
                            Main.tile[index4, index2].type = this.readBuffer[startIndex1];
                            ++startIndex1;
                            if (Main.tileFrameImportant[(int) Main.tile[index4, index2].type])
                            {
                                Main.tile[index4, index2].frameX = BitConverter.ToInt16(this.readBuffer, startIndex1);
                                int startIndex2 = startIndex1 + 2;
                                Main.tile[index4, index2].frameY = BitConverter.ToInt16(this.readBuffer, startIndex2);
                                startIndex1 = startIndex2 + 2;
                            }
                            else if (!flag || (int) Main.tile[index4, index2].type != num7)
                            {
                                Main.tile[index4, index2].frameX = (short) -1;
                                Main.tile[index4, index2].frameY = (short) -1;
                            }
                        }
                        if ((int) Main.tile[index4, index2].wall > 0)
                        {
                            Main.tile[index4, index2].wall = this.readBuffer[startIndex1];
                            ++startIndex1;
                        }
                        if ((int) Main.tile[index4, index2].liquid > 0)
                        {
                            Main.tile[index4, index2].liquid = this.readBuffer[startIndex1];
                            int index5 = startIndex1 + 1;
                            byte num7 = this.readBuffer[index5];
                            startIndex1 = index5 + 1;
                            Main.tile[index4, index2].lava = (int) num7 == 1 || false;
                        }
                        short num8 = BitConverter.ToInt16(this.readBuffer, startIndex1);
                        index3 = startIndex1 + 2;
                        int index51 = index4;
                        while ((int) num8 > 0)
                        {
                            ++index51;
                            --num8;
                            Main.tile[index51, index2].active = Main.tile[index4, index2].active;
                            Main.tile[index51, index2].type = Main.tile[index4, index2].type;
                            Main.tile[index51, index2].wall = Main.tile[index4, index2].wall;
                            Main.tile[index51, index2].wire = Main.tile[index4, index2].wire;
                            if (Main.tileFrameImportant[(int) Main.tile[index51, index2].type])
                            {
                                Main.tile[index51, index2].frameX = Main.tile[index4, index2].frameX;
                                Main.tile[index51, index2].frameY = Main.tile[index4, index2].frameY;
                            }
                            else
                            {
                                Main.tile[index51, index2].frameX = (short) -1;
                                Main.tile[index51, index2].frameY = (short) -1;
                            }
                            Main.tile[index51, index2].liquid = Main.tile[index4, index2].liquid;
                            Main.tile[index51, index2].lava = Main.tile[index4, index2].lava;
                        }
                    }
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData((int) num2, -1, this.whoAmI, "", (int) num3, (float) num4, (float) index2, 0.0f, 0);
                }
                else if ((int) num2 == 11)
                {
                    if (Main.netMode != 1)
                        return;
                    int startX = (int) BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 4;
                    int startY = (int) BitConverter.ToInt16(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    int endX = (int) BitConverter.ToInt16(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 4;
                    int endY = (int) BitConverter.ToInt16(this.readBuffer, startIndex3);
                    num1 = startIndex3 + 4;
                    WorldGen.SectionTileFrame(startX, startY, endX, endY);
                }
                else if ((int) num2 == 12)
                {
                    int index2 = (int) this.readBuffer[index1];
                    if (Main.netMode == 2)
                        index2 = this.whoAmI;
                    int startIndex1 = index1 + 1;
                    Main.player[index2].SpawnX = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    Main.player[index2].SpawnY = BitConverter.ToInt32(this.readBuffer, startIndex2);
                    num1 = startIndex2 + 4;
                    Main.player[index2].Spawn();
                    if (Main.netMode != 2 || Netplay.serverSock[this.whoAmI].state < 3)
                        return;
                    if (Netplay.serverSock[this.whoAmI].state == 3)
                    {
                        Netplay.serverSock[this.whoAmI].state = 10;
                        NetMessage.greetPlayer(this.whoAmI);
                        NetMessage.buffer[this.whoAmI].broadcast = true;
                        NetMessage.syncPlayers();
                        NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0.0f, 0.0f, 0.0f, 0);
                    }
                    else
                        NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 13)
                {
                    int number = (int) this.readBuffer[index1];
                    if (number == Main.myPlayer)
                        return;
                    if (Main.netMode == 1)
                    {
                        int num3 = Main.player[number].active ? 1 : 0;
                    }
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    int index2 = index1 + 1;
                    int num4 = (int) this.readBuffer[index2];
                    int index3 = index2 + 1;
                    int num5 = (int) this.readBuffer[index3];
                    int startIndex1 = index3 + 1;
                    float num6 = BitConverter.ToSingle(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    float num7 = BitConverter.ToSingle(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 4;
                    float num8 = BitConverter.ToSingle(this.readBuffer, startIndex3);
                    int startIndex4 = startIndex3 + 4;
                    float num9 = BitConverter.ToSingle(this.readBuffer, startIndex4);
                    num1 = startIndex4 + 4;
                    Main.player[number].selectedItem = num5;
                    Main.player[number].position.X = num6;
                    Main.player[number].position.Y = num7;
                    Main.player[number].velocity.X = num8;
                    Main.player[number].velocity.Y = num9;
                    Main.player[number].oldVelocity = Main.player[number].velocity;
                    Main.player[number].fallStart = (int) ((double) num7/16.0);
                    Main.player[number].controlUp = false;
                    Main.player[number].controlDown = false;
                    Main.player[number].controlLeft = false;
                    Main.player[number].controlRight = false;
                    Main.player[number].controlJump = false;
                    Main.player[number].controlUseItem = false;
                    Main.player[number].direction = -1;
                    if ((num4 & 1) == 1)
                        Main.player[number].controlUp = true;
                    if ((num4 & 2) == 2)
                        Main.player[number].controlDown = true;
                    if ((num4 & 4) == 4)
                        Main.player[number].controlLeft = true;
                    if ((num4 & 8) == 8)
                        Main.player[number].controlRight = true;
                    if ((num4 & 16) == 16)
                        Main.player[number].controlJump = true;
                    if ((num4 & 32) == 32)
                        Main.player[number].controlUseItem = true;
                    if ((num4 & 64) == 64)
                        Main.player[number].direction = 1;
                    if (Main.netMode != 2 || Netplay.serverSock[this.whoAmI].state != 10)
                        return;
                    NetMessage.SendData(13, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 14)
                {
                    if (Main.netMode != 1)
                        return;
                    int index2 = (int) this.readBuffer[index1];
                    if ((int) this.readBuffer[index1 + 1] == 1)
                    {
                        if (!Main.player[index2].active)
                            Main.player[index2] = new Player();
                        Main.player[index2].active = true;
                    }
                    else
                        Main.player[index2].active = false;
                }
                else if ((int) num2 == 15)
                {
                    if (Main.netMode == 2)
                        ;
                }
                else if ((int) num2 == 16)
                {
                    int number = (int) this.readBuffer[index1];
                    int startIndex = index1 + 1;
                    if (number == Main.myPlayer)
                        return;
                    int num3 = (int) BitConverter.ToInt16(this.readBuffer, startIndex);
                    int num4 = (int) BitConverter.ToInt16(this.readBuffer, startIndex + 2);
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    Main.player[number].statLife = num3;
                    Main.player[number].statLifeMax = num4;
                    if (Main.player[number].statLife <= 0)
                        Main.player[number].dead = true;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(16, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 17)
                {
                    byte num3 = this.readBuffer[index1];
                    int startIndex1 = index1 + 1;
                    int index2 = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    int index3 = BitConverter.ToInt32(this.readBuffer, startIndex2);
                    int index4 = startIndex2 + 4;
                    byte num4 = this.readBuffer[index4];
                    int num5 = (int) this.readBuffer[index4 + 1];
                    bool fail = false;
                    if ((int) num4 == 1)
                        fail = true;
                    if (Main.netMode == 2)
                    {
                        if (!fail)
                        {
                            if ((int) num3 == 0 || (int) num3 == 2 || (int) num3 == 4)
                                ++Netplay.serverSock[this.whoAmI].spamDelBlock;
                            else if ((int) num3 == 1 || (int) num3 == 3)
                                ++Netplay.serverSock[this.whoAmI].spamAddBlock;
                        }
                        if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(index2), Netplay.GetSectionY(index3)])
                            fail = true;
                    }
                    if ((int) num3 == 0)
                        WorldGen.KillTile(index2, index3, fail, false, false);
                    else if ((int) num3 == 1)
                        WorldGen.PlaceTile(index2, index3, (int) num4, false, true, -1, num5);
                    else if ((int) num3 == 2)
                        WorldGen.KillWall(index2, index3, fail);
                    else if ((int) num3 == 3)
                        WorldGen.PlaceWall(index2, index3, (int) num4, false);
                    else if ((int) num3 == 4)
                        WorldGen.KillTile(index2, index3, fail, false, true);
                    else if ((int) num3 == 5)
                        WorldGen.PlaceWire(index2, index3);
                    else if ((int) num3 == 6)
                        WorldGen.KillWire(index2, index3);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(17, -1, this.whoAmI, "", (int) num3, (float) index2, (float) index3, (float) num4, num5);
                    if ((int) num3 != 1 || (int) num4 != 53)
                        return;
                    NetMessage.SendTileSquare(-1, index2, index3, 1);
                }
                else if ((int) num2 == 18)
                {
                    if (Main.netMode != 1)
                        return;
                    byte num3 = this.readBuffer[index1];
                    int startIndex1 = index1 + 1;
                    int num4 = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    short num5 = BitConverter.ToInt16(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 2;
                    short num6 = BitConverter.ToInt16(this.readBuffer, startIndex3);
                    num1 = startIndex3 + 2;
                    Main.dayTime = (int) num3 == 1 || false;
                    Main.time = (double) num4;
                    Main.sunModY = num5;
                    Main.moonModY = num6;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(18, -1, this.whoAmI, "", 0, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 19)
                {
                    byte num3 = this.readBuffer[index1];
                    int startIndex1 = index1 + 1;
                    int i = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    int j = BitConverter.ToInt32(this.readBuffer, startIndex2);
                    int num4 = (int) this.readBuffer[startIndex2 + 4];
                    int direction = 0;
                    if (num4 == 0)
                        direction = -1;
                    if ((int) num3 == 0)
                        WorldGen.OpenDoor(i, j, direction);
                    else if ((int) num3 == 1)
                        WorldGen.CloseDoor(i, j, true);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(19, -1, this.whoAmI, "", (int) num3, (float) i, (float) j, (float) num4, 0);
                }
                else if ((int) num2 == 20)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, start + 1);
                    int startX = BitConverter.ToInt32(this.readBuffer, start + 3);
                    int startY = BitConverter.ToInt32(this.readBuffer, start + 7);
                    int startIndex1 = start + 11;
                    if (Main.netMode == 2)
                    {
                        try
                        {
                            if ((int) num3 > 10)
                                return;
                            int num4 = startX + (int) num3/2;
                            int num5 = startY;
                            int num6 = (int) ((double) Main.player[this.whoAmI].position.X + (double) (Main.player[this.whoAmI].width/2))/16;
                            int num7 = (int) ((double) Main.player[this.whoAmI].position.Y + (double) (Main.player[this.whoAmI].height/2))/16;
                            if (Math.Abs(num4 - num6) > 20)
                                return;
                            if (Math.Abs(num5 - num7) > 20)
                                return;
                        }
                        catch
                        {
                            return;
                        }
                    }
                    for (int index2 = startX; index2 < startX + (int) num3; ++index2)
                    {
                        for (int index3 = startY; index3 < startY + (int) num3; ++index3)
                        {
                            byte num4 = this.readBuffer[startIndex1];
                            ++startIndex1;
                            bool flag1 = Main.tile[index2, index3].active;
                            Main.tile[index2, index3].active = ((int) num4 & 1) == 1 || false;
                            Main.tile[index2, index3].wall = ((int) num4 & 4) != 4 ? (byte) 0 : (byte) 1;
                            bool flag2 = false;
                            if (((int) num4 & 8) == 8)
                                flag2 = true;
                            if (Main.netMode != 2)
                                Main.tile[index2, index3].liquid = !flag2 ? (byte) 0 : (byte) 1;
                            Main.tile[index2, index3].wire = ((int) num4 & 16) == 16 || false;
                            if (Main.tile[index2, index3].active)
                            {
                                int num5 = (int) Main.tile[index2, index3].type;
                                Main.tile[index2, index3].type = this.readBuffer[startIndex1];
                                ++startIndex1;
                                if (Main.tileFrameImportant[(int) Main.tile[index2, index3].type])
                                {
                                    Main.tile[index2, index3].frameX = BitConverter.ToInt16(this.readBuffer, startIndex1);
                                    int startIndex2 = startIndex1 + 2;
                                    Main.tile[index2, index3].frameY = BitConverter.ToInt16(this.readBuffer, startIndex2);
                                    startIndex1 = startIndex2 + 2;
                                }
                                else if (!flag1 || (int) Main.tile[index2, index3].type != num5)
                                {
                                    Main.tile[index2, index3].frameX = (short) -1;
                                    Main.tile[index2, index3].frameY = (short) -1;
                                }
                            }
                            if ((int) Main.tile[index2, index3].wall > 0)
                            {
                                Main.tile[index2, index3].wall = this.readBuffer[startIndex1];
                                ++startIndex1;
                            }
                            if (flag2)
                            {
                                Main.tile[index2, index3].liquid = this.readBuffer[startIndex1];
                                int index4 = startIndex1 + 1;
                                byte num5 = this.readBuffer[index4];
                                startIndex1 = index4 + 1;
                                if (Main.netMode != 2)
                                    Main.tile[index2, index3].lava = (int) num5 == 1 || false;
                            }
                        }
                    }
                    WorldGen.RangeFrame(startX, startY, startX + (int) num3, startY + (int) num3);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData((int) num2, -1, this.whoAmI, "", (int) num3, (float) startX, (float) startY, 0.0f, 0);
                }
                else if ((int) num2 == 21)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 2;
                    float num4 = BitConverter.ToSingle(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    float num5 = BitConverter.ToSingle(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 4;
                    float num6 = BitConverter.ToSingle(this.readBuffer, startIndex3);
                    int startIndex4 = startIndex3 + 4;
                    float num7 = BitConverter.ToSingle(this.readBuffer, startIndex4);
                    int index2 = startIndex4 + 4;
                    byte num8 = this.readBuffer[index2];
                    int index3 = index2 + 1;
                    byte num9 = this.readBuffer[index3];
                    short num10 = BitConverter.ToInt16(this.readBuffer, index3 + 1);
                    if (Main.netMode == 1)
                    {
                        if ((int) num10 == 0)
                        {
                            Main.item[(int) num3].active = false;
                        }
                        else
                        {
                            Main.item[(int) num3].netDefaults((int) num10);
                            Main.item[(int) num3].Prefix((int) num9);
                            Main.item[(int) num3].stack = (int) num8;
                            Main.item[(int) num3].position.X = num4;
                            Main.item[(int) num3].position.Y = num5;
                            Main.item[(int) num3].velocity.X = num6;
                            Main.item[(int) num3].velocity.Y = num7;
                            Main.item[(int) num3].active = true;
                            Main.item[(int) num3].wet = Collision.WetCollision(Main.item[(int) num3].position, Main.item[(int) num3].width, Main.item[(int) num3].height);
                        }
                    }
                    else if ((int) num10 == 0)
                    {
                        if ((int) num3 >= 200)
                            return;
                        Main.item[(int) num3].active = false;
                        NetMessage.SendData(21, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                    }
                    else
                    {
                        bool flag = false;
                        if ((int) num3 == 200)
                            flag = true;
                        if (flag)
                        {
                            Item obj = new Item();
                            obj.netDefaults((int) num10);
                            num3 = (short) Item.NewItem((int) num4, (int) num5, obj.width, obj.height, obj.type, (int) num8, true, 0);
                        }
                        Main.item[(int) num3].netDefaults((int) num10);
                        Main.item[(int) num3].Prefix((int) num9);
                        Main.item[(int) num3].stack = (int) num8;
                        Main.item[(int) num3].position.X = num4;
                        Main.item[(int) num3].position.Y = num5;
                        Main.item[(int) num3].velocity.X = num6;
                        Main.item[(int) num3].velocity.Y = num7;
                        Main.item[(int) num3].active = true;
                        Main.item[(int) num3].owner = Main.myPlayer;
                        if (flag)
                        {
                            NetMessage.SendData(21, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                            Main.item[(int) num3].ownIgnore = this.whoAmI;
                            Main.item[(int) num3].ownTime = 100;
                            Main.item[(int) num3].FindOwner((int) num3);
                        }
                        else
                            NetMessage.SendData(21, -1, this.whoAmI, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                    }
                }
                else if ((int) num2 == 22)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    byte num4 = this.readBuffer[index1 + 2];
                    if (Main.netMode == 2 && Main.item[(int) num3].owner != this.whoAmI)
                        return;
                    Main.item[(int) num3].owner = (int) num4;
                    Main.item[(int) num3].keepTime = (int) num4 != Main.myPlayer ? 0 : 15;
                    if (Main.netMode != 2)
                        return;
                    Main.item[(int) num3].owner = (int) byte.MaxValue;
                    Main.item[(int) num3].keepTime = 15;
                    NetMessage.SendData(22, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 23 && Main.netMode == 1)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 2;
                    float num4 = BitConverter.ToSingle(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    float num5 = BitConverter.ToSingle(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 4;
                    float num6 = BitConverter.ToSingle(this.readBuffer, startIndex3);
                    int startIndex4 = startIndex3 + 4;
                    float num7 = BitConverter.ToSingle(this.readBuffer, startIndex4);
                    int startIndex5 = startIndex4 + 4;
                    int num8 = (int) BitConverter.ToInt16(this.readBuffer, startIndex5);
                    int index2 = startIndex5 + 2;
                    int num9 = (int) this.readBuffer[index2] - 1;
                    int index3 = index2 + 1;
                    int num10 = (int) this.readBuffer[index3] - 1;
                    int startIndex6 = index3 + 1;
                    int num11 = BitConverter.ToInt32(this.readBuffer, startIndex6);
                    int startIndex7 = startIndex6 + 4;
                    float[] numArray = new float[NPC.maxAI];
                    for (int index4 = 0; index4 < NPC.maxAI; ++index4)
                    {
                        numArray[index4] = BitConverter.ToSingle(this.readBuffer, startIndex7);
                        startIndex7 += 4;
                    }
                    int type = (int) BitConverter.ToInt16(this.readBuffer, startIndex7);
                    if (!Main.npc[(int) num3].active || Main.npc[(int) num3].netID != type)
                    {
                        Main.npc[(int) num3].active = true;
                        Main.npc[(int) num3].netDefaults(type);
                    }
                    Main.npc[(int) num3].position.X = num4;
                    Main.npc[(int) num3].position.Y = num5;
                    Main.npc[(int) num3].velocity.X = num6;
                    Main.npc[(int) num3].velocity.Y = num7;
                    Main.npc[(int) num3].target = num8;
                    Main.npc[(int) num3].direction = num9;
                    Main.npc[(int) num3].directionY = num10;
                    Main.npc[(int) num3].life = num11;
                    if (num11 <= 0)
                        Main.npc[(int) num3].active = false;
                    for (int index4 = 0; index4 < NPC.maxAI; ++index4)
                        Main.npc[(int) num3].ai[index4] = numArray[index4];
                }
                else if ((int) num2 == 24)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    byte num4 = this.readBuffer[index1 + 2];
                    if (Main.netMode == 2)
                        num4 = (byte) this.whoAmI;
                    Main.npc[(int) num3].StrikeNPC(Main.player[(int) num4].inventory[Main.player[(int) num4].selectedItem].damage, Main.player[(int) num4].inventory[Main.player[(int) num4].selectedItem].knockBack, Main.player[(int) num4].direction, false, false);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(24, -1, this.whoAmI, "", (int) num3, (float) num4, 0.0f, 0.0f, 0);
                    NetMessage.SendData(23, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 25)
                {
                    int number = (int) this.readBuffer[start + 1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    byte R = this.readBuffer[start + 2];
                    byte G = this.readBuffer[start + 3];
                    byte B = this.readBuffer[start + 4];
                    if (Main.netMode == 2)
                    {
                        R = byte.MaxValue;
                        G = byte.MaxValue;
                        B = byte.MaxValue;
                    }
                    string @string = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
                    if (Main.netMode == 1)
                    {
                        string newText = @string;
                        if (number < (int) byte.MaxValue)
                        {
                            newText = "<" + Main.player[number].name + "> " + @string;
                            Main.player[number].chatText = @string;
                            Main.player[number].chatShowTime = Main.chatLength/2;
                        }
                        Main.NewText(newText, R, G, B);
                    }
                    else
                    {
                        if (Main.netMode != 2)
                            return;
                        string str1 = @string.ToLower();
                        if (str1 == Lang.mp[6])
                        {
                            string str2 = "";
                            for (int index2 = 0; index2 < (int) byte.MaxValue; ++index2)
                            {
                                if (Main.player[index2].active)
                                    str2 = !(str2 == "") ? str2 + ", " + Main.player[index2].name : str2 + Main.player[index2].name;
                            }
                            NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[7] + " " + str2 + ".", (int) byte.MaxValue, (float) byte.MaxValue, 240f, 20f, 0);
                        }
                        else if (str1.Length >= 4 && str1.Substring(0, 4) == "/me ")
                            NetMessage.SendData(25, -1, -1, "*" + Main.player[this.whoAmI].name + " " + @string.Substring(4), (int) byte.MaxValue, 200f, 100f, 0.0f, 0);
                        else if (str1 == Lang.mp[8])
                            NetMessage.SendData(25, -1, -1, "*" + (object) Main.player[this.whoAmI].name + " " + Lang.mp[9] + " " + (string) (object) Main.rand.Next(1, 101), (int) byte.MaxValue, (float) byte.MaxValue, 240f, 20f, 0);
                        else if (str1.Length >= 3 && str1.Substring(0, 3) == "/p ")
                        {
                            if (Main.player[this.whoAmI].team != 0)
                            {
                                for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
                                {
                                    if (Main.player[remoteClient].team == Main.player[this.whoAmI].team)
                                        NetMessage.SendData(25, remoteClient, -1, @string.Substring(3), number, (float) Main.teamColor[Main.player[this.whoAmI].team].R, (float) Main.teamColor[Main.player[this.whoAmI].team].G, (float) Main.teamColor[Main.player[this.whoAmI].team].B, 0);
                                }
                            }
                            else
                                NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[10], (int) byte.MaxValue, (float) byte.MaxValue, 240f, 20f, 0);
                        }
                        else
                        {
                            if ((int) Main.player[this.whoAmI].difficulty == 2)
                            {
                                R = Main.hcColor.R;
                                G = Main.hcColor.G;
                                B = Main.hcColor.B;
                            }
                            else if ((int) Main.player[this.whoAmI].difficulty == 1)
                            {
                                R = Main.mcColor.R;
                                G = Main.mcColor.G;
                                B = Main.mcColor.B;
                            }
                            NetMessage.SendData(25, -1, -1, @string, number, (float) R, (float) G, (float) B, 0);
                            if (!Main.dedServ)
                                return;
                            Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + @string);
                        }
                    }
                }
                else if ((int) num2 == 26)
                {
                    byte num3 = this.readBuffer[index1];
                    if (Main.netMode == 2 && this.whoAmI != (int) num3 && (!Main.player[(int) num3].hostile || !Main.player[this.whoAmI].hostile))
                        return;
                    int index2 = index1 + 1;
                    int hitDirection = (int) this.readBuffer[index2] - 1;
                    int startIndex = index2 + 1;
                    short num4 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    int index3 = startIndex + 2;
                    byte num5 = this.readBuffer[index3];
                    int index4 = index3 + 1;
                    bool pvp = false;
                    byte num6 = this.readBuffer[index4];
                    int index5 = index4 + 1;
                    bool Crit = false;
                    string @string = Encoding.UTF8.GetString(this.readBuffer, index5, length - index5 + start);
                    if ((int) num5 != 0)
                        pvp = true;
                    if ((int) num6 != 0)
                        Crit = true;
                    Main.player[(int) num3].Hurt((int) num4, hitDirection, pvp, true, @string, Crit);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(26, -1, this.whoAmI, @string, (int) num3, (float) hitDirection, (float) num4, (float) num5, 0);
                }
                else if ((int) num2 == 27)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 2;
                    float num4 = BitConverter.ToSingle(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    float num5 = BitConverter.ToSingle(this.readBuffer, startIndex2);
                    int startIndex3 = startIndex2 + 4;
                    float num6 = BitConverter.ToSingle(this.readBuffer, startIndex3);
                    int startIndex4 = startIndex3 + 4;
                    float num7 = BitConverter.ToSingle(this.readBuffer, startIndex4);
                    int startIndex5 = startIndex4 + 4;
                    float num8 = BitConverter.ToSingle(this.readBuffer, startIndex5);
                    int startIndex6 = startIndex5 + 4;
                    short num9 = BitConverter.ToInt16(this.readBuffer, startIndex6);
                    int index2 = startIndex6 + 2;
                    byte num10 = this.readBuffer[index2];
                    int index3 = index2 + 1;
                    byte num11 = this.readBuffer[index3];
                    int startIndex7 = index3 + 1;
                    float[] numArray = new float[Projectile.maxAI];
                    if (Main.netMode == 2)
                    {
                        num10 = (byte) this.whoAmI;
                        if (Main.projHostile[(int) num11])
                            return;
                    }
                    for (int index4 = 0; index4 < Projectile.maxAI; ++index4)
                    {
                        numArray[index4] = BitConverter.ToSingle(this.readBuffer, startIndex7);
                        startIndex7 += 4;
                    }
                    int number = 1000;
                    for (int index4 = 0; index4 < 1000; ++index4)
                    {
                        if (Main.projectile[index4].owner == (int) num10 && Main.projectile[index4].identity == (int) num3 && Main.projectile[index4].active)
                        {
                            number = index4;
                            break;
                        }
                    }
                    if (number == 1000)
                    {
                        for (int index4 = 0; index4 < 1000; ++index4)
                        {
                            if (!Main.projectile[index4].active)
                            {
                                number = index4;
                                break;
                            }
                        }
                    }
                    if (!Main.projectile[number].active || Main.projectile[number].type != (int) num11)
                    {
                        Main.projectile[number].SetDefaults((int) num11);
                        if (Main.netMode == 2)
                            ++Netplay.serverSock[this.whoAmI].spamProjectile;
                    }
                    Main.projectile[number].identity = (int) num3;
                    Main.projectile[number].position.X = num4;
                    Main.projectile[number].position.Y = num5;
                    Main.projectile[number].velocity.X = num6;
                    Main.projectile[number].velocity.Y = num7;
                    Main.projectile[number].damage = (int) num9;
                    Main.projectile[number].type = (int) num11;
                    Main.projectile[number].owner = (int) num10;
                    Main.projectile[number].knockBack = num8;
                    for (int index4 = 0; index4 < Projectile.maxAI; ++index4)
                        Main.projectile[number].ai[index4] = numArray[index4];
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(27, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 28)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 2;
                    short num4 = BitConverter.ToInt16(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 2;
                    float num5 = BitConverter.ToSingle(this.readBuffer, startIndex2);
                    int index2 = startIndex2 + 4;
                    int hitDirection = (int) this.readBuffer[index2] - 1;
                    int number5 = (int) this.readBuffer[index2 + 1];
                    if ((int) num4 >= 0)
                    {
                        if (number5 == 1)
                            Main.npc[(int) num3].StrikeNPC((int) num4, num5, hitDirection, true, false);
                        else
                            Main.npc[(int) num3].StrikeNPC((int) num4, num5, hitDirection, false, false);
                    }
                    else
                    {
                        Main.npc[(int) num3].life = 0;
                        Main.npc[(int) num3].HitEffect(0, 10.0);
                        Main.npc[(int) num3].active = false;
                    }
                    if (Main.netMode != 2)
                        return;
                    if (Main.npc[(int) num3].life <= 0)
                    {
                        NetMessage.SendData(28, -1, this.whoAmI, "", (int) num3, (float) num4, num5, (float) hitDirection, number5);
                        NetMessage.SendData(23, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                    }
                    else
                    {
                        NetMessage.SendData(28, -1, this.whoAmI, "", (int) num3, (float) num4, num5, (float) hitDirection, number5);
                        Main.npc[(int) num3].netUpdate = true;
                    }
                }
                else if ((int) num2 == 29)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    byte num4 = this.readBuffer[index1 + 2];
                    if (Main.netMode == 2)
                        num4 = (byte) this.whoAmI;
                    for (int index2 = 0; index2 < 1000; ++index2)
                    {
                        if (Main.projectile[index2].owner == (int) num4 && Main.projectile[index2].identity == (int) num3 && Main.projectile[index2].active)
                        {
                            Main.projectile[index2].Kill();
                            break;
                        }
                    }
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(29, -1, this.whoAmI, "", (int) num3, (float) num4, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 30)
                {
                    byte num3 = this.readBuffer[index1];
                    if (Main.netMode == 2)
                        num3 = (byte) this.whoAmI;
                    byte num4 = this.readBuffer[index1 + 1];
                    Main.player[(int) num3].hostile = (int) num4 == 1 || false;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(30, -1, this.whoAmI, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                    string str = " " + Lang.mp[11];
                    if ((int) num4 == 0)
                        str = " " + Lang.mp[12];
                    NetMessage.SendData(25, -1, -1, Main.player[(int) num3].name + str, (int) byte.MaxValue, (float) Main.teamColor[Main.player[(int) num3].team].R, (float) Main.teamColor[Main.player[(int) num3].team].G, (float) Main.teamColor[Main.player[(int) num3].team].B, 0);
                }
                else if ((int) num2 == 31)
                {
                    if (Main.netMode != 2)
                        return;
                    int X = BitConverter.ToInt32(this.readBuffer, index1);
                    int startIndex = index1 + 4;
                    int Y = BitConverter.ToInt32(this.readBuffer, startIndex);
                    num1 = startIndex + 4;
                    int chest = Chest.FindChest(X, Y);
                    if (chest <= -1 || Chest.UsingChest(chest) != -1)
                        return;
                    for (int index2 = 0; index2 < Chest.maxItems; ++index2)
                        NetMessage.SendData(32, this.whoAmI, -1, "", chest, (float) index2, 0.0f, 0.0f, 0);
                    NetMessage.SendData(33, this.whoAmI, -1, "", chest, 0.0f, 0.0f, 0.0f, 0);
                    Main.player[this.whoAmI].chest = chest;
                }
                else if ((int) num2 == 32)
                {
                    int index2 = (int) BitConverter.ToInt16(this.readBuffer, index1);
                    int index3 = index1 + 2;
                    int index4 = (int) this.readBuffer[index3];
                    int index5 = index3 + 1;
                    int num3 = (int) this.readBuffer[index5];
                    int index6 = index5 + 1;
                    int pre = (int) this.readBuffer[index6];
                    int type = (int) BitConverter.ToInt16(this.readBuffer, index6 + 1);
                    if (Main.chest[index2] == null)
                        Main.chest[index2] = new Chest();
                    if (Main.chest[index2].item[index4] == null)
                        Main.chest[index2].item[index4] = new Item();
                    Main.chest[index2].item[index4].netDefaults(type);
                    Main.chest[index2].item[index4].Prefix(pre);
                    Main.chest[index2].item[index4].stack = num3;
                }
                else if ((int) num2 == 33)
                {
                    int num3 = (int) BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex = index1 + 2;
                    int num4 = BitConverter.ToInt32(this.readBuffer, startIndex);
                    int num5 = BitConverter.ToInt32(this.readBuffer, startIndex + 4);
                    if (Main.netMode == 1)
                    {
                        if (Main.player[Main.myPlayer].chest == -1)
                        {
                            Main.playerInventory = true;
                            Main.PlaySound(10, -1, -1, 1);
                        }
                        else if (Main.player[Main.myPlayer].chest != num3 && num3 != -1)
                        {
                            Main.playerInventory = true;
                            Main.PlaySound(12, -1, -1, 1);
                        }
                        else if (Main.player[Main.myPlayer].chest != -1 && num3 == -1)
                            Main.PlaySound(11, -1, -1, 1);
                        Main.player[Main.myPlayer].chest = num3;
                        Main.player[Main.myPlayer].chestX = num4;
                        Main.player[Main.myPlayer].chestY = num5;
                    }
                    else
                        Main.player[this.whoAmI].chest = num3;
                }
                else if ((int) num2 == 34)
                {
                    if (Main.netMode != 2)
                        return;
                    int i = BitConverter.ToInt32(this.readBuffer, index1);
                    int j = BitConverter.ToInt32(this.readBuffer, index1 + 4);
                    if ((int) Main.tile[i, j].type != 21)
                        return;
                    WorldGen.KillTile(i, j, false, false, false);
                    if (Main.tile[i, j].active)
                        return;
                    NetMessage.SendData(17, -1, -1, "", 0, (float) i, (float) j, 0.0f, 0);
                }
                else if ((int) num2 == 35)
                {
                    int number = (int) this.readBuffer[index1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    int startIndex = index1 + 1;
                    int healAmount = (int) BitConverter.ToInt16(this.readBuffer, startIndex);
                    num1 = startIndex + 2;
                    if (number != Main.myPlayer)
                        Main.player[number].HealEffect(healAmount);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(35, -1, this.whoAmI, "", number, (float) healAmount, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 36)
                {
                    int number = (int) this.readBuffer[index1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    int index2 = index1 + 1;
                    int num3 = (int) this.readBuffer[index2];
                    int index3 = index2 + 1;
                    int num4 = (int) this.readBuffer[index3];
                    int index4 = index3 + 1;
                    int num5 = (int) this.readBuffer[index4];
                    int index5 = index4 + 1;
                    int num6 = (int) this.readBuffer[index5];
                    int index6 = index5 + 1;
                    int num7 = (int) this.readBuffer[index6];
                    num1 = index6 + 1;
                    Main.player[number].zoneEvil = num3 != 0 && true;
                    Main.player[number].zoneMeteor = num4 != 0 && true;
                    Main.player[number].zoneDungeon = num5 != 0 && true;
                    Main.player[number].zoneJungle = num6 != 0 && true;
                    Main.player[number].zoneHoly = num7 != 0 && true;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(36, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 37)
                {
                    if (Main.netMode != 1)
                        return;
                    if (Main.autoPass)
                    {
                        NetMessage.SendData(38, -1, -1, Netplay.password, 0, 0.0f, 0.0f, 0.0f, 0);
                        Main.autoPass = false;
                    }
                    else
                    {
                        Netplay.password = "";
                        Main.menuMode = 31;
                    }
                }
                else if ((int) num2 == 38)
                {
                    if (Main.netMode != 2)
                        return;
                    if (Encoding.UTF8.GetString(this.readBuffer, index1, length - index1 + start) == Netplay.password)
                    {
                        Netplay.serverSock[this.whoAmI].state = 1;
                        NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0.0f, 0.0f, 0.0f, 0);
                    }
                    else
                        NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 39 && Main.netMode == 1)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    Main.item[(int) num3].owner = (int) byte.MaxValue;
                    NetMessage.SendData(22, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 40)
                {
                    byte num3 = this.readBuffer[index1];
                    if (Main.netMode == 2)
                        num3 = (byte) this.whoAmI;
                    int startIndex = index1 + 1;
                    int num4 = (int) BitConverter.ToInt16(this.readBuffer, startIndex);
                    num1 = startIndex + 2;
                    Main.player[(int) num3].talkNPC = num4;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(40, -1, this.whoAmI, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 41)
                {
                    byte num3 = this.readBuffer[index1];
                    if (Main.netMode == 2)
                        num3 = (byte) this.whoAmI;
                    int startIndex = index1 + 1;
                    float num4 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    int num5 = (int) BitConverter.ToInt16(this.readBuffer, startIndex + 4);
                    Main.player[(int) num3].itemRotation = num4;
                    Main.player[(int) num3].itemAnimation = num5;
                    Main.player[(int) num3].channel = Main.player[(int) num3].inventory[Main.player[(int) num3].selectedItem].channel;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(41, -1, this.whoAmI, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 42)
                {
                    int number = (int) this.readBuffer[index1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    int startIndex = index1 + 1;
                    int num3 = (int) BitConverter.ToInt16(this.readBuffer, startIndex);
                    int num4 = (int) BitConverter.ToInt16(this.readBuffer, startIndex + 2);
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    Main.player[number].statMana = num3;
                    Main.player[number].statManaMax = num4;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(42, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 43)
                {
                    int number = (int) this.readBuffer[index1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    int startIndex = index1 + 1;
                    int manaAmount = (int) BitConverter.ToInt16(this.readBuffer, startIndex);
                    num1 = startIndex + 2;
                    if (number != Main.myPlayer)
                        Main.player[number].ManaEffect(manaAmount);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(43, -1, this.whoAmI, "", number, (float) manaAmount, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 44)
                {
                    byte num3 = this.readBuffer[index1];
                    if ((int) num3 == Main.myPlayer)
                        return;
                    if (Main.netMode == 2)
                        num3 = (byte) this.whoAmI;
                    int index2 = index1 + 1;
                    int hitDirection = (int) this.readBuffer[index2] - 1;
                    int startIndex = index2 + 1;
                    short num4 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    int index3 = startIndex + 2;
                    byte num5 = this.readBuffer[index3];
                    int index4 = index3 + 1;
                    string @string = Encoding.UTF8.GetString(this.readBuffer, index4, length - index4 + start);
                    bool pvp = false;
                    if ((int) num5 != 0)
                        pvp = true;
                    Main.player[(int) num3].KillMe((double) num4, hitDirection, pvp, @string);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(44, -1, this.whoAmI, @string, (int) num3, (float) hitDirection, (float) num4, (float) num5, 0);
                }
                else if ((int) num2 == 45)
                {
                    int number = (int) this.readBuffer[index1];
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    int index2 = index1 + 1;
                    int index3 = (int) this.readBuffer[index2];
                    num1 = index2 + 1;
                    int num3 = Main.player[number].team;
                    Main.player[number].team = index3;
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(45, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                    string str = "";
                    if (index3 == 0)
                        str = " " + Lang.mp[13];
                    else if (index3 == 1)
                        str = " " + Lang.mp[14];
                    else if (index3 == 2)
                        str = " " + Lang.mp[15];
                    else if (index3 == 3)
                        str = " " + Lang.mp[16];
                    else if (index3 == 4)
                        str = " " + Lang.mp[17];
                    for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
                    {
                        if (remoteClient == this.whoAmI || num3 > 0 && Main.player[remoteClient].team == num3 || index3 > 0 && Main.player[remoteClient].team == index3)
                            NetMessage.SendData(25, remoteClient, -1, Main.player[number].name + str, (int) byte.MaxValue, (float) Main.teamColor[index3].R, (float) Main.teamColor[index3].G, (float) Main.teamColor[index3].B, 0);
                    }
                }
                else if ((int) num2 == 46)
                {
                    if (Main.netMode != 2)
                        return;
                    int i = BitConverter.ToInt32(this.readBuffer, index1);
                    int startIndex = index1 + 4;
                    int j = BitConverter.ToInt32(this.readBuffer, startIndex);
                    num1 = startIndex + 4;
                    int number = Sign.ReadSign(i, j);
                    if (number < 0)
                        return;
                    NetMessage.SendData(47, this.whoAmI, -1, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 47)
                {
                    int i = (int) BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 2;
                    int num3 = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    int num4 = BitConverter.ToInt32(this.readBuffer, startIndex2);
                    int index2 = startIndex2 + 4;
                    string @string = Encoding.UTF8.GetString(this.readBuffer, index2, length - index2 + start);
                    Main.sign[i] = new Sign();
                    Main.sign[i].x = num3;
                    Main.sign[i].y = num4;
                    Sign.TextSign(i, @string);
                    if (Main.netMode != 1 || Main.sign[i] == null || i == Main.player[Main.myPlayer].sign)
                        return;
                    Main.playerInventory = false;
                    Main.player[Main.myPlayer].talkNPC = -1;
                    Main.editSign = false;
                    Main.PlaySound(10, -1, -1, 1);
                    Main.player[Main.myPlayer].sign = i;
                    Main.npcChatText = Main.sign[i].text;
                }
                else if ((int) num2 == 48)
                {
                    int i = BitConverter.ToInt32(this.readBuffer, index1);
                    int startIndex = index1 + 4;
                    int j = BitConverter.ToInt32(this.readBuffer, startIndex);
                    int index2 = startIndex + 4;
                    byte num3 = this.readBuffer[index2];
                    int index3 = index2 + 1;
                    byte num4 = this.readBuffer[index3];
                    num1 = index3 + 1;
                    if (Main.netMode == 2 && Netplay.spamCheck)
                    {
                        int index4 = this.whoAmI;
                        int num5 = (int) ((double) Main.player[index4].position.X + (double) (Main.player[index4].width/2));
                        int num6 = (int) ((double) Main.player[index4].position.Y + (double) (Main.player[index4].height/2));
                        int num7 = 10;
                        int num8 = num5 - num7;
                        int num9 = num5 + num7;
                        int num10 = num6 - num7;
                        int num11 = num6 + num7;
                        if (num5 < num8 || num5 > num9 || (num6 < num10 || num6 > num11))
                        {
                            NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
                            return;
                        }
                    }
                    lock (Main.tile[i, j])
                    {
                        Main.tile[i, j].liquid = num3;
                        Main.tile[i, j].lava = (int) num4 == 1 || false;
                        if (Main.netMode != 2)
                            return;
                        WorldGen.SquareTileFrame(i, j, true);
                    }
                }
                else if ((int) num2 == 49)
                {
                    if (Netplay.clientSock.state != 6)
                        return;
                    Netplay.clientSock.state = 10;
                    Main.player[Main.myPlayer].Spawn();
                }
                else if ((int) num2 == 50)
                {
                    int number = (int) this.readBuffer[index1];
                    int index2 = index1 + 1;
                    if (Main.netMode == 2)
                        number = this.whoAmI;
                    else if (number == Main.myPlayer)
                        return;
                    for (int index3 = 0; index3 < 10; ++index3)
                    {
                        Main.player[number].buffType[index3] = (int) this.readBuffer[index2];
                        Main.player[number].buffTime[index3] = Main.player[number].buffType[index3] <= 0 ? 0 : 60;
                        ++index2;
                    }
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(50, -1, this.whoAmI, "", number, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 51)
                {
                    byte num3 = this.readBuffer[index1];
                    byte num4 = this.readBuffer[index1 + 1];
                    switch (num4)
                    {
                        case (byte) 1:
                            NPC.SpawnSkeletron();
                            break;
                        case (byte) 2:
                            if (Main.netMode == 2)
                            {
                                if (Main.netMode != 2)
                                    break;
                                NetMessage.SendData(51, -1, this.whoAmI, "", (int) num3, (float) num4, 0.0f, 0.0f, 0);
                                break;
                            }
                            else
                            {
                                Main.PlaySound(2, (int) Main.player[(int) num3].position.X, (int) Main.player[(int) num3].position.Y, 1);
                                break;
                            }
                    }
                }
                else if ((int) num2 == 52)
                {
                    byte num3 = this.readBuffer[index1];
                    int index2 = index1 + 1;
                    byte num4 = this.readBuffer[index2];
                    int startIndex1 = index2 + 1;
                    int num5 = BitConverter.ToInt32(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 4;
                    int num6 = BitConverter.ToInt32(this.readBuffer, startIndex2);
                    num1 = startIndex2 + 4;
                    if ((int) num4 != 1)
                        return;
                    Chest.Unlock(num5, num6);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(52, -1, this.whoAmI, "", (int) num3, (float) num4, (float) num5, (float) num6, 0);
                    NetMessage.SendTileSquare(-1, num5, num6, 2);
                }
                else if ((int) num2 == 53)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int index2 = index1 + 2;
                    byte num4 = this.readBuffer[index2];
                    int startIndex = index2 + 1;
                    short num5 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    num1 = startIndex + 2;
                    Main.npc[(int) num3].AddBuff((int) num4, (int) num5, true);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(54, -1, -1, "", (int) num3, 0.0f, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 54)
                {
                    if (Main.netMode != 1)
                        return;
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int index2 = index1 + 2;
                    for (int index3 = 0; index3 < 5; ++index3)
                    {
                        Main.npc[(int) num3].buffType[index3] = (int) this.readBuffer[index2];
                        int startIndex = index2 + 1;
                        Main.npc[(int) num3].buffTime[index3] = (int) BitConverter.ToInt16(this.readBuffer, startIndex);
                        index2 = startIndex + 2;
                    }
                }
                else if ((int) num2 == 55)
                {
                    byte num3 = this.readBuffer[index1];
                    int index2 = index1 + 1;
                    byte num4 = this.readBuffer[index2];
                    int startIndex = index2 + 1;
                    short num5 = BitConverter.ToInt16(this.readBuffer, startIndex);
                    num1 = startIndex + 2;
                    if (Main.netMode == 2 && (int) num3 != this.whoAmI && !Main.pvpBuff[(int) num4])
                        return;
                    if (Main.netMode == 1 && (int) num3 == Main.myPlayer)
                    {
                        Main.player[(int) num3].AddBuff((int) num4, (int) num5, true);
                    }
                    else
                    {
                        if (Main.netMode != 2)
                            return;
                        NetMessage.SendData(55, (int) num3, -1, "", (int) num3, (float) num4, (float) num5, 0.0f, 0);
                    }
                }
                else if ((int) num2 == 56)
                {
                    if (Main.netMode != 1)
                        return;
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int index2 = index1 + 2;
                    string @string = Encoding.UTF8.GetString(this.readBuffer, index2, length - index2 + start);
                    Main.chrName[(int) num3] = @string;
                }
                else if ((int) num2 == 57)
                {
                    if (Main.netMode != 1)
                        return;
                    WorldGen.tGood = this.readBuffer[index1];
                    WorldGen.tEvil = this.readBuffer[index1 + 1];
                }
                else if ((int) num2 == 58)
                {
                    byte num3 = this.readBuffer[index1];
                    if (Main.netMode == 2)
                        num3 = (byte) this.whoAmI;
                    int startIndex = index1 + 1;
                    float number2 = BitConverter.ToSingle(this.readBuffer, startIndex);
                    num1 = startIndex + 4;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(58, -1, this.whoAmI, "", this.whoAmI, number2, 0.0f, 0.0f, 0);
                    }
                    else
                    {
                        Main.harpNote = number2;
                        int Style = 26;
                        if (Main.player[(int) num3].inventory[Main.player[(int) num3].selectedItem].type == 507)
                            Style = 35;
                        Main.PlaySound(2, (int) Main.player[(int) num3].position.X, (int) Main.player[(int) num3].position.Y, Style);
                    }
                }
                else if ((int) num2 == 59)
                {
                    int num3 = BitConverter.ToInt32(this.readBuffer, index1);
                    int startIndex = index1 + 4;
                    int j = BitConverter.ToInt32(this.readBuffer, startIndex);
                    num1 = startIndex + 4;
                    WorldGen.hitSwitch(num3, j);
                    if (Main.netMode != 2)
                        return;
                    NetMessage.SendData(59, -1, this.whoAmI, "", num3, (float) j, 0.0f, 0.0f, 0);
                }
                else if ((int) num2 == 60)
                {
                    short num3 = BitConverter.ToInt16(this.readBuffer, index1);
                    int startIndex1 = index1 + 2;
                    short num4 = BitConverter.ToInt16(this.readBuffer, startIndex1);
                    int startIndex2 = startIndex1 + 2;
                    short num5 = BitConverter.ToInt16(this.readBuffer, startIndex2);
                    int index2 = startIndex2 + 2;
                    byte num6 = this.readBuffer[index2];
                    num1 = index2 + 1;
                    bool flag = false;
                    if ((int) num6 == 1)
                        flag = true;
                    if (Main.netMode == 1)
                    {
                        Main.npc[(int) num3].homeless = flag;
                        Main.npc[(int) num3].homeTileX = (int) num4;
                        Main.npc[(int) num3].homeTileY = (int) num5;
                    }
                    else if ((int) num6 == 0)
                        WorldGen.kickOut((int) num3);
                    else
                        WorldGen.moveRoom((int) num4, (int) num5, (int) num3);
                }
                else
                {
                    if ((int) num2 != 61)
                        return;
                    int plr = BitConverter.ToInt32(this.readBuffer, index1);
                    int startIndex = index1 + 4;
                    int Type = BitConverter.ToInt32(this.readBuffer, startIndex);
                    num1 = startIndex + 4;
                    if (Main.netMode != 2)
                        return;
                    if (Type == 4 || Type == 13 || (Type == 50 || Type == 125) || (Type == 126 || Type == 134 || (Type == (int) sbyte.MaxValue || Type == 128)))
                    {
                        bool flag = true;
                        for (int index2 = 0; index2 < 200; ++index2)
                        {
                            if (Main.npc[index2].active && Main.npc[index2].type == Type)
                                flag = false;
                        }
                        if (!flag)
                            return;
                        NPC.SpawnOnPlayer(plr, Type);
                    }
                    else
                    {
                        if (Type >= 0)
                            return;
                        int type = -1;
                        if (Type == -1)
                            type = 1;
                        if (Type == -2)
                            type = 2;
                        if (type <= 0 || Main.invasionType != 0)
                            return;
                        Main.invasionDelay = 0;
                        Main.StartInvasion(type);
                    }
                }
            }
        }
    }
}