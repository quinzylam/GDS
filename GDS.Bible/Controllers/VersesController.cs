using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GDS.Bible.Core.Models;
using GDS.Bible.Data;
using System.Text.RegularExpressions;
using GDS.Bible.ViewModels;

namespace GDS.Bible.Controllers
{
    public class VersesController : Controller
    {
        private readonly BibleContext _context;
        private readonly BibleViewModel _viewModel;

        public VersesController(BibleContext context, BibleViewModel viewModel)
        {
            _context = context;
            _viewModel = viewModel;
        }

        // GET: Verses
        public async Task<IActionResult> Index()
        {
            var verses = await _context.Verse.Where(x => x.ChapterId == _viewModel.Chapter.Id).OrderBy(x => x.VerseNo).ToListAsync();
            Regex regex = new Regex("<S>[0-9]*</S>");
            verses.ForEach(x => x.Text = regex.Replace(x.Text, ""));
            _viewModel.Verses = new System.Collections.ObjectModel.ObservableCollection<Verse>(verses);
            return View(_viewModel);
        }

        public IActionResult Reset()
        {
            Response.Cookies.Delete("VerseId");
            return Redirect("~/");
        }
        // GET: Verses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verse = await _context.Verse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verse == null)
            {
                return NotFound();
            }

            return View(verse);
        }

        // GET: Verses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Chapter,VerseNo,Text,Id")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(verse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verse);
        }

        // GET: Verses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verse = await _context.Verse.FindAsync(id);
            if (verse == null)
            {
                return NotFound();
            }
            return View(verse);
        }

        // POST: Verses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Chapter,VerseNo,Text,Id")] Verse verse)
        {
            if (id != verse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerseExists(verse.Id))
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
            return View(verse);
        }

        // GET: Verses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verse = await _context.Verse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verse == null)
            {
                return NotFound();
            }

            return View(verse);
        }

        // POST: Verses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verse = await _context.Verse.FindAsync(id);
            _context.Verse.Remove(verse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerseExists(int id)
        {
            return _context.Verse.Any(e => e.Id == id);
        }
    }
}
