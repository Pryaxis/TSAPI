using System;
using Terraria.Enums;

namespace Terraria.Modules
{
	public class LiquidPlacementModule
	{
		public LiquidPlacement water;

		public LiquidPlacement lava;

		public LiquidPlacementModule(LiquidPlacementModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.water = LiquidPlacement.Allowed;
				this.lava = LiquidPlacement.Allowed;
				return;
			}
			this.water = copyFrom.water;
			this.lava = copyFrom.lava;
		}
	}
}