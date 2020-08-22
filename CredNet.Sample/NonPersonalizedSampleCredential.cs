using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CredNet.Controls;
using CredNet.Interop;

namespace CredNet.Sample
{
    public class NonPersonalizedSampleCredential : UserCredential, INotifyPropertyChanged
    {
        private string mPassword;

        public string Password
        {
            get => mPassword;
            set
            {
                mPassword = value;
                OnPropertyChanged();
            }
        }

        public CredentialUser SelectedUser { get; set; }

        public override void Dispose()
        {
            
        }

        protected override void Initialize()
        {
            Controls.Add(new TileBitmap { Image = Properties.Resources.TileIcon, State = FieldState.DisplayInBoth });
            Controls.Add(new SmallLabel { Label = "Non-Personalized Sample Credential" });

            var comboBox = new ComboBox { DataContext = this };

            comboBox.OnSelectionChanged += (sender, args) => { Password = string.Empty; };

            foreach (var user in Provider.Users)
            {
                comboBox.Items.Add(new CredentialUser(user));
            }

            comboBox.Bindings.Add("SelectedItem", nameof(SelectedUser));
            Controls.Add(comboBox);

            var passwordBox = new PasswordBox { Label = "Password", DataContext = this, Options = FieldOptions.PasswordReveal };
            passwordBox.Bindings.Add("Value", nameof(Password), BindMode.TwoWay);
            Controls.Add(passwordBox);
            Controls.Add(new SubmitButton() { AdjacentControl = passwordBox });
        }

        public override string GetUserSid() => null;

        public override uint GetAuthenticationPackage() => SampleCredentialProvider.NegotiateAuthPackage;

        public override SerializationResponse GetSerialization(out byte[] serialization, ref string optionalStatus,
            ref StatusIcon optionalIcon)
        {
            serialization = CredentialSerializer.SerializeKerbInteractiveLogon(Native.GetComputerName(),
                SelectedUser.User.GetUserName(), Password);

            return SerializationResponse.ReturnCredentialFinished;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CredentialUser
    {
        public ICredentialProviderUser User { get; set; }

        public CredentialUser(ICredentialProviderUser user)
        {
            User = user;
        }

        public override string ToString() => User.GetDisplayName();
    }
}
