namespace TrulyMvvm.ViewModels
{
    using System;
    using System.Collections.Generic;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    public class MainViewModel : ViewModelBase
    {
        private IPage content;
        public IPage Content { get => content; private set => Set(ref content, value); }

        public RelayCommand<int> NavigateCommand => new RelayCommand<int>(Navigate);

        private readonly Dictionary<int, Lazy<IPage>> pages
            = new Dictionary<int, Lazy<IPage>>
            {
                [1] = new Lazy<IPage>(() => new Page1ViewModel()),
                [2] = new Lazy<IPage>(() => new Page2ViewModel())
            };

        public MainViewModel()
        {
            Navigate(1);
        }

        private void Navigate(int value) => Content = pages[value].Value;
    }
}
