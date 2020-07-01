using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct tagIDLDESC
	{
		[ComAliasName("CredNet.Interfaces.ULONG_PTR")]
		public ulong dwReserved;

		public ushort wIDLFlags;
	}
}
