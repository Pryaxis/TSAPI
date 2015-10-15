using System;
using Terraria.DataStructures;
using Terraria.ID;

namespace Terraria
{
	public class Framing
	{
		private static Point16[][] selfFrame8WayLookup;

		private static Point16[][] wallFrameLookup;

		private static Point16 frameSize8Way;

		private static Point16 wallFrameSize;

		private static Framing.BlockStyle[] blockStyleLookup;

		private static int[][] phlebasTileFrameNumberLookup;

		private static int[][] lazureTileFrameNumberLookup;

		private static int[][] centerWallFrameLookup;

		public Framing()
		{
		}

		public static void Add8WayLookup(int lookup, short point1X, short point1Y, short point2X, short point2Y, short point3X, short point3Y)
		{
			Point16[] point16 = new Point16[] { new Point16((int)(point1X * Framing.frameSize8Way.X), (int)(point1Y * Framing.frameSize8Way.Y)), new Point16((int)(point2X * Framing.frameSize8Way.X), (int)(point2Y * Framing.frameSize8Way.Y)), new Point16((int)(point3X * Framing.frameSize8Way.X), (int)(point3Y * Framing.frameSize8Way.Y)) };
			Framing.selfFrame8WayLookup[lookup] = point16;
		}

		public static void Add8WayLookup(int lookup, short x, short y)
		{
			Point16[] point16 = new Point16[] { new Point16((int)(x * Framing.frameSize8Way.X), (int)(y * Framing.frameSize8Way.Y)), new Point16((int)(x * Framing.frameSize8Way.X), (int)(y * Framing.frameSize8Way.Y)), new Point16((int)(x * Framing.frameSize8Way.X), (int)(y * Framing.frameSize8Way.Y)) };
			Framing.selfFrame8WayLookup[lookup] = point16;
		}

		public static void AddWallFrameLookup(int lookup, short point1X, short point1Y, short point2X, short point2Y, short point3X, short point3Y, short point4X, short point4Y)
		{
			Point16[] point16 = new Point16[] { new Point16((int)(point1X * Framing.wallFrameSize.X), (int)(point1Y * Framing.wallFrameSize.Y)), new Point16((int)(point2X * Framing.wallFrameSize.X), (int)(point2Y * Framing.wallFrameSize.Y)), new Point16((int)(point3X * Framing.wallFrameSize.X), (int)(point3Y * Framing.wallFrameSize.Y)), new Point16((int)(point4X * Framing.wallFrameSize.X), (int)(point4Y * Framing.wallFrameSize.Y)) };
			Framing.wallFrameLookup[lookup] = point16;
		}

		private static Framing.BlockStyle FindBlockStyle(Tile blockTile)
		{
			return Framing.blockStyleLookup[blockTile.blockType()];
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
			Framing.blockStyleLookup = new Framing.BlockStyle[] { new Framing.BlockStyle(true, true, true, true), new Framing.BlockStyle(false, true, true, true), new Framing.BlockStyle(false, true, true, false), new Framing.BlockStyle(false, true, false, true), new Framing.BlockStyle(true, false, true, false), new Framing.BlockStyle(true, false, false, true) };
			int[][] numArray = new int[][] { new int[] { 2, 4, 2 }, new int[] { 1, 3, 1 }, new int[] { 2, 2, 4 }, new int[] { 1, 1, 3 } };
			Framing.phlebasTileFrameNumberLookup = numArray;
			int[][] numArray1 = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
			Framing.lazureTileFrameNumberLookup = numArray1;
			int[][] numArray2 = new int[3][];
			int[] numArray3 = new int[] { 2, 0, 0 };
			numArray2[0] = numArray3;
			int[] numArray4 = new int[] { 0, 1, 4 };
			numArray2[1] = numArray4;
			int[] numArray5 = new int[] { 0, 3, 0 };
			numArray2[2] = numArray5;
			Framing.centerWallFrameLookup = numArray2;
			Framing.wallFrameLookup = new Point16[20][];
			Framing.wallFrameSize = new Point16(36, 36);
			Framing.AddWallFrameLookup(0, 9, 3, 10, 3, 11, 3, 6, 6);
			Framing.AddWallFrameLookup(1, 6, 3, 7, 3, 8, 3, 4, 6);
			Framing.AddWallFrameLookup(2, 12, 0, 12, 1, 12, 2, 12, 5);
			Framing.AddWallFrameLookup(3, 1, 4, 3, 4, 5, 4, 3, 6);
			Framing.AddWallFrameLookup(4, 9, 0, 9, 1, 9, 2, 9, 5);
			Framing.AddWallFrameLookup(5, 0, 4, 2, 4, 4, 4, 2, 6);
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

		public static void SelfFrame4Way()
		{
		}

		public static void SelfFrame8Way(int i, int j, Tile centerTile, bool resetFrame)
		{
			if (!centerTile.active())
			{
				return;
			}
			ushort num = centerTile.type;
			Framing.BlockStyle blockStyle = Framing.FindBlockStyle(centerTile);
			int num1 = 0;
			Framing.BlockStyle blockStyle1 = new Framing.BlockStyle();
			if (blockStyle.top)
			{
				Tile tileSafely = Framing.GetTileSafely(i, j - 1);
				if (tileSafely.active() && tileSafely.type == num)
				{
					blockStyle1 = Framing.FindBlockStyle(tileSafely);
					if (!blockStyle1.bottom)
					{
						blockStyle1.Clear();
					}
					else
					{
						num1 = num1 | 1;
					}
				}
			}
			Framing.BlockStyle blockStyle2 = new Framing.BlockStyle();
			if (blockStyle.left)
			{
				Tile tile = Framing.GetTileSafely(i - 1, j);
				if (tile.active() && tile.type == num)
				{
					blockStyle2 = Framing.FindBlockStyle(tile);
					if (!blockStyle2.right)
					{
						blockStyle2.Clear();
					}
					else
					{
						num1 = num1 | 2;
					}
				}
			}
			Framing.BlockStyle blockStyle3 = new Framing.BlockStyle();
			if (blockStyle.right)
			{
				Tile tileSafely1 = Framing.GetTileSafely(i + 1, j);
				if (tileSafely1.active() && tileSafely1.type == num)
				{
					blockStyle3 = Framing.FindBlockStyle(tileSafely1);
					if (!blockStyle3.left)
					{
						blockStyle3.Clear();
					}
					else
					{
						num1 = num1 | 4;
					}
				}
			}
			Framing.BlockStyle blockStyle4 = new Framing.BlockStyle();
			if (blockStyle.bottom)
			{
				Tile tile1 = Framing.GetTileSafely(i, j + 1);
				if (tile1.active() && tile1.type == num)
				{
					blockStyle4 = Framing.FindBlockStyle(tile1);
					if (!blockStyle4.top)
					{
						blockStyle4.Clear();
					}
					else
					{
						num1 = num1 | 8;
					}
				}
			}
			if (blockStyle1.left && blockStyle2.top)
			{
				Tile tileSafely2 = Framing.GetTileSafely(i - 1, j - 1);
				if (tileSafely2.active() && tileSafely2.type == num)
				{
					Framing.BlockStyle blockStyle5 = Framing.FindBlockStyle(tileSafely2);
					if (blockStyle5.right && blockStyle5.bottom)
					{
						num1 = num1 | 16;
					}
				}
			}
			if (blockStyle1.right && blockStyle3.top)
			{
				Tile tile2 = Framing.GetTileSafely(i + 1, j - 1);
				if (tile2.active() && tile2.type == num)
				{
					Framing.BlockStyle blockStyle6 = Framing.FindBlockStyle(tile2);
					if (blockStyle6.left && blockStyle6.bottom)
					{
						num1 = num1 | 32;
					}
				}
			}
			if (blockStyle4.left && blockStyle2.bottom)
			{
				Tile tileSafely3 = Framing.GetTileSafely(i - 1, j + 1);
				if (tileSafely3.active() && tileSafely3.type == num)
				{
					Framing.BlockStyle blockStyle7 = Framing.FindBlockStyle(tileSafely3);
					if (blockStyle7.right && blockStyle7.top)
					{
						num1 = num1 | 64;
					}
				}
			}
			if (blockStyle4.right && blockStyle3.bottom)
			{
				Tile tile3 = Framing.GetTileSafely(i + 1, j + 1);
				if (tile3.active() && tile3.type == num)
				{
					Framing.BlockStyle blockStyle8 = Framing.FindBlockStyle(tile3);
					if (blockStyle8.left && blockStyle8.top)
					{
						num1 = num1 | 128;
					}
				}
			}
			if (resetFrame)
			{
				centerTile.frameNumber((byte)WorldGen.genRand.Next(0, 3));
			}
			Point16 point16 = Framing.selfFrame8WayLookup[num1][centerTile.frameNumber()];
			centerTile.frameX = point16.X;
			centerTile.frameY = point16.Y;
		}

		public static void WallFrame(int i, int j, bool resetFrame = false)
		{
			if (i <= 0 || j <= 0 || i >= Main.maxTilesX - 1 || j >= Main.maxTilesY - 1 || Main.tile[i, j] == null)
			{
				return;
			}
			WorldGen.UpdateMapTile(i, j, true);
			Tile tile = Main.tile[i, j];
			if (tile.wall == WallID.None)
			{
				tile.wallColor(0);
				return;
			}
			int num = 0;
			Tile tile1 = Main.tile[i, j - 1];
			if (tile1 != null && (tile1.wall > 0 || tile1.active() && tile1.type == 54))
			{
				num = 1;
			}
			tile1 = Main.tile[i - 1, j];
			if (tile1 != null && (tile1.wall > 0 || tile1.active() && tile1.type == 54))
			{
				num = num | 2;
			}
			tile1 = Main.tile[i + 1, j];
			if (tile1 != null && (tile1.wall > 0 || tile1.active() && tile1.type == 54))
			{
				num = num | 4;
			}
			tile1 = Main.tile[i, j + 1];
			if (tile1 != null && (tile1.wall > 0 || tile1.active() && tile1.type == 54))
			{
				num = num | 8;
			}
			int num1 = 0;
			if (Main.wallLargeFrames[tile.wall] == 1)
			{
				num1 = Framing.phlebasTileFrameNumberLookup[j % 4][i % 3] - 1;
				tile.wallFrameNumber((byte)num1);
			}
			else if (Main.wallLargeFrames[tile.wall] == 2)
			{
				num1 = Framing.lazureTileFrameNumberLookup[i % 2][j % 2] - 1;
				tile.wallFrameNumber((byte)num1);
			}
			else if (!resetFrame)
			{
				num1 = tile.wallFrameNumber();
			}
			else
			{
				num1 = WorldGen.genRand.Next(0, 3);
				tile.wallFrameNumber((byte)num1);
			}
			if (num == 15)
			{
				num = num + Framing.centerWallFrameLookup[i % 3][j % 3];
			}
			Point16 point16 = Framing.wallFrameLookup[num][num1];
			tile.wallFrameX(point16.X);
			tile.wallFrameY(point16.Y);
		}

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
				int num = 0;
				bool flag = num == 1;
				this.right = num == 1;
				bool flag1 = flag;
				bool flag2 = flag1;
				this.left = flag1;
				bool flag3 = flag2;
				bool flag4 = flag3;
				this.bottom = flag3;
				this.top = flag4;
			}
		}
	}
}
