using System;
using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class NpcSpawnEventArgs : HandledEventArgs
	{
		public NPC Npc
		{
			get;
			internal set;
		}
	}
}
