using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	
	[Guid("0000000B-0000-0000-C000-000000000046")]
	[ComImport]
	public interface IStorage
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int CreateStream([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName, [In] uint grfMode, [In] uint reserved1, [In] uint reserved2, [MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteOpenStream([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName, [In] uint cbReserved1, [In] ref byte reserved1, [In] uint grfMode, [In] uint reserved2, [MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int CreateStorage([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName, [In] uint grfMode, [In] uint reserved1, [In] uint reserved2, [MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int OpenStorage([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName, [MarshalAs(UnmanagedType.Interface)] [In] IStorage pstgPriority, [In] uint grfMode, [ComAliasName("CredNet.Interfaces.wireSNB")] [In] ref tagRemSNB snbExclude, [In] uint reserved, [MarshalAs(UnmanagedType.Interface)] out IStorage ppstg);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteCopyTo([In] uint ciidExclude, [In] ref Guid rgiidExclude, [ComAliasName("CredNet.Interfaces.wireSNB")] [In] ref tagRemSNB snbExclude, [MarshalAs(UnmanagedType.Interface)] [In] IStorage pstgDest);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int MoveElementTo([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName, [MarshalAs(UnmanagedType.Interface)] [In] IStorage pstgDest, [MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsNewName, [In] uint grfFlags);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Commit([In] uint grfCommitFlags);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Revert();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RemoteEnumElements([In] uint reserved1, [In] uint cbReserved2, [In] ref byte reserved2, [In] uint reserved3, [MarshalAs(UnmanagedType.Interface)] out IEnumSTATSTG ppenum);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int DestroyElement([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RenameElement([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsOldName, [MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsNewName);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetElementTimes([MarshalAs(UnmanagedType.LPWStr)] [In] string pwcsName, [In] ref _FILETIME pctime, [In] ref _FILETIME patime, [In] ref _FILETIME pmtime);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetClass([In] ref Guid clsid);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int SetStateBits([In] uint grfStateBits, [In] uint grfMask);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int Stat(out tagSTATSTG pstatstg, [In] uint grfStatFlag);
	}
}
