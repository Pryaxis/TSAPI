using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.GameContent.Events
{
	internal class ScreenObstruction
	{
		public static float screenObstruction;

		static ScreenObstruction()
		{
		}

		public ScreenObstruction()
		{
		}

		public static void Draw(SpriteBatch spriteBatch)
		{
			if (ScreenObstruction.screenObstruction == 0f)
			{
				return;
			}
			Color black = Color.Black * ScreenObstruction.screenObstruction;
			int width = Main.extraTexture[49].Width;
			int num = 10;
			Rectangle rect = Main.player[Main.myPlayer].getRect();
			rect.Inflate((width - rect.Width) / 2, (width - rect.Height) / 2 + num / 2);
			rect.Offset(-(int)Main.screenPosition.X, -(int)Main.screenPosition.Y + (int)Main.player[Main.myPlayer].gfxOffY - num);
			Rectangle rectangle = Rectangle.Union(new Rectangle(0, 0, 1, 1), new Rectangle(rect.Right - 1, rect.Top - 1, 1, 1));
			Rectangle rectangle1 = Rectangle.Union(new Rectangle(Main.screenWidth - 1, 0, 1, 1), new Rectangle(rect.Right, rect.Bottom - 1, 1, 1));
			Rectangle rectangle2 = Rectangle.Union(new Rectangle(Main.screenWidth - 1, Main.screenHeight - 1, 1, 1), new Rectangle(rect.Left, rect.Bottom, 1, 1));
			Rectangle rectangle3 = Rectangle.Union(new Rectangle(0, Main.screenHeight - 1, 1, 1), new Rectangle(rect.Left - 1, rect.Top, 1, 1));
			spriteBatch.Draw(Main.magicPixel, rectangle, new Rectangle?(new Rectangle(0, 0, 1, 1)), black);
			spriteBatch.Draw(Main.magicPixel, rectangle1, new Rectangle?(new Rectangle(0, 0, 1, 1)), black);
			spriteBatch.Draw(Main.magicPixel, rectangle2, new Rectangle?(new Rectangle(0, 0, 1, 1)), black);
			spriteBatch.Draw(Main.magicPixel, rectangle3, new Rectangle?(new Rectangle(0, 0, 1, 1)), black);
			spriteBatch.Draw(Main.extraTexture[49], rect, black);
		}

		public static void Update()
		{
			float single = 0f;
			float single1 = 0.1f;
			if (Main.player[Main.myPlayer].headcovered)
			{
				single = 0.95f;
				single1 = 0.3f;
			}
			ScreenObstruction.screenObstruction = MathHelper.Lerp(ScreenObstruction.screenObstruction, single, single1);
		}
	}
}