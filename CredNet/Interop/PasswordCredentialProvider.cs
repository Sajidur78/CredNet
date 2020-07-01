using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[CoClass(typeof(PasswordCredentialProviderClass))]
	[Guid("D27C3481-5A1C-45B2-8AAA-C20EBBE8229E")]
	[ComImport]
	public interface PasswordCredentialProvider : ICredentialProvider
	{
	}
}
