using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIImageFramed : UIElement
	{
		private Texture2D _texture;

		private Rectangle _frame;

		public UIImageFramed(Texture2D texture, Rectangle frame)
		{
			this._texture = texture;
			this._frame = frame;
			this.Width.Set((float)this._frame.Width, 0f);
			this.Height.Set((float)this._frame.Height, 0f);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position(), new Rectangle?(this._frame), Color.White);
		}

		public void SetFrame(Rectangle frame)
		{
			this._frame = frame;
			this.Width.Set((float)this._frame.Width, 0f);
			this.Height.Set((float)this._frame.Height, 0f);
		}

		public void SetImage(Texture2D texture, Rectangle frame)
		{
			this._texture = texture;
			this._frame = frame;
			this.Width.Set((float)this._frame.Width, 0f);
			this.Height.Set((float)this._frame.Height, 0f);
		}
	}
}