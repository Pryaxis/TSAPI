using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics;
using Terraria.IO;
using Terraria.Social;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UIWorldListItem : UIPanel
	{
		private WorldFileData _data;

		private Texture2D _dividerTexture;

		private Texture2D _innerPanelTexture;

		private UIImage _worldIcon;

		private UIText _buttonLabel;

		private UIText _deleteButtonLabel;

		private Texture2D _buttonCloudActiveTexture;

		private Texture2D _buttonCloudInactiveTexture;

		private Texture2D _buttonFavoriteActiveTexture;

		private Texture2D _buttonFavoriteInactiveTexture;

		private Texture2D _buttonPlayTexture;

		private Texture2D _buttonDeleteTexture;

		private UIImageButton _deleteButton;

		public bool IsFavorite
		{
			get
			{
				return this._data.IsFavorite;
			}
		}

		public UIWorldListItem(WorldFileData data)
		{
			this.BorderColor = new Color(89, 116, 213) * 0.7f;
			this._dividerTexture = TextureManager.Load("Images/UI/Divider");
			this._innerPanelTexture = TextureManager.Load("Images/UI/InnerPanelBackground");
			this._buttonCloudActiveTexture = TextureManager.Load("Images/UI/ButtonCloudActive");
			this._buttonCloudInactiveTexture = TextureManager.Load("Images/UI/ButtonCloudInactive");
			this._buttonFavoriteActiveTexture = TextureManager.Load("Images/UI/ButtonFavoriteActive");
			this._buttonFavoriteInactiveTexture = TextureManager.Load("Images/UI/ButtonFavoriteInactive");
			this._buttonPlayTexture = TextureManager.Load("Images/UI/ButtonPlay");
			this._buttonDeleteTexture = TextureManager.Load("Images/UI/ButtonDelete");
			this.Height.Set(96f, 0f);
			this.Width.Set(0f, 1f);
			base.SetPadding(6f);
			this._data = data;
			this._worldIcon = new UIImage(this.GetIcon());
			this._worldIcon.Left.Set(4f, 0f);
			this._worldIcon.OnDoubleClick += new UIElement.MouseEvent(this.PlayGame);
			base.Append(this._worldIcon);
			UIImageButton uIImageButton = new UIImageButton(this._buttonPlayTexture)
			{
				VAlign = 1f
			};
			uIImageButton.Left.Set(4f, 0f);
			uIImageButton.OnClick += new UIElement.MouseEvent(this.PlayGame);
			base.OnDoubleClick += new UIElement.MouseEvent(this.PlayGame);
			uIImageButton.OnMouseOver += new UIElement.MouseEvent(this.PlayMouseOver);
			uIImageButton.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
			base.Append(uIImageButton);
			UIImageButton uIImageButton1 = new UIImageButton((this._data.IsFavorite ? this._buttonFavoriteActiveTexture : this._buttonFavoriteInactiveTexture))
			{
				VAlign = 1f
			};
			uIImageButton1.Left.Set(28f, 0f);
			uIImageButton1.OnClick += new UIElement.MouseEvent(this.FavoriteButtonClick);
			uIImageButton1.OnMouseOver += new UIElement.MouseEvent(this.FavoriteMouseOver);
			uIImageButton1.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
			uIImageButton1.SetVisibility(1f, (this._data.IsFavorite ? 0.8f : 0.4f));
			base.Append(uIImageButton1);
			if (SocialAPI.Cloud != null)
			{
				UIImageButton uIImageButton2 = new UIImageButton((this._data.IsCloudSave ? this._buttonCloudActiveTexture : this._buttonCloudInactiveTexture))
				{
					VAlign = 1f
				};
				uIImageButton2.Left.Set(52f, 0f);
				uIImageButton2.OnClick += new UIElement.MouseEvent(this.CloudButtonClick);
				uIImageButton2.OnMouseOver += new UIElement.MouseEvent(this.CloudMouseOver);
				uIImageButton2.OnMouseOut += new UIElement.MouseEvent(this.ButtonMouseOut);
				base.Append(uIImageButton2);
			}
			UIImageButton uIImageButton3 = new UIImageButton(this._buttonDeleteTexture)
			{
				VAlign = 1f,
				HAlign = 1f
			};
			uIImageButton3.OnClick += new UIElement.MouseEvent(this.DeleteButtonClick);
			uIImageButton3.OnMouseOver += new UIElement.MouseEvent(this.DeleteMouseOver);
			uIImageButton3.OnMouseOut += new UIElement.MouseEvent(this.DeleteMouseOut);
			this._deleteButton = uIImageButton3;
			if (!this._data.IsFavorite)
			{
				base.Append(uIImageButton3);
			}
			this._buttonLabel = new UIText("", 1f, false)
			{
				VAlign = 1f
			};
			this._buttonLabel.Left.Set(80f, 0f);
			this._buttonLabel.Top.Set(-3f, 0f);
			base.Append(this._buttonLabel);
			this._deleteButtonLabel = new UIText("", 1f, false)
			{
				VAlign = 1f,
				HAlign = 1f
			};
			this._deleteButtonLabel.Left.Set(-30f, 0f);
			this._deleteButtonLabel.Top.Set(-3f, 0f);
			base.Append(this._deleteButtonLabel);
		}

		private void ButtonMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonLabel.SetText("");
		}

		private void CloudButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			if (!this._data.IsCloudSave)
			{
				this._data.MoveToCloud();
			}
			else
			{
				this._data.MoveToLocal();
			}
			((UIImageButton)evt.Target).SetImage((this._data.IsCloudSave ? this._buttonCloudActiveTexture : this._buttonCloudInactiveTexture));
			if (this._data.IsCloudSave)
			{
				this._buttonLabel.SetText("Move off cloud");
				return;
			}
			this._buttonLabel.SetText("Move to cloud");
		}

		private void CloudMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			if (this._data.IsCloudSave)
			{
				this._buttonLabel.SetText("Move off cloud");
				return;
			}
			this._buttonLabel.SetText("Move to cloud");
		}

		public override int CompareTo(object obj)
		{
			UIWorldListItem uIWorldListItem = obj as UIWorldListItem;
			if (uIWorldListItem == null)
			{
				return base.CompareTo(obj);
			}
			if (this.IsFavorite && !uIWorldListItem.IsFavorite)
			{
				return -1;
			}
			if (!this.IsFavorite && uIWorldListItem.IsFavorite)
			{
				return 1;
			}
			return this._data.Name.CompareTo(uIWorldListItem._data.Name);
		}

		private void DeleteButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			for (int i = 0; i < Main.WorldList.Count; i++)
			{
				if (Main.WorldList[i] == this._data)
				{
					Main.PlaySound(10, -1, -1, 1);
					Main.selectedWorld = i;
					Main.menuMode = 9;
					return;
				}
			}
		}

		private void DeleteMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			this._deleteButtonLabel.SetText("");
		}

		private void DeleteMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			this._deleteButtonLabel.SetText("Delete");
		}

		private void DrawPanel(SpriteBatch spriteBatch, Vector2 position, float width)
		{
			spriteBatch.Draw(this._innerPanelTexture, position, new Rectangle?(new Rectangle(0, 0, 8, this._innerPanelTexture.Height)), Color.White);
			spriteBatch.Draw(this._innerPanelTexture, new Vector2(position.X + 8f, position.Y), new Rectangle?(new Rectangle(8, 0, 8, this._innerPanelTexture.Height)), Color.White, 0f, Vector2.Zero, new Vector2((width - 16f) / 8f, 1f), SpriteEffects.None, 0f);
			spriteBatch.Draw(this._innerPanelTexture, new Vector2(position.X + width - 8f, position.Y), new Rectangle?(new Rectangle(16, 0, 8, this._innerPanelTexture.Height)), Color.White);
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);
			CalculatedStyle innerDimensions = base.GetInnerDimensions();
			CalculatedStyle dimensions = this._worldIcon.GetDimensions();
			float x = dimensions.X + dimensions.Width;
			Utils.DrawBorderString(spriteBatch, this._data.Name, new Vector2(x + 6f, dimensions.Y - 2f), Color.White, 1f, 0f, 0f, -1);
			Rectangle? nullable = null;
			spriteBatch.Draw(this._dividerTexture, new Vector2(x, innerDimensions.Y + 21f), nullable, Color.White, 0f, Vector2.Zero, new Vector2((base.GetDimensions().X + base.GetDimensions().Width - x) / 8f, 1f), SpriteEffects.None, 0f);
			Vector2 vector2 = new Vector2(x + 6f, innerDimensions.Y + 29f);
			float single = 80f;
			this.DrawPanel(spriteBatch, vector2, single);
			string str = (this._data.IsExpertMode ? "Expert" : "Normal");
			float x1 = Main.fontMouseText.MeasureString(str).X;
			float single1 = single * 0.5f - x1 * 0.5f;
			Utils.DrawBorderString(spriteBatch, str, vector2 + new Vector2(single1, 3f), (this._data.IsExpertMode ? new Color(217, 143, 244) : Color.White), 1f, 0f, 0f, -1);
			vector2.X = vector2.X + (single + 5f);
			float single2 = 140f;
			this.DrawPanel(spriteBatch, vector2, single2);
			string str1 = string.Concat(this._data.WorldSizeName, " World");
			float x2 = Main.fontMouseText.MeasureString(str1).X;
			float single3 = single2 * 0.5f - x2 * 0.5f;
			Utils.DrawBorderString(spriteBatch, str1, vector2 + new Vector2(single3, 3f), Color.White, 1f, 0f, 0f, -1);
			vector2.X = vector2.X + (single2 + 5f);
			float x3 = innerDimensions.X + innerDimensions.Width - vector2.X;
			this.DrawPanel(spriteBatch, vector2, x3);
			string str2 = string.Concat("Created: ", this._data.CreationTime.ToString("d MMMM yyyy"));
			float x4 = Main.fontMouseText.MeasureString(str2).X;
			float single4 = x3 * 0.5f - x4 * 0.5f;
			Utils.DrawBorderString(spriteBatch, str2, vector2 + new Vector2(single4, 3f), Color.White, 1f, 0f, 0f, -1);
			vector2.X = vector2.X + (x3 + 5f);
		}

		private void FavoriteButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			this._data.ToggleFavorite();
			((UIImageButton)evt.Target).SetImage((this._data.IsFavorite ? this._buttonFavoriteActiveTexture : this._buttonFavoriteInactiveTexture));
			((UIImageButton)evt.Target).SetVisibility(1f, (this._data.IsFavorite ? 0.8f : 0.4f));
			if (!this._data.IsFavorite)
			{
				this._buttonLabel.SetText("Favorite");
				base.Append(this._deleteButton);
			}
			else
			{
				this._buttonLabel.SetText("Unfavorite");
				base.RemoveChild(this._deleteButton);
			}
			UIList parent = this.Parent.Parent as UIList;
			if (parent != null)
			{
				parent.UpdateOrder();
			}
		}

		private void FavoriteMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			if (this._data.IsFavorite)
			{
				this._buttonLabel.SetText("Unfavorite");
				return;
			}
			this._buttonLabel.SetText("Favorite");
		}

		private Texture2D GetIcon()
		{
			return TextureManager.Load(string.Concat("Images/UI/Icon", (this._data.IsHardMode ? "Hallow" : ""), (this._data.HasCorruption ? "Corruption" : "Crimson")));
		}

		public override void MouseOut(UIMouseEvent evt)
		{
			base.MouseOut(evt);
			this.BackgroundColor = new Color(63, 82, 151) * 0.7f;
			this.BorderColor = new Color(89, 116, 213) * 0.7f;
		}

		public override void MouseOver(UIMouseEvent evt)
		{
			base.MouseOver(evt);
			this.BackgroundColor = new Color(73, 94, 171);
			this.BorderColor = new Color(89, 116, 213);
		}

		private void PlayGame(UIMouseEvent evt, UIElement listeningElement)
		{
			if (listeningElement != evt.Target)
			{
				return;
			}
			this._data.SetAsActive();
			Main.PlaySound(10, -1, -1, 1);
			Main.GetInputText("");
			if (Main.menuMultiplayer && SocialAPI.Network != null)
			{
				Main.menuMode = 889;
			}
			else if (!Main.menuMultiplayer)
			{
				Main.menuMode = 10;
			}
			else
			{
				Main.menuMode = 30;
			}
			if (!Main.menuMultiplayer)
			{
				WorldGen.playWorld();
			}
		}

		private void PlayMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonLabel.SetText("Play");
		}
	}
}