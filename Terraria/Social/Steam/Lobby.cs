using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
	public class Lobby
	{
		private HashSet<CSteamID> _usersSeen = new HashSet<CSteamID>();

		private byte[] _messageBuffer = new byte[1024];

		public CSteamID Id = CSteamID.Nil;

		public CSteamID Owner = CSteamID.Nil;

		public LobbyState State;

		private CallResult<LobbyEnter_t> _lobbyEnter;

		private CallResult<LobbyEnter_t>.APIDispatchDelegate _lobbyEnterExternalCallback;

		private CallResult<LobbyCreated_t> _lobbyCreated;

		private CallResult<LobbyCreated_t>.APIDispatchDelegate _lobbyCreatedExternalCallback;

		public Lobby()
		{
			this._lobbyEnter = CallResult<LobbyEnter_t>.Create(new CallResult<LobbyEnter_t>.APIDispatchDelegate(this.OnLobbyEntered));
			this._lobbyCreated = CallResult<LobbyCreated_t>.Create(new CallResult<LobbyCreated_t>.APIDispatchDelegate(this.OnLobbyCreated));
		}

		public void Create(bool inviteOnly, CallResult<LobbyCreated_t>.APIDispatchDelegate callResult)
		{
			SteamAPICall_t steamAPICallT = SteamMatchmaking.CreateLobby((inviteOnly ? ELobbyType.k_ELobbyTypePrivate : ELobbyType.k_ELobbyTypeFriendsOnly), 256);
			this._lobbyCreatedExternalCallback = callResult;
			this._lobbyCreated.Set(steamAPICallT, null);
			this.State = LobbyState.Creating;
		}

		public byte[] GetMessage(int index)
		{
			CSteamID cSteamID;
			EChatEntryType eChatEntryType;
			int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry(this.Id, index, out cSteamID, this._messageBuffer, (int)this._messageBuffer.Length, out eChatEntryType);
			byte[] numArray = new byte[lobbyChatEntry];
			Array.Copy(this._messageBuffer, numArray, lobbyChatEntry);
			return numArray;
		}

		public CSteamID GetUserByIndex(int index)
		{
			return SteamMatchmaking.GetLobbyMemberByIndex(this.Id, index);
		}

		public int GetUserCount()
		{
			return SteamMatchmaking.GetNumLobbyMembers(this.Id);
		}

		public void Join(CSteamID lobbyId, CallResult<LobbyEnter_t>.APIDispatchDelegate callResult)
		{
			if (this.State != LobbyState.Inactive)
			{
				return;
			}
			this.State = LobbyState.Connecting;
			this._lobbyEnterExternalCallback = callResult;
			SteamAPICall_t steamAPICallT = SteamMatchmaking.JoinLobby(lobbyId);
			this._lobbyEnter.Set(steamAPICallT, null);
		}

		public void Leave()
		{
			if (this.State == LobbyState.Active)
			{
				SteamMatchmaking.LeaveLobby(this.Id);
			}
			this.State = LobbyState.Inactive;
			this._usersSeen.Clear();
		}

		private void OnLobbyCreated(LobbyCreated_t result, bool failure)
		{
			if (this.State != LobbyState.Creating)
			{
				return;
			}
			if (!failure)
			{
				this.State = LobbyState.Active;
			}
			else
			{
				this.State = LobbyState.Inactive;
			}
			this.Id = new CSteamID(result.m_ulSteamIDLobby);
			this.Owner = SteamMatchmaking.GetLobbyOwner(this.Id);
			this._lobbyCreatedExternalCallback(result, failure);
		}

		private void OnLobbyEntered(LobbyEnter_t result, bool failure)
		{
			if (this.State != LobbyState.Connecting)
			{
				return;
			}
			if (!failure)
			{
				this.State = LobbyState.Active;
			}
			else
			{
				this.State = LobbyState.Inactive;
			}
			this.Id = new CSteamID(result.m_ulSteamIDLobby);
			this.Owner = SteamMatchmaking.GetLobbyOwner(this.Id);
			this._lobbyEnterExternalCallback(result, failure);
		}

		public bool SendMessage(byte[] data)
		{
			return this.SendMessage(data, (int)data.Length);
		}

		public bool SendMessage(byte[] data, int length)
		{
			if (this.State != LobbyState.Active)
			{
				return false;
			}
			return SteamMatchmaking.SendLobbyChatMsg(this.Id, data, length);
		}

		public void Set(CSteamID lobbyId)
		{
			this.Id = lobbyId;
			this.State = LobbyState.Active;
			this.Owner = SteamMatchmaking.GetLobbyOwner(lobbyId);
		}

		public void SetPlayedWith(CSteamID userId)
		{
			if (this._usersSeen.Contains(userId))
			{
				return;
			}
			SteamFriends.SetPlayedWith(userId);
			this._usersSeen.Add(userId);
		}
	}
}