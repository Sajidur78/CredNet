using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[ComConversionLoss]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 24)]
	public struct __MIDL_IOleAutomationTypes_0001
	{
		[FieldOffset(0)]
		public _BYTE_SIZEDARR ByteStr;

		[FieldOffset(0)]
		public _SHORT_SIZEDARR WordStr;

		[FieldOffset(0)]
		public _LONG_SIZEDARR LongStr;

		[FieldOffset(0)]
		public _HYPER_SIZEDARR HyperStr;
	}
}
