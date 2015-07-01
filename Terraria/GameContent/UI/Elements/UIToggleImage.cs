using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIToggleImage : UIElement
	{
		private Texture2D _onTexture;

		private Texture2D _offTexture;

		private int _drawWidth;

		private int _drawHeight;

		private Point _onTextureOffset = Point.Zero;

		private Point _offTextureOffset = Point.Zero;

		private bool _isOn;

		public bool IsOn
		{
			get
			{
				return this._isOn;
			}
		}

		public UIToggleImage(Texture2D texture, int width, int height, Point onTextureOffset, Point offTextureOffset)
		{
			this._onTexture = texture;
			this._offTexture = texture;
			this._offTextureOffset = offTextureOffset;
			this._onTextureOffset = onTextureOffset;
			this._drawWidth = width;
			this._drawHeight = height;
			this.Width.Set((float)width, 0f);
			this.Height.Set((float)height, 0f);
		}

		public override void Click(UIMouseEvent evt)
		{
			this.Toggle();
			base.Click(evt);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			Texture2D texture2D;
			Point point;
			CalculatedStyle dimensions = base.GetDimensions();
			if (!this._isOn)
			{
				texture2D = this._offTexture;
				point = this._offTextureOffset;
			}
			else
			{
				texture2D = this._onTexture;
				point = this._onTextureOffset;
			}
			Color color = (base.IsMouseHovering ? Color.White : Color.Silver);
			spriteBatch.Draw(texture2D, new Rectangle((int)dimensions.X, (int)dimensions.Y, this._drawWidth, this._drawHeight), new Rectangle?(new Rectangle(point.X, point.Y, this._drawWidth, this._drawHeight)), color);
		}

		public void SetState(bool value)
		{
			this._isOn = value;
		}

		public void Toggle()
		{
			this._isOn = !this._isOn;
		}
	}
}