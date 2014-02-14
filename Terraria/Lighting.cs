using System;
using System.Diagnostics;

namespace Terraria
{
	public class Lighting
	{
		public static int maxRenderCount = 4;
		public static int dirX;
		public static int dirY;
		public static float brightness = 1f;
		public static float defBrightness = 1f;
		public static int lightMode = 0;
		public static bool RGB = true;
		public static float oldSkyColor = 0f;
		public static float skyColor = 0f;
		public static int lightCounter = 0;
		public static int offScreenTiles = 45;
		public static int offScreenTiles2 = 35;
		public static int scrX;
		public static int scrY;
		public static int minX;
		public static int maxX;
		public static int minY;
		public static int maxY;
	}
}
