using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Terraria;
using Terraria.Utilities;

namespace Terraria.Achievements
{
	public class AchievementManager
	{

		private Dictionary<string, Achievement> _achievements = new Dictionary<string, Achievement>();

		private Dictionary<string, int> _achievementIconIndexes = new Dictionary<string, int>();

		private static object _ioLock;

		static AchievementManager()
		{
			AchievementManager._ioLock = new object();
		}

		public AchievementManager()
		{
		}

		private void AchievementCompleted(Achievement achievement)
		{
			this.Save();
			if (this.OnAchievementCompleted != null)
			{
				this.OnAchievementCompleted(achievement);
			}
		}

		public List<Achievement> CreateAchievementsList()
		{
			return this._achievements.Values.ToList<Achievement>();
		}

		public Achievement GetAchievement(string achievementName)
		{
			Achievement achievement;
			if (this._achievements.TryGetValue(achievementName, out achievement))
			{
				return achievement;
			}
			return null;
		}

		public T GetCondition<T>(string achievementName, string conditionName)
		where T : AchievementCondition
		{
			return (T)(this.GetCondition(achievementName, conditionName) as T);
		}

		public AchievementCondition GetCondition(string achievementName, string conditionName)
		{
			Achievement achievement;
			if (!this._achievements.TryGetValue(achievementName, out achievement))
			{
				return null;
			}
			return achievement.GetCondition(conditionName);
		}

		public int GetIconIndex(string achievementName)
		{
			int num;
			if (this._achievementIconIndexes.TryGetValue(achievementName, out num))
			{
				return num;
			}
			return 0;
		}

		public void Load()
		{
			
		}

		public void Register(Achievement achievement)
		{
			this._achievements.Add(achievement.Name, achievement);
			achievement.OnCompleted += new Achievement.AchievementCompleted(this.AchievementCompleted);
		}

		public void RegisterAchievementCategory(string achievementName, AchievementCategory category)
		{
			this._achievements[achievementName].SetCategory(category);
		}

		public void RegisterIconIndex(string achievementName, int iconIndex)
		{
			this._achievementIconIndexes.Add(achievementName, iconIndex);
		}

		public void Save()
		{
			
		}

		public event Achievement.AchievementCompleted OnAchievementCompleted;
	}
}