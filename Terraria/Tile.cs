#define TILE_BITPACK
//#define TILE_DEBUG
using System;
using System.Runtime.InteropServices;

namespace Terraria
{
	public sealed class Tile
	{
		public byte liquid;
		public byte type;
		public byte wall;
		public byte wallFrameNumber;
		public byte wallFrameX;
		public byte wallFrameY;
		public short frameX;
		public short frameY;

#if TILE_BITPACK
		public TileFlag Flags;

		public bool active
		{
			get { return (byte)(Flags & TileFlag.Active) != 0; }
			set { this.SetFlag(TileFlag.Active, value); }
		}

		public bool checkingLiquid
		{
			get { return (byte)(Flags & TileFlag.CheckingLiquid) != 0; }
			set { this.SetFlag(TileFlag.CheckingLiquid, value); }
		}

		public byte frameNumber
		{
			get { return (byte)(Flags & (TileFlag)3); }
			set { Flags = ((Flags & (TileFlag)252) | (TileFlag)value); }
		}

		public bool lava
		{
			get { return (byte)(Flags & TileFlag.Lava) != 0; }
			set { this.SetFlag(TileFlag.Lava, value); }
		}

		public bool lighted
		{
			get { return (byte)(Flags & TileFlag.Lighted) != 0; }
			set { this.SetFlag(TileFlag.Lighted, value); }
		}

		public bool skipLiquid
		{
			get { return (byte)(Flags & TileFlag.SkipLiquid) != 0; }
			set { this.SetFlag(TileFlag.SkipLiquid, value); }
		}

		public bool wire
		{
			get { return (byte)(Flags & TileFlag.Wire) != 0; }
			set { this.SetFlag(TileFlag.Wire, value); }
		}

		private void SetFlag(TileFlag flag, bool set)
		{
			if (set)
				Flags |= flag;
			else
				Flags &= ~flag;
		}
#else
		public byte frameNumber;
		public bool active;
		public bool checkingLiquid;
		public bool lava;
		public bool lighted;
		public bool skipLiquid;
		public bool wire;
#endif
		[Obsolete("Direct Access of TileData is now deprecicated please use the Tile object instead")]
		public TileData Data
		{
			get
			{
				TileData data = new TileData();
				data.active = active;
				data.checkingLiquid = checkingLiquid;
				data.frameNumber = frameNumber;
				data.frameX = frameX;
				data.frameY = frameY;
				data.lava = lava;
				data.lighted = lighted;
				data.liquid = liquid;
				data.skipLiquid = skipLiquid;
				data.type = type;
				data.wall = wall;
				data.wallFrameNumber = wallFrameNumber;
				data.wallFrameX = wallFrameX;
				data.wallFrameY = wallFrameY;
				data.wire = this.wire;
				return data;
			}
			set
			{
				active = value.active;
				checkingLiquid = value.checkingLiquid;
				frameNumber = value.frameNumber;
				frameX = value.frameX;
				frameY = value.frameY;
				lava = value.lava;
				lighted = value.lighted;
				liquid = value.liquid;
				skipLiquid = value.skipLiquid;
				type = value.type;
				wall = value.wall;
				wallFrameNumber = value.wallFrameNumber;
				wallFrameX = value.wallFrameX;
				wallFrameY = value.wallFrameY;
				wire = this.wire;
			}
		}

		public bool isTheSameAs(Tile compTile)
		{
			if (this.active != compTile.active)
			{
				return false;
			}
			if (this.active)
			{
				if (type != compTile.type)
				{
					return false;
				}
				if (Main.tileFrameImportant[(int)type])
				{
					if (frameX != compTile.frameX || frameY != compTile.frameY)
					{
						return false;
					}
				}
			}
			return wall == compTile.wall && liquid == compTile.liquid && this.lava == compTile.lava && this.wire == compTile.wire;
		}
	}

	public class TileCollection
	{
		static Tile[] tiles;
		static int x;
		static int y;
#if TILE_DEBUG
		static int Count = 0;
		static int AccessCount = 0;
		public string status
		{
			get { return string.Format("Status: {0} elements, {1} accesses, {2}x{3} = {4} => {5}%", Count, AccessCount, x, y, x*y, Count / ((x*y) / 100)); }
		}
#else
		public readonly string status = string.Empty;
#endif

		public void clear(int x, int y)
		{
			tiles[x * TileCollection.y + y] = null;
		}

		public void reset()
		{
			tiles = new Tile[x * y + y];
		}

		public Tile this[int x, int y]
		{
			get
			{
#if TILE_DEBUG
				AccessCount++;
#endif
				int idx = x * TileCollection.y + y;
				Tile tile = tiles[idx];
				if (null == tile)
				{
					tile = new Tile();
					tiles[idx] = tile;
#if TILE_DEBUG
					Count++;
#endif
				}
				return tile;
			}
			set { tiles[x * TileCollection.y + y] = value; }
		}
		internal void SetSize(int x, int y)
		{
			TileCollection.x = x;
			TileCollection.y = y;
			tiles = new Tile[x * y + y];
		}
	}

	[Obsolete("Use of TileData is now deprecicated please use the Tile object instead")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TileData
	{
		public byte liquid;
		public byte type;
		public byte wall;
		public byte wallFrameNumber;
		public byte wallFrameX;
		public byte wallFrameY;
		public short frameX;
		public short frameY;

#if TILE_BITPACK
		public bool active
		{
			get { return (byte)(this.Flags & TileFlag.Active) != 0; }
			set { this.SetFlag(TileFlag.Active, value); }
		}

		public bool checkingLiquid
		{
			get { return (byte)(this.Flags & TileFlag.CheckingLiquid) != 0; }
			set { this.SetFlag(TileFlag.CheckingLiquid, value); }
		}

		public byte frameNumber
		{
			get { return (byte)(this.Flags & (TileFlag)3); }
			set { this.Flags = ((this.Flags & (TileFlag)252) | (TileFlag)value); }
		}

		public bool lava
		{
			get { return (byte)(this.Flags & TileFlag.Lava) != 0; }
			set { this.SetFlag(TileFlag.Lava, value); }
		}

		public bool lighted
		{
			get { return (byte)(this.Flags & TileFlag.Lighted) != 0; }
			set { this.SetFlag(TileFlag.Lighted, value); }
		}

		public bool skipLiquid
		{
			get { return (byte)(this.Flags & TileFlag.SkipLiquid) != 0; }
			set { this.SetFlag(TileFlag.SkipLiquid, value); }
		}

		public bool wire
		{
			get { return (byte)(this.Flags & TileFlag.Wire) != 0; }
			set { this.SetFlag(TileFlag.Wire, value); }
		}

		private void SetFlag(TileFlag flag, bool set)
		{
			if (set)
				Flags |= flag;
			else
				Flags &= ~flag;
		}

		private TileFlag Flags;
#else

		public bool active;
		public bool checkingLiquid;
		public byte frameNumber;
		public bool lava;
		public bool lighted;
		public bool skipLiquid;
		public bool wire;
#endif
	}

	public enum TileFlag : byte
	{
		Unknown,
		Reserved1,
		Wire = 4,
		Active = 8,
		SkipLiquid = 16,
		Lighted = 32,
		CheckingLiquid = 64,
		Lava = 128
	}
}
/*using System;
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
}*/
