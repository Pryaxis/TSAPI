using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Terraria;
using Terraria.Social;
using Terraria.Social.Base;
using Terraria.Utilities;

namespace Terraria.Achievements
{
	public class AchievementManager
	{
		private string _savePath;

		private Dictionary<string, Achievement> _achievements = new Dictionary<string, Achievement>();

		private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();

		private ICryptoTransform _encryptor;

		private ICryptoTransform _decryptor;

		private Dictionary<string, int> _achievementIconIndexes = new Dictionary<string, int>();

		private static object _ioLock;

		static AchievementManager()
		{
			AchievementManager._ioLock = new object();
		}

		public AchievementManager()
		{
			byte[] bytes;
			if (SocialAPI.Achievements == null)
			{
				this._savePath = string.Concat(Main.SavePath, Path.DirectorySeparatorChar, "achievements.dat");
				bytes = Encoding.ASCII.GetBytes("RELOGIC-TERRARIA");
			}
			else
			{
				this._savePath = SocialAPI.Achievements.GetSavePath();
				bytes = SocialAPI.Achievements.GetEncryptionKey();
			}
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			this._encryptor = rijndaelManaged.CreateEncryptor(bytes, bytes);
			rijndaelManaged.Padding = PaddingMode.None;
			this._decryptor = rijndaelManaged.CreateDecryptor(bytes, bytes);
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
			this.Load(this._savePath, false);
		}

		private void Load(string path, bool cloud)
		{
			bool flag = false;
			lock (AchievementManager._ioLock)
			{
				if (FileUtilities.Exists(path, cloud))
				{
					byte[] numArray = FileUtilities.ReadAllBytes(path, cloud);
					Dictionary<string, AchievementManager.StoredAchievement> strs = null;
					try
					{
						using (MemoryStream memoryStream = new MemoryStream(numArray))
						{
							using (CryptoStream cryptoStream = new CryptoStream(memoryStream, this._decryptor, CryptoStreamMode.Read))
							{
								using (BsonReader bsonReader = new BsonReader(cryptoStream))
								{
									strs = JsonSerializer.Create(this._serializerSettings).Deserialize<Dictionary<string, AchievementManager.StoredAchievement>>(bsonReader);
								}
							}
						}
					}
					catch (Exception)
					{
						FileUtilities.Delete(path, cloud);
						return;
					}
					if (strs != null)
					{
						foreach (KeyValuePair<string, AchievementManager.StoredAchievement> keyValuePair in strs)
						{
							if (!this._achievements.ContainsKey(keyValuePair.Key))
							{
								continue;
							}
							this._achievements[keyValuePair.Key].Load(keyValuePair.Value.Conditions);
						}
						if (SocialAPI.Achievements != null)
						{
							foreach (KeyValuePair<string, Achievement> _achievement in this._achievements)
							{
								if (!_achievement.Value.IsCompleted || SocialAPI.Achievements.IsAchievementCompleted(_achievement.Key))
								{
									continue;
								}
								flag = true;
								_achievement.Value.ClearProgress();
							}
						}
					}
					else
					{
						return;
					}
				}
				else
				{
					return;
				}
			}
			if (flag)
			{
				this.Save();
			}
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
			this.Save(this._savePath, false);
		}

		private void Save(string path, bool cloud)
		{
			lock (AchievementManager._ioLock)
			{
				if (SocialAPI.Achievements != null)
				{
					SocialAPI.Achievements.StoreStats();
				}
				try
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, this._encryptor, CryptoStreamMode.Write))
						{
							using (BsonWriter bsonWriter = new BsonWriter(cryptoStream))
							{
								JsonSerializer.Create(this._serializerSettings).Serialize(bsonWriter, this._achievements);
								bsonWriter.Flush();
								cryptoStream.FlushFinalBlock();
								FileUtilities.Write(path, memoryStream.GetBuffer(), (int)memoryStream.Length, cloud);
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
			}
		}

		public event Achievement.AchievementCompleted OnAchievementCompleted;

		private class StoredAchievement
		{
			public Dictionary<string, JObject> Conditions;

			public StoredAchievement()
			{
			}
		}
	}
}