using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace Terraria.GameContent.Events
{
	internal class ScreenDarkness
	{
		public static float screenObstruction;

		static ScreenDarkness()
		{
		}

		public ScreenDarkness()
		{
		}

		public static void DrawBack(SpriteBatch spriteBatch)
		{
			if (ScreenDarkness.screenObstruction == 0f)
			{
				return;
			}
			Color black = Color.Black * ScreenDarkness.screenObstruction;
			spriteBatch.Draw(Main.magicPixel, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), black);
		}

		public static void DrawFront(SpriteBatch spriteBatch)
		{
			if (ScreenDarkness.screenObstruction == 0f)
			{
				return;
			}
			Color color = (new Color(0, 0, 120) * ScreenDarkness.screenObstruction) * 0.3f;
			spriteBatch.Draw(Main.magicPixel, new Rectangle(-2, -2, Main.screenWidth + 4, Main.screenHeight + 4), new Rectangle?(new Rectangle(0, 0, 1, 1)), color);
		}

		public static void Update()
		{
			float single = 0f;
			float single1 = 0.1f;
			Vector2 mountedCenter = Main.player[Main.myPlayer].MountedCenter;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active && Main.npc[i].type == 370 && Main.npc[i].Distance(mountedCenter) < 3000f && (Main.npc[i].ai[0] >= 10f || Main.npc[i].ai[0] == 9f && Main.npc[i].ai[2] > 120f))
				{
					single = 0.95f;
					single1 = 0.03f;
				}
			}
			ScreenDarkness.screenObstruction = MathHelper.Lerp(ScreenDarkness.screenObstruction, single, single1);
		}
	}
}