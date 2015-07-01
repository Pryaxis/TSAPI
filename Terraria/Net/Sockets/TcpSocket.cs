using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria;
using Terraria.Net;

namespace Terraria.Net.Sockets
{
	public class TcpSocket : ISocket
	{
		private TcpClient _connection;

		private TcpListener _listener;

		private SocketConnectionAccepted _listenerCallback;

		private RemoteAddress _remoteAddress;

		private bool _isListening;

		public TcpSocket()
		{
			this._connection = new TcpClient()
			{
				NoDelay = true
			};
		}

		public TcpSocket(TcpClient tcpClient)
		{
			this._connection = tcpClient;
			this._connection.NoDelay = true;
			IPEndPoint remoteEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
			this._remoteAddress = new TcpAddress(remoteEndPoint.Address, remoteEndPoint.Port);
		}

		private void ListenLoop(object unused)
		{
			while (this._isListening && !Netplay.disconnect)
			{
				try
				{
					ISocket tcpSocket = new TcpSocket(this._listener.AcceptTcpClient());
					//Console.WriteLine(string.Concat(tcpSocket.GetRemoteAddress(), " is connecting..."));
					this._listenerCallback(tcpSocket);
				}
				catch (Exception)
				{
				}
			}
			this._listener.Stop();
		}

		private void ReadCallback(IAsyncResult result)
		{
			Tuple<SocketReceiveCallback, object> asyncState = (Tuple<SocketReceiveCallback, object>)result.AsyncState;
			asyncState.Item1(asyncState.Item2, this._connection.GetStream().EndRead(result));
		}

		private void SendCallback(IAsyncResult result)
		{
			Tuple<SocketSendCallback, object> asyncState = (Tuple<SocketSendCallback, object>)result.AsyncState;
			try
			{
				this._connection.GetStream().EndWrite(result);
				asyncState.Item1(asyncState.Item2);
			}
			catch (Exception)
			{
				((ISocket)this).Close();
			}
		}

		void Terraria.Net.Sockets.ISocket.AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			this._connection.GetStream().BeginRead(data, offset, size, new AsyncCallback(this.ReadCallback), new Tuple<SocketReceiveCallback, object>(callback, state));
		}

		void Terraria.Net.Sockets.ISocket.AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state)
		{
			this._connection.GetStream().BeginWrite(data, 0, size, new AsyncCallback(this.SendCallback), new Tuple<SocketSendCallback, object>(callback, state));
		}

		void Terraria.Net.Sockets.ISocket.Close()
		{
			this._remoteAddress = null;
			this._connection.Close();
		}

		void Terraria.Net.Sockets.ISocket.Connect(RemoteAddress address)
		{
			TcpAddress tcpAddress = (TcpAddress)address;
			this._connection.Connect(tcpAddress.Address, tcpAddress.Port);
			this._remoteAddress = address;
		}

		RemoteAddress Terraria.Net.Sockets.ISocket.GetRemoteAddress()
		{
			return this._remoteAddress;
		}

		bool Terraria.Net.Sockets.ISocket.IsConnected()
		{
			if (this._connection == null || this._connection.Client == null)
			{
				return false;
			}
			return this._connection.Connected;
		}

		bool Terraria.Net.Sockets.ISocket.IsDataAvailable()
		{
			return this._connection.GetStream().DataAvailable;
		}

		bool Terraria.Net.Sockets.ISocket.StartListening(SocketConnectionAccepted callback)
		{
			bool flag;
			this._isListening = true;
			this._listenerCallback = callback;
			if (this._listener == null)
			{
				this._listener = new TcpListener(IPAddress.Any, Netplay.ListenPort);
			}
			try
			{
				this._listener.Start();
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.ListenLoop));
				return true;
			}
			catch (Exception)
			{
				flag = false;
			}
			return flag;
		}

		void Terraria.Net.Sockets.ISocket.StopListening()
		{
			this._isListening = false;
		}
	}
}