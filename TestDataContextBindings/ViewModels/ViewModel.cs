namespace TestDataContextBindings.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using TestDataContextBindings.Views.UserControls;


    internal class ViewModel : ViewModelBase, INotifyPropertyChanged
    {
        string ClassName => this.GetType().Name;

        private string bindingInfo;
        public string BindingInfo { get => bindingInfo; private set => Set(ref bindingInfo, value); }

        Dictionary<PageNum, Lazy<IPage>> pages = new ()
        {
            { PageNum.PageInfo, new Lazy<IPage> ( () => new ViewModelInfo() ) },
            { PageNum.Page1, new Lazy<IPage> ( () => new ViewModel1() ) },
            { PageNum.Page2, new Lazy<IPage> ( () => new ViewModel2() ) },
            { PageNum.Page3, new Lazy<IPage> ( () => new ViewModel3() ) },
        };

        private IPage content;
        public IPage Content { get => content; private set => Set(ref content, value); }

        public RelayCommand<PageNum> NavigateCommand => new RelayCommand<PageNum>(SetPage);

        public RelayCommand<object> DoSome => new RelayCommand<object>(state =>
        {
            BindingInfo = $"{ClassName}.DoSome RelayCommand is called";
            var jobs = state as IJobs;
            var str = jobs?.DoJob();
            BindingInfo += $"\r\nRelative call, IJobs.DoJob() result: {str}";
        });

        public RelayCommand DoJob => new RelayCommand(() =>
        {
            BindingInfo = $"{ClassName}.DoJob RelayCommand is called.";
        });


        public ViewModel()
        {
            SetPage(PageNum.PageInfo);
        }

        void SetPage(PageNum panelNum)
        {
            Content = pages[panelNum].Value;
            BindingInfo = $"Page changed done. Page now is: {panelNum}";
        }
    }
}
