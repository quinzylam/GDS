using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GDSOnline.Controllers
{
    public class ReaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}