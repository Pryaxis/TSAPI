using Steamworks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.IO;
using Terraria.Net;
using Terraria.Net.Sockets;

namespace Terraria.Social.Steam
{
	public class NetClientSocialModule : NetSocialModule
	{
		private Callback<GameLobbyJoinRequested_t> _gameLobbyJoinRequested;

		private Callback<P2PSessionRequest_t> _p2pSessionRequest;

		private Callback<P2PSessionConnectFail_t> _p2pSessionConnectfail;

		private HAuthTicket _authTicket = HAuthTicket.Invalid;

		private byte[] _authData = new byte[1021];

		private uint _authDataLength;

		private bool _hasLocalHost;

		public NetClientSocialModule() : base(2, 1)
		{
		}

		public override void CancelJoin()
		{
			if (this._lobby.State != LobbyState.Inactive)
			{
				this._lobby.Leave();
			}
		}

		public override bool CanInvite()
		{
			if (this._hasLocalHost)
			{
				return true;
			}
			return this._lobby.State == LobbyState.Active;
		}

		private void CheckParameters()
		{
			ulong num;
			if (Program.LaunchParameters.ContainsKey("+connect_lobby") && ulong.TryParse(Program.LaunchParameters["+connect_lobby"], out num))
			{
				CSteamID cSteamID = new CSteamID(num);
				if (cSteamID.IsValid())
				{
					Main.OpenPlayerSelect((PlayerFileData playerData) => {
						Main.ServerSideCharacter = false;
						playerData.SetAsActive();
						Main.menuMode = 10;
						Main.statusText = "Joining game...";
						this._lobby.Join(cSteamID, new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnLobbyEntered));
					});
				}
			}
		}

		private void ClearAuthTicket()
		{
			if (this._authTicket != HAuthTicket.Invalid)
			{
				SteamUser.CancelAuthTicket(this._authTicket);
			}
			this._authTicket = HAuthTicket.Invalid;
			for (int i = 0; i < (int)this._authData.Length; i++)
			{
				this._authData[i] = 0;
			}
			this._authDataLength = 0;
		}

		public override void Close(RemoteAddress address)
		{
			SteamFriends.ClearRichPresence();
			this.Close(base.RemoteAddressToSteamId(address));
		}

		private void Close(CSteamID user)
		{
			if (!this._connectionStateMap.ContainsKey(user))
			{
				return;
			}
			SteamNetworking.CloseP2PSessionWithUser(user);
			this.ClearAuthTicket();
			this._connectionStateMap[user] = NetSocialModule.ConnectionState.Inactive;
			this._lobby.Leave();
			this._reader.ClearUser(user);
			this._writer.ClearUser(user);
		}

		public override void Connect(RemoteAddress address)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			this._gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(new Callback<GameLobbyJoinRequested_t>.DispatchDelegate(this.OnLobbyJoinRequest));
			this._p2pSessionRequest = Callback<P2PSessionRequest_t>.Create(new Callback<P2PSessionRequest_t>.DispatchDelegate(this.OnP2PSessionRequest));
			this._p2pSessionConnectfail = Callback<P2PSessionConnectFail_t>.Create(new Callback<P2PSessionConnectFail_t>.DispatchDelegate(this.OnSessionConnectFail));
			Main.OnEngineLoad += new Action(this.CheckParameters);
		}

		public override void LaunchLocalServer(Process process, ServerSocialMode mode)
		{
			if (this._lobby.State != LobbyState.Inactive)
			{
				this._lobby.Leave();
			}
			ProcessStartInfo startInfo = process.StartInfo;
			startInfo.Arguments = string.Concat(startInfo.Arguments, " -steam -localsteamid ", SteamUser.GetSteamID().m_SteamID);
			switch (mode)
			{
				case ServerSocialMode.InviteOnly:
				{
					ProcessStartInfo processStartInfo = process.StartInfo;
					processStartInfo.Arguments = string.Concat(processStartInfo.Arguments, " -lobby private");
					this._hasLocalHost = true;
					break;
				}
				case ServerSocialMode.FriendsOnly:
				{
					ProcessStartInfo startInfo1 = process.StartInfo;
					startInfo1.Arguments = string.Concat(startInfo1.Arguments, " -lobby friends");
					this._hasLocalHost = true;
					break;
				}
			}
			SteamFriends.SetRichPresence("status", "Playing online.");
			Netplay.OnDisconnect += new Action(this.OnDisconnect);
			process.Start();
		}

		private void OnDisconnect()
		{
			SteamFriends.ClearRichPresence();
			this._hasLocalHost = false;
			Netplay.OnDisconnect -= new Action(this.OnDisconnect);
		}

		private void OnLobbyEntered(LobbyEnter_t result, bool failure)
		{
			P2PSessionState_t p2PSessionStateT;
			SteamNetworking.AllowP2PPacketRelay(true);
			this.SendAuthTicket(this._lobby.Owner);
			int num = 0;
			while (SteamNetworking.GetP2PSessionState(this._lobby.Owner, out p2PSessionStateT) && p2PSessionStateT.m_bConnectionActive != 1)
			{
				switch (p2PSessionStateT.m_eP2PSessionError)
				{
					case 1:
					{
						this.ClearAuthTicket();
						return;
					}
					case 2:
					{
						this.ClearAuthTicket();
						return;
					}
					case 3:
					{
						this.ClearAuthTicket();
						return;
					}
					case 4:
					{
						int num1 = num + 1;
						num = num1;
						if (num1 > 5)
						{
							this.ClearAuthTicket();
							return;
						}
						SteamNetworking.CloseP2PSessionWithUser(this._lobby.Owner);
						this.SendAuthTicket(this._lobby.Owner);
						continue;
					}
					case 5:
					{
						this.ClearAuthTicket();
						return;
					}
					default:
					{
						continue;
					}
				}
			}
			this._connectionStateMap[this._lobby.Owner] = NetSocialModule.ConnectionState.Connected;
			SteamFriends.SetPlayedWith(this._lobby.Owner);
			SteamFriends.SetRichPresence("status", "Playing online.");
			Main.netMode = 1;
			Netplay.OnConnectedToSocialServer(new SocialSocket(new SteamAddress(this._lobby.Owner)));
		}

		private void OnLobbyJoinRequest(GameLobbyJoinRequested_t result)
		{
			if (this._lobby.State != LobbyState.Inactive)
			{
				this._lobby.Leave();
			}
			string friendPersonaName = SteamFriends.GetFriendPersonaName(result.m_steamIDFriend);
			Main.OpenPlayerSelect((PlayerFileData playerData) => {
				Main.ServerSideCharacter = false;
				playerData.SetAsActive();
				Main.menuMode = 882;
				Main.statusText = string.Concat("Joining ", friendPersonaName, "...");
				this._lobby.Join(result.m_steamIDLobby, new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnLobbyEntered));
			});
		}

		private void OnP2PSessionRequest(P2PSessionRequest_t result)
		{
			CSteamID mSteamIDRemote = result.m_steamIDRemote;
			if (this._connectionStateMap.ContainsKey(mSteamIDRemote) && this._connectionStateMap[mSteamIDRemote] != NetSocialModule.ConnectionState.Inactive)
			{
				SteamNetworking.AcceptP2PSessionWithUser(mSteamIDRemote);
			}
		}

		private void OnSessionConnectFail(P2PSessionConnectFail_t result)
		{
			this.Close(result.m_steamIDRemote);
		}

		public override void OpenInviteInterface()
		{
			SteamFriends.ActivateGameOverlay("LobbyInvite");
		}

		private void SendAuthTicket(CSteamID address)
		{
			if (this._authTicket == HAuthTicket.Invalid)
			{
				this._authTicket = SteamUser.GetAuthSessionTicket(this._authData, (int)this._authData.Length, out this._authDataLength);
			}
			int num = (int)(this._authDataLength + 3);
			byte[] numArray = new byte[num];
			numArray[0] = (byte)(num & 255);
			numArray[1] = (byte)(num >> 8 & 255);
			numArray[2] = 93;
			for (int i = 0; i < this._authDataLength; i++)
			{
				numArray[i + 3] = this._authData[i];
			}
			SteamNetworking.SendP2PPacket(address, numArray, (uint)num, EP2PSend.k_EP2PSendReliable, 1);
		}

		public override bool StartListening(SocketConnectionAccepted callback)
		{
			return false;
		}

		public override void StopListening()
		{
		}
	}
}