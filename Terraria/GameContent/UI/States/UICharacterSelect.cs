using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.UI;

namespace Terraria.GameContent.UI.States
{
	internal class UICharacterSelect : UIState
	{
		private UIList _playerList;

		public UICharacterSelect()
		{
		}

		private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
		{
			((UIPanel)evt.Target).BackgroundColor = new Color(63, 82, 151) * 0.7f;
		}

		private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(12, -1, -1, 1);
			((UIPanel)evt.Target).BackgroundColor = new Color(73, 94, 171);
		}

		private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(11, -1, -1, 1);
			Main.menuMode = 0;
		}

		private void NewCharacterClick(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(10, -1, -1, 1);
			Player player = new Player();
			player.inventory[0].SetDefaults("Copper Shortsword");
			player.inventory[0].Prefix(-1);
			player.inventory[1].SetDefaults("Copper Pickaxe");
			player.inventory[1].Prefix(-1);
			player.inventory[2].SetDefaults("Copper Axe");
			player.inventory[2].Prefix(-1);
			Main.PendingPlayer = player;
			Main.menuMode = 2;
		}

		public override void OnActivate()
		{
			Main.LoadPlayers();
			this._playerList.Clear();
			foreach (PlayerFileData playerList in Main.PlayerList)
			{
				this._playerList.Add(new UICharacterListItem(playerList));
			}
		}

		public override void OnInitialize()
		{
			UIElement uIElement = new UIElement();
			uIElement.Width.Set(0f, 0.8f);
			uIElement.MaxWidth.Set(600f, 0f);
			uIElement.Top.Set(220f, 0f);
			uIElement.Height.Set(-220f, 1f);
			uIElement.HAlign = 0.5f;
			UIPanel uIPanel = new UIPanel();
			uIPanel.Width.Set(0f, 1f);
			uIPanel.Height.Set(-110f, 1f);
			uIPanel.BackgroundColor = new Color(33, 43, 79) * 0.8f;
			uIElement.Append(uIPanel);
			this._playerList = new UIList();
			this._playerList.Width.Set(-25f, 1f);
			this._playerList.Height.Set(0f, 1f);
			this._playerList.ListPadding = 5f;
			uIPanel.Append(this._playerList);
			UIScrollbar uIScrollbar = new UIScrollbar();
			uIScrollbar.SetView(100f, 1000f);
			uIScrollbar.Height.Set(0f, 1f);
			uIScrollbar.HAlign = 1f;
			uIPanel.Append(uIScrollbar);
			this._playerList.SetScrollbar(uIScrollbar);
			UITextPanel uITextPanel = new UITextPanel("Select Player", 0.8f, true)
			{
				HAlign = 0.5f
			};
			uITextPanel.Top.Set(-35f, 0f);
			uITextPanel.SetPadding(15f);
			uITextPanel.BackgroundColor = new Color(73, 94, 171);
			uIElement.Append(uITextPanel);
			UITextPanel uITextPanel1 = new UITextPanel("Back", 0.7f, true);
			uITextPanel1.Width.Set(-10f, 0.5f);
			uITextPanel1.Height.Set(50f, 0f);
			uITextPanel1.VAlign = 1f;
			uITextPanel1.Top.Set(-45f, 0f);
			uITextPanel1.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			uITextPanel1.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			uITextPanel1.OnClick += new UIElement.MouseEvent(this.GoBackClick);
			uIElement.Append(uITextPanel1);
			UITextPanel uITextPanel2 = new UITextPanel("New", 0.7f, true);
			uITextPanel2.CopyStyle(uITextPanel1);
			uITextPanel2.HAlign = 1f;
			uITextPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
			uITextPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
			uITextPanel2.OnClick += new UIElement.MouseEvent(this.NewCharacterClick);
			uIElement.Append(uITextPanel2);
			base.Append(uIElement);
		}
	}
}