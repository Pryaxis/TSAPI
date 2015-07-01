using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIPanel : UIElement
	{
		private const int CORNER_SIZE = 12;

		private const int TEXTURE_PADDING = 3;

		private const int BAR_SIZE = 2;

		private static Texture2D _borderTexture;

		private static Texture2D _backgroundTexture;

		public Color BorderColor = Color.Black;

		public Color BackgroundColor = new Color(63, 82, 151) * 0.7f;

		public UIPanel()
		{
			if (UIPanel._borderTexture == null)
			{
				UIPanel._borderTexture = TextureManager.Load("Images/UI/PanelBorder");
			}
			if (UIPanel._backgroundTexture == null)
			{
				UIPanel._backgroundTexture = TextureManager.Load("Images/UI/PanelBackground");
			}
			base.SetPadding(12f);
		}

		private void DrawPanel(SpriteBatch spriteBatch, Texture2D texture, Color color)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			Point point = new Point((int)dimensions.X, (int)dimensions.Y);
			Point point1 = new Point((int)(dimensions.X + dimensions.Width) - 12, (int)(dimensions.Y + dimensions.Height) - 12);
			int num = (int)Math.Ceiling((double)dimensions.Width) - 24;
			int num1 = (int)Math.Ceiling((double)dimensions.Height) - 24;
			spriteBatch.Draw(texture, new Rectangle(point.X, point.Y, 12, 12), new Rectangle?(new Rectangle(0, 0, 12, 12)), color);
			spriteBatch.Draw(texture, new Rectangle(point1.X, point.Y, 12, 12), new Rectangle?(new Rectangle(20, 0, 12, 12)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X, point1.Y, 12, 12), new Rectangle?(new Rectangle(0, 20, 12, 12)), color);
			spriteBatch.Draw(texture, new Rectangle(point1.X, point1.Y, 12, 12), new Rectangle?(new Rectangle(20, 20, 12, 12)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + 12, point.Y, num, 12), new Rectangle?(new Rectangle(15, 0, 2, 12)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + 12, point1.Y, num, 12), new Rectangle?(new Rectangle(15, 20, 2, 12)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X, point.Y + 12, 12, num1), new Rectangle?(new Rectangle(0, 15, 12, 2)), color);
			spriteBatch.Draw(texture, new Rectangle(point1.X, point.Y + 12, 12, num1), new Rectangle?(new Rectangle(20, 15, 12, 2)), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + 12, point.Y + 12, num, num1), new Rectangle?(new Rectangle(15, 15, 2, 2)), color);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			this.DrawPanel(spriteBatch, UIPanel._backgroundTexture, this.BackgroundColor);
			this.DrawPanel(spriteBatch, UIPanel._borderTexture, this.BorderColor);
		}
	}
}