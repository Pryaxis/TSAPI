using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking;

internal static class WorldHooks
{
	private static HookManager _hookManager;

	/// <summary>
	/// Attaches any of the OTAPI World hooks to the existing <see cref="HookManager"/> implementation
	/// </summary>
	/// <param name="hookManager">HookManager instance which will receive the events</param>
	public static void AttachTo(HookManager hookManager)
	{
		_hookManager = hookManager;

		HookEvents.Terraria.IO.WorldFile.SaveWorld_Boolean_Boolean += WorldFile_SaveWorld;
		HookEvents.Terraria.WorldGen.StartHardmode += WorldGen_StartHardmode;
		HookEvents.Terraria.WorldGen.SpreadGrass += WorldGen_SpreadGrass;
		HookEvents.Terraria.Main.checkXMas += Main_checkXMas;
		HookEvents.Terraria.Main.checkHalloween += Main_checkHalloween;

		Hooks.Collision.PressurePlate += OnPressurePlate;
		Hooks.WorldGen.Meteor += OnDropMeteor;
	}

	static void OnPressurePlate(object sender, Hooks.Collision.PressurePlateEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (e.Entity is NPC npc)
		{
			if (_hookManager.InvokeNpcTriggerPressurePlate(npc, e.X, e.Y))
				e.Result = HookResult.Cancel;
		}
		else if (e.Entity is Player player)
		{
			if (_hookManager.InvokePlayerTriggerPressurePlate(player, e.X, e.Y))
				e.Result = HookResult.Cancel;
		}
		else if (e.Entity is Projectile projectile)
		{
			if (_hookManager.InvokeProjectileTriggerPressurePlate(projectile, e.X, e.Y))
				e.Result = HookResult.Cancel;
		}
	}

	static void WorldFile_SaveWorld(object? sender, HookEvents.Terraria.IO.WorldFile.SaveWorld_Boolean_BooleanEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeWorldSave(args.resetTime))
			args.ContinueExecution = false;
	}

	private static void WorldGen_StartHardmode(object? sender, HookEvents.Terraria.WorldGen.StartHardmodeEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeWorldStartHardMode())
			args.ContinueExecution = false;
	}

	static void OnDropMeteor(object sender, Hooks.WorldGen.MeteorEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (_hookManager.InvokeWorldMeteorDrop(e.X, e.Y))
		{
			e.Result = HookResult.Cancel;
		}
	}

	private static void Main_checkXMas(object? sender, HookEvents.Terraria.Main.checkXMasEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeWorldChristmasCheck(ref Terraria.Main.xMas))
			args.ContinueExecution = false;
	}

	private static void Main_checkHalloween(object? sender, HookEvents.Terraria.Main.checkHalloweenEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeWorldHalloweenCheck(ref Main.halloween))
			args.ContinueExecution = false;
	}

	private static void WorldGen_SpreadGrass(object? sender, HookEvents.Terraria.WorldGen.SpreadGrassEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeWorldGrassSpread(args.i, args.j, args.dirt, args.grass, args.repeat, args.color))
			args.ContinueExecution = false;
	}
}
