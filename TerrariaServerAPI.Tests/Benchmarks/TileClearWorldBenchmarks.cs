using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This tests how well providers can run the clear world logic from vanilla.
/// </summary>
[MarkdownExporter]
public class TileClearWorldBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileClearWorldBenchmarks>(
			ManualConfig
				.Create(DefaultConfig.Instance)
				.WithOption(ConfigOptions.DisableOptimizationsValidator, true)
		);
		Assert.That(res.HasCriticalValidationErrors, Is.False);
	}

	[Benchmark(Baseline = true), Test]
	public void ClearWorld_Stock() => ClearWorld(_stock);

	[Benchmark, Test]
	public void ClearWorld_Heap() => ClearWorld(_heap);

	[Benchmark, Test]
	public void ClearWorld_Constileation() => ClearWorld(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void ClearWorld_1d() => ClearWorld(_1d);

	[Benchmark, Test]
	public void ClearWorld_2d() => ClearWorld(_2d);

	[Benchmark, Test]
	public void ClearWorld_Struct() => ClearWorld(_struct);
#endif

	/// <summary>
	/// This replicates the clear logic that terraria itself calls. It intentially replicates the tile hooks, as it will
	/// create Terraria.Tile references for the providers to translate.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="requestProvider"></param>
	public void ClearWorld(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				if (provider[x, y] is null)
					provider[x, y] = OTAPI.Hooks.Tile.InvokeCreate();
				else
					provider[x, y].ClearEverything();
			}
	}
}
