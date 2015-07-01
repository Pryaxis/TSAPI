using Microsoft.Xna.Framework;
using System;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	internal class NameTagHandler : ITagHandler
	{
		public NameTagHandler()
		{
		}

		public static string GenerateTag(string name)
		{
			string str = string.Concat("[n:", name.Replace("[", "\\[").Replace("]", "\\]"), "]");
			return str;
		}

		TextSnippet Terraria.UI.Chat.ITagHandler.Parse(string text, Color baseColor, string options)
		{
			TextSnippet textSnippet = new TextSnippet(string.Concat("<", text.Replace("\\[", "[").Replace("\\]", "]"), ">"), baseColor, 1f);
			return textSnippet;
		}
	}
}