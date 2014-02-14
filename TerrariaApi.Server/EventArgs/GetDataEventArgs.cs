using System;
using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class GetDataEventArgs : HandledEventArgs
	{
		public PacketTypes MsgID
		{
			get;
			set;
		}
		public MessageBuffer Msg
		{
			get;
			internal set;
		}
		public int Index
		{
			get;
			set;
		}
		public int Length
		{
			get;
			set;
		}
	}
}
