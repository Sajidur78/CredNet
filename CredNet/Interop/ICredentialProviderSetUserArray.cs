using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[Guid("095C1484-1C0C-4388-9C6D-500E61BF84BD")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface ICredentialProviderSetUserArray
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetUserArray([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderUserArray users);
	}
}
