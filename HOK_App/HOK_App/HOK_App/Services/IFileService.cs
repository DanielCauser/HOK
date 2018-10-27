using System;
namespace HOK_App.Services
{
    public interface IFileService
    {
        bool AssetExists(string fileName);
        void MoveAsset(string fileName, string destinationPath);
    }
}
