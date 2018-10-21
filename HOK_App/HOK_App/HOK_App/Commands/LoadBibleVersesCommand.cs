using System;
using System.Threading.Tasks;
using HOK_App.Services;

namespace HOK_App.Commands
{
    public class LoadBibleVersesCommand : BaseCommand, ILoadBibleVersesCommand
    {
        private readonly IBibleVersesDataService _bibleVersesDataService;

        public LoadBibleVersesCommand(IErrorManagementService errorManagementService,
                                     IBibleVersesDataService bibleVersesDataService) : base(errorManagementService)
        {
            _bibleVersesDataService = bibleVersesDataService;
            ExecuteMethodAsync = LoadEventsFeed;
        }

        public async Task LoadEventsFeed()
        {
            var list = await _bibleVersesDataService.GetBibleVerses();
            //Task.Run(() => { JobSchedulerService.ScheduleJobs(list); });
        }
    }
}
