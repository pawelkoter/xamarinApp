using System;
using System.Threading.Tasks;
using Windows.Storage;
using PamoApp.Services;
using PamoApp.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper_UWP))]
namespace PamoApp.UWP
{
    public class FileHelper_UWP : IFileHelper
    {
        public async Task WriteTextAsync(string filename, string text)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            IStorageFile storageFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, text);
        }

        public async Task<string> ReadTextAsync(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            IStorageFile storageFile = await localFolder.GetFileAsync(filename);
            return await FileIO.ReadTextAsync(storageFile);
        }

        public async Task<bool> ExistsAsync(string filename)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                await localFolder.GetFileAsync(filename);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}