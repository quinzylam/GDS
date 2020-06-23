using GDS.Bibles.Core.Services;
using GDS.Core.Models.Enums;
using GDS.Data;
using GDS.KJVAE.Services;
using GDS.NKJV.Services;
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

            SeedBibles(context, update);
            SeedBooks(context, update);

            foreach (var bible in context.Bibles.ToList())
            {
                var service = GetService(context, bible.Code);
                SeedBibleBooks(context, update, bible.Code, service);
                SeedHeadings(context, update, bible.Code, service);
                SeedVerses(context, update, bible, service);
            }
        }

        private static void SeedHeadings(Context context, bool update, BibleVersion code, IBibleService service)
        {
            if (!context.Books.Any())
                return;

            service.BibleBooks = context.BibleBooks.Where(x => x.Version == code).ToList();

            if (service.Headings == null)
                return;

            if (!context.Headings.Any())
            {
                foreach (var item in service.Headings)
                    context.Headings.Add(item);
                context.SaveChanges();
            }
            else if (update)
            {
                foreach (var item in service.Headings)
                {
                    var dbobj = context.Headings.FirstOrDefault(x => x.LocalId == item.LocalId);
                    if (dbobj != null)
                    {
                        item.Id = dbobj.Id;
                        context.Entry(dbobj).CurrentValues.SetValues(item);
                    }
                    else
                        context.Headings.Add(item);
                }
                context.SaveChanges();
            }
        }

        private static void SeedVerses(Context context, bool update, Core.Models.Bible bible, IBibleService service)
        {
            service.BibleBooks = context.BibleBooks.Where(x => x.Version == bible.Code).ToList();
            service.Headings = context.Headings.ToList();
            if (!context.Verses.Any(x => x.BibleBook.Version == bible.Code))
            {
                foreach (var item in service.Verses)
                    context.Verses.Add(item);
                context.SaveChanges();
            }
            else if (update)
            {
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

        private static void SeedBibles(Context context, bool update)
        {
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
                    var item = bible;
                    if (bible.Code == Core.Models.Enums.BibleVersion.NKJV)
                        item = new NKJVService(context.Books, bible).Bible;

                    var dbobj = context.Bibles.Find(item.Id);
                    if (dbobj != null)
                        context.Entry(dbobj).CurrentValues.SetValues(item);
                    else
                        context.Bibles.Add(item);
                }
                context.SaveChanges();
            }
        }

        private static void SeedBibleBooks(Context context, bool update, BibleVersion code, IBibleService service)
        {
            if (!context.BibleBooks.Any(x => x.Version == code))
                AddBibleBooks(context, service);
            else if (update)
                UpdateBook(context, service);
        }

        private static void SeedBooks(Context context, bool update)
        {
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
        }

        private static void UpdateBook(Context context, IBibleService service)
        {
            foreach (var item in service.BibleBooks)
            {
                var dbobj = context.BibleBooks.FirstOrDefault(x => x.LocalId == item.LocalId);
                if (dbobj != null)
                {
                    item.Id = dbobj.Id;
                    context.Entry(dbobj).CurrentValues.SetValues(item);
                }
                else
                    context.BibleBooks.Add(item);
            }
            context.SaveChanges();
        }

        private static void AddBibleBooks(Context context, IBibleService service)
        {
            foreach (var item in service.BibleBooks.ToList())
                context.BibleBooks.Add(item);
            context.SaveChanges();
        }

        private static IBibleService GetService(Context context, BibleVersion code)
        {
            IBibleService service = null;
            switch (code)
            {
                case BibleVersion.KJVAE:
                    service = new KJVAEService(context.Bibles.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJVAE), context.Books.ToList());
                    break;

                case BibleVersion.NKJV:
                    service = new NKJVService(context.Books.ToList(), context.Bibles.FirstOrDefault(x => x.Code == code));
                    break;
            }

            return service;
        }
    }
}