using System;
using Plugin.Jobs;

namespace HOK_App.Services
{
    public class JobSchedulerService
    {
        public static void ScheduleJobs()
        {
            var job = new JobInfo
            {
                Name = "DailyBibleVerseJob",
                Type = typeof(DailyBibleVerseJob)
            };

            CrossJobs.Current.Schedule(job);

            CrossJobs.Current.Run(nameof(DailyBibleVerseJob));
        }
    }
}
