using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria;

namespace Terraria.World.Generation
{
	public class WorldGenerator
	{
		private List<GenPass> _passes = new List<GenPass>();

		private float _totalLoadWeight;

		private int _seed;

		public WorldGenerator(int seed)
		{
			this._seed = seed;
		}

		public void Append(GenPass pass)
		{
			this._passes.Add(pass);
			WorldGenerator weight = this;
			weight._totalLoadWeight = weight._totalLoadWeight + pass.Weight;
		}

		public void GenerateWorld(GenerationProgress progress = null)
		{
			Stopwatch stopwatch = new Stopwatch();
			float weight = 0f;
			foreach (GenPass _pass in this._passes)
			{
				weight = weight + _pass.Weight;
			}
			if (progress == null)
			{
				progress = new GenerationProgress();
			}
			progress.TotalWeight = weight;
			Main.menuMode = 888;
			foreach (GenPass genPass in this._passes)
			{
				WorldGen._genRand = new Random(this._seed);
				Main.rand = new Random(this._seed);
				stopwatch.Start();
				progress.Start(genPass.Weight);
				genPass.Apply(progress);
				progress.End();
				stopwatch.Reset();
			}
		}
	}
}