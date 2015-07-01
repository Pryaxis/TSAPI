using System;

namespace Terraria.Modules
{
	public class LiquidDeathModule
	{
		public bool water;

		public bool lava;

		public LiquidDeathModule(LiquidDeathModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.water = false;
				this.lava = false;
				return;
			}
			this.water = copyFrom.water;
			this.lava = copyFrom.lava;
		}
	}
}