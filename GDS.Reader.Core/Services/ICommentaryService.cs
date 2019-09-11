using System.Linq;
using GDS.Reader.Core.Models.Commentaries;

namespace GDS.Reader.Core.Services
{
    public interface ICommentaryService
    {
        Chapter GetChapter(int id);

        IQueryable<Chapter> GetChapters();

        Comment GetComment(int id);

        IQueryable<Comment> GetComments();
    }
}