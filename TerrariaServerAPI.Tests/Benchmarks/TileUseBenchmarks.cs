using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;
using Terraria.ID;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This test will determine how long it will take for providers to process some basic actions of every tile in the collection.
/// </summary>
[MarkdownExporter]
public class TileUseBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileUseBenchmarks>(
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
	public void Use_Stock() => Use(_stock);

	[Benchmark, Test]
	public void Use_Heap() => Use(_heap);

	[Benchmark, Test]
	public void Use_Constileation() => Use(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void Use_1d() => Use(_1d);

	[Benchmark, Test]
	public void Use_2d() => Use(_2d);

	[Benchmark, Test]
	public void Use_Struct() => Use(_struct);
#endif

	public void Use(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				provider[x, y].Clear(Terraria.DataStructures.TileDataType.All);
				provider[x, y].type = TileID.Stone;
				provider[x, y].active(true);
			}
	}
}
