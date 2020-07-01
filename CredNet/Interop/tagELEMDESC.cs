using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tagELEMDESC
	{
		public tagTYPEDESC tdesc;

		public tagPARAMDESC paramdesc;
	}
}
