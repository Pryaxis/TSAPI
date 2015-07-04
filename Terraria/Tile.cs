
using System;

namespace Terraria
{
	public class Tile
	{
		public const int Type_Solid = 0;

		public const int Type_Halfbrick = 1;

		public const int Type_SlopeDownRight = 2;

		public const int Type_SlopeDownLeft = 3;

		public const int Type_SlopeUpRight = 4;

		public const int Type_SlopeUpLeft = 5;

		public const int Liquid_Water = 0;

		public const int Liquid_Lava = 1;

		public const int Liquid_Honey = 2;

		public ushort type;

		public byte wall;

		public byte liquid;

		public short sTileHeader;

		public byte bTileHeader;

		public byte bTileHeader2;

		public byte bTileHeader3;

		public short frameX;

		public short frameY;

		public int collisionType
		{
			get
			{
				if (!this.active())
				{
					return 0;
				}
				if (this.halfBrick())
				{
					return 2;
				}
				if (this.slope() > 0)
				{
					return 2 + this.slope();
				}
				if (Main.tileSolid[this.type] && !Main.tileSolidTop[this.type])
				{
					return 1;
				}
				return -1;
			}
		}

		public Tile()
		{
			this.type = 0;
			this.wall = 0;
			this.liquid = 0;
			this.sTileHeader = 0;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
		}

		public Tile(Tile copy)
		{
			if (copy == null)
			{
				this.type = 0;
				this.wall = 0;
				this.liquid = 0;
				this.sTileHeader = 0;
				this.bTileHeader = 0;
				this.bTileHeader2 = 0;
				this.bTileHeader3 = 0;
				this.frameX = 0;
				this.frameY = 0;
				return;
			}
			this.type = copy.type;
			this.wall = copy.wall;
			this.liquid = copy.liquid;
			this.sTileHeader = copy.sTileHeader;
			this.bTileHeader = copy.bTileHeader;
			this.bTileHeader2 = copy.bTileHeader2;
			this.bTileHeader3 = copy.bTileHeader3;
			this.frameX = copy.frameX;
			this.frameY = copy.frameY;
		}

		public Color actColor(Color oldColor)
		{
			if (!this.inActive())
			{
				return oldColor;
			}
			double num = 0.4;
			return new Color((int)(num * (double)oldColor.R), (int)(num * (double)oldColor.G), (int)(num * (double)oldColor.B), (int)oldColor.A);
		}

		public bool active()
		{
			return (this.sTileHeader & 32) == 32;
		}

		public void active(bool active)
		{
			if (active)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 32);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 65503);
		}

		public bool actuator()
		{
			return (this.sTileHeader & 2048) == 2048;
		}

		public void actuator(bool actuator)
		{
			if (actuator)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 2048);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 63487);
		}

		public int blockType()
		{
			if (this.halfBrick())
			{
				return 1;
			}
			int num = this.slope();
			if (num > 0)
			{
				num++;
			}
			return num;
		}

		public bool bottomSlope()
		{
			byte num = this.slope();
			if (num == 3)
			{
				return true;
			}
			return num == 4;
		}

		public bool checkingLiquid()
		{
			return (this.bTileHeader3 & 8) == 8;
		}

		public void checkingLiquid(bool checkingLiquid)
		{
			if (checkingLiquid)
			{
				Tile tile = this;
				tile.bTileHeader3 = (byte)(tile.bTileHeader3 | 8);
				return;
			}
			this.bTileHeader3 = (byte)(this.bTileHeader3 & 247);
		}

		public void ClearEverything()
		{
			this.type = 0;
			this.wall = 0;
			this.liquid = 0;
			this.sTileHeader = 0;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
		}

		internal void ClearMetadata()
		{
			this.liquid = 0;
			this.sTileHeader = 0;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
		}

		public void ClearTile()
		{
			this.slope(0);
			this.halfBrick(false);
			this.active(false);
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public byte color()
		{
			return (byte)(this.sTileHeader & 31);
		}

		public void color(byte color)
		{
			if (color > 30)
			{
				color = 30;
			}
			this.sTileHeader = (short)(this.sTileHeader & 65504 | color);
		}

		public void CopyFrom(Tile from)
		{
			this.type = from.type;
			this.wall = from.wall;
			this.liquid = from.liquid;
			this.sTileHeader = from.sTileHeader;
			this.bTileHeader = from.bTileHeader;
			this.bTileHeader2 = from.bTileHeader2;
			this.bTileHeader3 = from.bTileHeader3;
			this.frameX = from.frameX;
			this.frameY = from.frameY;
		}

		public byte frameNumber()
		{
			return (byte)((this.bTileHeader2 & 48) >> 4);
		}

		public void frameNumber(byte frameNumber)
		{
			this.bTileHeader2 = (byte)(this.bTileHeader2 & 207 | (frameNumber & 3) << 4);
		}

		public bool halfBrick()
		{
			return (this.sTileHeader & 1024) == 1024;
		}

		public void halfBrick(bool halfBrick)
		{
			if (halfBrick)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 1024);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 64511);
		}

		public bool HasSameSlope(Tile tile)
		{
			return (this.sTileHeader & 29696) == (tile.sTileHeader & 29696);
		}

		public bool honey()
		{
			return (this.bTileHeader & 64) == 64;
		}

		public void honey(bool honey)
		{
			if (!honey)
			{
				this.bTileHeader = (byte)(this.bTileHeader & 191);
				return;
			}
			this.bTileHeader = (byte)(this.bTileHeader & 159 | 64);
		}

		public bool inActive()
		{
			return (this.sTileHeader & 64) == 64;
		}

		public void inActive(bool inActive)
		{
			if (inActive)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 64);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 65471);
		}

		public bool isTheSameAs(Tile compTile)
		{
			if (compTile == null)
			{
				return false;
			}
			if (this.sTileHeader != compTile.sTileHeader)
			{
				return false;
			}
			if (this.active())
			{
				if (this.type != compTile.type)
				{
					return false;
				}
				if (Main.tileFrameImportant[this.type] && (this.frameX != compTile.frameX || this.frameY != compTile.frameY))
				{
					return false;
				}
			}
			if (this.wall != compTile.wall || this.liquid != compTile.liquid)
			{
				return false;
			}
			if (compTile.liquid == 0)
			{
				if (this.wallColor() != compTile.wallColor())
				{
					return false;
				}
			}
			else if (this.bTileHeader != compTile.bTileHeader)
			{
				return false;
			}
			return true;
		}

		public bool lava()
		{
			return (this.bTileHeader & 32) == 32;
		}

		public void lava(bool lava)
		{
			if (!lava)
			{
				this.bTileHeader = (byte)(this.bTileHeader & 223);
				return;
			}
			this.bTileHeader = (byte)(this.bTileHeader & 159 | 32);
		}

		public bool leftSlope()
		{
			byte num = this.slope();
			if (num == 2)
			{
				return true;
			}
			return num == 4;
		}

		public void liquidType(int liquidType)
		{
			if (liquidType == 0)
			{
				this.bTileHeader = (byte)(this.bTileHeader & 159);
				return;
			}
			if (liquidType == 1)
			{
				this.lava(true);
				return;
			}
			if (liquidType == 2)
			{
				this.honey(true);
			}
		}

		public byte liquidType()
		{
			return (byte)((this.bTileHeader & 96) >> 5);
		}

		public bool nactive()
		{
			if ((this.sTileHeader & 96) == 32)
			{
				return true;
			}
			return false;
		}

		public void ResetToType(ushort type)
		{
			this.liquid = 0;
			this.sTileHeader = 32;
			this.bTileHeader = 0;
			this.bTileHeader2 = 0;
			this.bTileHeader3 = 0;
			this.frameX = 0;
			this.frameY = 0;
			this.type = type;
		}

		public bool rightSlope()
		{
			byte num = this.slope();
			if (num == 1)
			{
				return true;
			}
			return num == 3;
		}

		public bool skipLiquid()
		{
			return (this.bTileHeader3 & 16) == 16;
		}

		public void skipLiquid(bool skipLiquid)
		{
			if (skipLiquid)
			{
				Tile tile = this;
				tile.bTileHeader3 = (byte)(tile.bTileHeader3 | 16);
				return;
			}
			this.bTileHeader3 = (byte)(this.bTileHeader3 & 239);
		}

		public byte slope()
		{
			return (byte)((this.sTileHeader & 28672) >> 12);
		}

		public void slope(byte slope)
		{
			this.sTileHeader = (short)(this.sTileHeader & 36863 | (slope & 7) << 12);
		}

		public static void SmoothSlope(int x, int y, bool applyToNeighbors = true)
		{
			if (applyToNeighbors)
			{
				Tile.SmoothSlope(x + 1, y, false);
				Tile.SmoothSlope(x - 1, y, false);
				Tile.SmoothSlope(x, y + 1, false);
				Tile.SmoothSlope(x, y - 1, false);
			}
			Tile tile = Main.tile[x, y];
			if (!WorldGen.SolidOrSlopedTile(x, y))
			{
				return;
			}
			bool flag = !WorldGen.TileEmpty(x, y - 1);
			bool flag1 = (WorldGen.SolidOrSlopedTile(x, y - 1) ? false : flag);
			bool flag2 = WorldGen.SolidOrSlopedTile(x, y + 1);
			bool flag3 = WorldGen.SolidOrSlopedTile(x - 1, y);
			bool flag4 = WorldGen.SolidOrSlopedTile(x + 1, y);
			switch ((flag ? 1 : 0) << 3 | (flag2 ? 1 : 0) << 2 | (flag3 ? 1 : 0) << 1 | (flag4 ? 1 : 0))
			{
				case 4:
				{
					tile.slope(0);
					tile.halfBrick(true);
					return;
				}
				case 5:
				{
					tile.halfBrick(false);
					tile.slope(2);
					return;
				}
				case 6:
				{
					tile.halfBrick(false);
					tile.slope(1);
					return;
				}
				case 7:
				case 8:
				{
					tile.halfBrick(false);
					tile.slope(0);
					break;
				}
				case 9:
				{
					if (flag1)
					{
						break;
					}
					tile.halfBrick(false);
					tile.slope(4);
					return;
				}
				case 10:
				{
					if (flag1)
					{
						break;
					}
					tile.halfBrick(false);
					tile.slope(3);
					return;
				}
				default:
				{
					goto case 8;
				}
			}
		}

		public bool topSlope()
		{
			byte num = this.slope();
			if (num == 1)
			{
				return true;
			}
			return num == 2;
		}

		public byte wallColor()
		{
			return (byte)(this.bTileHeader & 31);
		}

		public void wallColor(byte wallColor)
		{
			if (wallColor > 30)
			{
				wallColor = 30;
			}
			this.bTileHeader = (byte)(this.bTileHeader & 224 | wallColor);
		}

		public byte wallFrameNumber()
		{
			return (byte)((this.bTileHeader2 & 192) >> 6);
		}

		public void wallFrameNumber(byte wallFrameNumber)
		{
			this.bTileHeader2 = (byte)(this.bTileHeader2 & 63 | (wallFrameNumber & 3) << 6);
		}

		public int wallFrameX()
		{
			return (this.bTileHeader2 & 15) * 36;
		}

		public void wallFrameX(int wallFrameX)
		{
			this.bTileHeader2 = (byte)(this.bTileHeader2 & 240 | wallFrameX / 36 & 15);
		}

		public int wallFrameY()
		{
			return (this.bTileHeader3 & 7) * 36;
		}

		public void wallFrameY(int wallFrameY)
		{
			this.bTileHeader3 = (byte)(this.bTileHeader3 & 248 | wallFrameY / 36 & 7);
		}

		public bool wire()
		{
			return (this.sTileHeader & 128) == 128;
		}

		public void wire(bool wire)
		{
			if (wire)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 128);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 65407);
		}

		public bool wire2()
		{
			return (this.sTileHeader & 256) == 256;
		}

		public void wire2(bool wire2)
		{
			if (wire2)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 256);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 65279);
		}

		public bool wire3()
		{
			return (this.sTileHeader & 512) == 512;
		}

		public void wire3(bool wire3)
		{
			if (wire3)
			{
				Tile tile = this;
				tile.sTileHeader = (short)(tile.sTileHeader | 512);
				return;
			}
			this.sTileHeader = (short)(this.sTileHeader & 65023);
		}
	}
}