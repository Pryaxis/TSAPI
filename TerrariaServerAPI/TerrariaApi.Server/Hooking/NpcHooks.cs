using Microsoft.Xna.Framework;
using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
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

			On.Terraria.NPC.SetDefaults += OnSetDefaultsById;
			On.Terraria.NPC.SetDefaultsFromNetId += OnSetDefaultsFromNetId;
			On.Terraria.NPC.StrikeNPC += OnStrike;
			On.Terraria.NPC.Transform += OnTransform;
			On.Terraria.NPC.AI += OnAI;

			Hooks.NPC.Spawn += OnSpawn;
			Hooks.NPC.DropLoot += OnDropLoot;
			Hooks.NPC.BossBag += OnBossBagItem;
			Hooks.NPC.Killed += OnKilled;
		}

		static void OnKilled(object sender, Hooks.NPC.KilledEventArgs e)
		{
			_hookManager.InvokeNpcKilled(e.Npc);
		}

		static void OnSetDefaultsById(On.Terraria.NPC.orig_SetDefaults orig, NPC npc, int type, NPCSpawnParams spawnparams)
		{
			if (_hookManager.InvokeNpcSetDefaultsInt(ref type, npc))
				return;

			orig(npc, type, spawnparams);
		}

		static void OnSetDefaultsFromNetId(On.Terraria.NPC.orig_SetDefaultsFromNetId orig, NPC npc, int id, NPCSpawnParams spawnparams)
		{
			if (_hookManager.InvokeNpcNetDefaults(ref id, npc))
				return;

			orig(npc, id, spawnparams);
		}

		static double OnStrike(On.Terraria.NPC.orig_StrikeNPC orig, NPC npc, int Damage, float knockBack, int hitDirection, bool crit, bool noEffect, bool fromNet, Entity entity)
		{
			if (entity is Player player)
			{
				if (_hookManager.InvokeNpcStrike(npc, ref Damage, ref knockBack, ref hitDirection, ref crit, ref noEffect, ref fromNet, player))
				{
					return 0;
				}
			}

			return orig(npc, Damage, knockBack, hitDirection, crit, noEffect, fromNet, entity);
		}

		static void OnTransform(On.Terraria.NPC.orig_Transform orig, NPC npc, int newType)
		{
			if (_hookManager.InvokeNpcTransformation(npc.whoAmI))
				return;

			orig(npc, newType);
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

		static void OnAI(On.Terraria.NPC.orig_AI orig, NPC npc)
		{
			if (_hookManager.InvokeNpcAIUpdate(npc))
				return;

			orig(npc);
		}
	}
}
