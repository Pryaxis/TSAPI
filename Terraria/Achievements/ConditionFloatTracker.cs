using System;

namespace Terraria.Achievements
{
	public class ConditionFloatTracker : AchievementTracker<float>
	{
		public ConditionFloatTracker(float maxValue) : base(TrackerType.Float)
		{
			this._maxValue = maxValue;
		}

		public ConditionFloatTracker() : base(TrackerType.Float)
		{
		}

		protected override void Load()
		{
		}

		public override void ReportUpdate()
		{
		}
	}
}