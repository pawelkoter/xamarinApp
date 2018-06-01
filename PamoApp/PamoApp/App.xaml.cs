using PamoApp.Services;
using PamoApp.Views;
using Xamarin.Forms;

namespace PamoApp
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();


            MainPage = new MainPage();
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            
		    // check last theme used
            var useDarkTheme = false;
		    if (Application.Current.Properties.ContainsKey(Constants.UseDarkThemeProperty))
		    {
		        useDarkTheme = (bool)Application.Current.Properties[Constants.UseDarkThemeProperty];
		    }

		    var themeService = new ThemeService();
            themeService.ChangeTheme(useDarkTheme);
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
