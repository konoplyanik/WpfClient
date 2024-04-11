using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WpfClient.Infrastructure.Model;

namespace WpfClient.Infrastructure.HttpClients;

public class WebApiClient : IWebApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    public WebApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiUrl = configuration["ApiUrl"];
    }

    public async Task UploadImageTextDataAsync(ImageTextDto data)
    {
        var apiUrl = $"{_apiUrl}/save-image";

        using (var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"))
        {
            var response = await _httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }

    public async Task<List<ImageTextDto>> GetImageTextDataAsync()
    {
        var apiUrl = $"{_apiUrl}/get-images";
        var response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };
        var result = JsonSerializer.Deserialize<List<ImageTextDto>>(jsonString, options);

        return result;
    }
}