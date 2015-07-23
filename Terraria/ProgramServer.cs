using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Terraria.Social;
using TerrariaApi.Server;

namespace Terraria
{
	internal class ProgramServer
	{
		private static bool isClosing;

		private static ProgramServer.HandlerRoutine _handleRoutine;

		private static Main Game;

		static ProgramServer()
		{
			ProgramServer.isClosing = false;
		}

		public ProgramServer()
		{
		}

		private static bool ConsoleCtrlCheck(ProgramServer.CtrlTypes ctrlType)
		{
			switch (ctrlType)
			{
				case ProgramServer.CtrlTypes.CTRL_C_EVENT:
				{
					ProgramServer.isClosing = true;
					if (ProgramServer.isClosing)
					{
						SocialAPI.Shutdown();
					}
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_BREAK_EVENT:
				{
					ProgramServer.isClosing = true;
					if (ProgramServer.isClosing)
					{
						SocialAPI.Shutdown();
					}
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_CLOSE_EVENT:
				{
					ProgramServer.isClosing = true;
					if (ProgramServer.isClosing)
					{
						SocialAPI.Shutdown();
					}
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_BREAK_EVENT | ProgramServer.CtrlTypes.CTRL_CLOSE_EVENT:
				{
					if (ProgramServer.isClosing)
					{
						SocialAPI.Shutdown();
					}
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_LOGOFF_EVENT:
				case ProgramServer.CtrlTypes.CTRL_SHUTDOWN_EVENT:
				{
					ProgramServer.isClosing = true;
					if (ProgramServer.isClosing)
					{
						SocialAPI.Shutdown();
					}
					return true;
				}
				default:
				{
					if (ProgramServer.isClosing)
					{
						SocialAPI.Shutdown();
					}
					return true;
				}
			}
		}

		private static void InnerStart(string[] args)
		{
			try
			{
				Program.LaunchParameters = Utils.ParseArguements(args);
				ProgramServer.Game = new Main();
				string str = null;
				int num = 0;
				SocialMode socialMode = SocialMode.None;

				foreach(KeyValuePair<string, string> arg in Program.LaunchParameters)
				{
					switch(arg.Key.ToLower())
					{
						case "-players":
							int playerCount;
							if (!Int32.TryParse(arg.Value, out playerCount))
							{
								Console.WriteLine("Invalid player count. Using 8");
								playerCount = 8;
							}

							ProgramServer.Game.SetNetPlayers(playerCount);
							break;
						case "-maxplayers":
							goto case "-players";
						case "-pass":
							Netplay.ServerPassword = arg.Value;
							break;
						case "-password":
							goto case "-pass";
						case "-lang":
							int lang;
							if (!Int32.TryParse(arg.Value, out lang))
							{
								Console.WriteLine("Invalid language. Using English");
								lang = 1;
							}

							Lang.lang = lang;
							break;
						case "-steam":
							socialMode = SocialMode.Steam;
							break;
						case "-worldname":
							ProgramServer.Game.SetWorldName(arg.Value);
							break;
						case "-world":
							if (!Program.LaunchParameters.ContainsKey("-autocreate") && File.Exists(args[num]) == false)
								throw new Exception("Terraria world at path \"" + arg.Value + "\" doesn't exist.");

							ProgramServer.Game.SetWorld(args[num]);
							break;
						case "-motd":
							ProgramServer.Game.NewMOTD(args[num]);
							break;
						case "-banlist":
							Netplay.BanFilePath = arg.Value;
							break;
						case "-autoshutdown":
							ProgramServer.Game.autoShut();
							break;
						case "-secure":
							Netplay.spamCheck = true;
							break;
						case "-autocreate":
							ProgramServer.Game.autoCreate(arg.Value);
							break;
						case "-loadlib":
							ProgramServer.Game.loadLib(arg.Value);
							break;
					}
				}

				SocialAPI.Initialize(new SocialMode?(socialMode));
				if (str != null)
				{
					ProgramServer.Game.SetWorld(str);
				}
				try
				{
					Console.WriteLine("TerrariaAPI Version: " + ServerApi.ApiVersion + " (Protocol {0} ({1}))", Terraria.Main.versionNumber2, Terraria.Main.curRelease);
					Console.WriteLine("SendQ edition");
					ServerApi.Initialize(args, Game);
				}
				catch (Exception ex)
				{
					ServerApi.LogWriter.ServerWriteLine(
						"Startup aborted due to an exception in the Server API initialization:\n" + ex, TraceLevel.Error);

					Console.ReadLine();
					return;
				}
				ProgramServer.Game.DedServ();
				ServerApi.DeInitialize();
			}
			catch (Exception exception1)
			{
				ServerApi.LogWriter.ServerWriteLine("Server crashed due to an unhandled exception:\n" + exception1, TraceLevel.Error);
			}
		}

		private static void Main(string[] args)
		{
			ProgramServer._handleRoutine = new ProgramServer.HandlerRoutine(ProgramServer.ConsoleCtrlCheck);
			//ProgramServer.SetConsoleCtrlHandler(ProgramServer._handleRoutine, true);
			ProgramServer.InnerStart(args);
		}

		public enum CtrlTypes
		{
			CTRL_C_EVENT = 0,
			CTRL_BREAK_EVENT = 1,
			CTRL_CLOSE_EVENT = 2,
			CTRL_LOGOFF_EVENT = 5,
			CTRL_SHUTDOWN_EVENT = 6
		}

		public delegate bool HandlerRoutine(ProgramServer.CtrlTypes CtrlType);
	}
}