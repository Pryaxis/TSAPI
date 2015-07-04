
using System;
using Terraria;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class MarbleBiome : MicroBiome
	{
		private const int SCALE = 3;

		private MarbleBiome.Slab[,] _slabs;

		public MarbleBiome()
		{
		}

		private bool IsGroupSolid(int x, int y, int scale)
		{
			int num = 0;
			for (int i = 0; i < scale; i++)
			{
				for (int j = 0; j < scale; j++)
				{
					if (WorldGen.SolidOrSlopedTile(x + i, y + j))
					{
						num++;
					}
				}
			}
			return num > scale / 4 * 3;
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			MarbleBiome.SlabState slabState;
			bool flag;
			if (this._slabs == null)
			{
				this._slabs = new MarbleBiome.Slab[56, 26];
			}
			int num = GenBase._random.Next(80, 150) / 3;
			int num1 = GenBase._random.Next(40, 60) / 3;
			int num2 = (num1 * 3 - GenBase._random.Next(20, 30)) / 3;
			origin.X = origin.X - num * 3 / 2;
			origin.Y = origin.Y - num1 * 3 / 2;
			for (int i = -1; i < num + 1; i++)
			{
				float single = (float)(i - num / 2) / (float)num + 0.5f;
				int num3 = (int)((0.5f - Math.Abs(single - 0.5f)) * 5f) - 2;
				for (int j = -1; j < num1 + 1; j++)
				{
					bool flag1 = true;
					bool flag2 = false;
					bool flag3 = this.IsGroupSolid(i * 3 + origin.X, j * 3 + origin.Y, 3);
					int num4 = Math.Abs(j - num1 / 2);
					int num5 = num4 - num2 / 4 + num3;
					if (num5 > 3)
					{
						flag2 = flag3;
						flag1 = false;
					}
					else if (num5 > 0)
					{
						flag2 = (j - num1 / 2 > 0 ? true : flag3);
						flag1 = (j - num1 / 2 < 0 ? true : num5 <= 2);
					}
					else if (num5 == 0)
					{
						if (GenBase._random.Next(2) != 0)
						{
							flag = false;
						}
						else
						{
							flag = (j - num1 / 2 > 0 ? true : flag3);
						}
						flag2 = flag;
					}
					if (Math.Abs(single - 0.5f) > 0.35f + GenBase._random.NextFloat() * 0.1f && !flag3)
					{
						flag1 = false;
						flag2 = false;
					}
					slabState = (flag2 ? new MarbleBiome.SlabState(MarbleBiome.SlabStates.Solid) : new MarbleBiome.SlabState(MarbleBiome.SlabStates.Empty));
					this._slabs[i + 1, j + 1] = MarbleBiome.Slab.Create(slabState, flag1);
				}
			}
			for (int k = 0; k < num; k++)
			{
				for (int l = 0; l < num1; l++)
				{
					this.SmoothSlope(k + 1, l + 1);
				}
			}
			int num6 = num / 2;
			int num7 = num1 / 2;
			int num8 = (num7 + 1) * (num7 + 1);
			float single1 = GenBase._random.NextFloat() * 2f - 1f;
			float single2 = GenBase._random.NextFloat() * 2f - 1f;
			float single3 = GenBase._random.NextFloat() * 2f - 1f;
			float single4 = 0f;
			for (int m = 0; m <= num; m++)
			{
				float single5 = (float)num7 / (float)num6 * (float)(m - num6);
				int num9 = Math.Min(num7, (int)Math.Sqrt((double)Math.Max(0f, (float)num8 - single5 * single5)));
				single4 = (m >= num / 2 ? single4 + MathHelper.Lerp(single2, single3, (float)m / (float)(num / 2) - 1f) : single4 + MathHelper.Lerp(single1, single2, (float)m / (float)(num / 2)));
				for (int n = num7 - num9; n <= num7 + num9; n++)
				{
					this.PlaceSlab(this._slabs[m + 1, n + 1], m * 3 + origin.X, n * 3 + origin.Y + (int)single4, 3);
				}
			}
			return true;
		}

		private void PlaceSlab(MarbleBiome.Slab slab, int originX, int originY, int scale)
		{
			for (int i = 0; i < scale; i++)
			{
				for (int j = 0; j < scale; j++)
				{
					Tile tile = GenBase._tiles[originX + i, originY + j];
					if (!TileID.Sets.Ore[tile.type])
					{
						tile.ResetToType(367);
					}
					else
					{
						tile.ResetToType(tile.type);
					}
					tile.active(slab.State(i, j, scale));
					if (slab.HasWall)
					{
						tile.wall = 178;
					}
					WorldUtils.TileFrame(originX + i, originY + j, true);
					WorldGen.SquareWallFrame(originX + i, originY + j, true);
					Tile.SmoothSlope(originX + i, originY + j, true);
					if (WorldGen.SolidTile(originX + i, originY + j - 1) && GenBase._random.Next(4) == 0)
					{
						WorldGen.PlaceTight(originX + i, originY + j, 165, false);
					}
					if (WorldGen.SolidTile(originX + i, originY + j) && GenBase._random.Next(4) == 0)
					{
						WorldGen.PlaceTight(originX + i, originY + j - 1, 165, false);
					}
				}
			}
		}

		private void SmoothSlope(int x, int y)
		{
			MarbleBiome.Slab slab = this._slabs[x, y];
			if (!slab.IsSolid)
			{
				return;
			}
			bool isSolid = this._slabs[x, y - 1].IsSolid;
			bool flag = this._slabs[x, y + 1].IsSolid;
			bool isSolid1 = this._slabs[x - 1, y].IsSolid;
			bool flag1 = this._slabs[x + 1, y].IsSolid;
			switch ((isSolid ? 1 : 0) << 3 | (flag ? 1 : 0) << 2 | (isSolid1 ? 1 : 0) << 1 | (flag1 ? 1 : 0))
			{
				case 4:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.HalfBrick));
					return;
				}
				case 5:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.BottomRightFilled));
					return;
				}
				case 6:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.BottomLeftFilled));
					return;
				}
				case 7:
				case 8:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.Solid));
					return;
				}
				case 9:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.TopRightFilled));
					return;
				}
				case 10:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.TopLeftFilled));
					return;
				}
				default:
				{
					this._slabs[x, y] = slab.WithState(new MarbleBiome.SlabState(MarbleBiome.SlabStates.Solid));
					return;
				}
			}
		}

		private struct Slab
		{
			public readonly MarbleBiome.SlabState State;

			public readonly bool HasWall;

			public bool IsSolid
			{
				get
				{
					return this.State != new MarbleBiome.SlabState(MarbleBiome.SlabStates.Empty);
				}
			}

			private Slab(MarbleBiome.SlabState state, bool hasWall)
			{
				this.State = state;
				this.HasWall = hasWall;
			}

			public static MarbleBiome.Slab Create(MarbleBiome.SlabState state, bool hasWall)
			{
				return new MarbleBiome.Slab(state, hasWall);
			}

			public MarbleBiome.Slab WithState(MarbleBiome.SlabState state)
			{
				return new MarbleBiome.Slab(state, this.HasWall);
			}
		}

		private delegate bool SlabState(int x, int y, int scale);

		private class SlabStates
		{
			public SlabStates()
			{
			}

			public static bool BottomLeftFilled(int x, int y, int scale)
			{
				return x < y;
			}

			public static bool BottomRightFilled(int x, int y, int scale)
			{
				return x >= scale - y;
			}

			public static bool Empty(int x, int y, int scale)
			{
				return false;
			}

			public static bool HalfBrick(int x, int y, int scale)
			{
				return y >= scale / 2;
			}

			public static bool Solid(int x, int y, int scale)
			{
				return true;
			}

			public static bool TopLeftFilled(int x, int y, int scale)
			{
				return x < scale - y;
			}

			public static bool TopRightFilled(int x, int y, int scale)
			{
				return x > y;
			}
		}
	}
}