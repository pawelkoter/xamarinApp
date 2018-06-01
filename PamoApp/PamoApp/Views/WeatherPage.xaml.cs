using PamoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PamoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WeatherPage : ContentPage
	{
		public WeatherPage ()
		{
			InitializeComponent ();
		    BindingContext = new WeatherViewModel();
		}
    }
}