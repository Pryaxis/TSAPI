
using System;
using System.Collections.Generic;

namespace Terraria.World.Generation
{
	public static class Biomes<T>
	where T : MicroBiome, new()
	{
		private static T _microBiome;

		static Biomes()
		{
			Biomes<T>._microBiome = Biomes<T>.CreateInstance();
		}

		private static T CreateInstance()
		{
			T t = Activator.CreateInstance<T>();
			BiomeCollection.Biomes.Add(t);
			return t;
		}

		public static T Get()
		{
			return Biomes<T>._microBiome;
		}

		public static bool Place(int x, int y, StructureMap structures)
		{
			return Biomes<T>._microBiome.Place(new Point(x, y), structures);
		}

		public static bool Place(Point origin, StructureMap structures)
		{
			return Biomes<T>._microBiome.Place(origin, structures);
		}
	}
}