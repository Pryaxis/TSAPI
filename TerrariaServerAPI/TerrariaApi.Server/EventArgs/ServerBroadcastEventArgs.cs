using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class ServerBroadcastEventArgs : HandledEventArgs
	{
		public string Message { get; set; }
		public Color Color { get; set; }
	}
}
