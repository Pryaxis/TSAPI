using Microsoft.Xna.Framework;
using System;

namespace Terraria.UI.Chat
{
	public class ChatLine
	{
		public Color color = Color.White;

		public int showTime;

		public string text = "";

		public TextSnippet[] parsedText = new TextSnippet[0];

		public ChatLine()
		{
		}
	}
}