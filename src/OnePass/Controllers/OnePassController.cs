using Microsoft.AspNetCore.Mvc;
using OnePass.Core.Services.Interface;
using OnePass.Repository.Interfaces;

namespace OnePass.Controllers
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
        private readonly IOnePassServices _onePassServices;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOnePassServices onePassServices)
        {
            _logger = logger; 
            _onePassServices = onePassServices;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<bool> Get()
        {

            await _onePassServices.connectDB();


            return true;
        }
    }
}