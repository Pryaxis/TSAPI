using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Utilities;
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
						Clients[i].TileSections[j, k] = false;
					}
				}
			}
		}
		public static void AddBan(int plr)
		{
			RemoteAddress remoteAddress = Clients[plr].Socket.GetRemoteAddress();
			using (StreamWriter streamWriter = new StreamWriter(BanFilePath, true))
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
				if (File.Exists(BanFilePath))
				{
					using (StreamReader streamReader = new StreamReader(BanFilePath))
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
		public static void newRecent() { }

		public static void SocialClientLoop(object threadContext)
		{
			ISocket socket = (ISocket)threadContext;
			ClientLoopSetup(socket.GetRemoteAddress());
			Connection.Socket = socket;
		}
		public static void TcpClientLoop(object threadContext)
		{
			RemoteAddress address = new TcpAddress(ServerIP, ListenPort);
			ClientLoopSetup(address);
			Main.menuMode = 14;
			bool flag = true;
			while (flag)
			{
				flag = false;
				try
				{
					Connection.Socket.Connect(new TcpAddress(ServerIP, ListenPort));
					flag = false;
				}
				catch
				{
					if (!disconnect && Main.gameMenu)
					{
						flag = true;
					}
				}
			}
		}
		private static void ClientLoopSetup(RemoteAddress address)
		{
			ResetNetDiag();
			Main.ServerSideCharacter = false;
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
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
				Main.statusText = Language.GetTextValue("Net.ConnectingTo", address.GetFriendlyName());
			}
			disconnect = false;
			Connection = new RemoteServer();
			Connection.ReadBuffer = new byte[1024];
		}
		private static int FindNextOpenClientSlot()
		{
			for (int i = 0; i < Main.maxNetPlayers; i++)
			{
				if (!Clients[i].Socket.IsConnected())
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
				Netplay.Clients[num].Reset();
				Netplay.Clients[num].Socket = client;
				Console.WriteLine(Language.GetTextValue("Net.ClientConnecting", client.GetRemoteAddress()));
			}
			if (Netplay.FindNextOpenClientSlot() == -1)
			{
				Netplay.StopListening();
			}
		}

		public static void OnConnectedToSocialServer(ISocket client)
		{
			StartSocialClient(client);
		}
		private static bool StartListening()
		{
			return TcpListener.StartListening(new SocketConnectionAccepted(OnConnectionAccepted));
		}
		private static void StopListening()
		{

			TcpListener.StopListening();
		}
		public static void ServerLoop(object threadContext)
		{
			ResetNetDiag();
			if (Main.rand == null)
			{
				Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
			}
			Main.myPlayer = 255;
			Main.menuMode = 14;
			Main.statusText = Lang.menu[8];
			Main.netMode = 2;
			disconnect = false;
			for (int i = 0; i < 256; i++)
			{
				Clients[i] = new RemoteClient();
				Clients[i].Reset();
				Clients[i].Id = i;
				Clients[i].ReadBuffer = new byte[1024];
			}
			TcpListener = new TcpSocket();
			if (!disconnect)
			{
				if (!StartListening())
				{
					Main.menuMode = 15;
					Main.statusText = Language.GetTextValue("Error.TriedToRunServerTwice");
					disconnect = true;
				}
				Main.statusText = Language.GetTextValue("CLI.ServerStarted");
			}
			int num = 0;
			while (!disconnect)
			{
				if (!IsListening)
				{
					int num2 = -1;
					for (int j = 0; j < Main.maxNetPlayers; j++)
					{
						if (!Clients[j].Socket.IsConnected())
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
								StartListening();
								IsListening = true;
								goto IL_16A;
							}
							catch
							{
								goto IL_16A;
							}
						}
						StartListening();
						IsListening = true;
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
					if (Clients[k].PendingTermination)
					{
						ServerApi.Hooks.InvokeServerLeave(Clients[k].Id);
						Clients[k].Reset();
						NetMessage.SyncDisconnectedPlayer(k);
					}
					else
					{
						if (Clients[k].Socket.IsConnected())
						{
							if (!Clients[k].IsActive)
							{
								Clients[k].State = 0;
							}
							Clients[k].IsActive = true;
							num3++;
							if (!Clients[k].IsReading)
							{
								try
								{
									if (Clients[k].Socket.IsDataAvailable())
									{
										Clients[k].IsReading = true;
										Clients[k].Socket.AsyncReceive(Clients[k].ReadBuffer, 0, Clients[k].ReadBuffer.Length, new SocketReceiveCallback(Clients[k].ServerReadCallBack), null);
									}
								}
								catch
								{
									Clients[k].PendingTermination = true;
								}
							}
							if (Clients[k].StatusMax > 0 && Clients[k].StatusText2 != "")
							{
								if (Clients[k].StatusCount >= Clients[k].StatusMax)
								{
									Clients[k].StatusText = Language.GetTextValue("Net.ClientStatusComplete", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name, Netplay.Clients[k].StatusText2);
									Clients[k].StatusText2 = "";
									Clients[k].StatusMax = 0;
									Clients[k].StatusCount = 0;
									continue;
								}
								Clients[k].StatusText = string.Concat(new object[]
								{
									"(",
									Clients[k].Socket.GetRemoteAddress(),
									") ",
									Clients[k].Name,
									" ",
									Clients[k].StatusText2,
									": ",
									(int)((float)Clients[k].StatusCount / (float)Clients[k].StatusMax * 100f),
									"%"
								});
								continue;
							}
							else
							{
								if (Clients[k].State == 0)
								{
									Clients[k].StatusText = Language.GetTextValue("Net.ClientConnecting", string.Format("({0}) {1}", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name));
									continue;
								}
								if (Clients[k].State == 1)
								{
									Clients[k].StatusText = Language.GetTextValue("Net.ClientSendingData", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name);
									continue;
								}
								if (Clients[k].State == 2)
								{
									Clients[k].StatusText = Language.GetTextValue("Net.ClientRequestedWorldInfo", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name);
									continue;
								}
								if (Clients[k].State == 3 || Clients[k].State != 10)
								{
									continue;
								}
								try
								{
									Clients[k].StatusText = Language.GetTextValue("Net.ClientPlaying", Netplay.Clients[k].Socket.GetRemoteAddress(), Netplay.Clients[k].Name);
									continue;
								}
								catch
								{
									Clients[k].PendingTermination = true;
									continue;
								}
							}
						}
						if (Clients[k].IsActive)
						{
							Clients[k].PendingTermination = true;
						}
						else
						{
							Clients[k].StatusText2 = "";
							if (k < 255)
							{
								bool active = Main.player[k].active;
								Main.player[k].active = false;
								if (active)
								{
									Player.Hooks.PlayerDisconnect(k);
								}
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
						Main.statusText = Language.GetTextValue("Net.WaitingForClients");
					}
					else
					{
						Main.statusText = Language.GetTextValue("Net.ClientsConnected", num3);
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
				IsServerRunning = true;
			}
			StopListening();
			for (int l = 0; l < 256; l++)
			{
				Clients[l].Reset();
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
			ThreadPool.QueueUserWorkItem(new WaitCallback(SocialClientLoop), socket);
		}
		public static void StartTcpClient()
		{
			ThreadPool.QueueUserWorkItem(new WaitCallback(TcpClientLoop), 1);
		}
		public static void StartServer()
		{
			Thread t = new Thread(ServerLoop);
			t.Name = "Server Loop";
			t.Start();
			
			//ThreadPool.QueueUserWorkItem(new WaitCallback(Netplay.ServerLoop), 1);
		}
		public static bool SetRemoteIP(string remoteAddress)
		{
			try
			{
				IPAddress iPAddress;
				if (IPAddress.TryParse(remoteAddress, out iPAddress))
				{
					ServerIP = iPAddress;
					ServerIPText = iPAddress.ToString();
					bool result = true;
					return result;
				}
				IPHostEntry hostEntry = Dns.GetHostEntry(remoteAddress);
				IPAddress[] addressList = hostEntry.AddressList;
				for (int i = 0; i < addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						ServerIP = addressList[i];
						ServerIPText = remoteAddress;
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
					Clients[i] = new RemoteClient();
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
