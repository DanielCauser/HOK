using System;
using SQLite;

namespace HOK_App.Models
{
    public class BibleVerse
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Verse { get; set; }
        public string Feast { get; set; }
        public string VerseLocation { get; set; }
        public DateTime Date { get; set; }
    }
}
