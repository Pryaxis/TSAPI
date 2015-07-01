using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.UI.Chat;

namespace Terraria.UI
{
	public class ChestUI
	{
		public const float buttonScaleMinimum = 0.75f;

		public const float buttonScaleMaximum = 1f;

		public static float[] ButtonScale;

		public static bool[] ButtonHovered;

		static ChestUI()
		{
			ChestUI.ButtonScale = new float[6];
			ChestUI.ButtonHovered = new bool[6];
		}

		public ChestUI()
		{
		}

		public static void DepositAll()
		{
			Player player = Main.player[Main.myPlayer];
			if (player.chest > -1)
			{
				ChestUI.MoveCoins(player.inventory, Main.chest[player.chest].item);
			}
			else if (player.chest != -3)
			{
				ChestUI.MoveCoins(player.inventory, player.bank.item);
			}
			else
			{
				ChestUI.MoveCoins(player.inventory, player.bank2.item);
			}
			for (int i = 49; i >= 10; i--)
			{
				if (player.inventory[i].stack > 0 && player.inventory[i].type > 0 && !player.inventory[i].favorited)
				{
					if (player.inventory[i].maxStack > 1)
					{
						for (int j = 0; j < 40; j++)
						{
							if (player.chest > -1)
							{
								Chest chest = Main.chest[player.chest];
								if (chest.item[j].stack < chest.item[j].maxStack && player.inventory[i].IsTheSameAs(chest.item[j]))
								{
									int num = player.inventory[i].stack;
									if (player.inventory[i].stack + chest.item[j].stack > chest.item[j].maxStack)
									{
										num = chest.item[j].maxStack - chest.item[j].stack;
									}
									Item item = player.inventory[i];
									item.stack = item.stack - num;
									Item item1 = chest.item[j];
									item1.stack = item1.stack + num;
									Main.PlaySound(7, -1, -1, 1);
									if (player.inventory[i].stack > 0)
									{
										if (chest.item[j].type == 0)
										{
											chest.item[j] = player.inventory[i].Clone();
											player.inventory[i].SetDefaults(0, false);
										}
										if (Main.netMode == 1)
										{
											NetMessage.SendData(32, -1, -1, "", player.chest, (float)j, 0f, 0f, 0, 0, 0);
										}
									}
									else
									{
										player.inventory[i].SetDefaults(0, false);
										if (Main.netMode != 1)
										{
											break;
										}
										NetMessage.SendData(32, -1, -1, "", player.chest, (float)j, 0f, 0f, 0, 0, 0);
										break;
									}
								}
							}
							else if (player.chest == -3)
							{
								if (player.bank2.item[j].stack < player.bank2.item[j].maxStack && player.inventory[i].IsTheSameAs(player.bank2.item[j]))
								{
									int num1 = player.inventory[i].stack;
									if (player.inventory[i].stack + player.bank2.item[j].stack > player.bank2.item[j].maxStack)
									{
										num1 = player.bank2.item[j].maxStack - player.bank2.item[j].stack;
									}
									Item item2 = player.inventory[i];
									item2.stack = item2.stack - num1;
									Item item3 = player.bank2.item[j];
									item3.stack = item3.stack + num1;
									Main.PlaySound(7, -1, -1, 1);
									if (player.inventory[i].stack <= 0)
									{
										player.inventory[i].SetDefaults(0, false);
										break;
									}
									else if (player.bank2.item[j].type == 0)
									{
										player.bank2.item[j] = player.inventory[i].Clone();
										player.inventory[i].SetDefaults(0, false);
									}
								}
							}
							else if (player.bank.item[j].stack < player.bank.item[j].maxStack && player.inventory[i].IsTheSameAs(player.bank.item[j]))
							{
								int num2 = player.inventory[i].stack;
								if (player.inventory[i].stack + player.bank.item[j].stack > player.bank.item[j].maxStack)
								{
									num2 = player.bank.item[j].maxStack - player.bank.item[j].stack;
								}
								Item item4 = player.inventory[i];
								item4.stack = item4.stack - num2;
								Item item5 = player.bank.item[j];
								item5.stack = item5.stack + num2;
								Main.PlaySound(7, -1, -1, 1);
								if (player.inventory[i].stack <= 0)
								{
									player.inventory[i].SetDefaults(0, false);
									break;
								}
								else if (player.bank.item[j].type == 0)
								{
									player.bank.item[j] = player.inventory[i].Clone();
									player.inventory[i].SetDefaults(0, false);
								}
							}
						}
					}
					if (player.inventory[i].stack > 0)
					{
						if (player.chest > -1)
						{
							int num3 = 0;
							while (num3 < 40)
							{
								if (Main.chest[player.chest].item[num3].stack != 0)
								{
									num3++;
								}
								else
								{
									Main.PlaySound(7, -1, -1, 1);
									Main.chest[player.chest].item[num3] = player.inventory[i].Clone();
									player.inventory[i].SetDefaults(0, false);
									if (Main.netMode != 1)
									{
										break;
									}
									NetMessage.SendData(32, -1, -1, "", player.chest, (float)num3, 0f, 0f, 0, 0, 0);
									break;
								}
							}
						}
						else if (player.chest != -3)
						{
							int num4 = 0;
							while (num4 < 40)
							{
								if (player.bank.item[num4].stack != 0)
								{
									num4++;
								}
								else
								{
									Main.PlaySound(7, -1, -1, 1);
									player.bank.item[num4] = player.inventory[i].Clone();
									player.inventory[i].SetDefaults(0, false);
									break;
								}
							}
						}
						else
						{
							int num5 = 0;
							while (num5 < 40)
							{
								if (player.bank2.item[num5].stack != 0)
								{
									num5++;
								}
								else
								{
									Main.PlaySound(7, -1, -1, 1);
									player.bank2.item[num5] = player.inventory[i].Clone();
									player.inventory[i].SetDefaults(0, false);
									break;
								}
							}
						}
					}
				}
			}
		}

		public static void Draw(SpriteBatch spritebatch)
		{
			if (Main.player[Main.myPlayer].chest == -1 || Main.recBigList)
			{
				for (int i = 0; i < 6; i++)
				{
					ChestUI.ButtonScale[i] = 0.75f;
					ChestUI.ButtonHovered[i] = false;
				}
				return;
			}
			Main.inventoryScale = 0.755f;
			if (Utils.FloatIntersect((float)Main.mouseX, (float)Main.mouseY, 0f, 0f, 73f, (float)Main.instance.invBottom, 560f * Main.inventoryScale, 224f * Main.inventoryScale))
			{
				Main.player[Main.myPlayer].mouseInterface = true;
			}
			ChestUI.DrawName(spritebatch);
			ChestUI.DrawButtons(spritebatch);
			ChestUI.DrawSlots(spritebatch);
		}

		private static void DrawButton(SpriteBatch spriteBatch, int ID, int X, int Y)
		{
			Player player = Main.player[Main.myPlayer];
			if (ID == 4 && player.chest < -1 || ID == 5 && !Main.editChest)
			{
				ChestUI.UpdateHover(ID, false);
				return;
			}
			Y = Y + ID * 26;
			float buttonScale = ChestUI.ButtonScale[ID];
			string str = "";
			switch (ID)
			{
				case 0:
				{
					str = Lang.inter[29];
					break;
				}
				case 1:
				{
					str = Lang.inter[30];
					break;
				}
				case 2:
				{
					str = Lang.inter[31];
					break;
				}
				case 3:
				{
					str = Lang.inter[82];
					break;
				}
				case 4:
				{
					str = Lang.inter[(Main.editChest ? 47 : 61)];
					break;
				}
				case 5:
				{
					str = Lang.inter[63];
					break;
				}
			}
			Vector2 vector2 = Main.fontMouseText.MeasureString(str);
			Color color = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor) * buttonScale;
			color = (Color.White * 0.97f) * (1f - (255f - (float)Main.mouseTextColor) / 255f * 0.5f);
			color.A = 255;
			X = X + (int)(vector2.X * buttonScale / 2f);
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontMouseText, str, new Vector2((float)X, (float)Y), color, 0f, vector2 / 2f, new Vector2(buttonScale), -1f, 1.5f);
			vector2 = vector2 * buttonScale;
			if (!Utils.FloatIntersect((float)Main.mouseX, (float)Main.mouseY, 0f, 0f, (float)X - vector2.X / 2f, (float)Y - vector2.Y / 2f, vector2.X, vector2.Y))
			{
				ChestUI.UpdateHover(ID, false);
				return;
			}
			ChestUI.UpdateHover(ID, true);
			player.mouseInterface = true;
			if (!Main.mouseLeft || !Main.mouseLeftRelease)
			{
				return;
			}
			switch (ID)
			{
				case 0:
				{
					ChestUI.LootAll();
					break;
				}
				case 1:
				{
					ChestUI.DepositAll();
					break;
				}
				case 2:
				{
					ChestUI.QuickStack();
					break;
				}
				case 3:
				{
					ChestUI.Restock();
					break;
				}
				case 4:
				{
					ChestUI.RenameChest();
					break;
				}
				case 5:
				{
					ChestUI.RenameChestCancel();
					break;
				}
			}
			Recipe.FindRecipes();
		}

		private static void DrawButtons(SpriteBatch spritebatch)
		{
			for (int i = 0; i < 6; i++)
			{
				ChestUI.DrawButton(spritebatch, i, 506, Main.instance.invBottom + 40);
			}
		}

		private static void DrawName(SpriteBatch spritebatch)
		{
			int num;
			Player player = Main.player[Main.myPlayer];
			string empty = string.Empty;
			if (Main.editChest)
			{
				empty = Main.npcChatText;
				Main main = Main.instance;
				main.textBlinkerCount = main.textBlinkerCount + 1;
				if (Main.instance.textBlinkerCount >= 20)
				{
					if (Main.instance.textBlinkerState != 0)
					{
						Main.instance.textBlinkerState = 0;
					}
					else
					{
						Main.instance.textBlinkerState = 1;
					}
					Main.instance.textBlinkerCount = 0;
				}
				if (Main.instance.textBlinkerState == 1)
				{
					empty = string.Concat(empty, "|");
				}
			}
			else if (player.chest > -1)
			{
				if (Main.chest[player.chest] == null)
				{
					Main.chest[player.chest] = new Chest(false);
				}
				Chest chest = Main.chest[player.chest];
				if (chest.name != "")
				{
					empty = chest.name;
				}
				else if (Main.tile[player.chestX, player.chestY].type == 21)
				{
					empty = Lang.chestType[Main.tile[player.chestX, player.chestY].frameX / 36];
				}
				else if (Main.tile[player.chestX, player.chestY].type == 88)
				{
					empty = Lang.dresserType[Main.tile[player.chestX, player.chestY].frameX / 54];
				}
			}
			else if (player.chest == -2)
			{
				empty = Lang.inter[32];
			}
			else if (player.chest == -3)
			{
				empty = Lang.inter[33];
			}
			Color color = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
			color = Color.White * (1f - (255f - (float)Main.mouseTextColor) / 255f * 0.5f);
			color.A = 255;
			Utils.WordwrapString(empty, Main.fontMouseText, 200, 1, out num);
			num++;
			for (int i = 0; i < num; i++)
			{
				ChatManager.DrawColorCodedStringWithShadow(spritebatch, Main.fontMouseText, empty, new Vector2(504f, (float)(Main.instance.invBottom + i * 26)), color, 0f, Vector2.Zero, Vector2.One, -1f, 1.5f);
			}
		}

		private static void DrawSlots(SpriteBatch spriteBatch)
		{
			Player player = Main.player[Main.myPlayer];
			int num = 0;
			Item[] itemArray = null;
			if (player.chest > -1)
			{
				num = 3;
				itemArray = Main.chest[player.chest].item;
			}
			if (player.chest == -2)
			{
				num = 4;
				itemArray = player.bank.item;
			}
			if (player.chest == -3)
			{
				num = 4;
				itemArray = player.bank2.item;
			}
			Main.inventoryScale = 0.755f;
			if (Utils.FloatIntersect((float)Main.mouseX, (float)Main.mouseY, 0f, 0f, 73f, (float)Main.instance.invBottom, 560f * Main.inventoryScale, 224f * Main.inventoryScale))
			{
				player.mouseInterface = true;
			}
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int num1 = (int)(73f + (float)(i * 56) * Main.inventoryScale);
					int num2 = (int)((float)Main.instance.invBottom + (float)(j * 56) * Main.inventoryScale);
					int num3 = i + j * 10;
					Color color = new Color(100, 100, 100, 100);
					if (Utils.FloatIntersect((float)Main.mouseX, (float)Main.mouseY, 0f, 0f, (float)num1, (float)num2, (float)Main.inventoryBackTexture.Width * Main.inventoryScale, (float)Main.inventoryBackTexture.Height * Main.inventoryScale))
					{
						player.mouseInterface = true;
						ItemSlot.Handle(itemArray, num, num3);
					}
					Vector2 vector2 = new Vector2((float)num1, (float)num2);
					Color color1 = new Color();
					ItemSlot.Draw(spriteBatch, itemArray, num, num3, vector2, color1);
				}
			}
		}

		public static void LootAll()
		{
			Player center = Main.player[Main.myPlayer];
			if (center.chest > -1)
			{
				Chest item = Main.chest[center.chest];
				for (int i = 0; i < 40; i++)
				{
					if (item.item[i].type > 0)
					{
						item.item[i].position = center.Center;
						item.item[i] = center.GetItem(Main.myPlayer, item.item[i], false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(32, -1, -1, "", center.chest, (float)i, 0f, 0f, 0, 0, 0);
						}
					}
				}
				return;
			}
			if (center.chest == -3)
			{
				for (int j = 0; j < 40; j++)
				{
					if (center.bank2.item[j].type > 0)
					{
						center.bank2.item[j].position = center.Center;
						center.bank2.item[j] = center.GetItem(Main.myPlayer, center.bank2.item[j], false, false);
					}
				}
				return;
			}
			for (int k = 0; k < 40; k++)
			{
				if (center.bank.item[k].type > 0)
				{
					center.bank.item[k].position = center.Center;
					center.bank.item[k] = center.GetItem(Main.myPlayer, center.bank.item[k], false, false);
				}
			}
		}

		public static void MoveCoins(Item[] pInv, Item[] cInv)
		{
			int[] numArray = new int[4];
			List<int> nums = new List<int>();
			List<int> nums1 = new List<int>();
			bool flag = false;
			int[] numArray1 = new int[40];
			for (int i = 0; i < (int)cInv.Length; i++)
			{
				numArray1[i] = -1;
				if (cInv[i].stack < 1 || cInv[i].type < 1)
				{
					nums1.Add(i);
					cInv[i] = new Item();
				}
				if (cInv[i] != null && cInv[i].stack > 0)
				{
					int num = 0;
					if (cInv[i].type == 71)
					{
						num = 1;
					}
					if (cInv[i].type == 72)
					{
						num = 2;
					}
					if (cInv[i].type == 73)
					{
						num = 3;
					}
					if (cInv[i].type == 74)
					{
						num = 4;
					}
					numArray1[i] = num - 1;
					if (num > 0)
					{
						numArray[num - 1] = numArray[num - 1] + cInv[i].stack;
						nums1.Add(i);
						cInv[i] = new Item();
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return;
			}
			Main.PlaySound(7, -1, -1, 1);
			for (int j = 0; j < (int)pInv.Length; j++)
			{
				if (j != 58 && pInv[j] != null && pInv[j].stack > 0)
				{
					int num1 = 0;
					if (pInv[j].type == 71)
					{
						num1 = 1;
					}
					if (pInv[j].type == 72)
					{
						num1 = 2;
					}
					if (pInv[j].type == 73)
					{
						num1 = 3;
					}
					if (pInv[j].type == 74)
					{
						num1 = 4;
					}
					if (num1 > 0)
					{
						numArray[num1 - 1] = numArray[num1 - 1] + pInv[j].stack;
						nums.Add(j);
						pInv[j] = new Item();
					}
				}
			}
			for (int k = 0; k < 3; k++)
			{
				while (numArray[k] >= 100)
				{
					numArray[k] = numArray[k] - 100;
					numArray[k + 1] = numArray[k + 1] + 1;
				}
			}
			for (int l = 0; l < 40; l++)
			{
				if (numArray1[l] >= 0 && cInv[l].type == 0)
				{
					int num2 = l;
					int num3 = numArray1[l];
					if (numArray[num3] > 0)
					{
						cInv[num2].SetDefaults(71 + num3, false);
						cInv[num2].stack = numArray[num3];
						if (cInv[num2].stack > cInv[num2].maxStack)
						{
							cInv[num2].stack = cInv[num2].maxStack;
						}
						numArray[num3] = numArray[num3] - cInv[num2].stack;
						numArray1[l] = -1;
					}
					if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
					{
						NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num2, 0f, 0f, 0, 0, 0);
					}
					nums1.Remove(num2);
				}
			}
			for (int m = 0; m < 40; m++)
			{
				if (numArray1[m] >= 0 && cInv[m].type == 0)
				{
					int num4 = m;
					int num5 = 3;
					while (num5 >= 0)
					{
						if (numArray[num5] <= 0)
						{
							num5--;
						}
						else
						{
							cInv[num4].SetDefaults(71 + num5, false);
							cInv[num4].stack = numArray[num5];
							if (cInv[num4].stack > cInv[num4].maxStack)
							{
								cInv[num4].stack = cInv[num4].maxStack;
							}
							numArray[num5] = numArray[num5] - cInv[num4].stack;
							numArray1[m] = -1;
							break;
						}
					}
					if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
					{
						NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)num4, 0f, 0f, 0, 0, 0);
					}
					nums1.Remove(num4);
				}
			}
			while (nums1.Count > 0)
			{
				int item = nums1[0];
				int num6 = 3;
				while (num6 >= 0)
				{
					if (numArray[num6] <= 0)
					{
						num6--;
					}
					else
					{
						cInv[item].SetDefaults(71 + num6, false);
						cInv[item].stack = numArray[num6];
						if (cInv[item].stack > cInv[item].maxStack)
						{
							cInv[item].stack = cInv[item].maxStack;
						}
						numArray[num6] = numArray[num6] - cInv[item].stack;
						break;
					}
				}
				if (Main.netMode == 1 && Main.player[Main.myPlayer].chest > -1)
				{
					NetMessage.SendData(32, -1, -1, "", Main.player[Main.myPlayer].chest, (float)nums1[0], 0f, 0f, 0, 0, 0);
				}
				nums1.RemoveAt(0);
			}
			while (nums.Count > 0)
			{
				int item1 = nums[0];
				for (int n = 3; n >= 0; n--)
				{
					if (numArray[n] > 0)
					{
						pInv[item1].SetDefaults(71 + n, false);
						pInv[item1].stack = numArray[n];
						if (pInv[item1].stack > pInv[item1].maxStack)
						{
							pInv[item1].stack = pInv[item1].maxStack;
						}
						numArray[n] = numArray[n] - pInv[item1].stack;
					}
				}
				nums.RemoveAt(0);
			}
		}

		public static void QuickStack()
		{
			Player player = Main.player[Main.myPlayer];
			if (player.chest == -3)
			{
				ChestUI.MoveCoins(player.inventory, player.bank2.item);
			}
			else if (player.chest == -2)
			{
				ChestUI.MoveCoins(player.inventory, player.bank.item);
			}
			Item[] item = player.inventory;
			Item[] itemArray = player.bank.item;
			if (player.chest > -1)
			{
				itemArray = Main.chest[player.chest].item;
			}
			else if (player.chest == -2)
			{
				itemArray = player.bank.item;
			}
			else if (player.chest == -3)
			{
				itemArray = player.bank2.item;
			}
			List<int> nums = new List<int>();
			List<int> nums1 = new List<int>();
			List<int> nums2 = new List<int>();
			Dictionary<int, int> nums3 = new Dictionary<int, int>();
			List<int> nums4 = new List<int>();
			bool[] flagArray = new bool[(int)itemArray.Length];
			for (int i = 0; i < 40; i++)
			{
				if (itemArray[i].type > 0 && itemArray[i].stack > 0)
				{
					nums1.Add(i);
					nums.Add(itemArray[i].netID);
				}
				if (itemArray[i].type == 0 || itemArray[i].stack <= 0)
				{
					nums2.Add(i);
				}
			}
			int num = 50;
			if (player.chest <= -2)
			{
				num = num + 4;
			}
			for (int j = 0; j < num; j++)
			{
				if (nums.Contains(item[j].netID) && !item[j].favorited)
				{
					nums3.Add(j, item[j].netID);
				}
			}
			for (int k = 0; k < nums1.Count; k++)
			{
				int item1 = nums1[k];
				int num1 = itemArray[item1].netID;
				foreach (KeyValuePair<int, int> keyValuePair in nums3)
				{
					if (keyValuePair.Value != num1 || item[keyValuePair.Key].netID != num1)
					{
						continue;
					}
					int num2 = item[keyValuePair.Key].stack;
					int num3 = itemArray[item1].maxStack - itemArray[item1].stack;
					if (num3 == 0)
					{
						break;
					}
					if (num2 > num3)
					{
						num2 = num3;
					}
					Main.PlaySound(7, -1, -1, 1);
					Item item2 = itemArray[item1];
					item2.stack = item2.stack + num2;
					Item item3 = item[keyValuePair.Key];
					item3.stack = item3.stack - num2;
					if (item[keyValuePair.Key].stack == 0)
					{
						item[keyValuePair.Key].SetDefaults(0, false);
					}
					flagArray[item1] = true;
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair1 in nums3)
			{
				if (item[keyValuePair1.Key].stack != 0)
				{
					continue;
				}
				nums4.Add(keyValuePair1.Key);
			}
			foreach (int num4 in nums4)
			{
				nums3.Remove(num4);
			}
			for (int l = 0; l < nums2.Count; l++)
			{
				int item4 = nums2[l];
				bool flag = true;
				int value = itemArray[item4].netID;
				foreach (KeyValuePair<int, int> keyValuePair2 in nums3)
				{
					if ((keyValuePair2.Value != value || item[keyValuePair2.Key].netID != value) && (!flag || item[keyValuePair2.Key].stack <= 0))
					{
						continue;
					}
					Main.PlaySound(7, -1, -1, 1);
					if (!flag)
					{
						int num5 = item[keyValuePair2.Key].stack;
						int num6 = itemArray[item4].maxStack - itemArray[item4].stack;
						if (num6 == 0)
						{
							break;
						}
						if (num5 > num6)
						{
							num5 = num6;
						}
						Item item5 = itemArray[item4];
						item5.stack = item5.stack + num5;
						Item item6 = item[keyValuePair2.Key];
						item6.stack = item6.stack - num5;
						if (item[keyValuePair2.Key].stack == 0)
						{
							item[keyValuePair2.Key] = new Item();
						}
					}
					else
					{
						value = keyValuePair2.Value;
						itemArray[item4] = item[keyValuePair2.Key];
						item[keyValuePair2.Key] = new Item();
					}
					flagArray[item4] = true;
					flag = false;
				}
			}
			if (Main.netMode == 1 && player.chest >= 0)
			{
				for (int m = 0; m < (int)flagArray.Length; m++)
				{
					NetMessage.SendData(32, -1, -1, "", player.chest, (float)m, 0f, 0f, 0, 0, 0);
				}
			}
			nums.Clear();
			nums1.Clear();
			nums2.Clear();
			nums3.Clear();
			nums4.Clear();
		}

		public static void RenameChest()
		{
			Player player = Main.player[Main.myPlayer];
			if (Main.editChest)
			{
				Main.PlaySound(12, -1, -1, 1);
				Main.editChest = false;
				int num = player.chest;
				if (Main.npcChatText == Main.defaultChestName)
				{
					Main.npcChatText = "";
				}
				if (Main.chest[num].name != Main.npcChatText)
				{
					Main.chest[num].name = Main.npcChatText;
					if (Main.netMode == 1)
					{
						player.editedChestName = true;
					}
				}
				return;
			}
			Main.npcChatText = Main.chest[player.chest].name;
			if (Main.tile[player.chestX, player.chestY].type == 21)
			{
				Main.defaultChestName = Lang.chestType[Main.tile[player.chestX, player.chestY].frameX / 36];
			}
			if (Main.tile[player.chestX, player.chestY].type == 88)
			{
				Main.defaultChestName = Lang.dresserType[Main.tile[player.chestX, player.chestY].frameX / 54];
			}
			if (Main.npcChatText == "")
			{
				Main.npcChatText = Main.defaultChestName;
			}
			Main.editChest = true;
			Main.clrInput();
		}

		public static void RenameChestCancel()
		{
			Main.PlaySound(12, -1, -1, 1);
			Main.editChest = false;
			Main.npcChatText = string.Empty;
		}

		public static void Restock()
		{
			Player player = Main.player[Main.myPlayer];
			Item[] itemArray = player.inventory;
			Item[] item = player.bank.item;
			if (player.chest > -1)
			{
				item = Main.chest[player.chest].item;
			}
			else if (player.chest == -2)
			{
				item = player.bank.item;
			}
			else if (player.chest == -3)
			{
				item = player.bank2.item;
			}
			HashSet<int> nums = new HashSet<int>();
			List<int> nums1 = new List<int>();
			List<int> nums2 = new List<int>();
			for (int i = 57; i >= 0; i--)
			{
				if ((i < 50 || i >= 54) && (itemArray[i].type < 71 || itemArray[i].type > 74))
				{
					if (itemArray[i].stack > 0 && itemArray[i].maxStack > 1 && itemArray[i].prefix == 0)
					{
						nums.Add(itemArray[i].netID);
						if (itemArray[i].stack < itemArray[i].maxStack)
						{
							nums1.Add(i);
						}
					}
					else if (itemArray[i].stack == 0 || itemArray[i].netID == 0 || itemArray[i].type == 0)
					{
						nums2.Add(i);
					}
				}
			}
			bool flag = false;
			for (int j = 0; j < (int)item.Length; j++)
			{
				if (item[j].stack >= 1 && item[j].prefix == 0 && nums.Contains(item[j].netID))
				{
					bool flag1 = false;
					for (int k = 0; k < nums1.Count; k++)
					{
						int num = nums1[k];
						int num1 = 0;
						if (num >= 50)
						{
							num1 = 2;
						}
						if (itemArray[num].netID == item[j].netID && ItemSlot.PickItemMovementAction(itemArray, num1, num, item[j]) != -1)
						{
							int num2 = item[j].stack;
							if (itemArray[num].maxStack - itemArray[num].stack < num2)
							{
								num2 = itemArray[num].maxStack - itemArray[num].stack;
							}
							Item item1 = itemArray[num];
							item1.stack = item1.stack + num2;
							Item item2 = item[j];
							item2.stack = item2.stack - num2;
							flag = true;
							if (itemArray[num].stack == itemArray[num].maxStack)
							{
								nums1.RemoveAt(k);
								k--;
							}
							if (item[j].stack == 0)
							{
								item[j] = new Item();
								flag1 = true;
								break;
							}
						}
					}
					if (!flag1 && nums2.Count > 0 && item[j].ammo != 0)
					{
						int num3 = 0;
						while (num3 < nums2.Count)
						{
							int num4 = 0;
							if (nums2[num3] >= 50)
							{
								num4 = 2;
							}
							if (ItemSlot.PickItemMovementAction(itemArray, num4, nums2[num3], item[j]) == -1)
							{
								num3++;
							}
							else
							{
								Utils.Swap<Item>(ref itemArray[nums2[num3]], ref item[j]);
								nums1.Add(nums2[num3]);
								nums2.RemoveAt(num3);
								flag = true;
								break;
							}
						}
					}
				}
			}
			if (flag)
			{
				Main.PlaySound(7, -1, -1, 1);
			}
		}

		public static void UpdateHover(int ID, bool hovering)
		{
			if (!hovering)
			{
				ChestUI.ButtonHovered[ID] = false;
				ChestUI.ButtonScale[ID] = ChestUI.ButtonScale[ID] - 0.05f;
				if (ChestUI.ButtonScale[ID] < 0.75f)
				{
					ChestUI.ButtonScale[ID] = 0.75f;
				}
			}
			else
			{
				if (!ChestUI.ButtonHovered[ID])
				{
					Main.PlaySound(12, -1, -1, 1);
				}
				ChestUI.ButtonHovered[ID] = true;
				ChestUI.ButtonScale[ID] = ChestUI.ButtonScale[ID] + 0.05f;
				if (ChestUI.ButtonScale[ID] > 1f)
				{
					ChestUI.ButtonScale[ID] = 1f;
					return;
				}
			}
		}

		public class ButtonID
		{
			public const int LootAll = 0;

			public const int DepositAll = 1;

			public const int QuickStack = 2;

			public const int Restock = 3;

			public const int RenameChest = 4;

			public const int RenameChestCancel = 5;

			public const int Count = 6;

			public ButtonID()
			{
			}
		}
	}
}