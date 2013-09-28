using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class ChatEventArgs : HandledEventArgs
	{
		public string Message
		{
			get; 
			set;
		}
	}
}
