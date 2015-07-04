using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.Net.Sockets;

namespace Terraria.Net
{
	internal class NetManager
	{
		public static NetManager Instance;

		private Dictionary<ushort, NetModule> _modules = new Dictionary<ushort, NetModule>();

		private ushort ModuleCount;

		private static long _trafficTotal;

		private static Stopwatch _trafficTimer;

		static NetManager()
		{
			NetManager.Instance = new NetManager();
			NetManager._trafficTotal = (long)0;
			NetManager._trafficTimer = NetManager.CreateStopwatch();
		}

		public NetManager()
		{
		}

		public void Broadcast(NetPacket packet, int ignoreClient = -1)
		{
			for (int i = 0; i < 256; i++)
			{
				if (i != ignoreClient && Netplay.Clients[i].Socket.IsConnected())
				{
					NetManager.SendData(Netplay.Clients[i].Socket, packet);
				}
			}
		}

		private static Stopwatch CreateStopwatch()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			return stopwatch;
		}

		public ushort GetId<T>()
		where T : NetModule
		{
			return NetManager.PacketTypeStorage<T>.Module.Id;
		}

		public NetModule GetModule<T>()
		where T : NetModule
		{
			return NetManager.PacketTypeStorage<T>.Module;
		}

		public void Read(BinaryReader reader, int userId)
		{
			ushort num = reader.ReadUInt16();
			if (this._modules.ContainsKey(num))
			{
				this._modules[num].Deserialize(reader, userId);
			}
		}

		public void Register<T>()
		where T : NetModule, new()
		{
			T moduleCount = Activator.CreateInstance<T>();
			moduleCount.Id = this.ModuleCount;
			NetManager.PacketTypeStorage<T>.Module = moduleCount;
			this._modules[this.ModuleCount] = moduleCount;
			NetManager netManager = this;
			netManager.ModuleCount = (ushort)(netManager.ModuleCount + 1);
		}

		public static void SendCallback(object state)
		{
			if (state == null)
			{
				return;
			}
			((NetPacket)state).Recycle();
		}

		public static void SendData(ISocket socket, NetPacket packet)
		{
			try
			{
				socket.AsyncSend(packet.Buffer.Data, 0, packet.Length, new SocketSendCallback(NetManager.SendCallback), packet);
			}
			catch
			{
				Console.WriteLine("    Exception normal: Tried to send data to a client after losing connection");
			}
		}

		public void SendToServer(NetPacket packet)
		{
			NetManager.SendData(Netplay.Connection.Socket, packet);
		}

		private static void UpdateStats(int length)
		{
			NetManager._trafficTotal = NetManager._trafficTotal + (long)length;
			double totalSeconds = NetManager._trafficTimer.Elapsed.TotalSeconds;
			if (totalSeconds > 5)
			{
				double num = (double)NetManager._trafficTotal;
				double num1 = Math.Floor(num / totalSeconds) / 1000;
				Console.WriteLine(string.Concat("NetManager :: Sending at ", num1, " kbps."));
				NetManager._trafficTimer.Restart();
				NetManager._trafficTotal = (long)0;
			}
		}

		private class PacketTypeStorage<T>
		where T : NetModule
		{
			public static T Module;

			public PacketTypeStorage()
			{
			}
		}
	}
}