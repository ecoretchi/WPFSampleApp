namespace TrulyMvvm.ViewModels
{
    using System.Windows;
    using GalaSoft.MvvmLight;
    using System.ComponentModel;

    public interface IPage
    {
        string Title { get; }
    }

    public abstract class PqgeViewModelBase : ViewModelBase, IPage
    {
        public PqgeViewModelBase(string title)
        {
            Title = title;
            if (!IsInDesignMode)
            {
                // runtime only code here...
                Title += " is alive!";
            }
        }

        public string Title { get; }
    }

    public class Page1ViewModel : PqgeViewModelBase
    {
        // Add page specific code here....
        public Page1ViewModel() : base(nameof(Page1ViewModel))
        {
        }
    }

    public class Page2ViewModel : PqgeViewModelBase
    {
        // Add page specific code here....
        public Page2ViewModel() : base(nameof(Page2ViewModel))
        {
        }
    }
}
