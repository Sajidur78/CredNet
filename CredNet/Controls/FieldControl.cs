using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public abstract class FieldControl : IControl
    {
        private string mLabel;
        private FieldState mState = FieldState.DisplayInSelectedTile;
        private FieldInteractiveState mInteractiveState = FieldInteractiveState.None;

        public event PropertyChangedEventHandler PropertyChanged;

        public uint ID => Globals.GetControlID(this);

        public string Label
        {
            get => mLabel;
            set
            {
                mLabel = value;
                PerformCredentialOperation(events =>
                    {
                        events.SetFieldString(Credential.InternalCredential, ID, mLabel);
                    });

                OnPropertyChanged();
            }
        }

        public FieldState State
        {
            get => mState;
            set
            {
                mState = value;
                PerformCredentialOperation(events => events.SetFieldState(Credential.InternalCredential, ID, mState));

                OnPropertyChanged();
            }
        }

        public FieldInteractiveState InteractiveState
        {
            get => mInteractiveState;
            set
            {
                mInteractiveState = value;
                PerformCredentialOperation(events => events.SetFieldInteractiveState(Credential.InternalCredential, ID, mInteractiveState));

                OnPropertyChanged();
            }
        }

        public object DataContext
        {
            get => Bindings.DataContext;
            set => Bindings.DataContext = value;
        }

        public DataBindingCollection Bindings { get; }

        public UserCredential Credential { get; internal set; }

        public abstract FieldType GetFieldType();
        
        public FieldDescriptor GetFieldDescriptor()
        {
            return new FieldDescriptor()
            {
                FieldID = ID, FieldType = GetFieldType(),
                Label = Label, FieldTypeGuid = default(Guid)
            };
        }

        protected FieldControl()
        {
            Bindings = new DataBindingCollection(this);
        }

        public FieldControl WithDataContext(object context)
        {
            DataContext = context;
            return this;
        }

        public FieldControl WithBinding(string sourceProperty, string destinationProperty, BindMode mode = BindMode.OneWay)
        {
            Bindings.Add(sourceProperty, destinationProperty, mode);
            return this;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void PerformCredentialOperation(Action<ICredentialProviderCredentialEvents> action)
        {
            if (Credential?.CredentialEvents != null)
            {
                action(Credential.CredentialEvents);
            }
        }
    }
}
