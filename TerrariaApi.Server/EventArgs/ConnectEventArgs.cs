using System;
using System.ComponentModel;

namespace TerrariaApi.Server
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
