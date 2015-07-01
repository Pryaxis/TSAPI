using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ActionGrass : GenAction
	{
		public ActionGrass()
		{
		}

		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			if (GenBase._tiles[x, y].active() || GenBase._tiles[x, y - 1].active())
			{
				return false;
			}
			Random random = GenBase._random;
			ushort[] numArray = new ushort[] { 3, 73 };
			WorldGen.PlaceTile(x, y, (int)Utils.SelectRandom<ushort>(random, numArray), true, false, -1, 0);
			return base.UnitApply(origin, x, y, args);
		}
	}
}