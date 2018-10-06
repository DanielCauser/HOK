using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using HOK_App.Models;
using HOK_App.Services;
using HttpTracer;
using MonkeyCache.SQLite;
using MvvmHelpers;
using Xamarin.Essentials;

namespace HOK_App.Commands
{
    public class LoadFeedCommand : BaseCommand, ILoadFeedCommand
    {
        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public LoadFeedCommand(IErrorManagementService errorManagementService) : base(errorManagementService)
        {
            ExecuteMethodAsync = LoadEventsFeed;
        }

        private ObservableRangeCollection<RssFeedItem> _eventList;

        public ObservableRangeCollection<RssFeedItem> EventList =>
            _eventList = _eventList ?? new ObservableRangeCollection<RssFeedItem>();

        public async Task LoadEventsFeed()
        {
            try
            {
                const string url = "http://www.haleokaula.org/feed/";
                IsRefreshing = true;

                string result;
                List<RssFeedItem> events;

                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    //#if DEBUG
                    //                    using (var client = new HttpClient(new HttpTracerHandler()))
                    //#else
                    using (var client = new HttpClient())
                    //#endif

                    {
                        result = await client.GetStringAsync(url).ConfigureAwait(false);
                        events = await ParseFeed(result);
                        Barrel.Current.Add(url, events, TimeSpan.FromDays(1));
                    }
                }
                else
                {
                    events = Barrel.Current.Get<List<RssFeedItem>>(url);
                }

                if (events != null && events.Any())
                    EventList.ReplaceRange(events);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async Task<List<RssFeedItem>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
            {
                var result = new List<RssFeedItem>();
                if (string.IsNullOrWhiteSpace(rss)) return result;
                var xdoc = XDocument.Parse(rss);
                var id = 0;
                foreach (var item in xdoc.Descendants("item"))
                {
                    var feed = new RssFeedItem
                    {
                        Title = (string)item.Element("title"),
                        Description = (string)item.Element("description"),
                        Link = (string)item.Element("guid"),
                        PublishDate = (string)item.Element("pubDate"),
                        Id = id++
                    };

                    if(!string.IsNullOrEmpty((string)item.Element("enclosure")?.Attribute("url")?.Value))
                    {
                        feed.PodCastLink = (string)item.Element("enclosure").Attribute("url").Value;
                        feed.Author = (string)item.Elements().Where(y => y.Name.LocalName == "author").FirstOrDefault().Value;
                        feed.ImageLink = (string)item.Elements().Where(y => y.Name.LocalName == "image").FirstOrDefault().Attribute("href").Value;
                        feed.PodCastDuration = (string)item.Elements().Where(y => y.Name.LocalName == "duration").FirstOrDefault().Value;
                    }

                    result.Add(feed);
                    //(string)el.Attribute(aw + "Type") == "Billing"
                }
                return result;
                //    return (from item in xdoc.Descendants("item")
                //        select new RssFeedItem
                //        {
                //            Title = (string) item.Element("title"),
                //            Description = (string) item.Element("description"),
                //            Link = (string) item.Element("guid"),
                //            PublishDate = (string) item.Element("pubDate"),
                //            AuthorEmail = (string) item.Element("author"),
                //            ImageLink = (string)item.Element("image"),
                //            Id = id++
                //        }).ToList();
            });
        }
    }
}