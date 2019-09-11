using System.Collections.Generic;
using System.Threading.Tasks;
using GDS.Reader.Core.Models.Bibles;
using GDS.Reader.Core.Services;
using GDS.Reader.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GDS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibleController : ControllerBase
    {
        private IBibleService _bible;

        public BibleController()
        {
            _bible = new BibleService();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _bible.GetBooks().ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            return _bible.GetBook(id);
        }
    }
}