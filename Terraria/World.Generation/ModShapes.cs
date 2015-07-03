using XNA;
using System;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.World.Generation
{
	internal static class ModShapes
	{
		public class All : GenModShape
		{
			public All(ShapeData data) : base(data)
			{
			}

			public override bool Perform(Point origin, GenAction action)
			{
				bool flag;
				HashSet<Point16>.Enumerator enumerator = this._data.GetData().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point16 current = enumerator.Current;
						if (base.UnitApply(action, origin, current.X + origin.X, current.Y + origin.Y, new object[0]) || !this._quitOnFail)
						{
							continue;
						}
						flag = false;
						return flag;
					}
					return true;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		public class InnerOutline : GenModShape
		{
			private readonly static int[] POINT_OFFSETS;

			private bool _useDiagonals;

			static InnerOutline()
			{
				ModShapes.InnerOutline.POINT_OFFSETS = new int[] { 1, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, -1, 1, -1, -1 };
			}

			public InnerOutline(ShapeData data, bool useDiagonals = true) : base(data)
			{
				this._useDiagonals = useDiagonals;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				bool flag;
				int num = (this._useDiagonals ? 16 : 8);
				HashSet<Point16>.Enumerator enumerator = this._data.GetData().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point16 current = enumerator.Current;
						bool flag1 = false;
						int num1 = 0;
						while (num1 < num)
						{
							if (this._data.Contains(current.X + ModShapes.InnerOutline.POINT_OFFSETS[num1], current.Y + ModShapes.InnerOutline.POINT_OFFSETS[num1 + 1]))
							{
								num1 = num1 + 2;
							}
							else
							{
								flag1 = true;
								break;
							}
						}
						if (!flag1 || base.UnitApply(action, origin, current.X + origin.X, current.Y + origin.Y, new object[0]) || !this._quitOnFail)
						{
							continue;
						}
						flag = false;
						return flag;
					}
					return true;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		public class OuterOutline : GenModShape
		{
			private readonly static int[] POINT_OFFSETS;

			private bool _useDiagonals;

			private bool _useInterior;

			static OuterOutline()
			{
				ModShapes.OuterOutline.POINT_OFFSETS = new int[] { 1, 0, -1, 0, 0, 1, 0, -1, 1, 1, 1, -1, -1, 1, -1, -1 };
			}

			public OuterOutline(ShapeData data, bool useDiagonals = true, bool useInterior = false) : base(data)
			{
				this._useDiagonals = useDiagonals;
				this._useInterior = useInterior;
			}

			public override bool Perform(Point origin, GenAction action)
			{
				bool flag;
				int num = (this._useDiagonals ? 16 : 8);
				HashSet<Point16>.Enumerator enumerator = this._data.GetData().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Point16 current = enumerator.Current;
						if (!this._useInterior || base.UnitApply(action, origin, current.X + origin.X, current.Y + origin.Y, new object[0]) || !this._quitOnFail)
						{
							int num1 = 0;
							while (num1 < num)
							{
								if (this._data.Contains(current.X + ModShapes.OuterOutline.POINT_OFFSETS[num1], current.Y + ModShapes.OuterOutline.POINT_OFFSETS[num1 + 1]) || base.UnitApply(action, origin, origin.X + current.X + ModShapes.OuterOutline.POINT_OFFSETS[num1], origin.Y + current.Y + ModShapes.OuterOutline.POINT_OFFSETS[num1 + 1], new object[0]) || !this._quitOnFail)
								{
									num1 = num1 + 2;
								}
								else
								{
									flag = false;
									return flag;
								}
							}
						}
						else
						{
							flag = false;
							return flag;
						}
					}
					return true;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
		}
	}
}