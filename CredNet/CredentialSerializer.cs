using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CredNet
{
    public class CredentialSerializer
    {
        public static unsafe byte[] SerializeKerbInteractiveLogon(string domain, string username, string password)
        {
            var size = sizeof(KerberosInteractiveLogon) +
                       Encoding.Unicode.GetMaxByteCount(domain.Length) +
                       Encoding.Unicode.GetMaxByteCount(username.Length) +
                       Encoding.Unicode.GetMaxByteCount(password.Length);

            var dataBuffer = new byte[size];

            fixed (byte* buffer = dataBuffer)
            {
                var logon = (KerberosInteractiveLogon*)buffer;

                logon->SubmitType = KerbLogonSubmitType.InteractiveLogon;
                logon->LogonDomainName.MaxLength = (ushort)Encoding.Unicode.GetMaxByteCount(domain.Length);
                logon->LogonDomainName.Length = (ushort)(domain.Length * sizeof(char));
                logon->LogonDomainName.Buffer = (IntPtr)sizeof(KerberosInteractiveLogon);
                fixed (char* domainBuffer = domain)
                {
                    Encoding.Unicode.GetBytes(domainBuffer, domain.Length,
                        buffer + logon->LogonDomainName.Buffer.ToInt64(), logon->LogonDomainName.Length);
                }

                logon->Username.Length = (ushort)(username.Length * sizeof(char));
                logon->Username.MaxLength = (ushort)Encoding.Unicode.GetMaxByteCount(username.Length);
                logon->Username.Buffer = (IntPtr)(sizeof(KerberosInteractiveLogon) + logon->LogonDomainName.MaxLength);
                fixed (char* usernameBuffer = username)
                {
                    Encoding.Unicode.GetBytes(usernameBuffer, username.Length,
                        buffer + logon->Username.Buffer.ToInt64(), logon->Username.Length);
                }

                logon->Password.MaxLength = (ushort)Encoding.Unicode.GetMaxByteCount(password.Length);
                logon->Password.Length = (ushort)(password.Length * sizeof(char));
                logon->Password.Buffer = (IntPtr)(sizeof(KerberosInteractiveLogon) + logon->LogonDomainName.MaxLength + logon->Username.MaxLength);
                fixed (char* passwordBuffer = password)
                {
                    Encoding.Unicode.GetBytes(passwordBuffer, password.Length,
                        buffer + logon->Password.Buffer.ToInt64(), logon->Password.Length);
                }
            }

            return dataBuffer;
        }
    }
}
