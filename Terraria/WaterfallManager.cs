
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

		public WaterfallManager()
		{
		}

		public bool CheckForWaterfall(int i, int j)
		{
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