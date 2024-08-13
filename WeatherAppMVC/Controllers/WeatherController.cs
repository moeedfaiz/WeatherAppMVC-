using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAppMVC.Services;

namespace WeatherAppMVC.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery] double latitude, [FromQuery] double longitude)
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(latitude, longitude);
            if (weatherData == null)
            {
                return NotFound(new { Message = "Weather data not found for the provided location." });
            }

            // Debugging: Check if hourly data is null
            if (weatherData.hourly == null || weatherData.hourly.Temperature_2m == null || weatherData.hourly.Time == null)
            {
                return BadRequest(new { Message = "Incomplete hourly data received." });
            }

            return Ok(weatherData);
        }
    }
}
