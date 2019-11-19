using AutoMapper;
using GDS.Core.Models.Bibles;
using GDS.External.Seed.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Book = GDS.External.Seed.Models.Book;
using Verse = GDS.External.Seed.Models.Verse;

namespace GDS.External.Seed
{
    public class SeedBibles
    {
        private readonly Mapper _mapper;
        private SQLiteAsyncConnection database;

        public SeedBibles()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, GDS.Core.Models.Bibles.Book>()
                    .ForMember(dest => dest.Colour, opt => opt.MapFrom(src => src.BookColor))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.LongName))
                    .ForMember(dest => dest.ShortTitle, opt => opt.MapFrom(src => src.ShortName));

                cfg.CreateMap<Verse, GDS.Core.Models.Bibles.Verse>();
            }));
        }

        public void GenericBible(string dbname)
        {
            var dbpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bibles", dbname);
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Book>().Wait();
            database.CreateTableAsync<Verse>().Wait();
            database.CreateTableAsync<Info>().Wait();
        }

        public async Task<Translation> GetKJV()
        {
            if (database == null)
            {
                GenericBible("KJV.SQLite3");
            }
            var translation = new Translation
            {
                Code = "KJV",
                Title = (await database.Table<Info>().Where(x => x.Name == "description").FirstOrDefaultAsync()).Value,
                Description = (await database.Table<Info>().Where(x => x.Name == "detailed_info").FirstOrDefaultAsync()).Value,
                HasStrongs = (await database.Table<Info>().Where(x => x.Name == "strong_numbers").FirstOrDefaultAsync()).Value == "true" ? true : false,
                Books = new List<Core.Models.Bibles.Book>()
            };
            var books = await database.Table<Book>().ToListAsync();

            foreach (var book in books)
            {
                var newBook = _mapper.Map<GDS.Core.Models.Bibles.Book>(book);
                newBook.Verses = _mapper.Map<ICollection<Core.Models.Bibles.Verse>>(await database.Table<Verse>().Where(x => x.BookNumber == book.BookNumber).ToListAsync());
                translation.Books.Add(newBook);
            }

            return translation;
        }
    }
}