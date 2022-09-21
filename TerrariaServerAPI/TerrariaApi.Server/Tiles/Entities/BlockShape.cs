// Copyright (c) 2020 Pryaxis & Orion Contributors
// 
// This file is part of Orion.
// 
// Orion is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Orion is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

namespace TerrariaServerAPI.TerrariaApi.Server.Tiles.Entities;

/// <summary>
/// Specifies a block shape.
/// </summary>
public enum BlockShape : byte
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	Normal = 0,
	Halved = 1,
	TopRight = 2,
	TopLeft = 3,
	BottomRight = 4,
	BottomLeft = 5
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
