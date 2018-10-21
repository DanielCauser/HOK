using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HOK_App.Models;

namespace HOK_App.Services
{
    public interface IBibleVersesDataService
    {
        Task<IList<BibleVerse>> GetBibleVerses();
    }
}
