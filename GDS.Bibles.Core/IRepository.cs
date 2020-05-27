using SQLite;

namespace GDS.Bibles.Core
{
    public interface IRepository
    {
        SQLiteConnection Connection { get; }
        string DBPath { get; }
    }
}