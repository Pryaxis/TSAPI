using System;

namespace Terraria.UI
{
	public struct StyleDimension
	{
		public static StyleDimension Fill;

		public static StyleDimension Empty;

		public float Pixels;

		public float Precent;

		static StyleDimension()
		{
			StyleDimension.Fill = new StyleDimension(0f, 1f);
			StyleDimension.Empty = new StyleDimension(0f, 0f);
		}

		public StyleDimension(float pixels, float precent)
		{
			this.Pixels = pixels;
			this.Precent = precent;
		}

		public float GetValue(float containerSize)
		{
			return this.Pixels + this.Precent * containerSize;
		}

		public void Set(float pixels, float precent)
		{
			this.Pixels = pixels;
			this.Precent = precent;
		}
	}
}