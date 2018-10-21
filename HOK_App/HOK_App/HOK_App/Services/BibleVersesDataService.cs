using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HOK_App.Models;
using SQLite;

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
            var list = await _conn.QueryAsync<BibleVerse>($"select * from {nameof(BibleVerse)} LIMIT 30");
            return list;
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
