using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace SimpleJWTGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IOptions<JWTOptions> _options;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<JWTOptions> options)
        {
            _logger = logger;
            _options = options; 
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get(string username, string password)
        {

            var result = new JWTProvider(_options).GenerateToken(username, password);    
          return Ok(result);
        }

        [Authorize]
        [HttpGet(template :"login", Name = "login")]
        public IActionResult Login()
        {
            var result = "login";
           
            return Ok(result);
        }

        [HttpGet(template: "logout", Name = "logout")]
        public IActionResult Logout()
        {

            var result = "LOGOUT";

            return Ok(result);
        }
    }
}
