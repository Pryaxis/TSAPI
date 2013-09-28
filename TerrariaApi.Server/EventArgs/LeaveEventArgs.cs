using System;

namespace TerrariaApi.Server
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
