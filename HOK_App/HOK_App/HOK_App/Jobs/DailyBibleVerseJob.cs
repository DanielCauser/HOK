using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HOK_App.Models;
using Plugin.Jobs;
using Plugin.LocalNotifications;

namespace HOK_App.Services
{
    public class DailyBibleVerseJob : IJob
    {
        private static DateTime TimeLeft(int repetition)
        {
            var now = DateTime.Now;
            var tomorrow8am = now.AddDays(1).Date.AddHours(8);
            var next = DateTime.Now.AddHours((tomorrow8am - now).TotalHours + repetition * 24);

            return next;
        }

        public Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            Console.WriteLine("Entering background job!");
            try
            {
                var list = jobInfo.GetValue<List<string>>("BibleVerseList");
                //for (int i = 0; i < list.Count; i++)
                //{
                //    var feast = list[i].Feast != nameof(FeastEnum.None) ? list[i].Feast : string.Empty;
                //    CrossLocalNotifications.Current.Show(
                //        $"Daily bible verse {feast}".Trim(),
                //        $"{list[i].Verse}",
                //        i,
                //        //DateTime.Now.AddSeconds(10 * i));
                //        TimeLeft(i));
                //}
            }
            catch (Exception ex)
            {

            }

            return Task.FromResult(0);
        }
    }
}
