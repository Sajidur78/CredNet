using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("94596C7E-3744-41CE-893E-BBF09122F76A")]
	
	[TypeLibType(TypeLibTypeFlags.FCanCreate)]
	[ComImport]
	public class SmartcardPinProviderClass : ICredentialProvider, SmartcardPinProvider
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
