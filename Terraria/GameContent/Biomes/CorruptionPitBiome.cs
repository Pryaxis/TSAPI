
using System;
using Terraria;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	public class CorruptionPitBiome : MicroBiome
	{
		public static bool[] ValidTiles;

		static CorruptionPitBiome()
		{
			SetFactory factory = TileID.Sets.Factory;
			int[] numArray = new int[] { 21, 31, 26 };
			CorruptionPitBiome.ValidTiles = factory.CreateBoolSet(true, numArray);
		}

		public CorruptionPitBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Point point;
			if (WorldGen.SolidTile(origin.X, origin.Y) && GenBase._tiles[origin.X, origin.Y].wall == 3)
			{
				return false;
			}
			Searches.Down down = new Searches.Down(100);
			GenCondition[] isSolid = new GenCondition[] { new Conditions.IsSolid() };
			if (!WorldUtils.Find(origin, Searches.Chain(down, isSolid), out origin))
			{
				return false;
			}
			Point point1 = new Point(origin.X - 4, origin.Y);
			Searches.Down down1 = new Searches.Down(5);
			GenCondition[] genConditionArray = new GenCondition[1];
			ushort[] numArray = new ushort[] { 25 };
			genConditionArray[0] = (new Conditions.IsTile(numArray)).AreaAnd(8, 1);
			if (!WorldUtils.Find(point1, Searches.Chain(down1, genConditionArray), out point))
			{
				return false;
			}
			ShapeData shapeDatum = new ShapeData();
			ShapeData shapeDatum1 = new ShapeData();
			ShapeData shapeDatum2 = new ShapeData();
			for (int i = 0; i < 6; i++)
			{
				Shapes.Circle circle = new Shapes.Circle(GenBase._random.Next(10, 12) + i);
				GenAction[] offset = new GenAction[] { new Modifiers.Offset(0, 5 * i + 5), (new Modifiers.Blotches(3, 0.3)).Output(shapeDatum) };
				WorldUtils.Gen(origin, circle, Actions.Chain(offset));
			}
			for (int j = 0; j < 6; j++)
			{
				Shapes.Circle circle1 = new Shapes.Circle(GenBase._random.Next(5, 7) + j);
				GenAction[] genActionArray = new GenAction[] { new Modifiers.Offset(0, 2 * j + 18), (new Modifiers.Blotches(3, 0.3)).Output(shapeDatum1) };
				WorldUtils.Gen(origin, circle1, Actions.Chain(genActionArray));
			}
			for (int k = 0; k < 6; k++)
			{
				Shapes.Circle circle2 = new Shapes.Circle(GenBase._random.Next(4, 6) + k / 2);
				GenAction[] offset1 = new GenAction[] { new Modifiers.Offset(0, (int)(7.5f * (float)k) - 10), (new Modifiers.Blotches(3, 0.3)).Output(shapeDatum2) };
				WorldUtils.Gen(origin, circle2, Actions.Chain(offset1));
			}
			ShapeData shapeDatum3 = new ShapeData(shapeDatum1);
			shapeDatum1.Subtract(shapeDatum2, origin, origin);
			shapeDatum3.Subtract(shapeDatum1, origin, origin);
			ShapeData[] shapeDataArray = new ShapeData[] { shapeDatum, shapeDatum2 };
			Rectangle bounds = ShapeData.GetBounds(origin, shapeDataArray);
			if (!structures.CanPlace(bounds, CorruptionPitBiome.ValidTiles, 2))
			{
				return false;
			}
			ModShapes.All all = new ModShapes.All(shapeDatum);
			GenAction[] setTile = new GenAction[] { new Actions.SetTile(25, true, true), new Actions.PlaceWall(3, true) };
			WorldUtils.Gen(origin, all, Actions.Chain(setTile));
			WorldUtils.Gen(origin, new ModShapes.All(shapeDatum1), new Actions.SetTile(0, true, true));
			WorldUtils.Gen(origin, new ModShapes.All(shapeDatum2), new Actions.ClearTile(true));
			ModShapes.All all1 = new ModShapes.All(shapeDatum1);
			GenAction[] isTouchingAir = new GenAction[] { new Modifiers.IsTouchingAir(true), null, null };
			ushort[] numArray1 = new ushort[] { 25 };
			isTouchingAir[1] = new Modifiers.NotTouching(false, numArray1);
			isTouchingAir[2] = new Actions.SetTile(23, true, true);
			WorldUtils.Gen(origin, all1, Actions.Chain(isTouchingAir));
			WorldUtils.Gen(origin, new ModShapes.All(shapeDatum3), new Actions.PlaceWall(69, true));
			structures.AddStructure(bounds, 2);
			return true;
		}
	}
}