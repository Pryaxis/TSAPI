using System;

namespace TerrariaApi.Server
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class ApiVersionAttribute : Attribute
	{
		public Version ApiVersion;
		public ApiVersionAttribute(Version version)
		{
			this.ApiVersion = version;
		}
		public ApiVersionAttribute(int major, int minor) : this(new Version(major, minor))
		{
		}
	}
}
