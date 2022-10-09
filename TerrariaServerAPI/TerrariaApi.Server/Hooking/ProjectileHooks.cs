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

			On.Terraria.Projectile.SetDefaults += OnSetDefaults;
			On.Terraria.Projectile.AI += OnAI;
		}

		private static void OnSetDefaults(On.Terraria.Projectile.orig_SetDefaults orig, Projectile projectile, int type)
		{
			orig(projectile, type);
			_hookManager.InvokeProjectileSetDefaults(ref type, projectile);
		}

		private static void OnAI(On.Terraria.Projectile.orig_AI orig, Projectile projectile)
		{
			if (_hookManager.InvokeProjectileAIUpdate(projectile))
				return;

			orig(projectile);
		}
	}
}
