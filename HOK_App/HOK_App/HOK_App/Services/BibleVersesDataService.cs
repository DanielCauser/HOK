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

        public BibleVersesDataService(IFileService fileService)
        {
            _fileService = fileService;
            //_conn = new SQLiteAsyncConnection(Constants.DataBaseCompletePath);
        }
        //private readonly SQLiteAsyncConnection _conn;


        //public BibleVersesDataService(/**/)
        //{


        //    //_conn = new SQLiteAsyncConnection(EnsureDatabaseFile());

        //}

        //public async Task<IList<BibleVerse>> GetBibleVerses()
        //{
        //    var list = await _conn.QueryAsync<BibleVerse>($"select * from {nameof(BibleVerse)} LIMIT 30");
        //    return list;
        //}

        //private string EnsureDatabaseFile()
        //{
        //    if (!File.Exists(Constants.DataBasePath))
        //    {
        //        if (_fileService.AssetExists(Constants.DataBaseName))
        //        {
        //            try
        //            {
        //                _fileService.MoveAsset(Constants.DataBaseName, Constants.DataBaseCompletePath);
        //            }
        //            catch
        //            {
        //                File.Create(Constants.DataBaseCompletePath).Dispose();
        //            }
        //        }
        //        else
        //        {
        //            File.Create(Constants.DataBaseCompletePath).Dispose();
        //        }
        //    }
        //    return Constants.DataBaseCompletePath;
        //}
        public Task<IList<BibleVerse>> GetBibleVerses()
        {
            throw new NotImplementedException();
        }
    }
}
