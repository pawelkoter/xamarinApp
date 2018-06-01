using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using PamoApp.Models;
using PamoApp.Services;
using Xamarin.Forms;

namespace PamoApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public bool UseDarkTheme { get; set; }

        public IList<ColorModel> Colors { get; set; }

        public ICommand SaveColorCommand { get; private set; }
        public int ColorSelectedIndex { get; set; }

        public SettingsViewModel()
        {
            Title = "Ustawienia";

            if (Application.Current.Properties.ContainsKey(Constants.UseDarkThemeProperty))
            {
                UseDarkTheme = (bool)Application.Current.Properties[Constants.UseDarkThemeProperty];
            }

            SaveColorCommand = new Command(SaveColor);

            Colors = new List<ColorModel>
            {
                new ColorModel(nameof(Color.BlueViolet), Color.BlueViolet),
                new ColorModel(nameof(Color.Coral),Color.Coral),
                new ColorModel(nameof(Color.DarkOrange),Color.DarkOrange),
                new ColorModel(nameof(Color.Gold),Color.Gold)
            };
        }

        private readonly IFileHelper _fileHelper = new FileHelper();

        private async void SaveColor()
        {
            var color = Colors[ColorSelectedIndex];

            var json = JsonConvert.SerializeObject(color);

            await _fileHelper.WriteTextAsync(Constants.ColorFile, json);

            var themeService = new ThemeService();
            themeService.ChangeTheme(UseDarkTheme);
        }
    }
}