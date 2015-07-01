using Steamworks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Terraria;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.Steam
{
	public class NetServerSocialModule : NetSocialModule
	{
		private Callback<P2PSessionRequest_t> _p2pSessionRequest;

		private bool _acceptingClients;

		private SocketConnectionAccepted _connectionAcceptedCallback;

		public NetServerSocialModule() : base(1, 2)
		{
		}

		private void BroadcastConnectedUsers()
		{
			List<ulong> nums = new List<ulong>();
			foreach (KeyValuePair<CSteamID, NetSocialModule.ConnectionState> keyValuePair in this._connectionStateMap)
			{
				if (keyValuePair.Value != NetSocialModule.ConnectionState.Connected)
				{
					continue;
				}
				nums.Add(keyValuePair.Key.m_SteamID);
			}
			byte[] numArray = new byte[nums.Count * 8 + 1];
			using (MemoryStream memoryStream = new MemoryStream(numArray))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((byte)1);
					foreach (ulong num in nums)
					{
						binaryWriter.Write(num);
					}
				}
			}
			this._lobby.SendMessage(numArray);
		}

		public override void CancelJoin()
		{
		}

		public override bool CanInvite()
		{
			return false;
		}

		public override void Close(RemoteAddress address)
		{
			this.Close(base.RemoteAddressToSteamId(address));
		}

		private void Close(CSteamID user)
		{
			if (!this._connectionStateMap.ContainsKey(user))
			{
				return;
			}
			SteamUser.EndAuthSession(user);
			SteamNetworking.CloseP2PSessionWithUser(user);
			this._connectionStateMap[user] = NetSocialModule.ConnectionState.Inactive;
		}

		public override void Connect(RemoteAddress address)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			this._reader.SetReadEvent(new SteamP2PReader.OnReadEvent(this.OnPacketRead));
			this._p2pSessionRequest = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate(this.OnP2PSessionRequest));
			if (Program.LaunchParameters.ContainsKey("-lobby"))
			{
				string item = Program.LaunchParameters["-lobby"];
				string str = item;
				if (item != null)
				{
					if (str == "private")
					{
						this._lobby.Create(true, new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
						return;
					}
					if (str == "friends")
					{
						this._lobby.Create(false, new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
						return;
					}
				}
				Console.WriteLine("-lobby flag used without \"private\" or \"friends\". Ignoring it.");
			}
		}

		public override void LaunchLocalServer(Process process, ServerSocialMode mode)
		{
		}

		private void OnLobbyCreated(LobbyCreated_t result, bool failure)
		{
			if (failure)
			{
				return;
			}
			SteamFriends.SetRichPresence("status", "Playing online.");
		}

		private void OnP2PSessionRequest(P2PSessionRequest_t result)
		{
			P2PSessionState_t p2PSessionStateT;
			CSteamID mSteamIDRemote = result.m_steamIDRemote;
			if (this._connectionStateMap.ContainsKey(mSteamIDRemote) && this._connectionStateMap[mSteamIDRemote] != NetSocialModule.ConnectionState.Inactive)
			{
				SteamNetworking.AcceptP2PSessionWithUser(mSteamIDRemote);
				return;
			}
			if (!this._acceptingClients)
			{
				return;
			}
			SteamNetworking.AcceptP2PSessionWithUser(mSteamIDRemote);
			while (SteamNetworking.GetP2PSessionState(mSteamIDRemote, out p2PSessionStateT) && p2PSessionStateT.m_bConnecting == 1)
			{
			}
			if (p2PSessionStateT.m_bConnectionActive == 0)
			{
				this.Close(mSteamIDRemote);
			}
			this._connectionStateMap[mSteamIDRemote] = NetSocialModule.ConnectionState.Authenticating;
			this._connectionAcceptedCallback(new SocialSocket(new SteamAddress(mSteamIDRemote)));
		}

		private bool OnPacketRead(byte[] data, int length, CSteamID userId)
		{
			P2PSessionRequest_t p2PSessionRequestT = new P2PSessionRequest_t();
			if (!this._connectionStateMap.ContainsKey(userId) || this._connectionStateMap[userId] == NetSocialModule.ConnectionState.Inactive)
			{
				p2PSessionRequestT.m_steamIDRemote = userId;
				this.OnP2PSessionRequest(p2PSessionRequestT);
				if (!this._connectionStateMap.ContainsKey(userId) || this._connectionStateMap[userId] == NetSocialModule.ConnectionState.Inactive)
				{
					return false;
				}
			}
			NetSocialModule.ConnectionState item = this._connectionStateMap[userId];
			if (item != NetSocialModule.ConnectionState.Authenticating)
			{
				return item == NetSocialModule.ConnectionState.Connected;
			}
			if (length < 3)
			{
				return false;
			}
			if ((data[1] << 8 | data[0]) != length)
			{
				return false;
			}
			if (data[2] != 93)
			{
				return false;
			}
			byte[] numArray = new byte[(int)data.Length - 3];
			Array.Copy(data, 3, numArray, 0, (int)numArray.Length);
			switch (SteamUser.BeginAuthSession(numArray, (int)numArray.Length, userId))
			{
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultOK:
				{
					this._connectionStateMap[userId] = NetSocialModule.ConnectionState.Connected;
					this.BroadcastConnectedUsers();
					break;
				}
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultInvalidTicket:
				{
					this.Close(userId);
					break;
				}
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultDuplicateRequest:
				{
					this.Close(userId);
					break;
				}
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultInvalidVersion:
				{
					this.Close(userId);
					break;
				}
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultGameMismatch:
				{
					this.Close(userId);
					break;
				}
				case EBeginAuthSessionResult.k_EBeginAuthSessionResultExpiredTicket:
				{
					this.Close(userId);
					break;
				}
			}
			return false;
		}

		public override void OpenInviteInterface()
		{
		}

		public override bool StartListening(SocketConnectionAccepted callback)
		{
			this._acceptingClients = true;
			this._connectionAcceptedCallback = callback;
			return true;
		}

		public override void StopListening()
		{
			this._acceptingClients = false;
		}
	}
}