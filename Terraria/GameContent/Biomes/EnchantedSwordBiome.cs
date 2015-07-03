using XNA;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class EnchantedSwordBiome : MicroBiome
	{
		public EnchantedSwordBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Point y;
			Point point;
			Dictionary<ushort, int> nums = new Dictionary<ushort, int>();
			Point point1 = new Point(origin.X - 25, origin.Y - 25);
			Shapes.Rectangle rectangle = new Shapes.Rectangle(50, 50);
			ushort[] numArray = new ushort[] { 0, 1 };
			WorldUtils.Gen(point1, rectangle, (new Actions.TileScanner(numArray)).Output(nums));
			if (nums[0] + nums[1] < 1250)
			{
				return false;
			}
			Searches.Up up = new Searches.Up(1000);
			GenCondition[] genConditionArray = new GenCondition[] { (new Conditions.IsSolid()).AreaOr(1, 50).Not() };
			bool flag = WorldUtils.Find(origin, Searches.Chain(up, genConditionArray), out y);
			Point point2 = origin;
			Searches.Up up1 = new Searches.Up(origin.Y - y.Y);
			GenCondition[] isTile = new GenCondition[1];
			ushort[] numArray1 = new ushort[] { 53 };
			isTile[0] = new Conditions.IsTile(numArray1);
			if (WorldUtils.Find(point2, Searches.Chain(up1, isTile), out point))
			{
				return false;
			}
			if (!flag)
			{
				return false;
			}
			y.Y = y.Y + 50;
			ShapeData shapeDatum = new ShapeData();
			ShapeData shapeDatum1 = new ShapeData();
			Point point3 = new Point(origin.X, origin.Y + 20);
			Point point4 = new Point(origin.X, origin.Y + 30);
			float single = 0.8f + GenBase._random.NextFloat() * 0.5f;
			if (!structures.CanPlace(new Rectangle(point3.X - (int)(20f * single), point3.Y - 20, (int)(40f * single), 40), 0))
			{
				return false;
			}
			if (!structures.CanPlace(new Rectangle(origin.X, y.Y + 10, 1, origin.Y - y.Y - 9), 2))
			{
				return false;
			}
			Shapes.Slime slime = new Shapes.Slime(20, single, 1f);
			GenAction[] blotch = new GenAction[] { new Modifiers.Blotches(2, 0.4), (new Actions.ClearTile(true)).Output(shapeDatum) };
			WorldUtils.Gen(point3, slime, Actions.Chain(blotch));
			Shapes.Mound mound = new Shapes.Mound(14, 14);
			GenAction[] genActionArray = new GenAction[] { new Modifiers.Blotches(2, 1, 0.8), new Actions.SetTile(0, false, true), (new Actions.SetFrames(true)).Output(shapeDatum1) };
			WorldUtils.Gen(point4, mound, Actions.Chain(genActionArray));
			shapeDatum.Subtract(shapeDatum1, point3, point4);
			ModShapes.InnerOutline innerOutline = new ModShapes.InnerOutline(shapeDatum, true);
			GenAction[] setTile = new GenAction[] { new Actions.SetTile(2, false, true), new Actions.SetFrames(true) };
			WorldUtils.Gen(point3, innerOutline, Actions.Chain(setTile));
			ModShapes.All all = new ModShapes.All(shapeDatum);
			GenAction[] rectangleMask = new GenAction[] { new Modifiers.RectangleMask(-40, 40, 0, 40), new Modifiers.IsEmpty(), new Actions.SetLiquid(0, 255) };
			WorldUtils.Gen(point3, all, Actions.Chain(rectangleMask));
			ModShapes.All all1 = new ModShapes.All(shapeDatum);
			GenAction[] placeWall = new GenAction[] { new Actions.PlaceWall(68, true), null, null, null };
			ushort[] numArray2 = new ushort[] { 2 };
			placeWall[1] = new Modifiers.OnlyTiles(numArray2);
			placeWall[2] = new Modifiers.Offset(0, 1);
			placeWall[3] = new ActionVines(3, 5, 52);
			WorldUtils.Gen(point3, all1, Actions.Chain(placeWall));
			ShapeData shapeDatum2 = new ShapeData();
			Point point5 = new Point(origin.X, y.Y + 10);
			Shapes.Rectangle rectangle1 = new Shapes.Rectangle(1, origin.Y - y.Y - 9);
			GenAction[] onlyTile = new GenAction[] { new Modifiers.Blotches(2, 0.2), (new Actions.ClearTile(false)).Output(shapeDatum2), new Modifiers.Expand(1), null, null };
			ushort[] numArray3 = new ushort[] { 53 };
			onlyTile[3] = new Modifiers.OnlyTiles(numArray3);
			onlyTile[4] = (new Actions.SetTile(397, false, true)).Output(shapeDatum2);
			WorldUtils.Gen(point5, rectangle1, Actions.Chain(onlyTile));
			WorldUtils.Gen(new Point(origin.X, y.Y + 10), new ModShapes.All(shapeDatum2), new Actions.SetFrames(true));
			if (GenBase._random.Next(3) != 0)
			{
				WorldGen.PlaceTile(point4.X, point4.Y - 15, 186, true, false, -1, 15);
			}
			else
			{
				WorldGen.PlaceTile(point4.X, point4.Y - 15, 187, true, false, -1, 17);
			}
			ModShapes.All all2 = new ModShapes.All(shapeDatum1);
			GenAction[] offset = new GenAction[] { new Modifiers.Offset(0, -1), null, null, null };
			ushort[] numArray4 = new ushort[] { 2 };
			offset[1] = new Modifiers.OnlyTiles(numArray4);
			offset[2] = new Modifiers.Offset(0, -1);
			offset[3] = new ActionGrass();
			WorldUtils.Gen(point4, all2, Actions.Chain(offset));
			structures.AddStructure(new Rectangle(point3.X - (int)(20f * single), point3.Y - 20, (int)(40f * single), 40), 4);
			return true;
		}
	}
}