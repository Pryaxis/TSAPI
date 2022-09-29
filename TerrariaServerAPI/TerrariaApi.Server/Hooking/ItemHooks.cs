﻿using OTAPI;
using Terraria;
using Terraria.GameContent.Items;

namespace TerrariaApi.Server.Hooking
{
	internal static class ItemHooks
	{
		private static HookService _hookService;

		/// <summary>
		/// Attaches any of the OTAPI Item hooks to the existing <see cref="HookManager"/> implementation
		/// </summary>
		/// <param name="hookManager">HookManager instance which will receive the events</param>
		public static void AttachTo(HookService hookManager)
		{
			_hookService = hookManager;

			On.Terraria.Item.SetDefaults_int_bool_ItemVariant += OnSetDefaults;
			On.Terraria.Item.netDefaults += OnNetDefaults;

			Hooks.Chest.QuickStack += OnQuickStack;
		}

		private static void OnNetDefaults(On.Terraria.Item.orig_netDefaults orig, Item item, int type)
		{
			if (_hookService.InvokeItemNetDefaults(ref type, item))
				return;

			orig(item, type);
		}

		private static void OnSetDefaults(On.Terraria.Item.orig_SetDefaults_int_bool_ItemVariant orig, Item item, int type, bool noMatCheck, ItemVariant? variant = null)
		{
			if (_hookService.InvokeItemSetDefaultsInt(ref type, item))
				return;

			orig(item, type, noMatCheck, variant);
		}

		private static void OnQuickStack(object? sender, Hooks.Chest.QuickStackEventArgs e)
		{
			if (_hookService.InvokeItemForceIntoChest(Main.chest[e.ChestIndex], e.Item, Main.player[e.PlayerId]))
			{
				e.Result = HookResult.Cancel;
			}
		}
	}
}
