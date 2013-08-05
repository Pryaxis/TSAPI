using System;
using System.ComponentModel;
using Terraria;

namespace ServerApi
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
