using ModFramework;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Terraria;
using Terraria.Utilities;
using TerrariaServerAPI.TerrariaApi.Server.Tiles;

namespace TerrariaServerAPI.Tests;

public class TileBenchmarks
{
	[OneTimeSetUp]
	public void Init()
	{
		var are = new AutoResetEvent(false);
		Exception? error = null;
		On.Terraria.Main.hook_DedServ cb = (On.Terraria.Main.orig_DedServ orig, Terraria.Main instance) =>
		{
			instance.Initialize();
			are.Set();
		};
		On.Terraria.Main.DedServ += cb;

		global::TerrariaApi.Server.Program.Main(new string[] { });

		var hit = are.WaitOne(TimeSpan.FromSeconds(30));

		On.Terraria.Main.DedServ -= cb;

		Assert.That(hit, Is.True);
		Assert.That(error, Is.Null);
	}

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
		Console.WriteLine("Clearing world...");
		Main.tile = requestProvider();
		var max = 10;

		var sw = new Stopwatch();
		sw.Start();
		for (var i = 0; i < max; i++)
			WorldGen.clearWorld();
		sw.Stop();
		Console.WriteLine($"Clear took: {sw.Elapsed.TotalSeconds}s ({sw.Elapsed.TotalSeconds / max}s avg)");
	}

	void SetWorldSmall()
	{
		Main.maxTilesX = 4200;
		Main.maxTilesY = 1200;
	}

	public void Generate_Small<T>(Func<T> requestProvider)
		 where T : ICollection<ITile>
	{
		Console.WriteLine("Generate starting...");
		SetWorldSmall();
		Main.tile = requestProvider();
		WorldGen.clearWorld();
		var max = 1;

		var sw = new Stopwatch();
		sw.Start();
		for (var i = 0; i < max; i++)
			CreateNewWorld();
		sw.Stop();
		Console.WriteLine($"Generate took: {sw.Elapsed.TotalSeconds}s ({sw.Elapsed.TotalSeconds / max}s avg)");
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
