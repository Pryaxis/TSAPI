using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Hooks;

namespace Terraria
{
    public class Netplay
    {
        public const int bufferSize = 1024;
        public const int maxConnections = 256;
        public static bool stopListen;
        public static ServerSock[] serverSock = new ServerSock[256];
        public static ClientSock clientSock = new ClientSock();
        public static TcpListener tcpListener;
        public static IPAddress serverListenIP = IPAddress.Any;
        public static IPAddress serverIP = IPAddress.Any;
        public static int serverPort = 7777;
        public static bool disconnect;
        public static string password = "";
        public static string banFile = "banlist.txt";
        public static bool spamCheck;
        public static bool anyClients;
        public static bool ServerUp;

        public static void ResetNetDiag()
        {
            Main.rxMsg = 0;
            Main.rxData = 0;
            Main.txMsg = 0;
            Main.txData = 0;
            for (int i = 0; i < Main.maxMsg; i++)
            {
                Main.rxMsgType[i] = 0;
                Main.rxDataType[i] = 0;
                Main.txMsgType[i] = 0;
                Main.txDataType[i] = 0;
            }
        }

        public static void ResetSections()
        {
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < Main.maxSectionsX; j++)
                {
                    for (int k = 0; k < Main.maxSectionsY; k++)
                    {
                        serverSock[i].tileSection[j, k] = false;
                    }
                }
            }
        }

        public static void AddBan(int plr)
        {
            string text = serverSock[plr].tcpClient.Client.RemoteEndPoint.ToString();
            string value = text;
            for (int i = 0; i < text.Length; i++)
            {
                if (text.Substring(i, 1) == ":")
                {
                    value = text.Substring(0, i);
                }
            }
            using (var streamWriter = new StreamWriter(banFile, true))
            {
                streamWriter.WriteLine("//" + Main.player[plr].name);
                streamWriter.WriteLine(value);
            }
        }

        public static bool CheckBan(string ip)
        {
            try
            {
                string b = ip;
                for (int i = 0; i < ip.Length; i++)
                {
                    if (ip.Substring(i, 1) == ":")
                    {
                        b = ip.Substring(0, i);
                    }
                }
                if (File.Exists(banFile))
                {
                    using (var streamReader = new StreamReader(banFile))
                    {
                        string a;
                        while ((a = streamReader.ReadLine()) != null)
                        {
                            if (a == b)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public static void newRecent()
        {
            for (int i = 0; i < Main.maxMP; i++)
            {
                if (Main.recentIP[i] == serverIP.ToString() && Main.recentPort[i] == serverPort)
                {
                    for (int j = i; j < Main.maxMP - 1; j++)
                    {
                        Main.recentIP[j] = Main.recentIP[j + 1];
                        Main.recentPort[j] = Main.recentPort[j + 1];
                        Main.recentWorld[j] = Main.recentWorld[j + 1];
                    }
                }
            }
            for (int k = Main.maxMP - 1; k > 0; k--)
            {
                Main.recentIP[k] = Main.recentIP[k - 1];
                Main.recentPort[k] = Main.recentPort[k - 1];
                Main.recentWorld[k] = Main.recentWorld[k - 1];
            }
            Main.recentIP[0] = serverIP.ToString();
            Main.recentPort[0] = serverPort;
            Main.recentWorld[0] = Main.worldName;
            Main.SaveRecent();
        }

        public static void ServerLoop(object threadContext)
        {
            ResetNetDiag();
            if (Main.rand == null)
            {
                Main.rand = new Random((int) DateTime.Now.Ticks);
            }
            if (WorldGen.genRand == null)
            {
                WorldGen.genRand = new Random((int) DateTime.Now.Ticks);
            }
            Main.myPlayer = 255;
            serverIP = IPAddress.Any;
            //Netplay.serverListenIP = Netplay.serverIP;
            Main.menuMode = 14;
            Main.statusText = "Starting server...";
            Main.netMode = 2;
            disconnect = false;
            for (int i = 0; i < 256; i++)
            {
                serverSock[i] = new ServerSock();
                serverSock[i].Reset();
                serverSock[i].whoAmI = i;
                serverSock[i].tcpClient = new TcpClient();
                serverSock[i].tcpClient.NoDelay = true;
                serverSock[i].readBuffer = new byte[1024];
                serverSock[i].writeBuffer = new byte[1024];
            }
            tcpListener = new TcpListener(serverListenIP, serverPort);
            try
            {
                tcpListener.Start();
            }
            catch (Exception ex)
            {
                Main.menuMode = 15;
                Main.statusText = ex.ToString();
                disconnect = true;
            }
            if (!disconnect)
            {
                ThreadPool.QueueUserWorkItem(ListenForClients, 1);
                Main.statusText = "Server started";
            }
            int num = 0;
            while (!disconnect)
            {
                if (stopListen)
                {
                    int num2 = -1;
                    for (int j = 0; j < Main.maxNetPlayers; j++)
                    {
                        if (serverSock[j].tcpClient == null || !serverSock[j].tcpClient.Connected)
                        {
                            num2 = j;
                            break;
                        }
                    }
                    if (num2 >= 0)
                    {
                        if (Main.ignoreErrors)
                        {
                            try
                            {
                                tcpListener.Start();
                                stopListen = false;
                                ThreadPool.QueueUserWorkItem(ListenForClients, 1);
                                goto IL_208;
                            }
                            catch
                            {
                                goto IL_208;
                            }
                        }
                        tcpListener.Start();
                        stopListen = false;
                        ThreadPool.QueueUserWorkItem(ListenForClients, 1);
                    }
                }
                IL_208:
                int num3 = 0;
                for (int k = 0; k < 256; k++)
                {
                    if (NetMessage.buffer[k].checkBytes)
                    {
                        NetMessage.CheckBytes(k);
                    }
                    if (serverSock[k].kill)
                    {
                        ServerHooks.OnLeave(serverSock[k].whoAmI);
                        serverSock[k].Reset();
                        NetMessage.syncPlayers();
                    }
                    else if (serverSock[k].tcpClient != null && serverSock[k].tcpClient.Connected)
                    {
                        if (!serverSock[k].active)
                        {
                            serverSock[k].state = 0;
                        }
                        serverSock[k].active = true;
                        num3++;
                        if (!serverSock[k].locked)
                        {
                            try
                            {
                                serverSock[k].networkStream = serverSock[k].tcpClient.GetStream();
                                if (serverSock[k].networkStream.DataAvailable)
                                {
                                    serverSock[k].locked = true;
                                    serverSock[k].networkStream.BeginRead(serverSock[k].readBuffer, 0, serverSock[k].readBuffer.Length, serverSock[k].ServerReadCallBack, serverSock[k].networkStream);
                                }
                            }
                            catch
                            {
                                serverSock[k].kill = true;
                            }
                        }
                        if (serverSock[k].statusMax > 0 && serverSock[k].statusText2 != "")
                        {
                            if (serverSock[k].statusCount >= serverSock[k].statusMax)
                            {
                                serverSock[k].statusText2 = "";
                                serverSock[k].statusMax = 0;
                                serverSock[k].statusCount = 0;
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            if (serverSock[k].state == 0)
                            {
                            }
                            else
                            {
                                if (serverSock[k].state == 1)
                                {
                                }
                                else
                                {
                                    if (serverSock[k].state == 2)
                                    {
                                    }
                                    else
                                    {
                                        if (serverSock[k].state != 3 && serverSock[k].state == 10)
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (serverSock[k].active)
                    {
                        serverSock[k].kill = true;
                    }

                    else
                    {
                        serverSock[k].statusText2 = "";
                        if (k < 255)
                        {
                            Main.player[k].active = false;
                        }
                    }
                }
                num++;
                if (num > 10)
                {
                    Thread.Sleep(1);
                    num = 0;
                }
                else
                {
                    Thread.Sleep(0);
                }
                if (!WorldGen.saveLock && !Main.dedServ)
                {
                    if (num3 == 0)
                    {
                        Main.statusText = "Waiting for clients...";
                    }
                    else
                    {
                        Main.statusText = num3 + " clients connected";
                    }
                }
                if (num3 == 0)
                {
                    anyClients = false;
                }
                else
                {
                    anyClients = true;
                }
                ServerUp = true;
            }
            tcpListener.Stop();
            for (int l = 0; l < 256; l++)
            {
                serverSock[l].Reset();
            }
            if (Main.menuMode != 15)
            {
                Main.netMode = 0;
                Main.menuMode = 10;
                WorldGen.saveWorld(false);
                while (WorldGen.saveLock)
                {
                }
                Main.menuMode = 0;
            }
            else
            {
                Main.netMode = 0;
            }
            Main.myPlayer = 0;
        }

        public static void ListenForClients(object threadContext)
        {
            while (!disconnect && !stopListen)
            {
                int num = -1;
                for (int i = 0; i < Main.maxNetPlayers; i++)
                {
                    if (serverSock[i].tcpClient == null || !serverSock[i].tcpClient.Connected)
                    {
                        num = i;
                        break;
                    }
                }
                if (num >= 0)
                {
                    try
                    {
                        serverSock[num].tcpClient = tcpListener.AcceptTcpClient();
                        serverSock[num].tcpClient.NoDelay = true;
                        Console.WriteLine(serverSock[num].tcpClient.Client.RemoteEndPoint + " is connecting...");
                        continue;
                    }
                    catch (Exception ex)
                    {
                        if (!disconnect)
                        {
                            Main.menuMode = 15;
                            Main.statusText = ex.ToString();
                            disconnect = true;
                        }
                        continue;
                    }
                }
                stopListen = true;
                tcpListener.Stop();
            }
        }

        public static void StartServer()
        {
            ThreadPool.QueueUserWorkItem(ServerLoop, 1);
        }

        public static bool SetIP(string newIP)
        {
            try
            {
                serverIP = IPAddress.Parse(newIP);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool SetIP2(string newIP)
        {
            bool result;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(newIP);
                IPAddress[] addressList = hostEntry.AddressList;
                for (int i = 0; i < addressList.Length; i++)
                {
                    if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        serverIP = addressList[i];
                        result = true;
                        return result;
                    }
                }
                result = false;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static void Init()
        {
            for (int i = 0; i < 257; i++)
            {
                if (i < 256)
                {
                    serverSock[i] = new ServerSock();
                    serverSock[i].tcpClient.NoDelay = true;
                }
                NetMessage.buffer[i] = new messageBuffer();
                NetMessage.buffer[i].whoAmI = i;
            }
            clientSock.tcpClient.NoDelay = true;
        }

        public static int GetSectionX(int x)
        {
            return x/200;
        }

        public static int GetSectionY(int y)
        {
            return y/150;
        }
    }
}