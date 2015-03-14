using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Streams;
using System.Linq;
using System.Text;
using ClientApi.Networking;

namespace TerrariaApi.Server.Networking.TerrariaPackets
{
	[PacketId(PacketId.Version)]
	public class VersionPacket : IPacket
	{
		public String Version { get; set; }

		public void Read(Stream s)
		{
			Version = s.ReadString();
		}

		public void Write(Stream s)
		{
			s.WriteString(Version);
		}
	}
}
