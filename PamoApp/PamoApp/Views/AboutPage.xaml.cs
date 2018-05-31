using PamoApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PamoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{

        public AboutPage ()
		{
			InitializeComponent ();

            if (Application.Current.Properties.ContainsKey(Constants.UseDarkThemeProperty))
            {
                ThemeSwitch.IsToggled = (bool) Application.Current.Properties[Constants.UseDarkThemeProperty];
            }
        }

	    public async void OnThemeSwitchToggled(object sender, ToggledEventArgs toggledEventArgs)
	    {

            var themeSwith = (Switch)sender;

	        var useDarkTheme = themeSwith.IsToggled;

	        var themeService = new ThemeService();
            themeService.ChangeTheme(useDarkTheme);

	        Application.Current.Properties[Constants.UseDarkThemeProperty] = useDarkTheme;
            
	        await Application.Current.SavePropertiesAsync();
        }
	}
}