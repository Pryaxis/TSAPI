using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;

namespace Terraria
{
	public class Dust
	{
		public static float dCount;

		public static int lavaBubbles;

		public Vector2 position;

		public Vector2 velocity;

		public float fadeIn;

		public bool noGravity;

		public float scale;

		public float rotation;

		public bool noLight;

		public bool active;

		public int type;

		public Color color;

		public int alpha;

		public Rectangle frame;

		public ArmorShaderData shader;

		public object customData;

		public bool firstFrame;

		static Dust()
		{
		}

		public Dust()
		{
		}

		public static Dust CloneDust(int dustIndex)
		{
			return Dust.CloneDust(Main.dust[dustIndex]);
		}

		public static Dust CloneDust(Dust rf)
		{
			Dust[] dustArray = Main.dust;
			Vector2 vector2 = rf.position;
			int num = rf.type;
			Color color = new Color();
			Dust dust = dustArray[Dust.NewDust(vector2, 0, 0, num, 0f, 0f, 0, color, 1f)];
			dust.position = rf.position;
			dust.velocity = rf.velocity;
			dust.fadeIn = rf.fadeIn;
			dust.noGravity = rf.noGravity;
			dust.scale = rf.scale;
			dust.rotation = rf.rotation;
			dust.noLight = rf.noLight;
			dust.active = rf.active;
			dust.type = rf.type;
			dust.color = rf.color;
			dust.alpha = rf.alpha;
			dust.frame = rf.frame;
			dust.shader = rf.shader;
			dust.customData = rf.customData;
			return dust;
		}

		public static int dustWater()
		{
			switch (Main.waterStyle)
			{
				case 2:
				{
					return 98;
				}
				case 3:
				{
					return 99;
				}
				case 4:
				{
					return 100;
				}
				case 5:
				{
					return 101;
				}
				case 6:
				{
					return 102;
				}
				case 7:
				{
					return 103;
				}
				case 8:
				{
					return 104;
				}
				case 9:
				{
					return 105;
				}
				case 10:
				{
					return 123;
				}
			}
			return 33;
		}

		public Color GetAlpha(Color newColor)
		{
			int r;
			int g;
			int b;
			float single = (float)(255 - this.alpha) / 255f;
			if (this.type == 259)
			{
				return new Color(230, 230, 230, 230);
			}
			if (this.type == 261)
			{
				return new Color(230, 230, 230, 115);
			}
			if (this.type == 254 || this.type == 255)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 258)
			{
				return new Color(150, 50, 50, 0);
			}
			if (this.type == 263 || this.type == 264)
			{
				return new Color(this.color.R / 2 + 127, this.color.G + 127, this.color.B + 127, this.color.A / 8) * 0.5f;
			}
			if (this.type == 235)
			{
				return new Color(255, 255, 255, 0);
			}
			if ((this.type >= 86 && this.type <= 91 || this.type == 262) && !this.noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 213 || this.type == 260)
			{
				int num = (int)(this.scale / 2.5f * 255f);
				return new Color(num, num, num, num);
			}
			if (this.type == 64 && this.alpha == 255 && this.noLight)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 197)
			{
				return new Color(250, 250, 250, 150);
			}
			if (this.type >= 110 && this.type <= 114)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 204)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 181)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 182 || this.type == 206)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 159)
			{
				return new Color(250, 250, 250, 50);
			}
			if (this.type == 163 || this.type == 205)
			{
				return new Color(250, 250, 250, 0);
			}
			if (this.type == 170)
			{
				return new Color(200, 200, 200, 100);
			}
			if (this.type == 180)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 175)
			{
				return new Color(200, 200, 200, 0);
			}
			if (this.type == 183)
			{
				return new Color(50, 0, 0, 0);
			}
			if (this.type == 172)
			{
				return new Color(250, 250, 250, 150);
			}
			if (this.type == 160 || this.type == 162 || this.type == 164 || this.type == 173)
			{
				int num1 = (int)(250f * this.scale);
				return new Color(num1, num1, num1, 0);
			}
			if (this.type == 92 || this.type == 106 || this.type == 107)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 185)
			{
				return new Color(200, 200, 255, 125);
			}
			if (this.type == 127 || this.type == 187)
			{
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if (this.type == 156 || this.type == 230 || this.type == 234)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 6 || this.type == 242 || this.type == 174 || this.type == 135 || this.type == 75 || this.type == 20 || this.type == 21 || this.type == 231 || this.type == 169 || this.type >= 130 && this.type <= 134 || this.type == 158)
			{
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if (this.type >= 219 && this.type <= 223)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.5f);
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if (this.type == 226)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.8f);
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if (this.type == 228)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.8f);
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if (this.type == 229)
			{
				newColor = Color.Lerp(newColor, Color.White, 0.6f);
				return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 25);
			}
			if ((this.type == 68 || this.type == 70) && this.noGravity)
			{
				return new Color(255, 255, 255, 0);
			}
			if (this.type == 157)
			{
				int num2 = 255;
				b = num2;
				g = num2;
				r = num2;
				float single1 = (float)Main.mouseTextColor / 100f - 1.6f;
				r = (int)((float)r * single1);
				g = (int)((float)g * single1);
				b = (int)((float)b * single1);
				int num3 = (int)(100f * single1);
				r = r + 50;
				if (r > 255)
				{
					r = 255;
				}
				g = g + 50;
				if (g > 255)
				{
					g = 255;
				}
				b = b + 50;
				if (b > 255)
				{
					b = 255;
				}
				return new Color(r, g, b, num3);
			}
			if (this.type == 15 || this.type == 20 || this.type == 21 || this.type == 29 || this.type == 35 || this.type == 41 || this.type == 44 || this.type == 27 || this.type == 45 || this.type == 55 || this.type == 56 || this.type == 57 || this.type == 58 || this.type == 73 || this.type == 74)
			{
				single = (single + 3f) / 4f;
			}
			else if (this.type != 43)
			{
				if (this.type >= 244 && this.type <= 247)
				{
					return new Color(255, 255, 255, 0);
				}
				if (this.type == 66)
				{
					return new Color((int)newColor.R, (int)newColor.G, (int)newColor.B, 0);
				}
				if (this.type == 267)
				{
					return new Color((int)this.color.R, (int)this.color.G, (int)this.color.B, 0);
				}
				if (this.type == 71)
				{
					return new Color(200, 200, 200, 0);
				}
				if (this.type == 72)
				{
					return new Color(200, 200, 200, 200);
				}
			}
			else
			{
				single = (single + 9f) / 10f;
			}
			r = (int)((float)newColor.R * single);
			g = (int)((float)newColor.G * single);
			b = (int)((float)newColor.B * single);
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

		public Color GetColor(Color newColor)
		{
			int r = this.color.R - (255 - newColor.R);
			int g = this.color.G - (255 - newColor.G);
			int b = this.color.B - (255 - newColor.B);
			int a = this.color.A - (255 - newColor.A);
			if (r < 0)
			{
				r = 0;
			}
			if (r > 255)
			{
				r = 255;
			}
			if (g < 0)
			{
				g = 0;
			}
			if (g > 255)
			{
				g = 255;
			}
			if (b < 0)
			{
				b = 0;
			}
			if (b > 255)
			{
				b = 255;
			}
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

		public static int NewDust(Vector2 Position, int Width, int Height, int Type, float SpeedX = 0f, float SpeedY = 0f, int Alpha = 0, Color newColor = new Color(), float Scale = 1f)
		{
			if (Main.gameMenu)
			{
				return 6000;
			}
			if (Main.rand == null)
			{
				Main.rand = new Random((int)DateTime.Now.Ticks);
			}
			if (Main.gamePaused)
			{
				return 6000;
			}
			if (WorldGen.gen)
			{
				return 6000;
			}
			if (Main.netMode == 2)
			{
				return 6000;
			}
			int num = (int)(400f * (1f - Dust.dCount));
			Rectangle rectangle = new Rectangle((int)(Main.screenPosition.X - (float)num), (int)(Main.screenPosition.Y - (float)num), Main.screenWidth + num * 2, Main.screenHeight + num * 2);
			Rectangle rectangle1 = new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
			if (!rectangle.Intersects(rectangle1))
			{
				return 6000;
			}
			int num1 = 6000;
			int num2 = 0;
			while (num2 < 6000)
			{
				Dust type = Main.dust[num2];
				if (type.active)
				{
					num2++;
				}
				else
				{
					if ((double)num2 > (double)Main.numDust * 0.9)
					{
						if (Main.rand.Next(4) != 0)
						{
							return 5999;
						}
					}
					else if ((double)num2 > (double)Main.numDust * 0.8)
					{
						if (Main.rand.Next(3) != 0)
						{
							return 5999;
						}
					}
					else if ((double)num2 > (double)Main.numDust * 0.7)
					{
						if (Main.rand.Next(2) == 0)
						{
							return 5999;
						}
					}
					else if ((double)num2 > (double)Main.numDust * 0.6)
					{
						if (Main.rand.Next(4) == 0)
						{
							return 5999;
						}
					}
					else if ((double)num2 <= (double)Main.numDust * 0.5)
					{
						Dust.dCount = 0f;
					}
					else if (Main.rand.Next(5) == 0)
					{
						return 5999;
					}
					int width = Width;
					int height = Height;
					if (width < 5)
					{
						width = 5;
					}
					if (height < 5)
					{
						height = 5;
					}
					num1 = num2;
					type.fadeIn = 0f;
					type.active = true;
					type.type = Type;
					type.noGravity = false;
					type.color = newColor;
					type.alpha = Alpha;
					type.position.X = Position.X + (float)Main.rand.Next(width - 4) + 4f;
					type.position.Y = Position.Y + (float)Main.rand.Next(height - 4) + 4f;
					type.velocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedX;
					type.velocity.Y = (float)Main.rand.Next(-20, 21) * 0.1f + SpeedY;
					type.frame.X = 10 * Type;
					type.frame.Y = 10 * Main.rand.Next(3);
					type.shader = null;
					type.customData = null;
					int type1 = Type;
					while (type1 >= 100)
					{
						type1 = type1 - 100;
						type.frame.X = type.frame.X - 1000;
						type.frame.Y = type.frame.Y + 30;
					}
					type.frame.Width = 8;
					type.frame.Height = 8;
					type.rotation = 0f;
					type.scale = 1f + (float)Main.rand.Next(-20, 21) * 0.01f;
					Dust scale = type;
					scale.scale = scale.scale * Scale;
					type.noLight = false;
					type.firstFrame = true;
					if (type.type == 228 || type.type == 135 || type.type == 6 || type.type == 242 || type.type == 75 || type.type == 169 || type.type == 29 || type.type >= 59 && type.type <= 65 || type.type == 158)
					{
						type.velocity.Y = (float)Main.rand.Next(-10, 6) * 0.1f;
						type.velocity.X = type.velocity.X * 0.3f;
						Dust dust = type;
						dust.scale = dust.scale * 0.7f;
					}
					if (type.type == 127 || type.type == 187)
					{
						Dust dust1 = type;
						dust1.velocity = dust1.velocity * 0.3f;
						Dust dust2 = type;
						dust2.scale = dust2.scale * 0.7f;
					}
					if (type.type == 33 || type.type == 52 || type.type == 266 || type.type == 98 || type.type == 99 || type.type == 100 || type.type == 101 || type.type == 102 || type.type == 103 || type.type == 104 || type.type == 105)
					{
						type.alpha = 170;
						Dust dust3 = type;
						dust3.velocity = dust3.velocity * 0.5f;
						type.velocity.Y = type.velocity.Y + 1f;
					}
					if (type.type == 41)
					{
						Dust dust4 = type;
						dust4.velocity = dust4.velocity * 0f;
					}
					if (type.type == 80)
					{
						type.alpha = 50;
					}
					if (type.type != 34 && type.type != 35 && type.type != 152)
					{
						break;
					}
					Dust dust5 = type;
					dust5.velocity = dust5.velocity * 0.1f;
					type.velocity.Y = -0.5f;
					if (type.type != 34 || Collision.WetCollision(new Vector2(type.position.X, type.position.Y - 8f), 4, 4))
					{
						break;
					}
					type.active = false;
					break;
				}
			}
			return num1;
		}

		public static Dust QuickDust(Point tileCoords, Color color)
		{
			Dust[] dustArray = Main.dust;
			Vector2 vector2 = tileCoords.ToVector2() * 16f;
			Color color1 = new Color();
			Dust zero = dustArray[Dust.NewDust(vector2, 0, 0, 267, 0f, 0f, 0, color1, 1f)];
			zero.position = (tileCoords.ToVector2() * 16f) + new Vector2(8f);
			zero.velocity = Vector2.Zero;
			zero.fadeIn = 1f;
			zero.noLight = true;
			zero.noGravity = true;
			zero.color = color;
			return zero;
		}

		public static Dust QuickDust(Vector2 pos, Color color)
		{
			Dust[] dustArray = Main.dust;
			Color color1 = new Color();
			Dust zero = dustArray[Dust.NewDust(pos, 0, 0, 6, 0f, 0f, 0, color1, 1f)];
			zero.position = pos;
			zero.velocity = Vector2.Zero;
			zero.fadeIn = 1f;
			zero.noLight = true;
			zero.noGravity = true;
			zero.color = color;
			return zero;
		}

		public static void QuickDustLine(Vector2 start, Vector2 end, float splits, Color color)
		{
			Dust.QuickDust(start, color).scale = 2f;
			Dust.QuickDust(end, color).scale = 2f;
			float single = 1f / splits;
			for (float i = 0f; i < 1f; i = i + single)
			{
				Dust.QuickDust(Vector2.Lerp(start, end, i), color).scale = 2f;
			}
		}

		public static void UpdateDust()
		{
			Color color;
			int num = 0;
			Dust.lavaBubbles = 0;
			Main.snowDust = 0;
			for (int i = 0; i < 6000; i++)
			{
				Dust transparent = Main.dust[i];
				if (i >= Main.numDust)
				{
					transparent.active = false;
				}
				else if (transparent.active)
				{
					Dust.dCount = Dust.dCount + 1f;
					if (transparent.scale > 10f)
					{
						transparent.active = false;
					}
					if (transparent.firstFrame && !ChildSafety.Disabled && ChildSafety.DangerousDust(transparent.type))
					{
						if (Main.rand.Next(2) != 0)
						{
							transparent.active = false;
						}
						else
						{
							transparent.firstFrame = false;
							transparent.type = 16;
							transparent.scale = Main.rand.NextFloat() * 1.6f + 0.3f;
							transparent.color = Color.Transparent;
							transparent.frame.X = 10 * transparent.type;
							transparent.frame.Y = 10 * Main.rand.Next(3);
							transparent.shader = null;
							transparent.customData = null;
							int num1 = transparent.type / 100;
							transparent.frame.X = transparent.frame.X - 1000 * num1;
							transparent.frame.Y = transparent.frame.Y + 30 * num1;
							transparent.noGravity = true;
						}
					}
					if (transparent.type == 35)
					{
						Dust.lavaBubbles = Dust.lavaBubbles + 1;
					}
					Dust dust = transparent;
					dust.position = dust.position + transparent.velocity;
					if (transparent.type == 258)
					{
						transparent.noGravity = true;
						Dust dust1 = transparent;
						dust1.scale = dust1.scale + 0.015f;
					}
					if (transparent.type >= 86 && transparent.type <= 92 && !transparent.noLight)
					{
						float single = transparent.scale * 0.6f;
						if (single > 1f)
						{
							single = 1f;
						}
						int num2 = transparent.type - 85;
						float single1 = single;
						float single2 = single;
						float single3 = single;
						if (num2 == 3)
						{
							single1 = single1 * 0f;
							single2 = single2 * 0.1f;
							single3 = single3 * 1.3f;
						}
						else if (num2 == 5)
						{
							single1 = single1 * 1f;
							single2 = single2 * 0.1f;
							single3 = single3 * 0.1f;
						}
						else if (num2 == 4)
						{
							single1 = single1 * 0f;
							single2 = single2 * 1f;
							single3 = single3 * 0.1f;
						}
						else if (num2 == 1)
						{
							single1 = single1 * 0.9f;
							single2 = single2 * 0f;
							single3 = single3 * 0.9f;
						}
						else if (num2 == 6)
						{
							single1 = single1 * 1.3f;
							single2 = single2 * 1.3f;
							single3 = single3 * 1.3f;
						}
						else if (num2 == 2)
						{
							single1 = single1 * 0.9f;
							single2 = single2 * 0.9f;
							single3 = single3 * 0f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single * single1, single * single2, single * single3);
					}
					if (transparent.type >= 86 && transparent.type <= 92)
					{
						if (transparent.customData != null && transparent.customData is Player)
						{
							Player player = (Player)transparent.customData;
							Dust dust2 = transparent;
							dust2.position = dust2.position + (player.position - player.oldPosition);
						}
						else if (transparent.customData != null && transparent.customData is Projectile)
						{
							Projectile projectile = (Projectile)transparent.customData;
							if (projectile.active)
							{
								Dust dust3 = transparent;
								dust3.position = dust3.position + (projectile.position - projectile.oldPosition);
							}
						}
					}
					if (transparent.type == 262 && !transparent.noLight)
					{
						Vector3 vector3 = (new Vector3(0.9f, 0.6f, 0f) * transparent.scale) * 0.6f;
						Lighting.AddLight(transparent.position, vector3);
					}
					if (transparent.type == 240 && transparent.customData != null && transparent.customData is Projectile)
					{
						Projectile projectile1 = (Projectile)transparent.customData;
						if (projectile1.active)
						{
							Dust dust4 = transparent;
							dust4.position = dust4.position + (projectile1.position - projectile1.oldPosition);
						}
					}
					if (transparent.type == 263 || transparent.type == 264)
					{
						if (!transparent.noLight)
						{
							Vector3 vector31 = (transparent.color.ToVector3() * transparent.scale) * 0.4f;
							Lighting.AddLight(transparent.position, vector31);
						}
						if (transparent.customData != null && transparent.customData is Player)
						{
							Player player1 = (Player)transparent.customData;
							Dust dust5 = transparent;
							dust5.position = dust5.position + (player1.position - player1.oldPosition);
							transparent.customData = null;
						}
						else if (transparent.customData != null && transparent.customData is Projectile)
						{
							Projectile projectile2 = (Projectile)transparent.customData;
							Dust dust6 = transparent;
							dust6.position = dust6.position + (projectile2.position - projectile2.oldPosition);
						}
					}
					if (transparent.type == 230)
					{
						float single4 = transparent.scale * 0.6f;
						float single5 = single4;
						float single6 = single4;
						float single7 = single4;
						single5 = single5 * 0.5f;
						single6 = single6 * 0.9f;
						single7 = single7 * 1f;
						Dust dust7 = transparent;
						dust7.scale = dust7.scale + 0.02f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single4 * single5, single4 * single6, single4 * single7);
						if (transparent.customData != null && transparent.customData is Player)
						{
							Vector2 center = ((Player)transparent.customData).Center;
							Vector2 vector2 = transparent.position - center;
							float single8 = vector2.Length();
							vector2 = vector2 / single8;
							transparent.scale = Math.Min(transparent.scale, single8 / 24f - 1f);
							Dust dust8 = transparent;
							dust8.velocity = dust8.velocity - (vector2 * (100f / Math.Max(50f, single8)));
						}
					}
					if (transparent.type == 154 || transparent.type == 218)
					{
						Dust x = transparent;
						x.rotation = x.rotation + transparent.velocity.X * 0.3f;
						Dust dust9 = transparent;
						dust9.scale = dust9.scale - 0.03f;
					}
					if (transparent.type == 172)
					{
						float single9 = transparent.scale * 0.5f;
						if (single9 > 1f)
						{
							single9 = 1f;
						}
						float single10 = single9;
						float single11 = single9;
						float single12 = single9;
						single10 = single10 * 0f;
						single11 = single11 * 0.25f;
						single12 = single12 * 1f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single9 * single10, single9 * single11, single9 * single12);
					}
					if (transparent.type == 182)
					{
						Dust dust10 = transparent;
						dust10.rotation = dust10.rotation + 1f;
						if (!transparent.noLight)
						{
							float single13 = transparent.scale * 0.25f;
							if (single13 > 1f)
							{
								single13 = 1f;
							}
							float single14 = single13;
							float single15 = single13;
							float single16 = single13;
							single14 = single14 * 1f;
							single15 = single15 * 0.2f;
							single16 = single16 * 0.1f;
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single13 * single14, single13 * single15, single13 * single16);
						}
						if (transparent.customData != null && transparent.customData is Player)
						{
							Player player2 = (Player)transparent.customData;
							Dust dust11 = transparent;
							dust11.position = dust11.position + (player2.position - player2.oldPosition);
							transparent.customData = null;
						}
					}
					if (transparent.type == 261)
					{
						if (!transparent.noLight)
						{
							float single17 = transparent.scale * 0.3f;
							if (single17 > 1f)
							{
								single17 = 1f;
							}
							Lighting.AddLight(transparent.position, new Vector3(0.4f, 0.6f, 0.7f) * single17);
						}
						if (transparent.noGravity)
						{
							Dust dust12 = transparent;
							dust12.velocity = dust12.velocity * 0.93f;
							if (transparent.fadeIn == 0f)
							{
								Dust dust13 = transparent;
								dust13.scale = dust13.scale + 0.0025f;
							}
						}
						Dust vector21 = transparent;
						vector21.velocity = vector21.velocity * new Vector2(0.97f, 0.99f);
						Dust dust14 = transparent;
						dust14.scale = dust14.scale - 0.0025f;
						if (transparent.customData != null && transparent.customData is Player)
						{
							Player player3 = (Player)transparent.customData;
							Dust dust15 = transparent;
							dust15.position = dust15.position + (player3.position - player3.oldPosition);
						}
					}
					if (transparent.type == 254)
					{
						float single18 = transparent.scale * 0.35f;
						if (single18 > 1f)
						{
							single18 = 1f;
						}
						float single19 = single18;
						float single20 = single18;
						float single21 = single18;
						single19 = single19 * 0.9f;
						single20 = single20 * 0.1f;
						single21 = single21 * 0.75f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single18 * single19, single18 * single20, single18 * single21);
					}
					if (transparent.type == 255)
					{
						float single22 = transparent.scale * 0.25f;
						if (single22 > 1f)
						{
							single22 = 1f;
						}
						float single23 = single22;
						float single24 = single22;
						float single25 = single22;
						single23 = single23 * 0.9f;
						single24 = single24 * 0.1f;
						single25 = single25 * 0.75f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single22 * single23, single22 * single24, single22 * single25);
					}
					if (transparent.type == 211 && transparent.noLight && Collision.SolidCollision(transparent.position, 4, 4))
					{
						transparent.active = false;
					}
					if (transparent.type == 213 || transparent.type == 260)
					{
						transparent.rotation = 0f;
						float single26 = transparent.scale / 2.5f * 0.2f;
						Vector3 zero = Vector3.Zero;
						int num3 = transparent.type;
						if (num3 == 213)
						{
							zero = new Vector3(255f, 217f, 48f);
						}
						else if (num3 == 260)
						{
							zero = new Vector3(255f, 48f, 48f);
						}
						zero = zero / 255f;
						if (single26 > 1f)
						{
							single26 = 1f;
						}
						zero = zero * single26;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), zero.X, zero.Y, zero.Z);
					}
					if (transparent.type == 157)
					{
						float single27 = transparent.scale * 0.2f;
						float single28 = single27;
						float single29 = single27;
						float single30 = single27;
						single28 = single28 * 0.25f;
						single29 = single29 * 1f;
						single30 = single30 * 0.5f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single27 * single28, single27 * single29, single27 * single30);
					}
					if (transparent.type == 206)
					{
						Dust dust16 = transparent;
						dust16.scale = dust16.scale - 0.1f;
						float single31 = transparent.scale * 0.4f;
						float single32 = single31;
						float single33 = single31;
						float single34 = single31;
						single32 = single32 * 0.1f;
						single33 = single33 * 0.6f;
						single34 = single34 * 1f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single31 * single32, single31 * single33, single31 * single34);
					}
					if (transparent.type == 163)
					{
						float single35 = transparent.scale * 0.25f;
						float single36 = single35;
						float single37 = single35;
						float single38 = single35;
						single36 = single36 * 0.25f;
						single37 = single37 * 1f;
						single38 = single38 * 0.05f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single35 * single36, single35 * single37, single35 * single38);
					}
					if (transparent.type == 205)
					{
						float single39 = transparent.scale * 0.25f;
						float single40 = single39;
						float single41 = single39;
						float single42 = single39;
						single40 = single40 * 1f;
						single41 = single41 * 0.05f;
						single42 = single42 * 1f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single39 * single40, single39 * single41, single39 * single42);
					}
					if (transparent.type == 170)
					{
						float single43 = transparent.scale * 0.5f;
						float single44 = single43;
						float single45 = single43;
						float single46 = single43;
						single44 = single44 * 1f;
						single45 = single45 * 1f;
						single46 = single46 * 0.05f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single43 * single44, single43 * single45, single43 * single46);
					}
					if (transparent.type == 156)
					{
						float single47 = transparent.scale * 0.6f;
						int num4 = transparent.type;
						float single48 = single47;
						float single49 = single47;
						float single50 = single47;
						single48 = single48 * 0.5f;
						single49 = single49 * 0.9f;
						single50 = single50 * 1f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single47 * single48, single47 * single49, single47 * single50);
					}
					if (transparent.type == 234)
					{
						float single51 = transparent.scale * 0.6f;
						int num5 = transparent.type;
						float single52 = single51;
						float single53 = single51;
						float single54 = single51;
						single52 = single52 * 0.95f;
						single53 = single53 * 0.65f;
						single54 = single54 * 1.3f;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single51 * single52, single51 * single53, single51 * single54);
					}
					if (transparent.type == 175)
					{
						Dust dust17 = transparent;
						dust17.scale = dust17.scale - 0.05f;
					}
					if (transparent.type == 174)
					{
						Dust dust18 = transparent;
						dust18.scale = dust18.scale - 0.01f;
						float single55 = transparent.scale * 1f;
						if (single55 > 0.6f)
						{
							single55 = 0.6f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single55, single55 * 0.4f, 0f);
					}
					if (transparent.type == 235)
					{
						Vector2 vector22 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
						vector22.Normalize();
						vector22 = vector22 * 15f;
						Dust dust19 = transparent;
						dust19.scale = dust19.scale - 0.01f;
					}
					else if (transparent.type == 228 || transparent.type == 229 || transparent.type == 6 || transparent.type == 242 || transparent.type == 135 || transparent.type == 127 || transparent.type == 187 || transparent.type == 75 || transparent.type == 169 || transparent.type == 29 || transparent.type >= 59 && transparent.type <= 65 || transparent.type == 158)
					{
						if (!transparent.noGravity)
						{
							transparent.velocity.Y = transparent.velocity.Y + 0.05f;
						}
						if (transparent.type == 229 || transparent.type == 228)
						{
							if (transparent.customData != null && transparent.customData is NPC)
							{
								NPC nPC = (NPC)transparent.customData;
								Dust dust20 = transparent;
								dust20.position = dust20.position + (nPC.position - nPC.oldPos[1]);
							}
							else if (transparent.customData != null && transparent.customData is Player)
							{
								Player player4 = (Player)transparent.customData;
								Dust dust21 = transparent;
								dust21.position = dust21.position + (player4.position - player4.oldPosition);
							}
							else if (transparent.customData != null && transparent.customData is Vector2)
							{
								Vector2 vector23 = (Vector2)transparent.customData - transparent.position;
								if (vector23 != Vector2.Zero)
								{
									vector23.Normalize();
								}
								transparent.velocity = ((transparent.velocity * 4f) + (vector23 * transparent.velocity.Length())) / 5f;
							}
						}
						if (!transparent.noLight)
						{
							float single56 = transparent.scale * 1.4f;
							if (transparent.type == 29)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 0.1f, single56 * 0.4f, single56);
							}
							else if (transparent.type == 75)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 0.7f, single56, single56 * 0.2f);
							}
							else if (transparent.type == 169)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 1.1f, single56 * 1.1f, single56 * 0.2f);
							}
							else if (transparent.type == 135)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 0.2f, single56 * 0.7f, single56);
							}
							else if (transparent.type == 158)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 1f, single56 * 0.5f, 0f);
							}
							else if (transparent.type == 228)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 0.7f, single56 * 0.65f, single56 * 0.3f);
							}
							else if (transparent.type == 229)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 0.3f, single56 * 0.65f, single56 * 0.7f);
							}
							else if (transparent.type == 242)
							{
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56, 0f, single56);
							}
							else if (transparent.type >= 59 && transparent.type <= 65)
							{
								if (single56 > 0.8f)
								{
									single56 = 0.8f;
								}
								int num6 = transparent.type - 58;
								float single57 = 1f;
								float single58 = 1f;
								float single59 = 1f;
								if (num6 == 1)
								{
									single57 = 0f;
									single58 = 0.1f;
									single59 = 1.3f;
								}
								else if (num6 == 2)
								{
									single57 = 1f;
									single58 = 0.1f;
									single59 = 0.1f;
								}
								else if (num6 == 3)
								{
									single57 = 0f;
									single58 = 1f;
									single59 = 0.1f;
								}
								else if (num6 == 4)
								{
									single57 = 0.9f;
									single58 = 0f;
									single59 = 0.9f;
								}
								else if (num6 == 5)
								{
									single57 = 1.3f;
									single58 = 1.3f;
									single59 = 1.3f;
								}
								else if (num6 == 6)
								{
									single57 = 0.9f;
									single58 = 0.9f;
									single59 = 0f;
								}
								else if (num6 == 7)
								{
									single57 = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
									single58 = 0.3f;
									single59 = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * single57, single56 * single58, single56 * single59);
							}
							else if (transparent.type == 127)
							{
								single56 = single56 * 1.3f;
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56, single56 * 0.45f, single56 * 0.2f);
							}
							else if (transparent.type != 187)
							{
								if (single56 > 0.6f)
								{
									single56 = 0.6f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56, single56 * 0.65f, single56 * 0.4f);
							}
							else
							{
								single56 = single56 * 1.3f;
								if (single56 > 1f)
								{
									single56 = 1f;
								}
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single56 * 0.2f, single56 * 0.45f, single56);
							}
						}
					}
					else if (transparent.type == 159)
					{
						float single60 = transparent.scale * 1.3f;
						if (single60 > 1f)
						{
							single60 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single60, single60, single60 * 0.1f);
						if (!transparent.noGravity)
						{
							Dust dust22 = transparent;
							dust22.scale = dust22.scale + 0.005f;
							Dust dust23 = transparent;
							dust23.velocity = dust23.velocity * 0.9f;
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
							transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
							if (Main.rand.Next(5) == 0)
							{
								Vector2 vector24 = transparent.position;
								int num7 = transparent.type;
								color = new Color();
								int num8 = Dust.NewDust(vector24, 4, 4, num7, 0f, 0f, 0, color, 1f);
								Main.dust[num8].noGravity = true;
								Main.dust[num8].scale = transparent.scale * 2.5f;
							}
						}
						else
						{
							if (transparent.scale < 0.7f)
							{
								Dust dust24 = transparent;
								dust24.velocity = dust24.velocity * 1.075f;
							}
							else if (Main.rand.Next(2) != 0)
							{
								Dust dust25 = transparent;
								dust25.velocity = dust25.velocity * 1.05f;
							}
							else
							{
								Dust dust26 = transparent;
								dust26.velocity = dust26.velocity * -0.95f;
							}
							Dust dust27 = transparent;
							dust27.scale = dust27.scale - 0.03f;
						}
					}
					else if (transparent.type == 164)
					{
						float single61 = transparent.scale;
						if (single61 > 1f)
						{
							single61 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single61, single61 * 0.1f, single61 * 0.8f);
						if (!transparent.noGravity)
						{
							Dust dust28 = transparent;
							dust28.scale = dust28.scale - 0.005f;
							Dust dust29 = transparent;
							dust29.velocity = dust29.velocity * 0.9f;
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
							transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
							if (Main.rand.Next(5) == 0)
							{
								Vector2 vector25 = transparent.position;
								int num9 = transparent.type;
								color = new Color();
								int num10 = Dust.NewDust(vector25, 4, 4, num9, 0f, 0f, 0, color, 1f);
								Main.dust[num10].noGravity = true;
								Main.dust[num10].scale = transparent.scale * 2.5f;
							}
						}
						else
						{
							if (transparent.scale < 0.7f)
							{
								Dust dust30 = transparent;
								dust30.velocity = dust30.velocity * 1.075f;
							}
							else if (Main.rand.Next(2) != 0)
							{
								Dust dust31 = transparent;
								dust31.velocity = dust31.velocity * 1.05f;
							}
							else
							{
								Dust dust32 = transparent;
								dust32.velocity = dust32.velocity * -0.95f;
							}
							Dust dust33 = transparent;
							dust33.scale = dust33.scale - 0.03f;
						}
					}
					else if (transparent.type == 173)
					{
						float single62 = transparent.scale;
						if (single62 > 1f)
						{
							single62 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single62 * 0.4f, single62 * 0.1f, single62);
						if (!transparent.noGravity)
						{
							Dust dust34 = transparent;
							dust34.scale = dust34.scale - 0.015f;
							Dust dust35 = transparent;
							dust35.velocity = dust35.velocity * 0.8f;
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.005f;
							transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.005f;
							if (Main.rand.Next(10) == 10)
							{
								Vector2 vector26 = transparent.position;
								int num11 = transparent.type;
								color = new Color();
								int num12 = Dust.NewDust(vector26, 4, 4, num11, 0f, 0f, 0, color, 1f);
								Main.dust[num12].noGravity = true;
								Main.dust[num12].scale = transparent.scale;
							}
						}
						else
						{
							Dust dust36 = transparent;
							dust36.velocity = dust36.velocity * 0.8f;
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-20, 21) * 0.01f;
							transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-20, 21) * 0.01f;
							Dust dust37 = transparent;
							dust37.scale = dust37.scale - 0.01f;
						}
					}
					else if (transparent.type == 184)
					{
						if (!transparent.noGravity)
						{
							Dust dust38 = transparent;
							dust38.velocity = dust38.velocity * 0f;
							Dust dust39 = transparent;
							dust39.scale = dust39.scale - 0.01f;
						}
					}
					else if (transparent.type == 160 || transparent.type == 162)
					{
						float single63 = transparent.scale * 1.3f;
						if (single63 > 1f)
						{
							single63 = 1f;
						}
						if (transparent.type != 162)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single63 * 0.1f, single63, single63);
						}
						else
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single63, single63 * 0.7f, single63 * 0.1f);
						}
						if (!transparent.noGravity)
						{
							Dust dust40 = transparent;
							dust40.scale = dust40.scale - 0.1f;
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
							transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
							if ((double)transparent.scale > 0.3 && Main.rand.Next(50) == 0)
							{
								Vector2 vector27 = new Vector2(transparent.position.X - 4f, transparent.position.Y - 4f);
								int num13 = transparent.type;
								color = new Color();
								int num14 = Dust.NewDust(vector27, 1, 1, num13, 0f, 0f, 0, color, 1f);
								Main.dust[num14].noGravity = true;
								Main.dust[num14].scale = transparent.scale * 1.5f;
							}
						}
						else
						{
							Dust dust41 = transparent;
							dust41.velocity = dust41.velocity * 0.8f;
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-20, 21) * 0.04f;
							transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-20, 21) * 0.04f;
							Dust dust42 = transparent;
							dust42.scale = dust42.scale - 0.1f;
						}
					}
					else if (transparent.type == 168)
					{
						float single64 = transparent.scale * 0.8f;
						if ((double)single64 > 0.55)
						{
							single64 = 0.55f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single64, 0f, single64 * 0.8f);
						Dust dust43 = transparent;
						dust43.scale = dust43.scale + 0.03f;
						transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.02f;
						transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.02f;
						Dust dust44 = transparent;
						dust44.velocity = dust44.velocity * 0.99f;
					}
					else if (transparent.type >= 139 && transparent.type < 143)
					{
						transparent.velocity.X = transparent.velocity.X * 0.98f;
						transparent.velocity.Y = transparent.velocity.Y * 0.98f;
						if (transparent.velocity.Y < 1f)
						{
							transparent.velocity.Y = transparent.velocity.Y + 0.05f;
						}
						Dust dust45 = transparent;
						dust45.scale = dust45.scale + 0.009f;
						Dust x1 = transparent;
						x1.rotation = x1.rotation - transparent.velocity.X * 0.4f;
						if (transparent.velocity.X <= 0f)
						{
							Dust dust46 = transparent;
							dust46.rotation = dust46.rotation - 0.005f;
						}
						else
						{
							Dust dust47 = transparent;
							dust47.rotation = dust47.rotation + 0.005f;
						}
					}
					else if (transparent.type == 14 || transparent.type == 16 || transparent.type == 31 || transparent.type == 46 || transparent.type == 124 || transparent.type == 186 || transparent.type == 188)
					{
						transparent.velocity.Y = transparent.velocity.Y * 0.98f;
						transparent.velocity.X = transparent.velocity.X * 0.98f;
						if (transparent.type == 31 && transparent.noGravity)
						{
							Dust dust48 = transparent;
							dust48.velocity = dust48.velocity * 1.02f;
							Dust dust49 = transparent;
							dust49.scale = dust49.scale + 0.02f;
							Dust dust50 = transparent;
							dust50.alpha = dust50.alpha + 4;
							if (transparent.alpha > 255)
							{
								transparent.scale = 0.0001f;
								transparent.alpha = 255;
							}
						}
					}
					else if (transparent.type == 32)
					{
						Dust dust51 = transparent;
						dust51.scale = dust51.scale - 0.01f;
						transparent.velocity.X = transparent.velocity.X * 0.96f;
						if (!transparent.noGravity)
						{
							transparent.velocity.Y = transparent.velocity.Y + 0.1f;
						}
					}
					else if (transparent.type >= 244 && transparent.type <= 247)
					{
						Dust dust52 = transparent;
						dust52.rotation = dust52.rotation + 0.1f * transparent.scale;
						Color color1 = Lighting.GetColor((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f));
						byte r = (byte)((color1.R + color1.G + color1.B) / 3);
						float single65 = ((float)r / 270f + 1f) / 2f;
						float single66 = ((float)r / 270f + 1f) / 2f;
						float single67 = ((float)r / 270f + 1f) / 2f;
						single65 = single65 * (transparent.scale * 0.9f);
						single66 = single66 * (transparent.scale * 0.9f);
						single67 = single67 * (transparent.scale * 0.9f);
						if (transparent.alpha >= 255)
						{
							if ((double)transparent.scale < 0.8)
							{
								Dust dust53 = transparent;
								dust53.scale = dust53.scale - 0.01f;
							}
							if ((double)transparent.scale < 0.5)
							{
								Dust dust54 = transparent;
								dust54.scale = dust54.scale - 0.01f;
							}
						}
						else
						{
							Dust dust55 = transparent;
							dust55.scale = dust55.scale + 0.09f;
							if (transparent.scale >= 1f)
							{
								transparent.scale = 1f;
								transparent.alpha = 255;
							}
						}
						float single68 = 1f;
						if (transparent.type == 244)
						{
							single65 = single65 * 0.8862745f;
							single66 = single66 * 0.4627451f;
							single67 = single67 * 0.298039228f;
							single68 = 0.9f;
						}
						else if (transparent.type == 245)
						{
							single65 = single65 * 0.5137255f;
							single66 = single66 * 0.6745098f;
							single67 = single67 * 0.6784314f;
							single68 = 1f;
						}
						else if (transparent.type == 246)
						{
							single65 = single65 * 0.8f;
							single66 = single66 * 0.709803939f;
							single67 = single67 * 0.282352954f;
							single68 = 1.1f;
						}
						else if (transparent.type == 247)
						{
							single65 = single65 * 0.6f;
							single66 = single66 * 0.6745098f;
							single67 = single67 * 0.7254902f;
							single68 = 1.2f;
						}
						single65 = single65 * single68;
						single66 = single66 * single68;
						single67 = single67 * single68;
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single65, single66, single67);
					}
					else if (transparent.type == 43)
					{
						Dust dust56 = transparent;
						dust56.rotation = dust56.rotation + 0.1f * transparent.scale;
						Color color2 = Lighting.GetColor((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f));
						float r1 = (float)color2.R / 270f;
						float g = (float)color2.G / 270f;
						float b = (float)color2.B / 270f;
						float r2 = (float)(transparent.color.R / 255);
						float g1 = (float)(transparent.color.G / 255);
						float b1 = (float)(transparent.color.B / 255);
						r1 = r1 * (transparent.scale * 1.07f * r2);
						g = g * (transparent.scale * 1.07f * g1);
						b = b * (transparent.scale * 1.07f * b1);
						if (transparent.alpha >= 255)
						{
							if ((double)transparent.scale < 0.8)
							{
								Dust dust57 = transparent;
								dust57.scale = dust57.scale - 0.01f;
							}
							if ((double)transparent.scale < 0.5)
							{
								Dust dust58 = transparent;
								dust58.scale = dust58.scale - 0.01f;
							}
						}
						else
						{
							Dust dust59 = transparent;
							dust59.scale = dust59.scale + 0.09f;
							if (transparent.scale >= 1f)
							{
								transparent.scale = 1f;
								transparent.alpha = 255;
							}
						}
						if ((double)r1 >= 0.05 || (double)g >= 0.05 || (double)b >= 0.05)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), r1, g, b);
						}
						else
						{
							transparent.active = false;
						}
					}
					else if (transparent.type == 15 || transparent.type == 57 || transparent.type == 58)
					{
						transparent.velocity.Y = transparent.velocity.Y * 0.98f;
						transparent.velocity.X = transparent.velocity.X * 0.98f;
						float single69 = transparent.scale;
						if (transparent.type != 15)
						{
							single69 = transparent.scale * 0.8f;
						}
						if (transparent.noLight)
						{
							Dust dust60 = transparent;
							dust60.velocity = dust60.velocity * 0.95f;
						}
						if (single69 > 1f)
						{
							single69 = 1f;
						}
						if (transparent.type == 15)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single69 * 0.45f, single69 * 0.55f, single69);
						}
						else if (transparent.type == 57)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single69 * 0.95f, single69 * 0.95f, single69 * 0.45f);
						}
						else if (transparent.type == 58)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single69, single69 * 0.55f, single69 * 0.75f);
						}
					}
					else if (transparent.type == 204)
					{
						if (transparent.fadeIn <= transparent.scale)
						{
							Dust dust61 = transparent;
							dust61.scale = dust61.scale - 0.02f;
						}
						else
						{
							Dust dust62 = transparent;
							dust62.scale = dust62.scale + 0.02f;
						}
						Dust dust63 = transparent;
						dust63.velocity = dust63.velocity * 0.95f;
					}
					else if (transparent.type == 110)
					{
						float single70 = transparent.scale * 0.1f;
						if (single70 > 1f)
						{
							single70 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single70 * 0.2f, single70, single70 * 0.5f);
					}
					else if (transparent.type == 111)
					{
						float single71 = transparent.scale * 0.125f;
						if (single71 > 1f)
						{
							single71 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single71 * 0.2f, single71 * 0.7f, single71);
					}
					else if (transparent.type == 112)
					{
						float single72 = transparent.scale * 0.1f;
						if (single72 > 1f)
						{
							single72 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single72 * 0.8f, single72 * 0.2f, single72 * 0.8f);
					}
					else if (transparent.type == 113)
					{
						float single73 = transparent.scale * 0.1f;
						if (single73 > 1f)
						{
							single73 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single73 * 0.2f, single73 * 0.3f, single73 * 1.3f);
					}
					else if (transparent.type == 114)
					{
						float single74 = transparent.scale * 0.1f;
						if (single74 > 1f)
						{
							single74 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single74 * 1.2f, single74 * 0.5f, single74 * 0.4f);
					}
					else if (transparent.type == 66)
					{
						if (transparent.velocity.X >= 0f)
						{
							Dust dust64 = transparent;
							dust64.rotation = dust64.rotation + 1f;
						}
						else
						{
							Dust dust65 = transparent;
							dust65.rotation = dust65.rotation - 1f;
						}
						transparent.velocity.Y = transparent.velocity.Y * 0.98f;
						transparent.velocity.X = transparent.velocity.X * 0.98f;
						Dust dust66 = transparent;
						dust66.scale = dust66.scale + 0.02f;
						float single75 = transparent.scale;
						if (transparent.type != 15)
						{
							single75 = transparent.scale * 0.8f;
						}
						if (single75 > 1f)
						{
							single75 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single75 * ((float)transparent.color.R / 255f), single75 * ((float)transparent.color.G / 255f), single75 * ((float)transparent.color.B / 255f));
					}
					else if (transparent.type == 267)
					{
						if (transparent.velocity.X >= 0f)
						{
							Dust dust67 = transparent;
							dust67.rotation = dust67.rotation + 1f;
						}
						else
						{
							Dust dust68 = transparent;
							dust68.rotation = dust68.rotation - 1f;
						}
						transparent.velocity.Y = transparent.velocity.Y * 0.98f;
						transparent.velocity.X = transparent.velocity.X * 0.98f;
						Dust dust69 = transparent;
						dust69.scale = dust69.scale + 0.02f;
						float single76 = transparent.scale;
						if (transparent.type != 15)
						{
							single76 = transparent.scale * 0.8f;
						}
						if (single76 > 1f)
						{
							single76 = 1f;
						}
						if (!transparent.noLight)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single76 * ((float)transparent.color.R / 255f), single76 * ((float)transparent.color.G / 255f), single76 * ((float)transparent.color.B / 255f));
						}
					}
					else if (transparent.type == 20 || transparent.type == 21 || transparent.type == 231)
					{
						Dust dust70 = transparent;
						dust70.scale = dust70.scale + 0.005f;
						transparent.velocity.Y = transparent.velocity.Y * 0.94f;
						transparent.velocity.X = transparent.velocity.X * 0.94f;
						float single77 = transparent.scale * 0.8f;
						if (single77 > 1f)
						{
							single77 = 1f;
						}
						if (transparent.type == 21)
						{
							single77 = transparent.scale * 0.4f;
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single77 * 0.8f, single77 * 0.3f, single77);
						}
						else if (transparent.type != 231)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single77 * 0.3f, single77 * 0.6f, single77);
						}
						else
						{
							single77 = transparent.scale * 0.4f;
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single77, single77 * 0.5f, single77 * 0.3f);
						}
					}
					else if (transparent.type == 27 || transparent.type == 45)
					{
						if (transparent.type == 27 && transparent.fadeIn >= 100f)
						{
							if ((double)transparent.scale < 1.5)
							{
								Dust dust71 = transparent;
								dust71.scale = dust71.scale - 0.05f;
							}
							else
							{
								Dust dust72 = transparent;
								dust72.scale = dust72.scale - 0.01f;
							}
							if ((double)transparent.scale <= 0.5)
							{
								Dust dust73 = transparent;
								dust73.scale = dust73.scale - 0.05f;
							}
							if ((double)transparent.scale <= 0.25)
							{
								Dust dust74 = transparent;
								dust74.scale = dust74.scale - 0.05f;
							}
						}
						Dust dust75 = transparent;
						dust75.velocity = dust75.velocity * 0.94f;
						Dust dust76 = transparent;
						dust76.scale = dust76.scale + 0.002f;
						float single78 = transparent.scale;
						if (transparent.noLight)
						{
							single78 = single78 * 0.1f;
							Dust dust77 = transparent;
							dust77.scale = dust77.scale - 0.06f;
							if (transparent.scale < 1f)
							{
								Dust dust78 = transparent;
								dust78.scale = dust78.scale - 0.06f;
							}
							if (!Main.player[Main.myPlayer].wet)
							{
								Dust dust79 = transparent;
								dust79.position = dust79.position + Main.player[Main.myPlayer].velocity;
							}
							else
							{
								Dust dust80 = transparent;
								dust80.position = dust80.position + (Main.player[Main.myPlayer].velocity * 0.5f);
							}
						}
						if (single78 > 1f)
						{
							single78 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single78 * 0.6f, single78 * 0.2f, single78);
					}
					else if (transparent.type == 55 || transparent.type == 56 || transparent.type == 73 || transparent.type == 74)
					{
						Dust dust81 = transparent;
						dust81.velocity = dust81.velocity * 0.98f;
						float single79 = transparent.scale * 0.8f;
						if (transparent.type == 55)
						{
							if (single79 > 1f)
							{
								single79 = 1f;
							}
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single79, single79, single79 * 0.6f);
						}
						else if (transparent.type == 73)
						{
							if (single79 > 1f)
							{
								single79 = 1f;
							}
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single79, single79 * 0.35f, single79 * 0.5f);
						}
						else if (transparent.type != 74)
						{
							single79 = transparent.scale * 1.2f;
							if (single79 > 1f)
							{
								single79 = 1f;
							}
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single79 * 0.35f, single79 * 0.5f, single79);
						}
						else
						{
							if (single79 > 1f)
							{
								single79 = 1f;
							}
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single79 * 0.35f, single79, single79 * 0.5f);
						}
					}
					else if (transparent.type == 71 || transparent.type == 72)
					{
						Dust dust82 = transparent;
						dust82.velocity = dust82.velocity * 0.98f;
						float single80 = transparent.scale;
						if (single80 > 1f)
						{
							single80 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single80 * 0.2f, 0f, single80 * 0.1f);
					}
					else if (transparent.type == 76)
					{
						int x2 = (int)transparent.position.X / 16;
						int y = (int)transparent.position.Y / 16;
						Main.snowDust = Main.snowDust + 1;
						Dust dust83 = transparent;
						dust83.scale = dust83.scale + 0.009f;
						if (!transparent.noLight)
						{
							Dust dust84 = transparent;
							dust84.position = dust84.position + (Main.player[Main.myPlayer].velocity * 0.2f);
						}
					}
					else if (!transparent.noGravity && transparent.type != 41 && transparent.type != 44)
					{
						if (transparent.type != 107)
						{
							transparent.velocity.Y = transparent.velocity.Y + 0.1f;
						}
						else
						{
							Dust dust85 = transparent;
							dust85.velocity = dust85.velocity * 0.9f;
						}
					}
					if (transparent.type == 5 && transparent.noGravity)
					{
						Dust dust86 = transparent;
						dust86.scale = dust86.scale - 0.04f;
					}
					if (transparent.type == 33 || transparent.type == 52 || transparent.type == 266 || transparent.type == 98 || transparent.type == 99 || transparent.type == 100 || transparent.type == 101 || transparent.type == 102 || transparent.type == 103 || transparent.type == 104 || transparent.type == 105 || transparent.type == 123)
					{
						if (transparent.velocity.X == 0f)
						{
							if (Collision.SolidCollision(transparent.position, 2, 2))
							{
								transparent.scale = 0f;
							}
							Dust dust87 = transparent;
							dust87.rotation = dust87.rotation + 0.5f;
							Dust dust88 = transparent;
							dust88.scale = dust88.scale - 0.01f;
						}
						if (Collision.WetCollision(new Vector2(transparent.position.X, transparent.position.Y), 4, 4))
						{
							Dust dust89 = transparent;
							dust89.alpha = dust89.alpha + 20;
							Dust dust90 = transparent;
							dust90.scale = dust90.scale - 0.1f;
						}
						Dust dust91 = transparent;
						dust91.alpha = dust91.alpha + 2;
						Dust dust92 = transparent;
						dust92.scale = dust92.scale - 0.005f;
						if (transparent.alpha > 255)
						{
							transparent.scale = 0f;
						}
						if (transparent.velocity.Y > 4f)
						{
							transparent.velocity.Y = 4f;
						}
						if (transparent.noGravity)
						{
							if (transparent.velocity.X >= 0f)
							{
								Dust dust93 = transparent;
								dust93.rotation = dust93.rotation + 0.2f;
							}
							else
							{
								Dust dust94 = transparent;
								dust94.rotation = dust94.rotation - 0.2f;
							}
							Dust dust95 = transparent;
							dust95.scale = dust95.scale + 0.03f;
							transparent.velocity.X = transparent.velocity.X * 1.05f;
							transparent.velocity.Y = transparent.velocity.Y + 0.15f;
						}
					}
					if (transparent.type == 35 && transparent.noGravity)
					{
						Dust dust96 = transparent;
						dust96.scale = dust96.scale + 0.03f;
						if (transparent.scale < 1f)
						{
							transparent.velocity.Y = transparent.velocity.Y + 0.075f;
						}
						transparent.velocity.X = transparent.velocity.X * 1.08f;
						if (transparent.velocity.X <= 0f)
						{
							Dust dust97 = transparent;
							dust97.rotation = dust97.rotation - 0.01f;
						}
						else
						{
							Dust dust98 = transparent;
							dust98.rotation = dust98.rotation + 0.01f;
						}
						float single81 = transparent.scale * 0.6f;
						if (single81 > 1f)
						{
							single81 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f + 1f), single81, single81 * 0.3f, single81 * 0.1f);
					}
					else if (transparent.type == 152 && transparent.noGravity)
					{
						Dust dust99 = transparent;
						dust99.scale = dust99.scale + 0.03f;
						if (transparent.scale < 1f)
						{
							transparent.velocity.Y = transparent.velocity.Y + 0.075f;
						}
						transparent.velocity.X = transparent.velocity.X * 1.08f;
						if (transparent.velocity.X <= 0f)
						{
							Dust dust100 = transparent;
							dust100.rotation = dust100.rotation - 0.01f;
						}
						else
						{
							Dust dust101 = transparent;
							dust101.rotation = dust101.rotation + 0.01f;
						}
					}
					else if (transparent.type == 67 || transparent.type == 92)
					{
						float single82 = transparent.scale;
						if (single82 > 1f)
						{
							single82 = 1f;
						}
						if (transparent.noLight)
						{
							single82 = single82 * 0.1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), 0f, single82 * 0.8f, single82);
					}
					else if (transparent.type == 185)
					{
						float single83 = transparent.scale;
						if (single83 > 1f)
						{
							single83 = 1f;
						}
						if (transparent.noLight)
						{
							single83 = single83 * 0.1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single83 * 0.1f, single83 * 0.7f, single83);
					}
					else if (transparent.type == 107)
					{
						float single84 = transparent.scale * 0.5f;
						if (single84 > 1f)
						{
							single84 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single84 * 0.1f, single84, single84 * 0.4f);
					}
					else if (transparent.type == 34 || transparent.type == 35 || transparent.type == 152)
					{
						if (Collision.WetCollision(new Vector2(transparent.position.X, transparent.position.Y - 8f), 4, 4))
						{
							Dust dust102 = transparent;
							dust102.alpha = dust102.alpha + Main.rand.Next(2);
							if (transparent.alpha > 255)
							{
								transparent.scale = 0f;
							}
							transparent.velocity.Y = -0.5f;
							if (transparent.type != 34)
							{
								Dust dust103 = transparent;
								dust103.alpha = dust103.alpha + 1;
								Dust dust104 = transparent;
								dust104.scale = dust104.scale - 0.01f;
								transparent.velocity.Y = -0.2f;
							}
							else
							{
								Dust dust105 = transparent;
								dust105.scale = dust105.scale + 0.005f;
							}
							transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 10) * 0.002f;
							if ((double)transparent.velocity.X < -0.25)
							{
								transparent.velocity.X = -0.25f;
							}
							if ((double)transparent.velocity.X > 0.25)
							{
								transparent.velocity.X = 0.25f;
							}
						}
						else
						{
							transparent.scale = 0f;
						}
						if (transparent.type == 35)
						{
							float single85 = transparent.scale * 0.3f + 0.4f;
							if (single85 > 1f)
							{
								single85 = 1f;
							}
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single85, single85 * 0.5f, single85 * 0.3f);
						}
					}
					if (transparent.type == 68)
					{
						float single86 = transparent.scale * 0.3f;
						if (single86 > 1f)
						{
							single86 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single86 * 0.1f, single86 * 0.2f, single86);
					}
					if (transparent.type == 70)
					{
						float single87 = transparent.scale * 0.3f;
						if (single87 > 1f)
						{
							single87 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single87 * 0.5f, 0f, single87);
					}
					if (transparent.type == 41)
					{
						transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.01f;
						transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.01f;
						if ((double)transparent.velocity.X > 0.75)
						{
							transparent.velocity.X = 0.75f;
						}
						if ((double)transparent.velocity.X < -0.75)
						{
							transparent.velocity.X = -0.75f;
						}
						if ((double)transparent.velocity.Y > 0.75)
						{
							transparent.velocity.Y = 0.75f;
						}
						if ((double)transparent.velocity.Y < -0.75)
						{
							transparent.velocity.Y = -0.75f;
						}
						Dust dust106 = transparent;
						dust106.scale = dust106.scale + 0.007f;
						float single88 = transparent.scale * 0.7f;
						if (single88 > 1f)
						{
							single88 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single88 * 0.4f, single88 * 0.9f, single88);
					}
					else if (transparent.type != 44)
					{
						transparent.velocity.X = transparent.velocity.X * 0.99f;
					}
					else
					{
						transparent.velocity.X = transparent.velocity.X + (float)Main.rand.Next(-10, 11) * 0.003f;
						transparent.velocity.Y = transparent.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.003f;
						if ((double)transparent.velocity.X > 0.35)
						{
							transparent.velocity.X = 0.35f;
						}
						if ((double)transparent.velocity.X < -0.35)
						{
							transparent.velocity.X = -0.35f;
						}
						if ((double)transparent.velocity.Y > 0.35)
						{
							transparent.velocity.Y = 0.35f;
						}
						if ((double)transparent.velocity.Y < -0.35)
						{
							transparent.velocity.Y = -0.35f;
						}
						Dust dust107 = transparent;
						dust107.scale = dust107.scale + 0.0085f;
						float single89 = transparent.scale * 0.7f;
						if (single89 > 1f)
						{
							single89 = 1f;
						}
						Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single89 * 0.7f, single89, single89 * 0.8f);
					}
					if (transparent.type != 79)
					{
						Dust x3 = transparent;
						x3.rotation = x3.rotation + transparent.velocity.X * 0.5f;
					}
					if (transparent.fadeIn > 0f && transparent.fadeIn < 100f)
					{
						if (transparent.type == 235)
						{
							Dust dust108 = transparent;
							dust108.scale = dust108.scale + 0.007f;
							int num15 = (int)transparent.fadeIn - 1;
							if (num15 >= 0 && num15 <= 255)
							{
								Vector2 center1 = transparent.position - Main.player[num15].Center;
								float single90 = center1.Length();
								single90 = 100f - single90;
								if (single90 > 0f)
								{
									Dust dust109 = transparent;
									dust109.scale = dust109.scale - single90 * 0.0015f;
								}
								center1.Normalize();
								float single91 = (1f - transparent.scale) * 20f;
								center1 = center1 * -single91;
								transparent.velocity = ((transparent.velocity * 4f) + center1) / 5f;
							}
						}
						else if (transparent.type == 46)
						{
							Dust dust110 = transparent;
							dust110.scale = dust110.scale + 0.1f;
						}
						else if (transparent.type == 213 || transparent.type == 260)
						{
							Dust dust111 = transparent;
							dust111.scale = dust111.scale + 0.1f;
						}
						else
						{
							Dust dust112 = transparent;
							dust112.scale = dust112.scale + 0.03f;
						}
						if (transparent.scale > transparent.fadeIn)
						{
							transparent.fadeIn = 0f;
						}
					}
					else if (transparent.type == 213 || transparent.type == 260)
					{
						Dust dust113 = transparent;
						dust113.scale = dust113.scale - 0.2f;
					}
					else
					{
						Dust dust114 = transparent;
						dust114.scale = dust114.scale - 0.01f;
					}
					if (transparent.type >= 130 && transparent.type <= 134)
					{
						float single92 = transparent.scale;
						if (single92 > 1f)
						{
							single92 = 1f;
						}
						if (transparent.type == 130)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single92 * 1f, single92 * 0.5f, single92 * 0.4f);
						}
						if (transparent.type == 131)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single92 * 0.4f, single92 * 1f, single92 * 0.6f);
						}
						if (transparent.type == 132)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single92 * 0.3f, single92 * 0.5f, single92 * 1f);
						}
						if (transparent.type == 133)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single92 * 0.9f, single92 * 0.9f, single92 * 0.3f);
						}
						if (transparent.noGravity)
						{
							Dust dust115 = transparent;
							dust115.velocity = dust115.velocity * 0.93f;
							if (transparent.fadeIn == 0f)
							{
								Dust dust116 = transparent;
								dust116.scale = dust116.scale + 0.0025f;
							}
						}
						else if (transparent.type != 131)
						{
							Dust dust117 = transparent;
							dust117.velocity = dust117.velocity * 0.95f;
							Dust dust118 = transparent;
							dust118.scale = dust118.scale - 0.0025f;
						}
						else
						{
							Dust dust119 = transparent;
							dust119.velocity = dust119.velocity * 0.98f;
							transparent.velocity.Y = transparent.velocity.Y - 0.1f;
							Dust dust120 = transparent;
							dust120.scale = dust120.scale + 0.0025f;
						}
					}
					else if (transparent.type >= 219 && transparent.type <= 223)
					{
						float single93 = transparent.scale;
						if (single93 > 1f)
						{
							single93 = 1f;
						}
						if (!transparent.noLight)
						{
							if (transparent.type == 219)
							{
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single93 * 1f, single93 * 0.5f, single93 * 0.4f);
							}
							if (transparent.type == 220)
							{
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single93 * 0.4f, single93 * 1f, single93 * 0.6f);
							}
							if (transparent.type == 221)
							{
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single93 * 0.3f, single93 * 0.5f, single93 * 1f);
							}
							if (transparent.type == 222)
							{
								Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single93 * 0.9f, single93 * 0.9f, single93 * 0.3f);
							}
						}
						if (transparent.noGravity)
						{
							Dust dust121 = transparent;
							dust121.velocity = dust121.velocity * 0.93f;
							if (transparent.fadeIn == 0f)
							{
								Dust dust122 = transparent;
								dust122.scale = dust122.scale + 0.0025f;
							}
						}
						Dust vector28 = transparent;
						vector28.velocity = vector28.velocity * new Vector2(0.97f, 0.99f);
						Dust dust123 = transparent;
						dust123.scale = dust123.scale - 0.0025f;
						if (transparent.customData != null && transparent.customData is Player)
						{
							Player player5 = (Player)transparent.customData;
							Dust dust124 = transparent;
							dust124.position = dust124.position + (player5.position - player5.oldPosition);
						}
					}
					else if (transparent.type == 226)
					{
						float single94 = transparent.scale;
						if (single94 > 1f)
						{
							single94 = 1f;
						}
						if (!transparent.noLight)
						{
							Lighting.AddLight((int)(transparent.position.X / 16f), (int)(transparent.position.Y / 16f), single94 * 0.2f, single94 * 0.7f, single94 * 1f);
						}
						if (transparent.noGravity)
						{
							Dust dust125 = transparent;
							dust125.velocity = dust125.velocity * 0.93f;
							if (transparent.fadeIn == 0f)
							{
								Dust dust126 = transparent;
								dust126.scale = dust126.scale + 0.0025f;
							}
						}
						Dust vector29 = transparent;
						vector29.velocity = vector29.velocity * new Vector2(0.97f, 0.99f);
						if (transparent.customData != null && transparent.customData is Player)
						{
							Player player6 = (Player)transparent.customData;
							Dust dust127 = transparent;
							dust127.position = dust127.position + (player6.position - player6.oldPosition);
						}
						Dust dust128 = transparent;
						dust128.scale = dust128.scale - 0.01f;
					}
					else if (transparent.noGravity)
					{
						Dust dust129 = transparent;
						dust129.velocity = dust129.velocity * 0.92f;
						if (transparent.fadeIn == 0f)
						{
							Dust dust130 = transparent;
							dust130.scale = dust130.scale - 0.04f;
						}
					}
					if (transparent.position.Y > Main.screenPosition.Y + (float)Main.screenHeight)
					{
						transparent.active = false;
					}
					float single95 = 0.1f;
					if ((double)Dust.dCount == 0.5)
					{
						Dust dust131 = transparent;
						dust131.scale = dust131.scale - 0.001f;
					}
					if ((double)Dust.dCount == 0.6)
					{
						Dust dust132 = transparent;
						dust132.scale = dust132.scale - 0.0025f;
					}
					if ((double)Dust.dCount == 0.7)
					{
						Dust dust133 = transparent;
						dust133.scale = dust133.scale - 0.005f;
					}
					if ((double)Dust.dCount == 0.8)
					{
						Dust dust134 = transparent;
						dust134.scale = dust134.scale - 0.01f;
					}
					if ((double)Dust.dCount == 0.9)
					{
						Dust dust135 = transparent;
						dust135.scale = dust135.scale - 0.02f;
					}
					if ((double)Dust.dCount == 0.5)
					{
						single95 = 0.11f;
					}
					if ((double)Dust.dCount == 0.6)
					{
						single95 = 0.13f;
					}
					if ((double)Dust.dCount == 0.7)
					{
						single95 = 0.16f;
					}
					if ((double)Dust.dCount == 0.8)
					{
						single95 = 0.22f;
					}
					if ((double)Dust.dCount == 0.9)
					{
						single95 = 0.25f;
					}
					if (transparent.scale < single95)
					{
						transparent.active = false;
					}
				}
			}
			int num16 = num;
			if ((double)num16 > (double)Main.numDust * 0.9)
			{
				Dust.dCount = 0.9f;
				return;
			}
			if ((double)num16 > (double)Main.numDust * 0.8)
			{
				Dust.dCount = 0.8f;
				return;
			}
			if ((double)num16 > (double)Main.numDust * 0.7)
			{
				Dust.dCount = 0.7f;
				return;
			}
			if ((double)num16 > (double)Main.numDust * 0.6)
			{
				Dust.dCount = 0.6f;
				return;
			}
			if ((double)num16 > (double)Main.numDust * 0.5)
			{
				Dust.dCount = 0.5f;
				return;
			}
			Dust.dCount = 0f;
		}
	}
}