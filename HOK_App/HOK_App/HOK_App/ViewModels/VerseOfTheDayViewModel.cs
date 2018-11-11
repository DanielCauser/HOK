using System;
using System.Windows.Input;
using HOK_App.Commands;
using Prism.Navigation;

namespace HOK_App.ViewModels
{
    public class VerseOfTheDayViewModel : ViewModelBase
    {
        private ICommand _bibleVerseServiceCommand;
        private ICommand _verseOfTHeDayServiceCommand;

        public VerseOfTheDayViewModel(INavigationService navigationService,
                                      ILoadBibleVersesCommand bibleVerseService,
                                      IVerseOfTheDayCommand verseOfTHeDayService) 
                                      : base(navigationService)
        {
            _bibleVerseServiceCommand = bibleVerseService;
            _verseOfTHeDayServiceCommand = verseOfTHeDayService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _bibleVerseServiceCommand.Execute(null);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            _verseOfTHeDayServiceCommand.Execute(null);
        }
    }
}
