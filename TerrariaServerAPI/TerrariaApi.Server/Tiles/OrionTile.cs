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

//using System;
//using System.Diagnostics;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using TerrariaServerAPI.TerrariaApi.Server.Tiles.Entities;

//namespace TerrariaServerAPI.TerrariaApi.Server.Tiles;

///// <summary>
///// Represents an optimized Terraria tile.
///// </summary>
///// <remarks>
///// This structure is not thread-safe.
///// </remarks>
//[DebuggerStepThrough]
//[StructLayout(LayoutKind.Explicit, Size = 12)]
//public struct OrionTile : IEquatable<OrionTile>
//{
//	private const int BlockColorShift = 8;
//	private const int BlockShapeShift = 13;
//	private const int LiquidTypeShift = 22;
//	private const int WallColorShift = 24;

//	private const uint BlockColorMask /*      */ = 0b_00000000_00000000_00011111_00000000;
//	private const uint BlockShapeMask /*      */ = 0b_00000000_00000000_11100000_00000000;
//	private const uint HasRedWireMask /*      */ = 0b_00000000_00000001_00000000_00000000;
//	private const uint HasBlueWireMask /*     */ = 0b_00000000_00000010_00000000_00000000;
//	private const uint HasGreenWireMask /*    */ = 0b_00000000_00000100_00000000_00000000;
//	private const uint HasYellowWireMask /*   */ = 0b_00000000_00001000_00000000_00000000;
//	private const uint HasActuatorMask /*     */ = 0b_00000000_00010000_00000000_00000000;
//	private const uint IsBlockActuatedMask /* */ = 0b_00000000_00100000_00000000_00000000;
//	private const uint LiquidTypeMask /*      */ = 0b_00000000_11000000_00000000_00000000;
//	private const uint WallColorMask /*       */ = 0b_00011111_00000000_00000000_00000000;

//	[FieldOffset(0)] private readonly ulong _bytes;
//	[FieldOffset(2)] private ushort _wallId;
//	[FieldOffset(8)] private byte _liquidAmount;
//	[FieldOffset(8)] private uint _header;

//	/// <summary>
//	/// Gets or sets the tile's block ID.
//	/// </summary>
//	/// <value>The tile's block ID.</value>
//	[field: FieldOffset(0)] public BlockId BlockId { get; set; }

//	/// <summary>
//	/// Gets or sets the tile's wall ID.
//	/// </summary>
//	/// <value>The tile's wall ID.</value>
//	public WallId WallId
//	{
//		// We purposefully ignore the top bit of the wall ID, to allow a bit of state to be stored there for other
//		// purposes. This cuts down on the usable number of wall IDs by a factor of two, but it should be fine.

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		readonly get => (WallId)(_wallId & 0x7fff);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			Debug.Assert((ushort)value <= 0x7fff);

//			_wallId = (ushort)((_wallId & 0x8000) | (ushort)value);
//		}
//	}

//	/// <summary>
//	/// Gets or sets the block's X frame.
//	/// </summary>
//	/// <value>The block's X frame.</value>
//	[field: FieldOffset(4)] public short BlockFrameX { get; set; }

//	/// <summary>
//	/// Gets or sets the block's Y frame.
//	/// </summary>
//	/// <value>The block's Y frame.</value>
//	[field: FieldOffset(6)] public short BlockFrameY { get; set; }

//	/// <summary>
//	/// Gets or sets the tile's liquid.
//	/// </summary>
//	/// <value>The tile's liquid.</value>
//	public Liquid Liquid
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		readonly get => new Liquid((LiquidType)((_header & LiquidTypeMask) >> LiquidTypeShift), _liquidAmount);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			Debug.Assert((uint)value.Type <= 0x03);

//			_header = (_header & ~LiquidTypeMask) | ((uint)value.Type << LiquidTypeShift);
//			_liquidAmount = value.Amount;
//		}
//	}

//	/// <summary>
//	/// Gets or sets the block's color.
//	/// </summary>
//	/// <value>The block's color.</value>
//	public PaintColor BlockColor
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		readonly get => (PaintColor)((_header & BlockColorMask) >> BlockColorShift);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			Debug.Assert((uint)value <= 0x1f);

//			_header = (_header & ~BlockColorMask) | ((uint)value << BlockColorShift);
//		}
//	}

//	/// <summary>
//	/// Gets or sets the block's shape.
//	/// </summary>
//	/// <value>The block's shape.</value>
//	public BlockShape BlockShape
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		readonly get => (BlockShape)((_header & BlockShapeMask) >> BlockShapeShift);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			Debug.Assert((uint)value <= 0x07);

//			_header = (_header & ~BlockShapeMask) | ((uint)value << BlockShapeShift);
//		}
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether the tile has red wire.
//	/// </summary>
//	/// <value><see langword="true"/> if the tile has red wire; otherwise, <see langword="false"/>.</value>
//	public bool HasRedWire
//	{
//		readonly get => GetHeaderFlag(HasRedWireMask);
//		set => SetHeaderFlag(HasRedWireMask, value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether the tile has blue wire.
//	/// </summary>
//	/// <value><see langword="true"/> if the tile has blue wire; otherwise, <see langword="false"/>.</value>
//	public bool HasBlueWire
//	{
//		readonly get => GetHeaderFlag(HasBlueWireMask);
//		set => SetHeaderFlag(HasBlueWireMask, value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether the tile has green wire.
//	/// </summary>
//	/// <value><see langword="true"/> if the tile has green wire; otherwise, <see langword="false"/>.</value>
//	public bool HasGreenWire
//	{
//		readonly get => GetHeaderFlag(HasGreenWireMask);
//		set => SetHeaderFlag(HasGreenWireMask, value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether the tile has yellow wire.
//	/// </summary>
//	/// <value><see langword="true"/> if the tile has yellow wire; otherwise, <see langword="false"/>.</value>
//	public bool HasYellowWire
//	{
//		readonly get => GetHeaderFlag(HasYellowWireMask);
//		set => SetHeaderFlag(HasYellowWireMask, value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether the tile has an actuator.
//	/// </summary>
//	/// <value><see langword="true"/> if the tile has an actuator; otherwise, <see langword="false"/>.</value>
//	public bool HasActuator
//	{
//		readonly get => GetHeaderFlag(HasActuatorMask);
//		set => SetHeaderFlag(HasActuatorMask, value);
//	}

//	/// <summary>
//	/// Gets or sets a value indicating whether the block is actuated.
//	/// </summary>
//	/// <value><see langword="true"/> if the block is actuated; otherwise, <see langword="false"/>.</value>
//	public bool IsBlockActuated
//	{
//		readonly get => GetHeaderFlag(IsBlockActuatedMask);
//		set => SetHeaderFlag(IsBlockActuatedMask, value);
//	}

//	/// <summary>
//	/// Gets or sets the wall's color.
//	/// </summary>
//	/// <value>The wall's color.</value>
//	public PaintColor WallColor
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		readonly get => (PaintColor)((_header & WallColorMask) >> WallColorShift);

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			Debug.Assert((uint)value <= 0x1f);

//			_header = (_header & ~WallColorMask) | ((uint)value << WallColorShift);
//		}
//	}

//	/// <inheritdoc/>
//	public override readonly bool Equals(object? obj) => obj is OrionTile other && Equals(other);

//	/// <inheritdoc/>
//	public readonly bool Equals(OrionTile other)
//	{
//		// Two tiles are compared by checking the tiles' bytes directly. The first set of 8 bytes are checked,
//		// followed by the header.
//		//
//		// The first set of 8 bytes are:
//		// | yyyyyyyy | yyyyyyyy | xxxxxxxx | xxxxxxxx | ?wwwwwww | wwwwwwww | bbbbbbbb | bbbbbbbb |

//		var mask = BlockId.HasFrames()
//			? 0b_11111111_11111111_11111111_11111111_01111111_11111111_11111111_11111111UL
//			: 0b_00000000_00000000_00000000_00000000_01111111_11111111_11111111_11111111UL;

//		if (((_bytes ^ other._bytes) & mask) != 0)
//		{
//			return false;
//		}

//		// The header is:
//		// | ???hhhhh | hhhhhhhh | hhhhhhhh | llllllll |
//		//
//		// Note that the liquid type should not be checked if the liquid amount is 0.

//		var mask2 = _liquidAmount != 0
//			? 0b_00011111_11111111_11111111_11111111U
//			: 0b_00011111_00111111_11111111_11111111U;

//		return ((_header ^ other._header) & mask2) == 0;
//	}

//	/// <summary>
//	/// Returns the hash code of the tile.
//	/// </summary>
//	/// <returns>The hash code of the tile.</returns>
//	public override readonly int GetHashCode()
//	{
//		// The hash code is calculated similarly as above.

//		var mask = BlockId.HasFrames()
//			? 0b_11111111_11111111_11111111_11111111_01111111_11111111_11111111_11111111UL
//			: 0b_00000000_00000000_00000000_00000000_01111111_11111111_11111111_11111111UL;

//		var mask2 = _liquidAmount != 0
//			? 0b_00011111_11111111_11111111_11111111U
//			: 0b_00011111_00111111_11111111_11111111U;

//		return HashCode.Combine(_bytes & mask, _header & mask2);
//	}

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	private readonly bool GetHeaderFlag(uint mask) => (_header & mask) != 0;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	private void SetHeaderFlag(uint mask, bool value)
//	{
//		if (value)
//		{
//			_header |= mask;
//		}
//		else
//		{
//			_header &= ~mask;
//		}
//	}
//}
