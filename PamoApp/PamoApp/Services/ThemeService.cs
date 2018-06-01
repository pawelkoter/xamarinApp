using System;
using Newtonsoft.Json;
using PamoApp.Models;
using Xamarin.Forms;

namespace PamoApp.Services
{
    public class ThemeService : IThemeService
    {
        public async void ChangeTheme(bool useDarkTheme)
        {
            if (useDarkTheme)
            {
                var primaryColor = Color.FromHex("33302E");

                var fileHelper = new FileHelper();
                var overrideDefaultDarkTheme = await fileHelper.ExistsAsync(Constants.ColorFile);
                if (overrideDefaultDarkTheme)
                {
                    try
                    {
                        var json = await fileHelper.ReadTextAsync(Constants.ColorFile);
                        var color = JsonConvert.DeserializeObject<ColorModel>(json);

                        primaryColor = new Color(color.Red, color.Green, color.Blue);
                    }
                    catch (Exception e)
                    {
                        //well 
                    }
                }

                Application.Current.Resources["Primary"] = primaryColor;
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