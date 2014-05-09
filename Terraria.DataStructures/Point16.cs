using System;
namespace Terraria.DataStructures
{
	public struct Point16
	{
		public short x;
		public short y;
		public Point16(int x, int y)
		{
			this.x = (short)x;
			this.y = (short)y;
		}
		public Point16(short x, short y)
		{
			this.x = x;
			this.y = y;
		}
		public override bool Equals(object obj)
		{
			Point16 point = (Point16)obj;
			return this.x == point.x && this.y == point.y;
		}
		public override int GetHashCode()
		{
			return ((int)this.x << 16) + (int)this.y;
		}
		public override string ToString()
		{
			return string.Format("{{{0}, {1}}}", this.x, this.y);
		}
	}
}
