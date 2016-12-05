using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class HalloweenCheckEventArgs : HandledEventArgs
	{
		public bool Halloween
		{
			get; 
			set;
		}
	}
}
