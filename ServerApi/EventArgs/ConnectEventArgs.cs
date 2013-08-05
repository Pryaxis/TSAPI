using System;
using System.ComponentModel;

namespace ServerApi
{
	public class ConnectEventArgs : HandledEventArgs
	{
		public int Who
		{
			get; 
			internal set;
		}
	}
}
