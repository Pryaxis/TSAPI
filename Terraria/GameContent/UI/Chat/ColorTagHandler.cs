using Microsoft.Xna.Framework;
using System;
using System.Globalization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	internal class ColorTagHandler : ITagHandler
	{
		public ColorTagHandler()
		{
		}

		TextSnippet Terraria.UI.Chat.ITagHandler.Parse(string text, Color baseColor, string options)
		{
			int num;
			TextSnippet textSnippet = new TextSnippet(text);
			if (!int.TryParse(options, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out num))
			{
				return textSnippet;
			}
			textSnippet.Color = new Color(num >> 16 & 255, num >> 8 & 255, num & 255);
			return textSnippet;
		}
	}
}