using System;

namespace Terraria.Modules
{
	public class TileObjectStyleModule
	{
		public int style;

		public bool horizontal;

		public int styleWrapLimit;

		public int styleMultiplier;

		public TileObjectStyleModule(TileObjectStyleModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.style = 0;
				this.horizontal = false;
				this.styleWrapLimit = 0;
				this.styleMultiplier = 1;
				return;
			}
			this.style = copyFrom.style;
			this.horizontal = copyFrom.horizontal;
			this.styleWrapLimit = copyFrom.styleWrapLimit;
			this.styleMultiplier = copyFrom.styleMultiplier;
		}
	}
}