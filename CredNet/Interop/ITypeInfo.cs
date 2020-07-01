using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[Guid("00020401-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComConversionLoss]
	
	[ComImport]
	public interface ITypeInfo
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetTypeAttr([Out] IntPtr ppTypeAttr, [ComAliasName("CredNet.Interfaces.DWORD")] out uint pDummy);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetTypeComp([MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTComp);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetFuncDesc([In] uint index, [Out] IntPtr ppFuncDesc, [ComAliasName("CredNet.Interfaces.DWORD")] out uint pDummy);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetVarDesc([In] uint index, [Out] IntPtr ppVarDesc, [ComAliasName("CredNet.Interfaces.DWORD")] out uint pDummy);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetNames([In] int memid, [MarshalAs(UnmanagedType.BStr)] out string rgBstrNames, [In] uint cMaxNames, out uint pcNames);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetRefTypeOfImplType([In] uint index, out uint pRefType);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetImplTypeFlags([In] uint index, out int pImplTypeFlags);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalGetIDsOfNames();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalInvoke();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetDocumentation([In] int memid, [In] uint refPtrFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrName, [MarshalAs(UnmanagedType.BStr)] out string pBstrDocString, out uint pdwHelpContext, [MarshalAs(UnmanagedType.BStr)] out string pBstrHelpFile);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetDllEntry([In] int memid, [In] tagINVOKEKIND invkind, [In] uint refPtrFlags, [MarshalAs(UnmanagedType.BStr)] out string pBstrDllName, [MarshalAs(UnmanagedType.BStr)] out string pbstrName, out ushort pwOrdinal);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetRefTypeInfo([In] uint hreftype, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTInfo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalAddressOfMember();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteCreateInstance([In] ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetMops([In] int memid, [MarshalAs(UnmanagedType.BStr)] out string pBstrMops);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteGetContainingTypeLib([MarshalAs(UnmanagedType.Interface)] out ITypeLib ppTLib, out uint pIndex);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalReleaseTypeAttr();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalReleaseFuncDesc();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int LocalReleaseVarDesc();
	}
}
