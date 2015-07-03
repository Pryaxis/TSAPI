using XNA;
using System;
using Terraria;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class TrackGenerator
	{
		private const int TOTAL_TILE_IGNORES = 150;

		private const int PLAYER_HEIGHT = 6;

		private const int MAX_RETRIES = 400;

		private const int MAX_SMOOTH_DISTANCE = 15;

		private const int MAX_ITERATIONS = 1000000;

		private readonly static byte[] INVALID_WALLS;

		private TrackGenerator.TrackHistory[] _historyCache = new TrackGenerator.TrackHistory[2048];

		static TrackGenerator()
		{
			TrackGenerator.INVALID_WALLS = new byte[] { 7, 94, 95, 8, 98, 99, 9, 96, 97, 3, 83, 87, 86 };
		}

		public TrackGenerator()
		{
		}

		private bool CanTrackBePlaced(int x, int y)
		{
			if (y > Main.maxTilesY - 200 || x < 0 || y < (int)Main.worldSurface || x > Main.maxTilesX - 5)
			{
				return false;
			}
			byte num = Main.tile[x, y].wall;
			for (int i = 0; i < (int)TrackGenerator.INVALID_WALLS.Length; i++)
			{
				if (num == TrackGenerator.INVALID_WALLS[i])
				{
					return false;
				}
			}
			for (int j = -1; j <= 1; j++)
			{
				if (Main.tile[x + j, y].active() && (Main.tile[x + j, y].type == 314 || !TileID.Sets.GeneralPlacementTiles[Main.tile[x + j, y].type]))
				{
					return false;
				}
			}
			return true;
		}

		public bool FindPath(int x, int y, int minimumLength, bool debugMode = false)
		{
			TrackGenerator.TrackHistory[] trackHistory = this._historyCache;
			int num = 0;
			Tile[,] tileArray = Main.tile;
			bool flag = true;
			int num1 = ((new Random()).Next(2) == 0 ? 1 : -1);
			if (debugMode)
			{
				num1 = Main.player[Main.myPlayer].direction;
			}
			int yDirection = 1;
			int num2 = 0;
			int num3 = 400;
			bool flag1 = false;
			int num4 = 150;
			int num5 = 0;
			int num6 = 1000000;
			while (num6 > 0 && flag && num < (int)trackHistory.Length - 1)
			{
				num6--;
				trackHistory[num] = new TrackGenerator.TrackHistory(x, y, yDirection);
				bool flag2 = false;
				int num7 = 1;
				if (num > minimumLength >> 1)
				{
					num7 = -1;
				}
				else if (num > (minimumLength >> 1) - 5)
				{
					num7 = 0;
				}
				if (!flag1)
				{
					int num8 = Math.Min(1, yDirection + 1);
					while (num8 >= Math.Max(-1, yDirection - 1))
					{
						if (!this.IsLocationEmpty(x + num1, y + num8 * num7))
						{
							num8--;
						}
						else
						{
							yDirection = num8;
							flag2 = true;
							x = x + num1;
							y = y + yDirection * num7;
							num2 = num + 1;
							break;
						}
					}
					if (!flag2)
					{
						while (num > num5 && y == trackHistory[num].Y)
						{
							num--;
						}
						x = trackHistory[num].X;
						y = trackHistory[num].Y;
						yDirection = trackHistory[num].YDirection - 1;
						num3--;
						if (num3 <= 0)
						{
							num = num2;
							x = trackHistory[num].X;
							y = trackHistory[num].Y;
							yDirection = trackHistory[num].YDirection;
							flag1 = true;
							num3 = 200;
						}
						num--;
					}
				}
				else
				{
					int num9 = 0;
					int num10 = num4;
					bool flag3 = false;
					for (int i = Math.Min(1, yDirection + 1); i >= Math.Max(-1, yDirection - 1); i--)
					{
						int num11 = 0;
						while (num11 <= num4)
						{
							if (!this.IsLocationEmpty(x + (num11 + 1) * num1, y + (num11 + 1) * i * num7))
							{
								num11++;
							}
							else
							{
								flag3 = true;
								break;
							}
						}
						if (num11 < num10)
						{
							num10 = num11;
							num9 = i;
						}
					}
					if (flag3)
					{
						yDirection = num9;
						for (int j = 0; j < num10 - 1; j++)
						{
							num++;
							x = x + num1;
							y = y + yDirection * num7;
							trackHistory[num] = new TrackGenerator.TrackHistory(x, y, yDirection);
							num5 = num;
						}
						x = x + num1;
						y = y + yDirection * num7;
						num2 = num + 1;
						flag1 = false;
					}
					num4 = num4 - num10;
					if (num4 < 0)
					{
						flag = false;
					}
				}
				num++;
			}
			if (num2 <= minimumLength && !debugMode)
			{
				return false;
			}
			this.SmoothTrack(trackHistory, num2);
			if (!debugMode)
			{
				for (int k = 0; k < num2; k++)
				{
					for (int l = -1; l < 7; l++)
					{
						if (!this.CanTrackBePlaced(trackHistory[k].X, trackHistory[k].Y - l))
						{
							return false;
						}
					}
				}
			}
			for (int m = 0; m < num2; m++)
			{
				TrackGenerator.TrackHistory trackHistory1 = trackHistory[m];
				for (int n = 0; n < 6; n++)
				{
					Main.tile[trackHistory1.X, trackHistory1.Y - n].active(false);
				}
			}
			for (int o = 0; o < num2; o++)
			{
				TrackGenerator.TrackHistory trackHistory2 = trackHistory[o];
				Tile.SmoothSlope(trackHistory2.X, trackHistory2.Y + 1, true);
				Tile.SmoothSlope(trackHistory2.X, trackHistory2.Y - 6, true);
				Main.tile[trackHistory2.X, trackHistory2.Y].ResetToType(314);
				if (o != 0)
				{
					for (int p = 0; p < 6; p++)
					{
						WorldUtils.TileFrame(trackHistory[o - 1].X, trackHistory[o - 1].Y - p, true);
					}
					if (o == num2 - 1)
					{
						for (int q = 0; q < 6; q++)
						{
							WorldUtils.TileFrame(trackHistory2.X, trackHistory2.Y - q, true);
						}
					}
				}
			}
			return true;
		}

		public void Generate(int trackCount, int minimumLength)
		{
			Random random = new Random();
			int num = trackCount;
			while (num > 0)
			{
				int num1 = random.Next(150, Main.maxTilesX - 150);
				int num2 = random.Next((int)Main.worldSurface + 25, Main.maxTilesY - 200);
				if (!this.IsLocationEmpty(num1, num2))
				{
					continue;
				}
				while (this.IsLocationEmpty(num1, num2 + 1))
				{
					num2++;
				}
				if (!this.FindPath(num1, num2, minimumLength, false))
				{
					continue;
				}
				num--;
			}
		}

		private bool IsLocationEmpty(int x, int y)
		{
			if (y > Main.maxTilesY - 200 || x < 0 || y < (int)Main.worldSurface || x > Main.maxTilesX - 5)
			{
				return false;
			}
			for (int i = 0; i < 6; i++)
			{
				if (WorldGen.SolidTile(x, y - i))
				{
					return false;
				}
			}
			return true;
		}

		public static void Run(int trackCount = 30, int minimumLength = 250)
		{
			(new TrackGenerator()).Generate(trackCount, minimumLength);
		}

		public static void Run(Point start)
		{
			(new TrackGenerator()).FindPath(start.X, start.Y, 250, true);
		}

		private void SmoothTrack(TrackGenerator.TrackHistory[] history, int length)
		{
			int num = length - 1;
			bool flag = false;
			for (int i = length - 1; i >= 0; i--)
			{
				if (flag)
				{
					num = Math.Min(i + 15, num);
					if (history[i].Y >= history[num].Y)
					{
						for (int j = i + 1; history[j].Y > history[i].Y; j++)
						{
							history[j].Y = history[i].Y;
						}
						if (history[i].Y == history[num].Y)
						{
							flag = false;
						}
					}
				}
				else if (history[i].Y <= history[num].Y)
				{
					num = i;
				}
				else
				{
					flag = true;
				}
			}
		}

		private struct TrackHistory
		{
			public short X;

			public short Y;

			public byte YDirection;

			public TrackHistory(int x, int y, int yDirection)
			{
				this.X = (short)x;
				this.Y = (short)y;
				this.YDirection = (byte)yDirection;
			}

			public TrackHistory(short x, short y, byte yDirection)
			{
				this.X = x;
				this.Y = y;
				this.YDirection = yDirection;
			}
		}
	}
}