using System;
using System.ComponentModel;
using Terraria.Net;

namespace TerrariaApi.Server
{
	public class SendNetDataEventArgs : HandledEventArgs
	{
		public NetManager netManager { get; set; }
		public Terraria.Net.Sockets.ISocket socket { get; set; }
		public NetPacket packet { get; set; }
	}
}
