using Microsoft.Xna.Framework;
using OTAPI;

namespace TerrariaApi.Server.Hooking
{
	internal static class GameHooks
	{
		private static HookService _hookService;

		/// <summary>
		/// Attaches any of the OTAPI Game hooks to the existing <see cref="HookService"/> implementation
		/// </summary>
		/// <param name="hookService">HookService instance which will receive the events</param>
		public static void AttachTo(HookService hookService)
		{
			_hookService = hookService;

			On.Terraria.Main.Update += OnUpdate;
			On.Terraria.Main.Initialize += OnInitialize;
			On.Terraria.Netplay.StartServer += OnStartServer;

			Hooks.WorldGen.HardmodeTilePlace += OnHardmodeTilePlace;
			Hooks.WorldGen.HardmodeTileUpdate += OnHardmodeTileUpdate;
			Hooks.Item.MechSpawn += OnItemMechSpawn;
			Hooks.NPC.MechSpawn += OnNpcMechSpawn;
		}

		private static void OnUpdate(On.Terraria.Main.orig_Update orig, Terraria.Main instance, GameTime gameTime)
		{
			_hookService.InvokeGameUpdate();
			orig(instance, gameTime);
			_hookService.InvokeGamePostUpdate();
		}

		private static void OnHardmodeTileUpdate(object? sender, Hooks.WorldGen.HardmodeTileUpdateEventArgs e)
		{
			if (_hookService.InvokeGameHardmodeTileUpdate(e.X, e.Y, e.Type))
			{
				e.Result = HookResult.Cancel;
			}
		}

		private static void OnHardmodeTilePlace(object? sender, Hooks.WorldGen.HardmodeTilePlaceEventArgs e)
		{
			if (_hookService.InvokeGameHardmodeTileUpdate(e.X, e.Y, e.Type))
			{
				e.Result = HardmodeTileUpdateResult.Cancel;
			}
		}

		private static void OnInitialize(On.Terraria.Main.orig_Initialize orig, Terraria.Main instance)
		{
			_hookService.InitialiseAPI();
			_hookService.InvokeGameInitialize();
			orig(instance);
		}

		private static void OnStartServer(On.Terraria.Netplay.orig_StartServer orig)
		{
			_hookService.InvokeGamePostInitialize();
			orig();
		}

		private static void OnItemMechSpawn(object? sender, Hooks.Item.MechSpawnEventArgs e)
		{
			if (!_hookService.InvokeGameStatueSpawn(e.Num2, e.Num3, e.Num, (int)(e.X / 16f), (int)(e.Y / 16f), e.Type, false))
			{
				e.Result = HookResult.Cancel;
			}
		}

		private static void OnNpcMechSpawn(object? sender, Hooks.NPC.MechSpawnEventArgs e)
		{
			if (!_hookService.InvokeGameStatueSpawn(e.Num2, e.Num3, e.Num, (int)(e.X / 16f), (int)(e.Y / 16f), e.Type, true))
			{
				e.Result = HookResult.Cancel;
			}
		}
	}
}
