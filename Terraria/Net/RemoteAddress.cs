using System;

namespace Terraria.Net
{
	public abstract class RemoteAddress
	{
		public AddressType Type;

		protected RemoteAddress()
		{
		}

		public abstract string GetFriendlyName();

		public abstract string GetIdentifier();

		public abstract bool IsLocalHost();
	}
}