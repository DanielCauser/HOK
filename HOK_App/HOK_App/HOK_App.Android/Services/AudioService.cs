using System;
using System.Threading.Tasks;
using Android.Media;
using HOK_App.Services;
using Java.Lang;
using static Android.Media.MediaPlayer;

namespace HOK_App.Droid.Services
{
    public class AudioService : MediaPlayer, IAudioService, IOnPreparedListener
    {
        Action<string, double> _updatePlayerStatus;

        public bool IsLoaded { get; private set; }

        //private readonly MediaPlayer _mediaPlayer;

        //public AudioService() => _mediaPlayer = new MediaPlayer();

        public async Task Play(string url, Action<string, double> updatePlayerStatus)
        {
            if (IsPlaying)
                return;

            if (IsLoaded)
                Start();

            await SetDataSourceAsync(url);
            PrepareAsync();
            SetOnPreparedListener(this);


        }

        public void OnPrepared(MediaPlayer mp)
        {
            mp.Start();
            IsLoaded = true;
        }
    }
}
