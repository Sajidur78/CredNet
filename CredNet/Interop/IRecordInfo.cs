using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[Guid("0000002F-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IRecordInfo
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RecordInit([Out] IntPtr pvNew);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RecordClear([In] IntPtr pvExisting);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RecordCopy([In] IntPtr pvExisting, [Out] IntPtr pvNew);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetGuid(out Guid pguid);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetName([MarshalAs(UnmanagedType.BStr)] out string pbstrName);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetSize(out uint pcbSize);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetTypeInfo([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler))] out Type ppTypeInfo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetField([In] IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] [In] string szFieldName, [MarshalAs(UnmanagedType.Struct)] out object pvarField);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetFieldNoCopy([In] IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] [In] string szFieldName, [MarshalAs(UnmanagedType.Struct)] out object pvarField, out IntPtr ppvDataCArray);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int PutField([In] uint wFlags, [In] [Out] IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] [In] string szFieldName, [MarshalAs(UnmanagedType.Struct)] [In] ref object pvarField);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int PutFieldNoCopy([In] uint wFlags, [In] [Out] IntPtr pvData, [MarshalAs(UnmanagedType.LPWStr)] [In] string szFieldName, [MarshalAs(UnmanagedType.Struct)] [In] ref object pvarField);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int GetFieldNames([In] [Out] ref uint pcNames, [MarshalAs(UnmanagedType.BStr)] out string rgBstrNames);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		int IsMatchingType([MarshalAs(UnmanagedType.Interface)] [In] IRecordInfo pRecordInfo);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		IntPtr RecordCreate();

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RecordCreateCopy([In] IntPtr pvSource, out IntPtr ppvDest);

		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.Error)]
		int RecordDestroy([In] IntPtr pvRecord);
	}
}
