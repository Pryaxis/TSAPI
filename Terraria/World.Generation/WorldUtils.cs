
using System;
using Terraria;

namespace Terraria.World.Generation
{
	public static class WorldUtils
	{
		public static void ClearChestLocation(int x, int y)
		{
			WorldUtils.ClearTile(x, y, true);
			WorldUtils.ClearTile(x - 1, y, true);
			WorldUtils.ClearTile(x, y - 1, true);
			WorldUtils.ClearTile(x - 1, y - 1, true);
		}

		public static void ClearTile(int x, int y, bool frameNeighbors = false)
		{
			Main.tile[x, y].ClearTile();
			if (frameNeighbors)
			{
				WorldGen.TileFrame(x + 1, y, false, false);
				WorldGen.TileFrame(x - 1, y, false, false);
				WorldGen.TileFrame(x, y + 1, false, false);
				WorldGen.TileFrame(x, y - 1, false, false);
			}
		}

		public static void ClearWall(int x, int y, bool frameNeighbors = false)
		{
			Main.tile[x, y].wall = 0;
			if (frameNeighbors)
			{
				WorldGen.SquareWallFrame(x + 1, y, true);
				WorldGen.SquareWallFrame(x - 1, y, true);
				WorldGen.SquareWallFrame(x, y + 1, true);
				WorldGen.SquareWallFrame(x, y - 1, true);
			}
		}

		public static void DebugRegen()
		{
			WorldGen.clearWorld();
			WorldGen.generateWorld(Main.ActiveWorldFileData.Seed, null);
			Main.NewText("World Regen Complete.", 255, 255, 255, false);
		}

		public static void DebugRotate()
		{
			int num = 0;
			int num1 = 0;
			int num2 = Main.maxTilesY;
			for (int i = 0; i < Main.maxTilesX / Main.maxTilesY; i++)
			{
				for (int j = 0; j < num2 / 2; j++)
				{
					for (int k = j; k < num2 - j; k++)
					{
						Tile tile = Main.tile[k + num, j + num1];
						Main.tile[k + num, j + num1] = Main.tile[j + num, num2 - k + num1];
						Main.tile[j + num, num2 - k + num1] = Main.tile[num2 - k + num, num2 - j + num1];
						Main.tile[num2 - k + num, num2 - j + num1] = Main.tile[num2 - j + num, k + num1];
						Main.tile[num2 - j + num, k + num1] = tile;
					}
				}
				num = num + num2;
			}
		}

		public static bool Find(Point origin, GenSearch search, out Point result)
		{
			result = search.Find(origin);
			if (result == GenSearch.NOT_FOUND)
			{
				return false;
			}
			return true;
		}

		public static bool Gen(Point origin, GenShape shape, GenAction action)
		{
			return shape.Perform(origin, action);
		}

		public static void TileFrame(int x, int y, bool frameNeighbors = false)
		{
			WorldGen.TileFrame(x, y, true, false);
			if (frameNeighbors)
			{
				WorldGen.TileFrame(x + 1, y, true, false);
				WorldGen.TileFrame(x - 1, y, true, false);
				WorldGen.TileFrame(x, y + 1, true, false);
				WorldGen.TileFrame(x, y - 1, true, false);
			}
		}

		public static void WireLine(Point start, Point end)
		{
			Point point = start;
			Point point1 = end;
			if (end.X < start.X)
			{
				Utils.Swap<int>(ref end.X, ref start.X);
			}
			if (end.Y < start.Y)
			{
				Utils.Swap<int>(ref end.Y, ref start.Y);
			}
			for (int i = start.X; i <= end.X; i++)
			{
				WorldGen.PlaceWire(i, point.Y);
			}
			for (int j = start.Y; j <= end.Y; j++)
			{
				WorldGen.PlaceWire(point1.X, j);
			}
		}
	}
}