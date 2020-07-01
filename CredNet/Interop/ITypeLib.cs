using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[Guid("00020402-0000-0000-C000-000000000046")]
	[ComImport]
	public interface ITypeLib
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetTypeInfoCount(out uint pcTInfo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetTypeInfo([In] uint index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTInfo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetTypeInfoType([In] uint index, out tagTYPEKIND pTKind);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetTypeInfoOfGuid([In] ref Guid guid, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTInfo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetLibAttr([Out] IntPtr ppTLibAttr, [ComAliasName("CredNet.Interfaces.DWORD")] out uint pDummy);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetTypeComp([MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTComp);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetDocumentation([In] int index, [In] uint refPtrFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrName, [MarshalAs(UnmanagedType.BStr)] out string pBstrDocString, out uint pdwHelpContext, [MarshalAs(UnmanagedType.BStr)] out string pBstrHelpFile);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteIsName([MarshalAs(UnmanagedType.LPWStr)] [In] string szNameBuf, [In] uint lHashVal, out int pfName, [MarshalAs(UnmanagedType.BStr)] out string pBstrLibName);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteFindName([MarshalAs(UnmanagedType.LPWStr)] [In] string szNameBuf, [In] uint lHashVal, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTInfo, out int rgMemId, [In] [Out] ref ushort pcFound, [MarshalAs(UnmanagedType.BStr)] out string pBstrLibName);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalReleaseTLibAttr();
	}
}
