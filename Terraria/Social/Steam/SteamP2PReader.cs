using Steamworks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.Social.Steam
{
	public class SteamP2PReader
	{
		private const int BUFFER_SIZE = 4096;

		public object SteamLock = new object();

		private bool _isReading;

		private Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> _pendingReadBuffers = new Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>>();

		private Queue<CSteamID> _deletionQueue = new Queue<CSteamID>();

		private Queue<byte[]> _bufferPool = new Queue<byte[]>();

		private int _channel;

		private SteamP2PReader.OnReadEvent _readEvent;

		public SteamP2PReader(int channel)
		{
			this._channel = channel;
		}

		public void ClearUser(CSteamID id)
		{
			lock (this._pendingReadBuffers)
			{
				this._deletionQueue.Enqueue(id);
			}
		}

		public bool IsDataAvailable(CSteamID id)
		{
			bool flag;
			lock (this._pendingReadBuffers)
			{
				if (this._pendingReadBuffers.ContainsKey(id))
				{
					Queue<SteamP2PReader.ReadResult> item = this._pendingReadBuffers[id];
					flag = (item.Count == 0 || item.Peek().Size == 0 ? false : true);
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private bool IsPacketAvailable(out uint size)
		{
			bool flag;
			lock (this.SteamLock)
			{
				flag = SteamNetworking.IsP2PPacketAvailable(out size, this._channel);
			}
			return flag;
		}

		public int Receive(CSteamID user, byte[] buffer, int bufferOffset, int bufferSize)
		{
			int num;
			uint num1 = 0;
			lock (this._pendingReadBuffers)
			{
				if (this._pendingReadBuffers.ContainsKey(user))
				{
					Queue<SteamP2PReader.ReadResult> item = this._pendingReadBuffers[user];
					while (item.Count > 0)
					{
						SteamP2PReader.ReadResult readResult = item.Peek();
						uint num2 = (uint)Math.Min(bufferSize - num1, readResult.Size - readResult.Offset);
						if (num2 != 0)
						{
							Array.Copy(readResult.Data, (long)readResult.Offset, buffer, (long)((long)bufferOffset + (long)num1), (long)num2);
							if (num2 != readResult.Size - readResult.Offset)
							{
								SteamP2PReader.ReadResult offset = readResult;
								offset.Offset = offset.Offset + num2;
							}
							else
							{
								this._bufferPool.Enqueue(item.Dequeue().Data);
							}
							num1 = num1 + num2;
						}
						else
						{
							num = (int)num1;
							return num;
						}
					}
					return (int)num1;
				}
				else
				{
					num = 0;
				}
			}
			return num;
		}

		private void ReceiverLoop(object state)
		{
			uint num;
			byte[] numArray;
			CSteamID readResults;
			uint num1;
			bool flag;
			while (this._isReading)
			{
				lock (this._pendingReadBuffers)
				{
					while (this._deletionQueue.Count > 0)
					{
						this._pendingReadBuffers.Remove(this._deletionQueue.Dequeue());
					}
					while (this.IsPacketAvailable(out num))
					{
						numArray = (this._bufferPool.Count != 0 ? this._bufferPool.Dequeue() : new byte[Math.Max(num, 4096)]);
						lock (this.SteamLock)
						{
							flag = SteamNetworking.ReadP2PPacket(numArray, (uint)numArray.Length, out num1, out readResults, this._channel);
						}
						if (!flag)
						{
							continue;
						}
						if (this._readEvent == null || this._readEvent(numArray, (int)num1, readResults))
						{
							if (!this._pendingReadBuffers.ContainsKey(readResults))
							{
								this._pendingReadBuffers[readResults] = new Queue<SteamP2PReader.ReadResult>();
							}
							this._pendingReadBuffers[readResults].Enqueue(new SteamP2PReader.ReadResult(numArray, num1));
						}
						else
						{
							this._bufferPool.Enqueue(numArray);
						}
					}
				}
				Thread.Sleep(1);
			}
		}

		public void SetReadEvent(SteamP2PReader.OnReadEvent method)
		{
			this._readEvent = method;
		}

		public void Start()
		{
			this._isReading = true;
			ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReceiverLoop));
		}

		public void Stop()
		{
			this._isReading = false;
		}

		public delegate bool OnReadEvent(byte[] data, int size, CSteamID user);

		private class ReadResult
		{
			public byte[] Data;

			public uint Size;

			public uint Offset;

			public ReadResult(byte[] data, uint size)
			{
				this.Data = data;
				this.Size = size;
				this.Offset = 0;
			}
		}
	}
}