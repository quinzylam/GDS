using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.Core.Models;
using GDS.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDS.API.Controllers
{
    public class BibleBooksController : ODataController
    {
        [HttpGet, EnableQuery]
        public static IQueryable<BibleBook> Get([FromServices] Context context) => context.BibleBooks;
    }
}