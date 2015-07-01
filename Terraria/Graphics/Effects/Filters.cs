using System;

namespace Terraria.Graphics.Effects
{
	internal static class Filters
	{
		public static FilterManager Scene;

		static Filters()
		{
			Filters.Scene = new FilterManager();
		}
	}
}