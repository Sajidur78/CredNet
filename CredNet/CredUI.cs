using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
            /// No flags
            /// </summary>
            None = 0x00000000,

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

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CREDUI_INFO
        {
            public int cbSize;
            public IntPtr hwndParent;
            public string pszMessageText;
            public string pszCaptionText;
            public IntPtr hbmBanner;
        }


        [DllImport("credui.dll", CharSet = CharSet.Unicode)]
        internal static extern uint CredUIPromptForWindowsCredentials(ref CREDUI_INFO notUsedHere,
            uint authError,
            ref uint authPackage,
            IntPtr inAuthBuffer,
            uint inAuthBufferSize,
            out IntPtr refOutAuthBuffer,
            out uint refOutAuthBufferSize,
            ref bool fSave,
            Flags flags);

        public static CredUIResult Prompt()
        {
            return Prompt(Flags.None, 0, false, IntPtr.Zero, string.Empty, string.Empty, 0, null);
        }

        public static CredUIResult Prompt(string caption)
        {
            return Prompt(Flags.None, 0, false, IntPtr.Zero, caption, string.Empty, 0, null);
        }

        public static CredUIResult Prompt(string caption, string message)
        {
            return Prompt(Flags.None, 0, false, IntPtr.Zero, caption, message, 0, null);
        }

        public static CredUIResult Prompt(string caption, string message, Bitmap banner)
        {
            return Prompt(Flags.None, 0, false, IntPtr.Zero, caption, message, 0, banner);
        }

        public static CredUIResult Prompt(string caption, string message, Bitmap banner, Flags flags)
        {
            return Prompt(flags, 0, false, IntPtr.Zero, caption, message, 0, banner);
        }

        public static CredUIResult Prompt(string caption, string message, Bitmap banner, Flags flags, uint authPackage)
        {
            return Prompt(flags, authPackage, false, IntPtr.Zero, caption, message, 0, banner);
        }

        public static CredUIResult Prompt(string caption, string message, Bitmap banner, Flags flags, uint authPackage, bool save)
        {
            return Prompt(flags, authPackage, save, IntPtr.Zero, caption, message, 0, banner);
        }

        public static CredUIResult Prompt(string caption, string message, Bitmap banner, Flags flags, uint authPackage, bool save, IntPtr hWndParent)
        {
            return Prompt(flags, authPackage, save, hWndParent, caption, message, 0, banner);
        }

        public static CredUIResult Prompt(string caption, string message, Bitmap banner, Flags flags, uint authPackage, bool save, IntPtr hWndParent, uint authError)
        {
            return Prompt(flags, authPackage, save, hWndParent, caption, message, authError, banner);
        }

        public static CredUIResult Prompt(Flags flags, uint authPackage, bool save, IntPtr parent, string caption, string message, uint authError, Bitmap banner)
        {
            var result = new CredUIResult();
            IntPtr hBanner = IntPtr.Zero;

            if (banner != null)
                hBanner = banner.GetHbitmap();

            var info = new CREDUI_INFO
            {
                cbSize = Marshal.SizeOf<CREDUI_INFO>(), 
                hbmBanner = hBanner, 
                pszCaptionText = caption,
                pszMessageText = message, 
                hwndParent = parent
            };

            var error = CredUIPromptForWindowsCredentials(ref info, authError, ref authPackage, IntPtr.Zero, 0,
                out IntPtr authBuf, out uint authBufSize, ref save, flags);

            result.Success = error == 0;

            if (result.Success)
            {
                result.AuthPackage = authPackage;
                result.Save = save;

                if (authBufSize != 0)
                {
                    unsafe
                    {
                        result.AuthBuffer = new byte[authBufSize];

                        fixed (byte* destination = result.AuthBuffer)
                            Unsafe.CopyBlock(destination, authBuf.ToPointer(), authBufSize);
                    }
                }
            }

            if (hBanner != IntPtr.Zero)
                Native.DeleteObject(hBanner);

            return result;
        }
    }

    // ReSharper disable once InconsistentNaming
    public struct CredUIResult
    {
        public bool Success;
        public byte[] AuthBuffer;
        public bool Save;
        public uint AuthPackage;
    }
}
