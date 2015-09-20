using System;
using System.Diagnostics;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;

namespace Terraria.Social.Base
{
	public abstract class NetSocialModule : ISocialModule
	{
		protected NetSocialModule()
		{
		}

		public abstract void CancelJoin();

		public abstract bool CanInvite();

		public abstract void Close(RemoteAddress address);

		public abstract void Connect(RemoteAddress address);

		public abstract void Initialize();

		public abstract bool IsConnected(RemoteAddress address);

		public abstract bool IsDataAvailable(RemoteAddress address);

		public abstract void LaunchLocalServer(Process process, ServerSocialMode mode);

		public abstract void OpenInviteInterface();

		public abstract int Receive(RemoteAddress address, byte[] data, int offset, int length);

		public abstract bool Send(RemoteAddress address, byte[] data, int length);

		public abstract void Shutdown();

		public abstract bool StartListening(SocketConnectionAccepted callback);

		public abstract void StopListening();
	}
}