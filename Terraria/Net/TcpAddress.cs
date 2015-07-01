using System;
using System.Net;

namespace Terraria.Net
{
	public class TcpAddress : RemoteAddress
	{
		public IPAddress Address;

		public int Port;

		public TcpAddress(IPAddress address, int port)
		{
			this.Type = AddressType.Tcp;
			this.Address = address;
			this.Port = port;
		}

		public override string GetFriendlyName()
		{
			return this.ToString();
		}

		public override string GetIdentifier()
		{
			return this.Address.ToString();
		}

		public override bool IsLocalHost()
		{
			return this.Address.Equals(IPAddress.Loopback);
		}

		public override string ToString()
		{
			return (new IPEndPoint(this.Address, this.Port)).ToString();
		}
	}
}