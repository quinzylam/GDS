using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.Core.Models;
using GDS.Core.Services;
using GDS.Services.Core.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDS.API.Controllers
{
    public class BooksController : ODataController
    {
        private readonly IBookService<Book> _bookService;

        public BooksController(IBookService<Book> bookService)
        {
            _bookService = bookService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var result = _bookService.Get();
            return Ok(result);
        }
    }
}