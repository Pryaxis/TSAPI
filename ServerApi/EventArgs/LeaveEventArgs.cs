using System;

namespace ServerApi
{
	public class LeaveEventArgs : EventArgs
	{
		public int Who
		{
			get; 
			internal set;
		}
	}
}
