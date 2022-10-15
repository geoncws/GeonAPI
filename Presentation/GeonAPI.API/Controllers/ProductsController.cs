using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeonAPI.Application.RequestParameters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeonAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            return Ok("Test edildi");
        }
        [HttpGet]
        public async Task<IActionResult> Post()
        {
            return Ok("Hasanca");
        }
    }
}

