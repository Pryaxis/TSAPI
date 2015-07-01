using System;
using System.Collections.Generic;
using Terraria.ObjectData;

namespace Terraria.Modules
{
	public class TileObjectSubTilesModule
	{
		public List<TileObjectData> data;

		public TileObjectSubTilesModule(TileObjectSubTilesModule copyFrom = null, List<TileObjectData> newData = null)
		{
			if (copyFrom == null)
			{
				this.data = null;
				return;
			}
			if (copyFrom.data == null)
			{
				this.data = null;
				return;
			}
			this.data = new List<TileObjectData>(copyFrom.data.Count);
			for (int i = 0; i < this.data.Count; i++)
			{
				this.data.Add(new TileObjectData(copyFrom.data[i]));
			}
		}
	}
}