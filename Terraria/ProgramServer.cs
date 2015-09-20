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
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_BREAK_EVENT:
				{
					ProgramServer.isClosing = true;
			
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_CLOSE_EVENT:
				{
					ProgramServer.isClosing = true;
				
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_BREAK_EVENT | ProgramServer.CtrlTypes.CTRL_CLOSE_EVENT:
				{
			
					return true;
				}
				case ProgramServer.CtrlTypes.CTRL_LOGOFF_EVENT:
				case ProgramServer.CtrlTypes.CTRL_SHUTDOWN_EVENT:
				{
					ProgramServer.isClosing = true;
					return true;
				}
				default:
				{
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