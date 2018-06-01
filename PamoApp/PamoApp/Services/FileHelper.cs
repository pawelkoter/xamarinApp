using System.Threading.Tasks;
using Xamarin.Forms;

namespace PamoApp.Services
{
    public class FileHelper : IFileHelper
    {
        private readonly IFileHelper _fileHelper = DependencyService.Get<IFileHelper>();

        public Task WriteTextAsync(string filename, string text)
        {
            return _fileHelper.WriteTextAsync(filename, text);
        }

        public Task<string> ReadTextAsync(string filename)
        {
            return _fileHelper.ReadTextAsync(filename);
        }

        public Task<bool> ExistsAsync(string filename)
        {
            return _fileHelper.ExistsAsync(filename);
        }
    }
}