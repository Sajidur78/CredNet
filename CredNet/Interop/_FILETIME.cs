using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct _FILETIME
	{
		public uint dwLowDateTime;

		public uint dwHighDateTime;
	}
}
