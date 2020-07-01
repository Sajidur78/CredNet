using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[Guid("B53C00B6-9922-4B78-B1F4-DDFE774DC39B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface ICredentialProviderCredentialEvents2 : ICredentialProviderCredentialEvents
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldState([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] FieldState cpfs);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldInteractiveState([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] FieldInteractiveState cpfis);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldString([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [MarshalAs(UnmanagedType.LPWStr)] [In] string psz);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldCheckbox([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] int bChecked, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszLabel);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldBitmap([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] IntPtr hbmp);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldComboBoxSelectedItem([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] uint dwSelectedItem);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int DeleteFieldComboBoxItem([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] uint dwItem);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int AppendFieldComboBoxItem([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [MarshalAs(UnmanagedType.LPWStr)] [In] string pszItem);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldSubmitButton([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential pcpc, [In] uint dwFieldID, [In] uint dwAdjacentTo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int OnCreatingWindow([ComAliasName("CredNet.Interfaces.wireHWND")] out _RemotableHandle phwndOwner);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int BeginFieldUpdates();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int EndFieldUpdates();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetFieldOptions([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredential credential, [In] uint fieldID, [In] FieldOptions options);
	}
}
