using BibleReader.Data;
using BibleReader.Models.Commentaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibleReader.Services
{
    public class CommentaryService : ICommentaryService
    {
        private readonly CommentaryContext _ctx;

        public CommentaryService(string name)
        {
            _ctx = new CommentaryContext(name);
        }

        public IQueryable<Chapter> GetChapters()
        {
            return _ctx.Chapters.AsQueryable();
        }

        public Chapter GetChapter(int id)
        {
            return _ctx.Chapters.Find(id);
        }

        public IQueryable<Comment> GetComments()
        {
            return _ctx.Comments.AsQueryable();
        }

        public Comment GetComment(int id)
        {
            return _ctx.Comments.Find(id);
        }
    }
}