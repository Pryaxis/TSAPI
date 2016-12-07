using Microsoft.Xna.Framework;
using System;


namespace TerrariaApi.Server
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
