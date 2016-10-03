using System;
using Terraria;

namespace Terraria.World.Generation
{
	public static class Conditions
	{
		public class Continue : GenCondition
		{
			public Continue()
			{
			}

			protected override bool CheckValidity(int x, int y)
			{
				return false;
			}
		}

		public class HasLava : GenCondition
		{
			public HasLava()
			{
			}

			protected override bool CheckValidity(int x, int y)
			{
				if (GenBase._tiles[x, y].liquid <= 0)
				{
					return false;
				}
				return GenBase._tiles[x, y].liquidType() == 1;
			}
		}

		public class IsSolid : GenCondition
		{
			public IsSolid()
			{
			}

			protected override bool CheckValidity(int x, int y)
			{
				if (!GenBase._tiles[x, y].active())
				{
					return false;
				}
				return Main.tileSolid[GenBase._tiles[x, y].type];
			}
		}

		public class IsTile : GenCondition
		{
			private ushort[] _types;

			public IsTile(params ushort[] types)
			{
				this._types = types;
			}

			protected override bool CheckValidity(int x, int y)
			{
				if (GenBase._tiles[x, y].active())
				{
					for (int i = 0; i < (int)this._types.Length; i++)
					{
						if (GenBase._tiles[x, y].type == this._types[i])
						{
							return true;
						}
					}
				}
				return false;
			}
		}
	}
}