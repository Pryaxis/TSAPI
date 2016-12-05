using System;
using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class NpcSpawnEventArgs : HandledEventArgs
	{
		public int NpcId
		{
			get; set;
		}
	}
}
