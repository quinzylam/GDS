using System.Linq;
using BibleReader.Models.Commentaries;

namespace BibleReader.Services
{
    public interface ICommentaryService
    {
        Chapter GetChapter(int id);
        IQueryable<Chapter> GetChapters();
        Comment GetComment(int id);
        IQueryable<Comment> GetComments();
    }
}