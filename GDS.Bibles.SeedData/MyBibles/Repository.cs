using GDS.Bible.Core.Models.Enums;
using GDS.Bible.SeedData.MyBibles.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GDS.Bible.SeedData.MyBibles
{
    public class Repository
    {
        public Repository(BibleVersion version)
        {
            var dbpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MyBibles","Bibles", string.Concat(version.ToString(),".SQLite3"));
            Db = new SQLiteConnection(dbpath);
            Db.CreateTable<Book>();
            Db.CreateTable<Verse>();
            Db.CreateTable<Info>();
        }

        public Repository(string dictionary = "SECE.dictionary")
        {
            var dbpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MyBibles", "Dictionaries", string.Concat(dictionary, ".SQLite3"));
            Db = new SQLiteConnection(dbpath);
            Db.CreateTable<Dictionary>();
            Db.CreateTable<CognateStrongNumber>();
            Db.CreateTable<MorphologyIndication>();
            Db.CreateTable<Info>();
        }


        public SQLiteConnection Db { get; set; }
    }
}
