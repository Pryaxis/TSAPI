using System;

namespace Terraria.World.Generation
{
	public abstract class GenPass : GenBase
	{
		public string Name;

		public float Weight;

		public GenPass(string name, float loadWeight)
		{
			this.Name = name;
			this.Weight = loadWeight;
		}

		public abstract void Apply(GenerationProgress progress);
	}
}