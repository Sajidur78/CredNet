using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[Guid("00020403-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[ComConversionLoss]
	[ComImport]
	public interface ITypeComp
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteBind([MarshalAs(UnmanagedType.LPWStr)] [In] string szName, [In] uint lHashVal, [In] ushort wFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTInfo, out tagDESCKIND pDescKind, [Out] IntPtr ppFuncDesc, [Out] IntPtr ppVarDesc, [MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTypeComp, [ComAliasName("CredNet.Interfaces.DWORD")] out uint pDummy);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteBindType([MarshalAs(UnmanagedType.LPWStr)] [In] string szName, [In] uint lHashVal, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTInfo);
	}
}
