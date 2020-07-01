using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tagSAFEARRAYBOUND
	{
		public uint cElements;

		public int lLbound;
	}
}
