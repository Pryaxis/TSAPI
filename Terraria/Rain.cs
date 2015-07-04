using XNA;
using System;

namespace Terraria
{
	public class Rain
	{
		public Vector2 position;

		public Vector2 velocity;

		public float scale;

		public float rotation;

		public int alpha;

		public bool active;

		public byte type;

		public Rain()
		{
		}

		public static void MakeRain()
		{
			Vector2 vector2 = new Vector2();
			if ((double)Main.screenPosition.Y > Main.worldSurface * 16)
			{
				return;
			}
			if (Main.gameMenu)
			{
				return;
			}
			float single = (float)Main.screenWidth / 1920f;
			single = single * 25f;
			single = single * (0.25f + 1f * Main.cloudAlpha);
			for (int i = 0; (float)i < single; i++)
			{
				int num = 600;
				if (Main.player[Main.myPlayer].velocity.Y < 0f)
				{
					num = num + (int)(Math.Abs(Main.player[Main.myPlayer].velocity.Y) * 30f);
				}
				vector2.X = (float)Main.rand.Next((int)Main.screenPosition.X - num, (int)Main.screenPosition.X + Main.screenWidth + num);
				vector2.Y = Main.screenPosition.Y - (float)Main.rand.Next(20, 100);
				vector2.X = vector2.X - Main.windSpeed * 15f * 40f;
				vector2.X = vector2.X + Main.player[Main.myPlayer].velocity.X * 40f;
				if (vector2.X < 0f)
				{
					vector2.X = 0f;
				}
				if (vector2.X > (float)((Main.maxTilesX - 1) * 16))
				{
					vector2.X = (float)((Main.maxTilesX - 1) * 16);
				}
				int x = (int)vector2.X / 16;
				int y = (int)vector2.Y / 16;
				if (x < 0)
				{
					x = 0;
				}
				if (x > Main.maxTilesX - 1)
				{
					x = Main.maxTilesX - 1;
				}
				if (Main.gameMenu || !WorldGen.SolidTile(x, y) && Main.tile[x, y].wall <= 0)
				{
					Vector2 vector21 = new Vector2(Main.windSpeed * 12f, 14f);
					Rain.NewRain(vector2, vector21);
				}
			}
		}

		public static int NewRain(Vector2 Position, Vector2 Velocity)
		{
			int num = -1;
			int num1 = (int)((float)Main.maxRain * Main.cloudAlpha);
			if (num1 > Main.maxRain)
			{
				num1 = Main.maxRain;
			}
			float single = (1f + Main.gfxQuality) / 2f;
			if ((double)single < 0.9)
			{
				num1 = (int)((float)num1 * single);
			}
			float single1 = (float)(800 - Main.snowTiles);
			if (single1 < 0f)
			{
				single1 = 0f;
			}
			single1 = single1 / 800f;
			num1 = (int)((float)num1 * single1);
			int num2 = 0;
			while (num2 < num1)
			{
				if (Main.rain[num2].active)
				{
					num2++;
				}
				else
				{
					num = num2;
					break;
				}
			}
			if (num == -1)
			{
				return Main.maxRain;
			}
			Rain position = Main.rain[num];
			position.active = true;
			position.position = Position;
			position.scale = 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
			position.velocity = Velocity * position.scale;
			position.rotation = (float)Math.Atan2((double)position.velocity.X, (double)(-position.velocity.Y));
			position.type = (byte)Main.rand.Next(3);
			if (Main.bloodMoon)
			{
				Rain rain = position;
				rain.type = (byte)(rain.type + 3);
			}
			return num;
		}

		public void Update()
		{
			Rain rain = this;
			rain.position = rain.position + this.velocity;
			if (Collision.SolidCollision(this.position, 2, 2) || this.position.Y > Main.screenPosition.Y + (float)Main.screenHeight + 100f || Collision.WetCollision(this.position, 2, 2))
			{
				this.active = false;
				if ((float)Main.rand.Next(100) < Main.gfxQuality * 100f)
				{
					int num = 154;
					if (this.type == 3 || this.type == 4 || this.type == 5)
					{
						num = 218;
					}
				}
			}
		}
	}
}