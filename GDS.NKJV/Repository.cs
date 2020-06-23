using GDS.Bibles.Core;
using GDS.Bibles.Core.Models;
using GDS.Core.Models.Enums;
using SQLite;
using System;
using System.IO;
using System.Reflection;

namespace GDS.NKJV
{
    public class Repository : IRepository
    {
        public Repository()
        {
            Connection.CreateTable<Book>();
            Connection.CreateTable<Verse>();

            Connection.CreateTable<BookHeader>();
            Connection.CreateTable<Info>();
            Connection.CreateTable<Story>();
        }

        public string DBPath { get => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Database", string.Concat(BibleVersion.NKJV.ToString(), ".SQLite3")); }
        public SQLiteConnection Connection { get => new SQLiteConnection(DBPath); }
    }
}