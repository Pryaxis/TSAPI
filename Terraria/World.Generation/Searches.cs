
using System;

namespace Terraria.World.Generation
{
	internal static class Searches
	{
		public static GenSearch Chain(GenSearch search, params GenCondition[] conditions)
		{
			return search.Conditions(conditions);
		}

		public class Down : GenSearch
		{
			private int _maxDistance;

			public Down(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X, origin.Y + i))
					{
						return new Point(origin.X, origin.Y + i);
					}
				}
				return GenSearch.NOT_FOUND;
			}
		}

		public class Left : GenSearch
		{
			private int _maxDistance;

			public Left(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X - i, origin.Y))
					{
						return new Point(origin.X - i, origin.Y);
					}
				}
				return GenSearch.NOT_FOUND;
			}
		}

		public class Rectangle : GenSearch
		{
			private int _width;

			private int _height;

			public Rectangle(int width, int height)
			{
				this._width = width;
				this._height = height;
			}

			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._width; i++)
				{
					for (int j = 0; j < this._height; j++)
					{
						if (base.Check(origin.X + i, origin.Y + j))
						{
							return new Point(origin.X + i, origin.Y + j);
						}
					}
				}
				return GenSearch.NOT_FOUND;
			}
		}

		public class Right : GenSearch
		{
			private int _maxDistance;

			public Right(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X + i, origin.Y))
					{
						return new Point(origin.X + i, origin.Y);
					}
				}
				return GenSearch.NOT_FOUND;
			}
		}

		public class Up : GenSearch
		{
			private int _maxDistance;

			public Up(int maxDistance)
			{
				this._maxDistance = maxDistance;
			}

			public override Point Find(Point origin)
			{
				for (int i = 0; i < this._maxDistance; i++)
				{
					if (base.Check(origin.X, origin.Y - i))
					{
						return new Point(origin.X, origin.Y - i);
					}
				}
				return GenSearch.NOT_FOUND;
			}
		}
	}
}