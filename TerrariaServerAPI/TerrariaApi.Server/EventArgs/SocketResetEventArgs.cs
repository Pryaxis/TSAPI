using System;
using Terraria;

namespace TerrariaApi.Server
{
	public class SocketResetEventArgs : EventArgs
	{
		public RemoteClient Socket
		{
			get; 
			internal set;
		}
	}
}
