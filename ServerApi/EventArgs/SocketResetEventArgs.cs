using System;
using Terraria;

namespace ServerApi
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
