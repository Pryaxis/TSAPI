using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TerrariaApi.Server.Extensions
{
	public static class SocketExtensions
	{
		public static bool SocketConnected(this Socket s)
		{
			//bool isConnected = !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
			//sw.Stop();


			//return isConnected;
			return s.Connected == true;
		}
	}
}
