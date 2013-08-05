using System;
using System.ComponentModel;
using Terraria;

namespace ServerApi
{
	public class SendBytesEventArgs: HandledEventArgs
	{
		public ServerSock Socket
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
