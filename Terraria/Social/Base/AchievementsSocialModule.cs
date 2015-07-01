using System;
using Terraria.Social;

namespace Terraria.Social.Base
{
	public abstract class AchievementsSocialModule : ISocialModule
	{
		protected AchievementsSocialModule()
		{
		}

		public abstract void CompleteAchievement(string name);

		public abstract byte[] GetEncryptionKey();

		public abstract string GetSavePath();

		public abstract void Initialize();

		public abstract bool IsAchievementCompleted(string name);

		public abstract void Shutdown();

		public abstract void StoreStats();

		public abstract void UpdateFloatStat(string name, float value);

		public abstract void UpdateIntStat(string name, int value);
	}
}