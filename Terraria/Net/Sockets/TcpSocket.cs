using System;
using System.Collections.Generic;
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
		public int MessagesInQueue
		{
			get
			{
				return this._messagesInQueue;
			}
		}

		private List<object> _callbackBuffer = new List<object>();

		internal TcpClient _connection;

		private TcpListener _listener;

		private SocketConnectionAccepted _listenerCallback;

		private int _messagesInQueue;

		private byte[] _packetBuffer = new byte[1024];

		private int _packetBufferLength;

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
							try
							{
								Tuple<SocketReceiveCallback, object> asyncState = (Tuple<SocketReceiveCallback, object>)result.AsyncState;
								asyncState.Item1(asyncState.Item2, this._connection.GetStream().EndRead(result));
							}
							catch (Exception ex)
							{

							}
						}
					}
				}
			}
		}

		private void SendCallback(IAsyncResult result)
		{
			//Tuple<SocketSendCallback, object> asyncState = (Tuple<SocketSendCallback, object>)result.AsyncState;
			List<object> list = (List<object>)result.AsyncState;

			//if (((ISocket)this).IsConnected() == true)
			//{
			try
			{
				this._connection.GetStream().EndWrite(result);
			}
			catch (Exception ex)
			{
				//write failed
			}
			finally
			{
				//asyncState.Item1(asyncState.Item2);
				foreach (object current in list)
				{
					Tuple<SocketSendCallback, object> tuple = (Tuple<SocketSendCallback, object>)current;
					tuple.Item1(tuple.Item2);
				}
			}

			//}
			//else
			//{
			//	lock (_connection)
			//	{
			//		this._connectionDisposed = true;
			//		((ISocket)this).Close();
			//	}
			//}
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

			try
			{
				object item = new Tuple<SocketSendCallback, object>(callback, state);
				if (size + this._packetBufferLength > 1024)
				{
					((ISocket)this).SendQueuedPackets();
				}
				if (size > this._packetBuffer.Length)
				{
					byte[] array = new byte[size];
					Buffer.BlockCopy(this._packetBuffer, 0, array, 0, this._packetBufferLength);
					this._packetBuffer = array;
				}
				Buffer.BlockCopy(data, offset, this._packetBuffer, this._packetBufferLength, size);
				this._packetBufferLength += size;
				this._messagesInQueue++;
				this._callbackBuffer.Add(item);

				//this._connection.GetStream().Write(data, offset, size);
			}
			catch (Exception ex)
			{
				//Write failed
			}
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

			TcpAddress tcpAddress = (TcpAddress)address;
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
			if (this._connection == null || this._connection.Client == null)
			{
				return false;
			}

			/*
 			 * Note:  Double comparison here is intentional,
 			 * please do not remove.  -TW
 			 */
			if (this._connectionDisposed == false)
			{
				if (this._connectionDisposed == false)
				{


					return this._connection.Client.SocketConnected();
				}

				return false;
			}


			return false;
		}

		bool Terraria.Net.Sockets.ISocket.IsDataAvailable()
		{
			return this._connection.GetStream().DataAvailable;
		}

		void ISocket.SendQueuedPackets()
		{
			if (this._packetBufferLength == 0 || !((ISocket)this).IsConnected())
			{
				return;
			}
			try
			{
				this._connection.GetStream().BeginWrite(this._packetBuffer, 0, this._packetBufferLength, new AsyncCallback(this.SendCallback), this._callbackBuffer);
			}
			catch (Exception)
			{
				((ISocket)this).Close();
			}
			this._packetBufferLength = 0;
			this._messagesInQueue = 0;
			this._callbackBuffer = new List<object>();
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
				Thread t = new Thread(ListenLoop);
				t.IsBackground = true;
				t.Name = "Listen Loop";
				t.Start();
				//ThreadPool.QueueUserWorkItem(new WaitCallback(this.ListenLoop));
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
