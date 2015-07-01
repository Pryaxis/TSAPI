using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace NATUPNPLib
{
	[DefaultMember("Item"), CompilerGenerated, Guid("CD1F3E77-66D6-4664-82C7-36DBB641D0F1"), TypeIdentifier]
	[ComImport]
	public interface IStaticPortMappingCollection : IEnumerable
	{
		[DispId(-4)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler")]
		void _VtblGap1_2();
		[DispId(2)]
		void Remove([In] int lExternalPort, [MarshalAs(UnmanagedType.BStr)] [In] string bstrProtocol);
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.Interface)]
		IStaticPortMapping Add([In] int lExternalPort, [MarshalAs(UnmanagedType.BStr)] [In] string bstrProtocol, [In] int lInternalPort, [MarshalAs(UnmanagedType.BStr)] [In] string bstrInternalClient, [In] bool bEnabled, [MarshalAs(UnmanagedType.BStr)] [In] string bstrDescription);
	}
}
