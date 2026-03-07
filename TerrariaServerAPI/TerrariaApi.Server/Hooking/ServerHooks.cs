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
		HookEvents.Terraria.Main.ReadLineInput += Main_ReadLineInput;
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

#nullable enable
	/// <summary>
	/// Hooks the default ReadLineInput method to add a small delay when Console.ReadLine() returns null.
	/// For example, some docker instances may experience a 100% CPU usage due to this vanilla thread implementation.
	/// </summary>
	static void Main_ReadLineInput(object? sender, HookEvents.Terraria.Main.ReadLineInputEventArgs args)
	{
		args.ContinueExecution = false;

		string? text;
		while ((text = Console.ReadLine()) is null)
			System.Threading.Thread.Sleep(100);

		args.HookReturnValue = text;
	}
#nullable disable

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
