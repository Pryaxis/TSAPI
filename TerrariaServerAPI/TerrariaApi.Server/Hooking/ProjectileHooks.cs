using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
	internal static class ProjectileHooks
	{
		private static HookService _hookService;

		/// <summary>
		/// Attaches any of the OTAPI Projectile hooks to the existing <see cref="HookService"/> implementation
		/// </summary>
		/// <param name="hookService">HookService instance which will receive the events</param>
		public static void AttachTo(HookService hookService)
		{
			_hookService = hookService;

			On.Terraria.Projectile.SetDefaults += OnSetDefaults;
			On.Terraria.Projectile.AI += OnAI;
		}

		private static void OnSetDefaults(On.Terraria.Projectile.orig_SetDefaults orig, Projectile projectile, int type)
		{
			orig(projectile, type);
			_hookService.InvokeProjectileSetDefaults(ref type, projectile);
		}

		private static void OnAI(On.Terraria.Projectile.orig_AI orig, Projectile projectile)
		{
			if (_hookService.InvokeProjectileAIUpdate(projectile))
				return;

			orig(projectile);
		}
	}
}
