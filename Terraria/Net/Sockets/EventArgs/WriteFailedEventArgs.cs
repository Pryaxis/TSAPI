using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Terraria.Net.Sockets.EventArgs
{
	public class WriteFailedEventArgs : System.EventArgs
	{
		public SocketError ErrorCode { get; set; }
	}
}
