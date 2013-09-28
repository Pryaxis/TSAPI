using System;
using System.Diagnostics;
using TerrariaApi.Server;
using System.IO;
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
			}/*
			Game = new Main();
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i].ToLower() == "-config")
				{
					i++;
					ProgramServer.Game.LoadDedConfig(args[i]);
				}
				if (args[i].ToLower() == "-port")
				{
					i++;
					try
					{
						int serverPort = Convert.ToInt32(args[i]);
						Netplay.serverPort = serverPort;
					}
					catch
					{
					}
				}
				if (args[i].ToLower() == "-players" || args[i].ToLower() == "-maxplayers")
				{
					i++;
					try
					{
						int netPlayers = Convert.ToInt32(args[i]);
						ProgramServer.Game.SetNetPlayers(netPlayers);
					}
					catch
					{
					}
				}
				if (args[i].ToLower() == "-pass" || args[i].ToLower() == "-password")
				{
					i++;
					Netplay.password = args[i];
				}
				if (args[i].ToLower() == "-lang")
				{
					i++;
					Lang.lang = Convert.ToInt32(args[i]);
				}
				if (args[i].ToLower() == "-world")
				{
					i++;
					ProgramServer.Game.SetWorld(args[i]);
				}
				if (args[i].ToLower() == "-worldname")
				{
					i++;
					ProgramServer.Game.SetWorldName(args[i]);
				}
				if (args[i].ToLower() == "-motd")
				{
					i++;
					ProgramServer.Game.NewMOTD(args[i]);
				}
				if (args[i].ToLower() == "-banlist")
				{
					i++;
					Netplay.banFile = args[i];
				}
				if (args[i].ToLower() == "-autoshutdown")
				{
					ProgramServer.Game.autoShut();
				}
				if (args[i].ToLower() == "-secure")
				{
					Netplay.spamCheck = true;
				}
				if (args[i].ToLower() == "-autocreate")
				{
					i++;
					string newOpt = args[i];
					ProgramServer.Game.autoCreate(newOpt);
				}
				if (args[i].ToLower() == "-loadlib")
				{
					i++;
					string path = args[i];
					ProgramServer.Game.loadLib(path);
				}
				if (args[i].ToLower() == "-noupnp")
				{
					Netplay.uPNP = false;
				}
			}
			ProgramServer.Game.DedServ();*/
		}
	}
}
