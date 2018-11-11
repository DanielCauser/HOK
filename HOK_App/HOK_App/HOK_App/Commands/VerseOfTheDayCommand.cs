using System;
using System.Threading.Tasks;
using HOK_App.Services;

namespace HOK_App.Commands
{
    public class VerseOfTheDayCommand : BaseCommand, IVerseOfTheDayCommand
    {
        private readonly IBibleVersesDataService _bibleVersesDataService;

        public VerseOfTheDayCommand(IErrorManagementService errorManagementService,
                                   IBibleVersesDataService bibleVersesDataService) : base(errorManagementService)
        {
            _bibleVersesDataService = bibleVersesDataService;
            ExecuteMethodAsync = LoadVerseOfTheDay;
        }

        private string _verse;

        public string Verse
        {
            get => _verse;
            set => SetProperty(ref _verse, value);
        }

        private string _verseLocation;

        public string VerseLocation
        {
            get => _verseLocation;
            set => SetProperty(ref _verseLocation, value);
        }

        public async Task LoadVerseOfTheDay()
        {
            var bibleVerse = await _bibleVersesDataService.GetTodayVerse();
            Verse = bibleVerse.Verse;
            VerseLocation = bibleVerse.VerseLocation;
        }
    }
}
