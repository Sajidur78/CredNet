using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet
{
    public abstract class UserCredential
    {
        private bool mSelected;
        internal ICredentialProviderCredential InternalCredential { get; set; }
        internal ICredentialProviderCredentialEvents CredentialEvents { get; set; }

        protected CredentialProviderBase Provider { get; private set; }
        
        public ObservableCollection<IControl> Controls { get; set; } = new ObservableCollection<IControl>();

        public event EventHandler OnSelected;
        public event EventHandler OnDeSelected;

        public bool AutoLogon { get; set; }

        public bool Selected
        {
            get => mSelected;
            internal set
            {
                mSelected = value;
                
                if (value && OnSelected != null)
                    OnSelected(this, EventArgs.Empty);
                else if (!value && OnDeSelected != null)
                    OnDeSelected(this, EventArgs.Empty);
            }
        }

        public abstract string GetUserSid();

        public abstract uint GetAuthenticationPackage();

        public abstract SerializationResponse GetSerialization(out byte[] serialization, ref string optionalStatus, ref StatusIcon optionalIcon);

        protected abstract void Initialize();

        public void CreateWindow(out IntPtr handle)
        {
            CredentialEvents.OnCreatingWindow(out handle);
        }

        public IntPtr CreateWindow()
        {
            CredentialEvents.OnCreatingWindow(out var handle);
            return handle;
        }

        internal void SetProvider(CredentialProviderBase provider) => Provider = provider;
        internal void RaiseInitializer() => Initialize();
    }
}
