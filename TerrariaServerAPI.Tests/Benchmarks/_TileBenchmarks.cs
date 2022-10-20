using BenchmarkDotNet.Attributes;
using ModFramework;
using NUnit.Framework;
using Terraria;
using TerrariaApi.Server;

namespace TerrariaServerAPI.Tests.Benchmarks;

/// <summary>
/// Defines the basic functionality for tile benchmarks to reuse, such as priming each provider
/// </summary>
public abstract class TileBenchmarks : BaseTest
{
	protected ICollection<ITile> _stock;
	protected ICollection<ITile> _heap;
	protected ICollection<ITile> _const;
#if TILED_PLUGIN
	protected ICollection<ITile> _1d;
	protected ICollection<ITile> _2d;
	protected ICollection<ITile> _struct;
#endif

	/// <summary>
	/// A collection of all providers to be used by benchmarks
	/// </summary>
	protected System.Collections.Generic.IEnumerable<ICollection<ITile>> _all;

	/// <summary>
	/// Called to prepare Terraria "staticness" and to prime providers so each benchmark is not testing init code.
	/// </summary>
	[SetUp, GlobalSetup]
	public void PrepareBench()
	{
		Terraria.Program.SavePath = ""; // Terraria.Main requires this to not be null
		SetWorldSmall();

		// preallocate the providers, so init code does not affect measurements
		_stock = new DefaultCollection<ITile>(Main.maxTilesX, Main.maxTilesY);
		_heap = new TileProvider();
		_const = new ConstileationProvider();
#if TILED_PLUGIN
		_1d = new Tiled.OneDimension.OneDimensionTileProvider();
		_2d = new Tiled.TwoDimensions.TwoDimensionTileProvider();
		_struct = new Tiled.Struct.Structured1DTileProvider();
#endif

		_all = new[] { _stock, _heap, _const,
#if TILED_PLUGIN
			_1d, _2d, _struct
#endif
		};

		// touch each getter of the provider, as its common for them to create internal structures on the first access of a tile
		// this is typically because terraria (at least in the past) would precreate the tile array with large world figures,
		// and since most tile providers aim to reduce memory they will try not to overallocate unless needed.
		foreach (var prov in _all)
			_ = prov[0, 0];

		// allow inheritors to do extra priming
		OnSetup();
	}

	/// <summary>
	/// Called when the benchmarks are being setup, before running the benchmark.
	/// </summary>
	protected virtual void OnSetup() { }

	/// <summary>
	/// Sets the world dimensions to a small world
	/// </summary>
	protected void SetWorldSmall()
	{
		Main.maxTilesX = 4200;
		Main.maxTilesY = 1200;
	}
}
