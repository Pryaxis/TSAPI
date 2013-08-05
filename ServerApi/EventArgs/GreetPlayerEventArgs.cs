using System;
using System.ComponentModel;

namespace ServerApi
{
	public class GreetPlayerEventArgs : HandledEventArgs
	{
		public int Who
		{
			get; 
			internal set;
		}
	}
}
