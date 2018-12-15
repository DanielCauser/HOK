using System;
using Prism.Navigation;
using HOK_App.Models;
using System.Windows.Input;
using Prism.Commands;
using Plugin.MediaManager;

namespace HOK_App.ViewModels
{
    public class MediaPlayerViewModel : ViewModelBase
    {

        public ICommand PlayCommand => new DelegateCommand(PlayAudioCommand);

        private void PlayAudioCommand()
        {
            CrossMediaManager.Current.Play("www.haleokaula.org/wp-content/uploads/2018/12/20181215.mp3");
        }

        private string _podCastUrl;
        public string PodCastUrl
        {
            get => _podCastUrl;
            set => _podCastUrl = value;
        }

        public MediaPlayerViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PodCastUrl = parameters.GetValue<string>(nameof(RssFeedItem.PodCastLink));
        }
    }
}
