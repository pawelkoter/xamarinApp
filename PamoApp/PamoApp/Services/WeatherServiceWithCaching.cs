using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PamoApp.Models;

namespace PamoApp.Services
{
    public class WeatherServiceWithCaching : IWeatherService
    {
        private readonly IWeatherService _weatherService = new WeatherService();
        private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions() { });

        public async Task<WeatherData> GetWeatherDataAsync(int cityId)
        {
            if (!_cache.TryGetValue(cityId, out var weatherData))
            {
                weatherData = await _weatherService.GetWeatherDataAsync(cityId);
                _cache.Set(cityId, weatherData, new TimeSpan(0, 10, 0));
            }
            else
            {
                var casted = (WeatherData) weatherData;
                casted.City += " - Jestem z keszu";
            }

            return (WeatherData) weatherData;
        }
    }
}