using System;
using Terraria.GameContent.UI.Chat;
using Terraria.UI.Chat;

namespace Terraria.Initializers
{
	internal static class ChatInitializer
	{
		public static void Load()
		{
			ChatManager.Register<ColorTagHandler>(new string[] { "c", "color" });
			ChatManager.Register<ItemTagHandler>(new string[] { "i", "item" });
			ChatManager.Register<NameTagHandler>(new string[] { "n", "name" });
			ChatManager.Register<AchievementTagHandler>(new string[] { "a", "achievement" });
		}
	}
}