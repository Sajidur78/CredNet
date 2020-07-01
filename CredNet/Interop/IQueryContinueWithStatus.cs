using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("9090BE5B-502B-41FB-BCCC-0049A6C7254B")]
	
	[ComImport]
	public interface IQueryContinueWithStatus : IQueryContinue
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int QueryContinue();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetStatusMessage([MarshalAs(UnmanagedType.LPWStr)] [In] string psz);
	}
}
