using WpfClient.Infrastructure.HttpClients;
using WpfClient.Infrastructure.Model;

namespace WpfClient.Infrastructure.Repositories;

public class ImageTextRepository : IImageTextRepository
{
    private readonly IWebApiClient _webApiClient;

    public ImageTextRepository(IWebApiClient webApiClient)
    {
        _webApiClient = webApiClient;
    }

    public async Task UploadImageTextDataAsync(ImageTextDto data)
    {
        await _webApiClient.UploadImageTextDataAsync(data);
    }

    public async Task<List<ImageTextDto>> GetImageTextDataAsync()
    {
        var result = await _webApiClient.GetImageTextDataAsync();

        return result;
    }
}
