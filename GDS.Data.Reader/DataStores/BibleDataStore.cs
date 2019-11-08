using GDS.Data.Mobile.Reader.Models.Bibles;
using SQLite;

namespace GDS.Data.Mobile.Reader.DataStores
{
    public class BibleDataStore : IBibleDataStore
    {
        public BibleDataStore()
        {
            Initialize();
        }

        public SQLiteAsyncConnection Ctx { get; private set; }

        private void Initialize()
        {
            Ctx = new SQLiteAsyncConnection(ReaderGlobal.BiblePath);

            Ctx.CreateTableAsync<BookDto>().Wait();
            Ctx.CreateTableAsync<VerseDto>().Wait();
        }
    }
}