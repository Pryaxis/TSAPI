
using System;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	public class CampsiteBiome : MicroBiome
	{
		public CampsiteBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Point point;
			Ref<int> @ref = new Ref<int>(0);
			Ref<int> ref1 = new Ref<int>(0);
			Shapes.Circle circle = new Shapes.Circle(10);
			GenAction[] scanner = new GenAction[] { new Actions.Scanner(ref1), new Modifiers.IsSolid(), new Actions.Scanner(@ref) };
			WorldUtils.Gen(origin, circle, Actions.Chain(scanner));
			if (@ref.Value < ref1.Value - 5)
			{
				return false;
			}
			int num = GenBase._random.Next(6, 10);
			int num1 = GenBase._random.Next(5);
			if (!structures.CanPlace(new Rectangle(origin.X - num, origin.Y - num, num * 2, num * 2), 0))
			{
				return false;
			}
			ShapeData shapeDatum = new ShapeData();
			Shapes.Slime slime = new Shapes.Slime(num);
			GenAction[] onlyTile = new GenAction[] { (new Modifiers.Blotches(num1, num1, num1, 1, 0.3)).Output(shapeDatum), new Modifiers.Offset(0, -2), null, null, null, null };
			ushort[] numArray = new ushort[] { 53 };
			onlyTile[2] = new Modifiers.OnlyTiles(numArray);
			onlyTile[3] = new Actions.SetTile(397, true, true);
			onlyTile[4] = new Modifiers.OnlyWalls(new byte[1]);
			onlyTile[5] = new Actions.PlaceWall(16, true);
			WorldUtils.Gen(origin, slime, Actions.Chain(onlyTile));
			ModShapes.All all = new ModShapes.All(shapeDatum);
			GenAction[] clearTile = new GenAction[] { new Actions.ClearTile(false), new Actions.SetLiquid(0, 0), new Actions.SetFrames(true), new Modifiers.OnlyWalls(new byte[1]), new Actions.PlaceWall(16, true) };
			WorldUtils.Gen(origin, all, Actions.Chain(clearTile));
			Searches.Down down = new Searches.Down(10);
			GenCondition[] isSolid = new GenCondition[] { new Conditions.IsSolid() };
			if (!WorldUtils.Find(origin, Searches.Chain(down, isSolid), out point))
			{
				return false;
			}
			int y = point.Y - 1;
			bool flag = GenBase._random.Next() % 2 == 0;
			if (GenBase._random.Next() % 10 != 0)
			{
				int num2 = GenBase._random.Next(1, 4);
				int num3 = (flag ? 4 : -(num >> 1));
				for (int i = 0; i < num2; i++)
				{
					int num4 = GenBase._random.Next(1, 3);
					for (int j = 0; j < num4; j++)
					{
						WorldGen.PlaceTile(origin.X + num3 - i, y - j, 331, false, false, -1, 0);
					}
				}
			}
			int num5 = (num - 3) * (flag ? -1 : 1);
			if (GenBase._random.Next() % 10 != 0)
			{
				WorldGen.PlaceTile(origin.X + num5, y, 186, false, false, -1, 0);
			}
			if (GenBase._random.Next() % 10 != 0)
			{
				WorldGen.PlaceTile(origin.X, y, 215, true, false, -1, 0);
				if (GenBase._tiles[origin.X, y].active() && GenBase._tiles[origin.X, y].type == 215)
				{
					Tile tile = GenBase._tiles[origin.X, y];
					tile.frameY = (short)(tile.frameY + 36);
					Tile tile1 = GenBase._tiles[origin.X - 1, y];
					tile1.frameY = (short)(tile1.frameY + 36);
					Tile tile2 = GenBase._tiles[origin.X + 1, y];
					tile2.frameY = (short)(tile2.frameY + 36);
					Tile tile3 = GenBase._tiles[origin.X, y - 1];
					tile3.frameY = (short)(tile3.frameY + 36);
					Tile tile4 = GenBase._tiles[origin.X - 1, y - 1];
					tile4.frameY = (short)(tile4.frameY + 36);
					Tile tile5 = GenBase._tiles[origin.X + 1, y - 1];
					tile5.frameY = (short)(tile5.frameY + 36);
				}
			}
			structures.AddStructure(new Rectangle(origin.X - num, origin.Y - num, num * 2, num * 2), 4);
			return true;
		}
	}
}