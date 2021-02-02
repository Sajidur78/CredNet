using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredNet
{
    // ReSharper disable once InconsistentNaming
    public class CredUI
    {
        [Flags]
        public enum Flags
        {
            /// <summary>
            /// Plain text username/password is being requested
            /// </summary>
            Generic = 0x00000001,

            /// <summary>
            /// Show the Save Credential checkbox
            /// </summary>
            CheckBox = 0x00000002,

            /// <summary>
            /// Only Cred Providers that support the input auth package should enumerate
            /// </summary>
            AuthPackageOnly = 0x00000010,

            /// <summary>
            /// Only the incoming cred for the specific auth package should be enumerated
            /// </summary>
            InCredOnly = 0x00000020,

            /// <summary>
            /// Cred Providers should enumerate administrators only
            /// </summary>
            AdminOnly = 0x00000100,

            /// <summary>
            /// Only the incoming cred for the specific auth package should be enumerated
            /// </summary>
            EnumerateCurrentUser = 0x00000200,

            /// <summary>
            /// The CredUI prompt should be displayed on the secure desktop
            /// </summary>
            SecurePrompt = 0x00001000,

            /// <summary>
            /// Tell the credential provider it should be packing its Auth Blob 32 bit even though it is running 64 native
            /// </summary>
            Pack32 = 0x10000000,
        }
    }
}
