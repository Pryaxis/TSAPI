using System;
using System.ComponentModel;

namespace ServerApi
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
