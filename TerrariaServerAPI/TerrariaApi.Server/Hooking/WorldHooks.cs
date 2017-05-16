using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
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

			Hooks.Collision.PressurePlate = OnPressurePlate;
			Hooks.World.IO.PreSaveWorld = OnPreSaveWorld;
			Hooks.World.PreHardmode = OnPreHardmode;
			Hooks.World.DropMeteor = OnDropMeteor;
			Hooks.Game.Christmas = OnChristmas;
			Hooks.Game.Halloween = OnHalloween;
			Hooks.World.SpreadGrass = OnGrassSpread;
		}

		static HookResult OnPressurePlate(ref int x, ref int y, ref IEntity entity)
		{
			var npc = entity as NPC;
			if (npc != null)
			{
				if (_hookManager.InvokeNpcTriggerPressurePlate(npc, x, y))
				{
					return HookResult.Cancel;
				}
			}
			else
			{
				var player = entity as Player;
				if (player != null)
				{
					if (_hookManager.InvokePlayerTriggerPressurePlate(player, x, y))
					{
						return HookResult.Cancel;
					}
				}
				else
				{
					var projectile = entity as Projectile;
					if (projectile != null)
					{
						if (_hookManager.InvokeProjectileTriggerPressurePlate(projectile, x, y))
						{
							return HookResult.Cancel;
						}
					}
				}
			}

			return HookResult.Continue;
		}

		static HookResult OnPreSaveWorld(ref bool useCloudSaving, ref bool resetTime)
		{
			if (_hookManager.InvokeWorldSave(resetTime))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnPreHardmode()
		{
			if (_hookManager.InvokeWorldStartHardMode())
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnDropMeteor(ref int x, ref int y)
		{
			if (_hookManager.InvokeWorldMeteorDrop(x, y))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnChristmas()
		{
			if (_hookManager.InvokeWorldChristmasCheck(ref Terraria.Main.xMas))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnHalloween()
		{
			if (_hookManager.InvokeWorldHalloweenCheck(ref Main.halloween))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnGrassSpread(ref int tileX, ref int tileY, ref int dirt, ref int grass, ref bool repeat, ref byte color)
		{
			if (_hookManager.InvokeWorldGrassSpread(tileX, tileY, dirt, grass, repeat, color))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}
	}
}
