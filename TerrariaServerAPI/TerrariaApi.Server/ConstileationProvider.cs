using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Terraria;

namespace TerrariaApi.Server;

/// <summary>
/// Cons"tile"ation provider is a tile adapter that will function similar to heaptile to reduce memory, but instead of using math to determine offsets, a TileData structure is used instead which already knows the layout.
/// </summary>
public class ConstileationProvider : ModFramework.ICollection<ITile>
{
	private TileData[] data = null;

	/// <summary>
	/// Returns the max tile x value
	/// </summary>
	public int Width => Main.maxTilesX + 1;
	/// <summary>
	/// Returns the max tile y value
	/// </summary>
	public int Height => Main.maxTilesY + 1;

	/// <summary>
	/// Returns a tile given the coordinates
	/// </summary>
	/// <param name="x">Tile X</param>
	/// <param name="y">Tile Y</param>
	/// <returns>Tile data via the <see cref="ITile"/> interface</returns>
	public unsafe ITile this[int x, int y]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			data ??= new TileData[Width * Height];
			return new TileReference(ref data[Main.maxTilesY * x + y]);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			if (value is TileReference tref) // if it's one of our own, copy memory instead of newing up a new reference.
				data[Main.maxTilesY * x + y] = *tref._tile;
			else new TileReference(ref data[Main.maxTilesY * x + y]).CopyFrom(value);
		}
	}
}


/// <summary>
/// Maps tile data to memory in an organised format
/// </summary>
/// <remarks>When updating this, refer to <see cref="ITile"/> properties, and adjust the Size accordingly. Size is likely not required, but it make it clear how many bytes we expect to consume</remarks>
[StructLayout(LayoutKind.Sequential, Size = TileReference.TileSize, Pack = 1)]
internal struct TileData
{
	public ushort type;
	public ushort wall;
	public byte liquid;
	public ushort sTileHeader;
	public byte bTileHeader;
	public byte bTileHeader2;
	public byte bTileHeader3;
	public short frameX;
	public short frameY;
}

/// <summary>
/// This class is intended to be issued back and forth between Terraria, while referring to a preallocated memory mapping of the tile data which avoids duplicating data and storing offsets.
/// </summary>
internal unsafe sealed class TileReference : Tile
{
	/// <summary>
	/// Size of the tile data in bytes
	/// </summary>
	public const Int32 TileSize = 14;

	public override ushort type
	{
		get => _tile->type;
		set => _tile->type = value;
	}

	public override ushort wall
	{
		get => _tile->wall;
		set => _tile->wall = value;
	}

	public override byte liquid
	{
		get => _tile->liquid;
		set => _tile->liquid = value;
	}

	public override ushort sTileHeader
	{
		get => _tile->sTileHeader;
		set => _tile->sTileHeader = value;
	}

	public override byte bTileHeader
	{
		get => _tile->bTileHeader;
		set => _tile->bTileHeader = value;
	}

	public override byte bTileHeader2
	{
		get => _tile->bTileHeader2;
		set => _tile->bTileHeader2 = value;
	}

	public override byte bTileHeader3
	{
		get => _tile->bTileHeader3;
		set => _tile->bTileHeader3 = value;
	}

	public override short frameX
	{
		get => _tile->frameX;
		set => _tile->frameX = value;
	}

	public override short frameY
	{
		get => _tile->frameY;
		set => _tile->frameY = value;
	}

	public override void Initialise()
	{
		// this is called in ctor. we dont want to run the default code here.
	}

	internal readonly TileData* _tile;

	/// <summary>
	/// Creates a new reference to the packed memory data
	/// </summary>
	/// <param name="tile"></param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TileReference(ref TileData tile) => _tile = (TileData*)Unsafe.AsPointer(ref tile);

	/// <summary>
	/// Clears the tile data, using a faster method than resetting each variable (which creates more instructions than required with this setup)
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override void ClearEverything() => Unsafe.InitBlockUnaligned(_tile, 0, TileSize);
}
