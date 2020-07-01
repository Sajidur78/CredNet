using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[ComConversionLoss]
	[StructLayout(LayoutKind.Explicit, Pack = 8, Size = 16)]
	public struct __MIDL_IOleAutomationTypes_0004
	{
		[FieldOffset(0)]
		public long llVal;

		[FieldOffset(0)]
		public int lVal;

		[FieldOffset(0)]
		public byte bVal;

		[FieldOffset(0)]
		public short iVal;

		[FieldOffset(0)]
		public float fltVal;

		[FieldOffset(0)]
		public double dblVal;

		[FieldOffset(0)]
		public short boolVal;

		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.Error)]
		public int scode;

		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.Currency)]
		public decimal cyVal;

		[FieldOffset(0)]
		public DateTime date;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pbVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr piVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr plVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pllVal;

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

		[FieldOffset(0)]
		public sbyte cVal;

		[FieldOffset(0)]
		public ushort uiVal;

		[FieldOffset(0)]
		public uint ulVal;

		[FieldOffset(0)]
		public ulong ullVal;

		[FieldOffset(0)]
		public int intVal;

		[FieldOffset(0)]
		public uint uintVal;

		[FieldOffset(0)]
		public decimal decVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pcVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr puiVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pulVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pullVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr pintVal;

		[ComConversionLoss]
		[FieldOffset(0)]
		public IntPtr puintVal;
	}
}
