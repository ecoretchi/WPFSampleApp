namespace TestHierarchyModels.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using TestHierarchyModels.Views.UserControls;


    internal class ViewModel : ViewModelBase, INotifyPropertyChanged
    {
        string ClassName => this.GetType().Name;

        public string BindingInfo { get; set; } = $"This view binded to ViewModel";

        public RelayCommand<object> OnButton => new RelayCommand<object>( state =>
        {
            var vm = state as ViewModel1;
            if ( vm != null )
            {
                vm.BindingInfo = $"Info changed from {ClassName}";
                vm.RaisePropertyChanged(nameof(BindingInfo));
            }
            BindingInfo = "OnButton is here";
            RaisePropertyChanged(nameof(BindingInfo));
        });
    }
}
