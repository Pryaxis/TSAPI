
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class DesertBiome : MicroBiome
	{
		public DesertBiome()
		{
		}

		private void AddTileVariance(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
		{
			int x = (int)(scale.X * (float)clusters.Width);
			int y = (int)(scale.Y * (float)clusters.Height);
			for (int i = -20; i < x + 20; i++)
			{
				for (int j = -20; j < y + 20; j++)
				{
					int num = i + start.X;
					int y1 = j + start.Y;
					Tile tile = GenBase._tiles[num, y1];
					Tile tile1 = GenBase._tiles[num, y1 + 1];
					Tile tile2 = GenBase._tiles[num, y1 + 2];
					if (tile.type == TileID.Sand && (!WorldGen.SolidTile(tile1) || !WorldGen.SolidTile(tile2)))
					{
						tile.type = 397;
					}
				}
			}
			for (int k = -20; k < x + 20; k++)
			{
				for (int l = -20; l < y + 20; l++)
				{
					int x1 = k + start.X;
					int num1 = l + start.Y;
					Tile tile3 = GenBase._tiles[x1, num1];
					if (tile3.active() && tile3.type == 396)
					{
						bool flag = true;
						int num2 = -1;
						while (num2 >= -3)
						{
							if (!GenBase._tiles[x1, num1 + num2].active())
							{
								num2--;
							}
							else
							{
								flag = false;
								break;
							}
						}
						bool flag1 = true;
						int num3 = 1;
						while (num3 <= 3)
						{
							if (!GenBase._tiles[x1, num1 + num3].active())
							{
								num3++;
							}
							else
							{
								flag1 = false;
								break;
							}
						}
						if (flag ^ flag1 && GenBase._random.Next(5) == 0)
						{
							WorldGen.PlaceTile(x1, num1 + (flag ? -1 : 1), 165, true, true, -1, 0);
						}
						else if (flag && GenBase._random.Next(5) == 0)
						{
							WorldGen.PlaceTile(x1, num1 - 1, 187, true, true, -1, 29 + GenBase._random.Next(6));
						}
					}
				}
			}
		}

		private bool FindStart(Point origin, Vector2 scale, int xHubCount, int yHubCount, out Point start)
		{
			start = new Point(0, 0);
			int x = (int)(scale.X * (float)xHubCount);
			int y = (int)(scale.Y * (float)yHubCount);
			origin.X = origin.X - (x >> 1);
			int num = 220;
			for (int i = -20; i < x + 20; i++)
			{
				int num1 = 220;
				while (num1 < Main.maxTilesY)
				{
					if (!WorldGen.SolidTile(i + origin.X, num1))
					{
						num1++;
					}
					else
					{
						ushort num2 = GenBase._tiles[i + origin.X, num1].type;
						if (num2 == 59 || num2 == 60)
						{
							return false;
						}
						if (num1 <= num)
						{
							break;
						}
						num = num1;
						break;
					}
				}
			}
			WorldGen.UndergroundDesertLocation = new Rectangle(origin.X, num, x, y);
			start = new Point(origin.X, num);
			return true;
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Point point;
			float single = (float)Main.maxTilesX / 4200f;
			int num = (int)(80f * single);
			int num1 = (int)((GenBase._random.NextFloat() + 1f) * 80f * single);
			Vector2 vector2 = new Vector2(4f, 2f);
			if (!this.FindStart(origin, vector2, num, num1, out point))
			{
				return false;
			}
			DesertBiome.ClusterGroup clusterGroup = new DesertBiome.ClusterGroup();
			clusterGroup.Generate(num, num1);
			this.PlaceSand(clusterGroup, point, vector2);
			this.PlaceClusters(clusterGroup, point, vector2);
			this.AddTileVariance(clusterGroup, point, vector2);
			int x = (int)(vector2.X * (float)clusterGroup.Width);
			int y = (int)(vector2.Y * (float)clusterGroup.Height);
			for (int i = -20; i < x + 20; i++)
			{
				for (int j = -20; j < y + 20; j++)
				{
					if (i + point.X > 0 && i + point.X < Main.maxTilesX - 1 && j + point.Y > 0 && j + point.Y < Main.maxTilesY - 1)
					{
						WorldGen.SquareWallFrame(i + point.X, j + point.Y, true);
						WorldUtils.TileFrame(i + point.X, j + point.Y, true);
					}
				}
			}
			return true;
		}

		private void PlaceClusters(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
		{
			int x = (int)(scale.X * (float)clusters.Width);
			int y = (int)(scale.Y * (float)clusters.Height);
			Vector2 vector2 = new Vector2((float)x, (float)y);
			Vector2 vector21 = new Vector2((float)clusters.Width, (float)clusters.Height);
			for (int i = -20; i < x + 20; i++)
			{
				for (int j = -20; j < y + 20; j++)
				{
					float single = 0f;
					int num = -1;
					float single1 = 0f;
					int x1 = i + start.X;
					int y1 = j + start.Y;
					Vector2 vector22 = (new Vector2((float)i, (float)j) / vector2) * vector21;
					Vector2 vector23 = ((new Vector2((float)i, (float)j) / vector2) * 2f) - Vector2.One;
					float single2 = vector23.Length();
					for (int k = 0; k < clusters.Count; k++)
					{
						DesertBiome.Cluster item = clusters[k];
						if (Math.Abs(item[0].Position.X - vector22.X) <= 10f && Math.Abs(item[0].Position.Y - vector22.Y) <= 10f)
						{
							float single3 = 0f;
							foreach (DesertBiome.Hub hub in item)
							{
								single3 = single3 + 1f / Vector2.DistanceSquared(hub.Position, vector22);
							}
							if (single3 > single)
							{
								if (single > single1)
								{
									single1 = single;
								}
								single = single3;
								num = k;
							}
							else if (single3 > single1)
							{
								single1 = single3;
							}
						}
					}
					float single4 = single + single1;
					Tile tile = GenBase._tiles[x1, y1];
					bool flag = single2 >= 0.8f;
					if (single4 > 3.5f)
					{
						tile.ClearEverything();
						tile.wall = 187;
						tile.liquid = 0;
						if (num % 15 == 2)
						{
							tile.ResetToType(404);
							tile.wall = 187;
							tile.active(true);
						}
						Tile.SmoothSlope(x1, y1, true);
					}
					else if (single4 > 1.8f)
					{
						tile.wall = 187;
						if (!flag || tile.active())
						{
							tile.ResetToType(396);
							tile.wall = 187;
							tile.active(true);
							Tile.SmoothSlope(x1, y1, true);
						}
						tile.liquid = 0;
					}
					else if (single4 > 0.7f || !flag)
					{
						if (!flag || tile.active())
						{
							tile.ResetToType(397);
							tile.active(true);
							Tile.SmoothSlope(x1, y1, true);
						}
						tile.liquid = 0;
						tile.wall = 216;
					}
					else if (single4 > 0.25f)
					{
						float single5 = (single4 - 0.25f) / 0.45f;
						if (GenBase._random.NextFloat() < single5)
						{
							if (tile.active())
							{
								tile.ResetToType(397);
								tile.active(true);
								Tile.SmoothSlope(x1, y1, true);
								tile.wall = 216;
							}
							tile.liquid = 0;
							tile.wall = 187;
						}
					}
				}
			}
		}

		private void PlaceSand(DesertBiome.ClusterGroup clusters, Point start, Vector2 scale)
		{
			int x = (int)(scale.X * (float)clusters.Width);
			int y = (int)(scale.Y * (float)clusters.Height);
			int num = 5;
			int y1 = start.Y + (y >> 1);
			float single = 0f;
			short[] numArray = new short[x + num * 2];
			for (int i = -num; i < x + num; i++)
			{
				int num1 = 150;
				while (num1 < y1)
				{
					if (!WorldGen.SolidOrSlopedTile(i + start.X, num1))
					{
						num1++;
					}
					else
					{
						single = single + (float)(num1 - 1);
						numArray[i + num] = (short)(num1 - 1);
						break;
					}
				}
			}
			float single1 = single / (float)(x + num * 2);
			int num2 = 0;
			for (int j = -num; j < x + num; j++)
			{
				float single2 = Math.Abs((float)(j + num) / (float)(x + num * 2)) * 2f - 1f;
				single2 = MathHelper.Clamp(single2, -1f, 1f);
				if (j % 3 == 0)
				{
					num2 = Utils.Clamp<int>(num2 + GenBase._random.Next(-1, 2), -10, 10);
				}
				float single3 = (float)Math.Sqrt((double)(1f - single2 * single2 * single2 * single2));
				int num3 = y1 - (int)(single3 * (float)((float)y1 - single1)) + num2;
				int num4 = y1 - (int)((float)((float)y1 - single1) * (single3 - 0.15f / (float)Math.Sqrt(Math.Max(0.01, (double)Math.Abs(8f * single2) - 0.1)) + 0.25f));
				num4 = Math.Min(y1, num4);
				int num5 = (int)(70f - Utils.SmoothStep(0.5f, 0.8f, Math.Abs(single2)) * 70f);
				if (num3 - numArray[j + num] < num5)
				{
					for (int k = 0; k < num5; k++)
					{
						int x1 = j + start.X;
						int num6 = k + num3 - 70;
						GenBase._tiles[x1, num6].active(false);
						GenBase._tiles[x1, num6].wall = 0;
					}
					numArray[j + num] = (short)Utils.Clamp<int>(num5 + num3 - 70, num3, numArray[j + num]);
				}
				for (int l = y1 - 1; l >= num3; l--)
				{
					int x2 = j + start.X;
					int num7 = l;
					Tile tile = GenBase._tiles[x2, num7];
					tile.liquid = 0;
					Tile tile1 = GenBase._tiles[x2, num7 + 1];
					Tile tile2 = GenBase._tiles[x2, num7 + 2];
					tile.type = (ushort)((!WorldGen.SolidTile(tile1) || !WorldGen.SolidTile(tile2) ? 397 : 53));
					if (l > num3 + 5)
					{
						tile.wall = 187;
					}
					tile.active(true);
					if (tile.wall != WallID.Sandstone)
					{
						tile.wall = 0;
					}
					if (l < num4)
					{
						if (l > num3 + 5)
						{
							tile.wall = 187;
						}
						tile.active(false);
					}
					WorldGen.SquareWallFrame(x2, num7, true);
				}
			}
		}

		private class Cluster : List<DesertBiome.Hub>
		{
			public Cluster()
			{
			}
		}

		private class ClusterGroup : List<DesertBiome.Cluster>
		{
			public int Width;

			public int Height;

			public ClusterGroup()
			{
			}

			private void AttemptClaim(int x, int y, int[,] clusterIndexMap, List<List<Point>> pointClusters, int index)
			{
				int num = clusterIndexMap[x, y];
				if (num != -1 && num != index)
				{
					int num1 = (WorldGen.genRand.Next(2) == 0 ? -1 : index);
					foreach (Point item in pointClusters[num])
					{
						clusterIndexMap[item.X, item.Y] = num1;
					}
				}
			}

			public void Generate(int width, int height)
			{
				this.Width = width;
				this.Height = height;
				base.Clear();
				bool[,] flagArray = new bool[width, height];
				int num = (width >> 1) - 1;
				int num1 = (height >> 1) - 1;
				int num2 = (num + 1) * (num + 1);
				Point point = new Point(num, num1);
				for (int i = point.Y - num1; i <= point.Y + num1; i++)
				{
					float y = (float)num / (float)num1 * (float)(i - point.Y);
					int num3 = Math.Min(num, (int)Math.Sqrt((double)((float)num2 - y * y)));
					for (int j = point.X - num3; j <= point.X + num3; j++)
					{
						flagArray[j, i] = WorldGen.genRand.Next(2) == 0;
					}
				}
				List<List<Point>> lists = new List<List<Point>>();
				for (int k = 0; k < flagArray.GetLength(0); k++)
				{
					for (int l = 0; l < flagArray.GetLength(1); l++)
					{
						if (flagArray[k, l] && WorldGen.genRand.Next(2) == 0)
						{
							List<Point> points = new List<Point>();
							this.SearchForCluster(flagArray, points, k, l, 2);
							if (points.Count > 2)
							{
								lists.Add(points);
							}
						}
					}
				}
				int[,] numArray = new int[flagArray.GetLength(0), flagArray.GetLength(1)];
				for (int m = 0; m < numArray.GetLength(0); m++)
				{
					for (int n = 0; n < numArray.GetLength(1); n++)
					{
						numArray[m, n] = -1;
					}
				}
				for (int o = 0; o < lists.Count; o++)
				{
					foreach (Point item in lists[o])
					{
						numArray[item.X, item.Y] = o;
					}
				}
				for (int p = 0; p < lists.Count; p++)
				{
					foreach (Point item1 in lists[p])
					{
						int x = item1.X;
						int y1 = item1.Y;
						if (numArray[x, y1] == -1)
						{
							break;
						}
						int num4 = numArray[x, y1];
						if (x > 0)
						{
							this.AttemptClaim(x - 1, y1, numArray, lists, num4);
						}
						if (x < numArray.GetLength(0) - 1)
						{
							this.AttemptClaim(x + 1, y1, numArray, lists, num4);
						}
						if (y1 > 0)
						{
							this.AttemptClaim(x, y1 - 1, numArray, lists, num4);
						}
						if (y1 >= numArray.GetLength(1) - 1)
						{
							continue;
						}
						this.AttemptClaim(x, y1 + 1, numArray, lists, num4);
					}
				}
				foreach (List<Point> list in lists)
				{
					list.Clear();
				}
				for (int q = 0; q < numArray.GetLength(0); q++)
				{
					for (int r = 0; r < numArray.GetLength(1); r++)
					{
						if (numArray[q, r] != -1)
						{
							lists[numArray[q, r]].Add(new Point(q, r));
						}
					}
				}
				foreach (List<Point> list1 in lists)
				{
					if (list1.Count >= 4)
					{
						continue;
					}
					list1.Clear();
				}
				foreach (List<Point> points1 in lists)
				{
					DesertBiome.Cluster cluster = new DesertBiome.Cluster();
					if (points1.Count <= 0)
					{
						continue;
					}
					foreach (Point point1 in points1)
					{
						cluster.Add(new DesertBiome.Hub((float)point1.X + (WorldGen.genRand.NextFloat() - 0.5f) * 0.5f, (float)point1.Y + (WorldGen.genRand.NextFloat() - 0.5f) * 0.5f));
					}
					base.Add(cluster);
				}
			}

			private void SearchForCluster(bool[,] hubMap, List<Point> pointCluster, int x, int y, int level = 2)
			{
				pointCluster.Add(new Point(x, y));
				hubMap[x, y] = false;
				level--;
				if (level == -1)
				{
					return;
				}
				if (x > 0 && hubMap[x - 1, y])
				{
					this.SearchForCluster(hubMap, pointCluster, x - 1, y, level);
				}
				if (x < hubMap.GetLength(0) - 1 && hubMap[x + 1, y])
				{
					this.SearchForCluster(hubMap, pointCluster, x + 1, y, level);
				}
				if (y > 0 && hubMap[x, y - 1])
				{
					this.SearchForCluster(hubMap, pointCluster, x, y - 1, level);
				}
				if (y < hubMap.GetLength(1) - 1 && hubMap[x, y + 1])
				{
					this.SearchForCluster(hubMap, pointCluster, x, y + 1, level);
				}
			}
		}

		private struct Hub
		{
			public Vector2 Position;

			public Hub(Vector2 position)
			{
				this.Position = position;
			}

			public Hub(float x, float y)
			{
				this.Position = new Vector2(x, y);
			}
		}
	}
}
