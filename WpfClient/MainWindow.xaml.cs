using System.Net.Http;
using System.Windows;
using WpfClient.Core.Services;
using WpfClient.Infrastructure.HttpClients;
using WpfClient.Infrastructure.Repositories;
using WpfClient.ViewModels;

namespace WpfClient;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();

        var webApiClient = new WebApiClient(new HttpClient());
        var imageTextRepository = new ImageTextRepository(webApiClient);
        var mapper = MapperInitializer.Initialize();
        var imageTextService = new ImageTextService(imageTextRepository, mapper);

        _viewModel = new MainWindowViewModel(imageTextService);

        DataContext = _viewModel;
    }
}