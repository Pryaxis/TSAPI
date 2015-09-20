using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
	public class SteamP2PWriter
	{
		private const int BUFFER_SIZE = 1024;

		private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendData = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();

		private Queue<byte[]> _bufferPool = new Queue<byte[]>();

		private object _lock = new object();

		private int _channel;

		public SteamP2PWriter(int channel)
		{
			this._channel = channel;
		}

		public void ClearUser(CSteamID user)
		{
			lock (this._lock)
			{
				if (this._pendingSendData.ContainsKey(user))
				{
					Queue<SteamP2PWriter.WriteInformation> item = this._pendingSendData[user];
					while (item.Count > 0)
					{
						this._bufferPool.Enqueue(item.Dequeue().Data);
					}
				}
			}
		}

		public void QueueSend(CSteamID user, byte[] data, int length)
		{
			Queue<SteamP2PWriter.WriteInformation> item;
			SteamP2PWriter.WriteInformation writeInformation;
			lock (this._lock)
			{
				if (!this._pendingSendData.ContainsKey(user))
				{
					Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> cSteamIDs = this._pendingSendData;
					Queue<SteamP2PWriter.WriteInformation> writeInformations = new Queue<SteamP2PWriter.WriteInformation>();
					item = writeInformations;
					cSteamIDs[user] = writeInformations;
				}
				else
				{
					item = this._pendingSendData[user];
				}
				int num = length;
				int num1 = 0;
				while (num > 0)
				{
					if (item.Count == 0 || 1024 - item.Peek().Size == 0)
					{
						writeInformation = (this._bufferPool.Count <= 0 ? new SteamP2PWriter.WriteInformation() : new SteamP2PWriter.WriteInformation(this._bufferPool.Dequeue()));
						item.Enqueue(writeInformation);
					}
					else
					{
						writeInformation = item.Peek();
					}
					int num2 = Math.Min(num, 1024 - writeInformation.Size);
					Array.Copy(data, num1, writeInformation.Data, writeInformation.Size, num2);
					SteamP2PWriter.WriteInformation size = writeInformation;
					size.Size = size.Size + num2;
					num = num - num2;
					num1 = num1 + num2;
				}
			}
		}

		public void SendAll()
		{
			lock (this._lock)
			{
				foreach (KeyValuePair<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendDatum in this._pendingSendData)
				{
					Queue<SteamP2PWriter.WriteInformation> value = _pendingSendDatum.Value;
					while (value.Count > 0)
					{
						SteamP2PWriter.WriteInformation writeInformation = value.Dequeue();
						bool flag = SteamNetworking.SendP2PPacket(_pendingSendDatum.Key, writeInformation.Data, (uint)writeInformation.Size, EP2PSend.k_EP2PSendReliable, this._channel);
						this._bufferPool.Enqueue(writeInformation.Data);
					}
				}
			}
		}

		private class WriteInformation
		{
			public byte[] Data;

			public int Size;

			public WriteInformation()
			{
				this.Data = new byte[1024];
				this.Size = 0;
			}

			public WriteInformation(byte[] data)
			{
				this.Data = data;
				this.Size = 0;
			}
		}
	}
}