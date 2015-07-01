using System;

namespace Terraria.Modules
{
	public class TileObjectDrawModule
	{
		public int yOffset;

		public bool flipHorizontal;

		public bool flipVertical;

		public int stepDown;

		public TileObjectDrawModule(TileObjectDrawModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.yOffset = 0;
				this.flipHorizontal = false;
				this.flipVertical = false;
				this.stepDown = 0;
				return;
			}
			this.yOffset = copyFrom.yOffset;
			this.flipHorizontal = copyFrom.flipHorizontal;
			this.flipVertical = copyFrom.flipVertical;
			this.stepDown = copyFrom.stepDown;
		}
	}
}