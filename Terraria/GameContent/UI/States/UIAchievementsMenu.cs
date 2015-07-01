using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.Achievements;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.States
{
	public class UIAchievementsMenu : UIState
	{
		private UIList _achievementsList;

		private List<UIAchievementListItem> _achievementElements = new List<UIAchievementListItem>();

		private List<UIToggleImage> _categoryButtons = new List<UIToggleImage>();

		private UIElement _outerContainer;

		public UIAchievementsMenu()
		{
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			for (int i = 0; i < this._categoryButtons.Count; i++)
			{
				if (this._categoryButtons[i].IsMouseHovering)
				{
					string str = "";
					switch (i)
					{
						case -1:
						{
							str = "None";
							break;
						}
						case 0:
						{
							str = "Slayer";
							break;
						}
						case 1:
						{
							str = "Collector";
							break;
						}
						case 2:
						{
							str = "Explorer";
							break;
						}
						case 3:
						{
							str = "Challenger";
							break;
						}
						default:
						{
							str = "None";
							break;
						}
					}
					float x = Main.fontMouseText.MeasureString(str).X;
					Vector2 vector2 = new Vector2((float)Main.mouseX, (float)Main.mouseY) + new Vector2(16f);
					if (vector2.Y > (float)(Main.screenHeight - 30))
					{
						vector2.Y = (float)(Main.screenHeight - 30);
					}
					if (vector2.X > (float)Main.screenWidth - x)
					{
						vector2.X = (float)(Main.screenWidth - 460);
					}
					Utils.DrawBorderStringFourWay(spriteBatch, Main.fontMouseText, str, vector2.X, vector2.Y, new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), Color.Black, Vector2.Zero, 1f);
					return;
				}
			}
		}

		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.8f;
		}

		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private void FilterList(UIMouseEvent evt, UIElement listeningElement)
		{
			this._achievementsList.Clear();
			foreach (UIAchievementListItem _achievementElement in this._achievementElements)
			{
				if (!this._categoryButtons[(int)_achievementElement.GetAchievement().Category].IsOn)
				{
					continue;
				}
				this._achievementsList.Add(_achievementElement);
			}
			this.Recalculate();
		}

		private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.menuMode = 0;
			AchievementsUI.Close();
		}

		public void GotoAchievement(Achievement achievement)
		{
			this._achievementsList.Goto((UIElement element) => {
				UIAchievementListItem uIAchievementListItem = element as UIAchievementListItem;
				if (uIAchievementListItem == null)
				{
					return false;
				}
				return uIAchievementListItem.GetAchievement() == achievement;
			});
		}

		public override void OnActivate()
		{
			if (!Main.gameMenu)
			{
				this._outerContainer.Top.Set(120f, 0f);
				this._outerContainer.Height.Set(-120f, 1f);
			}
			else
			{
				this._outerContainer.Top.Set(220f, 0f);
				this._outerContainer.Height.Set(-220f, 1f);
			}
			this._achievementsList.UpdateOrder();
		}

		public override void OnInitialize()
		{
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(800f, 0f);
			uIElement.MinWidth.Set(600f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;
			this._outerContainer = uIElement;
			base.Append(uIElement);
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIPanel.PaddingTop = 0f;
			uIElement.Append(uIPanel);
			this._achievementsList = new UIList();
			this._achievementsList.Width.Set(-25f, 1f);
			this._achievementsList.Height.Set(-50f, 1f);
			this._achievementsList.Top.Set(50f, 0f);
			this._achievementsList.ListPadding = 5f;
			uIPanel.Append(this._achievementsList);
			UITextPanel uITextPanel = new UITextPanel("Achievements", 1f, true)
			{
				HAlign = 0.5f
			};
			uITextPanel.Top.Set(-33f, 0f);
			uITextPanel.SetPadding(13f);
			uITextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(uITextPanel);
			UITextPanel uITextPanel1 = new UITextPanel("Back", 0.7f, true);
			uITextPanel1.Width.Set(-10f, 0.5f);
			uITextPanel1.Height.Set(50f, 0f);
			uITextPanel1.VAlign = 1f;
			uITextPanel1.HAlign = 0.5f;
			uITextPanel1.Top.Set(-45f, 0f);
			uITextPanel1.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			uITextPanel1.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			uITextPanel1.OnClick += new UIElement.MouseEvent(this.GoBackClick);
			uIElement.Append(uITextPanel1);
			List<Achievement> achievements = Main.Achievements.CreateAchievementsList();
			for (int i = 0; i < achievements.Count; i++)
			{
				UIAchievementListItem uIAchievementListItem = new UIAchievementListItem(achievements[i]);
				this._achievementsList.Add(uIAchievementListItem);
				this._achievementElements.Add(uIAchievementListItem);
			}
			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(-50f, 1f);
			uIScrollbar.Top.Set(50f, 0f);
			uIScrollbar.HAlign = 1f;
			uIPanel.Append(uIScrollbar);
			this._achievementsList.SetScrollbar(uIScrollbar);
			UIElement uIElement1 = new UIElement();
			uIElement1.Width.Set(0f, 1f);
			uIElement1.Height.Set(32f, 0f);
			uIElement1.Top.Set(10f, 0f);
			Texture2D texture2D = TextureManager.Load("Images/UI/Achievement_Categories");
			for (int j = 0; j < 4; j++)
			{
				UIToggleImage uIToggleImage = new UIToggleImage(texture2D, 32, 32, new Point(34 * j, 0), new Point(34 * j, 34));
				uIToggleImage.Left.Set((float)(j * 36 + 8), 0f);
				uIToggleImage.SetState(true);
				uIToggleImage.OnClick += new UIElement.MouseEvent(this.FilterList);
				this._categoryButtons.Add(uIToggleImage);
				uIElement1.Append(uIToggleImage);
			}
			uIPanel.Append(uIElement1);
		}
	}
}