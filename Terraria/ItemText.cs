
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
		}

		public void Update(int whoAmI)
		{
		}

		public static void UpdateItemText()
		{
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