using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
	internal static class ProjectileHooks
	{
		private static HookManager _hookManager;

		/// <summary>
		/// Attaches any of the OTAPI Projectile hooks to the existing <see cref="HookManager"/> implementation
		/// </summary>
		/// <param name="hookManager">HookManager instance which will receive the events</param>
		public static void AttachTo(HookManager hookManager)
		{
			_hookManager = hookManager;

			Hooks.Projectile.PostSetDefaultsById = OnPostSetDefaultsById;
			Hooks.Projectile.PreAI = OnPreAI;
		}

		static void OnPostSetDefaultsById(Projectile projectile, int type)
		{
			_hookManager.InvokeProjectileSetDefaults(ref type, projectile);
		}

		static HookResult OnPreAI(Projectile projectile)
		{
			if (_hookManager.InvokeProjectileAIUpdate(projectile))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}
	}
}
