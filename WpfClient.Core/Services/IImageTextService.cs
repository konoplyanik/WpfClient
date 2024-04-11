using WpfClient.Core.Models;

namespace WpfClient.Core.Services;

public interface IImageTextService
{
    Task UploadImageTextDataAsync(ImageTextData data);
    Task<List<ImageTextData>> GetImageTextDataAsync();
}
