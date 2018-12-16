using System;
using Prism.Navigation;
using HOK_App.Models;
using System.Windows.Input;
using Prism.Commands;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Xamarin.Forms;
using Plugin.MediaManager.Abstractions.Implementations;
using HOK_App.Services;

namespace HOK_App.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        public RssFeedItem DataObject { get; set; }

        private readonly IAudioService _audioService;

        string _duration;
        private double _progress;
        public double Progress { get => _progress; set => SetProperty(ref _progress, value); }
        public string Duration { get => _duration; set => SetProperty(ref _duration, value); }

        public MediaPlayerViewModel(INavigationService navigationService,
                                    IAudioService audioService)
            : base(navigationService)
        {
            _audioService = audioService;
        }

        public ICommand PlayCommand => new DelegateCommand(PlayAudioCommand);

        public ICommand PauseCommand => new DelegateCommand(PauseAudioCommand);

        private void PlayAudioCommand()
        {
            _audioService.Play(DataObject.PodCastLink, HandleAction);
        }

        void HandleAction(string arg1, double arg2)
        {
        }

        private void PauseAudioCommand()
        {
            _audioService.Pause();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            DataObject = parameters.GetValue<RssFeedItem>(nameof(RssFeedItem));
            //MediaFile file = new MediaFile(DataObject.PodCastLink, MediaFileType.Audio);

            //CrossMediaManager.Current.AudioPlayer.PlayingChanged += (sender, e) =>
            //{
            //    //Device.BeginInvokeOnMainThread(() =>
            //    //{
            //    //Progress = e.Progress;
            //    //Duration = "" + e.Duration.TotalSeconds + " seconds";
            //    //});
            //};

            //CrossMediaManager.Current.AudioPlayer.Play(file);
        }
    }
}
