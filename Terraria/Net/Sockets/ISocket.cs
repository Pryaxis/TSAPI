using System;
using Terraria.Net;

namespace Terraria.Net.Sockets
{
	public interface ISocket
	{

		void AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state = null);

		void AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state = null);

		void Close();

		void Connect(RemoteAddress address);

		RemoteAddress GetRemoteAddress();

		bool IsConnected();

		bool IsDataAvailable();

		void SendQueuedPackets();

		bool StartListening(SocketConnectionAccepted callback);

		void StopListening();
	}
}
