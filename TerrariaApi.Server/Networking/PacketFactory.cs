using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ClientApi.Networking
{
	public sealed class PacketFactory
	{
		public static readonly PacketFactory Instance = new PacketFactory();
		private Dictionary<PacketId, Type> IdToType;
		private Dictionary<Type, PacketId> TypeToId;

		private PacketFactory()
		{
			var types = (from type in Assembly.GetExecutingAssembly().GetTypes()
						 let attr = type.GetCustomAttributes(typeof(PacketIdAttribute), false).OfType<PacketIdAttribute>().FirstOrDefault()
						 where attr != null
						 select new { type = type, id = attr.Id }).ToList();

			IdToType = types.ToDictionary(kv => kv.id, kv => kv.type);
			TypeToId = types.ToDictionary(kv => kv.type, kv => kv.id);
		}


		public PacketId GetPacketId(IPacket pck)
		{
			PacketId id;
			if (!TypeToId.TryGetValue(pck.GetType(), out id))
				throw new InvalidOperationException("Packet type is missing packet id: " + pck.GetType().FullName);
			return id;
		}

		public Type GetPacketType(PacketId id)
		{
			Type type = GetPacketTypeOrNull(id);
			if (type == null)
				throw new InvalidOperationException("Packet id is missing: " + id);
			return type;
		}
		public Type GetPacketTypeOrNull(PacketId id)
		{
			Type type;
			return IdToType.TryGetValue(id, out type) ? type : null;
		}


		public IPacket CreatePacket(PacketId id)
		{
			return (IPacket)Activator.CreateInstance(GetPacketType(id));
		}
		public IPacket CreatePacket(PacketId id, byte[] body)
		{
			var pck = CreatePacket(id);
			using (var ms = new MemoryStream(body))
				pck.Read(ms);
			return pck;
		}
	}
}
