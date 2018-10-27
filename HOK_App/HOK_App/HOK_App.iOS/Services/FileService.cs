using System;
using System.IO;
using Foundation;
using HOK_App.Services;

namespace HOK_App.iOS.Services
{
    public class FileService : IFileService
    {
        public bool AssetExists(string fileName)
        {
            var path = Path.Combine(NSBundle.MainBundle.ResourcePath, fileName);
            return File.Exists(path);
        }

        public void MoveAsset(string fileName, string destinationPath)
        {
            var path = Path.Combine(NSBundle.MainBundle.ResourcePath, fileName);
            File.Move(path, destinationPath);
        }
    }
}
