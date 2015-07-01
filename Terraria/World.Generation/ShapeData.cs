using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;

namespace Terraria.World.Generation
{
	internal class ShapeData
	{
		private HashSet<Point16> _points;

		public int Count
		{
			get
			{
				return this._points.Count;
			}
		}

		public ShapeData()
		{
			this._points = new HashSet<Point16>();
		}

		public ShapeData(ShapeData original)
		{
			this._points = new HashSet<Point16>(original._points);
		}

		public void Add(int x, int y)
		{
			this._points.Add(new Point16(x, y));
		}

		public void Add(ShapeData shapeData, Point localOrigin, Point remoteOrigin)
		{
			foreach (Point16 datum in shapeData.GetData())
			{
				this.Add(remoteOrigin.X - localOrigin.X + datum.X, remoteOrigin.Y - localOrigin.Y + datum.Y);
			}
		}

		public void Clear()
		{
			this._points.Clear();
		}

		public bool Contains(int x, int y)
		{
			return this._points.Contains(new Point16(x, y));
		}

		public static Rectangle GetBounds(Point origin, params ShapeData[] shapes)
		{
			int x = shapes[0]._points.First<Point16>().X;
			int num = x;
			int y = shapes[0]._points.First<Point16>().Y;
			int num1 = y;
			for (int i = 0; i < (int)shapes.Length; i++)
			{
				foreach (Point16 _point in shapes[i]._points)
				{
					x = Math.Max(x, _point.X);
					num = Math.Min(num, _point.X);
					y = Math.Max(y, _point.Y);
					num1 = Math.Min(num1, _point.Y);
				}
			}
			return new Rectangle(num + origin.X, num1 + origin.Y, x - num, y - num1);
		}

		public HashSet<Point16> GetData()
		{
			return this._points;
		}

		public void Remove(int x, int y)
		{
			this._points.Remove(new Point16(x, y));
		}

		public void Subtract(ShapeData shapeData, Point localOrigin, Point remoteOrigin)
		{
			foreach (Point16 datum in shapeData.GetData())
			{
				this.Remove(remoteOrigin.X - localOrigin.X + datum.X, remoteOrigin.Y - localOrigin.Y + datum.Y);
			}
		}
	}
}