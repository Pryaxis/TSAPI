using System;
using Terraria;

namespace ServerApi
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
