using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("0000000D-0000-0000-C000-000000000046")]
	[ComImport]
	public interface IEnumSTATSTG
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteNext([In] uint celt, out tagSTATSTG rgelt, out uint pceltFetched);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Skip([In] uint celt);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Reset();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Clone([MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);
	}
}
