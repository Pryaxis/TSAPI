using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaApi.Server
{
	public sealed class NpcKilledEventArgs : EventArgs
	{
		public Terraria.NPC npc { get; internal set; }
	}
}
