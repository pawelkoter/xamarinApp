using Xamarin.Forms;

namespace PamoApp.Services
{
    public class ThemeService : IThemeService
    {
        public void ChangeTheme(bool useDarkTheme)
        {
            if (useDarkTheme)
            {
                Application.Current.Resources["Primary"] = Color.FromHex("33302E");
                Application.Current.Resources["LightTextColor"] = Color.White;
            }
            else
            {
                Application.Current.Resources["Primary"] = Color.FromHex("#2196F3");
                Application.Current.Resources["LightTextColor"] = Color.FromHex("#FAFAFA");
            }
        }
    }
}