using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tagVersionedStream
	{
		public Guid guidVersion;

		[MarshalAs(UnmanagedType.Interface)]
		public IStream pStream;
	}
}
