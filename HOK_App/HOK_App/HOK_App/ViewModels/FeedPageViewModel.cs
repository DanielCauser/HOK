using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HOK_App.Commands;
using HOK_App.Models;
using HOK_App.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace HOK_App.ViewModels
{
    public class FeedPageViewModel : ViewModelBase
    {
        private ICommand _loadEventsCommand;
        private ICommand _bibleVerseServiceCommand;

        public ICommand RefreshCommand => _loadEventsCommand;
        public ICommand BibleVersesCommand => _loadEventsCommand;

        public FeedPageViewModel(INavigationService navigationService,
                                 ILoadFeedCommand loadEventsCommand,
                                 ILoadBibleVersesCommand bibleVerseService)
            : base(navigationService)
        {
            _loadEventsCommand = loadEventsCommand;
            _bibleVerseServiceCommand = bibleVerseService;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _loadEventsCommand.Execute(null);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _bibleVerseServiceCommand.Execute(null);
        }

        public override ICommand NavigateToWebUrlCommand => new DelegateCommand<RssFeedItem>(item => Device.OpenUri(new Uri(item.Link)));

    }
}