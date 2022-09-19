using System.Diagnostics;
using Terraria.ID;
using ReLogic.OS;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TerrariaApi.Server
{
	public static class Program
	{
		/// <summary>
		/// Initialises any internal values before any server initialisation begins
		/// </summary>
		static void InitialiseInternals()
		{
			ItemID.Sets.Explosives = ItemID.Sets.Factory.CreateBoolSet(new int[]
			{
				// Bombs
				ItemID.Bomb,
				ItemID.StickyBomb,
				ItemID.BouncyBomb,
				ItemID.BombFish,
				ItemID.DirtBomb,
				ItemID.DirtStickyBomb,
				ItemID.ScarabBomb,
				// Launchers
				ItemID.GrenadeLauncher,
				ItemID.RocketLauncher,
				ItemID.SnowmanCannon,
				ItemID.Celeb2,
				// Rockets
				ItemID.RocketII,
				ItemID.RocketIV,
				ItemID.ClusterRocketII,
				ItemID.MiniNukeII,
				// The following are classified as explosives untill we can figure out a better way.
				ItemID.DryRocket,
				ItemID.WetRocket,
				ItemID.LavaRocket,
				ItemID.HoneyRocket,
				// Explosives & misc
				ItemID.Dynamite,
				ItemID.Explosives,
				ItemID.StickyDynamite
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
			TileID.Sets.Crimson[TileID.CrimsonGrass] = true;
			TileID.Sets.Crimson[TileID.FleshIce] = true;
			TileID.Sets.Crimson[TileID.CrimsonPlants] = true;
			TileID.Sets.Crimson[TileID.Crimstone] = true;
			TileID.Sets.Crimson[TileID.Crimsand] = true;
			TileID.Sets.Crimson[TileID.CrimsonVines] = true;
			TileID.Sets.Crimson[TileID.CrimsonThorns] = true;
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

		/// <summary>
		/// 1.4.4.2 introduced another static variable, which needs to be setup before any Main calls
		/// </summary>
		static void PrepareSavePath(string[] args)
		{
			Terraria.Program.LaunchParameters = Terraria.Utils.ParseArguements(args);
			Terraria.Program.SavePath = (Terraria.Program.LaunchParameters.ContainsKey("-savedirectory")
				? Terraria.Program.LaunchParameters["-savedirectory"]
				: Platform.Get<IPathService>().GetStoragePath("Terraria"));
		}

		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += UnhandledException;
			try
			{
				PrepareSavePath(args);
				InitialiseInternals();

				IHostBuilder hostBuilder = DIBuilder.ConfigureHost(args);
				hostBuilder.ConfigureServices(svcs => svcs
					.AddSingleton<ServiceLoader>()
					.AddSingleton<HookService>());

				IHost host = hostBuilder.Build();

				HookService hookService = host.Services.GetRequiredService<HookService>();
				hookService.AttachOtapiHooks(args);

				// avoid any Terraria.Main calls here or the heaptile hook will not work.
				// this is because the hook is executed on the Terraria.Main static constructor,
				// and simply referencing it in this method will trigger the constructor.
				StartServer(args);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Server initialization failed due to uncaught exception: \n{0}", ex);
			}
		}

		static void StartServer(string[] args)
		{
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
