using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;
using CredNet.Interop;

namespace CredNet.Controls
{
    public class ComboBox : FieldControl, IComboBoxControl, IComboBoxInternal
    {
        private uint mSelectedItemIndex;

        public override FieldType GetFieldType() => FieldType.ComboBox;

        public ObservableCollection<object> Items { get; } = new ObservableCollection<object>();
        public event EventHandler OnSelectionChanged;

        public object SelectedItem
        {
            get
            {
                if (mSelectedItemIndex >= Items.Count)
                    return null;

                return Items[(int) SelectedItemIndex];
            }
        }

        public uint SelectedItemIndex
        {
            get => mSelectedItemIndex;
            set
            {
                mSelectedItemIndex = value;

                PerformCredentialOperation(events =>
                    events.SetFieldComboBoxSelectedItem(Credential.InternalCredential, ID, SelectedItemIndex));

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ComboBox()
        {
            Items.CollectionChanged += ItemsOnCollectionChanged;
        }

        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    PerformCredentialOperation(events => events.AppendFieldComboBoxItem(Credential.InternalCredential, ID, e.NewItems[0].ToString()));
                    break;

                case NotifyCollectionChangedAction.Remove:
                    PerformCredentialOperation(events => events.DeleteFieldComboBoxItem(Credential.InternalCredential, ID, (uint)e.OldStartingIndex));
                    break;

                case NotifyCollectionChangedAction.Reset:
                    PerformCredentialOperation(events =>
                    {
                        for (int i = e.OldItems.Count - 1; i >= 0; i--)
                        {
                            events.DeleteFieldComboBoxItem(Credential.InternalCredential, ID, (uint)i);
                        }
                    });
                    break;
            }
        }

        void IComboBoxInternal.OnSelectionChanged()
        {
            OnSelectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
