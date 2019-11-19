using GDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Xamarin.Forms;

namespace GDS.Data.Mobile.Contexts
{
    public class GDSContext : DbContext
    {
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseReader
        {
            return base.Set<TEntity>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DBGlobal.DB_NAME); ;
                    break;

                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBGlobal.DB_NAME);
                    break;

                case Device.UWP:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBGlobal.DB_NAME);
                    break;

                default:
                    throw new NotImplementedException("Platform not supported");
            }
            // Specify that we will use sqlite and the path of the database here
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}