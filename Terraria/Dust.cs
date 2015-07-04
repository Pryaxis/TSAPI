//
//using System;
//using Terraria.GameContent;

//namespace Terraria
//{
//	public class Dust
//	{
//		public static float dCount;

//		public static int lavaBubbles;

//		public Vector2 position;

//		public Vector2 velocity;

//		public float fadeIn;

//		public bool noGravity;

//		public float scale;

//		public float rotation;

//		public bool noLight;

//		public bool active;

//		public int type;

//		public Color color;

//		public int alpha;

//		public Rectangle frame;

//		public object customData;

//		public bool firstFrame;

//		static Dust()
//		{
//		}

//		public Dust()
//		{
//		}

//		public static Dust CloneDust(int dustIndex)
//		{
//			return Dust.CloneDust(Main.dust[dustIndex]);
//		}

//		public static Dust CloneDust(Dust rf)
//		{
//			return null;
//		}

//		public static int dustWater()
//		{
//			switch (Main.waterStyle)
//			{
//				case 2:
//				{
//					return 98;
//				}
//				case 3:
//				{
//					return 99;
//				}
//				case 4:
//				{
//					return 100;
//				}
//				case 5:
//				{
//					return 101;
//				}
//				case 6:
//				{
//					return 102;
//				}
//				case 7:
//				{
//					return 103;
//				}
//				case 8:
//				{
//					return 104;
//				}
//				case 9:
//				{
//					return 105;
//				}
//				case 10:
//				{
//					return 123;
//				}
//			}
//			return 33;
//		}

//		public Color GetAlpha(Color newColor)
//		{
//			int r;
//			int g;
//			int b;
//			float single = (float)(255 - this.alpha) / 255f;
//			if (this.type == 259)
//			{
//				return new Color(230, 230, 230, 230);
//			}
//			if (this.type == 261)
//			{
//				return new Color(230, 230, 230, 115);
//			}
//			if (this.type == 254 || this.type == 255)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 258)
//			{
//				return new Color(150, 50, 50, 0);
//			}
//			if (this.type == 263 || this.type == 264)
//			{
//				return new Color(this.color.R / 2 + 127, this.color.G + 127, this.color.B + 127, this.color.A / 8) * 0.5f;
//			}
//			if (this.type == 235)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if ((this.type >= 86 && this.type <= 91 || this.type == 262) && !this.noLight)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 213 || this.type == 260)
//			{
//				int num = (int)(this.scale / 2.5f * 255f);
//				return new Color(num, num, num, num);
//			}
//			if (this.type == 64 && this.alpha == 255 && this.noLight)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 197)
//			{
//				return new Color(250, 250, 250, 150);
//			}
//			if (this.type >= 110 && this.type <= 114)
//			{
//				return new Color(200, 200, 200, 0);
//			}
//			if (this.type == 204)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 181)
//			{
//				return new Color(200, 200, 200, 0);
//			}
//			if (this.type == 182 || this.type == 206)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 159)
//			{
//				return new Color(250, 250, 250, 50);
//			}
//			if (this.type == 163 || this.type == 205)
//			{
//				return new Color(250, 250, 250, 0);
//			}
//			if (this.type == 170)
//			{
//				return new Color(200, 200, 200, 100);
//			}
//			if (this.type == 180)
//			{
//				return new Color(200, 200, 200, 0);
//			}
//			if (this.type == 175)
//			{
//				return new Color(200, 200, 200, 0);
//			}
//			if (this.type == 183)
//			{
//				return new Color(50, 0, 0, 0);
//			}
//			if (this.type == 172)
//			{
//				return new Color(250, 250, 250, 150);
//			}
//			if (this.type == 160 || this.type == 162 || this.type == 164 || this.type == 173)
//			{
//				int num1 = (int)(250f * this.scale);
//				return new Color(num1, num1, num1, 0);
//			}
//			if (this.type == 92 || this.type == 106 || this.type == 107)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 185)
//			{
//				return new Color(200, 200, 255, 125);
//			}
//			if (this.type == 127 || this.type == 187)
//			{
//				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
//			}
//			if (this.type == 156 || this.type == 230 || this.type == 234)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 6 || this.type == 242 || this.type == 174 || this.type == 135 || this.type == 75 || this.type == 20 || this.type == 21 || this.type == 231 || this.type == 169 || this.type >= 130 && this.type <= 134 || this.type == 158)
//			{
//				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
//			}
//			if (this.type >= 219 && this.type <= 223)
//			{
//				newColor = Color.Lerp(newColor, Color.White, 0.5f);
//				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
//			}
//			if (this.type == 226)
//			{
//				newColor = Color.Lerp(newColor, Color.White, 0.8f);
//				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
//			}
//			if (this.type == 228)
//			{
//				newColor = Color.Lerp(newColor, Color.White, 0.8f);
//				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
//			}
//			if (this.type == 229)
//			{
//				newColor = Color.Lerp(newColor, Color.White, 0.6f);
//				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
//			}
//			if ((this.type == 68 || this.type == 70) && this.noGravity)
//			{
//				return new Color(255, 255, 255, 0);
//			}
//			if (this.type == 157)
//			{
//				int num2 = 255;
//				b = num2;
//				g = num2;
//				r = num2;
//				float single1 = (float)Main.mouseTextColor / 100f - 1.6f;
//				r = (int)((float)r * single1);
//				g = (int)((float)g * single1);
//				b = (int)((float)b * single1);
//				int num3 = (int)(100f * single1);
//				r = r + 50;
//				if (r > 255)
//				{
//					r = 255;
//				}
//				g = g + 50;
//				if (g > 255)
//				{
//					g = 255;
//				}
//				b = b + 50;
//				if (b > 255)
//				{
//					b = 255;
//				}
//				return new Color(r, g, b, num3);
//			}
//			if (this.type == 15 || this.type == 20 || this.type == 21 || this.type == 29 || this.type == 35 || this.type == 41 || this.type == 44 || this.type == 27 || this.type == 45 || this.type == 55 || this.type == 56 || this.type == 57 || this.type == 58 || this.type == 73 || this.type == 74)
//			{
//				single = (single + 3f) / 4f;
//			}
//			else if (this.type != 43)
//			{
//				if (this.type >= 244 && this.type <= 247)
//				{
//					return new Color(255, 255, 255, 0);
//				}
//				if (this.type == 66)
//				{
//					return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 0);
//				}
//				if (this.type == 267)
//				{
//					return new Color((int)this.color.R, (int)this.color.G, (int)this.color.B, 0);
//				}
//				if (this.type == 71)
//				{
//					return new Color(200, 200, 200, 0);
//				}
//				if (this.type == 72)
//				{
//					return new Color(200, 200, 200, 200);
//				}
//			}
//			else
//			{
//				single = (single + 9f) / 10f;
//			}
//			r = (int)((float)newColor.R * single);
//			g = (int)((float)newColor.G * single);
//			b = (int)((float)newColor.B * single);
//			int a = newColor.A - this.alpha;
//			if (a < 0)
//			{
//				a = 0;
//			}
//			if (a > 255)
//			{
//				a = 255;
//			}
//			return new Color(r, g, b, a);
//		}

//		public Color GetColor(Color newColor)
//		{
//			int r = this.color.R - (255 - newColor.R);
//			int g = this.color.G - (255 - newColor.G);
//			int b = this.color.B - (255 - newColor.B);
//			int a = this.color.A - (255 - newColor.A);
//			if (r < 0)
//			{
//				r = 0;
//			}
//			if (r > 255)
//			{
//				r = 255;
//			}
//			if (g < 0)
//			{
//				g = 0;
//			}
//			if (g > 255)
//			{
//				g = 255;
//			}
//			if (b < 0)
//			{
//				b = 0;
//			}
//			if (b > 255)
//			{
//				b = 255;
//			}
//			if (a < 0)
//			{
//				a = 0;
//			}
//			if (a > 255)
//			{
//				a = 255;
//			}
//			return new Color(r, g, b, a);
//		}

//		public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = new Color(), float Scale = 1f)
//		{
//			return -1;
//		}

//		public static Dust QuickDust(Point tileCoords, Color color)
//		{
//			return null;
//		}

//		public static Dust QuickDust(Vector2 pos, Color color)
//		{
//			return null;
//		}

//		public static void QuickDustLine(Vector2 start, Vector2 end, float splits, Color color)
//		{
//		}

//		public static void UpdateDust()
//		{
//		}
//	}
//}