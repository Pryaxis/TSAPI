using System;

namespace Terraria.DataStructures
{
	public struct PlacementHook
	{
		public const int Response_AllInvalid = 0;

		public Func<int, int, int, int, int, int> hook;

		public int badReturn;

		public int badResponse;

		public bool processedCoordinates;

		public static PlacementHook Empty;

		static PlacementHook()
		{
			PlacementHook.Empty = new PlacementHook(null, 0, 0, false);
		}

		public PlacementHook(Func<int, int, int, int, int, int> hook, int badReturn, int badResponse, bool processedCoordinates)
		{
			this.hook = hook;
			this.badResponse = badResponse;
			this.badReturn = badReturn;
			this.processedCoordinates = processedCoordinates;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is PlacementHook))
			{
				return false;
			}
			return this == (PlacementHook)obj;
		}

		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		public static bool operator ==(PlacementHook first, PlacementHook second)
		{
			if (!(first.hook == second.hook) || first.badResponse != second.badResponse || first.badReturn != second.badReturn)
			{
				return false;
			}
			return first.processedCoordinates == second.processedCoordinates;
		}

		public static bool operator !=(PlacementHook first, PlacementHook second)
		{
			if (first.hook != second.hook || first.badResponse != second.badResponse || first.badReturn != second.badReturn)
			{
				return true;
			}
			return first.processedCoordinates != second.processedCoordinates;
		}
	}
}