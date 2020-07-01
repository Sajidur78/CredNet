using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct _LONG_SIZEDARR
	{
		public uint clSize;

		[ComConversionLoss]
		public IntPtr pData;
	}
}
