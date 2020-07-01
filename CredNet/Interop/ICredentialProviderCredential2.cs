﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[Guid("FD672C54-40EA-4D6E-9B49-CFB1A7507BD7")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
	public interface ICredentialProviderCredential2 : ICredentialProviderCredential
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Advise([MarshalAs(UnmanagedType.Interface)] [In] ICredentialProviderCredentialEvents pcpce);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int UnAdvise();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetSelected(out int pbAutoLogon);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetDeselected();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetFieldState([In] uint dwFieldID, out FieldState pcpfs, out FieldInteractiveState pcpfis);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetStringValue([In] uint dwFieldID, [MarshalAs(UnmanagedType.LPWStr)] out string ppsz);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetBitmapValue([In] uint dwFieldID, out IntPtr phbmp);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetCheckboxValue([In] uint dwFieldID, out int pbChecked, [MarshalAs(UnmanagedType.LPWStr)] out string ppszLabel);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetSubmitButtonValue([In] uint dwFieldID, out uint pdwAdjacentTo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetComboBoxValueCount([In] uint dwFieldID, out uint pcItems, out uint pdwSelectedItem);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetComboBoxValueAt([In] uint dwFieldID, uint dwItem, [MarshalAs(UnmanagedType.LPWStr)] out string ppszItem);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetStringValue([In] uint dwFieldID, [MarshalAs(UnmanagedType.LPWStr)] [In] string psz);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetCheckboxValue([In] uint dwFieldID, [In] int bChecked);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetComboBoxSelectedValue([In] uint dwFieldID, [In] uint dwSelectedItem);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int CommandLinkClicked([In] uint dwFieldID);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetSerialization(out SerializationResponse pcpgsr, out CredentialSerialization pcpcs, [MarshalAs(UnmanagedType.LPWStr)] out string ppszOptionalStatusText, out StatusIcon pcpsiOptionalStatusIcon);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int ReportResult([In] int ntsStatus, [In] int ntsSubstatus, [MarshalAs(UnmanagedType.LPWStr)] out string ppszOptionalStatusText, out StatusIcon pcpsiOptionalStatusIcon);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetUserSid([MarshalAs(UnmanagedType.LPWStr)] out string sid);
	}
}
