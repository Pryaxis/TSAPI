using System;

namespace TerrariaApi.Server
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
