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

using System;
using System.Diagnostics.CodeAnalysis;
//using Destructurama.Attributed;

namespace TerrariaServerAPI.TerrariaApi.Server.Tiles.Entities;

/// <summary>
/// Represents a liquid in a tile.
/// </summary>
/// <remarks>
/// Each liquid consists of a <see cref="LiquidType"/>, which specifies the type of liquid, along with a liquid
/// amount which ranges from <c>0</c> to <c>255</c>.
/// </remarks>
public readonly struct Liquid : IEquatable<Liquid>
{
	/// <summary>
	/// Gets an empty liquid.
	/// </summary>
	/// <value>An empty liquid.</value>
	public static Liquid None => default;

	/// <summary>
	/// Gets a full block of water.
	/// </summary>
	/// <value>A full block of water.</value>
	public static Liquid Water => new Liquid(LiquidType.Water, 255);

	/// <summary>
	/// Gets a full block of lava.
	/// </summary>
	/// <value>A full block of lava.</value>
	public static Liquid Lava => new Liquid(LiquidType.Lava, 255);

	/// <summary>
	/// Gets a full block of honey.
	/// </summary>
	/// <value>A full block of honey.</value>
	public static Liquid Honey => new Liquid(LiquidType.Honey, 255);

	/// <summary>
	/// Initializes a new instance of the <see cref="Liquid"/> structure with the specified liquid
	/// <paramref name="type"/> and <paramref name="amount"/>.
	/// </summary>
	/// <param name="type">The liquid's type.</param>
	/// <param name="amount">The liquid's amount.</param>
	public Liquid(LiquidType type, byte amount)
	{
		Type = type;
		Amount = amount;
	}

	/// <summary>
	/// Gets the liquid's type.
	/// </summary>
	/// <value>The liquid's type.</value>
	public LiquidType Type { get; }

	/// <summary>
	/// Gets the liquid's amount. This ranges from <c>0</c> to <c>255</c>.
	/// </summary>
	/// <value>The liquid's amount.</value>
	public byte Amount { get; }

	/// <summary>
	/// Gets a value indicating whether the liquid is empty.
	/// </summary>
	/// <value><see langword="true"/> if the liquid is empty; otherwise, <see langword="false"/>.</value>
	//[NotLogged]
	public bool IsEmpty => Amount == 0;

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is Liquid other && Equals(other);

	/// <inheritdoc/>
	public bool Equals(Liquid other) => IsEmpty ? other.IsEmpty : (Type == other.Type && Amount == other.Amount);

	/// <summary>
	/// Returns the hash code of the liquid.
	/// </summary>
	/// <returns>The hash code of the liquid.</returns>
	public override int GetHashCode() => IsEmpty ? 0 : HashCode.Combine(Type, Amount);

	/// <summary>
	/// Returns a string representation of the liquid.
	/// </summary>
	/// <returns>A string representation of the liquid.</returns>
	[ExcludeFromCodeCoverage]
	public override string ToString() => IsEmpty ? "<none>" : $"{Type} x{Amount}";

	/// <summary>
	/// Returns a value indicating whether <paramref name="left"/> is equal to <paramref name="right"/>.
	/// </summary>
	/// <param name="left">The left liquid.</param>
	/// <param name="right">The right liquid.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="left"/> is equal to <paramref name="right"/>; otherwise,
	/// <see langword="false"/>.
	/// </returns>
	public static bool operator ==(Liquid left, Liquid right) => left.Equals(right);

	/// <summary>
	/// Returns a value indicating whether <paramref name="left"/> is not equal to <paramref name="right"/>.
	/// </summary>
	/// <param name="left">The left liquid.</param>
	/// <param name="right">The right liquid.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise,
	/// <see langword="false"/>.
	/// </returns>
	public static bool operator !=(Liquid left, Liquid right) => !(left == right);
}
