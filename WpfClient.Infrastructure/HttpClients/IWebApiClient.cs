using WpfClient.Infrastructure.Model;

namespace WpfClient.Infrastructure.HttpClients
{
    public interface IWebApiClient
    {
        Task UploadImageTextDataAsync(ImageTextDto data);
        Task<List<ImageTextDto>> GetImageTextDataAsync();
    }
}
