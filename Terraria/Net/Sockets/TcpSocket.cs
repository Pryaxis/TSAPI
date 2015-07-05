using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Terraria;
using Terraria.Net;
using TerrariaApi.Server.Extensions;

namespace Terraria.Net.Sockets
{
	public class TcpSocket : ISocket
	{
		private TcpClient _connection;

		private TcpListener _listener;

		private SocketConnectionAccepted _listenerCallback;

		private RemoteAddress _remoteAddress;

		private bool _isListening;

		private volatile bool _connectionDisposed;

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
					this._listenerCallback(tcpSocket);
				}
				catch (Exception ex)
				{
#if DEBUG
					Console.WriteLine(ex);
					System.Diagnostics.Debugger.Break();

#endif
				}
			}
			this._listener.Stop();
		}

		private void ReadCallback(IAsyncResult result)
		{

			if (this._connectionDisposed == false)
			{
				lock (_connection)
				{
					if (this._connectionDisposed == false)
					{
						if (this._connection.Client.SocketConnected())
						{
							Tuple<SocketReceiveCallback, object> asyncState = (Tuple<SocketReceiveCallback, object>)result.AsyncState;
							asyncState.Item1(asyncState.Item2, this._connection.GetStream().EndRead(result));
						}
					}
				}
			}
		}

		private void SendCallback(IAsyncResult result)
		{
			Tuple<SocketSendCallback, object> asyncState = (Tuple<SocketSendCallback, object>)result.AsyncState;

			if (((ISocket)this).IsConnected() == true)
			{
				try
				{
					this._connection.GetStream().EndWrite(result);
				}
				catch (SocketException ex)
				{
					//Write failed
				}
				asyncState.Item1(asyncState.Item2);
			}
			else
			{
				lock (_connection)
				{
					this._connectionDisposed = true;
					((ISocket)this).Close();
				}
			}
		}

		void Terraria.Net.Sockets.ISocket.AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state)
		{
			this._connection.GetStream().BeginRead(data, offset, size, new AsyncCallback(this.ReadCallback), new Tuple<SocketReceiveCallback, object>(callback, state));
		}

		void Terraria.Net.Sockets.ISocket.AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state)
		{
			if (((ISocket)this).IsConnected() == false)
			{
				return;
			}

			//this._connection.GetStream().Write(data, 0, size);
			//callback(null);
			this._connection.GetStream().BeginWrite(data, 0, size, new AsyncCallback(this.SendCallback), new Tuple<SocketSendCallback, object>(callback, state));
		}

		void Terraria.Net.Sockets.ISocket.Close()
		{
			lock (_connection)
			{
				this._connectionDisposed = true;
				this._remoteAddress = null;
				this._connection.Close();
			}
		}

		void Terraria.Net.Sockets.ISocket.Connect(RemoteAddress address)
		{
			
				TcpAddress tcpAddress = (TcpAddress) address;
				this._connection.Connect(tcpAddress.Address, tcpAddress.Port);
				this._remoteAddress = address;

				lock (_connection)
				{
					this._connectionDisposed = false;
				}
		}

		RemoteAddress Terraria.Net.Sockets.ISocket.GetRemoteAddress()
		{
			return this._remoteAddress;
		}

		bool Terraria.Net.Sockets.ISocket.IsConnected()
		{
			if (this._connectionDisposed == false)
			{
				lock (_connection)
				{
					if (this._connectionDisposed == false)
					{
						return !(this._connection == null || this._connection.Client == null ||
						         _connection.Client.SocketConnected() == false);
					}

					return false;
				}
			}


			return false;
			//if (this._connectionDisposed == true || this._connection == null || this._connection.Client == null || _connection.Client.SocketConnected() == false)
			//{
			//	return false;
			//}
			//return this._connection.Connected;
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
			catch
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
