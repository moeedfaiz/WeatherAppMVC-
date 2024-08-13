using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherAppMVC.Services;
using WeatherAppMVC.Models;

namespace WeatherAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;

        public HomeController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetWeather(double latitude, double longitude)
        {
            WeatherResponse weatherData = await _weatherService.GetWeatherDataAsync(latitude, longitude);
            return View("Index", weatherData);
        }
    }
}
