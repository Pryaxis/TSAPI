using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class JoinEventArgs : HandledEventArgs
	{
		public int Who
		{
			get; 
			internal set;
		}
	}
}
