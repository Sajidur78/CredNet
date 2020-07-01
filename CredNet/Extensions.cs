using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interop;

namespace CredNet
{
    public static class Extensions
    {
        public static string GetUserName(this ICredentialProviderUser user)
        {
            user.GetStringValue(PropertyKeys.PKEY_Identity_UserName, out var value);
            return value;
        }

        public static string GetQualifiedUserName(this ICredentialProviderUser user)
        {
            user.GetStringValue(PropertyKeys.PKEY_Identity_QualifiedUserName, out var value);
            return value;
        }

        public static string GetDisplayName(this ICredentialProviderUser user)
        {
            user.GetStringValue(PropertyKeys.PKEY_Identity_DisplayName, out var value);
            return value;
        }

        public static string GetLogonStatus(this ICredentialProviderUser user)
        {
            user.GetStringValue(PropertyKeys.PKEY_Identity_LogonStatusString, out var value);
            return value;
        }

        public static string GetPrimarySid(this ICredentialProviderUser user)
        {
            user.GetStringValue(PropertyKeys.PKEY_Identity_PrimarySid, out var value);
            return value;
        }

        public static string GetProviderID(this ICredentialProviderUser user)
        {
            user.GetStringValue(PropertyKeys.PKEY_Identity_ProviderID, out var value);
            return value;
        }
    }
}
