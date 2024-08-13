using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherAppMVC.Models;

namespace WeatherAppMVC.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherDataAsync(double latitude, double longitude)
        {
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m";
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
