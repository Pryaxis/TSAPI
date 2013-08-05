using System;

namespace ServerApi
{
	public class ChristmasCheckEventArgs : EventArgs
	{
		public bool Xmas
		{
			get; 
			internal set;
		}
	}
}
