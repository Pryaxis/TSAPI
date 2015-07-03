using XNA;
using System;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class HoneyPatchBiome : MicroBiome
	{
		public HoneyPatchBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Point y;
			if (GenBase._tiles[origin.X, origin.Y].active() && WorldGen.SolidTile(origin.X, origin.Y))
			{
				return false;
			}
			Searches.Down down = new Searches.Down(80);
			GenCondition[] isSolid = new GenCondition[] { new Conditions.IsSolid() };
			if (!WorldUtils.Find(origin, Searches.Chain(down, isSolid), out y))
			{
				return false;
			}
			y.Y = y.Y + 2;
			Ref<int> @ref = new Ref<int>(0);
			Shapes.Circle circle = new Shapes.Circle(8);
			GenAction[] genActionArray = new GenAction[] { new Modifiers.IsSolid(), new Actions.Scanner(@ref) };
			WorldUtils.Gen(y, circle, Actions.Chain(genActionArray));
			if (@ref.Value < 20)
			{
				return false;
			}
			if (!structures.CanPlace(new Rectangle(y.X - 8, y.Y - 8, 16, 16), 0))
			{
				return false;
			}
			Shapes.Circle circle1 = new Shapes.Circle(8);
			GenAction[] radialDither = new GenAction[] { new Modifiers.RadialDither(0f, 10f), new Modifiers.IsSolid(), new Actions.SetTile(229, true, true) };
			WorldUtils.Gen(y, circle1, Actions.Chain(radialDither));
			ShapeData shapeDatum = new ShapeData();
			Shapes.Circle circle2 = new Shapes.Circle(4, 3);
			GenAction[] blotch = new GenAction[] { new Modifiers.Blotches(2, 0.3), new Modifiers.IsSolid(), new Actions.ClearTile(true), (new Modifiers.RectangleMask(-6, 6, 0, 3)).Output(shapeDatum), new Actions.SetLiquid(2, 255) };
			WorldUtils.Gen(y, circle2, Actions.Chain(blotch));
			Point point = new Point(y.X, y.Y + 1);
			ModShapes.InnerOutline innerOutline = new ModShapes.InnerOutline(shapeDatum, true);
			GenAction[] isEmpty = new GenAction[] { new Modifiers.IsEmpty(), new Modifiers.RectangleMask(-6, 6, 1, 3), new Actions.SetTile(59, true, true) };
			WorldUtils.Gen(point, innerOutline, Actions.Chain(isEmpty));
			structures.AddStructure(new Rectangle(y.X - 8, y.Y - 8, 16, 16), 0);
			return true;
		}
	}
}