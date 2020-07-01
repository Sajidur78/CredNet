using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public class CommandLink : FieldControl, ICommandLinkControl
    {
        public override FieldType GetFieldType() => FieldType.CommandLink;

        public event EventHandler OnClick;
        
        public void Clicked()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
