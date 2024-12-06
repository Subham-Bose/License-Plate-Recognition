using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace LicensePlateRecognizer.Services;

public class PlateRecognizerService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public PlateRecognizerService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    public async Task<string> RecognizePlateAsync(string imagePath)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.platerecognizer.com/v1/plate-reader/");
        request.Headers.Authorization = new AuthenticationHeaderValue("Token", _apiKey);

        var form = new MultipartFormDataContent();
        var imageContent = new ByteArrayContent(await File.ReadAllBytesAsync(imagePath));
        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
        form.Add(imageContent, "upload", "image.jpg");

        request.Content = form;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        return jsonResponse;
    }
}
