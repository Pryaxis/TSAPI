using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
	internal class ItemTagHandler : ITagHandler
	{
		public ItemTagHandler()
		{
		}

		public static string GenerateTag(Item I)
		{
			string str = "[i";
			if (I.prefix != 0)
			{
				str = string.Concat(str, "/p", I.prefix);
			}
			if (I.stack != 1)
			{
				str = string.Concat(str, "/s", I.stack);
			}
			object obj = str;
			object[] i = new object[] { obj, ":", I.netID, "]" };
			str = string.Concat(i);
			return str;
		}

		TextSnippet Terraria.UI.Chat.ITagHandler.Parse(string text, Color baseColor, string options)
		{
			int num;
			int num1;
			int num2;
			Item item = new Item();
			if (!int.TryParse(text, out num))
			{
				item.SetDefaults(text);
			}
			else
			{
				item.netDefaults(num);
			}
			if (item.type <= 0)
			{
				return new TextSnippet(text);
			}
			item.stack = 1;
			if (options != null)
			{
				string[] strArrays = options.Split(new char[] { ',' });
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					if (strArrays[i].Length != 0)
					{
						char chr = strArrays[i][0];
						if (chr != 'p')
						{
							if ((chr == 's' || chr == 'x') && int.TryParse(strArrays[i].Substring(1), out num1))
							{
								item.stack = Utils.Clamp<int>(num1, 1, item.maxStack);
							}
						}
						else if (int.TryParse(strArrays[i].Substring(1), out num2))
						{
							item.Prefix((int)Utils.Clamp<int>(num2, 0, 84));
						}
					}
				}
			}
			string str = "";
			if (item.stack > 1)
			{
				str = string.Concat(" (", item.stack, ")");
			}
			ItemTagHandler.ItemSnippet itemSnippet = new ItemTagHandler.ItemSnippet(item)
			{
				Text = string.Concat("[", item.AffixName(), str, "]"),
				CheckForHover = true,
				DeleteWhole = true
			};
			return itemSnippet;
		}

		private class ItemSnippet : TextSnippet
		{
			private Item _item;

			public ItemSnippet(Item item) : base("")
			{
				this._item = item;
				this.Color = ItemRarity.GetColor(item.rare);
			}

			public override void OnHover()
			{
				Main.toolTip = this._item.Clone();
				Main.instance.MouseText(this._item.name, this._item.rare, 0);
			}

			public override bool UniqueDraw(bool justCheckingString, out Vector2 size, SpriteBatch spriteBatch, Vector2 position = new Vector2(), Color color = new Color(), float scale = 1f)
			{
				Rectangle rectangle;
				float single = 1f;
				float height = 1f;
				if (Main.netMode != 2 && !Main.dedServ)
				{
					Texture2D texture2D = Main.itemTexture[this._item.type];
					rectangle = (Main.itemAnimations[this._item.type] == null ? texture2D.Frame(1, 1, 0, 0) : Main.itemAnimations[this._item.type].GetFrame(texture2D));
					if (rectangle.Height > 32)
					{
						height = 32f / (float)rectangle.Height;
					}
				}
				height = height * scale;
				single = single * height;
				if (single > 0.75f)
				{
					single = 0.75f;
				}
				if (!justCheckingString && color != Color.Black)
				{
					float single1 = Main.inventoryScale;
					Main.inventoryScale = scale * single;
					ItemSlot.Draw(spriteBatch, ref this._item, 14, position - ((new Vector2(10f) * scale) * single), Color.White);
					Main.inventoryScale = single1;
				}
				size = (new Vector2(32f) * scale) * single;
				return true;
			}
		}
	}
}