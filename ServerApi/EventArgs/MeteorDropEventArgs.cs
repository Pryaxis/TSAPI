using System;
using System.ComponentModel;

namespace ServerApi
{
	public class MeteorDropEventArgs : HandledEventArgs
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
