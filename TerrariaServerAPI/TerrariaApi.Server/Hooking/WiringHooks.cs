using OTAPI;
using Terraria;

namespace TerrariaApi.Server.Hooking;

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

		Hooks.Wiring.AnnouncementBox += OnAnnouncementBox;
	}

	static void OnAnnouncementBox(object sender, Hooks.Wiring.AnnouncementBoxEventArgs e)
	{
		if (e.Result == HookResult.Cancel)
		{
			return;
		}
		if (_hookManager.InvokeWireTriggerAnnouncementBox(Wiring.CurrentUser, e.X, e.Y, e.SignId, Main.sign[e.SignId].text))
		{
			e.Result = HookResult.Cancel;
		}
	}
}
