using System.Windows;
using WpfClient.ViewModels;

namespace WpfClient;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();

        DataContext = _viewModel;
    }
}