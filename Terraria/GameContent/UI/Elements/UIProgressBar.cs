using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIProgressBar : UIElement
	{
		private UIProgressBar.UIInnerProgressBar _progressBar = new UIProgressBar.UIInnerProgressBar();

		private float _visualProgress;

		private float _targetProgress;

		public UIProgressBar()
		{
			this._progressBar.Height.Precent = 1f;
			this._progressBar.Recalculate();
			base.Append(this._progressBar);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this._visualProgress = this._visualProgress * 0.95f + 0.05f * this._targetProgress;
			this._progressBar.Width.Precent = this._visualProgress;
			this._progressBar.Recalculate();
		}

		public void SetProgress(float value)
		{
			this._targetProgress = value;
			if (value < this._visualProgress)
			{
				this._visualProgress = value;
			}
		}

		private class UIInnerProgressBar : UIElement
		{
			public UIInnerProgressBar()
			{
			}

			protected override void DrawSelf(SpriteBatch spriteBatch)
			{
				CalculatedStyle dimensions = base.GetDimensions();
				Rectangle? nullable = null;
				spriteBatch.Draw(Main.magicPixel, new Vector2(dimensions.X, dimensions.Y), nullable, Color.Blue, 0f, Vector2.Zero, new Vector2(dimensions.Width, dimensions.Height / 1000f), SpriteEffects.None, 0f);
			}
		}
	}
}