﻿namespace TestDataContextBindings.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using TestDataContextBindings.Views.UserControls;

    internal enum PageNum
    {
        Page1,
        Page2,
        Page3
    }

    internal struct MyViewPanel
    {
        internal UserControl uc;
        internal ViewModelBase vm;
    }

    internal class ViewModel : ViewModelBase, INotifyPropertyChanged
    {

        public string BindingInfo { get; set; } = $"This view binded to ViewModel";

        Dictionary<PageNum, MyViewPanel> pages = new ()
        {
            { PageNum.Page1, new MyViewPanel { uc = new UserControl1(), vm = new ViewModel1() } },
            { PageNum.Page2, new MyViewPanel { uc = new UserControl2(), vm = new ViewModel2() } },
            { PageNum.Page3, new MyViewPanel { uc = new UserControl3(), vm = new ViewModel3() } }
        };

        public UserControl? MainPage { get; set; }

        public RelayCommand OnM1Button => new RelayCommand(() => SetPage(PageNum.Page1));

        public RelayCommand OnM2Button => new RelayCommand(() => SetPage(PageNum.Page2));

        public RelayCommand OnM3Button => new RelayCommand(() => SetPage(PageNum.Page3));

        public RelayCommand<object> DoSome => new RelayCommand<object>(state =>
        {
            var jobs = state as IJobs;
            var str = jobs?.DoJob();
            BindingInfo = $"Do some ... {str}";
            RaisePropertyChanged(nameof(BindingInfo));
        });


        public ViewModel()
        {
            SetPage(PageNum.Page1);
        }

        void SetPage(PageNum page)
        {
            if (pages.TryGetValue(page, out MyViewPanel panel))
            {
                MainPage = panel.uc;
                MainPage.DataContext = panel.vm;
                RaisePropertyChanged(nameof(MainPage));
            }
        }
    }
}
