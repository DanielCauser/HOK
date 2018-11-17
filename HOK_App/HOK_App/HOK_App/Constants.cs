using System;
using System.IO;

namespace HOK_App
{
    public static class Constants
    {
        public static int HourScheduledForPN => 8;
        public static string DataBaseName => "hok.db";
        public static string DataBasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        public static string DataBaseCompletePath => $"{DataBasePath}/{DataBaseName}";
        public static string HOKSiteFeed => "http://www.haleokaula.org/feed/";
    }
}
