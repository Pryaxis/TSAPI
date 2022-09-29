//// Copyright (c) 2020 Pryaxis & Orion Contributors
//// 
//// This file is part of Orion.
//// 
//// Orion is free software: you can redistribute it and/or modify
//// it under the terms of the GNU General Public License as published by
//// the Free Software Foundation, either version 3 of the License, or
//// (at your option) any later version.
//// 
//// Orion is distributed in the hope that it will be useful,
//// but WITHOUT ANY WARRANTY; without even the implied warranty of
//// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//// GNU General Public License for more details.
//// 
//// You should have received a copy of the GNU General Public License
//// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

//using System.Diagnostics;
//using System.Diagnostics.CodeAnalysis;
//using System.Runtime.CompilerServices;
//using Terraria;
//using TerrariaServerAPI.TerrariaApi.Server.Tiles.Entities;

//namespace TerrariaServerAPI.TerrariaApi.Server.Tiles;

//// An adapter class to make a `Tile` reference compatible with `OTAPI.Tile.ITile`. Unfortunately, this means we
//// generate a lot of garbage, but this is the best we can really do.
//internal sealed unsafe class OrionTileAdapter : ITile
//{
//	internal readonly OrionTile* _tile;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public OrionTileAdapter(ref OrionTile tile)
//	{
//		_tile = (OrionTile*)Unsafe.AsPointer(ref tile);
//	}

//	public ushort type
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		get => _tile->BlockId == BlockId.None ? (ushort)0 : (ushort)(_tile->BlockId - 1);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			// Because Terraria originally stored active and block ID information separately, we need to be
//			// careful about replacing active information if Terraria does `type = 0`.
//			//
//			// We allow the following transitions:
//			// - <anything> -> type != 0
//			// - active -> type = 0

//			if (value != 0)
//			{
//				_tile->BlockId = (BlockId)(value + 1);
//			}
//			else if (_tile->BlockId != BlockId.None)
//			{
//				_tile->BlockId = BlockId.Dirt;
//			}
//		}
//	}

//	public ushort wall
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		get => (ushort)_tile->WallId;

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set => _tile->WallId = (WallId)value;
//	}

//	public short frameX
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		get => _tile->BlockFrameX;

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set => _tile->BlockFrameX = value;
//	}

//	public short frameY
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		get => _tile->BlockFrameY;

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set => _tile->BlockFrameY = value;
//	}

//	public byte liquid
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		get => *((byte*)_tile + 8);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set => *((byte*)_tile + 8) = value;
//	}

//	public uint Header
//	{
//		get => *(uint*)((byte*)_tile + 8);
//		set => *(uint*)((byte*)_tile + 8) = value;
//	}

//	// No-ops since these are never used.
//	[ExcludeFromCodeCoverage]
//	public int collisionType => 0;

//	public ushort sTileHeader
//	{
//		[ExcludeFromCodeCoverage]
//		get => 0;

//		[ExcludeFromCodeCoverage]
//		set { }
//	}

//	public byte bTileHeader
//	{
//		[ExcludeFromCodeCoverage]
//		get => 0;

//		[ExcludeFromCodeCoverage]
//		set { }
//	}

//	public byte bTileHeader2
//	{
//		[ExcludeFromCodeCoverage]
//		get => 0;

//		[ExcludeFromCodeCoverage]
//		set { }
//	}

//	public byte bTileHeader3
//	{
//		[ExcludeFromCodeCoverage]
//		get => 0;

//		[ExcludeFromCodeCoverage]
//		set { }
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool active() => _tile->BlockId != BlockId.None;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void active(bool active)
//	{
//		// Because Terraria originally stored active and block ID information separately, we need to be careful
//		// about replacing block ID information if Terraria calls `active(true)`.
//		//
//		// We allow the following transitions:
//		// - active -> not active
//		// - not active -> active (as dirt)

//		if (!active)
//		{
//			_tile->BlockId = BlockId.None;
//		}
//		else if (_tile->BlockId == BlockId.None)
//		{
//			_tile->BlockId = BlockId.Dirt;
//		}
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public byte color() => (byte)_tile->BlockColor;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void color(byte color) => _tile->BlockColor = (PaintColor)color;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public int blockType() => (int)_tile->BlockShape;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool halfBrick() => _tile->BlockShape == BlockShape.Halved;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void halfBrick(bool halfBrick)
//	{
//		// Because Terraria originally stored halved and slope information separately, we need to be careful
//		// about replacing slope information if Terraria calls `halfBrick(false)`.
//		//
//		// We allow the following transitions:
//		// - <anything> -> halved
//		// - halved -> not halved

//		if (halfBrick)
//		{
//			_tile->BlockShape = BlockShape.Halved;
//		}
//		else if (_tile->BlockShape == BlockShape.Halved)
//		{
//			_tile->BlockShape = BlockShape.Normal;
//		}
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public byte slope() => (byte)(_tile->BlockShape == BlockShape.Normal ? 0 : (_tile->BlockShape - 1));

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void slope(byte slope)
//	{
//		Debug.Assert(slope <= 0x06);

//		// Because Terraria originally stored halved and slope information separately, we need to be careful
//		// about replacing halved information if Terraria calls `slope(0)`.
//		//
//		// We allow the following transitions:
//		// - <anything> -> slope
//		// - slope -> no slope

//		if (slope > 0)
//		{
//			_tile->BlockShape = (BlockShape)(slope + 1);
//		}
//		else if (_tile->BlockShape > BlockShape.Halved)
//		{
//			_tile->BlockShape = BlockShape.Normal;
//		}
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool topSlope() => IsSlope(1, 2);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool bottomSlope() => IsSlope(3, 4);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool leftSlope() => IsSlope(2, 4);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool rightSlope() => IsSlope(1, 3);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool HasSameSlope(ITile tile) => slope() == tile.slope();

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool wire() => _tile->HasRedWire;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void wire(bool wire) => _tile->HasRedWire = wire;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool wire2() => _tile->HasBlueWire;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void wire2(bool wire2) => _tile->HasBlueWire = wire2;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool wire3() => _tile->HasGreenWire;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void wire3(bool wire3) => _tile->HasGreenWire = wire3;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool wire4() => _tile->HasYellowWire;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void wire4(bool wire4) => _tile->HasYellowWire = wire4;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool actuator() => _tile->HasActuator;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void actuator(bool actuator) => _tile->HasActuator = actuator;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool inActive() => _tile->IsBlockActuated;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void inActive(bool inActive) => _tile->IsBlockActuated = inActive;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool nactive() => active() && !inActive();

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public byte liquidType() => (byte)((Header & 0x00c00000) >> 22);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void liquidType(int liquidType)
//	{
//		Debug.Assert(liquidType <= 0x03);

//		Header = (Header & 0xff3fffffU) | ((uint)liquidType << 22);
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool lava() => (Header & 0x00400000) != 0;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void lava(bool lava)
//	{
//		if (lava)
//		{
//			Header = (Header & 0xff3fffff) | 0x00400000;
//		}
//		else
//		{
//			Header &= 0xffbfffff;
//		}
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool honey() => (Header & 0x00800000) != 0;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void honey(bool honey)
//	{
//		if (honey)
//		{
//			Header = (Header & 0xff3fffff) | 0x00800000;
//		}
//		else
//		{
//			Header &= 0xff7fffff;
//		}
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public byte wallColor() => (byte)_tile->WallColor;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void wallColor(byte wallColor) => _tile->WallColor = (PaintColor)wallColor;

//	// The checking liquid flag is implemented using the top bit of the header. This is done to cut down on the
//	// size of a tile.

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool checkingLiquid() => (Header & 0x80000000) != 0;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void checkingLiquid(bool checkingLiquid)
//	{
//		if (checkingLiquid)
//		{
//			Header |= 0x80000000;
//		}
//		else
//		{
//			Header &= 0x7fffffff;
//		}
//	}

//	// The skip liquid flag is implemented using the top bit of the wall ID. This is to cut down on the size of
//	// size of a tile.

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public bool skipLiquid() => (*((ushort*)_tile + 1) & 0x8000) != 0;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void skipLiquid(bool skipLiquid)
//	{
//		if (skipLiquid)
//		{
//			*((ushort*)_tile + 1) |= 0x8000;
//		}
//		else
//		{
//			*((ushort*)_tile + 1) &= 0x7fff;
//		}
//	}

//	// The frame number is implemented using bits 29-30 of the header. This is done to cut down on the size of a
//	// tile.

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public byte frameNumber() => (byte)((Header & 0x60000000) >> 29);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void frameNumber(byte frameNumber)
//	{
//		Debug.Assert(frameNumber <= 0x03);

//		Header = (Header & 0x9fffffff) | ((uint)frameNumber << 29);
//	}

//	public void CopyFrom(ITile from)
//	{
//		if (from is null)
//		{
//			ClearEverything();
//			return;
//		}

//		Debug.Assert(from is OrionTileAdapter);

//		*_tile = *((OrionTileAdapter)from)._tile;
//	}

//	public bool isTheSameAs(ITile compTile)
//	{
//		if (compTile is null)
//		{
//			return false;
//		}

//		Debug.Assert(compTile is OrionTileAdapter);

//		return _tile->Equals(*((OrionTileAdapter)compTile)._tile);
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void ClearEverything() => Unsafe.InitBlockUnaligned((byte*)_tile, 0, 12);

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void ClearMetadata()
//	{
//		Unsafe.InitBlockUnaligned((byte*)_tile + 4, 0, 8);
//		skipLiquid(false);
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void ClearTile()
//	{
//		_tile->BlockId = BlockId.None;
//		_tile->BlockShape = BlockShape.Normal;
//		_tile->IsBlockActuated = false;
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void Clear(Terraria.DataStructures.TileDataType types)
//	{
//		if ((types & Terraria.DataStructures.TileDataType.Tile) != 0)
//		{
//			_tile->BlockId = BlockId.None;
//			Unsafe.InitBlockUnaligned(((byte*)_tile) + 4, 0, 4);
//		}

//		if ((types & Terraria.DataStructures.TileDataType.TilePaint) != 0)
//		{
//			_tile->BlockColor = PaintColor.None;
//		}

//		if ((types & Terraria.DataStructures.TileDataType.Wall) != 0)
//		{
//			_tile->WallId = WallId.None;
//		}

//		if ((types & Terraria.DataStructures.TileDataType.WallPaint) != 0)
//		{
//			_tile->WallColor = PaintColor.None;
//		}

//		if ((types & Terraria.DataStructures.TileDataType.Liquid) != 0)
//		{
//			_tile->Liquid = default;
//			checkingLiquid(false);
//		}

//		if ((types & Terraria.DataStructures.TileDataType.Wiring) != 0)
//		{
//			wire(false);
//			wire2(false);
//			wire3(false);
//			wire4(false);
//		}

//		if ((types & Terraria.DataStructures.TileDataType.Actuator) != 0)
//		{
//			actuator(false);
//			inActive(false);
//		}

//		if ((types & Terraria.DataStructures.TileDataType.Slope) != 0)
//		{
//			_tile->BlockShape = BlockShape.Normal;
//		}
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public void ResetToType(ushort type)
//	{
//		ClearMetadata();
//		this.type = type;
//	}

//	// No-ops since these are never used.
//	[ExcludeFromCodeCoverage]
//	public object Clone() => MemberwiseClone();

//	[ExcludeFromCodeCoverage]
//	public Microsoft.Xna.Framework.Color actColor(Microsoft.Xna.Framework.Color oldColor) => default;

//	[ExcludeFromCodeCoverage]
//	public void actColor(ref Microsoft.Xna.Framework.Vector3 oldColor) { }

//	[ExcludeFromCodeCoverage]
//	public byte wallFrameNumber() => 0;

//	[ExcludeFromCodeCoverage]
//	public void wallFrameNumber(byte wallFrameNumber) { }

//	[ExcludeFromCodeCoverage]
//	public int wallFrameX() => 0;

//	[ExcludeFromCodeCoverage]
//	public void wallFrameX(int wallFrameX) { }

//	[ExcludeFromCodeCoverage]
//	public int wallFrameY() => 0;

//	[ExcludeFromCodeCoverage]
//	public void wallFrameY(int wallFrameY) { }

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	private bool IsSlope(byte slope1, byte slope2)
//	{
//		var slope = this.slope();
//		return slope == slope1 || slope == slope2;
//	}

//	public bool shimmer()
//	{
//		throw new NotImplementedException();
//	}

//	public void shimmer(bool shimmer)
//	{
//		throw new NotImplementedException();
//	}

//	public bool invisibleBlock()
//	{
//		throw new NotImplementedException();
//	}

//	public void invisibleBlock(bool invisibleBlock)
//	{
//		throw new NotImplementedException();
//	}

//	public bool invisibleWall()
//	{
//		throw new NotImplementedException();
//	}

//	public void invisibleWall(bool invisibleWall)
//	{
//		throw new NotImplementedException();
//	}

//	public bool fullbrightBlock()
//	{
//		throw new NotImplementedException();
//	}

//	public void fullbrightBlock(bool fullbrightBlock)
//	{
//		throw new NotImplementedException();
//	}

//	public bool fullbrightWall()
//	{
//		throw new NotImplementedException();
//	}

//	public void fullbrightWall(bool fullbrightWall)
//	{
//		throw new NotImplementedException();
//	}

//	public void CopyPaintAndCoating(ITile other)
//	{
//		throw new NotImplementedException();
//	}

//	public TileColorCache BlockColorAndCoating()
//	{
//		throw new NotImplementedException();
//	}

//	public TileColorCache WallColorAndCoating()
//	{
//		throw new NotImplementedException();
//	}

//	public void UseBlockColors(TileColorCache cache)
//	{
//		throw new NotImplementedException();
//	}

//	public void UseWallColors(TileColorCache cache)
//	{
//		throw new NotImplementedException();
//	}

//	public void ClearBlockPaintAndCoating()
//	{
//		throw new NotImplementedException();
//	}

//	public void ClearWallPaintAndCoating()
//	{
//		throw new NotImplementedException();
//	}
//}
