namespace TestDataContextBindings.ViewModels
{
    using System.ComponentModel;
    using GalaSoft.MvvmLight;

    internal class ViewModelInfo : ViewModelBase, INotifyPropertyChanged, IPage
    {
        void IPage.Init()
        {
        }
    }
}
