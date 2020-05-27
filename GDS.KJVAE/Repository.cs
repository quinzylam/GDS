using GDS.Bibles.Core;
using GDS.Core.Models.Enums;
using GDS.KJVAE.Models;
using SQLite;
using System.IO;
using System.Reflection;

namespace GDS.KJVAE
{
    public class Repository : IRepository
    {
        public Repository()
        {
            Connection.CreateTable<Chapter>();
            Connection.CreateTable<Verse>();

            Connection.CreateTable<AndroidMetadata>();
            Connection.CreateTable<Plan>();
            Connection.CreateTable<ReadingDay>();
            Connection.CreateTable<ReadingPlan>();
            Connection.CreateTable<DailyVerse>();
            Connection.CreateTable<SqliteSequence>();
            Connection.CreateTable<Version>();
        }

        public string DBPath { get => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Database", string.Concat(BibleVersion.KJVAE.ToString(), ".sqlite")); }
        public SQLiteConnection Connection { get => new SQLiteConnection(DBPath); }
    }
}