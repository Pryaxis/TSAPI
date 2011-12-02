using System;
using System.ComponentModel;
namespace Hooks
{
	public static class WorldHooks
	{
		public delegate void SaveWorldD(bool resettime, HandledEventArgs e);
		public static event WorldHooks.SaveWorldD SaveWorld;
		public static bool OnSaveWorld(bool resettime)
		{
			if (WorldHooks.SaveWorld == null)
			{
				return false;
			}
			HandledEventArgs handledEventArgs = new HandledEventArgs();
			WorldHooks.SaveWorld(resettime, handledEventArgs);
			return handledEventArgs.Handled;
		}
	}
}
