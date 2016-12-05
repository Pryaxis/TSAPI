using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class SendDataEventArgs : HandledEventArgs
	{
		public PacketTypes MsgId { get; set; }

		public int remoteClient { get; set; }

		public int ignoreClient { get; set; }

		public string text { get; set; }

		public int number { get; set; }

		public float number2 { get; set; }

		public float number3 { get; set; }

		public float number4 { get; set; }

		public int number5 { get; set; }

		public int number6 { get; set; }

		public int number7 { get; set; }
	}
}
