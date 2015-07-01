using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
	internal class UICharacter : UIElement
	{
		private Player _player;

		private Texture2D _texture;

		private static Item _blankItem;

		static UICharacter()
		{
			UICharacter._blankItem = new Item();
		}

		public UICharacter(Player player)
		{
			this._player = player;
			this.Width.Set(59f, 0f);
			this.Height.Set(58f, 0f);
			this._texture = TextureManager.Load("Images/UI/PlayerBackground");
			this._useImmediateMode = true;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			CalculatedStyle dimensions = base.GetDimensions();
			spriteBatch.Draw(this._texture, dimensions.Position(), Color.White);
			Vector2 vector2 = dimensions.Position() + new Vector2(dimensions.Width * 0.5f - (float)(this._player.width >> 1), dimensions.Height * 0.5f - (float)(this._player.height >> 1));
			Item item = this._player.inventory[this._player.selectedItem];
			this._player.inventory[this._player.selectedItem] = UICharacter._blankItem;
			Main.instance.DrawPlayer(this._player, vector2 + Main.screenPosition, 0f, Vector2.Zero, 0f);
			this._player.inventory[this._player.selectedItem] = item;
		}
	}
}