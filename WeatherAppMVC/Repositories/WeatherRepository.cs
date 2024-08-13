using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherAppMVC.Models;

namespace WeatherAppMVC.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m"; // Replace with your actual API key

        public WeatherRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherAsync(string cityName)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(jsonResponse);
            }
            return null;
        }
    }
}
