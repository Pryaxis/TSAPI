using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria
{
	public class ItemText
	{
		public Vector2 position;

		public Vector2 velocity;

		public float alpha;

		public int alphaDir = 1;

		public string name;

		public int stack;

		public float scale = 1f;

		public float rotation;

		public Color color;

		public bool active;

		public int lifeTime;

		public static int activeTime;

		public static int numActive;

		public bool NoStack;

		public bool coinText;

		public int coinValue;

		public bool expert;

		static ItemText()
		{
			ItemText.activeTime = 60;
		}

		public ItemText()
		{
		}

		public static void NewText(Item newItem, int stack, bool noStack = false, bool longText = false)
		{
			bool flag = (newItem.type < 71 ? false : newItem.type <= 74);
			if (!Main.showItemText)
			{
				return;
			}
			if (newItem.name == null || !newItem.active)
			{
				return;
			}
			if (Main.netMode == 2)
			{
				return;
			}
			for (int i = 0; i < 20; i++)
			{
				if (Main.itemText[i].active && (Main.itemText[i].name == newItem.AffixName() || flag && Main.itemText[i].coinText) && !Main.itemText[i].NoStack && !noStack)
				{
					object[] objArray = new object[] { newItem.name, " (", Main.itemText[i].stack + stack, ")" };
					string name = string.Concat(objArray);
					string str = newItem.name;
					if (Main.itemText[i].stack > 1)
					{
						object obj = str;
						object[] objArray1 = new object[] { obj, " (", Main.itemText[i].stack, ")" };
						str = string.Concat(objArray1);
					}
					Vector2 vector2 = Main.fontMouseText.MeasureString(str);
					vector2 = Main.fontMouseText.MeasureString(name);
					if (Main.itemText[i].lifeTime < 0)
					{
						Main.itemText[i].scale = 1f;
					}
					if (Main.itemText[i].lifeTime < 60)
					{
						Main.itemText[i].lifeTime = 60;
					}
					if (flag && Main.itemText[i].coinText)
					{
						int num = 0;
						if (newItem.type == 71)
						{
							num = num + newItem.stack;
						}
						else if (newItem.type == 72)
						{
							num = num + 100 * newItem.stack;
						}
						else if (newItem.type == 73)
						{
							num = num + 10000 * newItem.stack;
						}
						else if (newItem.type == 74)
						{
							num = num + 1000000 * newItem.stack;
						}
						ItemText itemText = Main.itemText[i];
						itemText.coinValue = itemText.coinValue + num;
						name = ItemText.ValueToName(Main.itemText[i].coinValue);
						vector2 = Main.fontMouseText.MeasureString(name);
						Main.itemText[i].name = name;
						if (Main.itemText[i].coinValue >= 1000000)
						{
							if (Main.itemText[i].lifeTime < 300)
							{
								Main.itemText[i].lifeTime = 300;
							}
							Main.itemText[i].color = new Color(220, 220, 198);
						}
						else if (Main.itemText[i].coinValue >= 10000)
						{
							if (Main.itemText[i].lifeTime < 240)
							{
								Main.itemText[i].lifeTime = 240;
							}
							Main.itemText[i].color = new Color(224, 201, 92);
						}
						else if (Main.itemText[i].coinValue >= 100)
						{
							if (Main.itemText[i].lifeTime < 180)
							{
								Main.itemText[i].lifeTime = 180;
							}
							Main.itemText[i].color = new Color(181, 192, 193);
						}
						else if (Main.itemText[i].coinValue >= 1)
						{
							if (Main.itemText[i].lifeTime < 120)
							{
								Main.itemText[i].lifeTime = 120;
							}
							Main.itemText[i].color = new Color(246, 138, 96);
						}
					}
					ItemText itemText1 = Main.itemText[i];
					itemText1.stack = itemText1.stack + stack;
					Main.itemText[i].scale = 0f;
					Main.itemText[i].rotation = 0f;
					Main.itemText[i].position.X = newItem.position.X + (float)newItem.width * 0.5f - vector2.X * 0.5f;
					Main.itemText[i].position.Y = newItem.position.Y + (float)newItem.height * 0.25f - vector2.Y * 0.5f;
					Main.itemText[i].velocity.Y = -7f;
					if (Main.itemText[i].coinText)
					{
						Main.itemText[i].stack = 1;
					}
					return;
				}
			}
			int num1 = -1;
			int num2 = 0;
			while (num2 < 20)
			{
				if (Main.itemText[num2].active)
				{
					num2++;
				}
				else
				{
					num1 = num2;
					break;
				}
			}
			if (num1 == -1)
			{
				double y = (double)Main.bottomWorld;
				for (int j = 0; j < 20; j++)
				{
					if (y > (double)Main.itemText[j].position.Y)
					{
						num1 = j;
						y = (double)Main.itemText[j].position.Y;
					}
				}
			}
			if (num1 >= 0)
			{
				string str1 = newItem.AffixName();
				if (stack > 1)
				{
					object obj1 = str1;
					object[] objArray2 = new object[] { obj1, " (", stack, ")" };
					str1 = string.Concat(objArray2);
				}
				Vector2 vector21 = Main.fontMouseText.MeasureString(str1);
				Main.itemText[num1].alpha = 1f;
				Main.itemText[num1].alphaDir = -1;
				Main.itemText[num1].active = true;
				Main.itemText[num1].scale = 0f;
				Main.itemText[num1].NoStack = noStack;
				Main.itemText[num1].rotation = 0f;
				Main.itemText[num1].position.X = newItem.position.X + (float)newItem.width * 0.5f - vector21.X * 0.5f;
				Main.itemText[num1].position.Y = newItem.position.Y + (float)newItem.height * 0.25f - vector21.Y * 0.5f;
				Main.itemText[num1].color = Color.White;
				if (newItem.rare == 1)
				{
					Main.itemText[num1].color = new Color(150, 150, 255);
				}
				else if (newItem.rare == 2)
				{
					Main.itemText[num1].color = new Color(150, 255, 150);
				}
				else if (newItem.rare == 3)
				{
					Main.itemText[num1].color = new Color(255, 200, 150);
				}
				else if (newItem.rare == 4)
				{
					Main.itemText[num1].color = new Color(255, 150, 150);
				}
				else if (newItem.rare == 5)
				{
					Main.itemText[num1].color = new Color(255, 150, 255);
				}
				else if (newItem.rare == -11)
				{
					Main.itemText[num1].color = new Color(255, 175, 0);
				}
				else if (newItem.rare == -1)
				{
					Main.itemText[num1].color = new Color(130, 130, 130);
				}
				else if (newItem.rare == 6)
				{
					Main.itemText[num1].color = new Color(210, 160, 255);
				}
				else if (newItem.rare == 7)
				{
					Main.itemText[num1].color = new Color(150, 255, 10);
				}
				else if (newItem.rare == 8)
				{
					Main.itemText[num1].color = new Color(255, 255, 10);
				}
				else if (newItem.rare == 9)
				{
					Main.itemText[num1].color = new Color(5, 200, 255);
				}
				else if (newItem.rare == 10)
				{
					Main.itemText[num1].color = new Color(255, 40, 100);
				}
				else if (newItem.rare >= 11)
				{
					Main.itemText[num1].color = new Color(180, 40, 255);
				}
				Main.itemText[num1].expert = newItem.expert;
				Main.itemText[num1].name = newItem.AffixName();
				Main.itemText[num1].stack = stack;
				Main.itemText[num1].velocity.Y = -7f;
				Main.itemText[num1].lifeTime = 60;
				if (longText)
				{
					ItemText itemText2 = Main.itemText[num1];
					itemText2.lifeTime = itemText2.lifeTime * 5;
				}
				Main.itemText[num1].coinValue = 0;
				Main.itemText[num1].coinText = (newItem.type < 71 ? false : newItem.type <= 74);
				if (Main.itemText[num1].coinText)
				{
					if (newItem.type == 71)
					{
						ItemText itemText3 = Main.itemText[num1];
						itemText3.coinValue = itemText3.coinValue + Main.itemText[num1].stack;
					}
					else if (newItem.type == 72)
					{
						ItemText itemText4 = Main.itemText[num1];
						itemText4.coinValue = itemText4.coinValue + 100 * Main.itemText[num1].stack;
					}
					else if (newItem.type == 73)
					{
						ItemText itemText5 = Main.itemText[num1];
						itemText5.coinValue = itemText5.coinValue + 10000 * Main.itemText[num1].stack;
					}
					else if (newItem.type == 74)
					{
						ItemText itemText6 = Main.itemText[num1];
						itemText6.coinValue = itemText6.coinValue + 1000000 * Main.itemText[num1].stack;
					}
					Main.itemText[num1].ValueToName();
					Main.itemText[num1].stack = 1;
					int num3 = num1;
					if (Main.itemText[num3].coinValue >= 1000000)
					{
						if (Main.itemText[num3].lifeTime < 300)
						{
							Main.itemText[num3].lifeTime = 300;
						}
						Main.itemText[num3].color = new Color(220, 220, 198);
						return;
					}
					if (Main.itemText[num3].coinValue >= 10000)
					{
						if (Main.itemText[num3].lifeTime < 240)
						{
							Main.itemText[num3].lifeTime = 240;
						}
						Main.itemText[num3].color = new Color(224, 201, 92);
						return;
					}
					if (Main.itemText[num3].coinValue >= 100)
					{
						if (Main.itemText[num3].lifeTime < 180)
						{
							Main.itemText[num3].lifeTime = 180;
						}
						Main.itemText[num3].color = new Color(181, 192, 193);
						return;
					}
					if (Main.itemText[num3].coinValue >= 1)
					{
						if (Main.itemText[num3].lifeTime < 120)
						{
							Main.itemText[num3].lifeTime = 120;
						}
						Main.itemText[num3].color = new Color(246, 138, 96);
					}
				}
			}
		}

		public void Update(int whoAmI)
		{
			if (this.active)
			{
				ItemText itemText = this;
				itemText.alpha = itemText.alpha + (float)this.alphaDir * 0.01f;
				if ((double)this.alpha <= 0.7)
				{
					this.alpha = 0.7f;
					this.alphaDir = 1;
				}
				if (this.alpha >= 1f)
				{
					this.alpha = 1f;
					this.alphaDir = -1;
				}
				if (this.expert && this.expert)
				{
					this.color = new Color((int)Main.DiscoR, (int)Main.DiscoG, (int)Main.DiscoB, (int)Main.mouseTextColor);
				}
				bool flag = false;
				string str = this.name;
				if (this.stack > 1)
				{
					object obj = str;
					object[] objArray = new object[] { obj, " (", this.stack, ")" };
					str = string.Concat(objArray);
				}
				Vector2 y = Main.fontMouseText.MeasureString(str);
				y = y * this.scale;
				y.Y = y.Y * 0.8f;
				Rectangle rectangle = new Rectangle((int)(this.position.X - y.X / 2f), (int)(this.position.Y - y.Y / 2f), (int)y.X, (int)y.Y);
				for (int i = 0; i < 20; i++)
				{
					if (Main.itemText[i].active && i != whoAmI)
					{
						string str1 = Main.itemText[i].name;
						if (Main.itemText[i].stack > 1)
						{
							object obj1 = str1;
							object[] objArray1 = new object[] { obj1, " (", Main.itemText[i].stack, ")" };
							str1 = string.Concat(objArray1);
						}
						Vector2 vector2 = Main.fontMouseText.MeasureString(str1);
						vector2 = vector2 * Main.itemText[i].scale;
						vector2.Y = vector2.Y * 0.8f;
						Rectangle rectangle1 = new Rectangle((int)(Main.itemText[i].position.X - vector2.X / 2f), (int)(Main.itemText[i].position.Y - vector2.Y / 2f), (int)vector2.X, (int)vector2.Y);
						if (rectangle.Intersects(rectangle1) && (this.position.Y < Main.itemText[i].position.Y || this.position.Y == Main.itemText[i].position.Y && whoAmI < i))
						{
							flag = true;
							int num = ItemText.numActive;
							if (num > 3)
							{
								num = 3;
							}
							Main.itemText[i].lifeTime = ItemText.activeTime + 15 * num;
							this.lifeTime = ItemText.activeTime + 15 * num;
						}
					}
				}
				if (!flag)
				{
					this.velocity.Y = this.velocity.Y * 0.86f;
					if (this.scale == 1f)
					{
						this.velocity.Y = this.velocity.Y * 0.4f;
					}
				}
				else if (this.velocity.Y <= -6f)
				{
					this.velocity.Y = this.velocity.Y * 0.86f;
				}
				else
				{
					this.velocity.Y = this.velocity.Y - 0.2f;
				}
				this.velocity.X = this.velocity.X * 0.93f;
				ItemText itemText1 = this;
				itemText1.position = itemText1.position + this.velocity;
				ItemText itemText2 = this;
				itemText2.lifeTime = itemText2.lifeTime - 1;
				if (this.lifeTime <= 0)
				{
					ItemText itemText3 = this;
					itemText3.scale = itemText3.scale - 0.03f;
					if ((double)this.scale < 0.1)
					{
						this.active = false;
					}
					this.lifeTime = 0;
					return;
				}
				if (this.scale < 1f)
				{
					ItemText itemText4 = this;
					itemText4.scale = itemText4.scale + 0.1f;
				}
				if (this.scale > 1f)
				{
					this.scale = 1f;
				}
			}
		}

		public static void UpdateItemText()
		{
			int num = 0;
			for (int i = 0; i < 20; i++)
			{
				if (Main.itemText[i].active)
				{
					num++;
					Main.itemText[i].Update(i);
				}
			}
			ItemText.numActive = num;
		}

		private static string ValueToName(int coinValue)
		{
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			string str = "";
			int num4 = coinValue;
			while (num4 > 0)
			{
				if (num4 >= 1000000)
				{
					num4 = num4 - 1000000;
					num++;
				}
				else if (num4 >= 10000)
				{
					num4 = num4 - 10000;
					num1++;
				}
				else if (num4 < 100)
				{
					if (num4 < 1)
					{
						continue;
					}
					num4--;
					num3++;
				}
				else
				{
					num4 = num4 - 100;
					num2++;
				}
			}
			str = "";
			if (num > 0)
			{
				str = string.Concat(str, num, " Platinum ");
			}
			if (num1 > 0)
			{
				str = string.Concat(str, num1, " Gold ");
			}
			if (num2 > 0)
			{
				str = string.Concat(str, num2, " Silver ");
			}
			if (num3 > 0)
			{
				str = string.Concat(str, num3, " Copper ");
			}
			if (str.Length > 1)
			{
				str = str.Substring(0, str.Length - 1);
			}
			return str;
		}

		private void ValueToName()
		{
			int num = 0;
			int num1 = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = this.coinValue;
			while (num4 > 0)
			{
				if (num4 >= 1000000)
				{
					num4 = num4 - 1000000;
					num++;
				}
				else if (num4 >= 10000)
				{
					num4 = num4 - 10000;
					num1++;
				}
				else if (num4 < 100)
				{
					if (num4 < 1)
					{
						continue;
					}
					num4--;
					num3++;
				}
				else
				{
					num4 = num4 - 100;
					num2++;
				}
			}
			this.name = "";
			if (num > 0)
			{
				ItemText itemText = this;
				itemText.name = string.Concat(itemText.name, num, " Platinum ");
			}
			if (num1 > 0)
			{
				ItemText itemText1 = this;
				itemText1.name = string.Concat(itemText1.name, num1, " Gold ");
			}
			if (num2 > 0)
			{
				ItemText itemText2 = this;
				itemText2.name = string.Concat(itemText2.name, num2, " Silver ");
			}
			if (num3 > 0)
			{
				ItemText itemText3 = this;
				itemText3.name = string.Concat(itemText3.name, num3, " Copper ");
			}
			if (this.name.Length > 1)
			{
				this.name = this.name.Substring(0, this.name.Length - 1);
			}
		}
	}
}