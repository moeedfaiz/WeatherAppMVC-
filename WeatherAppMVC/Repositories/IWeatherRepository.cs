using System.Threading.Tasks;
using WeatherAppMVC.Models;

namespace WeatherAppMVC.Repositories
{
    public interface IWeatherRepository
    {
        Task<WeatherResponse> GetWeatherAsync(string cityName);
    }
}
