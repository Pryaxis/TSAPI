using System;

namespace Terraria.Graphics.Effects
{
	internal static class Overlays
	{
		public static OverlayManager Scene;

		public static OverlayManager FilterFallback;

		static Overlays()
		{
			Overlays.Scene = new OverlayManager();
			Overlays.FilterFallback = new OverlayManager();
		}
	}
}