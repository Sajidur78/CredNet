using System.Runtime.InteropServices;

namespace CredNet.Interop
{
	[CoClass(typeof(SmartcardCredentialProviderClass))]
	[Guid("D27C3481-5A1C-45B2-8AAA-C20EBBE8229E")]
	[ComImport]
	public interface SmartcardCredentialProvider : ICredentialProvider
	{
	}
}
