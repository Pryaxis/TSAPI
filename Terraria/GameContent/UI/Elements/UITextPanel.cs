using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UITextPanel : UIPanel
	{
		private string _text = "";

		private float _textScale = 1f;

		private Vector2 _textSize = Vector2.Zero;

		private bool _isLarge;

		public UITextPanel(string text, float textScale = 1f, bool large = false)
		{
			this.SetText(text, textScale, large);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			Vector2 y = innerDimensions.Position();
			if (!this._isLarge)
			{
				y.Y = y.Y - 2f * this._textScale;
			}
			else
			{
				y.Y = y.Y - 10f * this._textScale;
			}
			y.X = y.X + (innerDimensions.Width - this._textSize.X) * 0.5f;
			if (this._isLarge)
			{
				Utils.DrawBorderStringBig(spriteBatch, this._text, y, Color.White, this._textScale, 0f, 0f, -1);
				return;
			}
			Utils.DrawBorderString(spriteBatch, this._text, y, Color.White, this._textScale, 0f, 0f, -1);
		}

		public override void Recalculate()
		{
			this.SetText(this._text, this._textScale, this._isLarge);
			base.Recalculate();
		}

		public void SetText(string text, float textScale, bool large)
		{
			Vector2 vector2 = new Vector2(((large ? Main.fontDeathText : Main.fontMouseText)).MeasureString(text).X, (large ? 32f : 16f)) * textScale;
			this._text = text;
			this._textScale = textScale;
			this._textSize = vector2;
			this._isLarge = large;
			this.MinWidth.Set(vector2.X + this.PaddingLeft + this.PaddingRight, 0f);
			this.MinHeight.Set(vector2.Y + this.PaddingTop + this.PaddingBottom, 0f);
		}
	}
}