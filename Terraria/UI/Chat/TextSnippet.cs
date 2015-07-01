using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria.UI.Chat
{
	public class TextSnippet
	{
		public string Text;

		public string TextOriginal;

		public Microsoft.Xna.Framework.Color Color = Microsoft.Xna.Framework.Color.White;

		public float Scale = 1f;

		public bool CheckForHover;

		public bool DeleteWhole;

		public TextSnippet(string text = "")
		{
			this.Text = text;
			this.TextOriginal = text;
		}

		public TextSnippet(string text, Microsoft.Xna.Framework.Color color, float scale = 1f)
		{
			this.Text = text;
			this.TextOriginal = text;
			this.Color = color;
			this.Scale = scale;
		}

		public virtual Microsoft.Xna.Framework.Color GetVisibleColor()
		{
			return ChatManager.WaveColor(this.Color);
		}

		public virtual void OnClick()
		{
		}

		public virtual void OnHover()
		{
		}

		public virtual bool UniqueDraw(bool justCheckingString, out Vector2 size, SpriteBatch spriteBatch, Vector2 position = new Vector2(), Microsoft.Xna.Framework.Color color = new Color(), float scale = 1f)
		{
			size = Vector2.Zero;
			return false;
		}

		public virtual void Update()
		{
		}
	}
}