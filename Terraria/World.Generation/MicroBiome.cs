using System;
using System.Collections.Generic;

namespace Terraria.World.Generation
{
	public abstract class MicroBiome : GenStructure
	{
		public MicroBiome()
		{
		}

		public virtual void Reset()
		{
		}

		public static void ResetAll()
		{
			foreach (MicroBiome biome in BiomeCollection.Biomes)
			{
				biome.Reset();
			}
		}
	}
}