using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Jobs;
using Plugin.Notifications;

namespace HOK_App.Services
{
    public class DailyBibleVerseJob : IJob
    {
        public async Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            Console.WriteLine("Entering background job!");
            var list = await CrossNotifications.Current.GetScheduledNotifications();

            if (list.Any()) return;

            // get the next 30 bible verses based on date
            //schedule a month
            for (int i = 0; i < 3; i++)
            {
                var nt = new Notification
                {
                    Title = "Daily bible verse",
                    Message = $"This is a bible verse {i}",
                    Vibrate = true,
                    When = TimeSpan.FromHours(TimeLeft(i)),
                };
                await CrossNotifications.Current.Send(nt);
            }
        }

        private static double TimeLeft(int repetition)
        {
            var now = DateTime.Now;
            var tomorrow8am = now.AddDays(1).Date.AddHours(8);
            double totalHours = (tomorrow8am - now).TotalHours + repetition * 24;

            return totalHours;
        }
    }
}
