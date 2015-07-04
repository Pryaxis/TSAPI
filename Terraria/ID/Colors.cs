
using System;
using Terraria;

namespace Terraria.ID
{
	public static class Colors
	{
		public readonly static Color RarityAmber;

		public readonly static Color RarityTrash;

		public readonly static Color RarityNormal;

		public readonly static Color RarityBlue;

		public readonly static Color RarityGreen;

		public readonly static Color RarityOrange;

		public readonly static Color RarityRed;

		public readonly static Color RarityPink;

		public readonly static Color RarityPurple;

		public readonly static Color RarityLime;

		public readonly static Color RarityYellow;

		public readonly static Color RarityCyan;

		public readonly static Color CoinPlatinum;

		public readonly static Color CoinGold;

		public readonly static Color CoinSilver;

		public readonly static Color CoinCopper;

		public readonly static Color[] _waterfallColors;

		public readonly static Color[] _liquidColors;

		public static Color CurrentLiquidColor
		{
			get
			{
				Color transparent = Color.Transparent;
				bool flag = true;
				for (int i = 0; i < 11; i++)
				{
					if (Main.liquidAlpha[i] > 0f)
					{
						if (!flag)
						{
							transparent = Color.Lerp(transparent, Colors._liquidColors[i], Main.liquidAlpha[i]);
						}
						else
						{
							flag = false;
							transparent = Colors._liquidColors[i];
						}
					}
				}
				return transparent;
			}
		}

		static Colors()
		{
			Colors.RarityAmber = new Color(255, 175, 0);
			Colors.RarityTrash = new Color(130, 130, 130);
			Colors.RarityNormal = Color.White;
			Colors.RarityBlue = new Color(150, 150, 255);
			Colors.RarityGreen = new Color(150, 255, 150);
			Colors.RarityOrange = new Color(255, 200, 150);
			Colors.RarityRed = new Color(255, 150, 150);
			Colors.RarityPink = new Color(255, 150, 255);
			Colors.RarityPurple = new Color(210, 160, 255);
			Colors.RarityLime = new Color(150, 255, 10);
			Colors.RarityYellow = new Color(255, 255, 10);
			Colors.RarityCyan = new Color(5, 200, 255);
			Colors.CoinPlatinum = new Color(220, 220, 198);
			Colors.CoinGold = new Color(224, 201, 92);
			Colors.CoinSilver = new Color(181, 192, 193);
			Colors.CoinCopper = new Color(246, 138, 96);
			Color[] color = new Color[22];
			color[0] = new Color(9, 61, 191);
			color[1] = new Color(253, 32, 3);
			color[2] = new Color(143, 143, 143);
			color[3] = new Color(59, 29, 131);
			color[4] = new Color(7, 145, 142);
			color[5] = new Color(171, 11, 209);
			color[6] = new Color(9, 137, 191);
			color[7] = new Color(168, 106, 32);
			color[8] = new Color(36, 60, 148);
			color[9] = new Color(65, 59, 101);
			color[10] = new Color(200, 0, 0);
			Color color1 = new Color();
			color[11] = color1;
			Color color2 = new Color();
			color[12] = color2;
			color[13] = new Color(177, 54, 79);
			color[14] = new Color(255, 156, 12);
			color[15] = new Color(91, 34, 104);
			color[16] = new Color(102, 104, 34);
			color[17] = new Color(34, 43, 104);
			color[18] = new Color(34, 104, 38);
			color[19] = new Color(104, 34, 34);
			color[20] = new Color(76, 79, 102);
			color[21] = new Color(104, 61, 34);
			Colors._waterfallColors = color;
			Color[] colorArray = new Color[] { new Color(9, 61, 191), new Color(253, 32, 3), new Color(59, 29, 131), new Color(7, 145, 142), new Color(171, 11, 209), new Color(9, 137, 191), new Color(168, 106, 32), new Color(36, 60, 148), new Color(65, 59, 101), new Color(200, 0, 0), new Color(177, 54, 79), new Color(255, 156, 12) };
			Colors._liquidColors = colorArray;
		}

		public static Color AlphaDarken(Color input)
		{
			return input * ((float)Main.mouseTextColor / 255f);
		}
	}
}