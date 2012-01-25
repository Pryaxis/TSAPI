using System;
using System.ComponentModel;
using Terraria;
namespace Hooks
{
    public class NpcSpawnEventArgs : HandledEventArgs
	{
		public NPC Npc
		{
			get;
			set;
		}
	}
}
