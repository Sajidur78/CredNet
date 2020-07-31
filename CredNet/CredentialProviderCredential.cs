using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CredNet.Controls;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet
{
    public class CredentialProviderCredential : ICredentialProviderCredential2, ICredentialProviderCredentialWithFieldOptions
    {
        internal static Bitmap EmptyBitmap = new Bitmap(1, 1);
        public ICredentialProviderCredentialEvents2 Events { get; internal set; }

        public UserCredential Credential { get; internal set; }
        public CredentialProviderBase Provider { get; }

        public CredentialProviderCredential(UserCredential credential, CredentialProviderBase provider)
        {
            Credential = credential;

            Provider = provider;
            Credential.InternalCredential = this;
            Credential.SetProvider(Provider);
            Credential.RaiseInitializer();
        }

        public int Advise(ICredentialProviderCredentialEvents pcpce)
        {
            Events = (ICredentialProviderCredentialEvents2)pcpce;

            Marshal.AddRef(Marshal.GetIUnknownForObject(Events));
            Credential.CredentialEvents = Events;

            return HRESULT.S_OK;
        }

        public int UnAdvise()
        {
            if (Events != null)
            {
                Marshal.ReleaseComObject(Events);
                Credential.CredentialEvents = null;
                Events = null;
            }

            return HRESULT.S_OK;
        }

        public int SetSelected(out int pbAutoLogon)
        {
            pbAutoLogon = Credential.AutoLogon ? 1 : 0;

            Credential.Selected = true;

            return HRESULT.S_OK;
        }

        public int SetDeselected()
        {
            Credential.Selected = false;

            return HRESULT.S_OK;
        }

        public int GetFieldState(uint dwFieldID, out FieldState pcpfs, out FieldInteractiveState pcpfis)
        {
            pcpfs = FieldState.Hidden;
            pcpfis = FieldInteractiveState.None;

            var control = Globals.GetControlFromID(dwFieldID);
            var isChild = Credential.Controls.Contains(control);

            if (!isChild)
            {
                return HRESULT.S_FALSE;
            }

            if (control != null)
            {
                pcpfs = control.State;
                pcpfis = control.InteractiveState;
                try
                {
                    ((FieldControl) control).Credential = Credential;
                }
                catch { }
            }

            return HRESULT.S_OK;
        }

        public int GetStringValue(uint dwFieldID, out string ppsz)
        {
            ppsz = null;

            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null)
            {
                if (control is IStringControl stringControl)
                    ppsz = stringControl.Value;
                else
                    ppsz = control.Label;
            }

            return HRESULT.S_OK;
        }

        public int GetBitmapValue(uint dwFieldID, out IntPtr phbmp)
        {
            phbmp = IntPtr.Zero;

            var control = Globals.GetControlFromID(dwFieldID);
            var isChild = Credential.Controls.Contains(control);

            if (!isChild)
            {
                return HRESULT.E_FAIL;
            }

            if (control != null && control is ITileImageControl imageControl)
            {
                var color = imageControl.Background;
                phbmp = imageControl.Image?.GetHbitmap(Color.FromArgb(color.A, color.B, color.G, color.R)) ?? EmptyBitmap.GetHbitmap(Color.FromArgb(color.A, color.B, color.G, color.R));
            }

            return HRESULT.S_OK;
        }

        public int GetCheckboxValue(uint dwFieldID, out int pbChecked, out string ppszLabel)
        {
            pbChecked = 0;
            ppszLabel = null;

            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is ICheckboxControl checkboxControl)
            {
                pbChecked = checkboxControl.Checked ? 1 : 0;
                ppszLabel = checkboxControl.Label;
            }

            return HRESULT.S_OK;
        }

        public int GetSubmitButtonValue(uint dwFieldID, out uint pdwAdjacentTo)
        {
            pdwAdjacentTo = 0;
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is ISubmitButtonControl submitButton)
            {
                pdwAdjacentTo = submitButton.AdjacentControl?.ID ?? Credential.Controls.LastOrDefault().ID;
            }

            return HRESULT.S_OK;
        }

        public int GetComboBoxValueCount(uint dwFieldID, out uint pcItems, out uint pdwSelectedItem)
        {
            pcItems = 0;
            pdwSelectedItem = 0;
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is IComboBoxControl comboBoxControl)
            {
                pcItems = (uint)comboBoxControl.Items.Count;
                pdwSelectedItem = comboBoxControl.SelectedItemIndex;
            }

            return HRESULT.S_OK;
        }

        public int GetComboBoxValueAt(uint dwFieldID, uint dwItem, out string ppszItem)
        {
            ppszItem = null;
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is IComboBoxControl comboBoxControl)
            {
                ppszItem = comboBoxControl.Items[(int) dwItem].ToString();
            }

            return HRESULT.S_OK;
        }

        public int SetStringValue(uint dwFieldID, string psz)
        {
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is IStringControl stringControl)
            {
                stringControl.Value = psz;
            }

            return HRESULT.S_OK;
        }

        public int SetCheckboxValue(uint dwFieldID, int bChecked)
        {
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is ICheckboxControl checkboxControl)
            {
                checkboxControl.Checked = bChecked > 0;
            }

            return HRESULT.S_OK;
        }

        public int SetComboBoxSelectedValue(uint dwFieldID, uint dwSelectedItem)
        {
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is IComboBoxControl comboBoxControl)
            {
                comboBoxControl.SelectedItemIndex = dwSelectedItem;

                if (comboBoxControl is IComboBoxInternal internalComboBox)
                {
                    internalComboBox.OnSelectionChanged();
                }
            }

            return HRESULT.S_OK;
        }

        public int CommandLinkClicked(uint dwFieldID)
        {
            var control = Globals.GetControlFromID(dwFieldID);

            if (control != null && control is ICommandLinkControl commandLink)
            {
                commandLink.Clicked();
            }
            
            return HRESULT.S_OK;
        }

        public int GetSerialization(out SerializationResponse pcpgsr,
            out CredentialSerialization pcpcs, out string ppszOptionalStatusText,
            out StatusIcon pcpsiOptionalStatusIcon)
        {
            ppszOptionalStatusText = null;
            pcpsiOptionalStatusIcon = StatusIcon.None;

            var guidAttribute = (GuidAttribute)Provider.GetType().GetCustomAttribute(typeof(GuidAttribute));
            var providerGuid = default(Guid);

            if (guidAttribute != null)
                providerGuid = new Guid(guidAttribute.Value);

            pcpgsr = Credential.GetSerialization(out var serializationData, ref ppszOptionalStatusText, ref pcpsiOptionalStatusIcon);
            IntPtr serialization = IntPtr.Zero;
            uint size = 0;

            if (serializationData != null)
            {
                unsafe
                {
                    size = (uint)serializationData.Length;
                    var logon = (KerberosInteractiveLogon*)Marshal.AllocCoTaskMem((int)size);

                    fixed (byte* data = serializationData)
                    {
                        for (int i = 0; i < serializationData.Length; i++)
                        {
                            *((byte*)logon + i) = data[i];
                        }
                    }

                    serialization = (IntPtr)logon;
                }
            }

            pcpcs = new CredentialSerialization()
            {
                SerializationData = serialization, 
                SerializationSize = size, 
                AuthenticationPackage = Credential.GetAuthenticationPackage(), 
                ProviderClassGuid = providerGuid
            };

            ppszOptionalStatusText = null;
            pcpsiOptionalStatusIcon = StatusIcon.None;
            return HRESULT.S_OK;
        }

        public int ReportResult(int ntsStatus, int ntsSubstatus, out string ppszOptionalStatusText,
            out StatusIcon pcpsiOptionalStatusIcon)
        {
            ppszOptionalStatusText = null;
            pcpsiOptionalStatusIcon = StatusIcon.None;

            if (Credential is IReportResult reportResult)
            {
                try
                {
                    reportResult.ReportResult(ntsStatus, ntsSubstatus, ref ppszOptionalStatusText,
                        ref pcpsiOptionalStatusIcon);
                }
                catch
                {
                    return HRESULT.E_FAIL;
                }
                return HRESULT.S_OK;
            }

            return HRESULT.E_NOTIMPL;
        }

        public int GetUserSid(out string sid)
        {
            try
            {
                sid = Credential.GetUserSid();
                return HRESULT.S_OK;
            }
            catch
            {
                sid = null;
                return HRESULT.E_FAIL;
            }
        }

        public int GetFieldOptions(uint fieldID, out FieldOptions options)
        {
            options = FieldOptions.None;

            var control = Globals.GetControlFromID(fieldID);

            if (control != null && control is IStringControl stringControl)
            {
                options = stringControl.Options;
                return HRESULT.S_OK;
            }

            return HRESULT.E_INVALIDARG;
        }
    }
}
