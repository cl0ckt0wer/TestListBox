using Avalonia.Controls;
using Avalonia.ReactiveUI;
using TestListBox.ViewModels;

namespace TestListBox.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
