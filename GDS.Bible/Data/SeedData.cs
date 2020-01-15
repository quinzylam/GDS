using GDS.Bible.Core.Models.Enums;
using GDS.Bible.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.Bible.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using var context = new BibleContext(serviceProvider.GetRequiredService<DbContextOptions<BibleContext>>());
            var seed = new Seed(BibleVersion.KJV);
            if (!context.Translation.Any())
            {
                context.Add(seed.GetTranslation(BibleVersion.KJV));
                context.SaveChanges();
            }
            var translationId = context.Translation.FirstOrDefault(x => x.Code == BibleVersion.KJV).Id;
            if (!context.Book.Any())
            {
                context.AddRange(seed.GetBooks().OrderBy(x => x.BookNo));
                context.SaveChanges();
            }
            if(!context.Chapter.Any())
            {
                
                foreach(var book in context.Book.ToList())
                {
                    context.Chapter.AddRange(seed.GetChapters(translationId, book));
                  
                }
                context.SaveChanges();

            }

            if (!context.Verse.Any())
            {
                foreach (var book in context.Book.ToList())
                {
                    foreach (var chapter in context.Chapter.Where(x => x.BookId == book.Id).OrderBy(y => y.ChapterNo).ToList())
                    {
                        
                        context.Verse.AddRange(seed.GetVerses(book.BookNo, chapter));
                        context.SaveChanges();
                    }
                }
                
                
            }
           
            

            
        }
    }
}
