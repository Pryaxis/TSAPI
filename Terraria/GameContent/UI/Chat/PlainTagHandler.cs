using Microsoft.Xna.Framework;
using System;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	public class PlainTagHandler : ITagHandler
	{
		public PlainTagHandler()
		{
		}

		TextSnippet Terraria.UI.Chat.ITagHandler.Parse(string text, Color baseColor, string options)
		{
			return new PlainTagHandler.PlainSnippet(text);
		}

		public class PlainSnippet : TextSnippet
		{
			public PlainSnippet(string text = "") : base(text)
			{
			}

			public PlainSnippet(string text, Color color, float scale = 1f) : base(text, color, scale)
			{
			}

			public override Color GetVisibleColor()
			{
				return this.Color;
			}
		}
	}
}