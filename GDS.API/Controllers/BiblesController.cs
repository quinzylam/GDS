using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using GDS.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDS.API.Controllers
{
    public class BiblesController : ODataController
    {
        [HttpGet, EnableQuery]
        public static IQueryable<Bible> Get([FromServices]Context context) => context.Bibles;
    }
}