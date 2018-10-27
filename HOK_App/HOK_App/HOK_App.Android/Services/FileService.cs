using System;
using System.IO;
using System.Linq;
using HOK_App.Services;

namespace HOK_App.Droid.Services
{
    public class FileService : IFileService
    {
        public bool AssetExists(string syncStoreName)
        {
            var assets = Android.App.Application.Context.Assets;
            var exists = assets.List("").FirstOrDefault(a => a.Equals(syncStoreName)) != null;
            return exists;
        }

        public void MoveAsset(string fileName, string destinationPath)
        {
            var assets = Android.App.Application.Context.Assets;

            using (var binaryReader = new BinaryReader(assets.Open(fileName)))
            using (var binaryWriter = new BinaryWriter(new FileStream(destinationPath, FileMode.Create)))
            {
                var buffer = new byte[2048];
                int length;
                while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    binaryWriter.Write(buffer, 0, length);
                }
            }
        }
    }
}
