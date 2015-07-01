using System;
using System.Collections.Generic;

namespace Terraria.Achievements
{
	public class ConditionsCompletedTracker : ConditionIntTracker
	{
		private List<AchievementCondition> _conditions = new List<AchievementCondition>();

		public ConditionsCompletedTracker()
		{
		}

		public void AddCondition(AchievementCondition condition)
		{
			ConditionsCompletedTracker conditionsCompletedTracker = this;
			conditionsCompletedTracker._maxValue = conditionsCompletedTracker._maxValue + 1;
			condition.OnComplete += new AchievementCondition.AchievementUpdate(this.OnConditionCompleted);
			this._conditions.Add(condition);
		}

		protected override void Load()
		{
			for (int i = 0; i < this._conditions.Count; i++)
			{
				if (this._conditions[i].IsCompleted)
				{
					ConditionsCompletedTracker conditionsCompletedTracker = this;
					conditionsCompletedTracker._value = conditionsCompletedTracker._value + 1;
				}
			}
		}

		private void OnConditionCompleted(AchievementCondition condition)
		{
			base.SetValue(Math.Min(this._value + 1, (int)this._maxValue), true);
		}
	}
}