using System;
using System.Threading.Tasks;
namespace HOK_App.Services
{
    public interface IAudioService
    {
        Task Play(string url, Action<string, double> updatePlayerStatus);
        void Pause();
    }
}
