using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public class SubmitButton : FieldControl, ISubmitButtonControl
    {
        private IControl mAdjacentControl;

        public override FieldType GetFieldType() => FieldType.Submit;

        public IControl AdjacentControl
        {
            get => mAdjacentControl;
            set
            {
                mAdjacentControl = value;
                PerformCredentialOperation(events => events.SetFieldSubmitButton(Credential.InternalCredential, ID, mAdjacentControl.ID));

                OnPropertyChanged();
            }
        }
    }
}
