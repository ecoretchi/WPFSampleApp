﻿namespace TestDataContextBindings.Views.UserControls
{
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using TestDataContextBindings.ViewModels;

    public partial class UserControl2 : UserControl
    {

        string? DataContextName => (DataContext == null) ? "null" : DataContext.GetType().Name;
            
        public UserControl2()
        {
            InitializeComponent();
            LbInfo.Content = $"UserControl2 constructor: DataContext is {DataContextName}";
        }

        void OnBtnClick(object sender, RoutedEventArgs e)
        {
            LbInfo.Content = $"DataContext is {DataContextName}";
            var vm = DataContext as ViewModel2;
            if (vm != null)
            {
                vm.OnButtonClicked();
            }
        }
    }
}
