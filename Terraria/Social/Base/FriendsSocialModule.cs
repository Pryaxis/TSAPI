using System;
using Terraria.Social;

namespace Terraria.Social.Base
{
	public abstract class FriendsSocialModule : ISocialModule
	{
		protected FriendsSocialModule()
		{
		}

		public abstract string GetUsername();

		public abstract void Initialize();

		public abstract void OpenJoinInterface();

		public abstract void Shutdown();
	}
}