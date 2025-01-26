using OTAPI;
using System;
using System.Linq;
using Terraria;

namespace TerrariaApi.Server.Hooking;

internal static class ServerHooks
{
	private static HookManager _hookManager;

	/// <summary>
	/// Attaches any of the OTAPI Server hooks to the existing <see cref="HookManager"/> implementation
	/// </summary>
	/// <param name="hookManager">HookManager instance which will receive the events</param>
	public static void AttachTo(HookManager hookManager)
	{
		_hookManager = hookManager;

		HookEvents.Terraria.Main.startDedInput += Main_startDedInput;
		HookEvents.Terraria.RemoteClient.Reset += RemoteClient_Reset;
		Hooks.Main.CommandProcess += OnProcess;
	}

	static void Main_startDedInput(object? sender, HookEvents.Terraria.Main.startDedInputEventArgs args)
	{
		if (!args.ContinueExecution) return;
		args.ContinueExecution = false;

		if (Environment.GetCommandLineArgs().Any(x => x.Equals("-disable-commands")))
		{
			Console.WriteLine("Command thread has been disabled.");
			return;
		}

		args.OriginalMethod();
	}

	static void OnProcess(object sender, Hooks.Main.CommandProcessEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (_hookManager.InvokeServerCommand(e.Command))
		{
			e.Result = HookResult.Cancel;
		}
	}

	static void RemoteClient_Reset(RemoteClient client, HookEvents.Terraria.RemoteClient.ResetEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (!Netplay.Disconnect)
		{
			if (client.IsActive)
			{
				_hookManager.InvokeServerLeave(client.Id);
			}
			_hookManager.InvokeServerSocketReset(client);
		}
	}
}
