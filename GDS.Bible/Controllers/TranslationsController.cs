using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GDS.Bible.Core.Models;
using GDS.Bible.Data;
using Microsoft.AspNetCore.Http;
using GDS.Bible.ViewModels;
using System.Collections.ObjectModel;

namespace GDS.Bible.Controllers
{
    public class TranslationsController : Controller
    {
        private readonly BibleContext _context;
        private readonly BibleViewModel _viewModel;
        public TranslationsController(BibleContext context, BibleViewModel viewModel)
        {
            _context = context;
            _viewModel = viewModel;
        }

        // GET: Translations
        public async Task<IActionResult> Index()
        {
            _viewModel.Translations = new ObservableCollection<Translation>(await _context.Translation.ToListAsync());
            return View(_viewModel);
        }

        public IActionResult Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            _viewModel.Translation = _viewModel.Translations.FirstOrDefault(x => x.Id == id);
            Response.Cookies.Append("Ref",_viewModel.Reference);
            return Redirect("~/");
        }

        public IActionResult Reset()
        {
            Response.Cookies.Delete("VerseId");
            Response.Cookies.Delete("ChapterId");
            Response.Cookies.Delete("BookId");
            Response.Cookies.Delete("TranslationId");
            return Redirect("~/");
        }
        // GET: Translations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _context.Translation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }

        // GET: Translations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Translations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Code,Description,HasStrongs,Id")] Translation translation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(translation);
        }

        // GET: Translations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _context.Translation.FindAsync(id);
            if (translation == null)
            {
                return NotFound();
            }
            return View(translation);
        }

        // POST: Translations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Code,Description,HasStrongs,Id")] Translation translation)
        {
            if (id != translation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslationExists(translation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(translation);
        }

        // GET: Translations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _context.Translation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }

        // POST: Translations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var translation = await _context.Translation.FindAsync(id);
            _context.Translation.Remove(translation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslationExists(int id)
        {
            return _context.Translation.Any(e => e.Id == id);
        }
    }
}
