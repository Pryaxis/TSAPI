using XNA;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ShapeFloodFill : GenShape
	{
		private int _maximumActions;

		public ShapeFloodFill(int maximumActions = 100)
		{
			this._maximumActions = maximumActions;
		}

		public override bool Perform(Point origin, GenAction action)
		{
			Queue<Point> points = new Queue<Point>();
			HashSet<Point16> point16s = new HashSet<Point16>();
			points.Enqueue(origin);
			int num = this._maximumActions;
			while (points.Count > 0)
			{
				if (num > 0)
				{
					Point point = points.Dequeue();
					if (point16s.Contains(new Point16(point.X, point.Y)) || !base.UnitApply(action, origin, point.X, point.Y, new object[0]))
					{
						continue;
					}
					point16s.Add(new Point16(point));
					num--;
					if (point.X + 1 < Main.maxTilesX - 1)
					{
						points.Enqueue(new Point(point.X + 1, point.Y));
					}
					if (point.X - 1 >= 1)
					{
						points.Enqueue(new Point(point.X - 1, point.Y));
					}
					if (point.Y + 1 < Main.maxTilesY - 1)
					{
						points.Enqueue(new Point(point.X, point.Y + 1));
					}
					if (point.Y - 1 < 1)
					{
						continue;
					}
					points.Enqueue(new Point(point.X, point.Y - 1));
				}
				else
				{
					break;
				}
			}
			while (points.Count > 0)
			{
				Point point1 = points.Dequeue();
				if (point16s.Contains(new Point16(point1.X, point1.Y)))
				{
					continue;
				}
				points.Enqueue(point1);
				break;
			}
			return points.Count == 0;
		}
	}
}