using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking
{
	internal static class WiringHooks
	{
		private static HookService _hookService;

		/// <summary>
		/// Attaches any of the OTAPI Wiring hooks to the existing <see cref="HookService"/> implementation
		/// </summary>
		/// <param name="hookService">HookService instance which will receive the events</param>
		public static void AttachTo(HookService hookService)
		{
			_hookService = hookService;

			Hooks.Wiring.AnnouncementBox += OnAnnouncementBox;
		}

		static void OnAnnouncementBox(object? sender, Hooks.Wiring.AnnouncementBoxEventArgs e)
		{
			if (_hookService.InvokeWireTriggerAnnouncementBox(Wiring.CurrentUser, e.X, e.Y, e.SignId, Main.sign[e.SignId].text))
			{
				e.Result = HookResult.Cancel;
			}
		}
	}
}
