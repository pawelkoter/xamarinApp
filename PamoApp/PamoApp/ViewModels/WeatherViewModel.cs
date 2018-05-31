using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using PamoApp.Models;
using PamoApp.Services;
using Xamarin.Forms;

namespace PamoApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    { 
        public WeatherData WeatherData { get; private set; }

        public IList<City> Cities { get; set; }
        public int CitiesSelectedIndex { get; set; }

        public ICommand GetWeatherDataCommand { get; private set; }

        public WeatherViewModel()
        {
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

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IWeatherService _weatherService = new WeatherService();

        private async void GetWeatherData()
        {
            var city = Cities[CitiesSelectedIndex];
            var data = await _weatherService.GetWeatherDataAsync(city.Id);

            WeatherData = data;

            OnPropertyChanged("WeatherData");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}