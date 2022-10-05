using System;
using System.ComponentModel;
using Terraria.GameContent.Items;

namespace TerrariaApi.Server
{
	public class SetDefaultsEventArgs<T, F> : HandledEventArgs
	{
		public T Object
		{
			get;
			internal set;
		}
		public F Info
		{
			get;
			set;
		}

		public ItemVariant ItemVariant { get; set; }
	}
}
