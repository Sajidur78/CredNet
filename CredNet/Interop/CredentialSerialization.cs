using System;
using System.Runtime.CompilerServices;
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

    public struct ManagedCredentialSerialization
    {
        public uint AuthenticationPackage;
        public Guid ProviderClassGuid;
        public byte[] Serialization;

        public static unsafe ManagedCredentialSerialization FromNative(CredentialSerialization serialization)
        {
            var man = new ManagedCredentialSerialization
            {
                AuthenticationPackage = serialization.AuthenticationPackage,
                ProviderClassGuid = serialization.ProviderClassGuid,
                Serialization = new byte[serialization.SerializationSize]
            };

            if (serialization.SerializationSize != 0)
            {
                Unsafe.CopyBlock(ref man.Serialization[0],
                    ref Unsafe.AsRef<byte>(serialization.SerializationData.ToPointer()),
                    serialization.SerializationSize);
            }

            return man;
        }

        public unsafe CredentialSerialization ToNative()
        {
            var ser = new CredentialSerialization
            {
                AuthenticationPackage = AuthenticationPackage,
                ProviderClassGuid = ProviderClassGuid,
                SerializationSize = Serialization == null ? 0 : (uint)Serialization.Length,
                SerializationData = Serialization == null ? IntPtr.Zero : Marshal.AllocCoTaskMem(Serialization.Length)
            };

            if (ser.SerializationData != IntPtr.Zero)
            {
                Unsafe.CopyBlock(ref Unsafe.AsRef<byte>(ser.SerializationData.ToPointer()), ref Serialization[0],
                    (uint)Serialization.Length);
            }

            return ser;
        }
    }
}
