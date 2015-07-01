using System;

namespace Terraria.Enums
{
	[Flags]
	public enum AnchorType
	{
		None = 0,
		SolidTile = 1,
		SolidWithTop = 2,
		Table = 4,
		SolidSide = 8,
		Tree = 16,
		AlternateTile = 32,
		EmptyTile = 64,
		SolidBottom = 128
	}
}