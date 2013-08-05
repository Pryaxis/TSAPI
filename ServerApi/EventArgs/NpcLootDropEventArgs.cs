using System;
using System.ComponentModel;

namespace ServerApi
{
	public class NpcLootDropEventArgs : HandledEventArgs
	{
		public int X
		{
			get; 
			set;
		}
		public int Y
		{
			get; 
			set;
		}
		public int Width
		{
			get; 
			set;
		}
		public int Height
		{
			get; 
			set;
		}
		public int Stack
		{
			get; 
			set;
		}
		public int ItemId
		{
			get; 
			set;
		}
		public bool Broadcast
		{
			get; 
			set;
		}
		public int Prefix
		{
			get; 
			set;
		}
		public int NpcId
		{
			get; 
			internal set;
		}
		public int NpcArrayIndex
		{
			get; 
			internal set;
		}
	}
}
