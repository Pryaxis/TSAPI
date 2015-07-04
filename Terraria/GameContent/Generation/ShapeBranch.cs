
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
	internal class ShapeBranch : GenShape
	{
		private Point _offset;

		private List<Point> _endPoints;

		public ShapeBranch()
		{
			this._offset = new Point(10, -5);
		}

		public ShapeBranch(Point offset)
		{
			this._offset = offset;
		}

		public ShapeBranch(double angle, double distance)
		{
			this._offset = new Point((int)(Math.Cos(angle) * distance), (int)(Math.Sin(angle) * distance));
		}

		public ShapeBranch OutputEndpoints(List<Point> endpoints)
		{
			this._endPoints = endpoints;
			return this;
		}

		public override bool Perform(Point origin, GenAction action)
		{
			Vector2 vector2 = new Vector2((float)this._offset.X, (float)this._offset.Y);
			float single = vector2.Length();
			int num = (int)(single / 6f);
			if (this._endPoints != null)
			{
				this._endPoints.Add(new Point(origin.X + this._offset.X, origin.Y + this._offset.Y));
			}
			if (!this.PerformSegment(origin, action, origin, new Point(origin.X + this._offset.X, origin.Y + this._offset.Y), num))
			{
				return false;
			}
			int num1 = (int)(single / 8f);
			for (int i = 0; i < num1; i++)
			{
				float single1 = ((float)i + 1f) / ((float)num1 + 1f);
				Point point = new Point((int)(single1 * (float)this._offset.X), (int)(single1 * (float)this._offset.Y));
				Vector2 vector21 = new Vector2((float)(this._offset.X - point.X), (float)(this._offset.Y - point.Y));
				Vector2 vector22 = vector21;
				double num2 = (double)(((float)GenBase._random.NextDouble() * 0.5f + 1f) * (float)((GenBase._random.Next(2) == 0 ? -1 : 1)));
				Vector2 vector23 = new Vector2();
				vector21 = vector22.RotatedBy(num2, vector23) * 0.75f;
				Point point1 = new Point((int)vector21.X + point.X, (int)vector21.Y + point.Y);
				if (this._endPoints != null)
				{
					this._endPoints.Add(new Point(point1.X + origin.X, point1.Y + origin.Y));
				}
				if (!this.PerformSegment(origin, action, new Point(point.X + origin.X, point.Y + origin.Y), new Point(point1.X + origin.X, point1.Y + origin.Y), num - 1))
				{
					return false;
				}
			}
			return true;
		}

		private bool PerformSegment(Point origin, GenAction action, Point start, Point end, int size)
		{
			size = Math.Max(1, size);
			for (int i = -(size >> 1); i < size - (size >> 1); i++)
			{
				for (int j = -(size >> 1); j < size - (size >> 1); j++)
				{
					if (!Utils.PlotLine(new Point(start.X + i, start.Y + j), end, (int tileX, int tileY) => {
						if (base.UnitApply(action, origin, tileX, tileY, new object[0]))
						{
							return true;
						}
						return !this._quitOnFail;
					}, false))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}