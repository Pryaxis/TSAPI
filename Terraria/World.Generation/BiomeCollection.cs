using System;
using System.Collections.Generic;

namespace Terraria.World.Generation
{
	internal static class BiomeCollection
	{
		public static List<MicroBiome> Biomes;

		static BiomeCollection()
		{
			BiomeCollection.Biomes = new List<MicroBiome>();
		}
	}
}