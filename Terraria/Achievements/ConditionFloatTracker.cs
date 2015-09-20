using System;
using Terraria.Social;
using Terraria.Social.Base;

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
			if (SocialAPI.Achievements != null && this._name != null)
			{
				SocialAPI.Achievements.UpdateFloatStat(this._name, this._value);
			}
		}
	}
}