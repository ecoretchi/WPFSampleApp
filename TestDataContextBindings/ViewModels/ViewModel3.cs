﻿namespace TestDataContextBindings.ViewModels
{
    using System.ComponentModel;
    using GalaSoft.MvvmLight;

    internal class ViewModel3 : ViewModelBase, INotifyPropertyChanged, IPage
    {
        public string BindingInfo { get; set; } = "This view binded to Model3";

        public bool IsBtnVisabled { get; set; } = true;

        string ClassName => this.GetType().Name;

        public void OnButtonClicked()
        {
            BindingInfo = $"Info from {ClassName}: DataContext checked done.";
            RaisePropertyChanged(nameof(BindingInfo));

            IsBtnVisabled = false;
            RaisePropertyChanged(nameof(IsBtnVisabled));
        }
    }
}
