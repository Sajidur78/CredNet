using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("13793285-3EA6-40FD-B420-15F47DA41FBB")]
	
	[ComImport]
	public interface ICredentialProviderUser
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetSid([MarshalAs(UnmanagedType.LPWStr)] out string sid);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetProviderID(out Guid providerID);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetStringValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.LPWStr)] out string stringValue);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetValue([In] ref PropertyKey key, out PropertyValue value);
	}
}
