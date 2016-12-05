using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class StatueSpawnEventArgs : HandledEventArgs
	{
		public int Within200
		{
			get; 
			internal set;
		}
		public int Within600
		{
			get;
			internal set;
		}
		public int WorldWide
		{
			get; 
			internal set;
		}
		public int X
		{
			get; 
			internal set;
		}
		public int Y
		{
			get;
			internal set;
		}
		public int Type
		{
			get;
			internal set;
		}
		public bool Npc
		{
			get;
			internal set;
		}
	}
}
