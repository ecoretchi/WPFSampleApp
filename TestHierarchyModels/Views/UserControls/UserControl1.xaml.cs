namespace TestHierarchyModels.Views.UserControls
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using TestHierarchyModels.ViewModels;

    public partial class UserControl1 : UserControl
    {           
        string InfoText { get; set; } = string.Empty;

        public UserControl1()
        {
            InitializeComponent();
            DataContext = new ViewModel1();
            
        }
    }
}
