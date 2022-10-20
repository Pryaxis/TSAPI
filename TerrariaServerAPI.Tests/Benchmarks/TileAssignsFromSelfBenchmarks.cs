using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using ModFramework;
using NUnit.Framework;
using Terraria;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// This tests to see how well the providers can store data, issued from itself, since some providers can copy memory instead of using ITile
/// </summary>
[MarkdownExporter]
public class TileAssignsFromSelfBenchmarks : TileBenchmarks
{
	[Test]
	public void RunBenchmarks()
	{
		var res = BenchmarkRunner.Run<TileAssignsFromSelfBenchmarks>(
			ManualConfig
				.Create(DefaultConfig.Instance)
				.WithOption(ConfigOptions.DisableOptimizationsValidator, true)
		);
		Assert.That(res.HasCriticalValidationErrors, Is.False);
	}

	[Benchmark(Baseline = true), Test]
	public void AssignFromSelf_Stock() => AssignFromSelf(_stock);

	[Benchmark, Test]
	public void AssignFromSelf_Heap() => AssignFromSelf(_heap);

	[Benchmark, Test]
	public void AssignFromSelf_Constileation() => AssignFromSelf(_const);

#if TILED_PLUGIN
	[Benchmark, Test]
	public void AssignFromSelf_1d() => AssignFromSelf(_1d);

	[Benchmark, Test]
	public void AssignFromSelf_2d() => AssignFromSelf(_2d);

	[Benchmark, Test]
	public void AssignFromSelf_Struct() => AssignFromSelf(_struct);
#endif

	public void AssignFromSelf(ICollection<ITile> provider)
	{
		for (int x = 0; x < Main.maxTilesX; x++)
			for (int y = 0; y < Main.maxTilesY; y++)
			{
				provider[x, y] = provider[x, y];
			}
	}
}
