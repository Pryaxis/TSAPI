using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Achievements;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIAchievementListItem : UIPanel
	{
		private const int _iconSize = 64;

		private const int _iconSizeWithSpace = 66;

		private const int _iconsPerRow = 8;

		private Achievement _achievement;

		private UIImageFramed _achievementIcon;

		private UIImage _achievementIconBorders;

		private int _iconIndex;

		private Rectangle _iconFrame;

		private Rectangle _iconFrameUnlocked;

		private Rectangle _iconFrameLocked;

		private Texture2D _innerPanelTopTexture;

		private Texture2D _innerPanelBottomTexture;

		private Texture2D _categoryTexture;

		private bool _locked;

		public UIAchievementListItem(Achievement achievement)
		{
			this.BackgroundColor = new Color(26, 40, 89) * 0.8f;
			this.BorderColor = new Color(13, 20, 44) * 0.8f;
			this._achievement = achievement;
			this.Height.Set(82f, 0f);
			this.Width.Set(0f, 1f);
			this.PaddingTop = 8f;
			this.PaddingLeft = 9f;
			int iconIndex = Main.Achievements.GetIconIndex(achievement.Name);
			this._iconIndex = iconIndex;
			this._iconFrameUnlocked = new Rectangle(iconIndex % 8 * 66, iconIndex / 8 * 66, 64, 64);
			this._iconFrameLocked = this._iconFrameUnlocked;
			this._iconFrameLocked.X = this._iconFrameLocked.X + 528;
			this._iconFrame = this._iconFrameLocked;
			this.UpdateIconFrame();
			this._achievementIcon = new UIImageFramed(TextureManager.Load("Images/UI/Achievements"), this._iconFrame);
			base.Append(this._achievementIcon);
			this._achievementIconBorders = new UIImage(TextureManager.Load("Images/UI/Achievement_Borders"));
			this._achievementIconBorders.Left.Set(-4f, 0f);
			this._achievementIconBorders.Top.Set(-4f, 0f);
			base.Append(this._achievementIconBorders);
			this._innerPanelTopTexture = TextureManager.Load("Images/UI/Achievement_InnerPanelTop");
			this._innerPanelBottomTexture = TextureManager.Load("Images/UI/Achievement_InnerPanelBottom");
			this._categoryTexture = TextureManager.Load("Images/UI/Achievement_Categories");
		}

		public override int CompareTo(object obj)
		{
			UIAchievementListItem uIAchievementListItem = obj as UIAchievementListItem;
			if (uIAchievementListItem == null)
			{
				return 0;
			}
			if (this._achievement.IsCompleted && !uIAchievementListItem._achievement.IsCompleted)
			{
				return -1;
			}
			if (!this._achievement.IsCompleted && uIAchievementListItem._achievement.IsCompleted)
			{
				return 1;
			}
			return this._achievement.Id.CompareTo(uIAchievementListItem._achievement.Id);
		}

		private void DrawPanelBottom(SpriteBatch spriteBatch, Vector2 position, float width, Color color)
		{
			spriteBatch.Draw(this._innerPanelBottomTexture, position, new Rectangle?(new Rectangle(0, 0, 6, this._innerPanelBottomTexture.Height)), color);
			spriteBatch.Draw(this._innerPanelBottomTexture, new Vector2(position.X + 6f, position.Y), new Rectangle?(new Rectangle(6, 0, 7, this._innerPanelBottomTexture.Height)), color, 0f, Vector2.Zero, new Vector2((width - 12f) / 7f, 1f), SpriteEffects.None, 0f);
			spriteBatch.Draw(this._innerPanelBottomTexture, new Vector2(position.X + width - 6f, position.Y), new Rectangle?(new Rectangle(13, 0, 6, this._innerPanelBottomTexture.Height)), color);
		}

		private void DrawPanelTop(SpriteBatch spriteBatch, Vector2 position, float width, Color color)
		{
			spriteBatch.Draw(this._innerPanelTopTexture, position, new Rectangle?(new Rectangle(0, 0, 2, this._innerPanelTopTexture.Height)), color);
			spriteBatch.Draw(this._innerPanelTopTexture, new Vector2(position.X + 2f, position.Y), new Rectangle?(new Rectangle(2, 0, 2, this._innerPanelTopTexture.Height)), color, 0f, Vector2.Zero, new Vector2((width - 4f) / 2f, 1f), SpriteEffects.None, 0f);
			spriteBatch.Draw(this._innerPanelTopTexture, new Vector2(position.X + width - 2f, position.Y), new Rectangle?(new Rectangle(4, 0, 2, this._innerPanelTopTexture.Height)), color);
		}

		private void DrawProgressBar(SpriteBatch spriteBatch, float progress, Vector2 spot, float Width = 169f, Color BackColor = new Color(), Color FillingColor = new Color(), Color BlipColor = new Color())
		{
			if (BlipColor == Color.Transparent)
			{
				BlipColor = new Color(255, 165, 0, 127);
			}
			if (FillingColor == Color.Transparent)
			{
				FillingColor = new Color(255, 241, 51);
			}
			if (BackColor == Color.Transparent)
			{
				FillingColor = new Color(255, 255, 255);
			}
			Texture2D texture2D = Main.colorBarTexture;
			Texture2D texture2D1 = Main.colorBlipTexture;
			Texture2D texture2D2 = Main.magicPixel;
			float single = MathHelper.Clamp(progress, 0f, 1f);
			float width = Width * 1f;
			float single1 = 8f;
			float single2 = width / 169f;
			Vector2 unitX = (spot + (Vector2.UnitY * single1)) + (Vector2.UnitX * 1f);
			spriteBatch.Draw(texture2D, spot, new Rectangle?(new Rectangle(5, 0, texture2D.Width - 9, texture2D.Height)), BackColor, 0f, new Vector2(84.5f, 0f), new Vector2(single2, 1f), SpriteEffects.None, 0f);
			spriteBatch.Draw(texture2D, spot + new Vector2(-single2 * 84.5f - 5f, 0f), new Rectangle?(new Rectangle(0, 0, 5, texture2D.Height)), BackColor, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
			spriteBatch.Draw(texture2D, spot + new Vector2(single2 * 84.5f, 0f), new Rectangle?(new Rectangle(texture2D.Width - 4, 0, 4, texture2D.Height)), BackColor, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
			unitX = unitX + ((Vector2.UnitX * (single - 0.5f)) * width);
			unitX.X = unitX.X - 1f;
			spriteBatch.Draw(texture2D2, unitX, new Rectangle?(new Rectangle(0, 0, 1, 1)), FillingColor, 0f, new Vector2(1f, 0.5f), new Vector2(width * single, single1), SpriteEffects.None, 0f);
			if (progress != 0f)
			{
				spriteBatch.Draw(texture2D2, unitX, new Rectangle?(new Rectangle(0, 0, 1, 1)), BlipColor, 0f, new Vector2(1f, 0.5f), new Vector2(2f, single1), SpriteEffects.None, 0f);
			}
			spriteBatch.Draw(texture2D2, unitX, new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Black, 0f, new Vector2(0f, 0.5f), new Vector2(width * (1f - single), single1), SpriteEffects.None, 0f);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			this._locked = !this._achievement.IsCompleted;
			this.UpdateIconFrame();
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			CalculatedStyle dimensions = this._achievementIconBorders.GetDimensions();
			float x = dimensions.X + dimensions.Width;
			Vector2 vector2 = new Vector2(x + 7f, innerDimensions.Y);
			Tuple<decimal, decimal> trackerValues = this.GetTrackerValues();
			bool flag = false;
			if ((!(trackerValues.Item1 == new decimal(0)) || !(trackerValues.Item2 == new decimal(0))) && this._locked)
			{
				flag = true;
			}
			float width = innerDimensions.Width - dimensions.Width + 1f;
			Vector2 vector21 = new Vector2(0.85f);
			Vector2 y = new Vector2(0.92f);
			Vector2 stringSize = ChatManager.GetStringSize(Main.fontItemStack, this._achievement.Description, y, width);
			if (stringSize.Y > 38f)
			{
				y.Y = y.Y * (38f / stringSize.Y);
			}
			Color color = (this._locked ? Color.Silver : Color.Gold);
			color = Color.Lerp(color, Color.White, (base.IsMouseHovering ? 0.5f : 0f));
			Color color1 = (this._locked ? Color.DarkGray : Color.Silver);
			color1 = Color.Lerp(color1, Color.White, (base.IsMouseHovering ? 1f : 0f));
			Color color2 = (base.IsMouseHovering ? Color.White : Color.Gray);
			Vector2 unitY = vector2 - (Vector2.UnitY * 2f);
			this.DrawPanelTop(spriteBatch, unitY, width, color2);
			AchievementCategory category = this._achievement.Category;
			unitY.Y = unitY.Y + 2f;
			unitY.X = unitY.X + 4f;
			spriteBatch.Draw(this._categoryTexture, unitY, new Rectangle?(this._categoryTexture.Frame(4, 2, (int)category, 0)), (base.IsMouseHovering ? Color.White : Color.Silver), 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
			unitY.X = unitY.X + 4f;
			unitY.X = unitY.X + 17f;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, this._achievement.FriendlyName, unitY, color, 0f, Vector2.Zero, vector21, width, 2f);
			unitY.X = unitY.X - 17f;
			Vector2 unitY1 = vector2 + (Vector2.UnitY * 27f);
			this.DrawPanelBottom(spriteBatch, unitY1, width, color2);
			unitY1.X = unitY1.X + 8f;
			unitY1.Y = unitY1.Y + 4f;
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, this._achievement.Description, unitY1, color1, 0f, Vector2.Zero, y, width - 10f, 2f);
			if (flag)
			{
				Vector2 unitX = (unitY + (Vector2.UnitX * width)) + Vector2.UnitY;
				string str = ((int)trackerValues.Item1).ToString();
				int item2 = (int)trackerValues.Item2;
				string str1 = string.Concat(str, "/", item2.ToString());
				Vector2 vector22 = new Vector2(0.75f);
				Vector2 stringSize1 = ChatManager.GetStringSize(Main.fontItemStack, str1, vector22, -1f);
				float item1 = (float)((float)(trackerValues.Item1 / trackerValues.Item2));
				float single = 80f;
				Color color3 = new Color(100, 255, 100);
				if (!base.IsMouseHovering)
				{
					color3 = Color.Lerp(color3, Color.Black, 0.25f);
				}
				Color color4 = new Color(255, 255, 255);
				if (!base.IsMouseHovering)
				{
					color4 = Color.Lerp(color4, Color.Black, 0.25f);
				}
				this.DrawProgressBar(spriteBatch, item1, unitX - ((Vector2.UnitX * single) * 0.7f), single, color4, color3, color3.MultiplyRGBA(new Color(new Vector4(1f, 1f, 1f, 0.5f))));
				unitX.X = unitX.X - (single * 1.4f + stringSize1.X);
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, str1, unitX, color, 0f, new Vector2(0f, 0f), vector22, 90f, 2f);
			}
		}

		public Achievement GetAchievement()
		{
			return this._achievement;
		}

		private Tuple<decimal, decimal> GetTrackerValues()
		{
			if (!this._achievement.HasTracker)
			{
				return Tuple.Create<decimal, decimal>(new decimal(0), new decimal(0));
			}
			IAchievementTracker tracker = this._achievement.GetTracker();
			if (tracker.GetTrackerType() == TrackerType.Int)
			{
				AchievementTracker<int> achievementTracker = (AchievementTracker<int>)tracker;
				return Tuple.Create<decimal, decimal>(achievementTracker.Value, achievementTracker.MaxValue);
			}
			if (tracker.GetTrackerType() != TrackerType.Float)
			{
				return Tuple.Create<decimal, decimal>(new decimal(0), new decimal(0));
			}
			AchievementTracker<float> achievementTracker1 = (AchievementTracker<float>)tracker;
			return Tuple.Create<decimal, decimal>((decimal)((float)achievementTracker1.Value), (decimal)((float)achievementTracker1.MaxValue));
		}

		public override void MouseOut(UIMouseEvent evt)
		{
			base.MouseOut(evt);
			this.BackgroundColor = new Color(26, 40, 89) * 0.8f;
			this.BorderColor = new Color(13, 20, 44) * 0.8f;
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			this.BackgroundColor = new Color(46, 60, 119);
			this.BorderColor = new Color(20, 30, 56);
		}

		private void UpdateIconFrame()
		{
			if (this._locked)
			{
				this._iconFrame = this._iconFrameLocked;
			}
			else
			{
				this._iconFrame = this._iconFrameUnlocked;
			}
			if (this._achievementIcon != null)
			{
				this._achievementIcon.SetFrame(this._iconFrame);
			}
		}
	}
}