using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ActionVines : GenAction
	{
		private int _minLength;

		private int _maxLength;

		private int _vineId;

		public ActionVines(int minLength = 6, int maxLength = 10, int vineId = 52)
		{
			this._minLength = minLength;
			this._maxLength = maxLength;
			this._vineId = vineId;
		}

		public override bool Apply(Point origin, int x, int y, params object[] args)
		{
			int i;
			int num = GenBase._random.Next(this._minLength, this._maxLength + 1);
			for (i = 0; i < num && !GenBase._tiles[x, y + i].active(); i++)
			{
				GenBase._tiles[x, y + i].type = (ushort)this._vineId;
				GenBase._tiles[x, y + i].active(true);
			}
			if (i <= 0)
			{
				return false;
			}
			return base.UnitApply(origin, x, y, args);
		}
	}
}