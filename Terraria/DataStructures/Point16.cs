using XNA;
using System;

namespace Terraria.DataStructures
{
	public struct Point16
	{
		public readonly short X;

		public readonly short Y;

		public static Point16 Zero;

		public static Point16 NegativeOne;

		static Point16()
		{
			Point16.Zero = new Point16(0, 0);
			Point16.NegativeOne = new Point16(-1, -1);
		}

		public Point16(Point point)
		{
			this.X = (short)point.X;
			this.Y = (short)point.Y;
		}

		public Point16(int X, int Y)
		{
			this.X = (short)X;
			this.Y = (short)Y;
		}

		public Point16(short X, short Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public override bool Equals(object obj)
		{
			Point16 point16 = (Point16)obj;
			if (this.X == point16.X && this.Y == point16.Y)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return this.X << 16 | (ushort)this.Y;
		}

		public static Point16 Max(int firstX, int firstY, int secondX, int secondY)
		{
			return new Point16((firstX > secondX ? firstX : secondX), (firstY > secondY ? firstY : secondY));
		}

		public Point16 Max(int compareX, int compareY)
		{
			return new Point16((this.X > compareX ? (int)this.X : compareX), (this.Y > compareY ? (int)this.Y : compareY));
		}

		public Point16 Max(Point16 compareTo)
		{
			return new Point16((this.X > compareTo.X ? this.X : compareTo.X), (this.Y > compareTo.Y ? this.Y : compareTo.Y));
		}

		public static bool operator ==(Point16 first, Point16 second)
		{
			if (first.X != second.X)
			{
				return false;
			}
			return first.Y == second.Y;
		}

		public static bool operator !=(Point16 first, Point16 second)
		{
			if (first.X != second.X)
			{
				return true;
			}
			return first.Y != second.Y;
		}

		public override string ToString()
		{
			return string.Format("{{{0}, {1}}}", this.X, this.Y);
		}
	}
}