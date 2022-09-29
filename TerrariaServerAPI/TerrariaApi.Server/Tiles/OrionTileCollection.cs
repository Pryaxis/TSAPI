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
//using System.Diagnostics.CodeAnalysis;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using Terraria;

//namespace TerrariaServerAPI.TerrariaApi.Server.Tiles;

//public sealed class OrionTileCollection : ModFramework.ICollection<ITile>, IDisposable
//{
//	private unsafe OrionTile* _tiles;

//	[MethodImpl(MethodImplOptions.AggressiveInlining)]
//	public unsafe ref OrionTile GetTile(int x, int y)
//	{
//		Debug.Assert(0 <= x && x <= Width);
//		Debug.Assert(0 <= y && y <= Height);

//		AllocateUnmanaged();

//		return ref _tiles[(y * Width) + x];
//	}

//	public unsafe ITile this[int x, int y]
//	{
//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		get => new OrionTileAdapter(ref GetTile(x, y));

//		[MethodImpl(MethodImplOptions.AggressiveInlining)]
//		set
//		{
//			ref var tile = ref GetTile(x, y);

//			if (value is null)
//			{
//				tile = default;
//				return;
//			}

//			Debug.Assert(value is OrionTileAdapter);

//			tile = *((OrionTileAdapter)value)._tile;
//		}
//	}

//	public int Width => Terraria.Main.maxTilesX;


//	public int Height => Terraria.Main.maxTilesY;

//	[ExcludeFromCodeCoverage]
//	unsafe ~OrionTileCollection()
//	{
//		DisposeUnmanaged();
//	}

//	public unsafe void Dispose()
//	{
//		DisposeUnmanaged();
//		GC.SuppressFinalize(this);
//	}

//	private unsafe void AllocateUnmanaged()
//	{
//		if (_tiles is null)
//		{
//			// Allocate the `Tile` array in unmanaged memory so that it doesn't need to be pinned. The bounds are
//			// increased by 1 to fix some OOB issues in world generation code.
//			var size = sizeof(OrionTile) * (Width + 1) * (Height + 1);

//			_tiles = (OrionTile*)Marshal.AllocHGlobal(size);
//			GC.AddMemoryPressure(size);
//		}
//	}

//	private unsafe void DisposeUnmanaged()
//	{
//		if (_tiles != null)
//		{
//			var size = sizeof(OrionTile) * (Width + 1) * (Height + 1);

//			Marshal.FreeHGlobal((IntPtr)_tiles);
//			GC.RemoveMemoryPressure(size);
//		}
//	}
//}
