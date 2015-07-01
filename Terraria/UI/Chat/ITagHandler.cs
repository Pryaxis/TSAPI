using Microsoft.Xna.Framework;
using System;

namespace Terraria.UI.Chat
{
	public interface ITagHandler
	{
		TextSnippet Parse(string text, Color baseColor = new Color(), string options = null);
	}
}