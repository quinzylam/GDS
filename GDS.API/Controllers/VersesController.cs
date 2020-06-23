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
    public class VersesController : ODataController
    {
        [HttpGet, EnableQuery(PageSize = 30)]
        public static IQueryable<Verse> Get([FromServices] Context context) => context.Verses;
    }
}