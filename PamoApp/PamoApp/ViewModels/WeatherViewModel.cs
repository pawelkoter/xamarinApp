using System;
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

        public ICommand GetWeatherDataCommand { get; private set; }

        public WeatherViewModel()
        {
            WeatherData = new WeatherData();
            GetWeatherDataCommand = new Command(GetWeatherData);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IWeatherService _weatherService = new WeatherService();

        private async void GetWeatherData()
        {
            var data = await _weatherService.GetWeatherDataAsync(3099434);

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