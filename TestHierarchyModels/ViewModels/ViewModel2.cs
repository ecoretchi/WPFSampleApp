namespace TestHierarchyModels.ViewModels
{
    using System.ComponentModel;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    internal class ViewModel2 : ViewModelBase, INotifyPropertyChanged
    {
        string ClassName => this.GetType().Name;

        public string BindingInfo { get; set; } = $"This view binded to ViewModel2";

        public RelayCommand<object> OnButton => new RelayCommand<object>( state =>
        {
            var vm = state as ViewModel;
            if (vm != null )
            {
                vm.BindingInfo = $"Info changed from {ClassName}";
                vm.RaisePropertyChanged(nameof(BindingInfo));
            }
            BindingInfo = $"Info changed from {ClassName}";
            RaisePropertyChanged(nameof(BindingInfo));
        });

    }
}
