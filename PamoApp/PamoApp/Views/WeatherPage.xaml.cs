using System;
using PamoApp.Services;
using PamoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PamoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
//        private readonly IWeatherService _weatherService = new WeatherService();


		public WeatherPage ()
		{
			InitializeComponent ();
		    BindingContext = new WeatherViewModel();
		}

//	    async void OnPickerSelectedIndexChanged(object sender, EventArgs eventArgs)
//	    {
//	        var picker = (Picker)sender;
//
//	        if (picker.SelectedIndex == -1)
//	        {
//	            CityLabel.Text = "Miasto: ";
//	        }
//	        else
//	        {
//	            var weatherData = await _weatherService.GetWeatherDataAsync(3099434);
//
//	            var city = weatherData.City;
//
//                CityLabel.Text = $"Miasto: {city}";
//            }
//        }

    }
}