using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Achievements;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	internal class AchievementTagHandler : ITagHandler
	{
		public AchievementTagHandler()
		{
		}

		public static string GenerateTag(Achievement achievement)
		{
			return string.Concat("[a:", achievement.Name, "]");
		}

		TextSnippet Terraria.UI.Chat.ITagHandler.Parse(string text, Color baseColor, string options)
		{
			Achievement achievement = Main.Achievements.GetAchievement(text);
			if (achievement == null)
			{
				return new TextSnippet(text);
			}
			return new AchievementTagHandler.AchievementSnippet(achievement);
		}

		private class AchievementSnippet : TextSnippet
		{
			private Achievement _achievement;

			public AchievementSnippet(Achievement achievement) : base(achievement.FriendlyName, Color.LightBlue, 1f)
			{
				this.CheckForHover = true;
				this._achievement = achievement;
			}

			public override void OnClick()
			{
				IngameOptions.Close();
				AchievementsUI.OpenAndGoto(this._achievement);
			}
		}
	}
}