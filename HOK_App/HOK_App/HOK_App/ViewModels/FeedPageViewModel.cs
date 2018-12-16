using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HOK_App.Commands;
using HOK_App.Models;
using HOK_App.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using System.Globalization;
using System.IO;
using System.Text;
using HOK_App.Views;

namespace HOK_App.ViewModels
{

    public class FeedPageViewModel : ViewModelBase
    {
        private ICommand _loadEventsCommand;

        public ICommand RefreshCommand => _loadEventsCommand;

        public FeedPageViewModel(INavigationService navigationService,
                                 ILoadFeedCommand loadEventsCommand)
            : base(navigationService)
        {
            _loadEventsCommand = loadEventsCommand;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _loadEventsCommand.Execute(null);
        }

        public override ICommand NavigateToWebUrlCommand => new DelegateCommand<RssFeedItem>(FeedItemClicked);

        private void FeedItemClicked(RssFeedItem obj)
        {
            if (string.IsNullOrEmpty(obj.PodCastLink))
                Device.OpenUri(new Uri(obj.Link));
            else
            {
                var parameter = new NavigationParameters();
                parameter.Add(nameof(RssFeedItem), obj);
                NavigationService.NavigateAsync(nameof(MediaPlayerPage), parameter);
            }
        }
    }
}