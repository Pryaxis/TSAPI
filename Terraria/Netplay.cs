using NATUPNPLib;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.IO;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;
using TerrariaApi.Server;

namespace Terraria
{
	public class Netplay
	{
		public static int MaxConnections = 256;
		public const int NetBufferSize = 1024;
		public static string BanFilePath = "banlist.txt";
		public static string ServerPassword = "";
		public static RemoteClient[] Clients = new RemoteClient[256];
		public static RemoteServer Connection = new RemoteServer();
		public static IPAddress ServerIP = IPAddress.Any;
		public static string ServerIPText = "";
		public static ISocket TcpListener;
		public static int ListenPort = 7777;
		public static bool IsServerRunning = false;
		public static bool IsListening = true;
		public static bool disconnect = false;
		public static bool spamCheck = false;
		public static bool anyClients = false;
		public static event Action OnDisconnect;

        public static void ResetNetDiag()
		{
			Main.rxMsg = 0;
			Main.rxData = 0;
			Main.txMsg = 0;
			Main.txData = 0;
		}
		public static void ResetSections()
		{
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < Main.maxSectionsX; j++)
				{
					for (int k = 0; k < Main.maxSectionsY; k++)
					{
						Netplay.Clients[i].TileSections[j, k] = false;
					}
				}
			}
		}
		public static void AddBan(int plr)
		{
			RemoteAddress remoteAddress = Netplay.Clients[plr].Socket.GetRemoteAddress();
			using (StreamWriter streamWriter = new StreamWriter(Netplay.BanFilePath, true))
			{
				streamWriter.WriteLine("//" + Main.player[plr].name);
				streamWriter.WriteLine(remoteAddress.ToString());
			}
		}
		public static bool IsBanned(RemoteAddress address)
		{
			try
			{
				string identifier = address.GetIdentifier();
				if (File.Exists(Netplay.BanFilePath))
				{
					using (StreamReader streamReader = new StreamReader(Netplay.BanFilePath))
					{
						string a;
						while ((a = streamReader.ReadLine()) != null)
						{
							if (a == identifier)
							{
								return true;
							}
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
		public static void newRecent()
		{
			if (Netplay.Connection.Socket.GetRemoteAddress().Type != AddressType.Tcp)
			{
				return;
			}
			for (int i = 0; i < Main.maxMP; i++)
			{
				if (Main.recentIP[i].ToLower() == Netplay.ServerIPText.ToLower() && Main.recentPort[i] == Netplay.ListenPort)
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
			Main.recentIP[0] = Netplay.ServerIPText;
			Main.recentPort[0] = Netplay.ListenPort;
			Main.recentWorld[0] = Main.worldName;
			Main.SaveRecent();
		}
		public static void SocialClientLoop(object threadContext)
		{
			ISocket socket = (ISocket)threadContext;
			Netplay.ClientLoopSetup(socket.GetRemoteAddress());
			Netplay.Connection.Socket = socket;
		}
		public static void TcpClientLoop(object threadContext)
		{
			RemoteAddress address = new TcpAddress(Netplay.ServerIP, Netplay.ListenPort);
			Netplay.ClientLoopSetup(address);
			Main.menuMode = 14;
			bool flag = true;
			while (flag)
			{
				flag = false;
				try
				{
					Netplay.Connection.Socket.Connect(new TcpAddress(Netplay.ServerIP, Netplay.ListenPort));
					flag = false;
				}
				catch
				{
					if (!Netplay.disconnect && Main.gameMenu)
					{
						flag = true;
					}
				}
			}
		}
		private static void ClientLoopSetup(RemoteAddress address)
		{
			Netplay.ResetNetDiag();
			Main.ServerSideCharacter = false;
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			Main.player[Main.myPlayer].hostile = false;
			Main.clientPlayer = (Player)Main.player[Main.myPlayer].clientClone();
			for (int i = 0; i < 255; i++)
			{
				if (i != Main.myPlayer)
				{
					Main.player[i] = new Player();
				}
			}
			Main.netMode = 1;
			Main.menuMode = 14;
			if (!Main.autoPass)
			{
				Main.statusText = "Connecting to " + address.GetFriendlyName();
			}
			Netplay.disconnect = false;
			Netplay.Connection = new RemoteServer();
			Netplay.Connection.ReadBuffer = new byte[1024];
		}
		private static int FindNextOpenClientSlot()
		{
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (!Netplay.Clients[i].Socket.IsConnected())
				{
					return i;
				}
			}
			return -1;
		}
		private static void OnConnectionAccepted(ISocket client)
		{
			int num = Netplay.FindNextOpenClientSlot();
			if (num != -1)
			{
				Netplay.Clients[num].Socket = client;
				Netplay.Clients[num].sendQueue.StartThread();

				Console.WriteLine(client.GetRemoteAddress() + " is connecting to slot {0}...", num);
			}
			else
			{
				using (var stream = new MemoryStream())
				{ 
					using (var writer = new BinaryWriter(stream))
					{ 
						writer.Write((short)0);
						writer.Write((byte)2);
						writer.Write("Server is full."); 
						short position = (short)writer.BaseStream.Position; 
						writer.BaseStream.Position = 0L;
						writer.Write((short)position); 
						byte[] data = stream.ToArray();
						client.AsyncSend(data, 0, data.Length, delegate { }); 
					}
				}
				client.Close();
			}
		}
		public static void OnConnectedToSocialServer(ISocket client)
		{
			Netplay.StartSocialClient(client);
		}
		private static bool StartListening()
		{
			if (SocialAPI.Network != null)
			{
				SocialAPI.Network.StartListening(new SocketConnectionAccepted(Netplay.OnConnectionAccepted));
			}
			return Netplay.TcpListener.StartListening(new SocketConnectionAccepted(Netplay.OnConnectionAccepted));
		}
		private static void StopListening()
		{
			if (SocialAPI.Network != null)
			{
				SocialAPI.Network.StopListening();
			}
			Netplay.TcpListener.StopListening();
		}
		public static void ServerLoop(object threadContext)
		{
			Netplay.ResetNetDiag();
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (WorldGen.genRand == null)
			{
				WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
			}
			Main.myPlayer = 255;
			Main.menuMode = 14;
			Main.statusText = "Starting server...";
			Main.netMode = 2;
			Netplay.disconnect = false;
			for (int i = 0; i < 256; i++)
			{
				Netplay.Clients[i] = new RemoteClient();
				Netplay.Clients[i].Reset();
				Netplay.Clients[i].Id = i;
				Netplay.Clients[i].ReadBuffer = new byte[1024];
			}
			Netplay.TcpListener = new TcpSocket();
			if (!Netplay.disconnect)
			{
				if (!Netplay.StartListening())
				{
					Main.menuMode = 15;
					Main.statusText = "Tried to run two servers on the same PC";
					Netplay.disconnect = true;
				}
				Main.statusText = "Server started";
			}
			int num = 0;
			while (!Netplay.disconnect)
			{
				if (!Netplay.IsListening)
				{
					int num2 = -1;
					for (int j = 0; j < Main.maxNetPlayers; j++)
					{
						if (!Netplay.Clients[j].Socket.IsConnected())
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
								Netplay.StartListening();
								Netplay.IsListening = true;
								goto IL_16A;
							}
							catch
							{
								goto IL_16A;
							}
						}
						Netplay.StartListening();
						Netplay.IsListening = true;
					}
				}
			IL_16A:
				int num3 = 0;
				for (int k = 0; k < 256; k++)
				{
					if (NetMessage.buffer[k].checkBytes)
					{
						NetMessage.CheckBytes(k);
					}
					if (Netplay.Clients[k].PendingTermination)
					{
						ServerApi.Hooks.InvokeServerLeave(Netplay.Clients[k].Id);
						Netplay.Clients[k].Reset();
						NetMessage.syncPlayers(sendInventory: false, sendPlayerInfo: false);
					}
					else
					{
						if (Netplay.Clients[k].Socket.IsConnected())
						{
							if (!Netplay.Clients[k].IsActive)
							{
								Netplay.Clients[k].State = 0;
							}
							Netplay.Clients[k].IsActive = true;
							num3++;
							if (!Netplay.Clients[k].IsReading)
							{
								try
								{
									if (Netplay.Clients[k].Socket.IsDataAvailable())
									{
										Netplay.Clients[k].IsReading = true;
										Netplay.Clients[k].Socket.AsyncReceive(Netplay.Clients[k].ReadBuffer, 0, Netplay.Clients[k].ReadBuffer.Length, new SocketReceiveCallback(Netplay.Clients[k].ServerReadCallBack), null);
									}
								}
								catch
								{
									Netplay.Clients[k].PendingTermination = true;
								}
							}
							if (Netplay.Clients[k].StatusMax > 0 && Netplay.Clients[k].StatusText2 != "")
							{
								if (Netplay.Clients[k].StatusCount >= Netplay.Clients[k].StatusMax)
								{
									Netplay.Clients[k].StatusText = string.Concat(new object[]
									{
										"(",
										Netplay.Clients[k].Socket.GetRemoteAddress(),
										") ",
										Netplay.Clients[k].Name,
										" ",
										Netplay.Clients[k].StatusText2,
										": Complete!"
									});
									Netplay.Clients[k].StatusText2 = "";
									Netplay.Clients[k].StatusMax = 0;
									Netplay.Clients[k].StatusCount = 0;
									continue;
								}
								Netplay.Clients[k].StatusText = string.Concat(new object[]
								{
									"(",
									Netplay.Clients[k].Socket.GetRemoteAddress(),
									") ",
									Netplay.Clients[k].Name,
									" ",
									Netplay.Clients[k].StatusText2,
									": ",
									(int)((float)Netplay.Clients[k].StatusCount / (float)Netplay.Clients[k].StatusMax * 100f),
									"%"
								});
								continue;
							}
							else
							{
								if (Netplay.Clients[k].State == 0)
								{
									Netplay.Clients[k].StatusText = string.Concat(new object[]
									{
										"(",
										Netplay.Clients[k].Socket.GetRemoteAddress(),
										") ",
										Netplay.Clients[k].Name,
										" is connecting..."
									});
									continue;
								}
								if (Netplay.Clients[k].State == 1)
								{
									Netplay.Clients[k].StatusText = string.Concat(new object[]
									{
										"(",
										Netplay.Clients[k].Socket.GetRemoteAddress(),
										") ",
										Netplay.Clients[k].Name,
										" is sending player data..."
									});
									continue;
								}
								if (Netplay.Clients[k].State == 2)
								{
									Netplay.Clients[k].StatusText = string.Concat(new object[]
									{
										"(",
										Netplay.Clients[k].Socket.GetRemoteAddress(),
										") ",
										Netplay.Clients[k].Name,
										" requested world information"
									});
									continue;
								}
								if (Netplay.Clients[k].State == 3 || Netplay.Clients[k].State != 10)
								{
									continue;
								}
								try
								{
									Netplay.Clients[k].StatusText = string.Concat(new object[]
									{
										"(",
										Netplay.Clients[k].Socket.GetRemoteAddress(),
										") ",
										Netplay.Clients[k].Name,
										" is playing"
									});
									continue;
								}
								catch
								{
									Netplay.Clients[k].PendingTermination = true;
									continue;
								}
							}
						}
						if (Netplay.Clients[k].IsActive)
						{
							Netplay.Clients[k].PendingTermination = true;
						}
						else
						{
							Netplay.Clients[k].StatusText2 = "";
							if (k < 255)
							{
								Main.player[k].active = false;
							}
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
					Netplay.anyClients = false;
				}
				else
				{
					Netplay.anyClients = true;
				}
				Netplay.IsServerRunning = true;
			}
			Netplay.StopListening();
			for (int l = 0; l < 256; l++)
			{
				Netplay.Clients[l].Reset();
			}
			if (Main.menuMode != 15)
			{
				Main.netMode = 0;
				Main.menuMode = 10;
				WorldFile.saveWorld();
				//blocks until world saves?
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
		public static void StartSocialClient(ISocket socket)
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.SocialClientLoop), socket);
		}
		public static void StartTcpClient()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.TcpClientLoop), 1);
		}
		public static void StartServer()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ServerLoop), 1);
		}
		public static bool SetRemoteIP(string remoteAddress)
		{
			try
			{
				IPAddress iPAddress;
				if (IPAddress.TryParse(remoteAddress, out iPAddress))
				{
					Netplay.ServerIP = iPAddress;
					Netplay.ServerIPText = iPAddress.ToString();
					bool result = true;
					return result;
				}
				IPHostEntry hostEntry = Dns.GetHostEntry(remoteAddress);
				IPAddress[] addressList = hostEntry.AddressList;
				for (int i = 0; i < addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						Netplay.ServerIP = addressList[i];
						Netplay.ServerIPText = remoteAddress;
						bool result = true;
						return result;
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
		public static void Initialize()
		{
			for (int i = 0; i < 257; i++)
			{
				if (i < 256)
				{
					Netplay.Clients[i] = new RemoteClient();
				}
				NetMessage.buffer[i] = new MessageBuffer();
				NetMessage.buffer[i].whoAmI = i;
			}
		}
		public static int GetSectionX(int x)
		{
			return x / 200;
		}
		public static int GetSectionY(int y)
		{
			return y / 150;
		}
	}
}
