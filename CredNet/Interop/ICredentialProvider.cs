using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[Guid("D27C3481-5A1C-45B2-8AAA-C20EBBE8229E")]
	[ComImport]
	public interface ICredentialProvider
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetUsageScenario([In] UsageScenario cpus, [In] uint dwFlags);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetSerialization([In] ref CredentialSerialization pcpcs);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Advise([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderEvents pcpe, IntPtr upAdviseContext);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int UnAdvise();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetFieldDescriptorCount(out uint pdwCount);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetFieldDescriptorAt([In] uint dwIndex, out IntPtr ppcpfd);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetCredentialCount(out uint pdwCount, out uint pdwDefault, out int pbAutoLogonWithDefault);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetCredentialAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICredentialProviderCredential ppcpc);
	}
}
