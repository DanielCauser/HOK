using System;
using System.Windows.Input;
using HOK_App.Commands;
using HOK_App.Models;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace HOK_App.ViewModels
{
    public class FeedPageViewModel : ViewModelBase
    {

        private ICommand _loadEventsCommand;
        public ICommand RefreshCommand => _loadEventsCommand;


        public FeedPageViewModel(INavigationService navigationService, ILoadFeedCommand loadEventsCommand)
            : base(navigationService)
        {
            _loadEventsCommand = loadEventsCommand;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _loadEventsCommand.Execute(null);
        }

        public override ICommand NavigateToWebUrlCommand => new DelegateCommand<RssFeedItem>(item => Device.OpenUri(new Uri(item.Link)));

    }
}