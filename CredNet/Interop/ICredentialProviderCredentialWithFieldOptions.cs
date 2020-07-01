using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("DBC6FB30-C843-49E3-A645-573E6F39446A")]
	[ComImport]
	public interface ICredentialProviderCredentialWithFieldOptions
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetFieldOptions([In] uint fieldID, out FieldOptions options);
	}
}
