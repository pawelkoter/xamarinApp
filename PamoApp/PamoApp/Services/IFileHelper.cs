using System.Threading.Tasks;

namespace PamoApp.Services
{
    public interface IFileHelper
    {
        Task WriteTextAsync(string filename, string text);

        Task<string> ReadTextAsync(string filename);

        Task<bool> ExistsAsync(string filename);
    }
}