using System.Linq;
using GDS.Core.Models;
using GDS.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GDS.API.Controllers
{
    public class BooksController : ODataController
    {
        [HttpGet, EnableQuery]
        public static IQueryable<Book> Get([FromServices]Context context) => context.Books;
    }
}