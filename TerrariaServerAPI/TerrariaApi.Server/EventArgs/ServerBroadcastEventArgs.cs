using Microsoft.Xna.Framework;
using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class ServerBroadcastEventArgs : HandledEventArgs
	{
		public Terraria.Localization.NetworkText Message { get; set; }
		public Color Color { get; set; }
	}
}
