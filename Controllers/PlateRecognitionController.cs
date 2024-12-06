using LicensePlateRecognizer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LicensePlateRecognizer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlateRecognitionController : ControllerBase
{
    private readonly PlateRecognizerService _plateRecognizerService;

    public PlateRecognitionController(PlateRecognizerService plateRecognizerService)
    {
        _plateRecognizerService = plateRecognizerService;
    }

    [HttpPost("recognizelicenseplate")]
    public async Task<IActionResult> RecognizePlate(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var filePath = Path.GetTempFileName();
        using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        var result = await _plateRecognizerService.RecognizePlateAsync(filePath);
        System.IO.File.Delete(filePath);

        return Ok(result);
    }
}
