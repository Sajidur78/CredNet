using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[Guid("A5DA53F9-D475-4080-A120-910C4A739880")]
	[ComImport]
	public interface ICredentialProviderFilter
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Filter([In] UsageScenario cpus, [In] uint dwFlags, IntPtr rgclsidProviders, IntPtr rgbAllow, [In] uint cProviders);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int UpdateRemoteCredential([In] ref CredentialSerialization pcpcsIn, ref CredentialSerialization pcpcsOut);
	}
}
