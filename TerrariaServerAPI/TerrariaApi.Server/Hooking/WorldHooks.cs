using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
	internal static class WorldHooks
	{
		private static HookService _hookService;

		/// <summary>
		/// Attaches any of the OTAPI World hooks to the existing <see cref="HookService"/> implementation
		/// </summary>
		/// <param name="hookService">HookService instance which will receive the events</param>
		public static void AttachTo(HookService hookService)
		{
			_hookService = hookService;

			On.Terraria.IO.WorldFile.SaveWorld_bool_bool += WorldFile_SaveWorld;
			On.Terraria.WorldGen.StartHardmode += WorldGen_StartHardmode;
			On.Terraria.WorldGen.SpreadGrass += WorldGen_SpreadGrass;
			On.Terraria.Main.checkXMas += Main_checkXMas;
			On.Terraria.Main.checkHalloween += Main_checkHalloween;

			Hooks.Collision.PressurePlate += OnPressurePlate;
			Hooks.WorldGen.Meteor += OnDropMeteor;
		}

		static void WorldFile_SaveWorld(On.Terraria.IO.WorldFile.orig_SaveWorld_bool_bool orig, bool useCloudSaving, bool resetTime)
		{
			if (_hookService.InvokeWorldSave(resetTime))
				return;

			orig(useCloudSaving, resetTime);
		}

		private static void WorldGen_StartHardmode(On.Terraria.WorldGen.orig_StartHardmode orig)
		{
			if (_hookService.InvokeWorldStartHardMode())
				return;

			orig();
		}

		private static void Main_checkXMas(On.Terraria.Main.orig_checkXMas orig)
		{
			if (_hookService.InvokeWorldChristmasCheck(ref Terraria.Main.xMas))
				return;

			orig();
		}

		private static void Main_checkHalloween(On.Terraria.Main.orig_checkHalloween orig)
		{
			if (_hookService.InvokeWorldHalloweenCheck(ref Main.halloween))
				return;

			orig();
		}

		private static void WorldGen_SpreadGrass(On.Terraria.WorldGen.orig_SpreadGrass orig, int i, int j, int dirt, int grass, bool repeat, byte color)
		{
			if (_hookService.InvokeWorldGrassSpread(i, j, dirt, grass, repeat, color))
				return;

			orig(i, j, dirt, grass, repeat, color);
		}

		static void OnPressurePlate(object? sender, Hooks.Collision.PressurePlateEventArgs e)
		{
			if (e.Entity is NPC npc)
			{
				if (_hookService.InvokeNpcTriggerPressurePlate(npc, e.X, e.Y))
					e.Result = HookResult.Cancel;
			}
			else if (e.Entity is Player player)
			{
				if (_hookService.InvokePlayerTriggerPressurePlate(player, e.X, e.Y))
					e.Result = HookResult.Cancel;
			}
			else if (e.Entity is Projectile projectile)
			{
				if (_hookService.InvokeProjectileTriggerPressurePlate(projectile, e.X, e.Y))
					e.Result = HookResult.Cancel;
			}
		}

		static void OnDropMeteor(object? sender, Hooks.WorldGen.MeteorEventArgs e)
		{
			if (_hookService.InvokeWorldMeteorDrop(e.X, e.Y))
			{
				e.Result = HookResult.Cancel;
			}
		}
	}
}
