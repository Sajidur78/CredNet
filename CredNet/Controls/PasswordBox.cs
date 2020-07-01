using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public class PasswordBox : FieldControl, IStringControl
    {
        private string mValue;
        private FieldOptions mOptions;

        public override FieldType GetFieldType() =>
            FieldType.PasswordText;

        public string Value
        {
            get => mValue;
            set
            {
                mValue = value;
                PerformCredentialOperation(events => events.SetFieldString(Credential.InternalCredential, ID, mValue));

                OnPropertyChanged();
            }
        }

        public FieldOptions Options
        {
            get => mOptions;
            set
            {
                mOptions = value;
                OnPropertyChanged();
            }
        }
    }
}
