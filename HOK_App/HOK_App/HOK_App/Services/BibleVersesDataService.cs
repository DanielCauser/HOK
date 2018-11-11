using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HOK_App.Models;
using SQLite;
using System.Globalization;
using System.Linq;

namespace HOK_App.Services
{
    public class BibleVersesDataService : IBibleVersesDataService
    {
        private readonly DateTime _todayin2018;
        private readonly IFileService _fileService;
        private SQLiteAsyncConnection _conn => new SQLiteAsyncConnection(EnsureDatabaseFile());

        public BibleVersesDataService(IFileService fileService)
        {
            _fileService = fileService;
            _todayin2018 = new DateTime(2018, DateTime.Now.Month, DateTime.Now.Day);
        }

        public async Task<IList<BibleVerse>> GetBibleVerses()
        {
            await UpdateAllHours();
            var list = await _conn.QueryAsync<BibleVerse>($"SELECT * FROM BibleVerse WHERE Date >= '{_todayin2018.Ticks}' AND Date < '{_todayin2018.AddDays(30).Ticks}'");
            return list;
        }

        public async Task<BibleVerse> GetTodayVerse()
        {
            var list = await _conn.QueryAsync<BibleVerse>($"SELECT * FROM BibleVerse WHERE Date = '{_todayin2018.Ticks}'");
            return list.First();
        }

        private async Task UpdateAllHours()
        {
            var query = _conn.Table<BibleVerse>();

            var list = await query.ToListAsync();

            var startDate = new DateTime(2018, 1, 1);
            var dateToUpdate = new DateTime(2018, 1, 1);

            for (int i = 0; i < list.Count(x => x.Feast == $"{nameof(FeastEnum.None)}"); i++)
            {
                list[i].Date = dateToUpdate;
                await _conn.UpdateAsync(list[i]);
                dateToUpdate = startDate.AddHours(i * 24);
            }
        }

        private string EnsureDatabaseFile()
        {
            if (!File.Exists(Constants.DataBaseCompletePath))
            {
                if (_fileService.AssetExists(Constants.DataBaseName))
                {
                    try
                    {
                        _fileService.MoveAsset(Constants.DataBaseName, Constants.DataBaseCompletePath);
                    }
                    catch
                    {
                        File.Create(Constants.DataBaseCompletePath).Dispose();
                    }
                }
                else
                {
                    File.Create(Constants.DataBaseCompletePath).Dispose();
                }
            }
            return Constants.DataBaseCompletePath;
        }
    }
}
