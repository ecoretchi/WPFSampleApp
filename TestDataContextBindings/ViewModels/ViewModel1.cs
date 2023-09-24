namespace TestDataContextBindings.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using static System.Reflection.Metadata.BlobBuilder;

    internal class ViewModel1 : ViewModelBase, INotifyPropertyChanged, IJobs
    {

        public string BindingInfo { get; set; } = $"This view binded to Model1";

        public bool IsBtnVisabled { get; set; } = true;

        string ClassName => this.GetType().Name;

        public void OnButtonClicked()
        {
            BindingInfo = $"Info from {ClassName}: DataContext checked done.";
            RaisePropertyChanged(nameof(BindingInfo));

            IsBtnVisabled = false;
            RaisePropertyChanged(nameof(IsBtnVisabled));
        }

        string IJobs.DoJob()
        {
            BindingInfo = $"{ClassName}.DoJob() is called.";
            RaisePropertyChanged(nameof(BindingInfo));

            return $"done job from {ClassName}";
        }
    }
}
