namespace TestHierarchyModels.Views.UserControls
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using TestHierarchyModels.ViewModels;

    public partial class UserControl2 : UserControl
    {         
        public UserControl2()
        {
            InitializeComponent();
            DataContext = new ViewModel2();
        }
    }
}
