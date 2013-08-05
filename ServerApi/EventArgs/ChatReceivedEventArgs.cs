using System;

namespace ServerApi
{
	public class ChatReceivedEventArgs : EventArgs
	{
		public byte PlayerID
		{
			get; 
			internal set;
		}
		public Color Color
		{
			get; 
			internal set;
		}
		public string Message
		{
			get; 
			internal set;
		}
	}
}
