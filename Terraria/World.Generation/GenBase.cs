using System;
using Terraria;

namespace Terraria.World.Generation
{
	public class GenBase
	{
		protected static Random _random
		{
			get
			{
				return WorldGen.genRand;
			}
		}

		protected static Tile[,] _tiles
		{
			get
			{
				return Main.tile;
			}
		}

		protected static int _worldHeight
		{
			get
			{
				return Main.maxTilesY;
			}
		}

		protected static int _worldWidth
		{
			get
			{
				return Main.maxTilesX;
			}
		}

		public GenBase()
		{
		}

		public delegate bool CustomPerUnitAction(int x, int y, params object[] args);
	}
}