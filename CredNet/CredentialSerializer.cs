using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
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

        public static unsafe byte[] SerializeKerbWorkstationUnlock(string domain, string username, string password)
        {
            var data = SerializeKerbInteractiveLogon(domain, username, password);

            return ModifySerializationType(data, KerbLogonSubmitType.WorkstationUnlockLogon);
        }

        public static unsafe byte[] ModifySerializationType(byte[] serialization, KerbLogonSubmitType type)
        {
            if (type == KerbLogonSubmitType.WorkstationUnlockLogon) {
                fixed (byte* buffer = serialization)
                {
                    ((KerberosInteractiveLogon*)buffer)->SubmitType = type;
                }
            }

            return serialization;
        }

        /// <summary>
        /// Deserialize KerberosInteractiveLogon or KerberosWorkstationUnlock credentials.
        /// </summary>
        /// <param name="serialization"></param>
        /// <param name="domain"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static unsafe bool TryDeserializeInteractiveCredentials(byte[] serialization, out string domain, out string username,
            out string password)
        {
            fixed (byte* buffer = serialization)
            {
                var logon = (KerberosInteractiveLogon*) buffer;
                if (logon->SubmitType != KerbLogonSubmitType.WorkstationUnlockLogon &&
                    logon->SubmitType != KerbLogonSubmitType.InteractiveLogon)
                {
                    domain = null;
                    username = null;
                    password = null;
                    return false;
                }

                var lsaDomain = logon->LogonDomainName;
                var lsaUsername = logon->Username;
                var lsaPassword = logon->Password;

                lsaDomain.Buffer = new IntPtr(buffer) + lsaDomain.Buffer.ToInt32();
                lsaUsername.Buffer = new IntPtr(buffer) + lsaUsername.Buffer.ToInt32();
                lsaPassword.Buffer = new IntPtr(buffer) + lsaPassword.Buffer.ToInt32();

                domain = lsaDomain.ToStringUni();
                username = lsaUsername.ToStringUni();
                password = lsaPassword.ToStringUni();
            }
            return true;
        }
    }
}
