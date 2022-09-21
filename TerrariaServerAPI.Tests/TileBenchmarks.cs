using ModFramework;
using NUnit.Framework;
using System;
using System.Diagnostics;
using Terraria;
using Terraria.Utilities;
using TerrariaServerAPI.TerrariaApi.Server.Tiles;

namespace TerrariaServerAPI.Tests;

public class TileBenchmarks: BaseTest
{
	[TestCase(10)]
	public void Clearing_Stock(int cycles) => ClearWorld(() => new DefaultCollection<ITile>(Main.maxTilesX, Main.maxTilesY), cycles);

	[TestCase(10)]
	public void Clearing_Heap(int cycles) => ClearWorld(() => new HeapTileProvider(), cycles);

	[TestCase(10)]
	public void Clearing_Orion(int cycles) => ClearWorld(() => new OrionTileCollection(), cycles);

#if TILED_PLUGIN
	[TestCase(10)]
	public void Clearing_1d(int cycles) => ClearWorld(() => new Tiled.OneDimension.OneDimensionTileProvider(), cycles);

	[TestCase(10)]
	public void Clearing_2d(int cycles) => ClearWorld(() => new Tiled.TwoDimensions.TwoDimensionTileProvider(), cycles);

	[TestCase(10)]
	public void Clearing_Struct(int cycles) => ClearWorld(() => new Tiled.Struct.Structured1DTileProvider(), cycles);
#endif

	public void ClearWorld<T>(Func<T> requestProvider, int cycles)
		 where T : ICollection<ITile>
	{
		SetWorldSmall();
		Main.tile = requestProvider();
		Console.WriteLine($"{Main.tile.GetType().Name}: Clearing world with {cycles} cycle(s)...");

		var sw = new Stopwatch();
		sw.Start();
		for (var i = 0; i < cycles; i++)
			WorldGen.clearWorld();

		sw.Stop();

		Console.WriteLine($"{Main.tile.GetType().Name}: Clear took: {sw.Elapsed.TotalSeconds:#.00}s ({sw.Elapsed.TotalMilliseconds / cycles:#.00}ms p/c)");
	}

	void SetWorldSmall()
	{
		Main.maxTilesX = 4200;
		Main.maxTilesY = 1200;
	}

	public void Generate_Small<T>(Func<T> requestProvider)
		 where T : ICollection<ITile>
	{
		SetWorldSmall();
		Main.tile = requestProvider();
		Console.WriteLine($"{Main.tile.GetType().Name}: Generate starting...");
		WorldGen.clearWorld();

		var sw = new Stopwatch();
		sw.Start();
		CreateNewWorld();
		sw.Stop();
		Console.WriteLine($"{Main.tile.GetType().Name}: Generate took: {sw.Elapsed.TotalSeconds:#.00}s");
	}

	[Test]
	public void Generate_Small_Stock()
		=> Generate_Small(() => new DefaultCollection<ITile>(Main.maxTilesX, Main.maxTilesY));

	[Test]
	public void Generate_Small_Heap()
		=> Generate_Small(() => new HeapTileProvider());

	[Test]
	public void Generate_Small_Orion()
		=> Generate_Small(() => new OrionTileCollection());

#if TILED_PLUGIN
	[Test]
	public void Generate_Small_1d()
		=> Generate_Small(() => new Tiled.OneDimension.OneDimensionTileProvider());

	[Test]
	public void Generate_Small_2d()
		=> Generate_Small(() => new Tiled.TwoDimensions.TwoDimensionTileProvider());

	[Test]
	public void Generate_Small_Struct()
		=> Generate_Small(() => new Tiled.Struct.Structured1DTileProvider());
#endif

	static void CreateNewWorld()
	{
		WorldGen.generatingWorld = true;
		Main.rand = new UnifiedRandom(9999);
		WorldGen.gen = true;
		Main.menuMode = 888;
		WorldGen.GenerateWorld(9999);
	}
}
