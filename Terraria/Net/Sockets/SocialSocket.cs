using System;
using System.Threading;
using Terraria.Net;
using Terraria.Social;
using Terraria.Social.Base;

namespace Terraria.Net.Sockets
{
	public class SocialSocket : ISocket
	{
		private RemoteAddress _remoteAddress;


		public int ClientID()
		{
			return 0;
		}

		public SocialSocket()
		{
		}

		public SocialSocket(RemoteAddress remoteAddress)
		{
			this._remoteAddress = remoteAddress;
		}

		private void ReadCallback(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			int num;
			while (true)
			{
				int num1 = SocialAPI.Network.Receive(this._remoteAddress, data, offset, size);
				num = num1;
				if (num1 != 0)
				{
					break;
				}
				Thread.Sleep(1);
			}
			callback(state, num);
		}

		void Terraria.Net.Sockets.ISocket.AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			SocialSocket.InternalReadCallback internalReadCallback = new SocialSocket.InternalReadCallback(this.ReadCallback);
			internalReadCallback.BeginInvoke(data, offset, size, callback, state, null, null);
		}

		void Terraria.Net.Sockets.ISocket.AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state)
		{
			SocialAPI.Network.Send(this._remoteAddress, data, size);
			callback.BeginInvoke(state, null, null);
		}

		void Terraria.Net.Sockets.ISocket.Close()
		{
			if (this._remoteAddress == null)
			{
				return;
			}
			SocialAPI.Network.Close(this._remoteAddress);
			this._remoteAddress = null;
		}

		void Terraria.Net.Sockets.ISocket.Connect(RemoteAddress address)
		{
			this._remoteAddress = address;
			SocialAPI.Network.Connect(address);
		}

		RemoteAddress Terraria.Net.Sockets.ISocket.GetRemoteAddress()
		{
			return this._remoteAddress;
		}

		bool Terraria.Net.Sockets.ISocket.IsConnected()
		{
			return SocialAPI.Network.IsConnected(this._remoteAddress);
		}

		bool Terraria.Net.Sockets.ISocket.IsDataAvailable()
		{
			return SocialAPI.Network.IsDataAvailable(this._remoteAddress);
		}

		bool Terraria.Net.Sockets.ISocket.StartListening(SocketConnectionAccepted callback)
		{
			return SocialAPI.Network.StartListening(callback);
		}

		void Terraria.Net.Sockets.ISocket.StopListening()
		{
			SocialAPI.Network.StopListening();
		}

		private delegate void InternalReadCallback(byte[] data, int offset, int size, SocketReceiveCallback callback, object state);
	}
}