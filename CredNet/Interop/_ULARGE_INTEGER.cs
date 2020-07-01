using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct _ULARGE_INTEGER
	{
		public ulong QuadPart;
	}
}
