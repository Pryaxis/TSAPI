using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This will test how fast all providers will be able to clear every tile they own.
/// </summary>
[MarkdownExporter]
public class TileClearBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileClearBenchmarks>(
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
	public void Clear_Stock() => Clear(_stock);

	[Benchmark, Test]
	public void Clear_Heap() => Clear(_heap);

	[Benchmark, Test]
	public void Clear_Constileation() => Clear(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void Clear_1d() => Clear(_1d);

	[Benchmark, Test]
	public void Clear_2d() => Clear(_2d);

	[Benchmark, Test]
	public void Clear_Struct() => Clear(_struct);
#endif

	public void Clear(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				provider[x, y].Clear(Terraria.DataStructures.TileDataType.All);
			}
	}
}
