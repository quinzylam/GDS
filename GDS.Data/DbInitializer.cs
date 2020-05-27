using GDS.Data;
using GDS.KJVAE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDS.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context, bool update = false)
        {
            context.Database.EnsureCreated();

            if (!context.Bibles.Any())
            {
                foreach (var bible in Seed.Bibles)
                    context.Bibles.Add(bible);
                context.SaveChanges();
            }
            else if (update)
            {
                Seed.Bibles = context.Bibles.ToList();
                Seed.SeedBibles();
                foreach (var bible in Seed.Bibles)
                {
                    var dbobj = context.Bibles.Find(bible.Id);
                    if (dbobj != null)
                        context.Entry(dbobj).CurrentValues.SetValues(bible);
                    else
                        context.Bibles.Add(bible);
                }
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                Seed.Bibles = context.Bibles.ToList();
                foreach (var book in Seed.Books)
                    context.Books.Add(book);
                context.SaveChanges();
            }
            else if (update)
            {
                Seed.Books = context.Books.ToList();
                Seed.SeedBooks();
                foreach (var book in Seed.Books)
                {
                    var dbobj = context.Books.Find(book.Id);
                    if (dbobj != null)
                        context.Entry(dbobj).CurrentValues.SetValues(book);
                    else
                        context.Books.Add(book);
                }
                context.SaveChanges();
            }

            if (!context.Chapters.Any())
            {
                var service = new KJVAEService(context.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE), context.Books.ToList());
                foreach (var item in service.Chapters)
                    context.Chapters.Add(item);
                context.SaveChanges();
            }
            else if (update)
            {
                var service = new KJVAEService(context.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE), context.Books.ToList());

                foreach (var item in service.Chapters)
                {
                    var dbobj = context.Chapters.FirstOrDefault(x => x.LocalId == item.LocalId);
                    if (dbobj != null)
                    {
                        item.Id = dbobj.Id;
                        context.Entry(dbobj).CurrentValues.SetValues(item);
                    }
                    else
                        context.Chapters.Add(item);
                }
                context.SaveChanges();
            }

            if (!context.Verses.Any())
            {
                var service = new KJVAEService(context.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE), context.Books.ToList())
                {
                    Chapters = context.Chapters.ToList()
                };
                foreach (var item in service.Verses)
                    context.Verses.Add(item);
                context.SaveChanges();
            }
            else if (update)
            {
                var service = new KJVAEService(context.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE), context.Books.ToList())
                {
                    Chapters = context.Chapters.ToList()
                };

                foreach (var item in service.Verses)
                {
                    var dbobj = context.Verses.FirstOrDefault(x => x.LocalId == item.LocalId);
                    if (dbobj != null)
                    {
                        item.Id = dbobj.Id;
                        context.Entry(dbobj).CurrentValues.SetValues(item);
                    }
                    else
                        context.Verses.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}