using System;

namespace Terraria
{
	public class Ref<T>
	{
		public T Value;

		public Ref()
		{
		}

		public Ref(T value)
		{
			this.Value = value;
		}
	}
}