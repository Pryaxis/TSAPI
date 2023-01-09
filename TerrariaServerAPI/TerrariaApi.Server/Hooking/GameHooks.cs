using Microsoft.Xna.Framework;
using OTAPI;

namespace TerrariaApi.Server.Hooking
{
	internal static class GameHooks
	{
		private static HookManager _hookManager;

		/// <summary>
		/// Attaches any of the OTAPI Game hooks to the existing <see cref="HookManager"/> implementation
		/// </summary>
		/// <param name="hookManager">HookManager instance which will receive the events</param>
		public static void AttachTo(HookManager hookManager)
		{
			_hookManager = hookManager;

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
			_hookManager.InvokeGameUpdate();
			orig(instance, gameTime);
			_hookManager.InvokeGamePostUpdate();
		}

		private static void OnHardmodeTileUpdate(object sender, Hooks.WorldGen.HardmodeTileUpdateEventArgs e)
		{
			if (e.Result == HookResult.Cancel)
			{
				return;
			}
			if (_hookManager.InvokeGameHardmodeTileUpdate(e.X, e.Y, e.Type))
			{
				e.Result = HookResult.Cancel;
			}
		}

		private static void OnHardmodeTilePlace(object sender, Hooks.WorldGen.HardmodeTilePlaceEventArgs e)
		{
			if (e.Result == HardmodeTileUpdateResult.Cancel)
			{
				return;
			}
			if (_hookManager.InvokeGameHardmodeTileUpdate(e.X, e.Y, e.Type))
			{
				e.Result = HardmodeTileUpdateResult.Cancel;
			}
		}

		private static void OnInitialize(On.Terraria.Main.orig_Initialize orig, Terraria.Main instance)
		{
			HookManager.InitialiseAPI();
			_hookManager.InvokeGameInitialize();
			orig(instance);
		}

		private static void OnStartServer(On.Terraria.Netplay.orig_StartServer orig)
		{
			_hookManager.InvokeGamePostInitialize();
			orig();
		}

		private static void OnItemMechSpawn(object sender, Hooks.Item.MechSpawnEventArgs e)
		{
			if (e.Result == HookResult.Cancel)
			{
				return;
			}
			if (!_hookManager.InvokeGameStatueSpawn(e.Num2, e.Num3, e.Num, (int)(e.X / 16f), (int)(e.Y / 16f), e.Type, false))
			{
				e.Result = HookResult.Cancel;
			}
		}

		private static void OnNpcMechSpawn(object sender, Hooks.NPC.MechSpawnEventArgs e)
		{
			if (e.Result == HookResult.Cancel)
			{
				return;
			}
			if (!_hookManager.InvokeGameStatueSpawn(e.Num2, e.Num3, e.Num, (int)(e.X / 16f), (int)(e.Y / 16f), e.Type, true))
			{
				e.Result = HookResult.Cancel;
			}
		}
	}
}
