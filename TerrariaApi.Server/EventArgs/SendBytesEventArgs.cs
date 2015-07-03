using System;
using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class SendBytesEventArgs: HandledEventArgs
	{
		public RemoteClient Socket
		{
			get; 
			internal set;
		}
		public byte[] Buffer
		{
			get; 
			internal set;
		}
		public int Offset
		{
			get; 
			internal set;
		}
		public int Count
		{
			get; 
			internal set;
		}
	}
}
