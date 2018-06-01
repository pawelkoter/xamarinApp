using Xamarin.Forms;

namespace PamoApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public bool UseDarkTheme { get; set; }

        public SettingsViewModel()
        {
            Title = "Ustawienia";

            if (Application.Current.Properties.ContainsKey(Constants.UseDarkThemeProperty))
            {
                UseDarkTheme = (bool)Application.Current.Properties[Constants.UseDarkThemeProperty];
            }
        }
    }
}