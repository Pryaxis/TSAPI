using System;
using System.Collections.Generic;
using System.Diagnostics;
using Terraria;
using Terraria.GameContent.UI.States;
using Terraria.UI;

namespace Terraria.World.Generation
{
	internal class WorldGenerator
	{
		private List<GenPass> _passes = new List<GenPass>();

		private float _totalLoadWeight;

		public WorldGenerator()
		{
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
			string str = "";
			Main.MenuUI.SetState(new UIWorldLoad(progress));
			Main.menuMode = 888;
			foreach (GenPass genPass in this._passes)
			{
				stopwatch.Start();
				progress.Start(genPass.Weight);
				genPass.Apply(progress);
				progress.End();
				string str1 = str;
				string[] name = new string[] { str1, "Pass - ", genPass.Name, " : ", null, null };
				name[4] = stopwatch.Elapsed.TotalMilliseconds.ToString();
				name[5] = ",\n";
				str = string.Concat(name);
				stopwatch.Reset();
			}
		}
	}
}