using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[Guid("34201E5A-A787-41A3-A5A4-BD6DCF2A854E")]
	[ComImport]
	public interface ICredentialProviderEvents
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int CredentialsChanged(IntPtr upAdviseContext);
	}
}
