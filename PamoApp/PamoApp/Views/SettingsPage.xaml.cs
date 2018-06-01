using PamoApp.Services;
using PamoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PamoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        public SettingsPage ()
		{
			InitializeComponent();

		    BindingContext = new SettingsViewModel();
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