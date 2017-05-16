using System;
using System.Diagnostics;
using System.Linq;
using Terraria.ID;
using TerrariaApi.Server;

namespace OTAPI.Shims.TShock
{
	class Program
	{
		/// <summary>
		/// Initialises any internal values before any server initialisation begins
		/// </summary>
		public static void InitialiseInternals()
		{
			ItemID.Sets.Explosives = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				ItemID.Bomb,
				ItemID.Dynamite,
				ItemID.StickyBomb,
				ItemID.Explosives,
				ItemID.GrenadeLauncher,
				ItemID.RocketLauncher,
				ItemID.RocketII,
				ItemID.RocketIV,
				ItemID.SnowmanCannon,
				ItemID.StickyDynamite,
				ItemID.BouncyBomb,
				ItemID.BombFish
			});

			//Set corrupt tiles to true, as they aren't in vanilla
			TileID.Sets.Corrupt[TileID.CorruptGrass] = true;
			TileID.Sets.Corrupt[TileID.CorruptPlants] = true;
			TileID.Sets.Corrupt[TileID.CorruptThorns] = true;
			TileID.Sets.Corrupt[TileID.CorruptIce] = true;
			TileID.Sets.Corrupt[TileID.CorruptHardenedSand] = true;
			TileID.Sets.Corrupt[TileID.CorruptSandstone] = true;
			TileID.Sets.Corrupt[TileID.Ebonstone] = true;
			TileID.Sets.Corrupt[TileID.Ebonsand] = true;

			//Same again for crimson
			TileID.Sets.Crimson[TileID.FleshBlock] = true;
			TileID.Sets.Crimson[TileID.FleshGrass] = true;
			TileID.Sets.Crimson[TileID.FleshIce] = true;
			TileID.Sets.Crimson[TileID.FleshWeeds] = true;
			TileID.Sets.Crimson[TileID.Crimstone] = true;
			TileID.Sets.Crimson[TileID.Crimsand] = true;
			TileID.Sets.Crimson[TileID.CrimsonVines] = true;
			TileID.Sets.Crimson[TileID.CrimtaneThorns] = true;
			TileID.Sets.Crimson[TileID.CrimsonHardenedSand] = true;
			TileID.Sets.Crimson[TileID.CrimsonSandstone] = true;

			//And hallow
			TileID.Sets.Hallow[TileID.HallowedGrass] = true;
			TileID.Sets.Hallow[TileID.HallowedPlants] = true;
			TileID.Sets.Hallow[TileID.HallowedPlants2] = true;
			TileID.Sets.Hallow[TileID.HallowedVines] = true;
			TileID.Sets.Hallow[TileID.HallowedIce] = true;
			TileID.Sets.Hallow[TileID.HallowHardenedSand] = true;
			TileID.Sets.Hallow[TileID.HallowSandstone] = true;
			TileID.Sets.Hallow[TileID.Pearlsand] = true;
			TileID.Sets.Hallow[TileID.Pearlstone] = true;
		}

		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += UnhandledException;
			try
			{
				InitialiseInternals();
				ServerApi.Hooks.AttachOTAPIHooks(args);

				// avoid any Terraria.Main calls here or the heaptile hook will not work.
				// this is because the hook is executed on the Terraria.Main static constructor,
				// and simply referencing it in this method will trigger the constructor.
				StartServer(args);

				ServerApi.DeInitialize();
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine("Server crashed due to an unhandled exception:\n" + ex, TraceLevel.Error);
			}
		}

		static void StartServer(string[] args)
		{
			if (args.Any(x => x == "-skipassemblyload"))
			{
				Terraria.Main.SkipAssemblyLoad = true;
			}

			Terraria.WindowsLaunch.Main(args);
		}

		/// <summary>
		/// TShock sets up its own unhandled exception handler; this one is just to catch possible
		/// startup exceptions
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Console.WriteLine($"Unhandled exception\n{e}");
		}


	}
}
