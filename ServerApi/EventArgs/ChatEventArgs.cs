using System;
using System.ComponentModel;

namespace ServerApi
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
