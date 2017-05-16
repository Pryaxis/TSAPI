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

			Hooks.Game.PreUpdate = OnPreUpdate;
			Hooks.Game.PostUpdate = OnPostUpdate;
			Hooks.World.HardmodeTileUpdate = OnHardmodeTileUpdate;
			Hooks.Game.PreInitialize = OnPreInitialize;
			Hooks.Game.Started = OnStarted;
			Hooks.World.Statue = OnStatue;
		}

		static void OnPreUpdate(ref GameTime gameTime)
		{
			_hookManager.InvokeGameUpdate();
		}

		static void OnPostUpdate(ref GameTime gameTime)
		{
			_hookManager.InvokeGamePostUpdate();
		}
		static HardmodeTileUpdateResult OnHardmodeTileUpdate(int x, int y, ref ushort type)
		{
			if (_hookManager.InvokeGameHardmodeTileUpdate(x, y, type))
			{
				return HardmodeTileUpdateResult.Cancel;
			}
			return HardmodeTileUpdateResult.Continue;
		}

		static void OnPreInitialize()
		{
			HookManager.InitialiseAPI();
			_hookManager.InvokeGameInitialize();
		}

		static void OnStarted()
		{
			_hookManager.InvokeGamePostInitialize();
		}

		static HookResult OnStatue(StatueType caller, float x, float y, int type, ref int num, ref int num2, ref int num3)
		{
			if (_hookManager.InvokeGameStatueSpawn(num2, num3, num, (int)(x / 16f), (int)(y / 16f), type, caller == StatueType.Npc))
			{
				return HookResult.Continue;
			}
			return HookResult.Cancel;
		}
	}
}
