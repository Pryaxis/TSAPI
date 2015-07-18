using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Terraria.Net.Sockets.EventArgs;

namespace Terraria.Net.Sockets
{
	public static class QueueDispatcher
	{
		private static readonly int kQueueDispatcherThreadCount = Environment.ProcessorCount / 2;
		private static readonly BlockingCollection<HeapItem> packetQueue = new BlockingCollection<HeapItem>();
		private static readonly object[] writeSyncRoots = new object[256];

		private static long packetCounter = 0L;

		static QueueDispatcher()
		{
			for (int i = 0; i < 256; i++)
			{
				writeSyncRoots[i] = new object();
			}

			for (int i = 0; i < kQueueDispatcherThreadCount; i++)
			{
				Thread writeThread = new Thread(DispatchThread);
				writeThread.IsBackground = true;
				writeThread.Start();
			}
		}

		public static void Dispatch(HeapItem item, params int[] ply)
		{
			item.SetRecipients(ply);
			packetQueue.Add(item);
		}

		private static void DispatchThread()
		{
			HeapItem item;
			while (true)
			{
				if (packetQueue.TryTake(out item, 100) == false)
				{
					continue;
				}

				for (int i = 0; i < 256; i++)
				{
					int length;

					if (item.recipients[i] == false)
					{
						continue;
					}

					if (Netplay.Clients[i].Socket.IsConnected() == false)
					{
						continue;
					}

					length = BitConverter.ToInt16(item.Array, item.Offset);

					try
					{
						lock (writeSyncRoots[i])
						{
							(Netplay.Clients[i].Socket as TcpSocket)._connection.GetStream().Write(item.Array, item.Offset, length);
							//Netplay.Clients[i].Socket.AsyncSend(item.Array, item.Offset, length, Netplay.Clients[i].ServerWriteCallBack);
						}
					}
					catch
					{
						Netplay.Clients[i].PendingTermination = true;
					}
				}
			}
		}


	}

	public class SendQueue : IDisposable
	{
		protected volatile bool threadCancelled;
		protected Thread sendThread;
		protected RemoteClient client;
		protected BlockingCollection<HeapItem> queue;
 
		public event EventHandler<WriteFailedEventArgs> WriteFailed;

		public SendQueue(RemoteClient client)
		{
			this.client = client;
		}

		public void StartThread()
		{
			threadCancelled = false;
			queue = new BlockingCollection<HeapItem>(new ConcurrentQueue<HeapItem>());

			sendThread = new Thread(WriteThread);
			sendThread.Name = "Network I/O Thread - " + client.Id;
			sendThread.Start();
		}

		protected void WriteThread()
		{
			HeapItem item;
			int offset;
			int length;

			while (true)
			{
				if (threadCancelled == true)
				{
					break;
				}

				try
				{
					if (queue.TryTake(out item, 100) == false)
					{
						continue;
					}
				}
				catch (ObjectDisposedException)
				{
					break;
				}
				catch (ArgumentNullException)
				{
					break;
				}

				offset = item.Offset;
				length = BitConverter.ToInt16(item.Array, offset);

				try
				{
					(client.Socket as TcpSocket)._connection.GetStream().Write(item.Array, offset, length);
				}
				catch 
				{
					Netplay.Clients[client.Id].PendingTermination = true;
				}
				finally
				{
				}
			}
		}

		public void Enqueue(HeapItem item)
		{
			int offset = item.Offset;
			int type = item.Array[item.Offset + 2];
			int length = BitConverter.ToInt16(item.Array, offset);

			if (length < 0 || length > PacketHeap.kPacketHeapLargeBlockSize || Enum.IsDefined(typeof(PacketTypes), type) == false)
			{
				//System.Diagnostics.Debugger.Break();
			}
			//try
			//{
			//	(client.Socket as TcpSocket)._connection.GetStream().Write(item.Array, offset, length);
			//}
			//catch
			//{

			//}
			//finally
			//{
			//}
			if (queue != null)
			{
				queue.Add(item);
			}
		}

		public static void Broadcast(HeapItem item, Func<int, bool> selector = null)
		{
			for (int i = 0; i < 256; i++)
			{
				if (selector == null || selector(i))
				{
					item.SetRecipient(i);
				}
			}

			QueueDispatcher.Dispatch(item);
		}

		~SendQueue()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Reset()
		{
			threadCancelled = true;

			if (queue != null)
			{
				queue.Dispose();
				queue = null;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (sendThread != null)
			{
				threadCancelled = true;
				sendThread.Join();
			}

			if (disposing)
			{
				queue.Dispose();
			}
		}
	}
}
