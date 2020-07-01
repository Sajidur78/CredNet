using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[Guid("90C119AE-0F18-4520-A1F1-114366A40FE8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[ComImport]
	public interface ICredentialProviderUserArray
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetProviderFilter([In] ref Guid guidProviderToFilterTo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetAccountOptions(out AccountOptions credentialProviderAccountOptions);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetCount(out uint userCount);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetAt([In] uint userIndex, [MarshalAs(UnmanagedType.Interface)] out ICredentialProviderUser user);
	}
}
