using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.Achievements
{
	public class Achievement
	{
		private static int _totalAchievements;

		public readonly string Name;

		public readonly string FriendlyName;

		public readonly string Description;

		public readonly int Id;

		private AchievementCategory _category;

		private IAchievementTracker _tracker;

		private Dictionary<string, AchievementCondition> _conditions;

		private int _completedCount;

		public AchievementCategory Category
		{
			get
			{
				return this._category;
			}
		}

		public bool HasTracker
		{
			get
			{
				return this._tracker != null;
			}
		}

		public bool IsCompleted
		{
			get
			{
				return this._completedCount == this._conditions.Count;
			}
		}

		static Achievement()
		{
		}

		public Achievement(string name, string friendlyName, string description)
		{
			int num = Achievement._totalAchievements;
			Achievement._totalAchievements = num + 1;
			this.Id = num;
			this._conditions = new Dictionary<string, AchievementCondition>();
			this.Name = name;
			this.FriendlyName = friendlyName;
			this.Description = description;
		}

		public void AddCondition(AchievementCondition condition)
		{
			this._conditions[condition.Name] = condition;
			condition.OnComplete += new AchievementCondition.AchievementUpdate(this.OnConditionComplete);
		}

		public void AddConditions(params AchievementCondition[] conditions)
		{
			for (int i = 0; i < (int)conditions.Length; i++)
			{
				this.AddCondition(conditions[i]);
			}
		}

		public void ClearProgress()
		{
			this._completedCount = 0;
			foreach (KeyValuePair<string, AchievementCondition> _condition in this._conditions)
			{
				_condition.Value.Clear();
			}
			if (this._tracker != null)
			{
				this._tracker.Clear();
			}
		}

		public void ClearTracker()
		{
			this._tracker = null;
		}

		public AchievementCondition GetCondition(string conditionName)
		{
			AchievementCondition achievementCondition;
			if (this._conditions.TryGetValue(conditionName, out achievementCondition))
			{
				return achievementCondition;
			}
			return null;
		}

		private IAchievementTracker GetConditionTracker(string name)
		{
			return this._conditions[name].GetAchievementTracker();
		}

		public IAchievementTracker GetTracker()
		{
			return this._tracker;
		}

		private void OnConditionComplete(AchievementCondition condition)
		{
			Achievement achievement = this;
			achievement._completedCount = achievement._completedCount + 1;
			if (this._completedCount == this._conditions.Count)
			{
				if (this.OnCompleted != null)
				{
					this.OnCompleted(this);
				}
			}
		}

		public void SetCategory(AchievementCategory category)
		{
			this._category = category;
		}

		public void UseConditionsCompletedTracker()
		{
			ConditionsCompletedTracker conditionsCompletedTracker = new ConditionsCompletedTracker();
			foreach (KeyValuePair<string, AchievementCondition> _condition in this._conditions)
			{
				conditionsCompletedTracker.AddCondition(_condition.Value);
			}
			this.UseTracker(conditionsCompletedTracker);
		}

		public void UseConditionsCompletedTracker(params string[] conditions)
		{
			ConditionsCompletedTracker conditionsCompletedTracker = new ConditionsCompletedTracker();
			for (int i = 0; i < (int)conditions.Length; i++)
			{
				string str = conditions[i];
				conditionsCompletedTracker.AddCondition(this._conditions[str]);
			}
			this.UseTracker(conditionsCompletedTracker);
		}

		private void UseTracker(IAchievementTracker tracker)
		{
			tracker.ReportAs(string.Concat("STAT_", this.Name));
			this._tracker = tracker;
		}

		public void UseTrackerFromCondition(string conditionName)
		{
			this.UseTracker(this.GetConditionTracker(conditionName));
		}

		public event Achievement.AchievementCompleted OnCompleted;

		public delegate void AchievementCompleted(Achievement achievement);
	}
}