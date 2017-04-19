using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
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

			Hooks.Item.PreSetDefaultsById = OnPreSetDefaultsById;
			Hooks.Item.PreNetDefaults = OnPreNetDefaults;
			Hooks.Chest.QuickStack = OnQuickStack;
		}

		static HookResult OnPreSetDefaultsById(Item item, ref int type, ref bool noMatCheck)
		{
			if (_hookManager.InvokeItemSetDefaultsInt(ref type, item))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnPreNetDefaults(Item item, ref int type)
		{
			if (_hookManager.InvokeItemNetDefaults(ref type, item))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}

		static HookResult OnQuickStack(int playerId, Item item, int chestIndex)
		{
			if (_hookManager.InvokeItemForceIntoChest(Main.chest[chestIndex], item, Main.player[playerId]))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}
	}
}
