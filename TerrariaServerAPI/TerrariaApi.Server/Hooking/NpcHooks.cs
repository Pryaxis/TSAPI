using Microsoft.Xna.Framework;
using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking;

internal static class NpcHooks
{
	private static HookManager _hookManager;

	/// <summary>
	/// Attaches any of the OTAPI Npc hooks to the existing <see cref="HookManager"/> implementation
	/// </summary>
	/// <param name="hookManager">HookManager instance which will receive the events</param>
	public static void AttachTo(HookManager hookManager)
	{
		_hookManager = hookManager;

		HookEvents.Terraria.NPC.SetDefaults += OnSetDefaultsById;
		HookEvents.Terraria.NPC.SetDefaultsFromNetId += OnSetDefaultsFromNetId;
		HookEvents.Terraria.NPC.StrikeNPC += OnStrike;
		HookEvents.Terraria.NPC.Transform += OnTransform;
		HookEvents.Terraria.NPC.AI += OnAI;

		Hooks.NPC.Spawn += OnSpawn;
		Hooks.NPC.DropLoot += OnDropLoot;
		Hooks.NPC.BossBag += OnBossBagItem;
		Hooks.NPC.Killed += OnKilled;
	}

	static void OnKilled(object sender, Hooks.NPC.KilledEventArgs e)
	{
		_hookManager.InvokeNpcKilled(e.Npc);
	}

	static void OnSetDefaultsById(NPC npc, HookEvents.Terraria.NPC.SetDefaultsEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeNpcSetDefaultsInt(ref args.Type, npc))
			args.ContinueExecution = false;
	}

	static void OnSetDefaultsFromNetId(NPC npc, HookEvents.Terraria.NPC.SetDefaultsFromNetIdEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeNpcNetDefaults(ref args.id, npc))
			args.ContinueExecution = false;
	}

	static void OnStrike(NPC npc, HookEvents.Terraria.NPC.StrikeNPCEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (args.entity is Player player)
		{
			if (_hookManager.InvokeNpcStrike(npc, ref args.Damage, ref args.knockBack, ref args.hitDirection, ref args.crit, ref args.noEffect, ref args.fromNet, player))
			{
				args.ContinueExecution = false;
				args.HookReturnValue = 0;
			}
		}
	}

	static void OnTransform(NPC npc, HookEvents.Terraria.NPC.TransformEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeNpcTransformation(npc.whoAmI))
			args.ContinueExecution = false;
	}

	static void OnSpawn(object sender, Hooks.NPC.SpawnEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		var index = e.Index;
		if (_hookManager.InvokeNpcSpawn(ref index))
		{
			e.Result = HookResult.Cancel;
			e.Index = index;
		}
	}

	static void OnDropLoot(object sender, Hooks.NPC.DropLootEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (e.Event == HookEvent.Before)
		{
			var Width = e.Width;
			var Height = e.Height;
			var Type = e.Type;
			var Stack = e.Stack;
			var noBroadcast = e.NoBroadcast;
			var pfix = e.Pfix;
			var noGrabDelay = e.NoGrabDelay;
			var reverseLookup = e.ReverseLookup;

			var position = new Vector2(e.X, e.Y);
			if (_hookManager.InvokeNpcLootDrop
			(
				ref position,
				ref Width,
				ref Height,
				ref Type,
				ref Stack,
				ref noBroadcast,
				ref pfix,
				e.Npc.type,
				e.Npc.whoAmI,
				ref noGrabDelay,
				ref reverseLookup
			))
			{
				e.X = (int)position.X;
				e.Y = (int)position.Y;
				e.Result = HookResult.Cancel;
			}
			e.X = (int)position.X;
			e.Y = (int)position.Y;

			e.Width = Width;
			e.Height = Height;
			e.Type = Type;
			e.Stack = Stack;
			e.NoBroadcast = noBroadcast;
			e.Pfix = pfix;
			e.NoGrabDelay = noGrabDelay;
			e.ReverseLookup = reverseLookup;
		}
	}

	static void OnBossBagItem(object sender, Hooks.NPC.BossBagEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		var Width = e.Width;
		var Height = e.Height;
		var Type = e.Type;
		var Stack = e.Stack;
		var noBroadcast = e.NoBroadcast;
		var pfix = e.Pfix;
		var noGrabDelay = e.NoGrabDelay;
		var reverseLookup = e.ReverseLookup;

		var positon = new Vector2(e.X, e.Y);
		if (_hookManager.InvokeDropBossBag
		(
			ref positon,
			ref Width,
			ref Height,
			ref Type,
			ref Stack,
			ref noBroadcast,
			ref pfix,
			e.Npc.type,
			e.Npc.whoAmI,
			ref noGrabDelay,
			ref reverseLookup
		))
		{
			e.Result = HookResult.Cancel;
		}

		e.Width = Width;
		e.Height = Height;
		e.Type = Type;
		e.Stack = Stack;
		e.NoBroadcast = noBroadcast;
		e.Pfix = pfix;
		e.NoGrabDelay = noGrabDelay;
		e.ReverseLookup = reverseLookup;
	}

	static void OnAI(NPC npc, HookEvents.Terraria.NPC.AIEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeNpcAIUpdate(npc))
			args.ContinueExecution = false;
	}
}
