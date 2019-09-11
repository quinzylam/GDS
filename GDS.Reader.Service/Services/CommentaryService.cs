using GDS.Reader.Core.Models.Commentaries;
using GDS.Reader.Core.Services;
using GDS.Reader.Data;
using System.Linq;

namespace GDS.Reader.Services
{
    public class CommentaryService : ICommentaryService
    {
        private readonly CommentaryContext _ctx;

        public CommentaryService(string name) => _ctx = new CommentaryContext(name);

        public IQueryable<Chapter> GetChapters() => _ctx.Chapters.AsQueryable();

        public Chapter GetChapter(int id) => _ctx.Chapters.Find(id);

        public IQueryable<Comment> GetComments() => _ctx.Comments.AsQueryable();

        public Comment GetComment(int id) => _ctx.Comments.Find(id);
    }
}