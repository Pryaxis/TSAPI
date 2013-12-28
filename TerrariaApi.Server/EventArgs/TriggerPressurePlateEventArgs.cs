using System;
using System.ComponentModel;

namespace TerrariaApi.Server
{
	public class TriggerPressurePlateEventArgs<T> : HandledEventArgs
	{
		public T Object
		{
			get; 
			set;
		}

		public int TileX
		{
			get; 
			set;
		}

		public int TileY
		{
			get; 
			set;
		}
	}
}
