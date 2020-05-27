using GDS.Bibles.Core;
using GDS.Core.Models.Enums;
using GDS.KJV.Models;
using SQLite;
using System;
using System.IO;
using System.Reflection;

namespace GDS.KJV
{
    public class Repository : IRepository
    {
        public Repository()
        {
            Connection.CreateTable<Book>();
            Connection.CreateTable<CognateStrongNumber>();
            Connection.CreateTable<Dictionary>();
            Connection.CreateTable<Info>();
            Connection.CreateTable<MorphologyIndication>();
            Connection.CreateTable<Verse>();
        }

        public string DBPath { get => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Database", string.Concat(BibleVersion.KJV.ToString(), ".SQLite3")); }
        public SQLiteConnection Connection { get => new SQLiteConnection(DBPath); }
    }
}