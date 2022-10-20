using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;
using Terraria.ID;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This test will determine how long it will take for a tile to update all tiles in the collection to a new type.
/// </summary>
[MarkdownExporter]
public class TileTypeBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileTypeBenchmarks>(
			ManualConfig
				.Create(DefaultConfig.Instance)
				.WithOption(ConfigOptions.DisableOptimizationsValidator, true)
		);
		Assert.That(res.HasCriticalValidationErrors, Is.False);
	}

	/// <summary>
	/// Ensure the providers all have some data, avoiding NRE while testing individually
	/// </summary>
	protected override void OnSetup()
	{
		foreach (var prov in _all)
			for (int x = 0; x < Main.maxTilesX; x++)
				for (int y = 0; y < Main.maxTilesY; y++)
					prov[x, y] = new Tile();
	}

	[Benchmark(Baseline = true), Test]
	public void Type_Stock() => Type(_stock);

	[Benchmark, Test]
	public void Type_Heap() => Type(_heap);

	[Benchmark, Test]
	public void Type_Constileation() => Type(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void Type_1d() => Type(_1d);

	[Benchmark, Test]
	public void Type_2d() => Type(_2d);

	[Benchmark, Test]
	public void Struct() => Type(_struct);
#endif

	public void Type(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
				provider[x, y].type = TileID.Stone;
	}
}
