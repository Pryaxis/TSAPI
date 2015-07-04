
using System;

namespace Terraria.World.Generation
{
	internal abstract class GenSearch : GenBase
	{
		public static Point NOT_FOUND;

		private bool _requireAll = true;

		private GenCondition[] _conditions;

		static GenSearch()
		{
			GenSearch.NOT_FOUND = new Point(2147483647, 2147483647);
		}

		protected GenSearch()
		{
		}

		protected bool Check(int x, int y)
		{
			for (int i = 0; i < (int)this._conditions.Length; i++)
			{
				if (this._requireAll ^ this._conditions[i].IsValid(x, y))
				{
					return !this._requireAll;
				}
			}
			return this._requireAll;
		}

		public GenSearch Conditions(params GenCondition[] conditions)
		{
			this._conditions = conditions;
			return this;
		}

		public abstract Point Find(Point origin);

		public GenSearch RequireAll(bool mode)
		{
			this._requireAll = mode;
			return this;
		}
	}
}