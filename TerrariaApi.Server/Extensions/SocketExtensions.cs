using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TerrariaApi.Server.Extensions
{
	public static class SocketExtensions
	{
		public static bool SocketConnected(this Socket s)
		{
			bool part1 = s.Poll(1000, SelectMode.SelectRead);
			bool part2 = (s.Connected == false && s.Available == 0);
			if (part1 && part2)
				return false;
			else
				return true;
		}
	}
}
