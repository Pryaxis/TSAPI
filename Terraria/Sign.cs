using System;

namespace Terraria
{
	public class Sign
	{
		public const int maxSigns = 1000;

		public int x;

		public int y;

		public string text;

		public Sign()
		{
		}

		public static void KillSign(int x, int y)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (Main.sign[i] != null && Main.sign[i].x == x && Main.sign[i].y == y)
				{
					Main.sign[i] = null;
				}
			}
		}

		public static int ReadSign(int i, int j, bool CreateIfMissing = true)
		{
			int num = Main.tile[i, j].frameX / 18;
			int num1 = Main.tile[i, j].frameY / 18;
			int num2 = i - num % 2;
			int num3 = j - num1;
			if (!Main.tileSign[Main.tile[num2, num3].type])
			{
				Sign.KillSign(num2, num3);
				return -1;
			}
			int num4 = -1;
			int num5 = 0;
			while (num5 < 1000)
			{
				if (Main.sign[num5] == null || Main.sign[num5].x != num2 || Main.sign[num5].y != num3)
				{
					num5++;
				}
				else
				{
					num4 = num5;
					break;
				}
			}
			if (num4 < 0 && CreateIfMissing)
			{
				int num6 = 0;
				while (num6 < 1000)
				{
					if (Main.sign[num6] != null)
					{
						num6++;
					}
					else
					{
						num4 = num6;
						Main.sign[num6] = new Sign();
						Main.sign[num6].x = num2;
						Main.sign[num6].y = num3;
						Main.sign[num6].text = "";
						break;
					}
				}
			}
			return num4;
		}

		public static void TextSign(int i, string text)
		{
			if (Main.tile[Main.sign[i].x, Main.sign[i].y] == null || !Main.tile[Main.sign[i].x, Main.sign[i].y].active() || !Main.tileSign[(int)Main.tile[Main.sign[i].x, Main.sign[i].y].type])
			{
				Main.sign[i] = null;
				return;
			}
			Main.sign[i].text = text;
		}

		public override string ToString()
		{
			object[] objArray = new object[] { "x", this.x, "\ty", this.y, "\t", this.text };
			return string.Concat(objArray);
		}
	}
}