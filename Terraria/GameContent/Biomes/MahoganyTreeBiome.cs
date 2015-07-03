using XNA;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class MahoganyTreeBiome : MicroBiome
	{
		public MahoganyTreeBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Point point;
			Point point1;
			Point point2 = new Point(origin.X - 3, origin.Y);
			Searches.Down down = new Searches.Down(200);
			GenCondition[] genConditionArray = new GenCondition[] { (new Conditions.IsSolid()).AreaAnd(6, 1) };
			if (!WorldUtils.Find(point2, Searches.Chain(down, genConditionArray), out point))
			{
				return false;
			}
			Point point3 = new Point(point.X, point.Y - 5);
			Searches.Up up = new Searches.Up(120);
			GenCondition[] genConditionArray1 = new GenCondition[] { (new Conditions.IsSolid()).AreaOr(6, 1) };
			if (!WorldUtils.Find(point3, Searches.Chain(up, genConditionArray1), out point1) || point.Y - 5 - point1.Y > 60)
			{
				return false;
			}
			if (point.Y - point1.Y < 30)
			{
				return false;
			}
			if (!structures.CanPlace(new Rectangle(point.X - 30, point.Y - 60, 60, 90), 0))
			{
				return false;
			}
			Dictionary<ushort, int> nums = new Dictionary<ushort, int>();
			Point point4 = new Point(point.X - 25, point.Y - 25);
			Shapes.Rectangle rectangle = new Shapes.Rectangle(50, 50);
			ushort[] numArray = new ushort[] { 0, 59, 147, 1 };
			WorldUtils.Gen(point4, rectangle, (new Actions.TileScanner(numArray)).Output(nums));
			int item = nums[0] + nums[1];
			int num = nums[59];
			if (nums[147] > num || item > num || num < 50)
			{
				return false;
			}
			int y = (point.Y - point1.Y - 9) / 5;
			int num1 = y * 5;
			int num2 = 0;
			double num3 = GenBase._random.NextDouble() + 1;
			double num4 = GenBase._random.NextDouble() + 2;
			if (GenBase._random.Next(2) == 0)
			{
				num4 = -num4;
			}
			for (int i = 0; i < y; i++)
			{
				double num5 = (double)(i + 1) / 12;
				int num6 = (int)(Math.Sin(num5 * num3 * 3.14159274101257) * num4);
				int num7 = (num6 < num2 ? num6 - num2 : 0);
				Point point5 = new Point(point.X + num2 + num7, point.Y - (i + 1) * 5);
				Shapes.Rectangle rectangle1 = new Shapes.Rectangle(6 + Math.Abs(num6 - num2), 7);
				GenAction[] removeWall = new GenAction[] { new Actions.RemoveWall(), new Actions.SetTile(383, false, true), new Actions.SetFrames(false) };
				WorldUtils.Gen(point5, rectangle1, Actions.Chain(removeWall));
				Point point6 = new Point(point.X + num2 + num7 + 2, point.Y - (i + 1) * 5);
				Shapes.Rectangle rectangle2 = new Shapes.Rectangle(2 + Math.Abs(num6 - num2), 5);
				GenAction[] clearTile = new GenAction[] { new Actions.ClearTile(true), new Actions.PlaceWall(78, true) };
				WorldUtils.Gen(point6, rectangle2, Actions.Chain(clearTile));
				Point point7 = new Point(point.X + num2 + 2, point.Y - i * 5);
				Shapes.Rectangle rectangle3 = new Shapes.Rectangle(2, 2);
				GenAction[] genActionArray = new GenAction[] { new Actions.ClearTile(true), new Actions.PlaceWall(78, true) };
				WorldUtils.Gen(point7, rectangle3, Actions.Chain(genActionArray));
				num2 = num6;
			}
			int num8 = 6;
			if (num4 < 0)
			{
				num8 = 0;
			}
			List<Point> points = new List<Point>();
			for (int j = 0; j < 2; j++)
			{
				double num9 = ((double)j + 1) / 3;
				int num10 = num8 + (int)(Math.Sin((double)y * num9 / 12 * num3 * 3.14159274101257) * num4);
				double num11 = GenBase._random.NextDouble() * 0.785398185253143 - 0.785398185253143 - 0.200000002980232;
				if (num8 == 0)
				{
					num11 = num11 - 1.57079637050629;
				}
				Point point8 = new Point(point.X + num10, point.Y - (int)((double)(y * 5) * num9));
				ShapeBranch shapeBranch = (new ShapeBranch(num11, (double)GenBase._random.Next(12, 16))).OutputEndpoints(points);
				GenAction[] setTile = new GenAction[] { new Actions.SetTile(383, false, true), new Actions.SetFrames(true) };
				WorldUtils.Gen(point8, shapeBranch, Actions.Chain(setTile));
				num8 = 6 - num8;
			}
			int num12 = (int)(Math.Sin((double)y / 12 * num3 * 3.14159274101257) * num4);
			Point point9 = new Point(point.X + 6 + num12, point.Y - num1);
			ShapeBranch shapeBranch1 = (new ShapeBranch(-0.685398185253143, (double)GenBase._random.Next(16, 22))).OutputEndpoints(points);
			GenAction[] setTile1 = new GenAction[] { new Actions.SetTile(383, false, true), new Actions.SetFrames(true) };
			WorldUtils.Gen(point9, shapeBranch1, Actions.Chain(setTile1));
			Point point10 = new Point(point.X + num12, point.Y - num1);
			ShapeBranch shapeBranch2 = (new ShapeBranch(-2.45619455575943, (double)GenBase._random.Next(16, 22))).OutputEndpoints(points);
			GenAction[] genActionArray1 = new GenAction[] { new Actions.SetTile(383, false, true), new Actions.SetFrames(true) };
			WorldUtils.Gen(point10, shapeBranch2, Actions.Chain(genActionArray1));
			foreach (Point point11 in points)
			{
				Shapes.Circle circle = new Shapes.Circle(4);
				GenAction[] blotch = new GenAction[] { new Modifiers.Blotches(4, 2, 0.3), null, null, null, null };
				ushort[] numArray1 = new ushort[] { 383 };
				blotch[1] = new Modifiers.SkipTiles(numArray1);
				byte[] numArray2 = new byte[] { 78 };
				blotch[2] = new Modifiers.SkipWalls(numArray2);
				blotch[3] = new Actions.SetTile(384, false, true);
				blotch[4] = new Actions.SetFrames(true);
				WorldUtils.Gen(point11, circle, Actions.Chain(blotch));
			}
			for (int k = 0; k < 4; k++)
			{
				float single = (float)k / 3f * 2f + 0.57075f;
				WorldUtils.Gen(point, new ShapeRoot(single, (float)GenBase._random.Next(40, 60), 4f, 1f), new Actions.SetTile(383, true, true));
			}
			WorldGen.AddBuriedChest(point.X + 3, point.Y - 1, (GenBase._random.Next(4) == 0 ? 0 : WorldGen.GetNextJungleChestItem()), false, 10);
			structures.AddStructure(new Rectangle(point.X - 30, point.Y - 30, 60, 60), 0);
			return true;
		}
	}
}