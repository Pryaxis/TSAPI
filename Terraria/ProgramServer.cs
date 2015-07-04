using System;
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
				Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
				ProgramServer.Game = new Main();
				string str = null;
				bool flag = false;
				int num = 0;
				SocialMode socialMode = SocialMode.None;
				while (num < (int)args.Length)
				{
					if (args[num].ToLower() == "-config")
					{
						num++;
						ProgramServer.Game.LoadDedConfig(args[num]);
					}
					if (args[num].ToLower() == "-port")
					{
						num++;
						try
						{
							Netplay.ListenPort = Convert.ToInt32(args[num]);
						}
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}
					}
					if (args[num].ToLower() == "-players" || args[num].ToLower() == "-maxplayers")
					{
						num++;
						try
						{
							int num1 = Convert.ToInt32(args[num]);
							ProgramServer.Game.SetNetPlayers(num1);
						}
						catch (Exception ex)
						{
#if DEBUG
							Console.WriteLine(ex);
							System.Diagnostics.Debugger.Break();

#endif
						}
					}
					if (args[num].ToLower() == "-pass" || args[num].ToLower() == "-password")
					{
						num++;
						Netplay.ServerPassword = args[num];
					}
					if (args[num].ToLower() == "-lang")
					{
						num++;
						Lang.lang = Convert.ToInt32(args[num]);
					}
					if (args[num].ToLower() == "-world")
					{
						num++;
						str = args[num];
						flag = false;
					}
					if (args[num].ToLower() == "-steam")
					{
						socialMode = SocialMode.Steam;
					}
					if (args[num].ToLower() == "-cloudworld")
					{
						num++;
						str = args[num];
						flag = true;
					}
					if (args[num].ToLower() == "-worldname")
					{
						num++;
						ProgramServer.Game.SetWorldName(args[num]);
					}
					if (args[num].ToLower() == "-motd")
					{
						num++;
						ProgramServer.Game.NewMOTD(args[num]);
					}
					if (args[num].ToLower() == "-banlist")
					{
						num++;
						Netplay.BanFilePath = args[num];
					}
					if (args[num].ToLower() == "-autoshutdown")
					{
						ProgramServer.Game.autoShut();
					}
					if (args[num].ToLower() == "-secure")
					{
						Netplay.spamCheck = true;
					}
					if (args[num].ToLower() == "-autocreate")
					{
						num++;
						string str1 = args[num];
						ProgramServer.Game.autoCreate(str1);
					}
					if (args[num].ToLower() == "-loadlib")
					{
						num++;
						string str2 = args[num];
						ProgramServer.Game.loadLib(str2);
					}
					if (args[num].ToLower() == "-noupnp")
					{
						Netplay.UseUPNP = false;
					}
					num++;
				}
				SocialAPI.Initialize(new SocialMode?(socialMode));
				if (str != null)
				{
					ProgramServer.Game.SetWorld(str, flag);
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
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler((object sender, ResolveEventArgs sargs) => {
				Assembly assembly;
				string str = string.Concat((new AssemblyName(sargs.Name)).Name, ".dll");
				string str1 = Array.Find<string>(typeof(ProgramServer).Assembly.GetManifestResourceNames(), (string element) => element.EndsWith(str));
				using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(str1))
				{
					byte[] numArray = new byte[checked(manifestResourceStream.Length)];
					manifestResourceStream.Read(numArray, 0, (int)numArray.Length);
					assembly = Assembly.Load(numArray);
				}
				return assembly;
			});
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