using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClientApi.Networking
{
	public interface IPacket
	{
		void Read(Stream s);
		void Write(Stream s);
	}
}
