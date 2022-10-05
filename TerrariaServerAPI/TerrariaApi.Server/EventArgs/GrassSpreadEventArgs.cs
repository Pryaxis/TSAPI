using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class GrassSpreadEventArgs : HandledEventArgs
	{
		public int TileX { get; set; }
		public int TileY { get; set; }
		public int Dirt { get; set; }
		public int Grass { get; set; }
		public bool Repeat { get; set; }
		public TileColorCache Color { get; set; }
	}
}
