using System;
using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.Initializers
{
	public static class NetworkInitializer
	{
		public static void Load()
		{
			NetManager.Instance.Register<NetLiquidModule>();
		}
	}
}