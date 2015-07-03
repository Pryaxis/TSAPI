using XNA;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ActionPlaceStatue : GenAction
	{
		private int _statueIndex;

		public ActionPlaceStatue(int index = -1)
		{
			this._statueIndex = index;
		}

		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			Point16 point16;
			point16 = (this._statueIndex != -1 ? WorldGen.statueList[this._statueIndex] : WorldGen.statueList[GenBase._random.Next(2, (int)WorldGen.statueList.Length)]);
			WorldGen.PlaceTile(x, y, point16.X, true, false, -1, point16.Y);
			return base.UnitApply(origin, x, y, args);
		}
	}
}