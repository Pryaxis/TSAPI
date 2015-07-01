using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
	public class TileObjectCoordinatesModule
	{
		public int width;

		public int[] heights;

		public int padding;

		public Point16 paddingFix;

		public int styleWidth;

		public int styleHeight;

		public bool calculated;

		public TileObjectCoordinatesModule(TileObjectCoordinatesModule copyFrom = null, int[] drawHeight = null)
		{
			if (copyFrom == null)
			{
				this.width = 0;
				this.padding = 0;
				this.paddingFix = Point16.Zero;
				this.styleWidth = 0;
				this.styleHeight = 0;
				this.calculated = false;
				this.heights = drawHeight;
				return;
			}
			this.width = copyFrom.width;
			this.padding = copyFrom.padding;
			this.paddingFix = copyFrom.paddingFix;
			this.styleWidth = copyFrom.styleWidth;
			this.styleHeight = copyFrom.styleHeight;
			this.calculated = copyFrom.calculated;
			if (drawHeight != null)
			{
				this.heights = drawHeight;
				return;
			}
			if (copyFrom.heights == null)
			{
				this.heights = null;
				return;
			}
			this.heights = new int[(int)copyFrom.heights.Length];
			Array.Copy(copyFrom.heights, this.heights, (int)this.heights.Length);
		}
	}
}