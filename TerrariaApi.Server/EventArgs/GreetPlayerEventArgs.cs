using System;
using System.ComponentModel;

namespace TerrariaApi.Server
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
