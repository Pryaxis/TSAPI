using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class NpcAiUpdateEventArgs : HandledEventArgs
	{
		public NPC Npc { get; internal set; }
	}
}
