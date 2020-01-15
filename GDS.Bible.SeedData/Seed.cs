using AutoMapper;
using GDS.Bible.Core.Models;
using GDS.Bible.Core.Models.Enums;
using GDS.Bible.SeedData.MyBibles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDS.Bible.SeedData
{
    public class Seed
    {
        Repository _repo;
        private readonly IMapper _mapper;
        public Seed(BibleVersion version)
        {
            _repo = new Repository(version);
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyBibles.Models.Book, Book>()
                    .ForMember(dest => dest.Colour, opt => opt.MapFrom(src => src.BookColor))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.LongName))
                    .ForMember(dest => dest.BookNo, opt => opt.MapFrom(src => src.BookNumber))
                    .ForMember(dest => dest.ShortTitle, opt => opt.MapFrom(src => src.ShortName));
                cfg.CreateMap<MyBibles.Models.Verse, Verse>()
                    .ForMember(dest => dest.Chapter, opt => opt.Ignore());
            }));
        }

        

        public Translation GetTranslation(BibleVersion version)
        {
            ChangeRepo(version);
            return new Translation
            {
                Code = version,
                Title = _repo.Db.Table<MyBibles.Models.Info>().Where(x => x.Name == "description").FirstOrDefault().Value,
                Description = _repo.Db.Table<MyBibles.Models.Info>().Where(x => x.Name == "detailed_info").FirstOrDefault().Value,
                HasStrongs = _repo.Db.Table<MyBibles.Models.Info>().Where(x => x.Name == "strong_numbers").FirstOrDefault().Value == "true" ? true : false,
            };
        }

        public IEnumerable<Verse> GetVerses(int bookNo, Chapter chapter)
        {
            
            var verses =  new List<Verse>(_mapper.Map<IEnumerable<Verse>>(_repo.Db.Table<MyBibles.Models.Verse>().Where(x => x.Chapter == chapter.ChapterNo && x.BookNumber == bookNo).ToList()) );
            verses.ForEach(x => x.ChapterId = chapter.Id);
            return verses;
        }

       

        public IEnumerable<Chapter> GetChapters(int translationId, Book book)
        {
            var chapters = new List<Chapter>();
            var chp = _repo.Db.Table<MyBibles.Models.Verse>().Where(x => x.BookNumber == book.BookNo).Select(y => y.Chapter).Distinct();
            foreach (var chapterno in chp)
            {
                var chapter = new Chapter()
                {
                    TranslationId = translationId,
                    BookId = book.Id,
                    ChapterNo = chapterno,
                };
                chapters.Add(chapter);
            }
            return chapters;
        }

        private void ChangeRepo(BibleVersion version)
        {
            _repo = new Repository(version);
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>();
            var newBooks = _repo.Db.Table<MyBibles.Models.Book>().ToList();
            foreach (var book in newBooks)
            {
                var b = _mapper.Map<Book>(book);
                books.Add(b);
            }
            return books;
        }
    }
}
