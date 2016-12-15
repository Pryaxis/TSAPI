using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
	internal static class WiringHooks
	{
		private static HookManager _hookManager;

		/// <summary>
		/// Attaches any of the OTAPI Wiring hooks to the existing <see cref="HookManager"/> implementation
		/// </summary>
		/// <param name="hookManager">HookManager instance which will receive the events</param>
		public static void AttachTo(HookManager hookManager)
		{
			_hookManager = hookManager;

			Hooks.Wiring.AnnouncementBox = OnAnnouncementBox;
		}

		static HookResult OnAnnouncementBox(int x, int y, int signId)
		{
			if (_hookManager.InvokeWireTriggerAnnouncementBox(Wiring.CurrentUser, x, y, signId, Main.sign[signId].text))
			{
				return HookResult.Cancel;
			}
			return HookResult.Continue;
		}
	}
}
