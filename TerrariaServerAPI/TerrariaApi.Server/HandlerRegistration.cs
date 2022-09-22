using Microsoft.Extensions.Logging;
namespace TerrariaApi.Server
{
	internal struct HandlerRegistration<ArgsType> where ArgsType : EventArgs
	{
		public HookHandler<ArgsType> Handler { get; set; }
		public ILogger Logger { get; set; }
		public int Priority { get; set; }

		public override int GetHashCode()
		{
			return this.Logger.GetHashCode() ^ this.Handler.GetHashCode() ^ this.Priority;
		}

		public override bool Equals(object? obj)
		{
			if (!(obj is HandlerRegistration<ArgsType>))
				return false;

			HandlerRegistration<ArgsType> other = (HandlerRegistration<ArgsType>)obj;
			return (this.Handler.Equals(other.Handler) && this.Logger.Equals(other.Logger));
		}
	}
}
