using System;

namespace Terraria.Achievements
{
	public class ConditionIntTracker : AchievementTracker<int>
	{
		public ConditionIntTracker() : base(TrackerType.Int)
		{
		}

		public ConditionIntTracker(int maxValue) : base(TrackerType.Int)
		{
			this._maxValue = maxValue;
		}

		protected override void Load()
		{
		}

		public override void ReportUpdate()
		{
		}
	}
}