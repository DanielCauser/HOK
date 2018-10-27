using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HOK_App.Models;
using SQLite;
using System.Globalization;

namespace HOK_App.Services
{
    public class BibleVersesDataService : IBibleVersesDataService
    {
        private readonly IFileService _fileService;
        private SQLiteAsyncConnection _conn => new SQLiteAsyncConnection(EnsureDatabaseFile());

        public BibleVersesDataService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<IList<BibleVerse>> GetBibleVerses()
        {
            var query = $"select * from {nameof(BibleVerse)}" +
                $" where {nameof(BibleVerse.Feast)} = '{nameof(FeastEnum.None)}'" +
                        $" ORDER BY RANDOM() Limit 30";
            var randomList = await _conn.QueryAsync<BibleVerse>(query);
            return randomList;
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
