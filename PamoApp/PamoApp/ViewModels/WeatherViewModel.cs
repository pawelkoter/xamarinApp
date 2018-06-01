using System.Collections.Generic;
using System.Windows.Input;
using PamoApp.Models;
using PamoApp.Services;
using Xamarin.Forms;

namespace PamoApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    { 
        public WeatherData WeatherData { get; private set; }

        public IList<City> Cities { get; set; }

        public int CitiesSelectedIndex { get; set; }

        public ICommand GetWeatherDataCommand { get; private set; }

        public WeatherViewModel()
        {
            Title = "Pogoda";

            WeatherData = new WeatherData();

            GetWeatherDataCommand = new Command(GetWeatherData);

            Cities = new List<City>
            {
                new City {Id = 6695624, Name ="Warszawa"},
                new City {Id = 3099434, Name ="Gdańsk"},
                new City {Id = 3094802, Name ="Kraków"},
                new City {Id = 3081368, Name ="Wrocław"},
                new City {Id = 3088171, Name ="Poznań"},
                new City {Id = 3093133, Name ="Łódź"},
                new City {Id = 3096472, Name ="Katowice"},
            };
        }

        private readonly IWeatherService _weatherService = new WeatherServiceWithCaching();

        private async void GetWeatherData()
        {
            var city = Cities[CitiesSelectedIndex];
            var data = await _weatherService.GetWeatherDataAsync(city.Id);

            WeatherData = data;

            OnPropertyChanged(nameof(WeatherData));
        }
    }
}