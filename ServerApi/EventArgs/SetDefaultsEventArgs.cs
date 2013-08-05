using System;
using System.ComponentModel;

namespace ServerApi
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
	}
}
