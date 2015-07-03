using XNA;
using System;
using System.Collections.Generic;
using Terraria;

namespace Terraria.World.Generation
{
	internal static class Actions
	{
		public static GenAction Chain(params GenAction[] actions)
		{
			for (int i = 0; i < (int)actions.Length - 1; i++)
			{
				actions[i].NextAction = actions[i + 1];
			}
			return actions[0];
		}

		public static GenAction Continue(GenAction action)
		{
			return new Actions.ContinueWrapper(action);
		}

		public class Blank : GenAction
		{
			public Blank()
			{
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class Clear : GenAction
		{
			public Clear()
			{
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].ClearEverything();
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class ClearMetadata : GenAction
		{
			public ClearMetadata()
			{
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].ClearMetadata();
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class ClearTile : GenAction
		{
			private bool _frameNeighbors;

			public ClearTile(bool frameNeighbors = false)
			{
				this._frameNeighbors = frameNeighbors;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldUtils.ClearTile(x, y, this._frameNeighbors);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class ClearWall : GenAction
		{
			private bool _frameNeighbors;

			public ClearWall(bool frameNeighbors = false)
			{
				this._frameNeighbors = frameNeighbors;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldUtils.ClearWall(x, y, this._frameNeighbors);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class ContinueWrapper : GenAction
		{
			private GenAction _action;

			public ContinueWrapper(GenAction action)
			{
				this._action = action;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				this._action.Apply(origin, x, y, args);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class Count : GenAction
		{
			private Ref<int> _count;

			public Count(Ref<int> count)
			{
				this._count = count;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Ref<int> value = this._count;
				value.Value = value.Value + 1;
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class Custom : GenAction
		{
			private GenBase.CustomPerUnitAction _perUnit;

			public Custom(GenBase.CustomPerUnitAction perUnit)
			{
				this._perUnit = perUnit;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				bool flag = this._perUnit(x, y, args);
				return flag | base.UnitApply(origin, x, y, args);
			}
		}

		public class DebugDraw : GenAction
		{
			private Color _color;

			public DebugDraw(Color color = new Color())
			{
				this._color = color;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class HalfBlock : GenAction
		{
			private bool _value;

			public HalfBlock(bool value = true)
			{
				this._value = value;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].halfBrick(this._value);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class PlaceTile : GenAction
		{
			private ushort _type;

			private int _style;

			public PlaceTile(ushort type, int style = 0)
			{
				this._type = type;
				this._style = style;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldGen.PlaceTile(x, y, (int)this._type, true, false, -1, this._style);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class PlaceWall : GenAction
		{
			private byte _type;

			private bool _neighbors;

			public PlaceWall(byte type, bool neighbors = true)
			{
				this._type = type;
				this._neighbors = neighbors;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].wall = this._type;
				WorldGen.SquareWallFrame(x, y, true);
				if (this._neighbors)
				{
					WorldGen.SquareWallFrame(x + 1, y, true);
					WorldGen.SquareWallFrame(x - 1, y, true);
					WorldGen.SquareWallFrame(x, y - 1, true);
					WorldGen.SquareWallFrame(x, y + 1, true);
				}
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class RemoveWall : GenAction
		{
			public RemoveWall()
			{
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].wall = 0;
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class Scanner : GenAction
		{
			private Ref<int> _count;

			public Scanner(Ref<int> count)
			{
				this._count = count;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Ref<int> value = this._count;
				value.Value = value.Value + 1;
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class SetFrames : GenAction
		{
			private bool _frameNeighbors;

			public SetFrames(bool frameNeighbors = false)
			{
				this._frameNeighbors = frameNeighbors;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldUtils.TileFrame(x, y, this._frameNeighbors);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class SetHalfTile : GenAction
		{
			private bool _halfTile;

			public SetHalfTile(bool halfTile)
			{
				this._halfTile = halfTile;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].halfBrick(this._halfTile);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class SetLiquid : GenAction
		{
			private int _type;

			private byte _value;

			public SetLiquid(int type = 0, byte value = 255)
			{
				this._value = value;
				this._type = type;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].liquidType(this._type);
				GenBase._tiles[x, y].liquid = this._value;
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class SetSlope : GenAction
		{
			private int _slope;

			public SetSlope(int slope)
			{
				this._slope = slope;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				WorldGen.SlopeTile(x, y, this._slope);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class SetTile : GenAction
		{
			private ushort _type;

			private bool _doFraming;

			private bool _doNeighborFraming;

			public SetTile(ushort type, bool setSelfFrames = false, bool setNeighborFrames = true)
			{
				this._type = type;
				this._doFraming = setSelfFrames;
				this._doNeighborFraming = setNeighborFrames;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				GenBase._tiles[x, y].ResetToType(this._type);
				if (this._doFraming)
				{
					WorldUtils.TileFrame(x, y, this._doNeighborFraming);
				}
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class Smooth : GenAction
		{
			private bool _applyToNeighbors;

			public Smooth(bool applyToNeighbors = false)
			{
				this._applyToNeighbors = applyToNeighbors;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile.SmoothSlope(x, y, this._applyToNeighbors);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class SwapSolidTile : GenAction
		{
			private ushort _type;

			public SwapSolidTile(ushort type)
			{
				this._type = type;
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile tile = GenBase._tiles[x, y];
				if (!WorldGen.SolidTile(tile))
				{
					return base.Fail();
				}
				tile.ResetToType(this._type);
				return base.UnitApply(origin, x, y, args);
			}
		}

		public class TileScanner : GenAction
		{
			private ushort[] _tileIds;

			private Dictionary<ushort, int> _tileCounts;

			public TileScanner(params ushort[] tiles)
			{
				this._tileIds = tiles;
				this._tileCounts = new Dictionary<ushort, int>();
				for (int i = 0; i < (int)tiles.Length; i++)
				{
					this._tileCounts[this._tileIds[i]] = 0;
				}
			}

			public override bool Apply(Point origin, int x, int y, params object[] args)
			{
				Tile tile = GenBase._tiles[x, y];
				if (tile.active() && this._tileCounts.ContainsKey(tile.type))
				{
					Dictionary<ushort, int> item = this._tileCounts;
					Dictionary<ushort, int> nums = item;
					ushort num = tile.type;
					item[num] = nums[num] + 1;
				}
				return base.UnitApply(origin, x, y, args);
			}

			public int GetCount(ushort tileId)
			{
				if (!this._tileCounts.ContainsKey(tileId))
				{
					return -1;
				}
				return this._tileCounts[tileId];
			}

			public Dictionary<ushort, int> GetResults()
			{
				return this._tileCounts;
			}

			public Actions.TileScanner Output(Dictionary<ushort, int> resultsOutput)
			{
				this._tileCounts = resultsOutput;
				for (int i = 0; i < (int)this._tileIds.Length; i++)
				{
					if (!this._tileCounts.ContainsKey(this._tileIds[i]))
					{
						this._tileCounts[this._tileIds[i]] = 0;
					}
				}
				return this;
			}
		}
	}
}