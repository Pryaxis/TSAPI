using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
	public class TilePlacementHooksModule
	{
		public PlacementHook check;

		public PlacementHook postPlaceEveryone;

		public PlacementHook postPlaceMyPlayer;

		public PlacementHook placeOverride;

		public TilePlacementHooksModule(TilePlacementHooksModule copyFrom = null)
		{
			if (copyFrom == null)
			{
				this.check = new PlacementHook();
				this.postPlaceEveryone = new PlacementHook();
				this.postPlaceMyPlayer = new PlacementHook();
				this.placeOverride = new PlacementHook();
				return;
			}
			this.check = copyFrom.check;
			this.postPlaceEveryone = copyFrom.postPlaceEveryone;
			this.postPlaceMyPlayer = copyFrom.postPlaceMyPlayer;
			this.placeOverride = copyFrom.placeOverride;
		}
	}
}