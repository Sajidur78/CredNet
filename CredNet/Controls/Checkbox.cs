using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public class Checkbox : FieldControl, ICheckboxControl
    {
        private bool mChecked;

        public override FieldType GetFieldType() => FieldType.CheckBox;

        public bool Checked
        {
            get => mChecked;
            set
            {
                mChecked = value;
                PerformCredentialOperation(events => events.SetFieldCheckbox(Credential.InternalCredential, ID, mChecked ? 1 : 0, Label));

                OnPropertyChanged();
            }
        }
    }
}
