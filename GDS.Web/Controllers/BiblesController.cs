using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.API.Client;
using GDS.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDS.Web.Controllers
{
    public class BiblesController : Controller
    {
        private readonly BibleViewModel _viewModel;

        public BiblesController()
        {
            _viewModel = new BibleViewModel();
        }

        // GET: Bible
        public IActionResult Index()
        {
            return View(_viewModel);
        }

        // GET: Bible/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Bible/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bible/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bible/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bible/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bible/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bible/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}