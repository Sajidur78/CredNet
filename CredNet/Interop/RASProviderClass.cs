using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[TypeLibType(TypeLibTypeFlags.FCanCreate)]
	[ComConversionLoss]
	[Guid("5537E283-B1E7-4EF8-9C6E-7AB0AFE5056D")]
	[ClassInterface(ClassInterfaceType.None)]
	
	[ComImport]
	public class RASProviderClass : ICredentialProvider, RASProvider
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int SetUsageScenario([In] UsageScenario cpus, [In] uint dwFlags);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int SetSerialization([In] ref CredentialSerialization pcpcs);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int Advise([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderEvents pcpe, IntPtr upAdviseContext);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int UnAdvise();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int GetFieldDescriptorCount(out uint pdwCount);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int GetFieldDescriptorAt([In] uint dwIndex, out IntPtr ppcpfd);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int GetCredentialCount(out uint pdwCount, out uint pdwDefault, out int pbAutoLogonWithDefault);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		public virtual extern int GetCredentialAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface)] out ICredentialProviderCredential ppcpc);
	}
}
