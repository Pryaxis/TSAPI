
using System;
using System.Runtime.CompilerServices;
using Terraria;

namespace Terraria.World.Generation
{
	internal static class Shapes
	{
		public class Circle : GenShape
		{
			private int _verticalRadius;

			private int _horizontalRadius;

			public Circle(int radius)
			{
				this._verticalRadius = radius;
				this._horizontalRadius = radius;
			}

			public Circle(int horizontalRadius, int verticalRadius)
			{
				this._horizontalRadius = horizontalRadius;
				this._verticalRadius = verticalRadius;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				int num = (this._horizontalRadius + 1) * (this._horizontalRadius + 1);
				for (int i = origin.Y - this._verticalRadius; i <= origin.Y + this._verticalRadius; i++)
				{
					float y = (float)this._horizontalRadius / (float)this._verticalRadius * (float)(i - origin.Y);
					int num1 = Math.Min(this._horizontalRadius, (int)Math.Sqrt((double)((float)num - y * y)));
					for (int j = origin.X - num1; j <= origin.X + num1; j++)
					{
						if (!base.UnitApply(action, origin, j, i, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public class HalfCircle : GenShape
		{
			private int _radius;

			public HalfCircle(int radius)
			{
				this._radius = radius;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				int num = (this._radius + 1) * (this._radius + 1);
				for (int i = origin.Y - this._radius; i <= origin.Y; i++)
				{
					int num1 = Math.Min(this._radius, (int)Math.Sqrt((double)(num - (i - origin.Y) * (i - origin.Y))));
					for (int j = origin.X - num1; j <= origin.X + num1; j++)
					{
						if (!base.UnitApply(action, origin, j, i, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public class Mound : GenShape
		{
			private int _halfWidth;

			private int _height;

			public Mound(int halfWidth, int height)
			{
				this._halfWidth = halfWidth;
				this._height = height;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				float single = (float)this._halfWidth;
				for (int i = -this._halfWidth; i <= this._halfWidth; i++)
				{
					int num = Math.Min(this._height, (int)(-((float)(this._height + 1) / (single * single)) * ((float)i + single) * ((float)i - single)));
					for (int j = 0; j < num; j++)
					{
						if (!base.UnitApply(action, origin, i + origin.X, origin.Y - j, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public class Rectangle : GenShape
		{
			private int _width;

			private int _height;

			public Rectangle(int width, int height)
			{
				this._width = width;
				this._height = height;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				for (int i = origin.X; i < origin.X + this._width; i++)
				{
					for (int j = origin.Y; j < origin.Y + this._height; j++)
					{
						if (!base.UnitApply(action, origin, i, j, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public class Slime : GenShape
		{
			private int _radius;

			private float _xScale;

			private float _yScale;

			public Slime(int radius)
			{
				this._radius = radius;
				this._xScale = 1f;
				this._yScale = 1f;
			}

			public Slime(int radius, float xScale, float yScale)
			{
				this._radius = radius;
				this._xScale = xScale;
				this._yScale = yScale;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				float single = (float)this._radius;
				int num = (this._radius + 1) * (this._radius + 1);
				for (int i = origin.Y - (int)(single * this._yScale); i <= origin.Y; i++)
				{
					float y = (float)(i - origin.Y) / this._yScale;
					int num1 = (int)Math.Min((float)this._radius * this._xScale, this._xScale * (float)Math.Sqrt((double)((float)num - y * y)));
					for (int j = origin.X - num1; j <= origin.X + num1; j++)
					{
						if (!base.UnitApply(action, origin, j, i, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				for (int k = origin.Y + 1; k <= origin.Y + (int)(single * this._yScale * 0.5f) - 1; k++)
				{
					float y1 = (float)(k - origin.Y) * (2f / this._yScale);
					int num2 = (int)Math.Min((float)this._radius * this._xScale, this._xScale * (float)Math.Sqrt((double)((float)num - y1 * y1)));
					for (int l = origin.X - num2; l <= origin.X + num2; l++)
					{
						if (!base.UnitApply(action, origin, l, k, new object[0]) && this._quitOnFail)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		public class Tail : GenShape
		{
			private float _width;

			private Vector2 _endOffset;

			public Tail(float width, Vector2 endOffset)
			{
				this._width = width * 16f;
				this._endOffset = endOffset * 16f;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				Vector2 vector2 = new Vector2((float)(origin.X << 4), (float)(origin.Y << 4));
				return Utils.PlotTileTale(vector2, vector2 + this._endOffset, this._width, (int x, int y) => {
					if (base.UnitApply(action, origin, x, y, new object[0]))
					{
						return true;
					}
					return !this._quitOnFail;
				});
			}
		}
	}
}