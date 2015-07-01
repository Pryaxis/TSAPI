using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Achievements;
using Terraria.GameContent.UI.States;

namespace Terraria.UI
{
	public class AchievementsUI
	{
		public AchievementsUI()
		{
		}

		public static void Close()
		{
			Main.achievementsWindow = false;
			Main.PlaySound(11, -1, -1, 1);
			if (!Main.gameMenu)
			{
				Main.playerInventory = true;
			}
			Main.InGameUI.SetState(null);
		}

		public static void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			if (!Main.gameMenu && Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
			{
				AchievementsUI.Close();
				Main.playerInventory = false;
				return;
			}
			if (!Main.gameMenu)
			{
				Main.mouseText = false;
				Main.instance.GUIBarsDraw();
				if (!Main.achievementsWindow)
				{
					Main.InGameUI.SetState(null);
				}
				Main.instance.DrawMouseOver();
				Texture2D texture2D = Main.cursorTextures[0];
				Vector2 vector2 = new Vector2((float)(Main.mouseX + 1), (float)(Main.mouseY + 1));
				Rectangle? nullable = null;
				Color color = new Color((int)((float)Main.cursorColor.R * 0.2f), (int)((float)Main.cursorColor.G * 0.2f), (int)((float)Main.cursorColor.B * 0.2f), (int)((float)Main.cursorColor.A * 0.5f));
				Vector2 vector21 = new Vector2();
				spriteBatch.Draw(texture2D, vector2, nullable, color, 0f, vector21, Main.cursorScale * 1.1f, SpriteEffects.None, 0f);
				Texture2D texture2D1 = Main.cursorTextures[0];
				Vector2 vector22 = new Vector2((float)Main.mouseX, (float)Main.mouseY);
				Rectangle? nullable1 = null;
				Color color1 = Main.cursorColor;
				Vector2 vector23 = new Vector2();
				spriteBatch.Draw(texture2D1, vector22, nullable1, color1, 0f, vector23, Main.cursorScale, SpriteEffects.None, 0f);
			}
		}

		public static void MouseOver()
		{
			if (!Main.achievementsWindow)
			{
				return;
			}
			if (Main.InGameUI.IsElementUnderMouse())
			{
				Main.mouseText = true;
			}
		}

		public static void Open()
		{
			Main.playerInventory = false;
			Main.editChest = false;
			Main.npcChatText = "";
			Main.achievementsWindow = true;
			Main.InGameUI.SetState(Main.AchievementsMenu);
		}

		public static void OpenAndGoto(Achievement achievement)
		{
			AchievementsUI.Open();
			Main.AchievementsMenu.GotoAchievement(achievement);
		}
	}
}