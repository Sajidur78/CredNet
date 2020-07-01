using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tagVARDESC
	{
		public int memid;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpstrSchema;

		public __MIDL_IOleAutomationTypes_0006 DUMMYUNIONNAME;

		public tagELEMDESC elemdescVar;

		public ushort wVarFlags;

		public tagVARKIND varkind;
	}
}
