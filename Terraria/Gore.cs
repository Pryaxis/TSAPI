using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;

namespace Terraria
{
	public class Gore
	{
		public static int goreTime;

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

		public bool behindTiles;

		public byte frame;

		public byte frameCounter;

		public byte numFrames = 1;

		static Gore()
		{
			Gore.goreTime = 600;
		}

		public Gore()
		{
		}

		public Color GetAlpha(Color newColor)
		{
			int r;
			int g;
			int b;
			float single = (float)(255 - this.alpha) / 255f;
			if (this.type == 16 || this.type == 17)
			{
				r = newColor.R;
				g = newColor.G;
				b = newColor.B;
			}
			else
			{
				if (this.type == 716)
				{
					return new Color(255, 255, 255, 200);
				}
				if (this.type >= 570 && this.type <= 572)
				{
					byte num = (byte)(255 - this.alpha);
					return new Color((int)num, (int)num, (int)num, num / 2);
				}
				if (this.type == 331)
				{
					return new Color(255, 255, 255, 50);
				}
				r = (int)((float)newColor.R * single);
				g = (int)((float)newColor.G * single);
				b = (int)((float)newColor.B * single);
			}
			int a = newColor.A - this.alpha;
			if (a < 0)
			{
				a = 0;
			}
			if (a > 255)
			{
				a = 255;
			}
			return new Color(r, g, b, a);
		}

		public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
		{
			if (Main.netMode == 2)
			{
				return 500;
			}
			if (Main.gamePaused)
			{
				return 500;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random();
			}
			int num = 500;
			int num1 = 0;
			while (num1 < 500)
			{
				if (Main.gore[num1].active)
				{
					num1++;
				}
				else
				{
					num = num1;
					break;
				}
			}
			if (num == 500)
			{
				return num;
			}
			Main.gore[num].numFrames = 1;
			Main.gore[num].frame = 0;
			Main.gore[num].frameCounter = 0;
			Main.gore[num].behindTiles = false;
			Main.gore[num].light = 0f;
			Main.gore[num].position = Position;
			Main.gore[num].velocity = Velocity;
			Main.gore[num].velocity.Y = Main.gore[num].velocity.Y - (float)Main.rand.Next(10, 31) * 0.1f;
			Main.gore[num].velocity.X = Main.gore[num].velocity.X + (float)Main.rand.Next(-20, 21) * 0.1f;
			Main.gore[num].type = Type;
			Main.gore[num].active = true;
			Main.gore[num].alpha = 0;
			Main.gore[num].rotation = 0f;
			Main.gore[num].scale = Scale;
			if (!ChildSafety.Disabled && ChildSafety.DangerousGore(Type))
			{
				Main.gore[num].type = Main.rand.Next(11, 14);
				Main.gore[num].scale = Main.rand.NextFloat() * 0.5f + 0.5f;
				Gore gore = Main.gore[num];
				gore.velocity = gore.velocity / 2f;
			}
			if (Gore.goreTime == 0 || Type == 11 || Type == 12 || Type == 13 || Type == 16 || Type == 17 || Type == 61 || Type == 62 || Type == 63 || Type == 99 || Type == 220 || Type == 221 || Type == 222 || Type == 435 || Type == 436 || Type == 437 || Type >= 861 && Type <= 862)
			{
				Main.gore[num].sticky = false;
			}
			else if (Type < 375 || Type > 377)
			{
				Main.gore[num].sticky = true;
				Main.gore[num].timeLeft = Gore.goreTime;
			}
			else
			{
				Main.gore[num].sticky = false;
				Main.gore[num].alpha = 100;
			}
			if (Type >= 706 && Type <= 717)
			{
				Main.gore[num].numFrames = 15;
				Main.gore[num].behindTiles = true;
				Main.gore[num].timeLeft = Gore.goreTime * 3;
			}
			if (Type == 16 || Type == 17)
			{
				Main.gore[num].alpha = 100;
				Main.gore[num].scale = 0.7f;
				Main.gore[num].light = 1f;
			}
			if (Type >= 570 && Type <= 572)
			{
				Main.gore[num].velocity = Velocity;
			}
			if (Type == 860 || Type == 892 || Type == 893)
			{
				Main.gore[num].velocity = new Vector2((Main.rand.NextFloat() - 0.5f) * 3f, Main.rand.NextFloat() * 6.28318548f);
			}
			if (Type >= 411 && Type <= 430 && Main.goreLoaded[Type])
			{
				Main.gore[num].position.X = Position.X - (float)(Main.goreTexture[Type].Width / 2) * Scale;
				Main.gore[num].position.Y = Position.Y - (float)Main.goreTexture[Type].Height * Scale;
				Main.gore[num].velocity.Y = Main.gore[num].velocity.Y * ((float)Main.rand.Next(90, 150) * 0.01f);
				Main.gore[num].velocity.X = Main.gore[num].velocity.X * ((float)Main.rand.Next(40, 90) * 0.01f);
				int num2 = Main.rand.Next(4) * 5;
				Gore gore1 = Main.gore[num];
				gore1.type = gore1.type + num2;
				Main.gore[num].timeLeft = Main.rand.Next(Gore.goreTime / 2, Gore.goreTime * 2);
			}
			if (Type >= 825 && Type <= 827)
			{
				Main.gore[num].sticky = false;
				if (Main.goreLoaded[Type])
				{
					Main.gore[num].alpha = 150;
					Main.gore[num].velocity = Velocity;
					Main.gore[num].position.X = Position.X - (float)(Main.goreTexture[Type].Width / 2) * Scale;
					Main.gore[num].position.Y = Position.Y - (float)Main.goreTexture[Type].Height * Scale / 2f;
					Main.gore[num].timeLeft = Main.rand.Next(Gore.goreTime / 2, Gore.goreTime + 1);
				}
			}
			return num;
		}

		public void Update()
		{
			if (Main.netMode == 2)
			{
				return;
			}
			if (this.active)
			{
				if (this.type >= 276 && this.type <= 282)
				{
					this.velocity.X = this.velocity.X * 0.98f;
					this.velocity.Y = this.velocity.Y * 0.98f;
					if (this.velocity.Y < this.scale)
					{
						this.velocity.Y = this.velocity.Y + 0.05f;
					}
					if ((double)this.velocity.Y > 0.1)
					{
						if (this.velocity.X <= 0f)
						{
							Gore gore = this;
							gore.rotation = gore.rotation - 0.01f;
						}
						else
						{
							Gore gore1 = this;
							gore1.rotation = gore1.rotation + 0.01f;
						}
					}
				}
				if (this.type >= 570 && this.type <= 572)
				{
					Gore gore2 = this;
					gore2.scale = gore2.scale - 0.001f;
					if ((double)this.scale <= 0.01)
					{
						this.scale = 0.01f;
						Gore.goreTime = 0;
					}
					this.sticky = false;
					this.rotation = this.velocity.X * 0.1f;
				}
				else if (this.type >= 706 && this.type <= 717)
				{
					if ((double)this.position.Y >= Main.worldSurface * 16 + 8)
					{
						this.alpha = 100;
					}
					else
					{
						this.alpha = 0;
					}
					int num = 4;
					Gore gore3 = this;
					gore3.frameCounter = (byte)(gore3.frameCounter + 1);
					if (this.frame <= 4)
					{
						int x = (int)(this.position.X / 16f);
						int y = (int)(this.position.Y / 16f) - 1;
						if (WorldGen.InWorld(x, y, 0) && !Main.tile[x, y].active())
						{
							this.active = false;
						}
						if (this.frame == 0)
						{
							num = 24 + Main.rand.Next(256);
						}
						if (this.frame == 1)
						{
							num = 24 + Main.rand.Next(256);
						}
						if (this.frame == 2)
						{
							num = 24 + Main.rand.Next(256);
						}
						if (this.frame == 3)
						{
							num = 24 + Main.rand.Next(96);
						}
						if (this.frame == 5)
						{
							num = 16 + Main.rand.Next(64);
						}
						if (this.type == 716)
						{
							num = num * 2;
						}
						if (this.type == 717)
						{
							num = num * 4;
						}
						if (this.frameCounter >= num)
						{
							this.frameCounter = 0;
							Gore gore4 = this;
							gore4.frame = (byte)(gore4.frame + 1);
							if (this.frame == 5)
							{
								int num1 = Gore.NewGore(this.position, this.velocity, this.type, 1f);
								Main.gore[num1].frame = 9;
								Gore gore5 = Main.gore[num1];
								gore5.velocity = gore5.velocity * 0f;
							}
						}
					}
					else if (this.frame <= 6)
					{
						num = 8;
						if (this.type == 716)
						{
							num = num * 2;
						}
						if (this.type == 717)
						{
							num = num * 3;
						}
						if (this.frameCounter >= num)
						{
							this.frameCounter = 0;
							Gore gore6 = this;
							gore6.frame = (byte)(gore6.frame + 1);
							if (this.frame == 7)
							{
								this.active = false;
							}
						}
					}
					else if (this.frame > 9)
					{
						if (this.type == 716)
						{
							num = num * 2;
						}
						else if (this.type == 717)
						{
							num = num * 6;
						}
						this.velocity.Y = this.velocity.Y + 0.1f;
						if (this.frameCounter >= num)
						{
							this.frameCounter = 0;
							Gore gore7 = this;
							gore7.frame = (byte)(gore7.frame + 1);
						}
						Gore gore8 = this;
						gore8.velocity = gore8.velocity * 0f;
						if (this.frame > 14)
						{
							this.active = false;
						}
					}
					else
					{
						num = 6;
						if (this.type == 716)
						{
							num = (int)((double)num * 1.5);
							this.velocity.Y = this.velocity.Y + 0.175f;
						}
						else if (this.type != 717)
						{
							this.velocity.Y = this.velocity.Y + 0.2f;
						}
						else
						{
							num = num * 2;
							this.velocity.Y = this.velocity.Y + 0.15f;
						}
						if ((double)this.velocity.Y < 0.5)
						{
							this.velocity.Y = 0.5f;
						}
						if (this.velocity.Y > 12f)
						{
							this.velocity.Y = 12f;
						}
						if (this.frameCounter >= num)
						{
							this.frameCounter = 0;
							Gore gore9 = this;
							gore9.frame = (byte)(gore9.frame + 1);
						}
						if (this.frame > 9)
						{
							this.frame = 7;
						}
					}
				}
				else if (this.type == 11 || this.type == 12 || this.type == 13 || this.type == 61 || this.type == 62 || this.type == 63 || this.type == 99 || this.type == 220 || this.type == 221 || this.type == 222 || this.type >= 375 && this.type <= 377 || this.type >= 435 && this.type <= 437 || this.type >= 861 && this.type <= 862)
				{
					this.velocity.Y = this.velocity.Y * 0.98f;
					this.velocity.X = this.velocity.X * 0.98f;
					Gore gore10 = this;
					gore10.scale = gore10.scale - 0.007f;
					if ((double)this.scale < 0.1)
					{
						this.scale = 0.1f;
						this.alpha = 255;
					}
				}
				else if (this.type == 16 || this.type == 17)
				{
					this.velocity.Y = this.velocity.Y * 0.98f;
					this.velocity.X = this.velocity.X * 0.98f;
					Gore gore11 = this;
					gore11.scale = gore11.scale - 0.01f;
					if ((double)this.scale < 0.1)
					{
						this.scale = 0.1f;
						this.alpha = 255;
					}
				}
				else if (this.type == 331)
				{
					Gore gore12 = this;
					gore12.alpha = gore12.alpha + 5;
					this.velocity.Y = this.velocity.Y * 0.95f;
					this.velocity.X = this.velocity.X * 0.95f;
					this.rotation = this.velocity.X * 0.1f;
				}
				else if (this.type != 860 && this.type != 892 && this.type != 893 && (this.type < 825 || this.type > 827) && (this.type < 411 || this.type > 430))
				{
					this.velocity.Y = this.velocity.Y + 0.2f;
				}
				Gore x1 = this;
				x1.rotation = x1.rotation + this.velocity.X * 0.1f;
				if (this.type >= 580 && this.type <= 582)
				{
					this.rotation = 0f;
					this.velocity.X = this.velocity.X * 0.95f;
				}
				if (this.type >= 825 && this.type <= 827)
				{
					if (this.timeLeft < 60)
					{
						Gore gore13 = this;
						gore13.alpha = gore13.alpha + Main.rand.Next(1, 7);
					}
					else if (this.alpha > 100)
					{
						Gore gore14 = this;
						gore14.alpha = gore14.alpha - Main.rand.Next(1, 4);
					}
					if (this.alpha < 0)
					{
						this.alpha = 0;
					}
					if (this.alpha > 255)
					{
						this.timeLeft = 0;
					}
					this.velocity.X = (this.velocity.X * 50f + Main.windSpeed * 2f + (float)Main.rand.Next(-10, 11) * 0.1f) / 51f;
					float single = 0f;
					if (this.velocity.X < 0f)
					{
						single = this.velocity.X * 0.2f;
					}
					this.velocity.Y = (this.velocity.Y * 50f + -0.35f + single + (float)Main.rand.Next(-10, 11) * 0.2f) / 51f;
					this.rotation = this.velocity.X * 0.6f;
					float single1 = -1f;
					if (Main.goreLoaded[this.type])
					{
						Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, (int)((float)Main.goreTexture[this.type].Width * this.scale), (int)((float)Main.goreTexture[this.type].Height * this.scale));
						for (int i = 0; i < 255; i++)
						{
							if (Main.player[i].active && !Main.player[i].dead)
							{
								Rectangle rectangle1 = new Rectangle((int)Main.player[i].position.X, (int)Main.player[i].position.Y, Main.player[i].width, Main.player[i].height);
								if (rectangle.Intersects(rectangle1))
								{
									this.timeLeft = 0;
									single1 = Main.player[i].velocity.Length();
									break;
								}
							}
						}
					}
					if (this.timeLeft <= 0)
					{
						this.alpha = 255;
						if (Main.goreLoaded[this.type] && single1 != -1f)
						{
							float width = (float)Main.goreTexture[this.type].Width * this.scale * 0.8f;
							float x2 = this.position.X;
							float y1 = this.position.Y;
							float width1 = (float)Main.goreTexture[this.type].Width * this.scale;
							float height = (float)Main.goreTexture[this.type].Height * this.scale;
							int num2 = 31;
							for (int j = 0; (float)j < width; j++)
							{
								Vector2 vector2 = new Vector2(x2, y1);
								int num3 = (int)width1;
								int num4 = (int)height;
								Color color = new Color();
								int num5 = Dust.NewDust(vector2, num3, num4, num2, 0f, 0f, 0, color, 1f);
								Dust dust = Main.dust[num5];
								dust.velocity = dust.velocity * ((1f + single1) / 3f);
								Main.dust[num5].noGravity = true;
								Main.dust[num5].alpha = 100;
								Main.dust[num5].scale = this.scale;
							}
						}
					}
					else
					{
						if (Main.rand.Next(2) == 0)
						{
							Gore gore15 = this;
							gore15.timeLeft = gore15.timeLeft - 1;
						}
						if (Main.rand.Next(50) == 0)
						{
							Gore gore16 = this;
							gore16.timeLeft = gore16.timeLeft - 5;
						}
						if (Main.rand.Next(100) == 0)
						{
							Gore gore17 = this;
							gore17.timeLeft = gore17.timeLeft - 10;
						}
					}
				}
				if (this.type >= 411 && this.type <= 430)
				{
					this.alpha = 50;
					this.velocity.X = (this.velocity.X * 50f + Main.windSpeed * 2f + (float)Main.rand.Next(-10, 11) * 0.1f) / 51f;
					this.velocity.Y = (this.velocity.Y * 50f + -0.25f + (float)Main.rand.Next(-10, 11) * 0.2f) / 51f;
					this.rotation = this.velocity.X * 0.3f;
					if (Main.goreLoaded[this.type])
					{
						Rectangle rectangle2 = new Rectangle((int)this.position.X, (int)this.position.Y, (int)((float)Main.goreTexture[this.type].Width * this.scale), (int)((float)Main.goreTexture[this.type].Height * this.scale));
						for (int k = 0; k < 255; k++)
						{
							if (Main.player[k].active && !Main.player[k].dead)
							{
								Rectangle rectangle3 = new Rectangle((int)Main.player[k].position.X, (int)Main.player[k].position.Y, Main.player[k].width, Main.player[k].height);
								if (rectangle2.Intersects(rectangle3))
								{
									this.timeLeft = 0;
								}
							}
						}
						if (Collision.SolidCollision(this.position, (int)((float)Main.goreTexture[this.type].Width * this.scale), (int)((float)Main.goreTexture[this.type].Height * this.scale)))
						{
							this.timeLeft = 0;
						}
					}
					if (this.timeLeft <= 0)
					{
						this.alpha = 255;
						if (Main.goreLoaded[this.type])
						{
							float width2 = (float)Main.goreTexture[this.type].Width * this.scale * 0.8f;
							float single2 = this.position.X;
							float y2 = this.position.Y;
							float width3 = (float)Main.goreTexture[this.type].Width * this.scale;
							float height1 = (float)Main.goreTexture[this.type].Height * this.scale;
							int num6 = 176;
							if (this.type >= 416 && this.type <= 420)
							{
								num6 = 177;
							}
							if (this.type >= 421 && this.type <= 425)
							{
								num6 = 178;
							}
							if (this.type >= 426 && this.type <= 430)
							{
								num6 = 179;
							}
							for (int l = 0; (float)l < width2; l++)
							{
								Vector2 vector21 = new Vector2(single2, y2);
								int num7 = (int)width3;
								int num8 = (int)height1;
								Color color1 = new Color();
								int num9 = Dust.NewDust(vector21, num7, num8, num6, 0f, 0f, 0, color1, 1f);
								Main.dust[num9].noGravity = true;
								Main.dust[num9].alpha = 100;
								Main.dust[num9].scale = this.scale;
							}
						}
					}
					else
					{
						if (Main.rand.Next(2) == 0)
						{
							Gore gore18 = this;
							gore18.timeLeft = gore18.timeLeft - 1;
						}
						if (Main.rand.Next(50) == 0)
						{
							Gore gore19 = this;
							gore19.timeLeft = gore19.timeLeft - 5;
						}
						if (Main.rand.Next(100) == 0)
						{
							Gore gore20 = this;
							gore20.timeLeft = gore20.timeLeft - 10;
						}
					}
				}
				else if (this.type != 860 && this.type != 892 && this.type != 893)
				{
					if (this.type >= 706 && this.type <= 717)
					{
						if (this.type == 716)
						{
							float single3 = 1f;
							float single4 = 1f;
							float single5 = 1f;
							float single6 = 0.6f;
							if (this.frame == 0)
							{
								single6 = single6 * 0.1f;
							}
							else if (this.frame == 1)
							{
								single6 = single6 * 0.2f;
							}
							else if (this.frame == 2)
							{
								single6 = single6 * 0.3f;
							}
							else if (this.frame == 3)
							{
								single6 = single6 * 0.4f;
							}
							else if (this.frame == 4)
							{
								single6 = single6 * 0.5f;
							}
							else if (this.frame == 5)
							{
								single6 = single6 * 0.4f;
							}
							else if (this.frame == 6)
							{
								single6 = single6 * 0.2f;
							}
							else if (this.frame <= 9)
							{
								single6 = single6 * 0.5f;
							}
							else if (this.frame == 10)
							{
								single6 = single6 * 0.5f;
							}
							else if (this.frame == 11)
							{
								single6 = single6 * 0.4f;
							}
							else if (this.frame == 12)
							{
								single6 = single6 * 0.3f;
							}
							else if (this.frame != 13)
							{
								single6 = (this.frame != 14 ? 0f : single6 * 0.1f);
							}
							else
							{
								single6 = single6 * 0.2f;
							}
							single3 = 1f * single6;
							single4 = 0.5f * single6;
							single5 = 0.1f * single6;
							Lighting.AddLight(this.position + new Vector2(8f, 8f), single3, single4, single5);
						}
						Vector2 vector22 = this.velocity;
						this.velocity = Collision.TileCollision(this.position, this.velocity, 16, 14, false, false, 1);
						if (this.velocity != vector22)
						{
							if (this.frame < 10)
							{
								this.frame = 10;
								this.frameCounter = 0;
								if (this.type != 716 && this.type != 717)
								{
									Main.PlaySound(39, (int)this.position.X + 8, (int)this.position.Y + 8, Main.rand.Next(2));
								}
							}
						}
						else if (Collision.WetCollision(this.position + this.velocity, 16, 14))
						{
							if (this.frame < 10)
							{
								this.frame = 10;
								this.frameCounter = 0;
								if (this.type != 716 && this.type != 717)
								{
									Main.PlaySound(39, (int)this.position.X + 8, (int)this.position.Y + 8, 2);
								}
							}
							int x3 = (int)(this.position.X + 8f) / 16;
							int y3 = (int)(this.position.Y + 14f) / 16;
							if (Main.tile[x3, y3] != null && Main.tile[x3, y3].liquid > 0)
							{
								Gore gore21 = this;
								gore21.velocity = gore21.velocity * 0f;
								this.position.Y = (float)(y3 * 16 - Main.tile[x3, y3].liquid / 16);
							}
						}
					}
					else if (!this.sticky)
					{
						Gore gore22 = this;
						gore22.alpha = gore22.alpha + 2;
					}
					else
					{
						int height2 = 32;
						if (Main.goreLoaded[this.type])
						{
							height2 = Main.goreTexture[this.type].Width;
							if (Main.goreTexture[this.type].Height < height2)
							{
								height2 = Main.goreTexture[this.type].Height;
							}
						}
						height2 = (int)((float)height2 * 0.9f);
						this.velocity = Collision.TileCollision(this.position, this.velocity, (int)((float)height2 * this.scale), (int)((float)height2 * this.scale), false, false, 1);
						if (this.velocity.Y == 0f)
						{
							this.velocity.X = this.velocity.X * 0.97f;
							if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
							{
								this.velocity.X = 0f;
							}
						}
						if (this.timeLeft <= 0)
						{
							Gore gore23 = this;
							gore23.alpha = gore23.alpha + 1;
						}
						else
						{
							Gore gore24 = this;
							gore24.timeLeft = gore24.timeLeft - 1;
						}
					}
				}
				if (this.type != 860 && this.type != 892 && this.type != 893)
				{
					Gore gore25 = this;
					gore25.position = gore25.position + this.velocity;
				}
				else if (this.velocity.Y >= 0f)
				{
					this.velocity.Y = this.velocity.Y + 0.05235988f;
					Vector2 unitY = Vector2.UnitY;
					double y4 = (double)this.velocity.Y;
					Vector2 vector23 = new Vector2();
					Vector2 unitY1 = Vector2.UnitY;
					double y5 = (double)this.velocity.Y;
					Vector2 vector24 = new Vector2();
					Vector2 vector25 = new Vector2(unitY.RotatedBy(y4, vector23).X * 2f, Math.Abs(unitY1.RotatedBy(y5, vector24).Y) * 3f);
					vector25 = vector25 * 2f;
					int height3 = 32;
					if (Main.goreLoaded[this.type])
					{
						height3 = Main.goreTexture[this.type].Width;
						if (Main.goreTexture[this.type].Height < height3)
						{
							height3 = Main.goreTexture[this.type].Height;
						}
					}
					Vector2 vector26 = vector25;
					vector25 = Collision.TileCollision(this.position, vector25, (int)((float)height3 * this.scale), (int)((float)height3 * this.scale), false, false, 1);
					if (vector25 != vector26)
					{
						this.velocity.Y = -1f;
					}
					Gore gore26 = this;
					gore26.position = gore26.position + vector25;
					this.rotation = vector25.ToRotation() + 3.14159274f;
					if (this.timeLeft <= 0)
					{
						Gore gore27 = this;
						gore27.alpha = gore27.alpha + 1;
					}
					else
					{
						Gore gore28 = this;
						gore28.timeLeft = gore28.timeLeft - 1;
					}
				}
				else
				{
					Vector2 x4 = new Vector2(this.velocity.X, 0.6f);
					int width4 = 32;
					if (Main.goreLoaded[this.type])
					{
						width4 = Main.goreTexture[this.type].Width;
						if (Main.goreTexture[this.type].Height < width4)
						{
							width4 = Main.goreTexture[this.type].Height;
						}
					}
					width4 = (int)((float)width4 * 0.9f);
					x4 = Collision.TileCollision(this.position, x4, (int)((float)width4 * this.scale), (int)((float)width4 * this.scale), false, false, 1);
					x4.X = x4.X * 0.97f;
					if ((double)x4.X > -0.01 && (double)x4.X < 0.01)
					{
						x4.X = 0f;
					}
					if (this.timeLeft <= 0)
					{
						Gore gore29 = this;
						gore29.alpha = gore29.alpha + 1;
					}
					else
					{
						Gore gore30 = this;
						gore30.timeLeft = gore30.timeLeft - 1;
					}
					this.velocity.X = x4.X;
				}
				if (this.alpha >= 255)
				{
					this.active = false;
				}
				if (this.light > 0f)
				{
					float single7 = this.light * this.scale;
					float single8 = this.light * this.scale;
					float single9 = this.light * this.scale;
					if (this.type == 16)
					{
						single9 = single9 * 0.3f;
						single8 = single8 * 0.8f;
					}
					else if (this.type == 17)
					{
						single8 = single8 * 0.6f;
						single7 = single7 * 0.3f;
					}
					if (Main.goreLoaded[this.type])
					{
						Lighting.AddLight((int)((this.position.X + (float)Main.goreTexture[this.type].Width * this.scale / 2f) / 16f), (int)((this.position.Y + (float)Main.goreTexture[this.type].Height * this.scale / 2f) / 16f), single7, single8, single9);
						return;
					}
					Lighting.AddLight((int)((this.position.X + 32f * this.scale / 2f) / 16f), (int)((this.position.Y + 32f * this.scale / 2f) / 16f), single7, single8, single9);
				}
			}
		}
	}
}