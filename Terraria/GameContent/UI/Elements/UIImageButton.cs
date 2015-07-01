using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIImageButton : UIElement
	{
		private Texture2D _texture;

		private float _visibilityActive = 1f;

		private float _visibilityInactive = 0.4f;

		public UIImageButton(Texture2D texture)
		{
			this._texture = texture;
			this.Width.Set((float)this._texture.Width, 0f);
			this.Height.Set((float)this._texture.Height, 0f);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position(), Color.White * (base.IsMouseHovering ? this._visibilityActive : this._visibilityInactive));
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			Main.PlaySound(12, -1, -1, 1);
		}

		public void SetImage(Texture2D texture)
		{
			this._texture = texture;
			this.Width.Set((float)this._texture.Width, 0f);
			this.Height.Set((float)this._texture.Height, 0f);
		}

		public void SetVisibility(float whenActive, float whenInactive)
		{
			this._visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
			this._visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
		}
	}
}