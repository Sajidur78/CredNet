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
                       ((domain.Length + username.Length + password.Length) * sizeof(char));

            var dataBuffer = new byte[size];

            fixed (byte* buffer = dataBuffer)
            {
                var logon = (KerberosInteractiveLogon*) buffer;

                logon->SubmitType = KerbLogonSubmitType.InteractiveLogon;
                logon->LogonDomainName.Length = (ushort)(domain.Length * sizeof(char));
                logon->LogonDomainName.MaxLength = logon->LogonDomainName.Length;
                logon->LogonDomainName.Buffer = (IntPtr)sizeof(KerberosInteractiveLogon);
                fixed (char* domainBuffer = domain)
                {
                    Unsafe.CopyBlock(buffer + logon->LogonDomainName.Buffer.ToInt64(), domainBuffer, logon->LogonDomainName.Length);
                }

                logon->Username.Length = (ushort) (username.Length * sizeof(char));
                logon->Username.MaxLength = logon->Username.Length;
                logon->Username.Buffer = (IntPtr)(sizeof(KerberosInteractiveLogon) + logon->LogonDomainName.Length);
                fixed (char* usernameBuffer = username)
                {
                    Unsafe.CopyBlock(buffer + logon->Username.Buffer.ToInt64(), usernameBuffer, logon->Username.Length);
                }

                logon->Password.Length = (ushort)(password.Length * sizeof(char));
                logon->Password.MaxLength = logon->Password.Length;
                logon->Password.Buffer = (IntPtr)(sizeof(KerberosInteractiveLogon) + logon->LogonDomainName.Length + logon->Username.Length);
                fixed (char* passwordBuffer = password)
                {
                    Unsafe.CopyBlock(buffer + logon->Password.Buffer.ToInt64(), passwordBuffer, logon->Password.Length);
                }
            }

            return dataBuffer;
        }
    }
}
