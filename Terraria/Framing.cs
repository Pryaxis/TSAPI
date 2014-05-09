using System;
using Terraria.DataStructures;
namespace Terraria
{
	public class Framing
	{
		private struct BlockStyle
		{
			public bool top;
			public bool bottom;
			public bool left;
			public bool right;
			public BlockStyle(bool up, bool down, bool left, bool right)
			{
				this.top = up;
				this.bottom = down;
				this.left = left;
				this.right = right;
			}
			public void Clear()
			{
				this.top = (this.bottom = (this.left = (this.right = false)));
			}
		}
		private static Point16[][] selfFrame8WayLookup;
		private static Point16[][] wallFrameLookup;
		private static Point16 frameSize8Way;
		private static Point16 wallFrameSize;
		private static Framing.BlockStyle[] blockStyleLookup;
		private static int[][] largeTileFrameNumberLookup;
		private static int[][] centerWallFrameLookup;
		public static void Initialize()
		{
			Framing.selfFrame8WayLookup = new Point16[256][];
			Framing.frameSize8Way = new Point16(18, 18);
			Framing.Add8WayLookup(0, 9, 3, 10, 3, 11, 3);
			Framing.Add8WayLookup(1, 6, 3, 7, 3, 8, 3);
			Framing.Add8WayLookup(2, 12, 0, 12, 1, 12, 2);
			Framing.Add8WayLookup(3, 15, 2);
			Framing.Add8WayLookup(4, 9, 0, 9, 1, 9, 2);
			Framing.Add8WayLookup(5, 13, 2);
			Framing.Add8WayLookup(6, 6, 4, 7, 4, 8, 4);
			Framing.Add8WayLookup(7, 14, 2);
			Framing.Add8WayLookup(8, 6, 0, 7, 0, 8, 0);
			Framing.Add8WayLookup(9, 5, 0, 5, 1, 5, 2);
			Framing.Add8WayLookup(10, 15, 0);
			Framing.Add8WayLookup(11, 15, 1);
			Framing.Add8WayLookup(12, 13, 0);
			Framing.Add8WayLookup(13, 13, 1);
			Framing.Add8WayLookup(14, 14, 0);
			Framing.Add8WayLookup(15, 14, 1);
			Framing.Add8WayLookup(19, 1, 4, 3, 4, 5, 4);
			Framing.Add8WayLookup(23, 16, 3);
			Framing.Add8WayLookup(27, 17, 0);
			Framing.Add8WayLookup(31, 13, 4);
			Framing.Add8WayLookup(37, 0, 4, 2, 4, 4, 4);
			Framing.Add8WayLookup(39, 17, 3);
			Framing.Add8WayLookup(45, 16, 0);
			Framing.Add8WayLookup(47, 12, 4);
			Framing.Add8WayLookup(55, 1, 2, 2, 2, 3, 2);
			Framing.Add8WayLookup(63, 6, 2, 7, 2, 8, 2);
			Framing.Add8WayLookup(74, 1, 3, 3, 3, 5, 3);
			Framing.Add8WayLookup(75, 17, 1);
			Framing.Add8WayLookup(78, 16, 2);
			Framing.Add8WayLookup(79, 13, 3);
			Framing.Add8WayLookup(91, 4, 0, 4, 1, 4, 2);
			Framing.Add8WayLookup(95, 11, 0, 11, 1, 11, 2);
			Framing.Add8WayLookup(111, 17, 4);
			Framing.Add8WayLookup(127, 14, 3);
			Framing.Add8WayLookup(140, 0, 3, 2, 3, 4, 3);
			Framing.Add8WayLookup(141, 16, 1);
			Framing.Add8WayLookup(142, 17, 2);
			Framing.Add8WayLookup(143, 12, 3);
			Framing.Add8WayLookup(159, 16, 4);
			Framing.Add8WayLookup(173, 0, 0, 0, 1, 0, 2);
			Framing.Add8WayLookup(175, 10, 0, 10, 1, 10, 2);
			Framing.Add8WayLookup(191, 15, 3);
			Framing.Add8WayLookup(206, 1, 0, 2, 0, 3, 0);
			Framing.Add8WayLookup(207, 6, 1, 7, 1, 8, 1);
			Framing.Add8WayLookup(223, 14, 4);
			Framing.Add8WayLookup(239, 15, 4);
			Framing.Add8WayLookup(255, 1, 1, 2, 1, 3, 1);
			Framing.blockStyleLookup = new Framing.BlockStyle[6];
			Framing.blockStyleLookup[0] = new Framing.BlockStyle(true, true, true, true);
			Framing.blockStyleLookup[1] = new Framing.BlockStyle(false, true, true, true);
			Framing.blockStyleLookup[2] = new Framing.BlockStyle(false, true, true, false);
			Framing.blockStyleLookup[3] = new Framing.BlockStyle(false, true, false, true);
			Framing.blockStyleLookup[4] = new Framing.BlockStyle(true, false, true, false);
			Framing.blockStyleLookup[5] = new Framing.BlockStyle(true, false, false, true);
			Framing.largeTileFrameNumberLookup = new int[][]
			{
				new int[]
				{
					2,
					4,
					2
				},
				new int[]
				{
					1,
					3,
					1
				},
				new int[]
				{
					2,
					2,
					4
				},
				new int[]
				{
					1,
					1,
					3
				}
			};
			int[][] array = new int[3][];
			int[][] arg_36F_0 = array;
			int arg_36F_1 = 0;
			int[] array2 = new int[3];
			array2[0] = 2;
			arg_36F_0[arg_36F_1] = array2;
			array[1] = new int[]
			{
				0,
				1,
				4
			};
			int[][] arg_394_0 = array;
			int arg_394_1 = 2;
			int[] array3 = new int[3];
			array3[1] = 3;
			arg_394_0[arg_394_1] = array3;
			Framing.centerWallFrameLookup = array;
			Framing.wallFrameLookup = new Point16[20][];
			Framing.wallFrameSize = new Point16(36, 36);
			Framing.AddWallFrameLookup(0, 9, 3, 10, 3, 11, 3, 6, 6);
			Framing.AddWallFrameLookup(1, 6, 3, 7, 3, 8, 3, 4, 6);
			Framing.AddWallFrameLookup(2, 12, 0, 12, 1, 12, 2, 12, 5);
			Framing.AddWallFrameLookup(3, 1, 4, 3, 4, 5, 4, 3, 6);
			Framing.AddWallFrameLookup(4, 9, 0, 9, 1, 9, 2, 9, 5);
			Framing.AddWallFrameLookup(5, 0, 4, 2, 4, 4, 4, 0, 6);
			Framing.AddWallFrameLookup(6, 6, 4, 7, 4, 8, 4, 5, 6);
			Framing.AddWallFrameLookup(7, 1, 2, 2, 2, 3, 2, 3, 5);
			Framing.AddWallFrameLookup(8, 6, 0, 7, 0, 8, 0, 6, 5);
			Framing.AddWallFrameLookup(9, 5, 0, 5, 1, 5, 2, 5, 5);
			Framing.AddWallFrameLookup(10, 1, 3, 3, 3, 5, 3, 1, 6);
			Framing.AddWallFrameLookup(11, 4, 0, 4, 1, 4, 2, 4, 5);
			Framing.AddWallFrameLookup(12, 0, 3, 2, 3, 4, 3, 0, 6);
			Framing.AddWallFrameLookup(13, 0, 0, 0, 1, 0, 2, 0, 5);
			Framing.AddWallFrameLookup(14, 1, 0, 2, 0, 3, 0, 1, 6);
			Framing.AddWallFrameLookup(15, 1, 1, 2, 1, 3, 1, 2, 5);
			Framing.AddWallFrameLookup(16, 6, 1, 7, 1, 8, 1, 7, 5);
			Framing.AddWallFrameLookup(17, 6, 2, 7, 2, 8, 2, 8, 5);
			Framing.AddWallFrameLookup(18, 10, 0, 10, 1, 10, 2, 10, 5);
			Framing.AddWallFrameLookup(19, 11, 0, 11, 1, 11, 2, 11, 5);
		}
		private static Framing.BlockStyle FindBlockStyle(Tile blockTile)
		{
			return Framing.blockStyleLookup[blockTile.blockType()];
		}
		public static void Add8WayLookup(int lookup, short point1X, short point1Y, short point2X, short point2Y, short point3X, short point3Y)
		{
			Point16[] array = new Point16[]
			{
				new Point16((int)(point1X * Framing.frameSize8Way.x), (int)(point1Y * Framing.frameSize8Way.y)),
				new Point16((int)(point2X * Framing.frameSize8Way.x), (int)(point2Y * Framing.frameSize8Way.y)),
				new Point16((int)(point3X * Framing.frameSize8Way.x), (int)(point3Y * Framing.frameSize8Way.y))
			};
			Framing.selfFrame8WayLookup[lookup] = array;
		}
		public static void Add8WayLookup(int lookup, short x, short y)
		{
			Point16[] array = new Point16[]
			{
				new Point16((int)(x * Framing.frameSize8Way.x), (int)(y * Framing.frameSize8Way.y)),
				new Point16((int)(x * Framing.frameSize8Way.x), (int)(y * Framing.frameSize8Way.y)),
				new Point16((int)(x * Framing.frameSize8Way.x), (int)(y * Framing.frameSize8Way.y))
			};
			Framing.selfFrame8WayLookup[lookup] = array;
		}
		public static void AddWallFrameLookup(int lookup, short point1X, short point1Y, short point2X, short point2Y, short point3X, short point3Y, short point4X, short point4Y)
		{
			Point16[] array = new Point16[]
			{
				new Point16((int)(point1X * Framing.wallFrameSize.x), (int)(point1Y * Framing.wallFrameSize.y)),
				new Point16((int)(point2X * Framing.wallFrameSize.x), (int)(point2Y * Framing.wallFrameSize.y)),
				new Point16((int)(point3X * Framing.wallFrameSize.x), (int)(point3Y * Framing.wallFrameSize.y)),
				new Point16((int)(point4X * Framing.wallFrameSize.x), (int)(point4Y * Framing.wallFrameSize.y))
			};
			Framing.wallFrameLookup[lookup] = array;
		}
		public static void SelfFrame4Way()
		{
		}
		public static void SelfFrame8Way(int i, int j, Tile centerTile, bool resetFrame)
		{
			if (!centerTile.active())
			{
				return;
			}
			ushort type = centerTile.type;
			Framing.BlockStyle blockStyle = Framing.FindBlockStyle(centerTile);
			int num = 0;
			Framing.BlockStyle blockStyle2 = default(Framing.BlockStyle);
			if (blockStyle.top)
			{
				Tile tileSafely = Framing.GetTileSafely(i, j - 1);
				if (tileSafely.active() && tileSafely.type == type)
				{
					blockStyle2 = Framing.FindBlockStyle(tileSafely);
					if (blockStyle2.bottom)
					{
						num |= 1;
					}
					else
					{
						blockStyle2.Clear();
					}
				}
			}
			Framing.BlockStyle blockStyle3 = default(Framing.BlockStyle);
			if (blockStyle.left)
			{
				Tile tileSafely2 = Framing.GetTileSafely(i - 1, j);
				if (tileSafely2.active() && tileSafely2.type == type)
				{
					blockStyle3 = Framing.FindBlockStyle(tileSafely2);
					if (blockStyle3.right)
					{
						num |= 2;
					}
					else
					{
						blockStyle3.Clear();
					}
				}
			}
			Framing.BlockStyle blockStyle4 = default(Framing.BlockStyle);
			if (blockStyle.right)
			{
				Tile tileSafely3 = Framing.GetTileSafely(i + 1, j);
				if (tileSafely3.active() && tileSafely3.type == type)
				{
					blockStyle4 = Framing.FindBlockStyle(tileSafely3);
					if (blockStyle4.left)
					{
						num |= 4;
					}
					else
					{
						blockStyle4.Clear();
					}
				}
			}
			Framing.BlockStyle blockStyle5 = default(Framing.BlockStyle);
			if (blockStyle.bottom)
			{
				Tile tileSafely4 = Framing.GetTileSafely(i, j + 1);
				if (tileSafely4.active() && tileSafely4.type == type)
				{
					blockStyle5 = Framing.FindBlockStyle(tileSafely4);
					if (blockStyle5.top)
					{
						num |= 8;
					}
					else
					{
						blockStyle5.Clear();
					}
				}
			}
			if (blockStyle2.left && blockStyle3.top)
			{
				Tile tileSafely5 = Framing.GetTileSafely(i - 1, j - 1);
				if (tileSafely5.active() && tileSafely5.type == type)
				{
					Framing.BlockStyle blockStyle6 = Framing.FindBlockStyle(tileSafely5);
					if (blockStyle6.right && blockStyle6.bottom)
					{
						num |= 16;
					}
				}
			}
			if (blockStyle2.right && blockStyle4.top)
			{
				Tile tileSafely6 = Framing.GetTileSafely(i + 1, j - 1);
				if (tileSafely6.active() && tileSafely6.type == type)
				{
					Framing.BlockStyle blockStyle7 = Framing.FindBlockStyle(tileSafely6);
					if (blockStyle7.left && blockStyle7.bottom)
					{
						num |= 32;
					}
				}
			}
			if (blockStyle5.left && blockStyle3.bottom)
			{
				Tile tileSafely7 = Framing.GetTileSafely(i - 1, j + 1);
				if (tileSafely7.active() && tileSafely7.type == type)
				{
					Framing.BlockStyle blockStyle8 = Framing.FindBlockStyle(tileSafely7);
					if (blockStyle8.right && blockStyle8.top)
					{
						num |= 64;
					}
				}
			}
			if (blockStyle5.right && blockStyle4.bottom)
			{
				Tile tileSafely8 = Framing.GetTileSafely(i + 1, j + 1);
				if (tileSafely8.active() && tileSafely8.type == type)
				{
					Framing.BlockStyle blockStyle9 = Framing.FindBlockStyle(tileSafely8);
					if (blockStyle9.left && blockStyle9.top)
					{
						num |= 128;
					}
				}
			}
			if (resetFrame)
			{
				centerTile.frameNumber((byte)WorldGen.genRand.Next(0, 3));
			}
			Point16 point = Framing.selfFrame8WayLookup[num][(int)centerTile.frameNumber()];
			centerTile.frameX = point.x;
			centerTile.frameY = point.y;
		}
		public static void WallFrame(int i, int j, bool resetFrame = false)
		{
			if (i <= 0 || j <= 0 || i >= Main.maxTilesX - 1 || j >= Main.maxTilesY - 1 || Main.tile[i, j] == null)
			{
				return;
			}
			Tile tile = Main.tile[i, j];
			if (tile.wall == 0)
			{
				tile.wallColor(0);
				return;
			}
			int num = 0;
			Tile tile2 = Main.tile[i, j - 1];
			if (tile2 != null && tile2.wall > 0)
			{
				num = 1;
			}
			tile2 = Main.tile[i - 1, j];
			if (tile2 != null && tile2.wall > 0)
			{
				num |= 2;
			}
			tile2 = Main.tile[i + 1, j];
			if (tile2 != null && tile2.wall > 0)
			{
				num |= 4;
			}
			tile2 = Main.tile[i, j + 1];
			if (tile2 != null && tile2.wall > 0)
			{
				num |= 8;
			}
			int num2;
			if (Main.wallLargeFrames[(int)tile.wall] == 1)
			{
				num2 = Framing.largeTileFrameNumberLookup[j % 4][i % 3] - 1;
				tile.wallFrameNumber((byte)num2);
			}
			else if (resetFrame)
			{
				num2 = WorldGen.genRand.Next(0, 3);
				tile.wallFrameNumber((byte)num2);
			}
			else
			{
				num2 = (int)tile.wallFrameNumber();
			}
			if (num == 15)
			{
				num += Framing.centerWallFrameLookup[i % 3][j % 3];
			}
			Point16 point = Framing.wallFrameLookup[num][num2];
			tile.wallFrameX((int)point.x);
			tile.wallFrameY((int)point.y);
		}
		public static Tile GetTileSafely(int i, int j)
		{
			Tile tile = Main.tile[i, j];
			if (tile == null)
			{
				tile = new Tile();
				Main.tile[i, j] = tile;
			}
			return tile;
		}
	}
}
