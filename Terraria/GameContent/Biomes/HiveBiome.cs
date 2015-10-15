
using System;
using Terraria;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class HiveBiome : MicroBiome
	{
		public HiveBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Ref<int> @ref = new Ref<int>(0);
			Ref<int> ref1 = new Ref<int>(0);
			Ref<int> ref2 = new Ref<int>(0);
			Ref<int> ref3 = new Ref<int>(0);
			Shapes.Circle circle = new Shapes.Circle(15);
			GenAction[] scanner = new GenAction[] { new Actions.Scanner(ref2), new Modifiers.IsSolid(), new Actions.Scanner(@ref), null, null, null, null };
			ushort[] numArray = new ushort[] { 60, 59 };
			scanner[3] = new Modifiers.OnlyTiles(numArray);
			scanner[4] = new Actions.Scanner(ref1);
			ushort[] numArray1 = new ushort[] { 60 };
			scanner[5] = new Modifiers.OnlyTiles(numArray1);
			scanner[6] = new Actions.Scanner(ref3);
			WorldUtils.Gen(origin, circle, Actions.Chain(scanner));
			if ((float)ref1.Value / (float)@ref.Value < 0.75f || ref3.Value < 2)
			{
				return false;
			}
			if (!structures.CanPlace(new Rectangle(origin.X - 50, origin.Y - 50, 100, 100), 0))
			{
				return false;
			}
			int x = origin.X;
			int y = origin.Y;
			int num = 150;
			for (int i = x - num; i < x + num; i = i + 10)
			{
				if (i > 0 && i <= Main.maxTilesX - 1)
				{
					for (int j = y - num; j < y + num; j = j + 10)
					{
						if (j > 0 && j <= Main.maxTilesY - 1)
						{
							if (Main.tile[i, j].active() && Main.tile[i, j].type == TileID.LihzahrdBrick)
							{
								return false;
							}
							if (Main.tile[i, j].wall == WallID.LihzahrdBrickUnsafe || Main.tile[i, j].wall == WallID.EbonstoneUnsafe || Main.tile[i, j].wall == WallID.CrimstoneUnsafe)
							{
								return false;
							}
						}
					}
				}
			}
			int x1 = origin.X;
			int y1 = origin.Y;
			int num1 = 0;
			int[] x2 = new int[10];
			int[] y2 = new int[10];
			Vector2 vector2 = new Vector2((float)x1, (float)y1);
			Vector2 vector21 = vector2;
			int num2 = WorldGen.genRand.Next(2, 5);
			for (int k = 0; k < num2; k++)
			{
				int num3 = WorldGen.genRand.Next(2, 5);
				for (int l = 0; l < num3; l++)
				{
					vector21 = WorldGen.Hive((int)vector2.X, (int)vector2.Y);
				}
				vector2 = vector21;
				x2[num1] = (int)vector2.X;
				y2[num1] = (int)vector2.Y;
				num1++;
			}
			for (int m = 0; m < num1; m++)
			{
				int num4 = x2[m];
				int num5 = y2[m];
				bool flag = false;
				int num6 = 1;
				if (WorldGen.genRand.Next(2) == 0)
				{
					num6 = -1;
				}
				while (num4 > 10 && num4 < Main.maxTilesX - 10 && num5 > 10 && num5 < Main.maxTilesY - 10 && (!Main.tile[num4, num5].active() || !Main.tile[num4, num5 + 1].active() || !Main.tile[num4 + 1, num5].active() || !Main.tile[num4 + 1, num5 + 1].active()))
				{
					num4 = num4 + num6;
					if (Math.Abs(num4 - x2[m]) <= 50)
					{
						continue;
					}
					flag = true;
					break;
				}
				if (!flag)
				{
					num4 = num4 + num6;
					for (int n = num4 - 1; n <= num4 + 2; n++)
					{
						for (int o = num5 - 1; o <= num5 + 2; o++)
						{
							if (n < 10 || n > Main.maxTilesX - 10)
							{
								flag = true;
							}
							else if (Main.tile[n, o].active() && Main.tile[n, o].type != TileID.Hive)
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						for (int p = num4 - 1; p <= num4 + 2; p++)
						{
							for (int q = num5 - 1; q <= num5 + 2; q++)
							{
								if (p < num4 || p > num4 + 1 || q < num5 || q > num5 + 1)
								{
									Main.tile[p, q].active(true);
									Main.tile[p, q].type = 225;
								}
								else
								{
									Main.tile[p, q].active(false);
									Main.tile[p, q].liquid = 255;
									Main.tile[p, q].honey(true);
								}
							}
						}
						num6 = num6 * -1;
						num5++;
						int num7 = 0;
						while ((num7 < 4 || WorldGen.SolidTile(num4, num5)) && num4 > 10 && num4 < Main.maxTilesX - 10)
						{
							num7++;
							num4 = num4 + num6;
							if (!WorldGen.SolidTile(num4, num5))
							{
								continue;
							}
							WorldGen.PoundTile(num4, num5);
							if (Main.tile[num4, num5 + 1].active())
							{
								continue;
							}
							Main.tile[num4, num5 + 1].active(true);
							Main.tile[num4, num5 + 1].type = 225;
						}
					}
				}
			}
			WorldGen.larvaX[WorldGen.numLarva] = Utils.Clamp<int>((int)vector2.X, 5, Main.maxTilesX - 5);
			WorldGen.larvaY[WorldGen.numLarva] = Utils.Clamp<int>((int)vector2.Y, 5, Main.maxTilesY - 5);
			WorldGen.numLarva = WorldGen.numLarva + 1;
			int x3 = (int)vector2.X;
			int y3 = (int)vector2.Y;
			for (int r = x3 - 1; r <= x3 + 1 && r > 0 && r < Main.maxTilesX; r++)
			{
				for (int s = y3 - 2; s <= y3 + 1 && s > 0 && s < Main.maxTilesY; s++)
				{
					if (s == y3 + 1)
					{
						Main.tile[r, s].active(true);
						Main.tile[r, s].type = 225;
						Main.tile[r, s].slope(0);
						Main.tile[r, s].halfBrick(false);
					}
					else
					{
						Main.tile[r, s].active(false);
					}
				}
			}
			structures.AddStructure(new Rectangle(origin.X - 50, origin.Y - 50, 100, 100), 5);
			return true;
		}
	}
}
