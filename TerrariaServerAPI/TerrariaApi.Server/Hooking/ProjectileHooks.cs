using Terraria;

namespace TerrariaApi.Server.Hooking;

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

		HookEvents.Terraria.Projectile.SetDefaults += OnSetDefaults;
		HookEvents.Terraria.Projectile.AI += OnAI;
	}

	private static void OnSetDefaults(Projectile projectile, HookEvents.Terraria.Projectile.SetDefaultsEventArgs args)
	{
		if (!args.ContinueExecution) return;
		args.ContinueExecution = false;
		args.OriginalMethod(args.Type);
		_hookManager.InvokeProjectileSetDefaults(ref args.Type, projectile);
	}

	private static void OnAI(Projectile projectile, HookEvents.Terraria.Projectile.AIEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeProjectileAIUpdate(projectile))
			args.ContinueExecution = false;
	}
}
