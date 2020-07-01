using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[ComConversionLoss]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CredentialSerialization
	{
		public uint AuthenticationPackage;

		public Guid ProviderClassGuid;

		public uint SerializationSize;

		[ComConversionLoss]
		public IntPtr SerializationData;
	}
}
