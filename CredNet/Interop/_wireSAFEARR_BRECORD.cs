using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct _wireSAFEARR_BRECORD
	{
		public uint Size;

		[ComConversionLoss]
		public IntPtr aRecord;
	}
}
