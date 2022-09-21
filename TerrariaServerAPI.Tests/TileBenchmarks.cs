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
	[Test]
	public void Clearing_Stock() => ClearWorld(() => new DefaultCollection<ITile>(Main.maxTilesX, Main.maxTilesY));

	[Test]
	public void Clearing_Heap() => ClearWorld(() => new HeapTileProvider());
	[Test]
	public void Clearing_Orion() => ClearWorld(() => new OrionTileCollection());

	public void ClearWorld<T>(Func<T> requestProvider)
		 where T : ICollection<ITile>
	{
		SetWorldSmall();
		Main.tile = requestProvider();
		Console.WriteLine($"{Main.tile.GetType().Name}: Clearing world...");
		var max = 10;

		var sw = new Stopwatch();
		sw.Start();
		for (var i = 0; i < max; i++)
			WorldGen.clearWorld();
		sw.Stop();
		Console.WriteLine($"{Main.tile.GetType().Name}: Clear took: {sw.Elapsed.TotalSeconds}s ({sw.Elapsed.TotalSeconds / max}s avg)");
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
		Console.WriteLine($"{Main.tile.GetType().Name} :Generate starting...");
		WorldGen.clearWorld();
		var max = 1;

		var sw = new Stopwatch();
		sw.Start();
		for (var i = 0; i < max; i++)
			CreateNewWorld();
		sw.Stop();
		Console.WriteLine($"{Main.tile.GetType().Name}: Generate took: {sw.Elapsed.TotalSeconds}s ({sw.Elapsed.TotalSeconds / max}s avg)");
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

	static void CreateNewWorld()
	{
		WorldGen.generatingWorld = true;
		Main.rand = new UnifiedRandom(9999);
		WorldGen.gen = true;
		Main.menuMode = 888;
		WorldGen.GenerateWorld(9999);
	}
}
