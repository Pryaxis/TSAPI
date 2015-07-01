using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.UI.Chat;
using Terraria.ID;
using Terraria.UI.Chat;

namespace Terraria.UI
{
	public class ItemSlot
	{
		private static Item[] singleSlotArray;

		private static bool[] canFavoriteAt;

		private static int dyeSlotCount;

		private static int accSlotCount;

		static ItemSlot()
		{
			ItemSlot.singleSlotArray = new Item[1];
			ItemSlot.canFavoriteAt = new bool[23];
			ItemSlot.dyeSlotCount = 0;
			ItemSlot.accSlotCount = 0;
			ItemSlot.canFavoriteAt[0] = true;
			ItemSlot.canFavoriteAt[1] = true;
			ItemSlot.canFavoriteAt[2] = true;
		}

		public ItemSlot()
		{
		}

		private static bool AccCheck(Item item, int slot)
		{
			Player player = Main.player[Main.myPlayer];
			if (slot != -1)
			{
				if (player.armor[slot].IsTheSameAs(item))
				{
					return false;
				}
				if (player.armor[slot].wingSlot > 0 && item.wingSlot > 0)
				{
					return false;
				}
			}
			for (int i = 0; i < (int)player.armor.Length; i++)
			{
				if (slot < 10 && i < 10)
				{
					if (item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						return true;
					}
					if (slot >= 10 && i >= 10 && item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						return true;
					}
				}
				if (item.IsTheSameAs(player.armor[i]))
				{
					return true;
				}
			}
			return false;
		}

		private static Item ArmorSwap(Item item, out bool success)
		{
			success = false;
			if (item.headSlot == -1 && item.bodySlot == -1 && item.legSlot == -1 && !item.accessory)
			{
				return item;
			}
			Player player = Main.player[Main.myPlayer];
			int num = (!item.vanity || item.accessory ? 0 : 10);
			item.favorited = false;
			Item item1 = item;
			if (item.headSlot != -1)
			{
				item1 = player.armor[num].Clone();
				player.armor[num] = item.Clone();
			}
			else if (item.bodySlot != -1)
			{
				item1 = player.armor[num + 1].Clone();
				player.armor[num + 1] = item.Clone();
			}
			else if (item.legSlot != -1)
			{
				item1 = player.armor[num + 2].Clone();
				player.armor[num + 2] = item.Clone();
			}
			else if (item.accessory)
			{
				int num1 = 5 + Main.player[Main.myPlayer].extraAccessorySlots;
				int num2 = 3;
				while (num2 < 3 + num1)
				{
					if (player.armor[num2].type != 0)
					{
						num2++;
					}
					else
					{
						ItemSlot.accSlotCount = num2 - 3;
						break;
					}
				}
				for (int i = 0; i < (int)player.armor.Length; i++)
				{
					if (item.IsTheSameAs(player.armor[i]))
					{
						ItemSlot.accSlotCount = i - 3;
					}
					if (i < 10 && item.wingSlot > 0 && player.armor[i].wingSlot > 0)
					{
						ItemSlot.accSlotCount = i - 3;
					}
				}
				if (ItemSlot.accSlotCount >= num1)
				{
					ItemSlot.accSlotCount = 0;
				}
				if (ItemSlot.accSlotCount < 0)
				{
					ItemSlot.accSlotCount = num1 - 1;
				}
				int num3 = 3 + ItemSlot.accSlotCount;
				for (int j = 0; j < (int)player.armor.Length; j++)
				{
					if (item.IsTheSameAs(player.armor[j]))
					{
						num3 = j;
					}
				}
				item1 = player.armor[num3].Clone();
				player.armor[num3] = item.Clone();
				ItemSlot.accSlotCount = ItemSlot.accSlotCount + 1;
				if (ItemSlot.accSlotCount >= num1)
				{
					ItemSlot.accSlotCount = 0;
				}
			}
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			success = true;
			return item1;
		}

		public static void Draw(SpriteBatch spriteBatch, ref Item inv, int context, Vector2 position, Color lightColor = new Color())
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.Draw(spriteBatch, ItemSlot.singleSlotArray, context, 0, position, lightColor);
			inv = ItemSlot.singleSlotArray[0];
		}

		public static void Draw(SpriteBatch spriteBatch, Item[] inv, int context, int slot, Vector2 position, Color lightColor = new Color())
		{
			Rectangle rectangle;
			Player player = Main.player[Main.myPlayer];
			Item item = inv[slot];
			float single = Main.inventoryScale;
			Color white = Color.White;
			if (lightColor != Color.Transparent)
			{
				white = lightColor;
			}
			Texture2D texture2D = Main.inventoryBackTexture;
			Color color = Main.inventoryBack;
			bool flag = false;
			if (item.type > 0 && item.stack > 0 && item.favorited && context != 13 && context != 21 && context != 22)
			{
				texture2D = Main.inventoryBack10Texture;
			}
			else if (context == 0 && slot < 10)
			{
				texture2D = Main.inventoryBack9Texture;
			}
			else if (context == 10 || context == 8 || context == 16 || context == 17 || context == 19 || context == 18 || context == 20)
			{
				texture2D = Main.inventoryBack3Texture;
			}
			else if (context == 11 || context == 9)
			{
				texture2D = Main.inventoryBack8Texture;
			}
			else if (context == 12)
			{
				texture2D = Main.inventoryBack12Texture;
			}
			else if (context == 3)
			{
				texture2D = Main.inventoryBack5Texture;
			}
			else if (context == 4)
			{
				texture2D = Main.inventoryBack2Texture;
			}
			else if (context == 7 || context == 5)
			{
				texture2D = Main.inventoryBack4Texture;
			}
			else if (context == 6)
			{
				texture2D = Main.inventoryBack7Texture;
			}
			else if (context == 13)
			{
				byte num = 200;
				if (slot == Main.player[Main.myPlayer].selectedItem)
				{
					texture2D = Main.inventoryBack14Texture;
					num = 255;
				}
				color = new Color((int)num, (int)num, (int)num, (int)num);
			}
			else if (context == 14 || context == 21)
			{
				flag = true;
			}
			else if (context == 15)
			{
				texture2D = Main.inventoryBack6Texture;
			}
			else if (context == 22)
			{
				texture2D = Main.inventoryBack4Texture;
			}
			if (!flag)
			{
				Rectangle? nullable = null;
				Vector2 vector2 = new Vector2();
				spriteBatch.Draw(texture2D, position, nullable, color, 0f, vector2, single, SpriteEffects.None, 0f);
			}
			int num1 = -1;
			switch (context)
			{
				case 8:
				{
					if (slot == 0)
					{
						num1 = 0;
					}
					if (slot == 1)
					{
						num1 = 6;
					}
					if (slot != 2)
					{
						goto case 15;
					}
					num1 = 12;
					goto case 15;
				}
				case 9:
				{
					if (slot == 10)
					{
						num1 = 3;
					}
					if (slot == 11)
					{
						num1 = 9;
					}
					if (slot != 12)
					{
						goto case 15;
					}
					num1 = 15;
					goto case 15;
				}
				case 10:
				{
					num1 = 11;
					goto case 15;
				}
				case 11:
				{
					num1 = 2;
					goto case 15;
				}
				case 12:
				{
					num1 = 1;
					goto case 15;
				}
				case 13:
				case 14:
				case 15:
				{
					if ((item.type <= 0 || item.stack <= 0) && num1 != -1)
					{
						Texture2D texture2D1 = Main.extraTexture[54];
						Rectangle width = texture2D1.Frame(3, 6, num1 % 3, num1 / 3);
						width.Width = width.Width - 2;
						width.Height = width.Height - 2;
						spriteBatch.Draw(texture2D1, position + ((texture2D.Size() / 2f) * single), new Rectangle?(width), Color.White * 0.35f, 0f, width.Size() / 2f, single, SpriteEffects.None, 0f);
					}
					if (item.type > 0 && item.stack > 0)
					{
						Texture2D texture2D2 = Main.itemTexture[item.type];
						rectangle = (Main.itemAnimations[item.type] == null ? texture2D2.Frame(1, 1, 0, 0) : Main.itemAnimations[item.type].GetFrame(texture2D2));
						Color color1 = white;
						float single1 = 1f;
						ItemSlot.GetItemLight(ref color1, ref single1, item, false);
						float single2 = 1f;
						if (rectangle.Width > 32 || rectangle.Height > 32)
						{
							single2 = (rectangle.Width <= rectangle.Height ? 32f / (float)rectangle.Height : 32f / (float)rectangle.Width);
						}
						single2 = single2 * single;
						Vector2 vector21 = (position + ((texture2D.Size() * single) / 2f)) - ((rectangle.Size() * single2) / 2f);
						Vector2 vector22 = rectangle.Size() * (single1 / 2f - 0.5f);
						spriteBatch.Draw(texture2D2, vector21, new Rectangle?(rectangle), item.GetAlpha(color1), 0f, vector22, single2 * single1, SpriteEffects.None, 0f);
						if (item.color != Color.Transparent)
						{
							spriteBatch.Draw(texture2D2, vector21, new Rectangle?(rectangle), item.GetColor(white), 0f, vector22, single2 * single1, SpriteEffects.None, 0f);
						}
						if (item.stack > 1)
						{
							ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, item.stack.ToString(), position + (new Vector2(10f, 26f) * single), white, 0f, Vector2.Zero, new Vector2(single), -1f, single);
						}
						int num2 = -1;
						if (context == 13)
						{
							if (item.useAmmo > 0)
							{
								int num3 = item.useAmmo;
								num2 = 0;
								for (int i = 0; i < 58; i++)
								{
									if (inv[i].ammo == num3)
									{
										num2 = num2 + inv[i].stack;
									}
								}
							}
							if (item.fishingPole > 0)
							{
								num2 = 0;
								for (int j = 0; j < 58; j++)
								{
									if (inv[j].bait > 0)
									{
										num2 = num2 + inv[j].stack;
									}
								}
							}
							if (item.tileWand > 0)
							{
								int num4 = item.tileWand;
								num2 = 0;
								for (int k = 0; k < 58; k++)
								{
									if (inv[k].type == num4)
									{
										num2 = num2 + inv[k].stack;
									}
								}
							}
							if (item.type == 509 || item.type == 851 || item.type == 850)
							{
								num2 = 0;
								for (int l = 0; l < 58; l++)
								{
									if (inv[l].type == 530)
									{
										num2 = num2 + inv[l].stack;
									}
								}
							}
						}
						if (num2 != -1)
						{
							ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, num2.ToString(), position + (new Vector2(8f, 30f) * single), white, 0f, Vector2.Zero, new Vector2(single * 0.8f), -1f, single);
						}
						if (context == 13)
						{
							string str = string.Concat(slot + 1);
							if (str == "10")
							{
								str = "0";
							}
							ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, str, position + (new Vector2(8f, 4f) * single), white, 0f, Vector2.Zero, new Vector2(single), -1f, single);
						}
						if (context == 13 && item.potion)
						{
							Vector2 vector23 = (position + ((texture2D.Size() * single) / 2f)) - ((Main.cdTexture.Size() * single) / 2f);
							Color alpha = item.GetAlpha(white) * ((float)player.potionDelay / (float)player.potionDelayTime);
							Texture2D texture2D3 = Main.cdTexture;
							Rectangle? nullable1 = null;
							Vector2 vector24 = new Vector2();
							spriteBatch.Draw(texture2D3, vector23, nullable1, alpha, 0f, vector24, single2, SpriteEffects.None, 0f);
						}
						if ((context == 10 || context == 18) && item.expertOnly && !Main.expertMode)
						{
							Vector2 vector25 = (position + ((texture2D.Size() * single) / 2f)) - ((Main.cdTexture.Size() * single) / 2f);
							Color white1 = Color.White;
							Texture2D texture2D4 = Main.cdTexture;
							Rectangle? nullable2 = null;
							Vector2 vector26 = new Vector2();
							spriteBatch.Draw(texture2D4, vector25, nullable2, white1, 0f, vector26, single2, SpriteEffects.None, 0f);
						}
					}
					else if (context == 6)
					{
						Texture2D texture2D5 = Main.trashTexture;
						Vector2 vector27 = (position + ((texture2D.Size() * single) / 2f)) - ((texture2D5.Size() * single) / 2f);
						Rectangle? nullable3 = null;
						Color color2 = new Color(100, 100, 100, 100);
						Vector2 vector28 = new Vector2();
						spriteBatch.Draw(texture2D5, vector27, nullable3, color2, 0f, vector28, single, SpriteEffects.None, 0f);
					}
					if (context == 0 && slot < 10)
					{
						float single3 = single;
						string str1 = string.Concat(slot + 1);
						if (str1 == "10")
						{
							str1 = "0";
						}
						Color color3 = Main.inventoryBack;
						int num5 = 0;
						if (Main.player[Main.myPlayer].selectedItem == slot)
						{
							num5 = num5 - 3;
							color3.R = 255;
							color3.B = 0;
							color3.G = 210;
							color3.A = 100;
							single3 = single3 * 1.4f;
						}
						ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, str1, position + (new Vector2(6f, (float)(4 + num5)) * single), color3, 0f, Vector2.Zero, new Vector2(single), -1f, single);
					}
					return;
				}
				case 16:
				{
					num1 = 4;
					goto case 15;
				}
				case 17:
				{
					num1 = 13;
					goto case 15;
				}
				case 18:
				{
					num1 = 7;
					goto case 15;
				}
				case 19:
				{
					num1 = 10;
					goto case 15;
				}
				case 20:
				{
					num1 = 17;
					goto case 15;
				}
				default:
				{
					goto case 15;
				}
			}
		}

		public static void DrawMoney(SpriteBatch sb, string text, float shopx, float shopy, int[] coinsArray, bool horizontal = false)
		{
			Utils.DrawBorderStringFourWay(sb, Main.fontMouseText, text, shopx, shopy + 40f, Color.White * ((float)Main.mouseTextColor / 255f), Color.Black, Vector2.Zero, 1f);
			if (horizontal)
			{
				for (int i = 0; i < 4; i++)
				{
					if (i == 0)
					{
						int num = coinsArray[3 - i];
					}
					Vector2 vector2 = new Vector2(shopx + ChatManager.GetStringSize(Main.fontMouseText, text, Vector2.One, -1f).X + (float)(24 * i) + 45f, shopy + 50f);
					Rectangle? nullable = null;
					sb.Draw(Main.itemTexture[74 - i], vector2, nullable, Color.White, 0f, Main.itemTexture[74 - i].Size() / 2f, 1f, SpriteEffects.None, 0f);
					Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, coinsArray[3 - i].ToString(), vector2.X - 11f, vector2.Y, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
				}
				return;
			}
			for (int j = 0; j < 4; j++)
			{
				int num1 = (j != 0 || coinsArray[3 - j] <= 99 ? 0 : -6);
				Rectangle? nullable1 = null;
				sb.Draw(Main.itemTexture[74 - j], new Vector2(shopx + 11f + (float)(24 * j), shopy + 75f), nullable1, Color.White, 0f, Main.itemTexture[74 - j].Size() / 2f, 1f, SpriteEffects.None, 0f);
				Utils.DrawBorderStringFourWay(sb, Main.fontItemStack, coinsArray[3 - j].ToString(), shopx + (float)(24 * j) + (float)num1, shopy + 75f, Color.White, Color.Black, new Vector2(0.3f), 0.75f);
			}
		}

		public static void DrawSavings(SpriteBatch sb, float shopx, float shopy, bool horizontal = false)
		{
			bool flag;
			Player player = Main.player[Main.myPlayer];
			long num = Utils.CoinsCount(out flag, player.bank.item, new int[0]);
			long num1 = Utils.CoinsCount(out flag, player.bank2.item, new int[0]);
			long[] numArray = new long[] { num, num1 };
			long num2 = Utils.CoinsCombineStacks(out flag, numArray);
			if (num2 > (long)0)
			{
				if (num1 > (long)0)
				{
					Rectangle? nullable = null;
					sb.Draw(Main.itemTexture[346], Utils.CenteredRectangle(new Vector2(shopx + 80f, shopy + 50f), Main.itemTexture[346].Size() * 0.65f), nullable, Color.White);
				}
				if (num > (long)0)
				{
					Rectangle? nullable1 = null;
					sb.Draw(Main.itemTexture[87], Utils.CenteredRectangle(new Vector2(shopx + 70f, shopy + 60f), Main.itemTexture[87].Size() * 0.65f), nullable1, Color.White);
				}
				ItemSlot.DrawMoney(sb, Lang.inter[66], shopx, shopy, Utils.CoinsSplit(num2), horizontal);
			}
		}

		private static Item DyeSwap(Item item, out bool success)
		{
			success = false;
			if (item.dye <= 0)
			{
				return item;
			}
			Player player = Main.player[Main.myPlayer];
			Item item1 = item;
			int num = 0;
			while (num < 10)
			{
				if (player.dye[num].type != 0)
				{
					num++;
				}
				else
				{
					ItemSlot.dyeSlotCount = num;
					break;
				}
			}
			if (ItemSlot.dyeSlotCount >= 10)
			{
				ItemSlot.dyeSlotCount = 0;
			}
			if (ItemSlot.dyeSlotCount < 0)
			{
				ItemSlot.dyeSlotCount = 9;
			}
			item1 = player.dye[ItemSlot.dyeSlotCount].Clone();
			player.dye[ItemSlot.dyeSlotCount] = item.Clone();
			ItemSlot.dyeSlotCount = ItemSlot.dyeSlotCount + 1;
			if (ItemSlot.dyeSlotCount >= 10)
			{
				ItemSlot.accSlotCount = 0;
			}
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			success = true;
			return item1;
		}

		public static void EquipPage(Item item)
		{
			Main.EquipPage = -1;
			if (Main.projHook[item.shoot])
			{
				Main.EquipPage = 2;
				return;
			}
			if (item.mountType != -1)
			{
				Main.EquipPage = 2;
				return;
			}
			if (item.dye > 0 && Main.EquipPageSelected == 1)
			{
				Main.EquipPage = 0;
				return;
			}
			if (item.legSlot != -1 || item.headSlot != -1 || item.bodySlot != -1 || item.accessory)
			{
				Main.EquipPage = 0;
			}
		}

		private static Item EquipSwap(Item item, Item[] inv, int slot, out bool success)
		{
			success = false;
			Player player = Main.player[Main.myPlayer];
			item.favorited = false;
			Item item1 = inv[slot].Clone();
			inv[slot] = item.Clone();
			Main.PlaySound(7, -1, -1, 1);
			Recipe.FindRecipes();
			success = true;
			return item1;
		}

		public static void GetItemLight(ref Color currentColor, Item item, bool outInTheWorld = false)
		{
			float single = 1f;
			ItemSlot.GetItemLight(ref currentColor, ref single, item, outInTheWorld);
		}

		public static void GetItemLight(ref Color currentColor, int type, bool outInTheWorld = false)
		{
			float single = 1f;
			ItemSlot.GetItemLight(ref currentColor, ref single, type, outInTheWorld);
		}

		public static void GetItemLight(ref Color currentColor, ref float scale, Item item, bool outInTheWorld = false)
		{
			ItemSlot.GetItemLight(ref currentColor, ref scale, item.type, outInTheWorld);
		}

		public static Color GetItemLight(ref Color currentColor, ref float scale, int type, bool outInTheWorld = false)
		{
			if (type < 0 || type > 3601)
			{
				return currentColor;
			}
			if (type == 662 || type == 663)
			{
				currentColor.R = (byte)Main.DiscoR;
				currentColor.G = (byte)Main.DiscoG;
				currentColor.B = (byte)Main.DiscoB;
				currentColor.A = 255;
			}
			else if (ItemID.Sets.ItemIconPulse[type])
			{
				scale = Main.essScale;
				currentColor.R = (byte)((float)currentColor.R * scale);
				currentColor.G = (byte)((float)currentColor.G * scale);
				currentColor.B = (byte)((float)currentColor.B * scale);
				currentColor.A = (byte)((float)currentColor.A * scale);
			}
			else if (type == 58 || type == 184)
			{
				scale = Main.essScale * 0.25f + 0.75f;
				currentColor.R = (byte)((float)currentColor.R * scale);
				currentColor.G = (byte)((float)currentColor.G * scale);
				currentColor.B = (byte)((float)currentColor.B * scale);
				currentColor.A = (byte)((float)currentColor.A * scale);
			}
			return currentColor;
		}

		public static void Handle(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.Handle(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
			Recipe.FindRecipes();
		}

		public static void Handle(Item[] inv, int context = 0, int slot = 0)
		{
			ItemSlot.OverrideHover(inv, context, slot);
			if (!Main.mouseLeftRelease || !Main.mouseLeft)
			{
				ItemSlot.RightClick(inv, context, slot);
			}
			else
			{
				ItemSlot.LeftClick(inv, context, slot);
				Recipe.FindRecipes();
			}
			ItemSlot.MouseHover(inv, context, slot);
		}

		public static void LeftClick(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.LeftClick(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		public static void LeftClick(Item[] inv, int context = 0, int slot = 0)
		{
			if (ItemSlot.OverrideLeftClick(inv, context, slot))
			{
				return;
			}
			Player player = Main.player[Main.myPlayer];
			bool flag = false;
			switch (context)
			{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				{
					flag = true;
					break;
				}
			}
			if (Main.keyState.IsKeyDown(Keys.LeftShift) && flag)
			{
				if (inv[slot].type > 0)
				{
					if (Main.npcShop > 0 && !inv[slot].favorited)
					{
						Chest chest = Main.instance.shop[Main.npcShop];
						if (inv[slot].type >= 71 && inv[slot].type <= 74)
						{
							return;
						}
						if (player.SellItem(inv[slot].@value, inv[slot].stack))
						{
							chest.AddShop(inv[slot]);
							inv[slot].SetDefaults(0, false);
							Main.PlaySound(18, -1, -1, 1);
							Recipe.FindRecipes();
							return;
						}
						if (inv[slot].@value == 0)
						{
							chest.AddShop(inv[slot]);
							inv[slot].SetDefaults(0, false);
							Main.PlaySound(7, -1, -1, 1);
							Recipe.FindRecipes();
							return;
						}
					}
					else if (!inv[slot].favorited)
					{
						Main.PlaySound(7, -1, -1, 1);
						Main.trashItem = inv[slot].Clone();
						inv[slot].SetDefaults(0, false);
						if (context == 3 && Main.netMode == 1)
						{
							NetMessage.SendData(32, -1, -1, "", player.chest, (float)slot, 0f, 0f, 0, 0, 0);
						}
						Recipe.FindRecipes();
						return;
					}
				}
			}
			else if ((player.selectedItem != slot || player.itemAnimation <= 0) && player.itemTime == 0)
			{
				int num = ItemSlot.PickItemMovementAction(inv, context, slot, Main.mouseItem);
				if (num == 0)
				{
					if (context == 6 && Main.mouseItem.type != 0)
					{
						inv[slot].SetDefaults(0, false);
					}
					Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
					if (inv[slot].stack > 0)
					{
						int num1 = context;
						if (num1 == 0)
						{
							AchievementsHelper.NotifyItemPickup(player, inv[slot]);
						}
						else
						{
							switch (num1)
							{
								case 8:
								case 9:
								case 10:
								case 11:
								case 12:
								case 16:
								case 17:
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
									break;
								}
							}
						}
					}
					if (inv[slot].type == 0 || inv[slot].stack < 1)
					{
						inv[slot] = new Item();
					}
					if (Main.mouseItem.IsTheSameAs(inv[slot]))
					{
						Utils.Swap<bool>(ref inv[slot].favorited, ref Main.mouseItem.favorited);
						if (inv[slot].stack != inv[slot].maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
						{
							if (Main.mouseItem.stack + inv[slot].stack > Main.mouseItem.maxStack)
							{
								int num2 = Main.mouseItem.maxStack - inv[slot].stack;
								Item item = inv[slot];
								item.stack = item.stack + num2;
								Item item1 = Main.mouseItem;
								item1.stack = item1.stack - num2;
							}
							else
							{
								Item item2 = inv[slot];
								item2.stack = item2.stack + Main.mouseItem.stack;
								Main.mouseItem.stack = 0;
							}
						}
					}
					if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
					{
						Main.mouseItem = new Item();
					}
					if (Main.mouseItem.type > 0 || inv[slot].type > 0)
					{
						Recipe.FindRecipes();
						Main.PlaySound(7, -1, -1, 1);
					}
					if (context == 3 && Main.netMode == 1)
					{
						NetMessage.SendData(32, -1, -1, "", player.chest, (float)slot, 0f, 0f, 0, 0, 0);
					}
				}
				else if (num == 1)
				{
					if (Main.mouseItem.stack == 1 && Main.mouseItem.type > 0 && inv[slot].type > 0 && inv[slot].IsNotTheSameAs(Main.mouseItem))
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						Main.PlaySound(7, -1, -1, 1);
						if (inv[slot].stack > 0)
						{
							int num3 = context;
							if (num3 == 0)
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
							else
							{
								switch (num3)
								{
									case 8:
									case 9:
									case 10:
									case 11:
									case 12:
									case 16:
									case 17:
									{
										AchievementsHelper.HandleOnEquip(player, inv[slot], context);
										break;
									}
								}
							}
						}
					}
					else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						if (inv[slot].type == 0 || inv[slot].stack < 1)
						{
							inv[slot] = new Item();
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || inv[slot].type > 0)
						{
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1);
						}
					}
					else if (Main.mouseItem.type > 0 && inv[slot].type == 0)
					{
						if (Main.mouseItem.stack != 1)
						{
							Item item3 = Main.mouseItem;
							item3.stack = item3.stack - 1;
							inv[slot].SetDefaults(Main.mouseItem.type, false);
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1);
						}
						else
						{
							Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
							if (inv[slot].type == 0 || inv[slot].stack < 1)
							{
								inv[slot] = new Item();
							}
							if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
							{
								Main.mouseItem = new Item();
							}
							if (Main.mouseItem.type > 0 || inv[slot].type > 0)
							{
								Recipe.FindRecipes();
								Main.PlaySound(7, -1, -1, 1);
							}
						}
						if (inv[slot].stack > 0)
						{
							int num4 = context;
							if (num4 == 0)
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
							else
							{
								switch (num4)
								{
									case 8:
									case 9:
									case 10:
									case 11:
									case 12:
									case 16:
									case 17:
									{
										AchievementsHelper.HandleOnEquip(player, inv[slot], context);
										break;
									}
								}
							}
						}
					}
				}
				else if (num != 2)
				{
					if (num == 3)
					{
						Main.mouseItem.netDefaults(inv[slot].netID);
						if (!inv[slot].buyOnce)
						{
							Main.mouseItem.Prefix(-1);
						}
						else
						{
							Main.mouseItem.Prefix((int)inv[slot].prefix);
						}
						Main.mouseItem.position = player.Center - (new Vector2((float)Main.mouseItem.width, (float)Main.mouseItem.headSlot) / 2f);
						ItemText.NewText(Main.mouseItem, Main.mouseItem.stack, false, false);
						if (inv[slot].buyOnce)
						{
							Item item4 = inv[slot];
							int num5 = item4.stack - 1;
							int num6 = num5;
							item4.stack = num5;
							if (num6 <= 0)
							{
								inv[slot].SetDefaults(0, false);
							}
						}
						if (inv[slot].@value <= 0)
						{
							Main.PlaySound(7, -1, -1, 1);
						}
						else
						{
							Main.PlaySound(18, -1, -1, 1);
						}
					}
					else if (num == 4)
					{
						Chest chest1 = Main.instance.shop[Main.npcShop];
						if (player.SellItem(Main.mouseItem.@value, Main.mouseItem.stack))
						{
							chest1.AddShop(Main.mouseItem);
							Main.mouseItem.SetDefaults(0, false);
							Main.PlaySound(18, -1, -1, 1);
						}
						else if (Main.mouseItem.@value == 0)
						{
							chest1.AddShop(Main.mouseItem);
							Main.mouseItem.SetDefaults(0, false);
							Main.PlaySound(7, -1, -1, 1);
						}
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseItem.stack == 1 && Main.mouseItem.dye > 0 && inv[slot].type > 0 && inv[slot].type != Main.mouseItem.type)
				{
					Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
					Main.PlaySound(7, -1, -1, 1);
					if (inv[slot].stack > 0)
					{
						int num7 = context;
						if (num7 == 0)
						{
							AchievementsHelper.NotifyItemPickup(player, inv[slot]);
						}
						else
						{
							switch (num7)
							{
								case 8:
								case 9:
								case 10:
								case 11:
								case 12:
								case 16:
								case 17:
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
									break;
								}
							}
						}
					}
				}
				else if (Main.mouseItem.type == 0 && inv[slot].type > 0)
				{
					Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
					if (inv[slot].type == 0 || inv[slot].stack < 1)
					{
						inv[slot] = new Item();
					}
					if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
					{
						Main.mouseItem = new Item();
					}
					if (Main.mouseItem.type > 0 || inv[slot].type > 0)
					{
						Recipe.FindRecipes();
						Main.PlaySound(7, -1, -1, 1);
					}
				}
				else if (Main.mouseItem.dye > 0 && inv[slot].type == 0)
				{
					if (Main.mouseItem.stack != 1)
					{
						Item item5 = Main.mouseItem;
						item5.stack = item5.stack - 1;
						inv[slot].SetDefaults(Main.mouseItem.type, false);
						Recipe.FindRecipes();
						Main.PlaySound(7, -1, -1, 1);
					}
					else
					{
						Utils.Swap<Item>(ref inv[slot], ref Main.mouseItem);
						if (inv[slot].type == 0 || inv[slot].stack < 1)
						{
							inv[slot] = new Item();
						}
						if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
						{
							Main.mouseItem = new Item();
						}
						if (Main.mouseItem.type > 0 || inv[slot].type > 0)
						{
							Recipe.FindRecipes();
							Main.PlaySound(7, -1, -1, 1);
						}
					}
					if (inv[slot].stack > 0)
					{
						int num8 = context;
						if (num8 == 0)
						{
							AchievementsHelper.NotifyItemPickup(player, inv[slot]);
						}
						else
						{
							switch (num8)
							{
								case 8:
								case 9:
								case 10:
								case 11:
								case 12:
								case 16:
								case 17:
								{
									AchievementsHelper.HandleOnEquip(player, inv[slot], context);
									break;
								}
							}
						}
					}
				}
				switch (context)
				{
					case 0:
					case 1:
					case 2:
					case 5:
					{
						break;
					}
					default:
					{
						inv[slot].favorited = false;
						break;
					}
				}
			}
		}

		public static void MouseHover(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.MouseHover(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		public static void MouseHover(Item[] inv, int context = 0, int slot = 0)
		{
			if (context == 6 && Main.hoverItemName == null)
			{
				Main.hoverItemName = Lang.inter[3];
			}
			if (inv[slot].type <= 0 || inv[slot].stack <= 0)
			{
				if (context == 10 || context == 11)
				{
					Main.hoverItemName = Lang.inter[9];
				}
				if (context == 11)
				{
					Main.hoverItemName = string.Concat(Lang.inter[11], " ", Main.hoverItemName);
				}
				if (context == 8 || context == 9)
				{
					if (slot == 0 || slot == 10)
					{
						Main.hoverItemName = Lang.inter[12];
					}
					if (slot == 1 || slot == 11)
					{
						Main.hoverItemName = Lang.inter[13];
					}
					if (slot == 2 || slot == 12)
					{
						Main.hoverItemName = Lang.inter[14];
					}
					if (slot >= 10)
					{
						Main.hoverItemName = string.Concat(Lang.inter[11], " ", Main.hoverItemName);
					}
				}
				if (context == 12)
				{
					Main.hoverItemName = Lang.inter[57];
				}
				if (context == 16)
				{
					Main.hoverItemName = Lang.inter[90];
				}
				if (context == 17)
				{
					Main.hoverItemName = Lang.inter[91];
				}
				if (context == 19)
				{
					Main.hoverItemName = Lang.inter[92];
				}
				if (context == 18)
				{
					Main.hoverItemName = Lang.inter[93];
				}
				if (context == 20)
				{
					Main.hoverItemName = Lang.inter[94];
				}
			}
			else
			{
				Main.hoverItemName = inv[slot].name;
				if (inv[slot].stack > 1)
				{
					object obj = Main.hoverItemName;
					object[] objArray = new object[] { obj, " (", inv[slot].stack, ")" };
					Main.hoverItemName = string.Concat(objArray);
				}
				Main.toolTip = inv[slot].Clone();
				if (context == 8 && slot <= 2)
				{
					Main.toolTip.wornArmor = true;
				}
				if (context == 11 || context == 9)
				{
					Main.toolTip.social = true;
				}
				if (context == 15)
				{
					Main.toolTip.buy = true;
					return;
				}
			}
		}

		public static void OverrideHover(Item[] inv, int context = 0, int slot = 0)
		{
			Item item = inv[slot];
			if (Main.keyState.IsKeyDown(Keys.LeftShift) && item.type > 0 && item.stack > 0 && !inv[slot].favorited)
			{
				switch (context)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					{
						Main.cursorOverride = 6;
						break;
					}
					case 5:
					case 8:
					case 9:
					case 10:
					case 11:
					case 12:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					{
						if (!Main.player[Main.myPlayer].ItemSpace(inv[slot]))
						{
							break;
						}
						Main.cursorOverride = 7;
						break;
					}
				}
			}
			if (Main.keyState.IsKeyDown(Keys.LeftAlt) && ItemSlot.canFavoriteAt[context])
			{
				if (item.type > 0 && item.stack > 0 && Main.chatMode)
				{
					Main.cursorOverride = 2;
					return;
				}
				if (item.type > 0 && item.stack > 0)
				{
					Main.cursorOverride = 3;
				}
			}
		}

		private static bool OverrideLeftClick(Item[] inv, int context = 0, int slot = 0)
		{
			Item item = inv[slot];
			if (Main.cursorOverride == 2)
			{
				if (ChatManager.AddChatText(Main.fontMouseText, ItemTagHandler.GenerateTag(item), Vector2.One))
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				return true;
			}
			if (Main.cursorOverride == 3)
			{
				if (!ItemSlot.canFavoriteAt[context])
				{
					return false;
				}
				item.favorited = !item.favorited;
				Main.PlaySound(12, -1, -1, 1);
				return true;
			}
			if (Main.cursorOverride != 7)
			{
				return false;
			}
			inv[slot] = Main.player[Main.myPlayer].GetItem(Main.myPlayer, inv[slot], false, true);
			Main.PlaySound(12, -1, -1, 1);
			return true;
		}

		public static int PickItemMovementAction(Item[] inv, int context, int slot, Item checkItem)
		{
			Player player = Main.player[Main.myPlayer];
			int num = -1;
			if (context == 0)
			{
				num = 0;
			}
			else if (context == 1)
			{
				if (checkItem.type == 0 || checkItem.type == 71 || checkItem.type == 72 || checkItem.type == 73 || checkItem.type == 74)
				{
					num = 0;
				}
			}
			else if (context == 2)
			{
				if ((checkItem.type == 0 || checkItem.ammo > 0 || checkItem.type == 530 || checkItem.bait > 0) && !checkItem.notAmmo)
				{
					num = 0;
				}
			}
			else if (context == 3)
			{
				num = 0;
			}
			else if (context == 4)
			{
				num = 0;
			}
			else if (context == 5)
			{
				if (checkItem.Prefix(-3) || checkItem.type == 0)
				{
					num = 0;
				}
			}
			else if (context == 6)
			{
				num = 0;
			}
			else if (context == 7)
			{
				if (checkItem.material || checkItem.type == 0)
				{
					num = 0;
				}
			}
			else if (context == 8)
			{
				if (checkItem.type == 0 || checkItem.headSlot > -1 && slot == 0 || checkItem.bodySlot > -1 && slot == 1 || checkItem.legSlot > -1 && slot == 2)
				{
					num = 1;
				}
			}
			else if (context == 9)
			{
				if (checkItem.type == 0 || checkItem.headSlot > -1 && slot == 10 || checkItem.bodySlot > -1 && slot == 11 || checkItem.legSlot > -1 && slot == 12)
				{
					num = 1;
				}
			}
			else if (context == 10)
			{
				if (checkItem.type == 0 || checkItem.accessory && !ItemSlot.AccCheck(checkItem, slot))
				{
					num = 1;
				}
			}
			else if (context == 11)
			{
				if (checkItem.type == 0 || checkItem.accessory && !ItemSlot.AccCheck(checkItem, slot))
				{
					num = 1;
				}
			}
			else if (context == 12)
			{
				num = 2;
			}
			else if (context == 15)
			{
				if (checkItem.type == 0 && inv[slot].type > 0)
				{
					if (player.BuyItem(inv[slot].@value))
					{
						num = 3;
					}
				}
				else if (inv[slot].type == 0 && checkItem.type > 0 && (checkItem.type < 71 || checkItem.type > 74))
				{
					num = 4;
				}
			}
			else if (context == 16)
			{
				if (checkItem.type == 0 || Main.projHook[checkItem.shoot])
				{
					num = 1;
				}
			}
			else if (context == 17)
			{
				if (checkItem.type == 0 || checkItem.mountType != -1 && !MountID.Sets.Cart[checkItem.mountType])
				{
					num = 1;
				}
			}
			else if (context == 19)
			{
				if (checkItem.type == 0 || checkItem.buffType > 0 && Main.vanityPet[checkItem.buffType] && !Main.lightPet[checkItem.buffType])
				{
					num = 1;
				}
			}
			else if (context == 18)
			{
				if (checkItem.type == 0 || checkItem.mountType != -1 && MountID.Sets.Cart[checkItem.mountType])
				{
					num = 1;
				}
			}
			else if (context == 20 && (checkItem.type == 0 || checkItem.buffType > 0 && Main.lightPet[checkItem.buffType]))
			{
				num = 1;
			}
			return num;
		}

		public static void RightClick(ref Item inv, int context = 0)
		{
			ItemSlot.singleSlotArray[0] = inv;
			ItemSlot.RightClick(ItemSlot.singleSlotArray, context, 0);
			inv = ItemSlot.singleSlotArray[0];
		}

		public static void RightClick(Item[] inv, int context = 0, int slot = 0)
		{
			bool flag;
			Player player = Main.player[Main.myPlayer];
			if (player.itemAnimation > 0)
			{
				return;
			}
			bool flag1 = false;
			if (context == 0)
			{
				flag1 = true;
				if (Main.mouseRight && inv[slot].type >= 3318 && inv[slot].type <= 3332)
				{
					if (Main.mouseRightRelease)
					{
						player.OpenBossBag(inv[slot].type);
						Item item = inv[slot];
						item.stack = item.stack - 1;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && (inv[slot].type >= 2334 && inv[slot].type <= 2336 || inv[slot].type >= 3203 && inv[slot].type <= 3208))
				{
					if (Main.mouseRightRelease)
					{
						player.openCrate(inv[slot].type);
						Item item1 = inv[slot];
						item1.stack = item1.stack - 1;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 3093)
				{
					if (Main.mouseRightRelease)
					{
						player.openHerbBag();
						Item item2 = inv[slot];
						item2.stack = item2.stack - 1;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 1774)
				{
					if (Main.mouseRightRelease)
					{
						Item item3 = inv[slot];
						item3.stack = item3.stack - 1;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openGoodieBag();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 3085)
				{
					if (Main.mouseRightRelease && player.consumeItem(327))
					{
						Item item4 = inv[slot];
						item4.stack = item4.stack - 1;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openLockBox();
						Recipe.FindRecipes();
					}
				}
				else if (Main.mouseRight && inv[slot].type == 1869)
				{
					if (Main.mouseRightRelease)
					{
						Item item5 = inv[slot];
						item5.stack = item5.stack - 1;
						if (inv[slot].stack == 0)
						{
							inv[slot].SetDefaults(0, false);
						}
						Main.PlaySound(7, -1, -1, 1);
						Main.stackSplit = 30;
						Main.mouseRightRelease = false;
						player.openPresent();
						Recipe.FindRecipes();
					}
				}
				else if (!Main.mouseRight || !Main.mouseRightRelease || inv[slot].type != 599 && inv[slot].type != 600 && inv[slot].type != 601)
				{
					flag1 = false;
				}
				else
				{
					Main.PlaySound(7, -1, -1, 1);
					Main.stackSplit = 30;
					Main.mouseRightRelease = false;
					int num = Main.rand.Next(14);
					if (num == 0 && Main.hardMode)
					{
						inv[slot].SetDefaults(602, false);
					}
					else if (num > 7)
					{
						inv[slot].SetDefaults(591, false);
						inv[slot].stack = Main.rand.Next(20, 50);
					}
					else
					{
						inv[slot].SetDefaults(586, false);
						inv[slot].stack = Main.rand.Next(20, 50);
					}
					Recipe.FindRecipes();
				}
			}
			else if (context == 9 || context == 11)
			{
				flag1 = true;
				if (Main.mouseRight && Main.mouseRightRelease && (inv[slot].type > 0 && inv[slot].stack > 0 || inv[slot - 10].type > 0 && inv[slot - 10].stack > 0))
				{
					bool flag2 = true;
					if (flag2 && context == 11 && inv[slot].wingSlot > 0)
					{
						for (int i = 3; i < 10; i++)
						{
							if (inv[i].wingSlot > 0 && i != slot - 10)
							{
								flag2 = false;
							}
						}
					}
					if (flag2)
					{
						Utils.Swap<Item>(ref inv[slot], ref inv[slot - 10]);
						Main.PlaySound(7, -1, -1, 1);
						Recipe.FindRecipes();
						if (inv[slot].stack > 0)
						{
							int num1 = context;
							if (num1 == 0)
							{
								AchievementsHelper.NotifyItemPickup(player, inv[slot]);
							}
							else
							{
								switch (num1)
								{
									case 8:
									case 9:
									case 10:
									case 11:
									case 12:
									case 16:
									case 17:
									{
										AchievementsHelper.HandleOnEquip(player, inv[slot], context);
										break;
									}
								}
							}
						}
					}
				}
			}
			else if (context == 12)
			{
				flag1 = true;
				if (Main.mouseRight && Main.mouseRightRelease && Main.mouseItem.stack < Main.mouseItem.maxStack && Main.mouseItem.type > 0 && inv[slot].type > 0 && Main.mouseItem.type == inv[slot].type)
				{
					Item item6 = Main.mouseItem;
					item6.stack = item6.stack + 1;
					inv[slot].SetDefaults(0, false);
					Main.PlaySound(7, -1, -1, 1);
				}
			}
			else if (context == 15)
			{
				flag1 = true;
				Chest chest = Main.instance.shop[Main.npcShop];
				if (Main.stackSplit <= 1 && Main.mouseRight && inv[slot].type > 0 && (Main.mouseItem.IsTheSameAs(inv[slot]) || Main.mouseItem.type == 0))
				{
					int num2 = Main.superFastStack + 1;
					for (int j = 0; j < num2; j++)
					{
						if ((Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0) && player.BuyItem(inv[slot].@value) && inv[slot].stack > 0)
						{
							if (j == 0)
							{
								Main.PlaySound(18, -1, -1, 1);
							}
							if (Main.mouseItem.type == 0)
							{
								Main.mouseItem.netDefaults(inv[slot].netID);
								if (inv[slot].prefix != 0)
								{
									Main.mouseItem.Prefix((int)inv[slot].prefix);
								}
								Main.mouseItem.stack = 0;
							}
							Item item7 = Main.mouseItem;
							item7.stack = item7.stack + 1;
							if (Main.stackSplit != 0)
							{
								Main.stackSplit = Main.stackDelay;
							}
							else
							{
								Main.stackSplit = 15;
							}
							if (inv[slot].buyOnce)
							{
								Item item8 = inv[slot];
								int num3 = item8.stack - 1;
								int num4 = num3;
								item8.stack = num3;
								if (num4 <= 0)
								{
									inv[slot].SetDefaults(0, false);
								}
							}
						}
					}
				}
			}
			if (flag1)
			{
				return;
			}
			if ((context == 0 || context == 4 || context == 3) && Main.mouseRight && Main.mouseRightRelease && inv[slot].maxStack == 1)
			{
				if (inv[slot].dye > 0)
				{
					inv[slot] = ItemSlot.DyeSwap(inv[slot], out flag);
					if (flag)
					{
						Main.EquipPageSelected = 0;
						AchievementsHelper.HandleOnEquip(player, inv[slot], 12);
					}
				}
				else if (Main.projHook[inv[slot].shoot])
				{
					inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 4, out flag);
					if (flag)
					{
						Main.EquipPageSelected = 2;
						AchievementsHelper.HandleOnEquip(player, inv[slot], 16);
					}
				}
				else if (inv[slot].mountType != -1 && !MountID.Sets.Cart[inv[slot].mountType])
				{
					inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 3, out flag);
					if (flag)
					{
						Main.EquipPageSelected = 2;
						AchievementsHelper.HandleOnEquip(player, inv[slot], 17);
					}
				}
				else if (inv[slot].mountType != -1 && MountID.Sets.Cart[inv[slot].mountType])
				{
					inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 2, out flag);
					if (flag)
					{
						Main.EquipPageSelected = 2;
					}
				}
				else if (inv[slot].buffType > 0 && Main.lightPet[inv[slot].buffType])
				{
					inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 1, out flag);
					if (flag)
					{
						Main.EquipPageSelected = 2;
					}
				}
				else if (inv[slot].buffType <= 0 || !Main.vanityPet[inv[slot].buffType])
				{
					inv[slot] = ItemSlot.ArmorSwap(inv[slot], out flag);
					if (flag)
					{
						Main.EquipPageSelected = 0;
						AchievementsHelper.HandleOnEquip(player, inv[slot], 8);
					}
				}
				else
				{
					inv[slot] = ItemSlot.EquipSwap(inv[slot], player.miscEquips, 0, out flag);
					if (flag)
					{
						Main.EquipPageSelected = 2;
					}
				}
				Recipe.FindRecipes();
				if (context == 3 && Main.netMode == 1)
				{
					NetMessage.SendData(32, -1, -1, "", player.chest, (float)slot, 0f, 0f, 0, 0, 0);
					return;
				}
			}
			else if (Main.stackSplit <= 1 && Main.mouseRight)
			{
				bool flag3 = true;
				if (context == 0 && inv[slot].maxStack <= 1)
				{
					flag3 = false;
				}
				if (context == 3 && inv[slot].maxStack <= 1)
				{
					flag3 = false;
				}
				if (context == 4 && inv[slot].maxStack <= 1)
				{
					flag3 = false;
				}
				if (flag3 && (Main.mouseItem.IsTheSameAs(inv[slot]) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
				{
					if (Main.mouseItem.type == 0)
					{
						Main.mouseItem = inv[slot].Clone();
						Main.mouseItem.stack = 0;
						if (!inv[slot].favorited || inv[slot].maxStack != 1)
						{
							Main.mouseItem.favorited = false;
						}
						else
						{
							Main.mouseItem.favorited = true;
						}
					}
					Item item9 = Main.mouseItem;
					item9.stack = item9.stack + 1;
					Item item10 = inv[slot];
					item10.stack = item10.stack - 1;
					if (inv[slot].stack <= 0)
					{
						inv[slot] = new Item();
					}
					Recipe.FindRecipes();
					Main.soundInstanceMenuTick.Stop();
					Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
					Main.PlaySound(12, -1, -1, 1);
					if (Main.stackSplit != 0)
					{
						Main.stackSplit = Main.stackDelay;
					}
					else
					{
						Main.stackSplit = 15;
					}
					if (context == 3 && Main.netMode == 1)
					{
						NetMessage.SendData(32, -1, -1, "", player.chest, (float)slot, 0f, 0f, 0, 0, 0);
					}
				}
			}
		}

		public class Context
		{
			public const int InventoryItem = 0;

			public const int InventoryCoin = 1;

			public const int InventoryAmmo = 2;

			public const int ChestItem = 3;

			public const int BankItem = 4;

			public const int PrefixItem = 5;

			public const int TrashItem = 6;

			public const int GuideItem = 7;

			public const int EquipArmor = 8;

			public const int EquipArmorVanity = 9;

			public const int EquipAccessory = 10;

			public const int EquipAccessoryVanity = 11;

			public const int EquipDye = 12;

			public const int HotbarItem = 13;

			public const int ChatItem = 14;

			public const int ShopItem = 15;

			public const int EquipGrapple = 16;

			public const int EquipMount = 17;

			public const int EquipMinecart = 18;

			public const int EquipPet = 19;

			public const int EquipLight = 20;

			public const int MouseItem = 21;

			public const int CraftingMaterial = 22;

			public const int Count = 23;

			public Context()
			{
			}
		}
	}
}