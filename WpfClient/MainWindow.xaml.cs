using System.Windows;
using WpfClient.ViewModels;

namespace WpfClient;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}