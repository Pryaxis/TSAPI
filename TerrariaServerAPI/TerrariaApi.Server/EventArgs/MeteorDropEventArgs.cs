using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class MeteorDropEventArgs : HandledEventArgs
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
