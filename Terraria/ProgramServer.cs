using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TerrariaApi.Server;

namespace Terraria
{
	internal class ProgramServer
	{
		private static Main Game;

		static ProgramServer()
		{
		}

		public ProgramServer()
		{
		}

		private static void InnerStart(string[] args)
		{
			try
			{
				Program.LaunchParameters = Utils.ParseArguements(args);
				ProgramServer.Game = new Main();
				string str = null;
				if (str != null)
				{
					ProgramServer.Game.SetWorld(str);
				}
				try
				{
					Console.WriteLine("TerrariaAPI Version: " + ServerApi.ApiVersion + " (Protocol {0} ({1}))", Terraria.Main.versionNumber2, Terraria.Main.curRelease);
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
	}
}