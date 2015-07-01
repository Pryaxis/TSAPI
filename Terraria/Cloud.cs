using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Terraria
{
	public class Cloud
	{
		public Vector2 position;

		public float scale;

		public float rotation;

		public float rSpeed;

		public float sSpeed;

		public bool active;

		public SpriteEffects spriteDir;

		public int type;

		public int width;

		public int height;

		public float Alpha;

		public bool kill;

		private static Random rand;

		static Cloud()
		{
			Cloud.rand = new Random();
		}

		public Cloud()
		{
		}

		public static void addCloud()
		{
			if (Main.netMode == 2)
			{
				return;
			}
			int num = -1;
			int num1 = 0;
			while (num1 < 200)
			{
				if (Main.cloud[num1].active)
				{
					num1++;
				}
				else
				{
					num = num1;
					break;
				}
			}
			if (num >= 0)
			{
				Main.cloud[num].kill = false;
				Main.cloud[num].rSpeed = 0f;
				Main.cloud[num].sSpeed = 0f;
				Main.cloud[num].scale = (float)Cloud.rand.Next(70, 131) * 0.01f;
				Main.cloud[num].rotation = (float)Cloud.rand.Next(-10, 11) * 0.01f;
				Main.cloud[num].width = (int)((float)Main.cloudTexture[Main.cloud[num].type].Width * Main.cloud[num].scale);
				Main.cloud[num].height = (int)((float)Main.cloudTexture[Main.cloud[num].type].Height * Main.cloud[num].scale);
				Main.cloud[num].Alpha = 0f;
				Main.cloud[num].spriteDir = SpriteEffects.None;
				if (Cloud.rand.Next(2) == 0)
				{
					Main.cloud[num].spriteDir = SpriteEffects.FlipHorizontally;
				}
				float x = Main.windSpeed;
				if (!Main.gameMenu)
				{
					x = Main.windSpeed - Main.player[Main.myPlayer].velocity.X * 0.1f;
				}
				int num2 = 0;
				int num3 = 0;
				if (x > 0f)
				{
					num2 = num2 - 200;
				}
				if (x < 0f)
				{
					num3 = num3 + 200;
				}
				int num4 = 300;
				float single = (float)WorldGen.genRand.Next(num2 - num4, Main.screenWidth + num3 + num4);
				Main.cloud[num].Alpha = 0f;
				Main.cloud[num].position.Y = (float)Cloud.rand.Next((int)((float)(-Main.screenHeight) * 0.25f), (int)((float)Main.screenHeight * 0.25f));
				Main.cloud[num].position.Y = Main.cloud[num].position.Y - (float)Cloud.rand.Next((int)((float)Main.screenHeight * 0.15f));
				Main.cloud[num].position.Y = Main.cloud[num].position.Y - (float)Cloud.rand.Next((int)((float)Main.screenHeight * 0.15f));
				Main.cloud[num].type = Cloud.rand.Next(4);
				if (Main.rand == null)
				{
					Main.rand = new Random();
				}
				if (Main.cloudAlpha > 0f && Cloud.rand.Next(4) != 0 || Main.cloudBGActive >= 1f && Main.rand.Next(2) == 0)
				{
					Main.cloud[num].type = Cloud.rand.Next(18, 22);
					if ((double)Main.cloud[num].scale >= 1.15)
					{
						Main.cloud[num].position.Y = Main.cloud[num].position.Y - 150f;
					}
					if (Main.cloud[num].scale >= 1f)
					{
						Main.cloud[num].position.Y = Main.cloud[num].position.Y - 150f;
					}
				}
				else if ((Main.cloudBGActive <= 0f && Main.cloudAlpha == 0f && Main.cloud[num].scale < 1f && Main.cloud[num].position.Y < (float)(-Main.screenHeight) * 0.2f || Main.cloud[num].position.Y < (float)(-Main.screenHeight) * 0.2f) && (double)Main.numClouds < 50)
				{
					Main.cloud[num].type = Cloud.rand.Next(9, 14);
				}
				else if (((double)Main.cloud[num].scale < 1.15 && Main.cloud[num].position.Y < (float)(-Main.screenHeight) * 0.3f || (double)Main.cloud[num].scale < 0.85 && Main.cloud[num].position.Y < (float)Main.screenHeight * 0.15f) && ((double)Main.numClouds > 70 || Main.cloudBGActive >= 1f))
				{
					Main.cloud[num].type = Cloud.rand.Next(4, 9);
				}
				else if (Main.cloud[num].position.Y > (float)(-Main.screenHeight) * 0.15f && Cloud.rand.Next(2) == 0 && (double)Main.numClouds > 20)
				{
					Main.cloud[num].type = Cloud.rand.Next(14, 18);
				}
				if ((double)Main.cloud[num].scale > 1.2)
				{
					Main.cloud[num].position.Y = Main.cloud[num].position.Y + 100f;
				}
				if ((double)Main.cloud[num].scale > 1.3)
				{
					Main.cloud[num].scale = 1.3f;
				}
				if ((double)Main.cloud[num].scale < 0.7)
				{
					Main.cloud[num].scale = 0.7f;
				}
				Main.cloud[num].active = true;
				Main.cloud[num].position.X = single;
				if (Main.cloud[num].position.X > (float)(Main.screenWidth + 100))
				{
					Main.cloud[num].Alpha = 1f;
				}
				if (Main.cloud[num].position.X + (float)Main.cloudTexture[Main.cloud[num].type].Width * Main.cloud[num].scale < -100f)
				{
					Main.cloud[num].Alpha = 1f;
				}
				Rectangle rectangle = new Rectangle((int)Main.cloud[num].position.X, (int)Main.cloud[num].position.Y, Main.cloud[num].width, Main.cloud[num].height);
				for (int i = 0; i < 200; i++)
				{
					if (num != i && Main.cloud[i].active)
					{
						Rectangle rectangle1 = new Rectangle((int)Main.cloud[i].position.X, (int)Main.cloud[i].position.Y, Main.cloud[i].width, Main.cloud[i].height);
						if (rectangle.Intersects(rectangle1))
						{
							Main.cloud[num].active = false;
						}
					}
				}
			}
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public Color cloudColor(Color bgColor)
		{
			float alpha = this.scale * this.Alpha;
			if (alpha > 1f)
			{
				alpha = 1f;
			}
			float r = (float)((int)((float)bgColor.R * alpha));
			float g = (float)((int)((float)bgColor.G * alpha));
			float b = (float)((int)((float)bgColor.B * alpha));
			float a = (float)((int)((float)bgColor.A * alpha));
			return new Color((int)r, (int)g, (int)b, (int)a);
		}

		public static void resetClouds()
		{
			if (Main.dedServ)
			{
				return;
			}
			if (Main.cloudLimit < 10)
			{
				return;
			}
			Main.windSpeed = Main.windSpeedSet;
			for (int i = 0; i < 200; i++)
			{
				Main.cloud[i].active = false;
			}
			for (int j = 0; j < Main.numClouds; j++)
			{
				Cloud.addCloud();
				Main.cloud[j].Alpha = 1f;
			}
			for (int k = 0; k < 200; k++)
			{
				Main.cloud[k].Alpha = 1f;
			}
		}

		public void Update()
		{
			if (!Main.gameMenu)
			{
				if (this.scale == 1f)
				{
					Cloud cloud = this;
					cloud.scale = cloud.scale - 0.0001f;
				}
				if ((double)this.scale == 1.15)
				{
					Cloud cloud1 = this;
					cloud1.scale = cloud1.scale - 0.0001f;
				}
				float single = 0.13f;
				if (this.scale < 1f)
				{
					single = 0.07f;
					float single1 = this.scale + 0.15f;
					single1 = (single1 + 1f) / 2f;
					single1 = single1 * single1;
					single = single * single1;
				}
				else if ((double)this.scale > 1.15)
				{
					single = 0.23f;
					float single2 = this.scale - 0.15f - 0.075f;
					single2 = single2 * single2;
					single = single * single2;
				}
				else
				{
					single = 0.19f;
					float single3 = this.scale - 0.075f;
					single3 = single3 * single3;
					single = single * single3;
				}
				this.position.X = this.position.X + Main.windSpeed * single * 5f * (float)Main.dayRate;
				float x = Main.screenPosition.X - Main.screenLastPosition.X;
				this.position.X = this.position.X - x * single;
			}
			else
			{
				this.position.X = this.position.X + Main.windSpeed * this.scale * 3f;
			}
			float single4 = 600f;
			if (this.kill)
			{
				Cloud alpha = this;
				alpha.Alpha = alpha.Alpha - 0.001f * (float)Main.dayRate;
				if (this.Alpha <= 0f)
				{
					this.active = false;
				}
			}
			else if (this.Alpha < 1f)
			{
				Cloud alpha1 = this;
				alpha1.Alpha = alpha1.Alpha + 0.001f * (float)Main.dayRate;
				if (this.Alpha > 1f)
				{
					this.Alpha = 1f;
				}
			}
			if (this.position.X + (float)Main.cloudTexture[this.type].Width * this.scale < -single4 || this.position.X > (float)Main.screenWidth + single4)
			{
				this.active = false;
			}
			Cloud cloud2 = this;
			cloud2.rSpeed = cloud2.rSpeed + (float)Cloud.rand.Next(-10, 11) * 2E-05f;
			if ((double)this.rSpeed > 0.0002)
			{
				this.rSpeed = 0.0002f;
			}
			if ((double)this.rSpeed < -0.0002)
			{
				this.rSpeed = -0.0002f;
			}
			if ((double)this.rotation > 0.02)
			{
				this.rotation = 0.02f;
			}
			if ((double)this.rotation < -0.02)
			{
				this.rotation = -0.02f;
			}
			Cloud cloud3 = this;
			cloud3.rotation = cloud3.rotation + this.rSpeed;
			this.width = (int)((float)Main.cloudTexture[this.type].Width * this.scale);
			this.height = (int)((float)Main.cloudTexture[this.type].Height * this.scale);
			if (this.type >= 9 && this.type <= 13 && (Main.cloudAlpha > 0f || Main.cloudBGActive >= 1f))
			{
				this.kill = true;
			}
		}

		public static void UpdateClouds()
		{
			if (Main.netMode == 2)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.cloud[i].active)
				{
					Main.cloud[i].Update();
					if (!Main.cloud[i].kill)
					{
						num++;
					}
				}
			}
			for (int j = 0; j < 200; j++)
			{
				if (Main.cloud[j].active)
				{
					if (j > 1 && (!Main.cloud[j - 1].active || (double)Main.cloud[j - 1].scale > (double)Main.cloud[j].scale + 0.02))
					{
						Cloud cloud = (Cloud)Main.cloud[j - 1].Clone();
						Main.cloud[j - 1] = (Cloud)Main.cloud[j].Clone();
						Main.cloud[j] = cloud;
					}
					if (j < 199 && (!Main.cloud[j].active || (double)Main.cloud[j + 1].scale < (double)Main.cloud[j].scale - 0.02))
					{
						Cloud cloud1 = (Cloud)Main.cloud[j + 1].Clone();
						Main.cloud[j + 1] = (Cloud)Main.cloud[j].Clone();
						Main.cloud[j] = cloud1;
					}
				}
			}
			if (num < Main.numClouds)
			{
				Cloud.addCloud();
				return;
			}
			if (num > Main.numClouds)
			{
				int num1 = Main.rand.Next(num);
				int num2 = 0;
				while (Main.cloud[num1].kill && num2 < 100)
				{
					num2++;
					num1 = Main.rand.Next(num);
				}
				Main.cloud[num1].kill = true;
			}
		}
	}
}