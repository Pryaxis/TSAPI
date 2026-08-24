using System;
using System.ComponentModel;
using Terraria;

namespace TerrariaApi.Server
{
	public class NpcStrikeEventArgs : HandledEventArgs
	{
		public Player Player
		{
			get;
			internal set;
		}
		public NPC Npc
		{
			get;
			internal set;
		}
		public int Damage
		{
			get;
			set;
		}
		public float KnockBack
		{
			get;
			set;
		}
		public int HitDirection
		{
			get;
			set;
		}
		public bool Critical
		{
			get;
			set;
		}
		[Obsolete("NPC.StrikeNPC does not supply this value; it is always false and is ignored.")]
		public bool NoEffect 
		{ 
			get; 
			set; 
		}
		public bool FromNet
		{
			get; 
			set; 
		}
	}
}
