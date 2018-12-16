using System;
using Prism.Navigation;
using HOK_App.Models;
using System.Windows.Input;
using Prism.Commands;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Xamarin.Forms;

namespace HOK_App.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {
        public RssFeedItem DataObject { get; set; }

        private string _duration;
        private double _progress;
        public double Progress { get => _progress; set => SetProperty(ref _progress, value); }
        public string Duration { get => _duration; set => SetProperty(ref _duration, value); }

        public MediaPlayerViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            PlayerController = CrossMediaManager.Current.PlaybackController;

            CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            {
                //Device.BeginInvokeOnMainThread(() =>
                //{
                Progress = e.Progress;
                Duration = "" + e.Duration.TotalSeconds + " seconds";
                //});
            };
        }

        public readonly IPlaybackController PlayerController;

        public ICommand PlayCommand => new DelegateCommand(PlayAudioCommand);

        public ICommand PauseCommand => new DelegateCommand(PauseAudioCommand);

        private void PlayAudioCommand()
        {
            PlayerController.Play();
        }

        private void PauseAudioCommand()
        {
            PlayerController.Pause();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            DataObject = parameters.GetValue<RssFeedItem>(nameof(RssFeedItem));
            CrossMediaManager.Current.Play(DataObject.PodCastLink);
            PlayerController.Pause();
        }
    }
}
