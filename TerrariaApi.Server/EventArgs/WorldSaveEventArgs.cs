using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class WorldSaveEventArgs : HandledEventArgs
	{
		public bool ResetTime
		{
			get; 
			internal set;
		}
	}
}
