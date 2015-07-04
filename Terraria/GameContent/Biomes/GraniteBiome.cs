
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class GraniteBiome : MicroBiome
	{
		private const int MAX_MAGMA_ITERATIONS = 300;

		private static GraniteBiome.Magma[,] _sourceMagmaMap;

		private static GraniteBiome.Magma[,] _targetMagmaMap;

		static GraniteBiome()
		{
			GraniteBiome._sourceMagmaMap = new GraniteBiome.Magma[200, 200];
			GraniteBiome._targetMagmaMap = new GraniteBiome.Magma[200, 200];
		}

		public GraniteBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			if (GenBase._tiles[origin.X, origin.Y].active())
			{
				return false;
			}
			int length = GraniteBiome._sourceMagmaMap.GetLength(0);
			int num = GraniteBiome._sourceMagmaMap.GetLength(1);
			int num1 = length / 2;
			int num2 = num / 2;
			origin.X = origin.X - num1;
			origin.Y = origin.Y - num2;
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < num; j++)
				{
					GraniteBiome._sourceMagmaMap[i, j] = GraniteBiome.Magma.CreateEmpty((WorldGen.SolidTile(i + origin.X, j + origin.Y) ? 4f : 1f));
					GraniteBiome._targetMagmaMap[i, j] = GraniteBiome._sourceMagmaMap[i, j];
				}
			}
			int num3 = num1;
			int num4 = num1;
			int num5 = num2;
			int num6 = num2;
			for (int k = 0; k < 300; k++)
			{
				for (int l = num3; l <= num4; l++)
				{
					for (int m = num5; m <= num6; m++)
					{
						GraniteBiome.Magma magma = GraniteBiome._sourceMagmaMap[l, m];
						if (magma.IsActive)
						{
							float single = 0f;
							Vector2 zero = Vector2.Zero;
							for (int n = -1; n <= 1; n++)
							{
								for (int o = -1; o <= 1; o++)
								{
									if (n != 0 || o != 0)
									{
										Vector2 vector2 = new Vector2((float)n, (float)o);
										vector2.Normalize();
										GraniteBiome.Magma magma1 = GraniteBiome._sourceMagmaMap[l + n, m + o];
										if (magma.Pressure > 0.01f && !magma1.IsActive)
										{
											if (n != -1)
											{
												num4 = Utils.Clamp<int>(l + n, num4, length - 2);
											}
											else
											{
												num3 = Utils.Clamp<int>(l + n, 1, num3);
											}
											if (o != -1)
											{
												num6 = Utils.Clamp<int>(m + o, num6, num - 2);
											}
											else
											{
												num5 = Utils.Clamp<int>(m + o, 1, num5);
											}
											GraniteBiome._targetMagmaMap[l + n, m + o] = magma1.ToFlow();
										}
										float pressure = magma1.Pressure;
										single = single + pressure;
										zero = zero + (pressure * vector2);
									}
								}
							}
							single = single / 8f;
							if (single > magma.Resistance)
							{
								float single1 = zero.Length() / 8f;
								float single2 = Math.Max(single - single1 - magma.Pressure, 0f) + single1 + magma.Pressure * 0.875f - magma.Resistance;
								single2 = Math.Max(0f, single2);
								GraniteBiome._targetMagmaMap[l, m] = GraniteBiome.Magma.CreateFlow(single2, Math.Max(0f, magma.Resistance - single2 * 0.02f));
							}
						}
					}
				}
				if (k < 2)
				{
					GraniteBiome._targetMagmaMap[num1, num2] = GraniteBiome.Magma.CreateFlow(25f, 0f);
				}
				Utils.Swap<GraniteBiome.Magma[,]>(ref GraniteBiome._sourceMagmaMap, ref GraniteBiome._targetMagmaMap);
			}
			bool y = origin.Y + num2 > WorldGen.lavaLine - 30;
			bool flag = false;
			for (int p = -50; p < 50 && !flag; p++)
			{
				for (int q = -50; q < 50 && !flag; q++)
				{
					if (GenBase._tiles[origin.X + num1 + p, origin.Y + num2 + q].active())
					{
						ushort num7 = GenBase._tiles[origin.X + num1 + p, origin.Y + num2 + q].type;
						if (num7 != 147)
						{
							switch (num7)
							{
								case 161:
								case 162:
								case 163:
									{
										break;
									}
								default:
									{
										if (num7 != 200)
										{
											continue;
										}
										else
										{
											break;
										}
									}
							}
						}
						y = false;
						flag = true;
					}
				}
			}
			for (int r = num3; r <= num4; r++)
			{
				for (int s = num5; s <= num6; s++)
				{
					GraniteBiome.Magma magma2 = GraniteBiome._sourceMagmaMap[r, s];
					if (magma2.IsActive)
					{
						Tile tile = GenBase._tiles[origin.X + r, origin.Y + s];
						float single3 = (float)Math.Sin((double)((float)(origin.Y + s) * 0.4f)) * 0.7f + 1.2f;
						float single4 = 0.2f + 0.5f / (float)Math.Sqrt((double)Math.Max(0f, magma2.Pressure - magma2.Resistance));
						float single5 = 1f - Math.Max(0f, single3 * single4);
						single5 = Math.Max(single5, magma2.Pressure / 15f);
						if (single5 > 0.35f + (WorldGen.SolidTile(origin.X + r, origin.Y + s) ? 0f : 0.5f))
						{
							if (!TileID.Sets.Ore[tile.type])
							{
								tile.ResetToType(368);
							}
							else
							{
								tile.ResetToType(tile.type);
							}
							tile.wall = 180;
						}
						else if (magma2.Resistance < 0.01f)
						{
							WorldUtils.ClearTile(origin.X + r, origin.Y + s, false);
							tile.wall = 180;
						}
						if (tile.liquid > 0 && y)
						{
							tile.liquidType(1);
						}
					}
				}
			}
			List<Point16> point16s = new List<Point16>();
			for (int t = num3; t <= num4; t++)
			{
				for (int u = num5; u <= num6; u++)
				{
					if (GraniteBiome._sourceMagmaMap[t, u].IsActive)
					{
						int num8 = 0;
						int x = t + origin.X;
						int y1 = u + origin.Y;
						if (WorldGen.SolidTile(x, y1))
						{
							for (int v = -1; v <= 1; v++)
							{
								for (int w = -1; w <= 1; w++)
								{
									if (WorldGen.SolidTile(x + v, y1 + w))
									{
										num8++;
									}
								}
							}
							if (num8 < 3)
							{
								point16s.Add(new Point16(x, y1));
							}
						}
					}
				}
			}
			foreach (Point16 point16 in point16s)
			{
				int x1 = point16.X;
				int y2 = point16.Y;
				WorldUtils.ClearTile(x1, y2, true);
				GenBase._tiles[x1, y2].wall = 180;
			}
			point16s.Clear();
			for (int x2 = num3; x2 <= num4; x2++)
			{
				for (int y3 = num5; y3 <= num6; y3++)
				{
					GraniteBiome.Magma magma3 = GraniteBiome._sourceMagmaMap[x2, y3];
					int x3 = x2 + origin.X;
					int y4 = y3 + origin.Y;
					if (magma3.IsActive)
					{
						WorldUtils.TileFrame(x3, y4, false);
						WorldGen.SquareWallFrame(x3, y4, true);
						if (GenBase._random.Next(8) == 0 && GenBase._tiles[x3, y4].active())
						{
							if (!GenBase._tiles[x3, y4 + 1].active())
							{
								WorldGen.PlaceTight(x3, y4 + 1, 165, false);
							}
							if (!GenBase._tiles[x3, y4 - 1].active())
							{
								WorldGen.PlaceTight(x3, y4 - 1, 165, false);
							}
						}
						if (GenBase._random.Next(2) == 0)
						{
							Tile.SmoothSlope(x3, y4, true);
						}
					}
				}
			}
			return true;
		}

		private struct Magma
		{
			public readonly float Pressure;

			public readonly float Resistance;

			public readonly bool IsActive;

			private Magma(float pressure, float resistance, bool active)
			{
				this.Pressure = pressure;
				this.Resistance = resistance;
				this.IsActive = active;
			}

			public static GraniteBiome.Magma CreateEmpty(float resistance = 0f)
			{
				return new GraniteBiome.Magma(0f, resistance, false);
			}

			public static GraniteBiome.Magma CreateFlow(float pressure, float resistance = 0f)
			{
				return new GraniteBiome.Magma(pressure, resistance, true);
			}

			public GraniteBiome.Magma ToFlow()
			{
				return new GraniteBiome.Magma(this.Pressure, this.Resistance, true);
			}
		}
	}
}