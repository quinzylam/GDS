using GDS.Core.Data;
using GDS.Core.Models.Administration;
using GDS.Core.Models.Bibles;
using GDS.Core.Services;
using GDS.Data.Mobile.Contexts;
using GDS.Data.Mobile.Repository;

namespace GDS.Core.Mobile.Services
{
    public class DataService : IDataService
    {
        public DataService(GDSContext context)
        {
            Translations = new RepoReader<Translation>(context);
            Books = new RepoReader<Book>(context);
            Verses = new RepoReader<Verse>(context);
            Users = new Repository<User>(context);
        }

        public IDataReader<Translation> Translations { get; }

        public IDataReader<Book> Books { get; }

        public IDataReader<Verse> Verses { get; }

        public IDataStore<User> Users { get; }
    }
}