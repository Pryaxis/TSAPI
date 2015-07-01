using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Achievements;
using Terraria.Graphics;

namespace Terraria.UI
{
	public class AchievementCompleteUI
	{
		private static Texture2D AchievementsTexture;

		private static Texture2D AchievementsTextureBorder;

		private static List<AchievementCompleteUI.DrawCache> caches;

		static AchievementCompleteUI()
		{
			AchievementCompleteUI.caches = new List<AchievementCompleteUI.DrawCache>();
		}

		public AchievementCompleteUI()
		{
		}

		public static void AddCompleted(Achievement achievement)
		{
			if (Main.netMode == 2)
			{
				return;
			}
			AchievementCompleteUI.caches.Add(new AchievementCompleteUI.DrawCache(achievement));
		}

		public static void Clear()
		{
			AchievementCompleteUI.caches.Clear();
		}

		public static void Draw(SpriteBatch sb)
		{
			Vector2 vector2 = new Vector2((float)(Main.screenWidth / 2), (float)(Main.screenHeight - 40));
			foreach (AchievementCompleteUI.DrawCache cach in AchievementCompleteUI.caches)
			{
				AchievementCompleteUI.DrawAchievement(sb, ref vector2, cach);
				if (vector2.Y >= -100f)
				{
					continue;
				}
				return;
			}
		}

		private static void DrawAchievement(SpriteBatch sb, ref Vector2 center, AchievementCompleteUI.DrawCache ach)
		{
			float alpha = ach.Alpha;
			if (alpha > 0f)
			{
				string title = ach.Title;
				Vector2 vector2 = center;
				Vector2 vector21 = Main.fontItemStack.MeasureString(title);
				float scale = ach.Scale * 1.1f;
				Rectangle rectangle = Utils.CenteredRectangle(vector2, (vector21 + new Vector2(58f, 10f)) * scale);
				Vector2 mouseScreen = Main.MouseScreen;
				bool flag = rectangle.Contains(mouseScreen.ToPoint());
				Utils.DrawInvBG(sb, rectangle, (flag ? new Color(64, 109, 164) * 0.75f : new Color(64, 109, 164) * 0.5f));
				float single = scale * 0.3f;
				Color color = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, Main.mouseTextColor / 5, (int)Main.mouseTextColor);
				Vector2 vector22 = rectangle.Right() - ((Vector2.UnitX * scale) * (12f + single * (float)ach.Frame.Width));
				sb.Draw(AchievementCompleteUI.AchievementsTexture, vector22, new Rectangle?(ach.Frame), Color.White * alpha, 0f, new Vector2(0f, (float)(ach.Frame.Height / 2)), single, SpriteEffects.None, 0f);
				Rectangle? nullable = null;
				sb.Draw(AchievementCompleteUI.AchievementsTextureBorder, vector22, nullable, Color.White * alpha, 0f, new Vector2(0f, (float)(ach.Frame.Height / 2)), single, SpriteEffects.None, 0f);
				Utils.DrawBorderString(sb, title, vector22 - (Vector2.UnitX * 10f), color * alpha, scale * 0.9f, 1f, 0.4f, -1);
				if (flag)
				{
					Main.player[Main.myPlayer].mouseInterface = true;
					if (Main.mouseLeft && Main.mouseLeftRelease)
					{
						AchievementsUI.OpenAndGoto(ach.theAchievement);
						ach.TimeLeft = 0;
					}
				}
			}
			ach.ApplyHeight(ref center);
		}

		public static void Initialize()
		{
			Main.Achievements.OnAchievementCompleted += new Achievement.AchievementCompleted(AchievementCompleteUI.AddCompleted);
		}

		public static void LoadContent()
		{
			AchievementCompleteUI.AchievementsTexture = TextureManager.Load("Images/UI/Achievements");
			AchievementCompleteUI.AchievementsTextureBorder = TextureManager.Load("Images/UI/Achievement_Borders");
		}

		public static void Update()
		{
			foreach (AchievementCompleteUI.DrawCache cach in AchievementCompleteUI.caches)
			{
				cach.Update();
			}
			for (int i = 0; i < AchievementCompleteUI.caches.Count; i++)
			{
				if (AchievementCompleteUI.caches[i].TimeLeft == 0)
				{
					AchievementCompleteUI.caches.Remove(AchievementCompleteUI.caches[i]);
					i--;
				}
			}
		}

		private class DrawCache
		{
			private const int _iconSize = 64;

			private const int _iconSizeWithSpace = 66;

			private const int _iconsPerRow = 8;

			public Achievement theAchievement;

			public int IconIndex;

			public Rectangle Frame;

			public string Title;

			public int TimeLeft;

			public float Alpha
			{
				get
				{
					float scale = this.Scale;
					if (scale <= 0.5f)
					{
						return 0f;
					}
					return (scale - 0.5f) / 0.5f;
				}
			}

			public float Scale
			{
				get
				{
					if (this.TimeLeft < 30)
					{
						return MathHelper.Lerp(0f, 1f, (float)this.TimeLeft / 30f);
					}
					if (this.TimeLeft <= 285)
					{
						return 1f;
					}
					return MathHelper.Lerp(1f, 0f, ((float)this.TimeLeft - 285f) / 15f);
				}
			}

			public DrawCache(Achievement achievement)
			{
				this.theAchievement = achievement;
				this.Title = achievement.FriendlyName;
				int iconIndex = Main.Achievements.GetIconIndex(achievement.Name);
				this.IconIndex = iconIndex;
				this.Frame = new Rectangle(iconIndex % 8 * 66, iconIndex / 8 * 66, 64, 64);
				this.TimeLeft = 300;
			}

			public void ApplyHeight(ref Vector2 v)
			{
				v.Y = v.Y - 50f * this.Alpha;
			}

			public void Update()
			{
				AchievementCompleteUI.DrawCache timeLeft = this;
				timeLeft.TimeLeft = timeLeft.TimeLeft - 1;
				if (this.TimeLeft < 0)
				{
					this.TimeLeft = 0;
				}
			}
		}
	}
}