using System;
using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class ServerChatEventArgs : HandledEventArgs
	{
		public MessageBuffer Buffer
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
		public Terraria.Chat.ChatCommandId CommandId
		{
			get;
			internal set;
		}
	}
}
