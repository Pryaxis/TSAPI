
using System;
using System.Collections.Generic;
using Terraria.ID;
using TerrariaApi.Server;

namespace Terraria
{
	public class Collision
	{
		public static bool stair;

		public static bool stairFall;

		public static bool honey;

		public static bool sloping;

		public static bool landMine;

		public static bool up;

		public static bool down;

		public static float Epsilon;

		static Collision()
		{
			Collision.stair = false;
			Collision.stairFall = false;
			Collision.honey = false;
			Collision.sloping = false;
			Collision.landMine = false;
			Collision.up = false;
			Collision.down = false;
			Collision.Epsilon = 2.71828175f;
		}

		public Collision()
		{
		}

		public static Vector2 AnyCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool evenActuated = false)
		{
			Vector2 vector2 = new Vector2();
			Vector2 velocity = Velocity;
			Vector2 velocity1 = Velocity;
			Vector2 position = Position + Velocity;
			Vector2 position1 = Position;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num1 = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			if (x < 0)
			{
				x = 0;
			}
			if (num > Main.maxTilesX)
			{
				num = Main.maxTilesX;
			}
			if (y < 0)
			{
				y = 0;
			}
			if (y1 > Main.maxTilesY)
			{
				y1 = Main.maxTilesY;
			}
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (evenActuated || !Main.tile[i, j].inActive()))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num5 = num5 - 8;
						}
						if (position.X + (float)Width > vector2.X && position.X < vector2.X + 16f && position.Y + (float)Height > vector2.Y && position.Y < vector2.Y + (float)num5)
						{
							if (position1.Y + (float)Height <= vector2.Y)
							{
								num3 = i;
								num4 = j;
								if (num3 != num1)
								{
									velocity.Y = vector2.Y - (position1.Y + (float)Height);
								}
							}
							else if (position1.X + (float)Width <= vector2.X && !Main.tileSolidTop[Main.tile[i, j].type])
							{
								num1 = i;
								num2 = j;
								if (num2 != num4)
								{
									velocity.X = vector2.X - (position1.X + (float)Width);
								}
								if (num3 == num1)
								{
									velocity.Y = velocity1.Y;
								}
							}
							else if (position1.X >= vector2.X + 16f && !Main.tileSolidTop[Main.tile[i, j].type])
							{
								num1 = i;
								num2 = j;
								if (num2 != num4)
								{
									velocity.X = vector2.X + 16f - position1.X;
								}
								if (num3 == num1)
								{
									velocity.Y = velocity1.Y;
								}
							}
							else if (position1.Y >= vector2.Y + (float)num5 && !Main.tileSolidTop[Main.tile[i, j].type])
							{
								num3 = i;
								num4 = j;
								velocity.Y = vector2.Y + (float)num5 - position1.Y + 0.01f;
								if (num4 == num2)
								{
									velocity.X = velocity1.X + 0.01f;
								}
							}
						}
					}
				}
			}
			return velocity;
		}

		public static bool CanHit(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2)
		{
			bool flag;
			int x = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
			int y = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
			int num = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
			int y1 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
			if (x <= 1)
			{
				x = 1;
			}
			if (x >= Main.maxTilesX)
			{
				x = Main.maxTilesX - 1;
			}
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (y <= 1)
			{
				y = 1;
			}
			if (y >= Main.maxTilesY)
			{
				y = Main.maxTilesY - 1;
			}
			if (y1 <= 1)
			{
				y1 = 1;
			}
			if (y1 >= Main.maxTilesY)
			{
				y1 = Main.maxTilesY - 1;
			}
			try
			{
				do
				{
					int num1 = Math.Abs(x - num);
					int num2 = Math.Abs(y - y1);
					if (x != num || y != y1)
					{
						if (num1 <= num2)
						{
							y = (y >= y1 ? y - 1 : y + 1);
							if (Main.tile[x - 1, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x + 1, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (!Main.tile[x - 1, y].inActive() && Main.tile[x - 1, y].active() && Main.tileSolid[Main.tile[x - 1, y].type] && !Main.tileSolidTop[Main.tile[x - 1, y].type] && Main.tile[x - 1, y].slope() == 0 && !Main.tile[x - 1, y].halfBrick() && !Main.tile[x + 1, y].inActive() && Main.tile[x + 1, y].active() && Main.tileSolid[Main.tile[x + 1, y].type] && !Main.tileSolidTop[Main.tile[x + 1, y].type] && Main.tile[x + 1, y].slope() == 0 && !Main.tile[x + 1, y].halfBrick())
							{
								flag = false;
								return flag;
							}
						}
						else
						{
							x = (x >= num ? x - 1 : x + 1);
							if (Main.tile[x, y - 1] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x, y + 1] == null)
							{
								flag = false;
								return flag;
							}
							else if (!Main.tile[x, y - 1].inActive() && Main.tile[x, y - 1].active() && Main.tileSolid[Main.tile[x, y - 1].type] && !Main.tileSolidTop[Main.tile[x, y - 1].type] && Main.tile[x, y - 1].slope() == 0 && !Main.tile[x, y - 1].halfBrick() && !Main.tile[x, y + 1].inActive() && Main.tile[x, y + 1].active() && Main.tileSolid[Main.tile[x, y + 1].type] && !Main.tileSolidTop[Main.tile[x, y + 1].type] && Main.tile[x, y + 1].slope() == 0 && !Main.tile[x, y + 1].halfBrick())
							{
								flag = false;
								return flag;
							}
						}
						if (Main.tile[x, y] != null)
						{
							continue;
						}
						flag = false;
						return flag;
					}
					else
					{
						flag = true;
						return flag;
					}
				}
				while (Main.tile[x, y].inActive() || !Main.tile[x, y].active() || !Main.tileSolid[Main.tile[x, y].type] || Main.tileSolidTop[Main.tile[x, y].type]);
				flag = false;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		public static bool CanHitLine(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2)
		{
			bool flag;
			int x = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
			int y = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
			int num = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
			int y1 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
			if (x <= 1)
			{
				x = 1;
			}
			if (x >= Main.maxTilesX)
			{
				x = Main.maxTilesX - 1;
			}
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (y <= 1)
			{
				y = 1;
			}
			if (y >= Main.maxTilesY)
			{
				y = Main.maxTilesY - 1;
			}
			if (y1 <= 1)
			{
				y1 = 1;
			}
			if (y1 >= Main.maxTilesY)
			{
				y1 = Main.maxTilesY - 1;
			}
			float single = (float)Math.Abs(x - num);
			float single1 = (float)Math.Abs(y - y1);
			if (single == 0f && single1 == 0f)
			{
				return true;
			}
			float single2 = 1f;
			float single3 = 1f;
			if (single == 0f || single1 == 0f)
			{
				if (single == 0f)
				{
					single2 = 0f;
				}
				if (single1 == 0f)
				{
					single3 = 0f;
				}
			}
			else if (single <= single1)
			{
				single3 = single1 / single;
			}
			else
			{
				single2 = single / single1;
			}
			float single4 = 0f;
			float single5 = 0f;
			int num1 = 1;
			if (y < y1)
			{
				num1 = 2;
			}
			int num2 = (int)single;
			int num3 = (int)single1;
			int num4 = Math.Sign(num - x);
			int num5 = Math.Sign(y1 - y);
			bool flag1 = false;
			bool flag2 = false;
			try
			{
				do
				{
					if (num1 == 2)
					{
						single4 = single4 + single2;
						int num6 = (int)single4;
						single4 = single4 % 1f;
						int num7 = 0;
						while (num7 < num6)
						{
							if (Main.tile[x, y - 1] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x, y + 1] != null)
							{
								Tile tile = Main.tile[x, y - 1];
								Tile tile1 = Main.tile[x, y + 1];
								Tile tile2 = Main.tile[x, y];
								if (!tile.inActive() && tile.active() && Main.tileSolid[tile.type] && !Main.tileSolidTop[tile.type] || !tile1.inActive() && tile1.active() && Main.tileSolid[tile1.type] && !Main.tileSolidTop[tile1.type] || !tile2.inActive() && tile2.active() && Main.tileSolid[tile2.type] && !Main.tileSolidTop[tile2.type])
								{
									flag = false;
									return flag;
								}
								else if (num2 != 0 || num3 != 0)
								{
									x = x + num4;
									num2--;
									if (num2 == 0 && num3 == 0 && num6 == 1)
									{
										flag2 = true;
									}
									num7++;
								}
								else
								{
									flag1 = true;
									break;
								}
							}
							else
							{
								flag = false;
								return flag;
							}
						}
						if (num3 != 0)
						{
							num1 = 1;
						}
					}
					else if (num1 == 1)
					{
						single5 = single5 + single3;
						int num8 = (int)single5;
						single5 = single5 % 1f;
						int num9 = 0;
						while (num9 < num8)
						{
							if (Main.tile[x - 1, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x + 1, y] != null)
							{
								Tile tile3 = Main.tile[x - 1, y];
								Tile tile4 = Main.tile[x + 1, y];
								Tile tile5 = Main.tile[x, y];
								if (!tile3.inActive() && tile3.active() && Main.tileSolid[tile3.type] && !Main.tileSolidTop[tile3.type] || !tile4.inActive() && tile4.active() && Main.tileSolid[tile4.type] && !Main.tileSolidTop[tile4.type] || !tile5.inActive() && tile5.active() && Main.tileSolid[tile5.type] && !Main.tileSolidTop[tile5.type])
								{
									flag = false;
									return flag;
								}
								else if (num2 != 0 || num3 != 0)
								{
									y = y + num5;
									num3--;
									if (num2 == 0 && num3 == 0 && num8 == 1)
									{
										flag2 = true;
									}
									num9++;
								}
								else
								{
									flag1 = true;
									break;
								}
							}
							else
							{
								flag = false;
								return flag;
							}
						}
						if (num2 != 0)
						{
							num1 = 2;
						}
					}
					if (Main.tile[x, y] != null)
					{
						Tile tile6 = Main.tile[x, y];
						if (tile6.inActive() || !tile6.active() || !Main.tileSolid[tile6.type] || Main.tileSolidTop[tile6.type])
						{
							continue;
						}
						flag = false;
						return flag;
					}
					else
					{
						flag = false;
						return flag;
					}
				}
				while (!flag1 && !flag2);
				flag = true;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		public static bool CanHitWithCheck(Vector2 Position1, int Width1, int Height1, Vector2 Position2, int Width2, int Height2, Utils.PerLinePoint check)
		{
			bool flag;
			int x = (int)((Position1.X + (float)(Width1 / 2)) / 16f);
			int y = (int)((Position1.Y + (float)(Height1 / 2)) / 16f);
			int num = (int)((Position2.X + (float)(Width2 / 2)) / 16f);
			int y1 = (int)((Position2.Y + (float)(Height2 / 2)) / 16f);
			if (x <= 1)
			{
				x = 1;
			}
			if (x >= Main.maxTilesX)
			{
				x = Main.maxTilesX - 1;
			}
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (y <= 1)
			{
				y = 1;
			}
			if (y >= Main.maxTilesY)
			{
				y = Main.maxTilesY - 1;
			}
			if (y1 <= 1)
			{
				y1 = 1;
			}
			if (y1 >= Main.maxTilesY)
			{
				y1 = Main.maxTilesY - 1;
			}
			try
			{
				do
				{
					int num1 = Math.Abs(x - num);
					int num2 = Math.Abs(y - y1);
					if (x != num || y != y1)
					{
						if (num1 <= num2)
						{
							y = (y >= y1 ? y - 1 : y + 1);
							if (Main.tile[x - 1, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x + 1, y] == null)
							{
								flag = false;
								return flag;
							}
							else if (!Main.tile[x - 1, y].inActive() && Main.tile[x - 1, y].active() && Main.tileSolid[Main.tile[x - 1, y].type] && !Main.tileSolidTop[Main.tile[x - 1, y].type] && Main.tile[x - 1, y].slope() == 0 && !Main.tile[x - 1, y].halfBrick() && !Main.tile[x + 1, y].inActive() && Main.tile[x + 1, y].active() && Main.tileSolid[Main.tile[x + 1, y].type] && !Main.tileSolidTop[Main.tile[x + 1, y].type] && Main.tile[x + 1, y].slope() == 0 && !Main.tile[x + 1, y].halfBrick())
							{
								flag = false;
								return flag;
							}
						}
						else
						{
							x = (x >= num ? x - 1 : x + 1);
							if (Main.tile[x, y - 1] == null)
							{
								flag = false;
								return flag;
							}
							else if (Main.tile[x, y + 1] == null)
							{
								flag = false;
								return flag;
							}
							else if (!Main.tile[x, y - 1].inActive() && Main.tile[x, y - 1].active() && Main.tileSolid[Main.tile[x, y - 1].type] && !Main.tileSolidTop[Main.tile[x, y - 1].type] && Main.tile[x, y - 1].slope() == 0 && !Main.tile[x, y - 1].halfBrick() && !Main.tile[x, y + 1].inActive() && Main.tile[x, y + 1].active() && Main.tileSolid[Main.tile[x, y + 1].type] && !Main.tileSolidTop[Main.tile[x, y + 1].type] && Main.tile[x, y + 1].slope() == 0 && !Main.tile[x, y + 1].halfBrick())
							{
								flag = false;
								return flag;
							}
						}
						if (Main.tile[x, y] != null)
						{
							if (Main.tile[x, y].inActive() || !Main.tile[x, y].active() || !Main.tileSolid[Main.tile[x, y].type] || Main.tileSolidTop[Main.tile[x, y].type])
							{
								continue;
							}
							flag = false;
							return flag;
						}
						else
						{
							flag = false;
							return flag;
						}
					}
					else
					{
						flag = true;
						return flag;
					}
				}
				while (check(x, y));
				flag = false;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		public static bool CheckAABBvAABBCollision(Vector2 position1, Vector2 dimensions1, Vector2 position2, Vector2 dimensions2)
		{
			if (position1.X >= position2.X + dimensions2.X || position1.Y >= position2.Y + dimensions2.Y || position1.X + dimensions1.X <= position2.X)
			{
				return false;
			}
			return position1.Y + dimensions1.Y > position2.Y;
		}

		public static bool CheckAABBvLineCollision(Vector2 objectPosition, Vector2 objectDimensions, Vector2 lineStart, Vector2 lineEnd, float lineWidth, ref float collisionPoint)
		{
			float single = lineWidth * 0.5f;
			Vector2 x = lineStart;
			Vector2 y = lineEnd - lineStart;
			if (y.X <= 0f)
			{
				x.X = x.X + (y.X - single);
				y.X = -y.X + lineWidth;
			}
			else
			{
				y.X = y.X + lineWidth;
				x.X = x.X - single;
			}
			if (y.Y <= 0f)
			{
				x.Y = x.Y + (y.Y - single);
				y.Y = -y.Y + lineWidth;
			}
			else
			{
				y.Y = y.Y + lineWidth;
				x.Y = x.Y - single;
			}
			if (!Collision.CheckAABBvAABBCollision(objectPosition, objectDimensions, x, y))
			{
				return false;
			}
			Vector2 vector2 = objectPosition - lineStart;
			Vector2 vector21 = vector2 + objectDimensions;
			Vector2 vector22 = new Vector2(vector2.X, vector21.Y);
			Vector2 vector23 = new Vector2(vector21.X, vector2.Y);
			Vector2 vector24 = lineEnd - lineStart;
			float single1 = vector24.Length();
			float single2 = (float)Math.Atan2((double)vector24.Y, (double)vector24.X);
			Vector2[] vector2Array = new Vector2[4];
			double num = (double)(-single2);
			Vector2 vector25 = new Vector2();
			vector2Array[0] = vector2.RotatedBy(num, vector25);
			double num1 = (double)(-single2);
			Vector2 vector26 = new Vector2();
			vector2Array[1] = vector23.RotatedBy(num1, vector26);
			double num2 = (double)(-single2);
			Vector2 vector27 = new Vector2();
			vector2Array[2] = vector21.RotatedBy(num2, vector27);
			double num3 = (double)(-single2);
			Vector2 vector28 = new Vector2();
			vector2Array[3] = vector22.RotatedBy(num3, vector28);
			collisionPoint = single1;
			bool flag = false;
			for (int i = 0; i < (int)vector2Array.Length; i++)
			{
				if (Math.Abs(vector2Array[i].Y) < single && vector2Array[i].X < collisionPoint && vector2Array[i].X >= 0f)
				{
					collisionPoint = vector2Array[i].X;
					flag = true;
				}
			}
			Vector2 vector29 = new Vector2(0f, single);
			Vector2 vector210 = new Vector2(single1, single);
			Vector2 vector211 = new Vector2(0f, -single);
			Vector2 vector212 = new Vector2(single1, -single);
			for (int j = 0; j < (int)vector2Array.Length; j++)
			{
				int length = (j + 1) % (int)vector2Array.Length;
				Vector2 vector213 = vector210 - vector29;
				Vector2 vector214 = vector2Array[length] - vector2Array[j];
				float x1 = vector213.X * vector214.Y - vector213.Y * vector214.X;
				if (x1 != 0f)
				{
					Vector2 vector215 = vector2Array[j] - vector29;
					float x2 = (vector215.X * vector214.Y - vector215.Y * vector214.X) / x1;
					if (x2 >= 0f && x2 <= 1f)
					{
						float x3 = (vector215.X * vector213.Y - vector215.Y * vector213.X) / x1;
						if (x3 >= 0f && x3 <= 1f)
						{
							flag = true;
							collisionPoint = Math.Min(collisionPoint, vector29.X + x2 * vector213.X);
						}
					}
				}
				vector213 = vector212 - vector211;
				x1 = vector213.X * vector214.Y - vector213.Y * vector214.X;
				if (x1 != 0f)
				{
					Vector2 vector216 = vector2Array[j] - vector211;
					float single3 = (vector216.X * vector214.Y - vector216.Y * vector214.X) / x1;
					if (single3 >= 0f && single3 <= 1f)
					{
						float x4 = (vector216.X * vector213.Y - vector216.Y * vector213.X) / x1;
						if (x4 >= 0f && x4 <= 1f)
						{
							flag = true;
							collisionPoint = Math.Min(collisionPoint, vector211.X + single3 * vector213.X);
						}
					}
				}
			}
			return flag;
		}

		public static Vector2[] CheckLinevLine(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
		{
			if (a1.Equals(a2) && b1.Equals(b2))
			{
				if (!a1.Equals(b1))
				{
					return new Vector2[0];
				}
				return new Vector2[] { a1 };
			}
			if (b1.Equals(b2))
			{
				if (!Collision.PointOnLine(b1, a1, a2))
				{
					return new Vector2[0];
				}
				return new Vector2[] { b1 };
			}
			if (a1.Equals(a2))
			{
				if (!Collision.PointOnLine(a1, b1, b2))
				{
					return new Vector2[0];
				}
				return new Vector2[] { a1 };
			}
			float x = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
			float single = (a2.X - a1.X) * (a1.Y - b1.Y) - (a2.Y - a1.Y) * (a1.X - b1.X);
			float y = (b2.Y - b1.Y) * (a2.X - a1.X) - (b2.X - b1.X) * (a2.Y - a1.Y);
			if (-Collision.Epsilon < y && y < Collision.Epsilon)
			{
				if ((-Collision.Epsilon >= x || x >= Collision.Epsilon) && (-Collision.Epsilon >= single || single >= Collision.Epsilon))
				{
					return new Vector2[0];
				}
				if (a1.Equals(a2))
				{
					return Collision.OneDimensionalIntersection(b1, b2, a1, a2);
				}
				return Collision.OneDimensionalIntersection(a1, a2, b1, b2);
			}
			float single1 = x / y;
			float single2 = single / y;
			if (0f > single1 || single1 > 1f || 0f > single2 || single2 > 1f)
			{
				return new Vector2[0];
			}
			Vector2[] vector2 = new Vector2[] { new Vector2(a1.X + single1 * (a2.X - a1.X), a1.Y + single1 * (a2.Y - a1.Y)) };
			return vector2;
		}

		private static double DistFromSeg(Vector2 p, Vector2 q0, Vector2 q1, double radius, ref float u)
		{
			double x = (double)(q1.X - q0.X);
			double y = (double)(q1.Y - q0.Y);
			double num = (double)(q0.X - p.X);
			double y1 = (double)(q0.Y - p.Y);
			double num1 = Math.Sqrt(x * x + y * y);
			if (num1 < (double)Collision.Epsilon)
			{
				throw new Exception("Expected line segment, not point.");
			}
			double num2 = Math.Abs(x * y1 - num * y);
			return num2 / num1;
		}

		public static bool DrownCollision(Vector2 Position, int Width, int Height, float gravDir = -1f)
		{
			Vector2 vector2 = new Vector2();
			Vector2 y = new Vector2(Position.X + (float)(Width / 2), Position.Y + (float)(Height / 2));
			int width = 10;
			int height = 12;
			if (width > Width)
			{
				width = Width;
			}
			if (height > Height)
			{
				height = Height;
			}
			y = new Vector2(y.X - (float)(width / 2), Position.Y + -2f);
			if (gravDir == -1f)
			{
				y.Y = y.Y + (float)(Height / 2 - 6);
			}
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y1 = (int)(Position.Y / 16f) - 1;
			int num1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			num1 = Utils.Clamp<int>(num1, 0, Main.maxTilesY - 1);
			for (int i = x; i < num; i++)
			{
				for (int j = y1; j < num1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && !Main.tile[i, j].lava())
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num2 = 16;
						float single = (float)(256 - Main.tile[i, j].liquid);
						single = single / 32f;
						vector2.Y = vector2.Y + single * 2f;
						num2 = num2 - (int)(single * 2f);
						if (y.X + (float)width > vector2.X && y.X < vector2.X + 16f && y.Y + (float)height > vector2.Y && y.Y < vector2.Y + (float)num2)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static bool EmptyTile(int i, int j, bool ignoreTiles = false)
		{
			Rectangle rectangle = new Rectangle(i * 16, j * 16, 16, 16);
			if (Main.tile[i, j].active() && !ignoreTiles)
			{
				return false;
			}
			for (int num = 0; num < 255; num++)
			{
				if (Main.player[num].active && rectangle.Intersects(new Rectangle((int)Main.player[num].position.X, (int)Main.player[num].position.Y, Main.player[num].width, Main.player[num].height)))
				{
					return false;
				}
			}
			for (int j1 = 0; j1 < 200; j1++)
			{
				if (Main.npc[j1].active && rectangle.Intersects(new Rectangle((int)Main.npc[j1].position.X, (int)Main.npc[j1].position.Y, Main.npc[j1].width, Main.npc[j1].height)))
				{
					return false;
				}
			}
			return true;
		}

		public static bool FindCollisionDirection(out int Direction, Vector2 position, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1)
		{
			Vector2 unitX = Vector2.UnitX * 16f;
			if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
			{
				Direction = 0;
				return true;
			}
			unitX = -Vector2.UnitX * 16f;
			if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
			{
				Direction = 1;
				return true;
			}
			unitX = Vector2.UnitY * 16f;
			if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
			{
				Direction = 2;
				return true;
			}
			unitX = -Vector2.UnitY * 16f;
			if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
			{
				Direction = 3;
				return true;
			}
			Direction = -1;
			return false;
		}

		public static List<Point> FindCollisionTile(int Direction, Vector2 position, float testMagnitude, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1, bool checkCardinals = true, bool checkSlopes = false)
		{
			int num;
			Vector2 vector2;
			Vector4 vector4;
			int width;
			int height;
			List<Point> points = new List<Point>();
			switch (Direction)
			{
				case 0:
				case 1:
				{
					vector2 = (Direction == 0 ? Vector2.UnitX * testMagnitude : -Vector2.UnitX * testMagnitude);
					vector4 = new Vector4(position, vector2.X, vector2.Y);
					float x = position.X;
					if (Direction == 0)
					{
						width = Width;
					}
					else
					{
						width = 0;
					}
					num = (int)(x + (float)width) / 16;
					float single = Math.Min(16f - position.Y % 16f, (float)Height);
					float single1 = single;
					if (checkCardinals && Collision.TileCollision(position - vector2, vector2, Width, (int)single, fallThrough, fall2, gravDir) != vector2)
					{
						points.Add(new Point(num, (int)position.Y / 16));
					}
					else if (checkSlopes && Collision.SlopeCollision(position, vector2, Width, (int)single, (float)gravDir, fallThrough).XZW() != vector4.XZW())
					{
						points.Add(new Point(num, (int)position.Y / 16));
					}
					while (single1 + 16f <= (float)(Height - 16))
					{
						if (checkCardinals && Collision.TileCollision((position - vector2) + (Vector2.UnitY * single1), vector2, Width, 16, fallThrough, fall2, gravDir) != vector2)
						{
							points.Add(new Point(num, (int)(position.Y + single1) / 16));
						}
						else if (checkSlopes && Collision.SlopeCollision(position + (Vector2.UnitY * single1), vector2, Width, 16, (float)gravDir, fallThrough).XZW() != vector4.XZW())
						{
							points.Add(new Point(num, (int)(position.Y + single1) / 16));
						}
						single1 = single1 + 16f;
					}
					int height1 = Height - (int)single1;
					if (!checkCardinals || !(Collision.TileCollision((position - vector2) + (Vector2.UnitY * single1), vector2, Width, height1, fallThrough, fall2, gravDir) != vector2))
					{
						if (!checkSlopes || !(Collision.SlopeCollision(position + (Vector2.UnitY * single1), vector2, Width, height1, (float)gravDir, fallThrough).XZW() != vector4.XZW()))
						{
							break;
						}
						points.Add(new Point(num, (int)(position.Y + single1) / 16));
						break;
					}
					else
					{
						points.Add(new Point(num, (int)(position.Y + single1) / 16));
						break;
					}
				}
				case 2:
				case 3:
				{
					vector2 = (Direction == 2 ? Vector2.UnitY * testMagnitude : -Vector2.UnitY * testMagnitude);
					vector4 = new Vector4(position, vector2.X, vector2.Y);
					float y = position.Y;
					if (Direction == 2)
					{
						height = Height;
					}
					else
					{
						height = 0;
					}
					num = (int)(y + (float)height) / 16;
					float single2 = Math.Min(16f - position.X % 16f, (float)Width);
					float single3 = single2;
					if (checkCardinals && Collision.TileCollision(position - vector2, vector2, (int)single2, Height, fallThrough, fall2, gravDir) != vector2)
					{
						points.Add(new Point((int)position.X / 16, num));
					}
					else if (checkSlopes && Collision.SlopeCollision(position, vector2, (int)single2, Height, (float)gravDir, fallThrough).YZW() != vector4.YZW())
					{
						points.Add(new Point((int)position.X / 16, num));
					}
					while (single3 + 16f <= (float)(Width - 16))
					{
						if (checkCardinals && Collision.TileCollision((position - vector2) + (Vector2.UnitX * single3), vector2, 16, Height, fallThrough, fall2, gravDir) != vector2)
						{
							points.Add(new Point((int)(position.X + single3) / 16, num));
						}
						else if (checkSlopes && Collision.SlopeCollision(position + (Vector2.UnitX * single3), vector2, 16, Height, (float)gravDir, fallThrough).YZW() != vector4.YZW())
						{
							points.Add(new Point((int)(position.X + single3) / 16, num));
						}
						single3 = single3 + 16f;
					}
					int width1 = Width - (int)single3;
					if (!checkCardinals || !(Collision.TileCollision((position - vector2) + (Vector2.UnitX * single3), vector2, width1, Height, fallThrough, fall2, gravDir) != vector2))
					{
						if (!checkSlopes || !(Collision.SlopeCollision(position + (Vector2.UnitX * single3), vector2, width1, Height, (float)gravDir, fallThrough).YZW() != vector4.YZW()))
						{
							break;
						}
						points.Add(new Point((int)(position.X + single3) / 16, num));
						break;
					}
					else
					{
						points.Add(new Point((int)(position.X + single3) / 16, num));
						break;
					}
				}
			}
			return points;
		}

		private static float[] FindOverlapPoints(float relativePoint1, float relativePoint2)
		{
			float single = Math.Min(relativePoint1, relativePoint2);
			float single1 = Math.Max(relativePoint1, relativePoint2);
			float single2 = Math.Max(0f, single);
			float single3 = Math.Min(1f, single1);
			if (single2 > single3)
			{
				return new float[0];
			}
			if (single2 == single3)
			{
				return new float[] { single2 };
			}
			return new float[] { single2, single3 };
		}

		public static float GetTileRotation(Vector2 position)
		{
			float y = position.Y % 16f;
			int x = (int)(position.X / 16f);
			int num = (int)(position.Y / 16f);
			Tile tile = Main.tile[x, num];
			bool flag = false;
			for (int i = 2; i >= 0; i--)
			{
				if (tile.active())
				{
					if (Main.tileSolid[tile.type])
					{
						int num1 = tile.blockType();
						if (tile.type != TileID.Platforms)
						{
							if (num1 == 1)
							{
								return 0f;
							}
							if (num1 == 2)
							{
								return 0.7853982f;
							}
							if (num1 == 3)
							{
								return -0.7853982f;
							}
							return 0f;
						}
						int num2 = tile.frameX / 18;
						if ((num2 >= 0 && num2 <= 7 || num2 >= 12 && num2 <= 16) && (y == 0f || flag))
						{
							return 0f;
						}
						switch (num2)
						{
							case 8:
							case 19:
							case 21:
							case 23:
							{
								return -0.7853982f;
							}
							case 10:
							case 20:
							case 22:
							case 24:
							{
								return 0.7853982f;
							}
							case 25:
							case 26:
							{
								if (flag)
								{
									return 0f;
								}
								if (num1 == 2)
								{
									return 0.7853982f;
								}
								if (num1 != 3)
								{
									break;
								}
								return -0.7853982f;
							}
						}
					}
					else if (Main.tileSolidTop[tile.type] && tile.frameY == 0 && flag)
					{
						return 0f;
					}
				}
				num++;
				tile = Main.tile[x, num];
				flag = true;
			}
			return 0f;
		}

		public static void HitTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector2 = new Vector2();
			Vector2 position = Position + Velocity;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (x < 0)
			{
				x = 0;
			}
			if (num > Main.maxTilesX)
			{
				num = Main.maxTilesX;
			}
			if (y < 0)
			{
				y = 0;
			}
			if (y1 > Main.maxTilesY)
			{
				y1 = Main.maxTilesY;
			}
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type] && Main.tile[i, j].frameY == 0))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num1 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num1 = num1 - 8;
						}
						if (position.X + (float)Width >= vector2.X && position.X <= vector2.X + 16f && position.Y + (float)Height >= vector2.Y && position.Y <= vector2.Y + (float)num1)
						{
							WorldGen.KillTile(i, j, true, true, false);
						}
					}
				}
			}
		}

		public static bool HitWallSubstep(int x, int y)
		{
			if (Main.tile[x, y].wall == WallID.None)
			{
				return false;
			}
			bool flag = false;
			if (Main.wallHouse[Main.tile[x, y].wall])
			{
				flag = true;
			}
			if (!flag)
			{
				for (int i = -1; i < 2; i++)
				{
					for (int j = -1; j < 2; j++)
					{
						if ((i != 0 || j != 0) && Main.tile[x + i, y + j].wall == 0)
						{
							flag = true;
						}
					}
				}
			}
			if (Main.tile[x, y].active() && flag)
			{
				bool flag1 = true;
				for (int k = -1; k < 2; k++)
				{
					for (int l = -1; l < 2; l++)
					{
						if (k != 0 || l != 0)
						{
							Tile tile = Main.tile[x + k, y + l];
							if (!tile.active() || !Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type])
							{
								flag1 = false;
							}
						}
					}
				}
				if (flag1)
				{
					flag = false;
				}
			}
			return flag;
		}

		public static Vector2 HurtTiles(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fireImmune = false)
		{
			Vector2 vector2 = new Vector2();
			Vector2 position = Position;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (x < 0)
			{
				x = 0;
			}
			if (num > Main.maxTilesX)
			{
				num = Main.maxTilesX;
			}
			if (y < 0)
			{
				y = 0;
			}
			if (y1 > Main.maxTilesY)
			{
				y1 = Main.maxTilesY;
			}
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && (Main.tile[i, j].type == TileID.CorruptThorns || Main.tile[i, j].type == TileID.Meteorite || Main.tile[i, j].type == TileID.Spikes || Main.tile[i, j].type == TileID.WoodenSpikes || Main.tile[i, j].type == TileID.Sand || Main.tile[i, j].type == TileID.Ash || Main.tile[i, j].type == TileID.Hellstone || Main.tile[i, j].type == TileID.JungleThorns || Main.tile[i, j].type == TileID.HellstoneBrick || Main.tile[i, j].type == TileID.Ebonsand || Main.tile[i, j].type == TileID.Pearlsand || Main.tile[i, j].type == TileID.Silt || Main.tile[i, j].type == TileID.Slush || Main.tile[i, j].type == TileID.Crimsand || Main.tile[i, j].type == TileID.CrimtaneThorns))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num1 = 0;
						int num2 = Main.tile[i, j].type;
						int num3 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num3 = num3 - 8;
						}
						if (num2 == 32 || num2 == 69 || num2 == 80 || num2 == 352 || num2 == 80 && Main.expertMode)
						{
							if (position.X + (float)Width > vector2.X && position.X < vector2.X + 16f && position.Y + (float)Height > vector2.Y && position.Y < vector2.Y + (float)num3 + 0.011f)
							{
								int num4 = 1;
								if (position.X + (float)(Width / 2) < vector2.X + 8f)
								{
									num4 = -1;
								}
								num1 = 10;
								if (num2 == 69)
								{
									num1 = 17;
								}
								else if (num2 == 80)
								{
									num1 = 6;
								}
								if (num2 == 32 || num2 == 69 || num2 == 352)
								{
									WorldGen.KillTile(i, j, false, false, false);
									if (Main.netMode == 1 && !Main.tile[i, j].active() && Main.netMode == 1)
									{
										NetMessage.SendData((int)PacketTypes.Tile, -1, -1, "", 4, (float)i, (float)j, 0f, 0, 0, 0);
									}
								}
								return new Vector2((float)num4, (float)num1);
							}
						}
						else if (num2 != 53 && num2 != 112 && num2 != 116 && num2 != 123 && num2 != 224 && num2 != 234)
						{
							if (position.X + (float)Width >= vector2.X && position.X <= vector2.X + 16f && position.Y + (float)Height >= vector2.Y && position.Y <= vector2.Y + (float)num3 + 0.011f)
							{
								int num5 = 1;
								if (position.X + (float)(Width / 2) < vector2.X + 8f)
								{
									num5 = -1;
								}
								if (!fireImmune && (num2 == 37 || num2 == 58 || num2 == 76))
								{
									num1 = 20;
								}
								if (num2 == 48)
								{
									num1 = 40;
								}
								if (num2 == 232)
								{
									num1 = 60;
								}
								return new Vector2((float)num5, (float)num1);
							}
						}
						else if (position.X + (float)Width - 2f >= vector2.X && position.X + 2f <= vector2.X + 16f && position.Y + (float)Height - 2f >= vector2.Y && position.Y + 2f <= vector2.Y + (float)num3)
						{
							int num6 = 1;
							if (position.X + (float)(Width / 2) < vector2.X + 8f)
							{
								num6 = -1;
							}
							num1 = 15;
							return new Vector2((float)num6, (float)num1);
						}
					}
				}
			}
			return new Vector2();
		}

		public static bool InTileBounds(int x, int y, int lx, int ly, int hx, int hy)
		{
			if (x >= lx && x <= hx && y >= ly && y <= hy)
			{
				return true;
			}
			return false;
		}

		public static bool IsClearSpotHack(Vector2 position, float testMagnitude, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1, bool checkCardinals = true, bool checkSlopes = false)
		{
			Vector2 unitX;
			if (checkCardinals)
			{
				unitX = Vector2.UnitX * testMagnitude;
				if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
				{
					return false;
				}
				unitX = -Vector2.UnitX * testMagnitude;
				if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
				{
					return false;
				}
				unitX = Vector2.UnitY * testMagnitude;
				if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
				{
					return false;
				}
				unitX = -Vector2.UnitY * testMagnitude;
				if (Collision.TileCollision(position - unitX, unitX, Width, Height, fallThrough, fall2, gravDir) != unitX)
				{
					return false;
				}
			}
			if (checkSlopes)
			{
				unitX = Vector2.UnitX * testMagnitude;
				Vector4 vector4 = new Vector4(position, testMagnitude, 0f);
				if (Collision.SlopeCollision(position, unitX, Width, Height, (float)gravDir, fallThrough) != vector4)
				{
					return false;
				}
				unitX = -Vector2.UnitX * testMagnitude;
				vector4 = new Vector4(position, -testMagnitude, 0f);
				if (Collision.SlopeCollision(position, unitX, Width, Height, (float)gravDir, fallThrough) != vector4)
				{
					return false;
				}
				unitX = Vector2.UnitY * testMagnitude;
				vector4 = new Vector4(position, 0f, testMagnitude);
				if (Collision.SlopeCollision(position, unitX, Width, Height, (float)gravDir, fallThrough) != vector4)
				{
					return false;
				}
				unitX = -Vector2.UnitY * testMagnitude;
				vector4 = new Vector4(position, 0f, -testMagnitude);
				if (Collision.SlopeCollision(position, unitX, Width, Height, (float)gravDir, fallThrough) != vector4)
				{
					return false;
				}
			}
			return true;
		}

		public static bool LavaCollision(Vector2 Position, int Width, int Height)
		{
			Vector2 vector2 = new Vector2();
			int height = Height;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j].lava())
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num1 = 16;
						float single = (float)(256 - Main.tile[i, j].liquid);
						single = single / 32f;
						vector2.Y = vector2.Y + single * 2f;
						num1 = num1 - (int)(single * 2f);
						if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)height > vector2.Y && Position.Y < vector2.Y + (float)num1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static Vector2 noSlopeCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false)
		{
			Vector2 vector2 = new Vector2();
			Collision.up = false;
			Collision.down = false;
			Vector2 velocity = Velocity;
			Vector2 velocity1 = Velocity;
			Vector2 position = Position + Velocity;
			Vector2 position1 = Position;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num1 = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			float single = (float)((y1 + 3) * 16);
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type] && Main.tile[i, j].frameY == 0))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num5 = num5 - 8;
						}
						if (position.X + (float)Width > vector2.X && position.X < vector2.X + 16f && position.Y + (float)Height > vector2.Y && position.Y < vector2.Y + (float)num5)
						{
							if (position1.Y + (float)Height <= vector2.Y)
							{
								Collision.down = true;
								if ((!Main.tileSolidTop[Main.tile[i, j].type] || !fallThrough || Velocity.Y > 1f && !fall2) && single > vector2.Y)
								{
									num3 = i;
									num4 = j;
									if (num5 < 16)
									{
										num4++;
									}
									if (num3 != num1)
									{
										velocity.Y = vector2.Y - (position1.Y + (float)Height);
										single = vector2.Y;
									}
								}
							}
							else if (position1.X + (float)Width <= vector2.X && !Main.tileSolidTop[Main.tile[i, j].type])
							{
								num1 = i;
								num2 = j;
								if (num2 != num4)
								{
									velocity.X = vector2.X - (position1.X + (float)Width);
								}
								if (num3 == num1)
								{
									velocity.Y = velocity1.Y;
								}
							}
							else if (position1.X >= vector2.X + 16f && !Main.tileSolidTop[Main.tile[i, j].type])
							{
								num1 = i;
								num2 = j;
								if (num2 != num4)
								{
									velocity.X = vector2.X + 16f - position1.X;
								}
								if (num3 == num1)
								{
									velocity.Y = velocity1.Y;
								}
							}
							else if (position1.Y >= vector2.Y + (float)num5 && !Main.tileSolidTop[Main.tile[i, j].type])
							{
								Collision.up = true;
								num3 = i;
								num4 = j;
								velocity.Y = vector2.Y + (float)num5 - position1.Y + 0.01f;
								if (num4 == num2)
								{
									velocity.X = velocity1.X;
								}
							}
						}
					}
				}
			}
			return velocity;
		}

		private static Vector2[] OneDimensionalIntersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
		{
			float y;
			float x;
			float single = a2.X - a1.X;
			float y1 = a2.Y - a1.Y;
			if (Math.Abs(single) <= Math.Abs(y1))
			{
				y = (b1.Y - a1.Y) / y1;
				x = (b2.Y - a1.Y) / y1;
			}
			else
			{
				y = (b1.X - a1.X) / single;
				x = (b2.X - a1.X) / single;
			}
			List<Vector2> vector2s = new List<Vector2>();
			float[] singleArray = Collision.FindOverlapPoints(y, x);
			for (int i = 0; i < (int)singleArray.Length; i++)
			{
				float single1 = (float)singleArray[i];
				float x1 = a2.X * single1 + a1.X * (1f - single1);
				float y2 = a2.Y * single1 + a1.Y * (1f - single1);
				vector2s.Add(new Vector2(x1, y2));
			}
			return vector2s.ToArray();
		}

		private static bool PointOnLine(Vector2 p, Vector2 a1, Vector2 a2)
		{
			float single = 0f;
			double num = Collision.DistFromSeg(p, a1, a2, (double)Collision.Epsilon, ref single);
			return num < (double)Collision.Epsilon;
		}

		public static Vector4 SlopeCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f, bool fall = false)
		{
			Vector2 vector2 = new Vector2();
			Collision.stair = false;
			Collision.stairFall = false;
			bool[] flagArray = new bool[5];
			float y = Position.Y;
			float single = Position.Y;
			Collision.sloping = false;
			Vector2 position = Position;
			Vector2 x = Position;
			Vector2 velocity = Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int x1 = (int)((Position.X + (float)Width) / 16f) + 2;
			int y1 = (int)(Position.Y / 16f) - 1;
			int num1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			x1 = Utils.Clamp<int>(x1, 0, Main.maxTilesX - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			num1 = Utils.Clamp<int>(num1, 0, Main.maxTilesY - 1);
			for (int i = num; i < x1; i++)
			{
				for (int j = y1; j < num1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type] && Main.tile[i, j].frameY == 0))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num2 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num2 = num2 - 8;
						}
						if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)Height > vector2.Y && Position.Y < vector2.Y + (float)num2)
						{
							bool flag = true;
							if (Main.tile[i, j].slope() > 0)
							{
								if (Main.tile[i, j].slope() <= 2)
								{
									if (Main.tile[i, j].slope() == 1 && position.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector2.Y + (float)num2 && position.X >= vector2.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 2 && position.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector2.Y + (float)num2 && position.X + (float)Width <= vector2.X + 16f)
									{
										flag = true;
									}
								}
								else
								{
									if (Main.tile[i, j].slope() == 3 && position.Y + Math.Abs(Velocity.X) + 1f >= vector2.Y && position.X >= vector2.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 4 && position.Y + Math.Abs(Velocity.X) + 1f >= vector2.Y && position.X + (float)Width <= vector2.X + 16f)
									{
										flag = true;
									}
								}
							}
							if (Main.tile[i, j].type == TileID.Platforms)
							{
								if (Velocity.Y < 0f)
								{
									flag = false;
								}
								if (Position.Y + (float)Height < (float)(j * 16) || Position.Y + (float)Height - (1f + Math.Abs(Velocity.X)) > (float)(j * 16 + 16))
								{
									flag = false;
								}
							}
							if (flag)
							{
								bool flag1 = false;
								if (fall && Main.tile[i, j].type == TileID.Platforms)
								{
									flag1 = true;
								}
								int num3 = Main.tile[i, j].slope();
								vector2.X = (float)(i * 16);
								vector2.Y = (float)(j * 16);
								if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)Height > vector2.Y && Position.Y < vector2.Y + 16f)
								{
									float single1 = 0f;
									if (num3 == 3 || num3 == 4)
									{
										if (num3 == 3)
										{
											single1 = Position.X - vector2.X;
										}
										if (num3 == 4)
										{
											single1 = vector2.X + 16f - (Position.X + (float)Width);
										}
										if (single1 >= 0f)
										{
											if (Position.Y <= vector2.Y + 16f - single1)
											{
												float y2 = vector2.Y + 16f - position.Y - single1;
												if (Position.Y + y2 > single)
												{
													x.Y = Position.Y + y2;
													single = x.Y;
													if (velocity.Y < 0.0101f)
													{
														velocity.Y = 0.0101f;
													}
													flagArray[num3] = true;
												}
											}
										}
										else if (Position.Y > vector2.Y)
										{
											float single2 = vector2.Y + 16f;
											if (x.Y < single2)
											{
												x.Y = single2;
												if (velocity.Y < 0.0101f)
												{
													velocity.Y = 0.0101f;
												}
											}
										}
									}
									if (num3 == 1 || num3 == 2)
									{
										if (num3 == 1)
										{
											single1 = Position.X - vector2.X;
										}
										if (num3 == 2)
										{
											single1 = vector2.X + 16f - (Position.X + (float)Width);
										}
										if (single1 >= 0f)
										{
											if (Position.Y + (float)Height >= vector2.Y + single1)
											{
												float y3 = vector2.Y - (position.Y + (float)Height) + single1;
												if (Position.Y + y3 < y)
												{
													if (!flag1)
													{
														if (Main.tile[i, j].type != TileID.Platforms)
														{
															Collision.stair = false;
														}
														else
														{
															Collision.stair = true;
														}
														x.Y = Position.Y + y3;
														y = x.Y;
														if (velocity.Y > 0f)
														{
															velocity.Y = 0f;
														}
														flagArray[num3] = true;
													}
													else
													{
														Collision.stairFall = true;
													}
												}
											}
										}
										else if (Main.tile[i, j].type != TileID.Platforms || Position.Y + (float)Height - 4f - Math.Abs(Velocity.X) <= vector2.Y)
										{
											float single3 = vector2.Y - (float)Height;
											if (x.Y > single3)
											{
												if (!flag1)
												{
													if (Main.tile[i, j].type != TileID.Platforms)
													{
														Collision.stair = false;
													}
													else
													{
														Collision.stair = true;
													}
													x.Y = single3;
													if (velocity.Y > 0f)
													{
														velocity.Y = 0f;
													}
												}
												else
												{
													Collision.stairFall = true;
												}
											}
										}
										else if (flag1)
										{
											Collision.stairFall = true;
										}
									}
								}
							}
						}
					}
				}
			}
			Vector2 position1 = Position;
			Vector2 vector21 = x - Position;
			Vector2 vector22 = Collision.TileCollision(position1, vector21, Width, Height, false, false, 1);
			if (vector22.Y > vector21.Y)
			{
				float y4 = vector21.Y - vector22.Y;
				x.Y = Position.Y + vector22.Y;
				if (flagArray[1])
				{
					x.X = Position.X - y4;
				}
				if (flagArray[2])
				{
					x.X = Position.X + y4;
				}
				velocity.X = 0f;
				velocity.Y = 0f;
				Collision.up = false;
			}
			else if (vector22.Y < vector21.Y)
			{
				float single4 = vector22.Y - vector21.Y;
				x.Y = Position.Y + vector22.Y;
				if (flagArray[3])
				{
					x.X = Position.X - single4;
				}
				if (flagArray[4])
				{
					x.X = Position.X + single4;
				}
				velocity.X = 0f;
				velocity.Y = 0f;
			}
			return new Vector4(x, velocity.X, velocity.Y);
		}

		public static Vector4 SlopeCollision_Yor(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f, bool fall = false)
		{
			Vector2 vector2 = new Vector2();
			Collision.stair = false;
			Collision.stairFall = false;
			bool[] flagArray = new bool[5];
			float y = Position.Y;
			float single = Position.Y;
			Collision.sloping = false;
			Vector2 position = Position;
			Vector2 x = Position;
			Vector2 velocity = Velocity;
			int num = (int)(Position.X / 16f) - 1;
			int x1 = (int)((Position.X + (float)Width) / 16f) + 2;
			int y1 = (int)(Position.Y / 16f) - 1;
			int num1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			x1 = Utils.Clamp<int>(x1, 0, Main.maxTilesX - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			num1 = Utils.Clamp<int>(num1, 0, Main.maxTilesY - 1);
			int num2 = 1;
			int num3 = 1;
			int num4 = x1;
			int num5 = num1;
			if (Velocity.X < 0f)
			{
				num2 = -1;
				num4 = num;
			}
			if (Velocity.Y < 0f)
			{
				num3 = -1;
				num5 = y1;
			}
			int x2 = (int)(Position.X + (float)(Width / 2)) / 16;
			int y2 = (int)(Position.Y + (float)(Height / 2)) / 16;
			for (int i = x2; i != num4; i = i + num2)
			{
				for (int j = y2; j != num5; j = j + num3)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type] && Main.tile[i, j].frameY == 0))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num6 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num6 = num6 - 8;
						}
						if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)Height > vector2.Y && Position.Y < vector2.Y + (float)num6)
						{
							bool flag = true;
							if (Main.tile[i, j].slope() > 0)
							{
								if (Main.tile[i, j].slope() <= 2)
								{
									if (Main.tile[i, j].slope() == 1 && position.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector2.Y + (float)num6 && position.X >= vector2.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 2 && position.Y + (float)Height - Math.Abs(Velocity.X) - 1f <= vector2.Y + (float)num6 && position.X + (float)Width <= vector2.X + 16f)
									{
										flag = true;
									}
								}
								else
								{
									if (Main.tile[i, j].slope() == 3 && position.Y + Math.Abs(Velocity.X) + 1f >= vector2.Y && position.X >= vector2.X)
									{
										flag = true;
									}
									if (Main.tile[i, j].slope() == 4 && position.Y + Math.Abs(Velocity.X) + 1f >= vector2.Y && position.X + (float)Width <= vector2.X + 16f)
									{
										flag = true;
									}
								}
							}
							if (Main.tile[i, j].type == TileID.Platforms)
							{
								if (Velocity.Y < 0f)
								{
									flag = false;
								}
								if (Position.Y + (float)Height < (float)(j * 16) || Position.Y + (float)Height - (1f + Math.Abs(Velocity.X)) > (float)(j * 16 + 16))
								{
									flag = false;
								}
							}
							if (flag)
							{
								bool flag1 = false;
								if (fall && Main.tile[i, j].type == TileID.Platforms)
								{
									flag1 = true;
								}
								int num7 = Main.tile[i, j].slope();
								vector2.X = (float)(i * 16);
								vector2.Y = (float)(j * 16);
								if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)Height > vector2.Y && Position.Y < vector2.Y + 16f)
								{
									float single1 = 0f;
									if (num7 == 3 || num7 == 4)
									{
										if (num7 == 3)
										{
											single1 = Position.X - vector2.X;
										}
										if (num7 == 4)
										{
											single1 = vector2.X + 16f - (Position.X + (float)Width);
										}
										if (single1 >= 0f)
										{
											if (Position.Y <= vector2.Y + 16f - single1)
											{
												float single2 = vector2.Y + 16f - position.Y - single1;
												if (Position.Y + single2 > single)
												{
													x.Y = x.Y + single2;
													single = x.Y;
													if (velocity.Y < 0.0101f)
													{
														velocity.Y = 0.0101f;
													}
													flagArray[num7] = true;
												}
											}
										}
										else if (Position.Y > vector2.Y)
										{
											float y3 = vector2.Y + 16f;
											if (x.Y < y3)
											{
												x.Y = y3;
												if (velocity.Y < 0.0101f)
												{
													velocity.Y = 0.0101f;
												}
											}
										}
									}
									if (num7 == 1 || num7 == 2)
									{
										if (num7 == 1)
										{
											single1 = Position.X - vector2.X;
										}
										if (num7 == 2)
										{
											single1 = vector2.X + 16f - (Position.X + (float)Width);
										}
										if (single1 >= 0f)
										{
											if (Position.Y + (float)Height >= vector2.Y + single1)
											{
												float single3 = vector2.Y - (position.Y + (float)Height) + single1;
												if (Position.Y + single3 < y)
												{
													if (!flag1)
													{
														if (Main.tile[i, j].type != TileID.Platforms)
														{
															Collision.stair = false;
														}
														else
														{
															Collision.stair = true;
														}
														x.Y = x.Y + single3;
														y = x.Y;
														if (velocity.Y > 0f)
														{
															velocity.Y = 0f;
														}
														flagArray[num7] = true;
													}
													else
													{
														Collision.stairFall = true;
													}
												}
											}
										}
										else if (Main.tile[i, j].type != TileID.Platforms || Position.Y + (float)Height - 4f - Math.Abs(Velocity.X) <= vector2.Y)
										{
											float y4 = vector2.Y - (float)Height;
											if (x.Y > y4)
											{
												if (!flag1)
												{
													if (Main.tile[i, j].type != TileID.Platforms)
													{
														Collision.stair = false;
													}
													else
													{
														Collision.stair = true;
													}
													x.Y = y4;
													if (velocity.Y > 0f)
													{
														velocity.Y = 0f;
													}
												}
												else
												{
													Collision.stairFall = true;
												}
											}
										}
										else if (flag1)
										{
											Collision.stairFall = true;
										}
									}
								}
							}
						}
					}
				}
			}
			Vector2 position1 = Position;
			Vector2 vector21 = x - Position;
			Vector2 vector22 = Collision.TileCollision(position1, vector21, Width, Height, false, false, 1);
			if (vector22.Y > vector21.Y)
			{
				float single4 = vector21.Y - vector22.Y;
				x.Y = Position.Y + vector22.Y;
				if (flagArray[1])
				{
					x.X = Position.X - single4;
				}
				if (flagArray[2])
				{
					x.X = Position.X + single4;
				}
				velocity.X = 0f;
				velocity.Y = 0f;
				Collision.up = false;
			}
			else if (vector22.Y < vector21.Y)
			{
				float y5 = vector22.Y - vector21.Y;
				x.Y = Position.Y + vector22.Y;
				if (flagArray[3])
				{
					x.X = Position.X - y5;
				}
				if (flagArray[4])
				{
					x.X = Position.X + y5;
				}
				velocity.X = 0f;
				velocity.Y = 0f;
			}
			return new Vector4(x, velocity.X, velocity.Y);
		}

		public static bool SolidCollision(Vector2 Position, int Width, int Height)
		{
			Vector2 vector2 = new Vector2();
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num1 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num1 = num1 - 8;
						}
						if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)Height > vector2.Y && Position.Y < vector2.Y + (float)num1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static bool SolidTiles(int startX, int endX, int startY, int endY)
		{
			if (startX < 0)
			{
				return true;
			}
			if (endX >= Main.maxTilesX)
			{
				return true;
			}
			if (startY < 0)
			{
				return true;
			}
			if (endY >= Main.maxTilesY)
			{
				return true;
			}
			for (int i = startX; i < endX + 1; i++)
			{
				for (int j = startY; j < endY + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						return false;
					}
					if (Main.tile[i, j].active() && !Main.tile[i, j].inActive() && Main.tileSolid[Main.tile[i, j].type] && !Main.tileSolidTop[Main.tile[i, j].type])
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool SolidTilesVersatile(int startX, int endX, int startY, int endY)
		{
			if (startX > endX)
			{
				Utils.Swap<int>(ref startX, ref endX);
			}
			if (startY > endY)
			{
				Utils.Swap<int>(ref startY, ref endY);
			}
			return Collision.SolidTiles(startX, endX, startY, endY);
		}

		public static void StepDown(ref Vector2 position, ref Vector2 velocity, int width, int height, ref float stepSpeed, ref float gfxOffY, int gravDir = 1, bool waterWalk = false)
		{
			Vector2 x = position;
			x.X = x.X + velocity.X;
			x.Y = (float)Math.Floor((double)((x.Y + (float)height) / 16f)) * 16f - (float)height;
			bool flag = false;
			int num = (int)(x.X / 16f);
			int x1 = (int)((x.X + (float)width) / 16f);
			int y = (int)((x.Y + (float)height + 4f) / 16f);
			float single = (float)((y + height / 16 + (height % 16 == 0 ? 0 : 1)) * 16);
			float single1 = Main.bottomWorld / 16f - 42f;
			for (int i = num; i <= x1; i++)
			{
				for (int j = y; j <= y + 1; j++)
				{
					if (WorldGen.InWorld(i, j, 1))
					{
						if (Main.tile[i, j] == null)
						{
							Main.tile[i, j] = new Tile();
						}
						if (Main.tile[i, j - 1] == null)
						{
							Main.tile[i, j - 1] = new Tile();
						}
						if (Main.tile[i, j].topSlope())
						{
							flag = true;
						}
						if (waterWalk && Main.tile[i, j].liquid > 0 && Main.tile[i, j - 1].liquid == 0)
						{
							int num1 = Main.tile[i, j].liquid / 32 * 2 + 2;
							int num2 = j * 16 + 16 - num1;
							Rectangle rectangle = new Rectangle(i * 16, j * 16 - 17, 16, 16);
							if (rectangle.Intersects(new Rectangle((int)position.X, (int)position.Y, width, height)) && (float)num2 < single)
							{
								single = (float)num2;
							}
						}
						if ((float)j >= single1 || Main.tile[i, j].nactive() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type]))
						{
							int num3 = j * 16;
							if (Main.tile[i, j].halfBrick())
							{
								num3 = num3 + 8;
							}
							if (Utils.FloatIntersect((float)(i * 16), (float)(j * 16 - 17), 16f, 16f, position.X, position.Y, (float)width, (float)height) && (float)num3 < single)
							{
								single = (float)num3;
							}
						}
					}
				}
			}
			float y1 = single - (position.Y + (float)height);
			if (y1 > 7f && y1 < 17f && !flag)
			{
				stepSpeed = 1.5f;
				if (y1 > 9f)
				{
					stepSpeed = 2.5f;
				}
				gfxOffY = gfxOffY + (position.Y + (float)height - single);
				position.Y = single - (float)height;
			}
		}

		public static void StepUp(ref Vector2 position, ref Vector2 velocity, int width, int height, ref float stepSpeed, ref float gfxOffY, int gravDir = 1, bool holdsMatching = false, int specialChecksMode = 0)
		{
			Tile tile;
			Tile tile1;
			bool flag;
			bool flag1;
			bool flag2;
			bool flag3;
			bool flag4;
			bool flag5;
			int num = 0;
			if (velocity.X < 0f)
			{
				num = -1;
			}
			if (velocity.X > 0f)
			{
				num = 1;
			}
			Vector2 x = position;
			x.X = x.X + velocity.X;
			int x1 = (int)((x.X + (float)(width / 2) + (float)((width / 2 + 1) * num)) / 16f);
			int y = (int)(((double)x.Y + 0.1) / 16);
			if (gravDir == 1)
			{
				y = (int)((x.Y + (float)height - 1f) / 16f);
			}
			int num1 = height / 16 + (height % 16 == 0 ? 0 : 1);
			bool flag6 = true;
			bool flag7 = true;
			if (Main.tile[x1, y] == null)
			{
				return;
			}
			for (int i = 1; i < num1 + 2; i++)
			{
				if (!WorldGen.InWorld(x1, y - i * gravDir, 0) || Main.tile[x1, y - i * gravDir] == null)
				{
					return;
				}
			}
			if (!WorldGen.InWorld(x1 - num, y - num1 * gravDir, 0) || Main.tile[x1 - num, y - num1 * gravDir] == null)
			{
				return;
			}
			for (int j = 2; j < num1 + 1; j++)
			{
				if (!WorldGen.InWorld(x1, y - j * gravDir, 0))
				{
					return;
				}
				if (Main.tile[x1, y - j * gravDir] == null)
				{
					return;
				}
				tile = Main.tile[x1, y - j * gravDir];
				if (!flag6)
				{
					flag = false;
				}
				else
				{
					flag = (!tile.nactive() || !Main.tileSolid[tile.type] ? true : Main.tileSolidTop[tile.type]);
				}
				flag6 = flag;
			}
			tile = Main.tile[x1 - num, y - num1 * gravDir];
			if (!flag7)
			{
				flag1 = false;
			}
			else
			{
				flag1 = (!tile.nactive() || !Main.tileSolid[tile.type] ? true : Main.tileSolidTop[tile.type]);
			}
			flag7 = flag1;
			bool flag8 = true;
			bool flag9 = true;
			bool flag10 = true;
			if (gravDir != 1)
			{
				tile = Main.tile[x1, y - gravDir];
				tile1 = Main.tile[x1, y - (num1 + 1) * gravDir];
				if (!flag8)
				{
					flag2 = false;
				}
				else if (!tile.nactive() || !Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type] || tile.slope() != 0)
				{
					flag2 = true;
				}
				else if (!tile.halfBrick())
				{
					flag2 = false;
				}
				else
				{
					flag2 = (!tile1.nactive() || !Main.tileSolid[tile1.type] ? true : Main.tileSolidTop[tile1.type]);
				}
				flag8 = flag2;
				tile = Main.tile[x1, y];
				tile1 = Main.tile[x1, y + 1];
				if (!flag9)
				{
					flag3 = false;
				}
				else if (!tile.nactive() || (!Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type]) && (!holdsMatching || !Main.tileSolidTop[tile.type] || tile.frameY != 0 || Main.tileSolid[tile1.type] && tile1.nactive()))
				{
					flag3 = (!tile1.halfBrick() ? false : tile1.nactive());
				}
				else
				{
					flag3 = true;
				}
				flag9 = flag3;
			}
			else
			{
				if (Main.tile[x1, y - gravDir] == null)
				{
					return;
				}
				if (Main.tile[x1, y - (num1 + 1) * gravDir] == null)
				{
					return;
				}
				tile = Main.tile[x1, y - gravDir];
				tile1 = Main.tile[x1, y - (num1 + 1) * gravDir];
				if (!flag8)
				{
					flag4 = false;
				}
				else if (!tile.nactive() || !Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type] || tile.slope() == 1 && position.X + (float)(width / 2) > (float)(x1 * 16) || tile.slope() == 2 && position.X + (float)(width / 2) < (float)(x1 * 16 + 16))
				{
					flag4 = true;
				}
				else if (!tile.halfBrick())
				{
					flag4 = false;
				}
				else
				{
					flag4 = (!tile1.nactive() || !Main.tileSolid[tile1.type] ? true : Main.tileSolidTop[tile1.type]);
				}
				flag8 = flag4;
				tile = Main.tile[x1, y];
				tile1 = Main.tile[x1, y - 1];
				if (specialChecksMode == 1)
				{
					flag10 = (tile.type == TileID.Anvils || tile.type == TileID.WorkBenches ? false : tile.type != TileID.MythrilAnvil);
				}
				if (!flag9)
				{
					flag5 = false;
				}
				else if (!tile.nactive() || tile.topSlope() && (tile.slope() != 1 || position.X + (float)(width / 2) >= (float)(x1 * 16)) && (tile.slope() != 2 || position.X + (float)(width / 2) <= (float)(x1 * 16 + 16)) || tile.topSlope() && position.Y + (float)height <= (float)(y * 16) || (!Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type]) && (!holdsMatching || (!Main.tileSolidTop[tile.type] || tile.frameY != 0) && tile.type != TileID.Platforms || Main.tileSolid[tile1.type] && tile1.nactive() || !flag10))
				{
					flag5 = (!tile1.halfBrick() ? false : tile1.nactive());
				}
				else
				{
					flag5 = true;
				}
				flag9 = flag5;
				flag9 = flag9 & (!Main.tileSolidTop[tile.type] ? true : !Main.tileSolidTop[tile1.type]);
			}
			if ((float)(x1 * 16) < x.X + (float)width && (float)(x1 * 16 + 16) > x.X)
			{
				if (gravDir == 1)
				{
					if (flag9 && flag8 && flag6 && flag7)
					{
						float single = (float)(y * 16);
						if (Main.tile[x1, y - 1].halfBrick())
						{
							single = single - 8f;
						}
						else if (Main.tile[x1, y].halfBrick())
						{
							single = single + 8f;
						}
						if (single < x.Y + (float)height)
						{
							float y1 = x.Y + (float)height - single;
							if ((double)y1 <= 16.1)
							{
								gfxOffY = gfxOffY + (position.Y + (float)height - single);
								position.Y = single - (float)height;
								if (y1 < 9f)
								{
									stepSpeed = 1f;
									return;
								}
								stepSpeed = 2f;
								return;
							}
						}
					}
				}
				else if (flag9 && flag8 && flag6 && flag7 && !Main.tile[x1, y].bottomSlope())
				{
					float single1 = (float)(y * 16 + 16);
					if (single1 > x.Y)
					{
						float y2 = single1 - x.Y;
						if ((double)y2 <= 16.1)
						{
							gfxOffY = gfxOffY - (single1 - position.Y);
							position.Y = single1;
							velocity.Y = 0f;
							if (y2 < 9f)
							{
								stepSpeed = 1f;
								return;
							}
							stepSpeed = 2f;
						}
					}
				}
			}
		}

		public static Vector2 StickyTiles(Vector2 Position, Vector2 Velocity, int Width, int Height)
		{
			Vector2 vector2 = new Vector2();
			Vector2 position = Position;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (x < 0)
			{
				x = 0;
			}
			if (num > Main.maxTilesX)
			{
				num = Main.maxTilesX;
			}
			if (y < 0)
			{
				y = 0;
			}
			if (y1 > Main.maxTilesY)
			{
				y1 = Main.maxTilesY;
			}
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive())
					{
						if (Main.tile[i, j].type == TileID.Cobweb)
						{
							int num1 = 0;
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							if (position.X + (float)Width > vector2.X - (float)num1 && position.X < vector2.X + 16f + (float)num1 && position.Y + (float)Height > vector2.Y && (double)position.Y < (double)vector2.Y + 16.01)
							{
								if (Main.tile[i, j].type == TileID.Cobweb && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.Next(30) == 0)
								{
								}
								return new Vector2((float)i, (float)j);
							}
						}
						else if (Main.tile[i, j].type == TileID.HoneyBlock && Main.tile[i, j].slope() == 0)
						{
							int num2 = 1;
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							float single = 16.01f;
							if (Main.tile[i, j].halfBrick())
							{
								vector2.Y = vector2.Y + 8f;
								single = single - 8f;
							}
							if (position.X + (float)Width > vector2.X - (float)num2 && position.X < vector2.X + 16f + (float)num2 && position.Y + (float)Height > vector2.Y && position.Y < vector2.Y + single)
							{
								if (Main.tile[i, j].type == TileID.Cobweb && (double)(Math.Abs(Velocity.X) + Math.Abs(Velocity.Y)) > 0.7 && Main.rand.Next(30) == 0)
								{
								}
								return new Vector2((float)i, (float)j);
							}
						}
					}
				}
			}
			return new Vector2(-1f, -1f);
		}

		public static bool SwitchTiles(object TriggeringObject, Vector2 Position, int Width, int Height, Vector2 oldPosition, int objType)
		{
			Vector2 vector2 = new Vector2();
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			if (x < 0)
			{
				x = 0;
			}
			if (num > Main.maxTilesX)
			{
				num = Main.maxTilesX;
			}
			if (y < 0)
			{
				y = 0;
			}
			if (y1 > Main.maxTilesY)
			{
				y1 = Main.maxTilesY;
			}
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tile[i, j].type == TileID.PressurePlates || Main.tile[i, j].type == TileID.LandMine))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16 + 12);
						if (Position.X + (float)Width > vector2.X && Position.X < vector2.X + 16f && Position.Y + (float)Height > vector2.Y && (double)Position.Y < (double)vector2.Y + 4.01)
						{
							if (Main.tile[i, j].type == TileID.LandMine)
							{
								WorldGen.ExplodeMine(i, j);
							}
							else if (oldPosition.X + (float)Width <= vector2.X || oldPosition.X >= vector2.X + 16f || oldPosition.Y + (float)Height <= vector2.Y || (double)oldPosition.Y >= (double)vector2.Y + 16.01)
							{
								int num1 = Main.tile[i, j].frameY / 18;
								bool flag = true;
								if ((num1 == 4 || num1 == 2 || num1 == 3 || num1 == 6) && objType != 1)
								{
									flag = false;
								}
								if (num1 == 5 && objType == 1)
								{
									flag = false;
								}
								if (flag)
								{
									bool handled = false;
									if (TriggeringObject is NPC)
									{
										handled = ServerApi.Hooks.InvokeNpcTriggerPressurePlate((NPC)TriggeringObject, i, j);
									}
									else if (TriggeringObject is Projectile)
									{
										handled = ServerApi.Hooks.InvokeProjectileTriggerPressurePlate((Projectile)TriggeringObject, i, j);
									}
									else if (TriggeringObject is Player)
									{
										handled = ServerApi.Hooks.InvokePlayerTriggerPressurePlate((Player)TriggeringObject, i, j);
									}
									if (!handled)
									{
										Wiring.HitSwitch(i, j);
										NetMessage.SendData((int)PacketTypes.HitSwitch, -1, -1, "", i, (float)j, 0f, 0f, 0, 0, 0);
										return true;
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		public static Vector2 TileCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, int gravDir = 1)
		{
			Vector2 vector2 = new Vector2();
			Collision.up = false;
			Collision.down = false;
			Vector2 velocity = Velocity;
			Vector2 velocity1 = Velocity;
			Vector2 position = Position + Velocity;
			Vector2 position1 = Position;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			int num1 = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			float single = (float)((y1 + 3) * 16);
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].active() && !Main.tile[i, j].inActive() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type] && Main.tile[i, j].frameY == 0))
					{
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16);
						int num5 = 16;
						if (Main.tile[i, j].halfBrick())
						{
							vector2.Y = vector2.Y + 8f;
							num5 = num5 - 8;
						}
						if (position.X + (float)Width > vector2.X && position.X < vector2.X + 16f && position.Y + (float)Height > vector2.Y && position.Y < vector2.Y + (float)num5)
						{
							bool flag = false;
							bool flag1 = false;
							if (Main.tile[i, j].slope() > 2)
							{
								if (Main.tile[i, j].slope() == 3 && position1.Y + Math.Abs(Velocity.X) >= vector2.Y && position1.X >= vector2.X)
								{
									flag1 = true;
								}
								if (Main.tile[i, j].slope() == 4 && position1.Y + Math.Abs(Velocity.X) >= vector2.Y && position1.X + (float)Width <= vector2.X + 16f)
								{
									flag1 = true;
								}
							}
							else if (Main.tile[i, j].slope() > 0)
							{
								flag = true;
								if (Main.tile[i, j].slope() == 1 && position1.Y + (float)Height - Math.Abs(Velocity.X) <= vector2.Y + (float)num5 && position1.X >= vector2.X)
								{
									flag1 = true;
								}
								if (Main.tile[i, j].slope() == 2 && position1.Y + (float)Height - Math.Abs(Velocity.X) <= vector2.Y + (float)num5 && position1.X + (float)Width <= vector2.X + 16f)
								{
									flag1 = true;
								}
							}
							if (!flag1)
							{
								if (position1.Y + (float)Height <= vector2.Y)
								{
									Collision.down = true;
									if ((!Main.tileSolidTop[Main.tile[i, j].type] || !fallThrough || Velocity.Y > 1f && !fall2) && single > vector2.Y)
									{
										num3 = i;
										num4 = j;
										if (num5 < 16)
										{
											num4++;
										}
										if (num3 != num1 && !flag)
										{
											velocity.Y = vector2.Y - (position1.Y + (float)Height) + (gravDir == -1 ? -0.01f : 0f);
											single = vector2.Y;
										}
									}
								}
								else if (position1.X + (float)Width <= vector2.X && !Main.tileSolidTop[Main.tile[i, j].type])
								{
									if (Main.tile[i - 1, j] == null)
									{
										Main.tile[i - 1, j] = new Tile();
									}
									if (Main.tile[i - 1, j].slope() != 2 && Main.tile[i - 1, j].slope() != 4)
									{
										num1 = i;
										num2 = j;
										if (num2 != num4)
										{
											velocity.X = vector2.X - (position1.X + (float)Width);
										}
										if (num3 == num1)
										{
											velocity.Y = velocity1.Y;
										}
									}
								}
								else if (position1.X >= vector2.X + 16f && !Main.tileSolidTop[Main.tile[i, j].type])
								{
									if (Main.tile[i + 1, j] == null)
									{
										Main.tile[i + 1, j] = new Tile();
									}
									if (Main.tile[i + 1, j].slope() != 1 && Main.tile[i + 1, j].slope() != 3)
									{
										num1 = i;
										num2 = j;
										if (num2 != num4)
										{
											velocity.X = vector2.X + 16f - position1.X;
										}
										if (num3 == num1)
										{
											velocity.Y = velocity1.Y;
										}
									}
								}
								else if (position1.Y >= vector2.Y + (float)num5 && !Main.tileSolidTop[Main.tile[i, j].type])
								{
									Collision.up = true;
									num3 = i;
									num4 = j;
									velocity.Y = vector2.Y + (float)num5 - position1.Y + (gravDir == 1 ? 0.01f : 0f);
									if (num4 == num2)
									{
										velocity.X = velocity1.X;
									}
								}
							}
						}
					}
				}
			}
			return velocity;
		}

		public static bool TupleHitLine(int x1, int y1, int x2, int y2, int ignoreX, int ignoreY, List<Tuple<int, int>> ignoreTargets, out Tuple<int, int> col)
		{
			bool flag;
			int num = x1;
			int num1 = y1;
			int num2 = x2;
			int num3 = y2;
			num = Utils.Clamp<int>(num, 1, Main.maxTilesX - 1);
			num2 = Utils.Clamp<int>(num2, 1, Main.maxTilesX - 1);
			num1 = Utils.Clamp<int>(num1, 1, Main.maxTilesY - 1);
			num3 = Utils.Clamp<int>(num3, 1, Main.maxTilesY - 1);
			float single = (float)Math.Abs(num - num2);
			float single1 = (float)Math.Abs(num1 - num3);
			if (single == 0f && single1 == 0f)
			{
				col = new Tuple<int, int>(num, num1);
				return true;
			}
			float single2 = 1f;
			float single3 = 1f;
			if (single == 0f || single1 == 0f)
			{
				if (single == 0f)
				{
					single2 = 0f;
				}
				if (single1 == 0f)
				{
					single3 = 0f;
				}
			}
			else if (single <= single1)
			{
				single3 = single1 / single;
			}
			else
			{
				single2 = single / single1;
			}
			float single4 = 0f;
			float single5 = 0f;
			int num4 = 1;
			if (num1 < num3)
			{
				num4 = 2;
			}
			int num5 = (int)single;
			int num6 = (int)single1;
			int num7 = Math.Sign(num2 - num);
			int num8 = Math.Sign(num3 - num1);
			bool flag1 = false;
			bool flag2 = false;
			try
			{
				do
				{
					if (num4 == 2)
					{
						single4 = single4 + single2;
						int num9 = (int)single4;
						single4 = single4 % 1f;
						int num10 = 0;
						while (num10 < num9)
						{
							if (Main.tile[num, num1 - 1] == null)
							{
								col = new Tuple<int, int>(num, num1 - 1);
								flag = false;
								return flag;
							}
							else if (Main.tile[num, num1 + 1] != null)
							{
								Tile tile = Main.tile[num, num1 - 1];
								Tile tile1 = Main.tile[num, num1 + 1];
								Tile tile2 = Main.tile[num, num1];
								if (!ignoreTargets.Contains(new Tuple<int, int>(num, num1)) && !ignoreTargets.Contains(new Tuple<int, int>(num, num1 - 1)) && !ignoreTargets.Contains(new Tuple<int, int>(num, num1 + 1)))
								{
									if (ignoreY != -1 && num8 < 0 && !tile.inActive() && tile.active() && Main.tileSolid[tile.type] && !Main.tileSolidTop[tile.type])
									{
										col = new Tuple<int, int>(num, num1 - 1);
										flag = true;
										return flag;
									}
									else if (ignoreY != 1 && num8 > 0 && !tile1.inActive() && tile1.active() && Main.tileSolid[tile1.type] && !Main.tileSolidTop[tile1.type])
									{
										col = new Tuple<int, int>(num, num1 + 1);
										flag = true;
										return flag;
									}
									else if (!tile2.inActive() && tile2.active() && Main.tileSolid[tile2.type] && !Main.tileSolidTop[tile2.type])
									{
										col = new Tuple<int, int>(num, num1);
										flag = true;
										return flag;
									}
								}
								if (num5 != 0 || num6 != 0)
								{
									num = num + num7;
									num5--;
									if (num5 == 0 && num6 == 0 && num9 == 1)
									{
										flag2 = true;
									}
									num10++;
								}
								else
								{
									flag1 = true;
									break;
								}
							}
							else
							{
								col = new Tuple<int, int>(num, num1 + 1);
								flag = false;
								return flag;
							}
						}
						if (num6 != 0)
						{
							num4 = 1;
						}
					}
					else if (num4 == 1)
					{
						single5 = single5 + single3;
						int num11 = (int)single5;
						single5 = single5 % 1f;
						int num12 = 0;
						while (num12 < num11)
						{
							if (Main.tile[num - 1, num1] == null)
							{
								col = new Tuple<int, int>(num - 1, num1);
								flag = false;
								return flag;
							}
							else if (Main.tile[num + 1, num1] != null)
							{
								Tile tile3 = Main.tile[num - 1, num1];
								Tile tile4 = Main.tile[num + 1, num1];
								Tile tile5 = Main.tile[num, num1];
								if (!ignoreTargets.Contains(new Tuple<int, int>(num, num1)) && !ignoreTargets.Contains(new Tuple<int, int>(num - 1, num1)) && !ignoreTargets.Contains(new Tuple<int, int>(num + 1, num1)))
								{
									if (ignoreX != -1 && num7 < 0 && !tile3.inActive() && tile3.active() && Main.tileSolid[tile3.type] && !Main.tileSolidTop[tile3.type])
									{
										col = new Tuple<int, int>(num - 1, num1);
										flag = true;
										return flag;
									}
									else if (ignoreX != 1 && num7 > 0 && !tile4.inActive() && tile4.active() && Main.tileSolid[tile4.type] && !Main.tileSolidTop[tile4.type])
									{
										col = new Tuple<int, int>(num + 1, num1);
										flag = true;
										return flag;
									}
									else if (!tile5.inActive() && tile5.active() && Main.tileSolid[tile5.type] && !Main.tileSolidTop[tile5.type])
									{
										col = new Tuple<int, int>(num, num1);
										flag = true;
										return flag;
									}
								}
								if (num5 != 0 || num6 != 0)
								{
									num1 = num1 + num8;
									num6--;
									if (num5 == 0 && num6 == 0 && num11 == 1)
									{
										flag2 = true;
									}
									num12++;
								}
								else
								{
									flag1 = true;
									break;
								}
							}
							else
							{
								col = new Tuple<int, int>(num + 1, num1);
								flag = false;
								return flag;
							}
						}
						if (num5 != 0)
						{
							num4 = 2;
						}
					}
					if (Main.tile[num, num1] != null)
					{
						Tile tile6 = Main.tile[num, num1];
						if (ignoreTargets.Contains(new Tuple<int, int>(num, num1)) || tile6.inActive() || !tile6.active() || !Main.tileSolid[tile6.type] || Main.tileSolidTop[tile6.type])
						{
							continue;
						}
						col = new Tuple<int, int>(num, num1);
						flag = true;
						return flag;
					}
					else
					{
						col = new Tuple<int, int>(num, num1);
						flag = false;
						return flag;
					}
				}
				while (!flag1 && !flag2);
				col = new Tuple<int, int>(num, num1);
				flag = true;
			}
			catch
			{
				col = new Tuple<int, int>(x1, y1);
				flag = false;
			}
			return flag;
		}

		public static Tuple<int, int> TupleHitLineWall(int x1, int y1, int x2, int y2)
		{
			Tuple<int, int> tuple;
			int num = x1;
			int num1 = y1;
			int num2 = x2;
			int num3 = y2;
			if (num <= 1)
			{
				num = 1;
			}
			if (num >= Main.maxTilesX)
			{
				num = Main.maxTilesX - 1;
			}
			if (num2 <= 1)
			{
				num2 = 1;
			}
			if (num2 >= Main.maxTilesX)
			{
				num2 = Main.maxTilesX - 1;
			}
			if (num1 <= 1)
			{
				num1 = 1;
			}
			if (num1 >= Main.maxTilesY)
			{
				num1 = Main.maxTilesY - 1;
			}
			if (num3 <= 1)
			{
				num3 = 1;
			}
			if (num3 >= Main.maxTilesY)
			{
				num3 = Main.maxTilesY - 1;
			}
			float single = (float)Math.Abs(num - num2);
			float single1 = (float)Math.Abs(num1 - num3);
			if (single == 0f && single1 == 0f)
			{
				return new Tuple<int, int>(num, num1);
			}
			float single2 = 1f;
			float single3 = 1f;
			if (single == 0f || single1 == 0f)
			{
				if (single == 0f)
				{
					single2 = 0f;
				}
				if (single1 == 0f)
				{
					single3 = 0f;
				}
			}
			else if (single <= single1)
			{
				single3 = single1 / single;
			}
			else
			{
				single2 = single / single1;
			}
			float single4 = 0f;
			float single5 = 0f;
			int num4 = 1;
			if (num1 < num3)
			{
				num4 = 2;
			}
			int num5 = (int)single;
			int num6 = (int)single1;
			int num7 = Math.Sign(num2 - num);
			int num8 = Math.Sign(num3 - num1);
			bool flag = false;
			bool flag1 = false;
			try
			{
				do
				{
					if (num4 == 2)
					{
						single4 = single4 + single2;
						int num9 = (int)single4;
						single4 = single4 % 1f;
						int num10 = 0;
						while (num10 < num9)
						{
							Tile tile = Main.tile[num, num1];
							if (Collision.HitWallSubstep(num, num1))
							{
								tuple = new Tuple<int, int>(num, num1);
								return tuple;
							}
							else if (num5 != 0 || num6 != 0)
							{
								num = num + num7;
								num5--;
								if (num5 == 0 && num6 == 0 && num9 == 1)
								{
									flag1 = true;
								}
								num10++;
							}
							else
							{
								flag = true;
								break;
							}
						}
						if (num6 != 0)
						{
							num4 = 1;
						}
					}
					else if (num4 == 1)
					{
						single5 = single5 + single3;
						int num11 = (int)single5;
						single5 = single5 % 1f;
						int num12 = 0;
						while (num12 < num11)
						{
							Tile tile1 = Main.tile[num, num1];
							if (Collision.HitWallSubstep(num, num1))
							{
								tuple = new Tuple<int, int>(num, num1);
								return tuple;
							}
							else if (num5 != 0 || num6 != 0)
							{
								num1 = num1 + num8;
								num6--;
								if (num5 == 0 && num6 == 0 && num11 == 1)
								{
									flag1 = true;
								}
								num12++;
							}
							else
							{
								flag = true;
								break;
							}
						}
						if (num5 != 0)
						{
							num4 = 2;
						}
					}
					if (Main.tile[num, num1] != null)
					{
						Tile tile2 = Main.tile[num, num1];
						if (!Collision.HitWallSubstep(num, num1))
						{
							continue;
						}
						tuple = new Tuple<int, int>(num, num1);
						return tuple;
					}
					else
					{
						tuple = new Tuple<int, int>(-1, -1);
						return tuple;
					}
				}
				while (!flag && !flag1);
				tuple = new Tuple<int, int>(num, num1);
			}
			catch
			{
				tuple = new Tuple<int, int>(-1, -1);
			}
			return tuple;
		}

		public static Vector4 WalkDownSlope(Vector2 Position, Vector2 Velocity, int Width, int Height, float gravity = 0f)
		{
			float x;
			Vector2 vector2 = new Vector2();
			if (Velocity.Y != gravity)
			{
				return new Vector4(Position, Velocity.X, Velocity.Y);
			}
			Vector2 position = Position;
			int num = (int)(position.X / 16f);
			int x1 = (int)((position.X + (float)Width) / 16f);
			int y = (int)((Position.Y + (float)Height + 4f) / 16f);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			x1 = Utils.Clamp<int>(x1, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 3);
			float single = (float)((y + 3) * 16);
			int num1 = -1;
			int num2 = -1;
			int num3 = 1;
			if (Velocity.X < 0f)
			{
				num3 = 2;
			}
			for (int i = num; i <= x1; i++)
			{
				for (int j = y; j <= y + 1; j++)
				{
					if (Main.tile[i, j] == null)
					{
						Main.tile[i, j] = new Tile();
					}
					if (Main.tile[i, j].nactive() && (Main.tileSolid[Main.tile[i, j].type] || Main.tileSolidTop[Main.tile[i, j].type]))
					{
						int num4 = j * 16;
						if (Main.tile[i, j].halfBrick())
						{
							num4 = num4 + 8;
						}
						Rectangle rectangle = new Rectangle(i * 16, j * 16 - 17, 16, 16);
						if (rectangle.Intersects(new Rectangle((int)Position.X, (int)Position.Y, Width, Height)) && (float)num4 <= single)
						{
							if (single != (float)num4)
							{
								single = (float)num4;
								num1 = i;
								num2 = j;
							}
							else if (Main.tile[i, j].slope() != 0)
							{
								if (num1 == -1 || num2 == -1 || Main.tile[num1, num2] == null || Main.tile[num1, num2].slope() == 0)
								{
									single = (float)num4;
									num1 = i;
									num2 = j;
								}
								else if (Main.tile[i, j].slope() == num3)
								{
									single = (float)num4;
									num1 = i;
									num2 = j;
								}
							}
						}
					}
				}
			}
			int num5 = num1;
			int num6 = num2;
			if (num1 != -1 && num2 != -1 && Main.tile[num5, num6] != null && Main.tile[num5, num6].slope() > 0)
			{
				int num7 = Main.tile[num5, num6].slope();
				vector2.X = (float)(num5 * 16);
				vector2.Y = (float)(num6 * 16);
				if (num7 == 2)
				{
					x = vector2.X + 16f - (Position.X + (float)Width);
					if (Position.Y + (float)Height >= vector2.Y + x && Velocity.X < 0f)
					{
						Velocity.Y = Velocity.Y + Math.Abs(Velocity.X);
					}
				}
				else if (num7 == 1)
				{
					x = Position.X - vector2.X;
					if (Position.Y + (float)Height >= vector2.Y + x && Velocity.X > 0f)
					{
						Velocity.Y = Velocity.Y + Math.Abs(Velocity.X);
					}
				}
			}
			return new Vector4(Position, Velocity.X, Velocity.Y);
		}

		public static Vector2 WaterCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, bool lavaWalk = true)
		{
			Vector2 vector2 = new Vector2();
			Vector2 velocity = Velocity;
			Vector2 position = Position + Velocity;
			Vector2 position1 = Position;
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j - 1].liquid == 0 && (!Main.tile[i, j].lava() || lavaWalk))
					{
						int num1 = Main.tile[i, j].liquid / 32 * 2 + 2;
						vector2.X = (float)(i * 16);
						vector2.Y = (float)(j * 16 + 16 - num1);
						if (position.X + (float)Width > vector2.X && position.X < vector2.X + 16f && position.Y + (float)Height > vector2.Y && position.Y < vector2.Y + (float)num1 && position1.Y + (float)Height <= vector2.Y && !fallThrough)
						{
							velocity.Y = vector2.Y - (position1.Y + (float)Height);
						}
					}
				}
			}
			return velocity;
		}

		public static bool WetCollision(Vector2 Position, int Width, int Height)
		{
			Vector2 vector2 = new Vector2();
			Collision.honey = false;
			Vector2 vector21 = new Vector2(Position.X + (float)(Width / 2), Position.Y + (float)(Height / 2));
			int width = 10;
			int height = Height / 2;
			if (width > Width)
			{
				width = Width;
			}
			if (height > Height)
			{
				height = Height;
			}
			vector21 = new Vector2(vector21.X - (float)(width / 2), vector21.Y - (float)(height / 2));
			int x = (int)(Position.X / 16f) - 1;
			int num = (int)((Position.X + (float)Width) / 16f) + 2;
			int y = (int)(Position.Y / 16f) - 1;
			int y1 = (int)((Position.Y + (float)Height) / 16f) + 2;
			x = Utils.Clamp<int>(x, 0, Main.maxTilesX - 1);
			num = Utils.Clamp<int>(num, 0, Main.maxTilesX - 1);
			y = Utils.Clamp<int>(y, 0, Main.maxTilesY - 1);
			y1 = Utils.Clamp<int>(y1, 0, Main.maxTilesY - 1);
			for (int i = x; i < num; i++)
			{
				for (int j = y; j < y1; j++)
				{
					if (Main.tile[i, j] != null)
					{
						if (Main.tile[i, j].liquid > 0)
						{
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							int num1 = 16;
							float single = (float)(256 - Main.tile[i, j].liquid);
							single = single / 32f;
							vector2.Y = vector2.Y + single * 2f;
							num1 = num1 - (int)(single * 2f);
							if (vector21.X + (float)width > vector2.X && vector21.X < vector2.X + 16f && vector21.Y + (float)height > vector2.Y && vector21.Y < vector2.Y + (float)num1)
							{
								if (Main.tile[i, j].honey())
								{
									Collision.honey = true;
								}
								return true;
							}
						}
						else if (Main.tile[i, j].active() && Main.tile[i, j].slope() != 0 && j > 0 && Main.tile[i, j - 1] != null && Main.tile[i, j - 1].liquid > 0)
						{
							vector2.X = (float)(i * 16);
							vector2.Y = (float)(j * 16);
							int num2 = 16;
							if (vector21.X + (float)width > vector2.X && vector21.X < vector2.X + 16f && vector21.Y + (float)height > vector2.Y && vector21.Y < vector2.Y + (float)num2)
							{
								if (Main.tile[i, j - 1].honey())
								{
									Collision.honey = true;
								}
								return true;
							}
						}
					}
				}
			}
			return false;
		}
	}
}
