using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIScrollbar : UIElement
	{
		private float _viewPosition;

		private float _viewSize = 1f;

		private float _maxViewSize = 20f;

		private bool _isDragging;

		private bool _isHoveringOverHandle;

		private float _dragYOffset;

		private Texture2D _texture;

		private Texture2D _innerTexture;

		public float ViewPosition
		{
			get
			{
				return this._viewPosition;
			}
			set
			{
				this._viewPosition = MathHelper.Clamp(value, 0f, this._maxViewSize - this._viewSize);
			}
		}

		public UIScrollbar()
		{
			this.Width.Set(20f, 0f);
			this.MaxWidth.Set(20f, 0f);
			this._texture = TextureManager.Load("Images/UI/Scrollbar");
			this._innerTexture = TextureManager.Load("Images/UI/ScrollbarInner");
			this.PaddingTop = 5f;
			this.PaddingBottom = 5f;
		}

		private void DrawBar(SpriteBatch spriteBatch, Texture2D texture, Rectangle dimensions, Color color)
		{
			spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y - 6, dimensions.Width, 6), new Rectangle?(new Rectangle(0, 0, texture.Width, 6)), color);
			spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y, dimensions.Width, dimensions.Height), new Rectangle?(new Rectangle(0, 9, texture.Width, 2)), color);
			spriteBatch.Draw(texture, new Rectangle(dimensions.X, dimensions.Y + dimensions.Height, dimensions.Width, 6), new Rectangle?(new Rectangle(0, texture.Height - 6, texture.Width, 6)), color);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			if (this._isDragging)
			{
				float y = UserInterface.ActiveInstance.MousePosition.Y - innerDimensions.Y - this._dragYOffset;
				this._viewPosition = MathHelper.Clamp(y / innerDimensions.Height * this._maxViewSize, 0f, this._maxViewSize - this._viewSize);
			}
			Rectangle handleRectangle = this.GetHandleRectangle();
			Vector2 mousePosition = UserInterface.ActiveInstance.MousePosition;
			bool flag = this._isHoveringOverHandle;
			this._isHoveringOverHandle = handleRectangle.Contains(new Point((int)mousePosition.X, (int)mousePosition.Y));
			if (!flag && this._isHoveringOverHandle && Main.hasFocus)
			{
				Main.PlaySound(12, -1, -1, 1);
			}
			this.DrawBar(spriteBatch, this._texture, dimensions.ToRectangle(), Color.White);
			this.DrawBar(spriteBatch, this._innerTexture, handleRectangle, Color.White * (this._isDragging || this._isHoveringOverHandle ? 1f : 0.85f));
		}

		private Rectangle GetHandleRectangle()
		{
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			return new Rectangle((int)innerDimensions.X, (int)(innerDimensions.Y + innerDimensions.Height * (this._viewPosition / this._maxViewSize)) - 3, 20, (int)(innerDimensions.Height * (this._viewSize / this._maxViewSize)) + 7);
		}

		public float GetValue()
		{
			return this._viewPosition;
		}

		public override void MouseDown(UIMouseEvent evt)
		{
			base.MouseDown(evt);
			if (evt.Target == this)
			{
				Rectangle handleRectangle = this.GetHandleRectangle();
				if (handleRectangle.Contains(new Point((int)evt.MousePosition.X, (int)evt.MousePosition.Y)))
				{
					this._isDragging = true;
					this._dragYOffset = evt.MousePosition.Y - (float)handleRectangle.Y;
					return;
				}
				CalculatedStyle innerDimensions = base.GetInnerDimensions();
				float y = UserInterface.ActiveInstance.MousePosition.Y - innerDimensions.Y - (float)(handleRectangle.Height >> 1);
				this._viewPosition = MathHelper.Clamp(y / innerDimensions.Height * this._maxViewSize, 0f, this._maxViewSize - this._viewSize);
			}
		}

		public override void MouseUp(UIMouseEvent evt)
		{
			base.MouseUp(evt);
			this._isDragging = false;
		}

		public void SetView(float viewSize, float maxViewSize)
		{
			viewSize = MathHelper.Clamp(viewSize, 0f, maxViewSize);
			this._viewPosition = MathHelper.Clamp(this._viewPosition, 0f, maxViewSize - viewSize);
			this._viewSize = viewSize;
			this._maxViewSize = maxViewSize;
		}
	}
}