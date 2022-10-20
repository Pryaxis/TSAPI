using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using NUnit.Framework;
using System.Linq;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// Allows all benchmarks to be run in one go (as an alternate to test explorer in VS)
/// </summary>
public class Benchmarks
{
	[Test]
	public void RunAllBenchmarks()
	{
		var res = BenchmarkRunner.Run(this.GetType().Assembly,
			ManualConfig
				.Create(DefaultConfig.Instance)
				.WithOption(ConfigOptions.DisableOptimizationsValidator, true)
		);
		Assert.That(res.Any(x => x.HasCriticalValidationErrors), Is.False);
	}
}
