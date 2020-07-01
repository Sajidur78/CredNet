using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using CredNet.Interop;

namespace CredNet.Interface
{
    public interface IControl : INotifyPropertyChanged
    {
        uint ID { get; }
        string Label { get; set; }
        FieldState State { get; set; }
        FieldInteractiveState InteractiveState { get; set; }
        
        object DataContext { get; set; }
        DataBindingCollection Bindings { get; }

        FieldType GetFieldType();

        FieldDescriptor GetFieldDescriptor();
    }

    public interface IStringControl : IControl
    {
        string Value { get; set; }
        FieldOptions Options { get; set; }
    }

    public interface ITileImageControl : IControl
    {
        Bitmap Image { get; set; }
        Color Background { get; set; }
    }

    public interface ICheckboxControl : IControl
    {
        bool Checked { get; set; }
    }

    public interface ISubmitButtonControl : IControl
    {
        IControl AdjacentControl { get; set; }
    }

    public interface IComboBoxControl : IControl
    {
        ObservableCollection<object> Items { get; }
        event EventHandler OnSelectionChanged;
        object SelectedItem { get; }
        uint SelectedItemIndex { get; set; }
    }

    internal interface IComboBoxInternal
    {
        void OnSelectionChanged();
    }

    public interface ICommandLinkControl : IControl
    {
        void Clicked();
    }
}
