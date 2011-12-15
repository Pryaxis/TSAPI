using System;
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
				ProgramServer.Game = new Main();
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
				}
				ProgramServer.Game.DedServ();
			}
			catch (Exception value)
			{
				try
				{
					using (StreamWriter streamWriter = new StreamWriter("crashlog.txt", true))
					{
						streamWriter.WriteLine(DateTime.Now);
						streamWriter.WriteLine(value);
						streamWriter.WriteLine("");
					}
					Console.WriteLine("Server crash: " + DateTime.Now);
					Console.WriteLine(value);
					Console.WriteLine("");
					Console.WriteLine("Please send crashlog.txt to support@terraria.org");
				}
				catch
				{
				}
			}
		}
	}
}
