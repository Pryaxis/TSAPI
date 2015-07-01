using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
	internal class ThinIceBiome : MicroBiome
	{
		public ThinIceBiome()
		{
		}

		public override bool Place(Point origin, StructureMap structures)
		{
			Dictionary<ushort, int> nums = new Dictionary<ushort, int>();
			Point point = new Point(origin.X - 25, origin.Y - 25);
			Shapes.Rectangle rectangle = new Shapes.Rectangle(50, 50);
			ushort[] numArray = new ushort[] { 0, 59, 147, 1 };
			WorldUtils.Gen(point, rectangle, (new Actions.TileScanner(numArray)).Output(nums));
			int item = nums[0] + nums[1];
			int num = nums[59];
			int item1 = nums[147];
			if (item1 <= num || item1 <= item)
			{
				return false;
			}
			int num1 = 0;
			for (int i = GenBase._random.Next(10, 15); i > 5; i--)
			{
				int num2 = GenBase._random.Next(-5, 5);
				Point point1 = new Point(origin.X + num2, origin.Y + num1);
				Shapes.Circle circle = new Shapes.Circle(i);
				GenAction[] blotch = new GenAction[] { new Modifiers.Blotches(4, 0.3), null, null };
				ushort[] numArray1 = new ushort[] { 147, 161, 224, 0, 1 };
				blotch[1] = new Modifiers.OnlyTiles(numArray1);
				blotch[2] = new Actions.SetTile(162, true, true);
				WorldUtils.Gen(point1, circle, Actions.Chain(blotch));
				Point point2 = new Point(origin.X + num2, origin.Y + num1);
				Shapes.Circle circle1 = new Shapes.Circle(i);
				GenAction[] genActionArray = new GenAction[] { new Modifiers.Blotches(4, 0.3), new Modifiers.HasLiquid(-1, -1), new Actions.SetTile(162, true, true), new Actions.SetLiquid(0, 0) };
				WorldUtils.Gen(point2, circle1, Actions.Chain(genActionArray));
				num1 = num1 + (i - 2);
			}
			return true;
		}
	}
}