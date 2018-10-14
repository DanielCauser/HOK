using System;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Jobs;
using Plugin.LocalNotifications;

namespace HOK_App.Services
{
    public class DailyBibleVerseJob : IJob
    {
        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            Console.WriteLine("Entering background job!");

            // get the next 30 bible verses based on date
            //schedule a month
            for (int i = 0; i < 3; i++)
            {
                CrossLocalNotifications.Current.Show(
                    "Daily bible verse", 
                    $"This is a bible verse {i}",
                    i, 
                    TimeLeft(i));
            }
        }

        private static DateTime TimeLeft(int repetition)
        {
            var now = DateTime.Now;
            var tomorrow8am = now.AddDays(1).Date.AddHours(8);
            var next = DateTime.Now.AddHours((tomorrow8am - now).TotalHours + repetition * 24);

            return next;
        }
    }
}
