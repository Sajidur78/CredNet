using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interop;

namespace CredNet.Sample
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("CredNet.Sample")]
    [Guid("f264df76-2c20-4884-8f05-7b75bb455b35")]
    public class SampleCredentialProvider : CredentialProviderBase
    {
        public static uint NegotiateAuthPackage = Native.LookupAuthenticationPackage("Negotiate");

        public override bool IsUsageSupported(UsageScenario usage)
        {
            return usage == UsageScenario.Logon;
        }

        public override void Initialize()
        {
            // Non personalized credential sample
            Credentials.Add(new NonPersonalizedSampleCredential());

            // Personalized credential sample
            foreach (var user in Users)
            {
                Credentials.Add(new PersonalizedSampleCredential(user));
            }
        }
    }
}