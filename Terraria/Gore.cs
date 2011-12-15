using Microsoft.Xna.Framework;
using System;
namespace Terraria
{
	public class Gore
	{
		public static int goreTime = 600;
		public Vector2 position;
		public Vector2 velocity;
		public float rotation;
		public float scale;
		public int alpha;
		public int type;
		public float light;
		public bool active;
		public bool sticky = true;
		public int timeLeft = Gore.goreTime;
		public void Update()
		{
			if (Main.netMode == 2)
			{
				return;
			}
			if (this.active)
			{
				if (this.type == 11 || this.type == 12 || this.type == 13 || this.type == 61 || this.type == 62 || this.type == 63 || this.type == 99)
				{
					this.velocity.Y = this.velocity.Y * 0.98f;
					this.velocity.X = this.velocity.X * 0.98f;
					this.scale -= 0.007f;
					if ((double)this.scale < 0.1)
					{
						this.scale = 0.1f;
						this.alpha = 255;
					}
				}
				else
				{
					if (this.type == 16 || this.type == 17)
					{
						this.velocity.Y = this.velocity.Y * 0.98f;
						this.velocity.X = this.velocity.X * 0.98f;
						this.scale -= 0.01f;
						if ((double)this.scale < 0.1)
						{
							this.scale = 0.1f;
							this.alpha = 255;
						}
					}
					else
					{
						this.velocity.Y = this.velocity.Y + 0.2f;
					}
				}
				this.rotation += this.velocity.X * 0.1f;
				if (this.sticky)
				{
					int num = Main.goreTexture[this.type].Width;
					if (Main.goreTexture[this.type].Height < num)
					{
						num = Main.goreTexture[this.type].Height;
					}
					num = (int)((float)num * 0.9f);
					this.velocity = Collision.TileCollision(this.position, this.velocity, (int)((float)num * this.scale), (int)((float)num * this.scale), false, false);
					if (this.velocity.Y == 0f)
					{
						this.velocity.X = this.velocity.X * 0.97f;
						if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
						{
							this.velocity.X = 0f;
						}
					}
					if (this.timeLeft > 0)
					{
						this.timeLeft--;
					}
					else
					{
						this.alpha++;
					}
				}
				else
				{
					this.alpha += 2;
				}
				this.position += this.velocity;
				if (this.alpha >= 255)
				{
					this.active = false;
				}
				if (this.light > 0f)
				{
					float num2 = this.light * this.scale;
					float num3 = this.light * this.scale;
					float num4 = this.light * this.scale;
					if (this.type == 16)
					{
						num4 *= 0.3f;
						num3 *= 0.8f;
					}
					else
					{
						if (this.type == 17)
						{
							num3 *= 0.6f;
							num2 *= 0.3f;
						}
					}
					Lighting.addLight((int)((this.position.X + (float)Main.goreTexture[this.type].Width * this.scale / 2f) / 16f), (int)((this.position.Y + (float)Main.goreTexture[this.type].Height * this.scale / 2f) / 16f), num2, num3, num4);
				}
			}
		}
		public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
		{
			if (Main.rand == null)
			{
				Main.rand = new Random();
			}
			if (Main.netMode == 2)
			{
				return 0;
			}
			int num = 200;
			for (int i = 0; i < 200; i++)
			{
				if (!Main.gore[i].active)
				{
					num = i;
					break;
				}
			}
			if (num == 200)
			{
				return num;
			}
			Main.gore[num].light = 0f;
			Main.gore[num].position = Position;
			Main.gore[num].velocity = Velocity;
			Gore expr_84_cp_0 = Main.gore[num];
			expr_84_cp_0.velocity.Y = expr_84_cp_0.velocity.Y - (float)Main.rand.Next(10, 31) * 0.1f;
			Gore expr_B1_cp_0 = Main.gore[num];
			expr_B1_cp_0.velocity.X = expr_B1_cp_0.velocity.X + (float)Main.rand.Next(-20, 21) * 0.1f;
			Main.gore[num].type = Type;
			Main.gore[num].active = true;
			Main.gore[num].alpha = 0;
			Main.gore[num].rotation = 0f;
			Main.gore[num].scale = Scale;
			if (Gore.goreTime == 0 || Type == 11 || Type == 12 || Type == 13 || Type == 16 || Type == 17 || Type == 61 || Type == 62 || Type == 63 || Type == 99)
			{
				Main.gore[num].sticky = false;
			}
			else
			{
				Main.gore[num].sticky = true;
				Main.gore[num].timeLeft = Gore.goreTime;
			}
			if (Type == 16 || Type == 17)
			{
				Main.gore[num].alpha = 100;
				Main.gore[num].scale = 0.7f;
				Main.gore[num].light = 1f;
			}
			return num;
		}
		public Color GetAlpha(Color newColor)
		{
			float num = (float)(255 - this.alpha) / 255f;
			int r;
			int g;
			int b;
			if (this.type == 16 || this.type == 17)
			{
				r = (int)newColor.R;
				g = (int)newColor.G;
				b = (int)newColor.B;
			}
			else
			{
				r = (int)((float)newColor.R * num);
				g = (int)((float)newColor.G * num);
				b = (int)((float)newColor.B * num);
			}
			int num2 = (int)newColor.A - this.alpha;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			return new Color(r, g, b, num2);
		}
	}
}
