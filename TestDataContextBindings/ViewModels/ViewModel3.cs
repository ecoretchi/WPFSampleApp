namespace TestDataContextBindings.ViewModels
{
    using System.ComponentModel;
    using GalaSoft.MvvmLight;

    internal class ViewModel3 : ViewModelBase, INotifyPropertyChanged, IPage
    {
        public string BindingInfo { get; set; } = string.Empty; 

        public bool IsBtnVisible { get; set; } = true;

        string ClassName => this.GetType().Name;

        public void OnButtonClicked()
        {
            BindingInfo = $"Info from {ClassName}: DataContext checked done.";
            RaisePropertyChanged(nameof(BindingInfo));

            IsBtnVisible = false;
            RaisePropertyChanged(nameof(IsBtnVisible));
        }

        void IPage.Init()
        {
            BindingInfo = "This view binded to Model3";
            IsBtnVisible = true;
        }
    }
}
