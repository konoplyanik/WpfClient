using WpfClient.Infrastructure.Model;

namespace WpfClient.Infrastructure.Repositories;

public interface IImageTextRepository
{
    Task UploadImageTextDataAsync(ImageTextDto data);
    Task<List<ImageTextDto>> GetImageTextDataAsync();
}
