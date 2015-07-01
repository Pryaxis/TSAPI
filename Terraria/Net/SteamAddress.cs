using Steamworks;
using System;
using System.Collections.Generic;
using Terraria;

namespace Terraria.Net
{
	public class SteamAddress : RemoteAddress
	{
		public readonly CSteamID SteamId;

		private string _friendlyName;

		public SteamAddress(CSteamID steamId)
		{
			this.Type = AddressType.Steam;
			this.SteamId = steamId;
		}

		public override string GetFriendlyName()
		{
			if (this._friendlyName == null)
			{
				this._friendlyName = SteamFriends.GetFriendPersonaName(this.SteamId);
			}
			return this._friendlyName;
		}

		public override string GetIdentifier()
		{
			return this.ToString();
		}

		public override bool IsLocalHost()
		{
			if (!Program.LaunchParameters.ContainsKey("-localsteamid"))
			{
				return false;
			}
			return Program.LaunchParameters["-localsteamid"].Equals(this.SteamId.m_SteamID.ToString());
		}

		public override string ToString()
		{
			ulong mSteamID = this.SteamId.m_SteamID % (long)2;
			string str = mSteamID.ToString();
			ulong num = (this.SteamId.m_SteamID - (76561197960265728L + this.SteamId.m_SteamID % (long)2)) / (long)2;
			string str1 = num.ToString();
			return string.Concat("STEAM_0:", str, ":", str1);
		}
	}
}