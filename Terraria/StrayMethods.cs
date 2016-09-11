using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terraria
{
	public class StrayMethods
	{
		public static bool CanSpawnSandstormFriendly(Vector2 position, int expandUp, int expandDown)
		{
			bool result = true;
			Point point = position.ToTileCoordinates();
			for (int i = -1; i <= 1; i++)
			{
				int num;
				int num2;
				Collision.ExpandVertically(point.X + i, point.Y, out num, out num2, expandUp, expandDown);
				num++;
				num2--;
				if (num2 - num < 10)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public static bool CanSpawnSandstormHostile(Vector2 position, int expandUp, int expandDown)
		{
			bool result = true;
			Point point = position.ToTileCoordinates();
			for (int i = -1; i <= 1; i++)
			{
				int num;
				int num2;
				Collision.ExpandVertically(point.X + i, point.Y, out num, out num2, expandUp, expandDown);
				num++;
				num2--;
				if (num2 - num < 20)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public static bool CountSandHorizontally(int i, int j, bool[] fittingTypes, int requiredTotalSpread = 4, int spreadInEachAxis = 5)
		{
			if (!WorldGen.InWorld(i, j, 2))
			{
				return false;
			}
			int num = 0;
			int num2 = 0;
			int num3 = i - 1;
			while (num < spreadInEachAxis && num3 > 0)
			{
				Tile tile = Main.tile[num3, j];
				if (tile.active() && fittingTypes[(int)tile.type] && !WorldGen.SolidTileAllowBottomSlope(num3, j - 1))
				{
					num++;
				}
				else if (!tile.active())
				{
					break;
				}
				num3--;
			}
			num3 = i + 1;
			while (num2 < spreadInEachAxis && num3 < Main.maxTilesX - 1)
			{
				Tile tile2 = Main.tile[num3, j];
				if (tile2.active() && fittingTypes[(int)tile2.type] && !WorldGen.SolidTileAllowBottomSlope(num3, j - 1))
				{
					num2++;
				}
				else if (!tile2.active())
				{
					break;
				}
				num3++;
			}
			return num + num2 + 1 >= requiredTotalSpread;
		}
	}
}
