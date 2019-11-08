using SQLite;

namespace GDS.Data.Mobile.Reader
{
    public interface IBibleDataStore
    {
        SQLiteAsyncConnection Ctx { get; }
    }
}