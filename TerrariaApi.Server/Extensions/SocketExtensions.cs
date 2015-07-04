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
		public static Stopwatch sw = new Stopwatch();

		public static bool SocketConnected(this Socket s)
		{
			bool isConnected = false;
			sw.Reset();
			isConnected = !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
			sw.Stop();

			Trace.WriteLineIf(sw.ElapsedMilliseconds > 0, string.Format("IsConnected {0}ms", sw.ElapsedMilliseconds));

			return isConnected;
		}
	}
}
