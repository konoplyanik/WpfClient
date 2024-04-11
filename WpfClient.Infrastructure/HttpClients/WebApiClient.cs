using System.Text;
using System.Text.Json;
using WpfClient.Infrastructure.Model;

namespace WpfClient.Infrastructure.HttpClients;

public class WebApiClient : IWebApiClient
{
    private readonly HttpClient _httpClient;

    public WebApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task UploadImageTextDataAsync(ImageTextDto data)
    {
        // Implement the upload logic using the _httpClient
        var apiUrl = "https://localhost:7048/ImageText/save-image";

        using (var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"))
        {
            var response = await _httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }

    public async Task<List<ImageTextDto>> GetImageTextDataAsync()
    {
        // Implement the get logic using the _httpClient
        var apiUrl = "https://localhost:7048/ImageText/get-images";
        var response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<ImageTextDto>>(jsonString);
    }
}