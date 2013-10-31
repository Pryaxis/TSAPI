using System;
namespace Terraria
{
	public class Tile
	{
		public byte type;
		public byte wall;
		public byte liquid;
		public byte tileHeader;
		public byte tileHeader2;
		public byte tileHeader3;
		public byte tileHeader4;
		public byte tileHeader5;
		public short frameX;
		public short frameY;
		public object Clone()
		{
			return base.MemberwiseClone();
		}
		public bool isTheSameAs(Tile compTile)
		{
			if (compTile == null)
			{
				return false;
			}
			if (this.active() != compTile.active())
			{
				return false;
			}
			if (this.active())
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
			if (this.wall != compTile.wall)
			{
				return false;
			}
			if (this.liquid != compTile.liquid)
			{
				return false;
			}
			if (this.liquid > 0)
			{
				if (this.lava() != compTile.lava())
				{
					return false;
				}
				if (this.honey() != compTile.honey())
				{
					return false;
				}
			}
			return this.wire() == compTile.wire() && this.wire2() == compTile.wire2() && this.wire3() == compTile.wire3() && this.halfBrick() == compTile.halfBrick() && this.actuator() == compTile.actuator() && this.inActive() == compTile.inActive() && this.wallColor() == compTile.wallColor() && this.color() == compTile.color() && this.slope() == compTile.slope();
		}
		public byte wallFrameX()
		{
			return (byte)(((this.tileHeader4 & 240) >> 4) * 18);
		}
		public void wallFrameX(int wallFrameX)
		{
			this.tileHeader4 = (byte)((int)(this.tileHeader4 & 15) | (wallFrameX / 18 & 15) << 4);
		}
		public byte wallFrameY()
		{
			return (byte)((this.tileHeader5 & 7) * 18);
		}
		public void wallFrameY(int wallFrameY)
		{
			this.tileHeader5 = (byte)((int)(this.tileHeader5 & 248) | (wallFrameY / 18 & 7));
		}
		public byte frameNumber()
		{
			return (byte)(this.tileHeader4 & 3);
		}
		public void frameNumber(byte frameNumber)
		{
			this.tileHeader4 = (byte)((this.tileHeader4 & 252) | (frameNumber & 3));
		}
		public byte wallFrameNumber()
		{
			return (byte)((this.tileHeader4 & 12) >> 2);
		}
		public void wallFrameNumber(byte wallFrameNumber)
		{
			this.tileHeader4 = (byte)((int)(this.tileHeader4 & 243) | (int)(wallFrameNumber & 3) << 2);
		}
		public byte slope()
		{
			return (byte)((this.tileHeader3 & 48) >> 4);
		}
		public void slope(byte slope)
		{
			this.tileHeader3 = (byte)((int)(this.tileHeader3 & 207) | (int)(slope & 3) << 4);
		}
		public byte color()
		{
			return (byte)((this.tileHeader2 & 124) >> 2);
		}
		public void color(byte color)
		{
			if (color > 27)
			{
				color = 27;
			}
			this.tileHeader2 = (byte)((int)(this.tileHeader2 & 131) | (int)(color & 31) << 2);
		}
		public byte wallColor()
		{
			return (byte)((this.tileHeader2 & 128) >> 7 | (int)(this.tileHeader3 & 15) << 1);
		}
		public void wallColor(byte wallColor)
		{
			if (wallColor > 27)
			{
				wallColor = 27;
			}
			this.tileHeader2 = (byte)((int)(this.tileHeader2 & 127) | (int)(wallColor & 1) << 7);
			this.tileHeader3 = (byte)((int)(this.tileHeader3 & 240) | (wallColor & 30) >> 1);
		}
		public bool lava()
		{
			return (this.tileHeader & 8) == 8;
		}
		public void lava(bool lava)
		{
			if (lava)
			{
				this.tileHeader |= 8;
				this.tileHeader3 &= 191;
				return;
			}
			this.tileHeader &= 247;
		}
		public bool honey()
		{
			return (this.tileHeader3 & 64) == 64;
		}
		public void honey(bool honey)
		{
			if (honey)
			{
				this.tileHeader3 |= 64;
				this.tileHeader &= 247;
				return;
			}
			this.tileHeader3 &= 191;
		}
		public void liquidType(int liquidType)
		{
			if (liquidType == 0)
			{
				this.honey(false);
				this.lava(false);
			}
			if (liquidType == 1)
			{
				this.honey(false);
				this.lava(true);
			}
			if (liquidType == 2)
			{
				this.honey(true);
				this.lava(false);
			}
		}
		public byte liquidType()
		{
			if (this.honey())
			{
				return 2;
			}
			if (!this.lava())
			{
				return 0;
			}
			return 1;
		}
		public bool checkingLiquid()
		{
			return (this.tileHeader & 2) == 2;
		}
		public void checkingLiquid(bool checkingLiquid)
		{
			if (checkingLiquid)
			{
				this.tileHeader |= 2;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -3);
		}
		public bool skipLiquid()
		{
			return (this.tileHeader & 4) == 4;
		}
		public void skipLiquid(bool skipLiquid)
		{
			if (skipLiquid)
			{
				this.tileHeader |= 4;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -5);
		}
		public bool wire()
		{
			return (this.tileHeader & 16) == 16;
		}
		public void wire(bool wire)
		{
			if (wire)
			{
				this.tileHeader |= 16;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -17);
		}
		public bool halfBrick()
		{
			return (this.tileHeader & 32) == 32;
		}
		public void halfBrick(bool halfBrick)
		{
			if (halfBrick)
			{
				this.tileHeader |= 32;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -33);
		}
		public bool actuator()
		{
			return (this.tileHeader & 64) == 64;
		}
		public void actuator(bool actuator)
		{
			if (actuator)
			{
				this.tileHeader |= 64;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -65);
		}
		public bool nactive()
		{
			return ((this.tileHeader & 1) != 1 || (this.tileHeader & 128) != 128) && (this.tileHeader & 1) == 1;
		}
		public bool inActive()
		{
			return (this.tileHeader & 128) == 128;
		}
		public void inActive(bool inActive)
		{
			if (inActive)
			{
				this.tileHeader |= 128;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -129);
		}
		public bool active()
		{
			return (this.tileHeader & 1) == 1;
		}
		public void active(bool active)
		{
			if (active)
			{
				this.tileHeader |= 1;
				return;
			}
			this.tileHeader = (byte)((int)this.tileHeader & -2);
		}
		public bool wire2()
		{
			return (this.tileHeader2 & 1) == 1;
		}
		public void wire2(bool wire2)
		{
			if (wire2)
			{
				this.tileHeader2 |= 1;
				return;
			}
			this.tileHeader2 = (byte)((int)this.tileHeader2 & -2);
		}
		public bool wire3()
		{
			return (this.tileHeader2 & 2) == 2;
		}
		public void wire3(bool wire3)
		{
			if (wire3)
			{
				this.tileHeader2 |= 2;
				return;
			}
			this.tileHeader2 = (byte)((int)this.tileHeader2 & -3);
		}
		public Color actColor(Color oldColor)
		{
			if (this.inActive())
			{
				float num = 0.4f;
				int r = (int)((byte)(num * (float)oldColor.R));
				int g = (int)((byte)(num * (float)oldColor.G));
				int b = (int)((byte)(num * (float)oldColor.B));
				return new Color(r, g, b, (int)oldColor.A);
			}
			return oldColor;
		}
	}
}
