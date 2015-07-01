using Steamworks;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
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
			if (!SteamAPI.Init())
			{
				MessageBox.Show("Please launch the game from your Steam client.", "Error");
				Environment.Exit(1);
			}
			this.IsSteamValid = true;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.SteamLoop), null);
		}

		public void Shutdown()
		{
			Application.ApplicationExit += new EventHandler((object obj, EventArgs evt) => this.IsSteamValid = false);
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