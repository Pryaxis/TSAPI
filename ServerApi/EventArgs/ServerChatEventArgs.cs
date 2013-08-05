using System;
using System.ComponentModel;
using Terraria;

namespace ServerApi
{
	public class ServerChatEventArgs : HandledEventArgs
	{
		public messageBuffer Buffer
		{
			get; 
			internal set;
		}
		public int Who
		{
			get; 
			internal set;
		}
		public string Text
		{
			get; 
			internal set;
		}
	}
}
