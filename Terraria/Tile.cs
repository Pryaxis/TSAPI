using System;
namespace Terraria
{
	public class Tile
	{
		public bool active;
		public byte type;
		public byte wall;
		public byte wallFrameX;
		public byte wallFrameY;
		public byte wallFrameNumber;
		public bool wire;
		public byte liquid;
		public bool checkingLiquid;
		public bool skipLiquid;
		public bool lava;
		public byte frameNumber;
		public short frameX;
		public short frameY;
		public object Clone()
		{
			return base.MemberwiseClone();
		}
		public bool isTheSameAs(Tile compTile)
		{
			if (this.active != compTile.active)
			{
				return false;
			}
			if (this.active)
			{
				if (this.type != compTile.type)
				{
					return false;
				}
				if (Main.tileFrameImportant[(int)this.type])
				{
					if (this.frameX != compTile.frameX)
					{
						return false;
					}
					if (this.frameY != compTile.frameY)
					{
						return false;
					}
				}
			}
			return this.wall == compTile.wall && this.liquid == compTile.liquid && this.lava == compTile.lava && this.wire == compTile.wire;
		}
	}
}
