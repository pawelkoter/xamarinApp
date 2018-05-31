using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PamoApp.DataTransfer;
using PamoApp.Models;

namespace PamoApp.Services
{
    public class WeatherService : IWeatherService
    {
        private const string ApiUrl = "http://api.openweathermap.org/data/2.5/weather";
        private const string ApiKey = "6b8e468145e7c5e5f99b5e7d0c5dfc0a";
        private const string Units = "metric";

        public async Task<WeatherData> GetWeatherDataAsync(int cityId)
        {
            var client = new HttpClient
            {
                DefaultRequestHeaders = { Accept = { MediaTypeWithQualityHeaderValue.Parse("applicaiton/json") }}
            };
//            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applicaiton/json"));

            var url = $"{ApiUrl}?appid={ApiKey}&units={Units}&id={cityId}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<WeatherDto>(content);

                return new WeatherData
                {
                    City = dto.Name
                };
            }

            return null;
        }
    }
}