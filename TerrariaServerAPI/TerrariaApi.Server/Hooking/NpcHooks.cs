using System;
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

			Hooks.Npc.PreSetDefaultsById = OnPreSetDefaultsById;
			Hooks.Npc.PreNetDefaults = OnPreNetDefaults;
			Hooks.Npc.Strike = OnStrike;
			Hooks.Npc.PreTransform = OnPreTransform;
			Hooks.Npc.Spawn = OnSpawn;
			Hooks.Npc.PreDropLoot = OnPreDropLoot;
			Hooks.Npc.BossBagItem = OnBossBagItem;
			Hooks.Npc.PreAI = OnPreAI;
			Hooks.Npc.Killed = OnKilled;
		}

		private static void OnKilled(NPC npc)
		{
			_hookManager.InvokeNpcKilled(npc);
		}

		static HookResult OnPreSetDefaultsById(NPC npc, ref int type, ref float scaleOverride)
		{
			if (_hookManager.InvokeNpcSetDefaultsInt(ref type, npc))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnPreNetDefaults(NPC npc, ref int type)
		{
			if (_hookManager.InvokeNpcNetDefaults(ref type, npc))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnStrike(
				NPC npc,
				ref double cancelResult,
				ref int damage,
				ref float knockBack,
				ref int hitDirection,
				ref bool critical,
				ref bool noEffect,
				ref bool fromNet,
				Entity entity
			)
		{
			var player = entity as Player;
			if (player != null)
			{
				if (_hookManager.InvokeNpcStrike(npc, ref damage, ref knockBack, ref hitDirection,
					ref critical, ref noEffect, ref fromNet, player))
				{
					return HookResult.Cancel;
				}
			}
			return HookResult.Continue;
		}

		static HookResult OnPreTransform(NPC npc, ref int newType)
		{
			if (_hookManager.InvokeNpcTransformation(npc.whoAmI))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnSpawn(ref int index)
		{
			if (_hookManager.InvokeNpcSpawn(ref index))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnPreDropLoot(
				 NPC npc,
				 ref int itemId,
				 ref int x,
				 ref int y,
				 ref int width,
				 ref int height,
				 ref int type,
				 ref int stack,
				 ref bool noBroadcast,
				 ref int prefix,
				 ref bool noGrabDelay,
				 ref bool reverseLookup)
		{
			var position = new Vector2(x, y);
			if (_hookManager.InvokeNpcLootDrop
			(
				ref position,
				ref width,
				ref height,
				ref type,
				ref stack,
				ref noBroadcast,
				ref prefix,
				npc.type,
				npc.whoAmI,
				ref noGrabDelay,
				ref reverseLookup
			))
			{
				x = (int)position.X;
				y = (int)position.Y;
				return HookResult.Cancel;
			}
			x = (int)position.X;
			y = (int)position.Y;
			return HookResult.Continue;
		}

		static HookResult OnBossBagItem(
				NPC npc,
				ref int X,
				ref int Y,
				ref int Width,
				ref int Height,
				ref int Type,
				ref int Stack,
				ref bool noBroadcast,
				ref int pfix,
				ref bool noGrabDelay,
				ref bool reverseLookup
			)
		{
			var positon = new Vector2(X, Y);
			if (_hookManager.InvokeDropBossBag
			(
				ref positon,
				ref Width,
				ref Height,
				ref Type,
				ref Stack,
				ref noBroadcast,
				ref pfix,
				npc.type,
				npc.whoAmI,
				ref noGrabDelay,
				ref reverseLookup
			))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnPreAI(NPC npc)
		{
			if (_hookManager.InvokeNpcAIUpdate(npc))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}
	}
}
