using System.Collections.Generic;
using Plugin.Iconize;

namespace HOK_App.Fonts
{
    public static class FontAwesomeRegular
    {
        private static IIcon _feed = new Icon(nameof(Feed), '\uf143');
        private static IIcon _connect = new Icon(nameof(Connect), '\uf1e6');
        private static IIcon _about = new Icon(nameof(About), '\uf129');
        private static IIcon _email = new Icon(nameof(Email), '\uf2b6');

        public static IList<IIcon> Items { get; } = new List<IIcon>
        {
            _feed,
            _connect,
            _about,
            _email,
        };

        public static string FeedKey => _feed.Key;
        public static string ConnectKey => _connect.Key;
        public static string AboutKey => _about.Key;
        public static string EmailKey => _email.Key;

        public static string Feed => _feed.Character.ToString();
        public static string Connect => _connect.Character.ToString();
        public static string About => _about.Character.ToString();
        public static string Email => _email.Character.ToString();
    }

    public static class FontAwesomeBrands
    {
        private static IIcon _meetup = new Icon(nameof(Meetup), '\uf2e0');
        private static IIcon _gitHub = new Icon(nameof(GitHub), '\uf09b');
        private static IIcon _youTube = new Icon(nameof(YouTube), '\uf167');
        private static IIcon _twitter = new Icon(nameof(Twitter), '\uf099');
        private static IIcon _whatsApp = new Icon(nameof(WhatsApp), '\uf232');
        private static IIcon _facebook = new Icon(nameof(Facebook), '\uf39e');

        private static IIcon _instagram = new Icon(nameof(Instagram), '\uf16d');

        public static IList<IIcon> Items { get; } = new List<IIcon>
        {
            _meetup,
            _gitHub,
            _youTube,
            _twitter,
            _whatsApp,
            _facebook,
            _instagram
        };

        public static string MeetupKey => _meetup.Key;
        public static string GitHubKey => _gitHub.Key;
        public static string YouTubeKey => _youTube.Key;
        public static string TwitterKey => _twitter.Key;
        public static string WhatsAppKey => _whatsApp.Key;
        public static string FacebookKey => _facebook.Key;
        public static string InstagramKey => _instagram.Key;

        public static string Meetup => _meetup.Character.ToString();
        public static string GitHub => _gitHub.Character.ToString();
        public static string YouTube => _youTube.Character.ToString();
        public static string Twitter => _twitter.Character.ToString();
        public static string WhatsApp => _whatsApp.Character.ToString();
        public static string Facebook => _facebook.Character.ToString();
        public static string Instagram => _instagram.Character.ToString();
    }
}
