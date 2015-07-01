using Steamworks;
using System;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
	public class FriendsSocialModule : Terraria.Social.Base.FriendsSocialModule
	{
		public FriendsSocialModule()
		{
		}

		public override string GetUsername()
		{
			return SteamFriends.GetPersonaName();
		}

		public override void Initialize()
		{
		}

		public override void OpenJoinInterface()
		{
			SteamFriends.ActivateGameOverlay("Friends");
		}

		public override void Shutdown()
		{
		}
	}
}