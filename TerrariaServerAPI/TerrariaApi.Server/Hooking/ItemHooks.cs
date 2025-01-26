using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking;

internal static class ItemHooks
{
	private static HookManager _hookManager;

	/// <summary>
	/// Attaches any of the OTAPI Item hooks to the existing <see cref="HookManager"/> implementation
	/// </summary>
	/// <param name="hookManager">HookManager instance which will receive the events</param>
	public static void AttachTo(HookManager hookManager)
	{
		_hookManager = hookManager;

		HookEvents.Terraria.Item.SetDefaults_Int32_Boolean_ItemVariant += OnSetDefaults;
		HookEvents.Terraria.Item.netDefaults += OnNetDefaults;

		Hooks.Chest.QuickStack += OnQuickStack;
	}

	private static void OnNetDefaults(Item item, HookEvents.Terraria.Item.netDefaultsEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeItemNetDefaults(ref args.type, item))
			args.ContinueExecution = false;
	}

	private static void OnSetDefaults(Item item, HookEvents.Terraria.Item.SetDefaults_Int32_Boolean_ItemVariantEventArgs args)
	{
		if (!args.ContinueExecution) return;
		if (_hookManager.InvokeItemSetDefaultsInt(ref args.Type, item, args.variant))
			args.ContinueExecution = false;
	}

	private static void OnQuickStack(object sender, Hooks.Chest.QuickStackEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (_hookManager.InvokeItemForceIntoChest(Main.chest[e.ChestIndex], e.Item, Main.player[e.PlayerId]))
		{
			e.Result = HookResult.Cancel;
		}
	}
}
