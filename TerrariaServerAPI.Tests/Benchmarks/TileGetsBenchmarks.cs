using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This tests to see how well the providers serve data.
/// </summary>
[MarkdownExporter]
public class TileGetsBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileGetsBenchmarks>(
			ManualConfig
				.Create(DefaultConfig.Instance)
				.WithOption(ConfigOptions.DisableOptimizationsValidator, true)
		);
		Assert.That(res.HasCriticalValidationErrors, Is.False);
	}

	[Benchmark(Baseline = true), Test]
	public void Gets_Stock() => Gets(_stock);

	[Benchmark, Test]
	public void Gets_Heap() => Gets(_heap);

	[Benchmark, Test]
	public void Gets_Constileation() => Gets(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void Gets_1d() => Gets(_1d);

	[Benchmark, Test]
	public void Gets_2d() => Gets(_2d);

	[Benchmark, Test]
	public void Gets_Struct() => Gets(_struct);
#endif

	public void Gets(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				_ = provider[x, y];
			}
	}
}
