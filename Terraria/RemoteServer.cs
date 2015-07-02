using System;
using Terraria.Net.Sockets;

namespace Terraria
{
	public class RemoteServer
	{
		public ISocket Socket = new TcpSocket();

		public bool IsActive;

		public int State;

		public int TimeOutTimer;

		public bool IsReading;

		public byte[] ReadBuffer;

		public string StatusText;

		public int StatusCount;

		public int StatusMax;

		public RemoteServer()
		{
		}

		public void ClientReadCallBack(object state, int length)
		{
			if (!Netplay.disconnect)
			{
				int num = length;
				if (num == 0)
				{
					Netplay.disconnect = true;
					Main.statusText = "Lost connection";
				}
				else if (!Main.ignoreErrors)
				{
					NetMessage.RecieveBytes(this.ReadBuffer, num, 256);
				}
				else
				{
					try
					{
						NetMessage.RecieveBytes(this.ReadBuffer, num, 256);
					}
					catch (Exception ex)
					{
#if DEBUG
						Console.WriteLine(ex);
						System.Diagnostics.Debugger.Break();

#endif
					}
				}
			}
			this.IsReading = false;
		}

		public void ClientWriteCallBack(object state)
		{
			MessageBuffer messageBuffer = NetMessage.buffer[256];
			messageBuffer.spamCount = messageBuffer.spamCount - 1;
		}
	}
}