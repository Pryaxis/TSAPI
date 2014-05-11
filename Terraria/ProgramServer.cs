using System;
using System.Diagnostics;
using System.IO;
using TerrariaApi.Server;
namespace Terraria
{
	internal class ProgramServer
	{
		private static Main Game;
		private static void Main(string[] args)
		{
			try
			{
				Game = new Main();

				if (Environment.OSVersion.Platform == PlatformID.Unix)
					Terraria.Main.SavePath = "Terraria";
				else
					Terraria.Main.SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games", "Terraria");

				Terraria.Main.WorldPath = Path.Combine(Terraria.Main.SavePath, "Worlds");
				Terraria.Main.PlayerPath = Path.Combine(Terraria.Main.SavePath, "Players");

				try
				{
					Console.WriteLine("TerrariaAPI Version: " + ServerApi.ApiVersion + " (Protocol {0})", Terraria.Main.versionNumber2);
					ServerApi.Initialize(args, Game);
				}
				catch (Exception ex)
				{
					ServerApi.LogWriter.ServerWriteLine(
						"Startup aborted due to an exception in the Server API initialization:\n" + ex, TraceLevel.Error);

					Console.ReadLine();
					return;
				}

				Game.DedServ();
				ServerApi.DeInitialize();
			}
			catch (Exception ex)
			{
				ServerApi.LogWriter.ServerWriteLine("Server crashed due to an unhandled exception:\n" + ex, TraceLevel.Error);
				Console.ReadLine();
			}
		}
	}
}
