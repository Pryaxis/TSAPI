using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApi.Networking
{
	public class PacketIdAttribute : Attribute
	{
		public PacketId Id { get; set; }

		public PacketIdAttribute(PacketId id)
		{
			Id = id;
		}
	}
}
