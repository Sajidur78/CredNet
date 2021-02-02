using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CredNet
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LsaString : IDisposable
    {
        public ushort Length;
        public ushort MaxLength;
        public IntPtr Buffer;

        public LsaString(string value)
        {
            Length = (ushort)value.Length;
            MaxLength = Length;
            Buffer = Marshal.StringToHGlobalAnsi(value);
        }

        public static implicit operator LsaString(string value) => new LsaString(value);
        public static implicit operator string(LsaString value) => value.ToString();

        public override string ToString()
        {
            return Marshal.PtrToStringAnsi(Buffer) ?? string.Empty;
        }

        public string ToStringUni()
        {
            return Marshal.PtrToStringUni(Buffer) ?? string.Empty;
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Buffer);
        }
    }

    public struct LsaHandle : IDisposable
    {
        public IntPtr Handle;

        public LsaHandle(IntPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator LsaHandle(IntPtr handle) => new LsaHandle(handle);
        public static implicit operator IntPtr(LsaHandle handle) => handle.Handle;

        public static LsaHandle ConnectUntrusted()
        {
            Native.LsaConnectUntrusted(out var handle);
            return handle;
        }

        public bool IsValid()
        {
            return Handle != IntPtr.Zero;
        }

        public void Dispose()
        {
            Native.LsaDeregisterLogonProcess(Handle);
        }
    }

    public class Native
    {
        [DllImport("secur32.dll", SetLastError = false)]
        public static extern uint LsaConnectUntrusted(out IntPtr LsaHandle);

        [DllImport("secur32.dll", SetLastError = false)]
        public static extern IntPtr LsaDeregisterLogonProcess([In] IntPtr handle);

        [DllImport("secur32.dll", SetLastError = false)]
        public static extern uint LsaLookupAuthenticationPackage(IntPtr lsaHandle, ref LsaString packageName, out uint authenticationPackage);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern uint LsaNtStatusToWinError(uint status);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetComputerName(StringBuilder buffer, ref uint size);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        
        public static string GetComputerName(uint bufferSize = 25)
        {
            var buffer = new StringBuilder((int)bufferSize);

            if (GetComputerName(buffer, ref bufferSize))
            {
                return buffer.ToString();
            }

            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public static uint LookupAuthenticationPackage(LsaString packageName)
        {
            using (var handle = LsaHandle.ConnectUntrusted())
            {
                LsaLookupAuthenticationPackage(handle, ref packageName, out var package);
                return package;
            }
        }
    }

    public enum KerbLogonSubmitType : uint
    {
        InteractiveLogon = 2,
        SmartCardLogon = 6,
        WorkstationUnlockLogon = 7,
        SmartCardUnlockLogon = 8,
        ProxyLogon = 9,
        TicketLogon = 10,
        TicketUnlockLogon = 11,
        S4ULogon = 12,
        CertificateLogon = 13,
        CertificateS4ULogon = 14,
        CertificateUnlockLogon = 15,
        NoElevationLogon = 83,
        LuidLogon = 84,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KerberosInteractiveLogon
    {
        public KerbLogonSubmitType SubmitType;
        public LsaString LogonDomainName;
        public LsaString Username;
        public LsaString Password;

        // Workaround to align our string data to 0x8 on x64.
        // Removing this field will make windows deny the serialization in the case of KerbWorkstationUnlockLogon.
        // However Windows accepts un-aligned data in case of KerbInteractiveLogon for some reason.
        private readonly IntPtr alignmentPadding;
    }
}
