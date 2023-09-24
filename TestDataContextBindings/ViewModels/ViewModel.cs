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

    internal enum PanelNum
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
        string ClassName => this.GetType().Name;

        public string BindingInfo { get; set; } = $"This view binded to ViewModel";

        Dictionary<PanelNum, MyViewPanel> pages = new ()
        {
            { PanelNum.Page1, new MyViewPanel { uc = new UserControl1(), vm = new ViewModel1() } },
            { PanelNum.Page2, new MyViewPanel { uc = new UserControl2(), vm = new ViewModel2() } },
            { PanelNum.Page3, new MyViewPanel { uc = new UserControl3(), vm = new ViewModel3() } }
        };

        public UserControl? Page1 { get; set; }
        public UserControl? Page2 { get; set; }
        public UserControl? Page3 { get; set; }

        public UserControl? MainPage { get; set; }

        public RelayCommand OnM1Button => new RelayCommand(() => SetPage(PanelNum.Page1));

        public RelayCommand OnM2Button => new RelayCommand(() => SetPage(PanelNum.Page2));

        public RelayCommand OnM3Button => new RelayCommand(() => SetPage(PanelNum.Page3));

        public RelayCommand<object> DoSome => new RelayCommand<object>(state =>
        {
            BindingInfo = $"{ClassName}.DoSome RelayCommand is called";
            var jobs = state as IJobs;
            var str = jobs?.DoJob();
            BindingInfo += $"\r\nRelative call, IJobs.DoJob() result: {str}";
            RaisePropertyChanged(nameof(BindingInfo));
        });

        public RelayCommand DoJob => new RelayCommand(() =>
        {
            BindingInfo = $"{ClassName}.DoJob RelayCommand is called.";
            RaisePropertyChanged(nameof(BindingInfo));
        });


        public ViewModel()
        {
            Page1 = GetPanelUC(PanelNum.Page1);
            Page2 = GetPanelUC(PanelNum.Page2);
            Page3 = GetPanelUC(PanelNum.Page3);
        }

        UserControl GetPanelUC(PanelNum page)
        {
            if (pages.TryGetValue(page, out MyViewPanel panel))
            {
                panel.uc.DataContext = panel.vm;
                return panel.uc;
            }
            throw new NotImplementedException();
        }

        void SetPage(PanelNum panelNum)
        {
            MainPage = GetPanelUC(panelNum);
            RaisePropertyChanged(nameof(MainPage));

            BindingInfo = $"Page changed done. Page now is: {panelNum}";
            RaisePropertyChanged(nameof(BindingInfo));
        }
    }
}
