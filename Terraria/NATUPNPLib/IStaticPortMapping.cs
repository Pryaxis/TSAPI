using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace NATUPNPLib
{
	[CompilerGenerated, Guid("6F10711F-729B-41E5-93B8-F21D0F818DF1"), TypeIdentifier]
	[ComImport]
	public interface IStaticPortMapping
	{
		int InternalPort
		{
			[DispId(3)]
			get;
		}
		string Protocol
		{
			[DispId(4)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
		string InternalClient
		{
			[DispId(5)]
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}
		void _VtblGap1_2();
	}
}
