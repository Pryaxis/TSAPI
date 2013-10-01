using System;
using Terraria;

namespace TerrariaApi.Server
{
	public class SocketResetEventArgs : EventArgs
	{
		public ServerSock Socket
		{
			get; 
			internal set;
		}
	}
}
