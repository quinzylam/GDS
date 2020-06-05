using AutoMapper;
using GDS.Core.Data;
using GDS.Core.Models;
using GDS.Data.Mobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GDS.Data.Mobile
{
    public class Context : IMobileContext
    {
        private const string DB_NAME = "GDS";

        public Context()
        {
            Initialize();
        }

        public SQLiteAsyncConnection Conn { get; set; }

        public IConfigurationProvider MapConfig => new MapperConfiguration(cfg =>
          {
              cfg.CreateMap<Bible, BibleDbo>()
              .ReverseMap();

              cfg.CreateMap<Book, BookDbo>()
              .ReverseMap();

              cfg.CreateMap<BibleBook, BibleBookDbo>()
              .ReverseMap();

              cfg.CreateMap<Verse, VerseDbo>()
              .ReverseMap();
          });

        private async void Initialize()
        {
            Conn = new SQLiteAsyncConnection(Path.Combine(Constants.DBPath, string.Concat(DB_NAME, Constants.DB_EXT)));

            await Conn.CreateTableAsync<BibleDbo>();
            await Conn.CreateTableAsync<BookDbo>();
            await Conn.CreateTableAsync<BibleBookDbo>();
            await Conn.CreateTableAsync<VerseDbo>();
        }
    }
}