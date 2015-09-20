
using System;
using System.IO;

namespace Terraria
{
	public class WaterfallManager
	{
		private const int minWet = 160;

		private const int maxCount = 200;

		private const int maxLength = 100;

		private const int maxTypes = 22;

		private int qualityMax;

		private int currentMax;

		private WaterfallManager.WaterfallData[] waterfalls;

		private int wFallFrCounter;

		private int regularFrame;

		private int wFallFrCounter2;

		private int slowFrame;

		private int rainFrameCounter;

		private int rainFrameForeground;

		private int rainFrameBackground;

		private int findWaterfallCount;

		private int waterfallDist = 100;

		public WaterfallManager()
		{
			this.waterfalls = new WaterfallManager.WaterfallData[200];
		}

		public bool CheckForWaterfall(int i, int j)
		{
			for (int num = 0; num < this.currentMax; num++)
			{
				if (this.waterfalls[num].x == i && this.waterfalls[num].y == j)
				{
					return true;
				}
			}
			return false;
		}

		public void Draw()
		{
		}

		private void DrawWaterfall(int Style = 0, float Alpha = 1f)
		{
		}

		public void UpdateFrame()
		{
		}

		public struct WaterfallData
		{
			public int x;

			public int y;

			public int type;

			public int stopAtStep;
		}
	}
}