using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace NATUPNPLib
{
	[CompilerGenerated, Guid("B171C812-CC76-485A-94D8-B6B3A2794E99"), TypeIdentifier]
	[ComImport]
	public interface IUPnPNAT
	{
		IStaticPortMappingCollection StaticPortMappingCollection
		{
			[DispId(1)]
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}
	}
}
