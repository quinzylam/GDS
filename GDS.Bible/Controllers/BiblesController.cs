using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.Bible.ViewModels;
using GDS.Bible.Data;
using Microsoft.AspNetCore.Mvc;

namespace GDS.Bible.Controllers
{
    public class BiblesController : Controller
    {
        private readonly BibleContext _context;
        private readonly BibleViewModel _viewModel;

        public BiblesController(BibleContext context, BibleViewModel viewModel)
        {
            _context = context;
            _viewModel = viewModel;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(_viewModel.Reference))
                _viewModel.Reference = Request.Cookies["Ref"];
            

            if (string.IsNullOrEmpty(_viewModel.TranslationCode) && _viewModel.Translation == null)
                return Redirect("Translations/Index");
            else if(_viewModel.Translation == null)
            {
                if(_viewModel.TranslationCode == "KJV")
                    _viewModel.Translation = _context.Translation.FirstOrDefault(x => x.Code == Core.Models.Enums.BibleVersion.KJV);
            }
                
            if (_viewModel.BookName == null && _viewModel.Book == null)
                return Redirect("Books/Index");
            else if (_viewModel.Book == null)
                _viewModel.Book = _context.Book.FirstOrDefault(x => x.ShortTitle.Contains(_viewModel.BookName) || x.Title.Contains(_viewModel.BookName));

            if (_viewModel.ChapterNo == null && _viewModel.Chapter == null)
                return Redirect("Chapters/Index");
            else if (_viewModel.Chapter == null)
                _viewModel.Chapter = _context.Chapter.FirstOrDefault(x => x.BookId == _viewModel.Book.Id && x.ChapterNo == (_viewModel.ChapterNo??0));

            if (_viewModel.FromVerse == null && _viewModel.Verse == null)
                return Redirect("Verses/Index");
            else if (_viewModel.Verse == null)
                _viewModel.Verse = _context.Verse.FirstOrDefault(x => x.ChapterId == _viewModel.Chapter.Id && x.VerseNo == (_viewModel.FromVerse ?? 0));

            return View();
        }

       
    }
}