using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost(Name = "GetWeatherForecastqqq")]
        public IActionResult GenerateBarcode(string text)
        {

            //var writer = new ZXing.Windows.Compatibility.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };


            ZXing.Windows.Compatibility.BarcodeWriter barcodeWriter = new ZXing.Windows.Compatibility.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128, // Specify the barcode format you want to generate
                Options = new EncodingOptions
                {
                    Height = 200, // Specify the height of the barcode image
                    Width = 400 // Specify the width of the barcode image
                }
            };

            Bitmap barcodeBitmap = barcodeWriter.Write(text); // Generate the barcode image

            MemoryStream stream = new MemoryStream();
            barcodeBitmap.Save(stream, ImageFormat.Png); // Save the barcode image to a stream

            return File(stream.ToArray(), "image/png"); // Return the barcode image as a file
        }
    }
}
