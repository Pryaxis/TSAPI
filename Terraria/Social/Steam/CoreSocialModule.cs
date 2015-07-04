using Steamworks;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Terraria.Social;

namespace Terraria.Social.Steam
{
	public class CoreSocialModule : ISocialModule
	{
		public const int SteamAppId = 105600;

		private bool IsSteamValid;

		public CoreSocialModule()
		{
		}

		public void Initialize()
		{
		}

		public void Shutdown()
		{
		}

		private void SteamLoop(object context)
		{
			while (this.IsSteamValid)
			{
				Thread.Sleep(5);
				SteamAPI.RunCallbacks();
				if (CoreSocialModule.OnTick == null)
				{
					continue;
				}
				CoreSocialModule.OnTick();
			}
			SteamAPI.Shutdown();
		}

		public static event Action OnTick;
	}
}