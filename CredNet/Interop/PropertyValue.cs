using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct PropertyValue
	{
		public ushort vt;

		public byte wReserved1;

		public byte wReserved2;

		public uint wReserved3;

		public InnerPropertyValue Value;
	}
}
