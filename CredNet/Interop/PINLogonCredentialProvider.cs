﻿using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[Guid("D27C3481-5A1C-45B2-8AAA-C20EBBE8229E")]
	[CoClass(typeof(PINLogonCredentialProviderClass))]
	[ComImport]
	public interface PINLogonCredentialProvider : ICredentialProvider
	{
	}
}
