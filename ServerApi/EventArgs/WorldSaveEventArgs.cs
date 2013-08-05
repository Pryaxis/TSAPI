using System;
using System.ComponentModel;

namespace ServerApi
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
