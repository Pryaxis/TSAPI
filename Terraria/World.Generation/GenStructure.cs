
using System;

namespace Terraria.World.Generation
{
	public abstract class GenStructure : GenBase
	{
		protected GenStructure()
		{
		}

		public abstract bool Place(Point origin, StructureMap structures);
	}
}