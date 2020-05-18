using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NLog;
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
		internal static readonly CrashReporter reporter = new CrashReporter();
		internal static Logger Log = LogManager.GetLogger("Server");
		public static HookManager Hooks { get; private set; }
		public static PluginManager PluginManager { get; } = new PluginManager();
		public static bool IsWorldRunning { get; internal set; }
		public static bool RunningMono { get; private set; }
		public static bool ForceUpdate { get; private set; }
		public static bool UseAsyncSocketsInMono { get; private set; }

		static ServerApi()
		{
			Hooks = new HookManager();

			UseAsyncSocketsInMono = false;
			ForceUpdate = false;
			Type t = Type.GetType("Mono.Runtime");
			RunningMono = (t != null);
			Main.SkipAssemblyLoad = true;
		}

		internal static void Initialize(string[] commandLineArgs, Main game)
		{
			Log.Debug($"TerrariaApi - Server v{ApiVersion} started.");
			Log.Debug($"\tCommand line: {Environment.CommandLine}");
			Log.Debug($"\tOS: {Environment.OSVersion} (64bit: {Environment.Is64BitOperatingSystem})");
			Log.Debug($"\tMono: {RunningMono}");

			ServerApi.game = game;
			HandleCommandLine(commandLineArgs);
			PluginManager.LoadPlugins();
			PluginManager.InitializeAllPlugins();
		}

		internal static void DeInitialize()
		{
			PluginManager.UnloadAllPlugins();
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
							ForceUpdate = true;
							Log.Warn("Forcing game updates regardless of players! This is experimental, and will cause constant CPU usage, you are on your own.");
							break;
						}
					case "-asyncmono":
						{
							UseAsyncSocketsInMono = true;
							Log.Warn("Forcing Mono to use asynchronous sockets.  This is highly experimental and may not work on all versions of Mono.");
							break;
						}
					case "-players":
						{
							if (!Int32.TryParse(arg.Value, out var playerCount))
							{
								Log.Warn("Invalid player count. Using 8");
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
							Netplay.SpamCheck = true;
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
	}
}
