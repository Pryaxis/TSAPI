using System;
using System.Linq;

namespace TerrariaApi.Server
{
	internal struct HandlerRegistration<ArgsType> where ArgsType: EventArgs
	{
		public TerrariaPlugin Registrator { get; set; }
		public HookHandler<ArgsType> Handler { get; set; }
		public int Priority { get; set; }
		
		public override int GetHashCode()
		{
			return this.Registrator.GetHashCode() ^ this.Handler.GetHashCode() ^ this.Priority;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is HandlerRegistration<ArgsType>))
				return false;

			HandlerRegistration<ArgsType> other = (HandlerRegistration<ArgsType>)obj;
			return (
				this.Registrator == other.Registrator &&
				this.Handler.Equals(other.Handler));
		}

		public static bool operator ==(HandlerRegistration<ArgsType> a, HandlerRegistration<ArgsType> b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(HandlerRegistration<ArgsType> a, HandlerRegistration<ArgsType> b)
		{
			return !a.Equals(b);
		}
	}
}
