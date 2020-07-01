using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Controls;
using CredNet.Interop;

namespace CredNet.Sample
{
    public class PersonalizedSampleCredential : UserCredential
    {
        public ICredentialProviderUser User { get; }

        public string Password { get; set; }

        public PersonalizedSampleCredential(ICredentialProviderUser user)
        {
            User = user;
        }

        protected override void Initialize()
        {
            var passwordBox = new PasswordBox
            {
                Label = "Password",
                DataContext = this,
                Options = FieldOptions.PasswordReveal,
                InteractiveState = FieldInteractiveState.Focused
            }.WithBinding("Value", nameof(Password));
            
            Controls.Add(new TileBitmap { Image = Properties.Resources.TileIcon, State = FieldState.DisplayInDeselectedTile });
            Controls.Add(new SmallLabel { Label = $"Personalized Credential for {User.GetDisplayName()}" });

            Controls.Add(passwordBox);
            Controls.Add(new SubmitButton() { AdjacentControl = passwordBox });
        }

        public override string GetUserSid() => User.GetPrimarySid();

        public override uint GetAuthenticationPackage() => SampleCredentialProvider.NegotiateAuthPackage;

        public override SerializationResponse GetSerialization(out byte[] serialization, ref string optionalStatus,
            ref StatusIcon optionalIcon)
        {
            if (string.IsNullOrEmpty(Password))
            {
                serialization = null;
                optionalStatus = "Invalid password!";
                optionalIcon = StatusIcon.Error;
                return SerializationResponse.NoCredentialNotFinished;
            }

            serialization = CredentialSerializer.SerializeKerbInteractiveLogon(Native.GetComputerName(),
                User.GetUserName(), Password);
            return SerializationResponse.ReturnCredentialFinished;
        }
    }
}
