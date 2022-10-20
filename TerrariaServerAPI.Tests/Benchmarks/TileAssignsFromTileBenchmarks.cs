using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This tests how well the providers can assign data from the vanilla Tile instance, as it will need to translate the ITile structure manually.
/// </summary>
[MarkdownExporter]
public class TileAssignsFromTileBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileAssignsFromTileBenchmarks>(
			ManualConfig
				.Create(DefaultConfig.Instance)
				.WithOption(ConfigOptions.DisableOptimizationsValidator, true)
		);
		Assert.That(res.HasCriticalValidationErrors, Is.False);
	}

	[Benchmark(Baseline = true), Test]
	public void AssignFromTile_Stock() => AssignFromTile(_stock);

	[Benchmark, Test]
	public void AssignFromTile_Heap() => AssignFromTile(_heap);

	[Benchmark, Test]
	public void AssignFromTile_Constileation() => AssignFromTile(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void AssignFromTile_1d() => AssignFromTile(_1d);

	[Benchmark, Test]
	public void AssignFromTile_2d() => AssignFromTile(_2d);

	[Benchmark, Test]
	public void AssignFromTile_Struct() => AssignFromTile(_struct);
#endif

	public void AssignFromTile(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				provider[x, y] = new Terraria.Tile();
			}
	}
}
