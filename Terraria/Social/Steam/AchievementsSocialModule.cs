using Steamworks;
using System;
using System.Threading;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	internal class AchievementsSocialModule : Terraria.Social.Base.AchievementsSocialModule
	{
		private const string FILE_NAME = "/achievements-steam.dat";

		private Callback<UserStatsReceived_t> _userStatsReceived;

		private bool _areStatsReceived;

		public AchievementsSocialModule()
		{
		}

		public override void CompleteAchievement(string name)
		{
			SteamUserStats.SetAchievement(name);
		}

		public override byte[] GetEncryptionKey()
		{
			byte[] numArray = new byte[16];
			byte[] bytes = BitConverter.GetBytes(SteamUser.GetSteamID().m_SteamID);
			Array.Copy(bytes, numArray, 8);
			Array.Copy(bytes, 0, numArray, 8, 8);
			return numArray;
		}

		public override string GetSavePath()
		{
			return "/achievements-steam.dat";
		}

		public override void Initialize()
		{
			this._userStatsReceived = Callback<UserStatsReceived_t>.Create(new Callback<UserStatsReceived_t>.DispatchDelegate(this.OnUserStatsReceived));
			SteamUserStats.RequestCurrentStats();
			while (!this._areStatsReceived)
			{
				Thread.Sleep(1);
			}
		}

		public override bool IsAchievementCompleted(string name)
		{
			bool flag;
			if (SteamUserStats.GetAchievement(name, out flag))
			{
				return flag;
			}
			return false;
		}

		private void OnUserStatsReceived(UserStatsReceived_t results)
		{
			if (results.m_nGameID == (long)105600 && results.m_steamIDUser == SteamUser.GetSteamID())
			{
				this._areStatsReceived = true;
			}
		}

		public override void Shutdown()
		{
			this.StoreStats();
		}

		public override void StoreStats()
		{
			SteamUserStats.StoreStats();
		}

		public override void UpdateFloatStat(string name, float value)
		{
			float single;
			SteamUserStats.GetStat(name, out single);
			if (single < value)
			{
				SteamUserStats.SetStat(name, value);
			}
		}

		public override void UpdateIntStat(string name, int value)
		{
			int num;
			SteamUserStats.GetStat(name, out num);
			if (num < value)
			{
				SteamUserStats.SetStat(name, value);
			}
		}
	}
}