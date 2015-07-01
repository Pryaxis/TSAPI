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
	internal class UICharacterListItem : UIPanel
	{
		private PlayerFileData _data;

		private Texture2D _dividerTexture;

		private Texture2D _innerPanelTexture;

		private UICharacter _playerPanel;

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

		public UICharacterListItem(PlayerFileData data)
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
			this._playerPanel = new UICharacter(data.Player);
			this._playerPanel.Left.Set(4f, 0f);
			this._playerPanel.OnDoubleClick += new UIElement.MouseEvent(this.PlayGame);
			base.OnDoubleClick += new UIElement.MouseEvent(this.PlayGame);
			base.Append(this._playerPanel);
			UIImageButton uIImageButton = new UIImageButton(this._buttonPlayTexture)
			{
				VAlign = 1f
			};
			uIImageButton.Left.Set(4f, 0f);
			uIImageButton.OnClick += new UIElement.MouseEvent(this.PlayGame);
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
			UICharacterListItem uICharacterListItem = obj as UICharacterListItem;
			if (uICharacterListItem == null)
			{
				return base.CompareTo(obj);
			}
			if (this.IsFavorite && !uICharacterListItem.IsFavorite)
			{
				return -1;
			}
			if (!this.IsFavorite && uICharacterListItem.IsFavorite)
			{
				return 1;
			}
			return this._data.Name.CompareTo(uICharacterListItem._data.Name);
		}

		private void DeleteButtonClick(UIMouseEvent evt, UIElement listeningElement)
		{
			for (int i = 0; i < Main.PlayerList.Count; i++)
			{
				if (Main.PlayerList[i] == this._data)
				{
					Main.PlaySound(10, -1, -1, 1);
					Main.selectedPlayer = i;
					Main.menuMode = 5;
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
			CalculatedStyle dimensions = this._playerPanel.GetDimensions();
			float x = dimensions.X + dimensions.Width;
			Utils.DrawBorderString(spriteBatch, this._data.Name, new Vector2(x + 6f, dimensions.Y - 2f), Color.White, 1f, 0f, 0f, -1);
			Rectangle? nullable = null;
			spriteBatch.Draw(this._dividerTexture, new Vector2(x, innerDimensions.Y + 21f), nullable, Color.White, 0f, Vector2.Zero, new Vector2((base.GetDimensions().X + base.GetDimensions().Width - x) / 8f, 1f), SpriteEffects.None, 0f);
			Vector2 vector2 = new Vector2(x + 6f, innerDimensions.Y + 29f);
			float single = 200f;
			Vector2 x1 = vector2;
			this.DrawPanel(spriteBatch, x1, single);
			spriteBatch.Draw(Main.heartTexture, x1 + new Vector2(5f, 2f), Color.White);
			x1.X = x1.X + (10f + (float)Main.heartTexture.Width);
			Utils.DrawBorderString(spriteBatch, string.Concat(this._data.Player.statLifeMax, " HP"), x1 + new Vector2(0f, 3f), Color.White, 1f, 0f, 0f, -1);
			x1.X = x1.X + 65f;
			spriteBatch.Draw(Main.manaTexture, x1 + new Vector2(5f, 2f), Color.White);
			x1.X = x1.X + (10f + (float)Main.manaTexture.Width);
			Utils.DrawBorderString(spriteBatch, string.Concat(this._data.Player.statManaMax, " MP"), x1 + new Vector2(0f, 3f), Color.White, 1f, 0f, 0f, -1);
			vector2.X = vector2.X + (single + 5f);
			Vector2 vector21 = vector2;
			float single1 = 110f;
			this.DrawPanel(spriteBatch, vector21, single1);
			string str = "";
			Color white = Color.White;
			switch (this._data.Player.difficulty)
			{
				case 0:
				{
					str = "Softcore";
					break;
				}
				case 1:
				{
					str = "Mediumcore";
					white = Main.mcColor;
					break;
				}
				case 2:
				{
					str = "Hardcore";
					white = Main.hcColor;
					break;
				}
			}
			vector21 = vector21 + new Vector2(single1 * 0.5f - Main.fontMouseText.MeasureString(str).X * 0.5f, 3f);
			Utils.DrawBorderString(spriteBatch, str, vector21, white, 1f, 0f, 0f, -1);
			vector2.X = vector2.X + (single1 + 5f);
			Vector2 vector22 = vector2;
			float x2 = innerDimensions.X + innerDimensions.Width - vector22.X;
			this.DrawPanel(spriteBatch, vector22, x2);
			TimeSpan playTime = this._data.GetPlayTime();
			int days = playTime.Days * 24 + playTime.Hours;
			string str1 = string.Concat((days < 10 ? "0" : ""), days, playTime.ToString("\\:mm\\:ss"));
			vector22 = vector22 + new Vector2(x2 * 0.5f - Main.fontMouseText.MeasureString(str1).X * 0.5f, 3f);
			Utils.DrawBorderString(spriteBatch, str1, vector22, Color.White, 1f, 0f, 0f, -1);
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
			if (this._data.Player.loadStatus == 0)
			{
				Main.SelectPlayer(this._data);
			}
		}

		private void PlayMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			this._buttonLabel.SetText("Play");
		}
	}
}