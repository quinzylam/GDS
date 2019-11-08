using GDS.Core.Data;
using GDS.Core.Models.Bibles;
using GDS.Core.Models.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Services
{
    public interface IDataService
    {
        IDataReader<Translation> Translations { get; }
        IDataReader<Book> Books { get; }
        IDataReader<Verse> Verses { get; }

        IServerDataStore<User> Users { get; }
    }
}