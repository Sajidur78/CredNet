using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct _LARGE_INTEGER
	{
		public long QuadPart;
	}
}
