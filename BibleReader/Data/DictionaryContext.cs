using BibleReader.Models;
using BibleReader.Models.Bible;
using BibleReader.Models.Dictionaries;
using BibleReader.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BibleReader
{
    public class DictionaryContext : DbContext
    {
        private readonly string _dictionary = "SECE.dictionary";

        public DictionaryContext(string dictionary)
        {
            _dictionary = dictionary;
        }

        public DbSet<StrongNumbers> StrongNumbers { get; set; }
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<MorphologyIndication> MorphologyIndications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {Resources.DictionaryPath}\\{_dictionary}.SQLite3");
        }
    }
}