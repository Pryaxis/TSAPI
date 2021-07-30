using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class ReceiveBytesEventArgs : HandledEventArgs
	{
		public byte[] Bytes { get; set; }

		public int StreamLength { get; set; }

		public int BufferIndex { get; internal set; }
	}
}
