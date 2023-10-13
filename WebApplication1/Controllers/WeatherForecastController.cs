using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using ZXing.Common;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

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
        private IHostingEnvironment _hostingEnvironment;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;   
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        ////}
        //[HttpPost(Name = "GetWeatherForecastqqq")]
        //public IActionResult GenerateBarcode(string text)
        //{

        //    //var writer = new ZXing.Windows.Compatibility.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };


        //    ZXing.Windows.Compatibility.BarcodeWriter barcodeWriter = new ZXing.Windows.Compatibility.BarcodeWriter
        //    {
        //        Format = BarcodeFormat.CODE_128, // Specify the barcode format you want to generate
        //        Options = new EncodingOptions
        //        {
        //            Height = 200, // Specify the height of the barcode image
        //            Width = 400 ,
        //            // Specify the width of the barcode image,
        //        }
        //    };

        //    Bitmap barcodeBitmap = barcodeWriter.Write(text); // Generate the barcode image

        //    MemoryStream stream = new MemoryStream();
        //    barcodeBitmap.Save(stream, ImageFormat.Png); // Save the barcode image to a stream

        //    return File(stream.ToArray(), "image/png"); // Return the barcode image as a file
        //}



        //}
        
        [HttpGet(Name = "GetWeatherForecastqqq")]
       // public IActionResult PrintLabel([FromBody] TheProduct product)
       public IActionResult PrintLabel(string  productId)
        {

            string string64 = GetBarCodeIStream(productId);
            var path = Path.Combine(_hostingEnvironment.ContentRootPath, "Reports", "Report1.rdlc");

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                LocalReport locareport = new();
                locareport.LoadReportDefinition(stream);
                locareport.EnableExternalImages = true;

                ReportParameterCollection reportParameters = new();
                reportParameters.Add(new ReportParameter("ProductId", productId));
                reportParameters.Add(new ReportParameter("BarCodeImg", string64,true));
                locareport.SetParameters(reportParameters);
                //var result = locareport.Render("PDF");
                var result = locareport.Render("IMAGE");
                return File(result, "image/png", "PrintOut.png");

                //* return File(result, "application/pdf", "PrintOut.pdf");
                //•	"IMAGE"
                //•	"WORD"/
                //•	"EXCEL"
                //•	"CSV"
                //•	"XML"
                //•	"HTML4.0"
                //•	"HTML3.2"
                //•	"MHTML" *//* }
               // return File(result, "application/pdf", "PrintOut.pdf");
            }


        }








        private static string GetBarCodeIStream(string text)
        {
            ZXing.Windows.Compatibility.BarcodeWriter barcodeWriter = new ZXing.Windows.Compatibility.BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128, // Specify the barcode format you want to generate
                Options = new EncodingOptions
                {
                    Height = 200, // Specify the height of the barcode image
                    Width = 400,
                    // Specify the width of the barcode image,
                }
            };

            Bitmap barcodeBitmap = barcodeWriter.Write(text); // Generate the barcode image

            MemoryStream stream = new MemoryStream();
            barcodeBitmap.Save(stream, ImageFormat.Png); // Save the barcode image to a stream

            // return File(stream.ToArray(), "image/png"); // Return the barcode image as a file
            var byteArray = stream.ToArray();
            // return byteArray;
            return Convert.ToBase64String(byteArray);
          
        }
    }
}
