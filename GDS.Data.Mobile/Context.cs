using AutoMapper;
using GDS.Core.Data;
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
        public Context(string name)
        {
            Initialize(name);
        }

        public SQLiteConnection Conn { get; set; }

        public IConfigurationProvider MapConfig => new MapperConfiguration(cfg =>
          {
              cfg.CreateMap<ChapterDbo, ChapterDbo>()
              .ReverseMap();
          });

        private void Initialize(string name)
        {
            Conn = new SQLiteConnection(Path.Combine(Constants.DBPath, string.Concat(name, Constants.DB_EXT)));

            Conn.CreateTable<ChapterDbo>();
        }
    }
}