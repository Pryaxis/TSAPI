using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class CommandEventArgs : HandledEventArgs
	{
		public string Command
		{
			get; 
			internal set;
		}
	}
}
