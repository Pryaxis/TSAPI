//
//using System;
//using Terraria.GameContent;

//namespace Terraria
//{
//	public class Gore
//	{
//		public static int goreTime;

//		public Vector2 position;

//		public Vector2 velocity;

//		public float rotation;

//		public float scale;

//		public int alpha;

//		public int type;

//		public float light;

//		public bool active;

//		public bool sticky = true;

//		public int timeLeft = Gore.goreTime;

//		public bool behindTiles;

//		public byte frame;

//		public byte frameCounter;

//		public byte numFrames = 1;

//		static Gore()
//		{
//			Gore.goreTime = 600;
//		}

//		public Gore()
//		{
//		}

//		public Color GetAlpha(Color newColor)
//		{
//			int r;
//			int g;
//			int b;
//			float single = (float)(255 - this.alpha) / 255f;
//			if (this.type == 16 || this.type == 17)
//			{
//				r = newColor.R;
//				g = newColor.G;
//				b = newColor.B;
//			}
//			else
//			{
//				if (this.type == 716)
//				{
//					return new Color(255, 255, 255, 200);
//				}
//				if (this.type >= 570 && this.type <= 572)
//				{
//					byte num = (byte)(255 - this.alpha);
//					return new Color((int)num, (int)num, (int)num, num / 2);
//				}
//				if (this.type == 331)
//				{
//					return new Color(255, 255, 255, 50);
//				}
//				r = (int)((float)newColor.R * single);
//				g = (int)((float)newColor.G * single);
//				b = (int)((float)newColor.B * single);
//			}
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

//		public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
//		{
//			return -1;
//		}

//		public void Update()
//		{
//		}
//	}
//}