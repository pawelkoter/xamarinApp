using System.Threading.Tasks;
using PamoApp.Models;

namespace PamoApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherDataAsync(int cityId);
    }
}