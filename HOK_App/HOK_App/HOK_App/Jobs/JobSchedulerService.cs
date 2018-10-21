using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HOK_App.Models;
using Plugin.Jobs;
using Prism.Autofac;
using Prism.Services;

namespace HOK_App.Services
{
    public class JobSchedulerService
    {
        public static void ScheduleJobs(IList<BibleVerse> list)
        {
            var job = new JobInfo
            {
                Name = "DailyBibleVerseJob",
                Type = typeof(DailyBibleVerseJob)
            };

            job.SetValue("BibleVerseList", list);

            CrossJobs.Current.Schedule(job);

            CrossJobs.Current.Run(nameof(DailyBibleVerseJob));
        }
    }
}
