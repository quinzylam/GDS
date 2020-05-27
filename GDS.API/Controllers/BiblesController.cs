using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDS.Core.Models;
using GDS.Core.Models.Enums;
using GDS.Core.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GDS.API.Controllers
{
    public class BiblesController : ODataController
    {
        private readonly IBibleService<Bible> _service;

        public BiblesController(IBibleService<Bible> bibleService)
        {
            _service = bibleService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var result = _service.Get();
            return Ok(result);
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri]BibleVersion key)
        {
            var result = _service.Get().FirstOrDefault(x => x.Code == key);
            return Ok(result);
        }
    }
}