using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct _wireVARIANT
	{
		public uint clSize;

		public uint rpcReserved;

		public ushort vt;

		public ushort wReserved1;

		public ushort wReserved2;

		public ushort wReserved3;

		public __MIDL_IOleAutomationTypes_0004 DUMMYUNIONNAME;
	}
}
