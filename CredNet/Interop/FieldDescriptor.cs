using System;
using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public unsafe struct FieldDescriptor
	{
		public uint FieldID;

		public FieldType FieldType;

		public StringPointer Label;

		public Guid FieldTypeGuid;
	}
}
