using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Terraria;
using TerrariaApi.Reporting;

namespace TerrariaApi.Server
{
	// TODO: Maybe re-implement a reload functionality for plugins, but you'll have to load all assemblies into their own
	// AppDomain in order to unload them again later. Beware that having them in their own AppDomain might cause threading
	// problems as usual locks will only work in their own AppDomains.
	public static class ServerApi
	{
		public static readonly Version ApiVersion = new Version(2, 1, 0, 0);
		private static Main game;
		private static List<IPluginContainer> plugins = new List<IPluginContainer>();

		internal static readonly CrashReporter reporter = new CrashReporter();
		public static IReadOnlyCollection<IPluginContainer> Plugins => new List<IPluginContainer>(plugins);
		public static HookManager Hooks { get; private set; }
		public static LogWriterManager LogWriter { get; private set; }
		public static ProfilerManager Profiler { get; private set; }
		public static IPluginLoader PluginLoader { get; set; }
		public static bool IsWorldRunning { get; internal set; }
		public static bool RunningMono { get; private set; }
		public static bool ForceUpdate { get; private set; }
		public static bool UseAsyncSocketsInMono { get; private set; }

		static ServerApi()
		{
			Hooks = new HookManager();
			LogWriter = new LogWriterManager();
			Profiler = new ProfilerManager();

			UseAsyncSocketsInMono = false;
			ForceUpdate = false;
			Type t = Type.GetType("Mono.Runtime");
			RunningMono = (t != null);
			Main.SkipAssemblyLoad = true;
		}

		internal static void Initialize(string[] commandLineArgs, Main game)
		{
			Profiler.BeginMeasureServerInitTime();
			LogWriter.ServerWriteLine(
				string.Format("TerrariaApi - Server v{0} started.", ApiVersion), TraceLevel.Verbose);
			LogWriter.ServerWriteLine(
				"\tCommand line: " + Environment.CommandLine, TraceLevel.Verbose);
			LogWriter.ServerWriteLine(
				string.Format("\tOS: {0} (64bit: {1})", Environment.OSVersion, Environment.Is64BitOperatingSystem), TraceLevel.Verbose);
			LogWriter.ServerWriteLine(
				"\tMono: " + RunningMono, TraceLevel.Verbose);

			ServerApi.game = game;
			HandleCommandLine(commandLineArgs);
			plugins = PluginLoader.LoadPlugins().ToList();
		}

		internal static void DeInitialize()
		{
			UnloadPlugins();
			Profiler.Deatch();
			LogWriter.Deatch();
		}

		internal static void HandleCommandLine(string[] parms)
		{
			var args = Utils.ParseArguements(parms);

			foreach (var arg in args)
			{
				switch (arg.Key.ToLower())
				{
					case "-forceupdate":
						{
							ServerApi.ForceUpdate = true;
							ServerApi.LogWriter.ServerWriteLine(
								"Forcing game updates regardless of players! This is experimental, and will cause constant CPU usage, you are on your own.",
								TraceLevel.Warning);

							break;
						}
					case "-asyncmono":
						{
							ServerApi.UseAsyncSocketsInMono = true;
							ServerApi.LogWriter.ServerWriteLine(
								"Forcing Mono to use asynchronous sockets.  This is highly experimental and may not work on all versions of Mono.",
								TraceLevel.Warning);
							break;
						}
					case "-players":
						{
							int playerCount;
							if (!Int32.TryParse(arg.Value, out playerCount))
							{
								ServerApi.LogWriter.ServerWriteLine("Invalid player count. Using 8", TraceLevel.Warning);

								playerCount = 8;
							}

							game.SetNetPlayers(playerCount);

							break;
						}
					case "-maxplayers":
						goto case "-players";
					case "-pass":
						{
							Netplay.ServerPassword = arg.Value;

							break;
						}
					case "-password":
						goto case "-pass";
					case "-worldname":
						{
							game.SetWorldName(arg.Value);

							break;
						}
					case "-world":
						{
							game.SetWorld(arg.Value, false);

							var full_path = Path.GetFullPath(arg.Value);
							Main.WorldPath = Path.GetDirectoryName(full_path);
							Main.worldName = Path.GetFileNameWithoutExtension(full_path);

							break;
						}
					case "-motd":
						{
							game.NewMOTD(arg.Value);

							break;
						}
					case "-banlist":
						{
							Netplay.BanFilePath = arg.Value;

							break;
						}
					case "-autoshutdown":
						{
							game.EnableAutoShutdown();

							break;
						}
					case "-secure":
						{
							Netplay.spamCheck = true;

							break;
						}
					case "-autocreate":
						{
							game.autoCreate(arg.Value);

							break;
						}
					case "-loadlib":
						{
							game.loadLib(arg.Value);

							break;
						}
					case "-crashdir":
						CrashReporter.crashReportPath = arg.Value;
						break;
				}
			}
		}

		internal static void UnloadPlugins()
		{
			foreach (var pluginContainer in plugins)
			{
				try
				{
					PluginLoader.UnloadPlugin(pluginContainer);
				}
				catch (Exception ex)
				{
					LogWriter.ServerWriteLine(string.Format(
						"Plugin \"{0}\" has thrown an exception while being deinitialized:\n{1}", pluginContainer.Plugin.Name, ex),
						TraceLevel.Error);
				}
			}
		}

	}
}
