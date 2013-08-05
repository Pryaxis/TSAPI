using System;
using System.ComponentModel;

namespace ServerApi
{
	public class NameCollisionEventArgs : HandledEventArgs
	{
		public int Who
		{
			get; 
			internal set;
		}
		public string Name
		{
			get; 
			internal set;
		}
	}
}
