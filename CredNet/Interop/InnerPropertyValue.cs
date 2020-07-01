using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 8)]
	public struct InnerPropertyValue
	{
		[FieldOffset(0)]
		public sbyte cVal;

		[FieldOffset(0)]
		public byte bVal;

		[FieldOffset(0)]
		public short iVal;

		[FieldOffset(0)]
		public ushort uiVal;

		[FieldOffset(0)]
		public int lVal;

		[FieldOffset(0)]
		public uint ulVal;

		[FieldOffset(0)]
		public int intVal;

		[FieldOffset(0)]
		public uint uintVal;

		[FieldOffset(0)]
		public _LARGE_INTEGER hVal;

		[FieldOffset(0)]
		public _ULARGE_INTEGER uhVal;

		[FieldOffset(0)]
		public float fltVal;

		[FieldOffset(0)]
		public double dblVal;

		[FieldOffset(0)]
		public short boolVal;

		[FieldOffset(0)]
		public short __OBSOLETE__VARIANT_BOOL;

		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.Error)]
		public int scode;

		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.Currency)]
		public decimal cyVal;

		[FieldOffset(0)]
		public DateTime date;

		[FieldOffset(0)]
		public _FILETIME filetime;

		[FieldOffset(0)]
		public tagBSTRBLOB bstrblobVal;

		[FieldOffset(0)]
		public tagBLOB blob;

		[FieldOffset(0)]
		public tagCAC cac;

		[FieldOffset(0)]
		public tagCAUB caub;

		[FieldOffset(0)]
		public tagCAI cai;

		[FieldOffset(0)]
		public tagCAUI caui;

		[FieldOffset(0)]
		public tagCAL cal;

		[FieldOffset(0)]
		public tagCAUL caul;

		[FieldOffset(0)]
		public tagCAFLT caflt;

		[FieldOffset(0)]
		public tagCADBL cadbl;

		[FieldOffset(0)]
		public tagCABOOL cabool;

		[FieldOffset(0)]
		public tagCASCODE cascode;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pcVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pbVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr piVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr puiVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr plVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pulVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pintVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr puintVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pfltVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pdblVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pboolVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pscode;
	}
}
