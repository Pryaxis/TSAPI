using System;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
	internal class CustomFlagCondition : AchievementCondition
	{
		private CustomFlagCondition(string name) : base(name)
		{
		}

		public static AchievementCondition Create(string name)
		{
			return new CustomFlagCondition(name);
		}
	}
}