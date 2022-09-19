using OTAPI;
using System;
using System.Linq;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
	internal static class ServerHooks
	{
		private static HookService _hookService;

		/// <summary>
		/// Attaches any of the OTAPI Server hooks to the existing <see cref="HookService"/> implementation
		/// </summary>
		/// <param name="hookService">HookService instance which will receive the events</param>
		public static void AttachTo(HookService hookService)
		{
			_hookService = hookService;

			On.Terraria.Main.startDedInput += Main_startDedInput;
			On.Terraria.RemoteClient.Reset += RemoteClient_Reset;
			Hooks.Main.CommandProcess += OnProcess;
		}

		static void Main_startDedInput(On.Terraria.Main.orig_startDedInput orig)
		{
			if (Environment.GetCommandLineArgs().Any(x => x.Equals("-disable-commands")))
			{
				Console.WriteLine("Command thread has been disabled.");
				return;
			}

			orig();
		}

		static void RemoteClient_Reset(On.Terraria.RemoteClient.orig_Reset orig, RemoteClient client)
		{
			if (!Netplay.Disconnect)
			{
				if (client.IsActive)
				{
					_hookService.InvokeServerLeave(client.Id);
				}
				_hookService.InvokeServerSocketReset(client);
			}

			orig(client);
		}

		static void OnProcess(object? sender, Hooks.Main.CommandProcessEventArgs e)
		{
			if (_hookService.InvokeServerCommand(e.Command))
			{
				e.Result = HookResult.Cancel;
			}
		}
	}
}
