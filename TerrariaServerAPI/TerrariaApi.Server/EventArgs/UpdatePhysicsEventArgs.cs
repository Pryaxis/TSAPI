using System;
using Terraria;

namespace TerrariaApi.Server
{
	public class UpdatePhysicsEventArgs : EventArgs
	{
		public Player Player
		{
			get; 
			internal set;
		}
	}
}
