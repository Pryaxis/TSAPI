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
namespace Terraria
{
	public class Netplay
	{
		public const int MaxConnections = 256;
		public const int NetBufferSize = 1024;
		public static string BanFilePath = "banlist.txt";
		public static string ServerPassword = "";
		public static RemoteClient[] Clients = new RemoteClient[256];
		public static RemoteServer Connection = new RemoteServer();
		public static IPAddress ServerIP;
		public static string ServerIPText = "";
		public static ISocket TcpListener;
		public static int ListenPort = 7777;
		public static bool IsServerRunning = false;
		public static bool IsListening = true;
		public static bool UseUPNP = true;
		public static bool disconnect = false;
		public static bool spamCheck = false;
		public static bool anyClients = false;
		public static UPnPNAT upnpnat = (UPnPNAT)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("AE1E00AA-3FD5-403C-8A27-2BBDC30CD0E1")));
		public static IStaticPortMappingCollection mappings = Netplay.upnpnat.StaticPortMappingCollection;
		public static string portForwardIP;
		public static int portForwardPort;
		public static bool portForwardOpen;
		public static event Action OnDisconnect;
		private static void OpenPort()
		{
			Netplay.portForwardIP = Netplay.GetLocalIPAddress();
			Netplay.portForwardPort = Netplay.ListenPort;
			if (Netplay.mappings != null)
			{
				foreach (IStaticPortMapping staticPortMapping in Netplay.mappings)
				{
					if (staticPortMapping.InternalPort == Netplay.portForwardPort && staticPortMapping.InternalClient == Netplay.portForwardIP && staticPortMapping.Protocol == "TCP")
					{
						Netplay.portForwardOpen = true;
					}
				}
				if (!Netplay.portForwardOpen)
				{
					Netplay.mappings.Add(Netplay.portForwardPort, "TCP", Netplay.portForwardPort, Netplay.portForwardIP, true, "Terraria Server");
					Netplay.portForwardOpen = true;
				}
			}
		}
		public static void closePort()
		{
			if (Netplay.portForwardOpen)
			{
				Netplay.mappings.Remove(Netplay.portForwardPort, "TCP");
			}
		}
		public static string GetLocalIPAddress()
		{
			string result = "";
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress[] addressList = hostEntry.AddressList;
			for (int i = 0; i < addressList.Length; i++)
			{
				IPAddress iPAddress = addressList[i];
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					result = iPAddress.ToString();
					break;
				}
			}
			return result;
		}
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
			Netplay.InnerClientLoop();
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
			Netplay.InnerClientLoop();
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
		private static void InnerClientLoop()
		{
			NetMessage.buffer[256].Reset();
			int num = -1;
			while (!Netplay.disconnect)
			{
				if (Netplay.Connection.Socket.IsConnected())
				{
					if (NetMessage.buffer[256].checkBytes)
					{
						NetMessage.CheckBytes(256);
					}
					Netplay.Connection.IsActive = true;
					if (Netplay.Connection.State == 0)
					{
						Main.statusText = "Found server";
						Netplay.Connection.State = 1;
						NetMessage.SendData(1, -1, -1, "", 0, 0f, 0f, 0f, 0, 0, 0);
					}
					if (Netplay.Connection.State == 2 && num != Netplay.Connection.State)
					{
						Main.statusText = "Sending player data...";
					}
					if (Netplay.Connection.State == 3 && num != Netplay.Connection.State)
					{
						Main.statusText = "Requesting world information";
					}
					if (Netplay.Connection.State == 4)
					{
						WorldGen.worldCleared = false;
						Netplay.Connection.State = 5;
						if (Main.cloudBGActive >= 1f)
						{
							Main.cloudBGAlpha = 1f;
						}
						else
						{
							Main.cloudBGAlpha = 0f;
						}
						Main.windSpeed = Main.windSpeedSet;
						Cloud.resetClouds();
						Main.cloudAlpha = Main.maxRaining;
						WorldGen.clearWorld();
						if (Main.mapEnabled)
						{
							Main.Map.Load();
						}
					}
					if (Netplay.Connection.State == 5 && Main.loadMapLock)
					{
						float num2 = (float)Main.loadMapLastX / (float)Main.maxTilesX;
						Main.statusText = string.Concat(new object[]
						{
							Lang.gen[68],
							" ",
							(int)(num2 * 100f + 1f),
							"%"
						});
					}
					else if (Netplay.Connection.State == 5 && WorldGen.worldCleared)
					{
						Netplay.Connection.State = 6;
						Main.player[Main.myPlayer].FindSpawn();
						NetMessage.SendData(8, -1, -1, "", Main.player[Main.myPlayer].SpawnX, (float)Main.player[Main.myPlayer].SpawnY, 0f, 0f, 0, 0, 0);
					}
					if (Netplay.Connection.State == 6 && num != Netplay.Connection.State)
					{
						Main.statusText = "Requesting tile data";
					}
					if (!Netplay.Connection.IsReading && !Netplay.disconnect && Netplay.Connection.Socket.IsDataAvailable())
					{
						Netplay.Connection.IsReading = true;
						Netplay.Connection.Socket.AsyncReceive(Netplay.Connection.ReadBuffer, 0, Netplay.Connection.ReadBuffer.Length, new SocketReceiveCallback(Netplay.Connection.ClientReadCallBack), null);
					}
					if (Netplay.Connection.StatusMax > 0 && Netplay.Connection.StatusText != "")
					{
						if (Netplay.Connection.StatusCount >= Netplay.Connection.StatusMax)
						{
							Main.statusText = Netplay.Connection.StatusText + ": Complete!";
							Netplay.Connection.StatusText = "";
							Netplay.Connection.StatusMax = 0;
							Netplay.Connection.StatusCount = 0;
						}
						else
						{
							Main.statusText = string.Concat(new object[]
							{
								Netplay.Connection.StatusText,
								": ",
								(int)((float)Netplay.Connection.StatusCount / (float)Netplay.Connection.StatusMax * 100f),
								"%"
							});
						}
					}
					Thread.Sleep(1);
				}
				else if (Netplay.Connection.IsActive)
				{
					Main.statusText = "Lost connection";
					Netplay.disconnect = true;
				}
				num = Netplay.Connection.State;
			}
			try
			{
				Netplay.Connection.Socket.Close();
			}
			catch (Exception ex)
			{
#if DEBUG
				Console.WriteLine(ex);
				System.Diagnostics.Debugger.Break();

				System.Diagnostics.Debugger.Break();

#endif
			}
			if (!Main.gameMenu)
			{
				Main.SwitchNetMode(0);
				Player.SavePlayer(Main.ActivePlayerFileData, false);
				Main.ActivePlayerFileData.StopPlayTimer();
				Main.gameMenu = true;
				Main.menuMode = 14;
			}
			NetMessage.buffer[256].Reset();
			if (Main.menuMode == 15 && Main.statusText == "Lost connection")
			{
				Main.menuMode = 14;
			}
			if (Netplay.Connection.StatusText != "" && Netplay.Connection.StatusText != null)
			{
				Main.statusText = "Lost connection";
			}
			Netplay.Connection.StatusCount = 0;
			Netplay.Connection.StatusMax = 0;
			Netplay.Connection.StatusText = "";
			Main.SwitchNetMode(0);
			if (Netplay.OnDisconnect != null)
			{
				Netplay.OnDisconnect();
			}
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
				Console.WriteLine(client.GetRemoteAddress() + " is connecting...");
			}
			if (Netplay.FindNextOpenClientSlot() == -1)
			{
				Netplay.StopListening();
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
			Netplay.ServerIP = IPAddress.Any;
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
			if (Netplay.UseUPNP)
			{
				try
				{
					Netplay.OpenPort();
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
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
						Netplay.Clients[k].Reset();
						NetMessage.syncPlayers();
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
			try
			{
				Netplay.closePort();
			}
			catch
			{
				if (!Main.ignoreErrors)
				{
					throw;
				}
			}
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
