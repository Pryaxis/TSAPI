using System;
using Terraria.Social;
using Terraria.Social.Base;

namespace Terraria.Achievements
{
	public abstract class AchievementTracker<T> : IAchievementTracker
	{
		protected T _value;

		protected T _maxValue;

		protected string _name;

		private TrackerType _type;

		public T MaxValue
		{
			get
			{
				return this._maxValue;
			}
		}

		public T Value
		{
			get
			{
				return this._value;
			}
		}

		protected AchievementTracker(TrackerType type)
		{
			this._type = type;
		}

		protected abstract void Load();

		protected void OnComplete()
		{
			if (SocialAPI.Achievements != null)
			{
				SocialAPI.Achievements.StoreStats();
			}
		}

		public abstract void ReportUpdate();

		public void SetValue(T newValue, bool reportUpdate = true)
		{
			if (!newValue.Equals(this._value))
			{
				this._value = newValue;
				if (reportUpdate)
				{
					this.ReportUpdate();
					if (this._value.Equals(this._maxValue))
					{
						this.OnComplete();
					}
				}
			}
		}

		void Terraria.Achievements.IAchievementTracker.Clear()
		{
			this.SetValue(default(T), true);
		}

		TrackerType Terraria.Achievements.IAchievementTracker.GetTrackerType()
		{
			return this._type;
		}

		void Terraria.Achievements.IAchievementTracker.Load()
		{
			this.Load();
		}

		void Terraria.Achievements.IAchievementTracker.ReportAs(string name)
		{
			this._name = name;
		}
	}
}