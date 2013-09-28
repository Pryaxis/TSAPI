using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class ChristmasCheckEventArgs : HandledEventArgs
	{
		public bool Xmas
		{
			get; 
			set;
		}
	}
}
