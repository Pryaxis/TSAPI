using System;
using System.ComponentModel;

namespace ServerApi
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
