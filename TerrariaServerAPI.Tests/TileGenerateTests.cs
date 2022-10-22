using BenchmarkDotNet.Attributes;
using ModFramework;
using NUnit.Framework;
using Terraria;
using Terraria.Utilities;
using TerrariaServerAPI.Tests.Benchmarks;

namespace TerrariaServerAPI.Tests;

/// <summary>
/// Tests that generation works and no regressions have occurred (heaptile for example)
/// No benchmarks are in place as it's unreasonable to bench like this, since world generation
/// is random.
/// </summary>
public class TileGenerateTests : TileBenchmarks
{
	/// <summary>
	/// Invokes creating a new world, while preparing terrarias variables used during generation.
	/// </summary>
	/// <param name="provider">The provider to use for generating</param>
	/// <remarks>Note, there are too many random calls in here for this to be suitable for a benchmark, only regressing testing.</remarks>
	public void Generate_Small(ICollection<ITile> provider)
	{
		Main.tile = provider;

		WorldGen.generatingWorld = true;
		Main.rand = new UnifiedRandom(9999);
		WorldGen.gen = true;
		Main.menuMode = 888;

		WorldGen.clearWorld();

		WorldGen.GenerateWorld(9999);
	}

	[Test]
	public void Generate_Small_Stock() => Generate_Small(_stock);

	[Test]
	public void Generate_Small_Heap() => Generate_Small(_heap);

	[Test]
	public void Generate_Small_Constileation() => Generate_Small(_const);

#if TILED_PLUGIN
	[Test]
	public void Generate_Small_1d() => Generate_Small(_1d);

	[Test]
	public void Generate_Small_2d() => Generate_Small(_2d);

	[Test]
	public void Generate_Small_Struct() => Generate_Small(_struct);
#endif
}
