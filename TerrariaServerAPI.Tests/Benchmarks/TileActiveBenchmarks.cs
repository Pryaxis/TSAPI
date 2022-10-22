using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This will test how fast each provider can mark all of it's tiles to active
/// </summary>
[MarkdownExporter]
public class TileActiveBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileActiveBenchmarks>(
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
	public void Active_Stock() => Active(_stock);

	[Benchmark, Test]
	public void Active_Heap() => Active(_heap);

	[Benchmark, Test]
	public void Active_Constileation() => Active(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void Active_1d() => Active(_1d);

	[Benchmark, Test]
	public void Active_2d() => Active(_2d);

	[Benchmark, Test]
	public void Active_Struct() => Active(_struct);
#endif

	public void Active(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				provider[x, y].active(true);
			}
	}
}
