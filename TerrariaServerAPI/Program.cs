using System;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using TerrariaApi.Server;

namespace OTAPI.Shims.TShock
{
	class Program
	{
		//private static Main Game;

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
		}

		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += UnhandledException;
			try
			{
				//AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs sargs)
				//{
				//	if (sargs.Name.StartsWith("TerrariaServer"))
				//	{
				//		return typeof(OTAPI.Shims.TShock.Program).Assembly;
				//	}
				//	return null;
				//};

				//Terraria.Program.LaunchParameters = Utils.ParseArguements(args);

				//InitialiseInternals();

				////Game = new Main();

				//try
				//{
				//	Console.WriteLine("TerrariaAPI Version: " + ServerApi.ApiVersion + " (Protocol {0} ({1}), OTAPI {2})",
				//		Terraria.Main.versionNumber2, Terraria.Main.curRelease,
				//		typeof(OTAPI.Hooks).Assembly.GetName().Version);
				//	ServerApi.Initialize(args, Game);
				//}
				//catch (Exception ex)
				//{
				//	ServerApi.LogWriter.ServerWriteLine(
				//		"Startup aborted due to an exception in the Server API initialization:\n" + ex, TraceLevel.Error);

				//	Console.ReadLine();
				//	return;
				//}


				//Game.DedServ();

				OTAPI.Shims.TShock.Program.InitialiseInternals();
				ServerApi.Hooks.AttachHooks();

				Terraria.WindowsLaunch.Main(args);
				ServerApi.DeInitialize();
			}
			catch (Exception exception1)
			{
				ServerApi.LogWriter.ServerWriteLine("Server crashed due to an unhandled exception:\n" + exception1, TraceLevel.Error);
			}
		}

		private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Console.WriteLine("Unhandled exception");
		}
	}
}
