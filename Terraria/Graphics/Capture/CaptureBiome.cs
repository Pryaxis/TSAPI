using System;

namespace Terraria.Graphics.Capture
{
	public class CaptureBiome
	{
		public static CaptureBiome[] Biomes;

		public readonly int WaterStyle;

		public readonly int BackgroundIndex;

		public readonly int BackgroundIndex2;

		public readonly CaptureBiome.TileColorStyle TileColor;

		static CaptureBiome()
		{
			CaptureBiome[] captureBiome = new CaptureBiome[] { new CaptureBiome(0, 0, 0, CaptureBiome.TileColorStyle.Normal), null, new CaptureBiome(1, 2, 2, CaptureBiome.TileColorStyle.Corrupt), new CaptureBiome(3, 0, 3, CaptureBiome.TileColorStyle.Jungle), new CaptureBiome(6, 2, 4, CaptureBiome.TileColorStyle.Normal), new CaptureBiome(7, 4, 5, CaptureBiome.TileColorStyle.Normal), new CaptureBiome(2, 1, 6, CaptureBiome.TileColorStyle.Normal), new CaptureBiome(9, 6, 7, CaptureBiome.TileColorStyle.Mushroom), new CaptureBiome(0, 0, 8, CaptureBiome.TileColorStyle.Normal), null, new CaptureBiome(8, 5, 10, CaptureBiome.TileColorStyle.Crimson), null };
			CaptureBiome.Biomes = captureBiome;
		}

		public CaptureBiome(int backgroundIndex, int backgroundIndex2, int waterStyle, CaptureBiome.TileColorStyle tileColorStyle = 0)
		{
			this.BackgroundIndex = backgroundIndex;
			this.BackgroundIndex2 = backgroundIndex2;
			this.WaterStyle = waterStyle;
			this.TileColor = tileColorStyle;
		}

		public enum TileColorStyle
		{
			Normal,
			Jungle,
			Crimson,
			Corrupt,
			Mushroom
		}
	}
}