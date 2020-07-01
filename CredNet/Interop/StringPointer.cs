using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CredNet.Interop
{
    public unsafe struct StringPointer
    {
        private char* mValue;

        public StringPointer(string value)
        {
            mValue = (char*)Marshal.StringToHGlobalUni(value);
        }

        public void SetValue(string value)
        {
            mValue = (char*)Marshal.StringToHGlobalUni(value);
        }

        public char* GetPointer() => mValue;

        public static implicit operator string(StringPointer value) => new string(value.GetPointer());
        public static implicit operator StringPointer(string value) => new StringPointer(value);
    }
}
