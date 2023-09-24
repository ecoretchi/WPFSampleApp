namespace TestDataContextBindings.ViewModels
{
    using System.ComponentModel;
    using GalaSoft.MvvmLight;


    internal class ViewModel1 : ViewModelBase, INotifyPropertyChanged, IJobs, IPage
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

        string IJobs.DoJob()
        {
            BindingInfo = $"{ClassName}.DoJob() is called.";
            RaisePropertyChanged(nameof(BindingInfo));

            return $"done job from {ClassName}";
        }

        void IPage.Init()
        {
            BindingInfo = $"This view binded to Model1";
            IsBtnVisible = true;
        }
    }
}
