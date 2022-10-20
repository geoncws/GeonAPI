using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeonAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Mvc;

namespace GeonAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class Multimedias : ControllerBase
    {
        readonly IStorageService _storageService;
        readonly IWebHostEnvironment _webHostEnvironment;

        public Multimedias(IWebHostEnvironment webHostEnvironment, IStorageService storageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
        }
        [HttpPost("{path}")]
        public async Task<ActionResult> Post(string path)
        {
            await _storageService.UploadAsync(path, Request.Form.Files);
            return Ok();
        }
    }
}