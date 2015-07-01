using Steamworks;
using System;
using System.Collections.Concurrent;
using System.IO;
using Terraria.Net;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	public abstract class NetSocialModule : Terraria.Social.Base.NetSocialModule
	{
		protected const string StatusInGame = "Playing online.";

		protected const string StatusJoining = "Joining game.";

		protected const int ServerReadChannel = 1;

		protected const int ClientReadChannel = 2;

		protected const int LobbyMessageJoin = 1;

		protected const ushort GamePort = 27005;

		protected const ushort SteamPort = 27006;

		protected const ushort QueryPort = 27007;

		protected readonly static byte[] _handshake;

		protected SteamP2PReader _reader;

		protected SteamP2PWriter _writer;

		protected Lobby _lobby = new Lobby();

		protected ConcurrentDictionary<CSteamID, Terraria.Social.Steam.NetSocialModule.ConnectionState> _connectionStateMap = new ConcurrentDictionary<CSteamID, Terraria.Social.Steam.NetSocialModule.ConnectionState>();

		protected object _steamLock = new object();

		private Callback<LobbyChatMsg_t> _lobbyChatMessage;

		static NetSocialModule()
		{
			Terraria.Social.Steam.NetSocialModule._handshake = new byte[] { 10, 0, 93, 114, 101, 108, 111, 103, 105, 99 };
		}

		protected NetSocialModule(int readChannel, int writeChannel)
		{
			this._reader = new SteamP2PReader(readChannel);
			this._writer = new SteamP2PWriter(writeChannel);
		}

		protected P2PSessionState_t GetSessionState(CSteamID userId)
		{
			P2PSessionState_t p2PSessionStateT;
			SteamNetworking.GetP2PSessionState(userId, out p2PSessionStateT);
			return p2PSessionStateT;
		}

		public override void Initialize()
		{
			this._reader.Start();
			CoreSocialModule.OnTick += new Action(this._writer.SendAll);
			Terraria.Social.Steam.NetSocialModule netSocialModule = this;
			this._lobbyChatMessage = Callback<LobbyChatMsg_t>.Create(new Callback<LobbyChatMsg_t>.DispatchDelegate(netSocialModule.OnLobbyChatMessage));
		}

		public override bool IsConnected(RemoteAddress address)
		{
			if (address == null)
			{
				return false;
			}
			CSteamID steamId = this.RemoteAddressToSteamId(address);
			if (!this._connectionStateMap.ContainsKey(steamId) || this._connectionStateMap[steamId] != Terraria.Social.Steam.NetSocialModule.ConnectionState.Connected)
			{
				return false;
			}
			if (this.GetSessionState(steamId).m_bConnectionActive == 1)
			{
				return true;
			}
			this.Close(address);
			return false;
		}

		public override bool IsDataAvailable(RemoteAddress address)
		{
			CSteamID steamId = this.RemoteAddressToSteamId(address);
			return this._reader.IsDataAvailable(steamId);
		}

		protected virtual void OnLobbyChatMessage(LobbyChatMsg_t result)
		{
			if (result.m_ulSteamIDLobby != this._lobby.Id.m_SteamID)
			{
				return;
			}
			if (result.m_eChatEntryType != 1)
			{
				return;
			}
			if (result.m_ulSteamIDUser != this._lobby.Owner.m_SteamID)
			{
				return;
			}
			byte[] message = this._lobby.GetMessage((int)result.m_iChatID);
			if ((int)message.Length == 0)
			{
				return;
			}
			using (MemoryStream memoryStream = new MemoryStream(message))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					if (binaryReader.ReadByte() == 1)
					{
						while ((long)((int)message.Length) - memoryStream.Position >= (long)8)
						{
							CSteamID cSteamID = new CSteamID(binaryReader.ReadUInt64());
							if (cSteamID == SteamUser.GetSteamID())
							{
								continue;
							}
							this._lobby.SetPlayedWith(cSteamID);
						}
					}
				}
			}
		}

		public override int Receive(RemoteAddress address, byte[] data, int offset, int length)
		{
			if (address == null)
			{
				return 0;
			}
			CSteamID steamId = this.RemoteAddressToSteamId(address);
			return this._reader.Receive(steamId, data, offset, length);
		}

		protected CSteamID RemoteAddressToSteamId(RemoteAddress address)
		{
			return ((SteamAddress)address).SteamId;
		}

		public override bool Send(RemoteAddress address, byte[] data, int length)
		{
			CSteamID steamId = this.RemoteAddressToSteamId(address);
			this._writer.QueueSend(steamId, data, length);
			return true;
		}

		public override void Shutdown()
		{
			this._reader.Stop();
			this._lobby.Leave();
		}

		protected delegate void AsyncHandshake(CSteamID client);

		public enum ConnectionState
		{
			Inactive,
			Authenticating,
			Connected
		}
	}
}