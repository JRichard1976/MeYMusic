using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeMyMusicData;
using MeMyMusicData.Models;
using MeMyMusicData.Services;
using NLog;
namespace MeYMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyGenresController : ControllerBase
    {
        private readonly MyGenresServices _myGenresServices;
        private readonly ILogger<MyGenresController> _logger;

        public MyGenresController(ILogger<MyGenresController> logger, MyGenresServices myGenresServices)
        {
            _myGenresServices = myGenresServices;
            _logger = logger;
        }

        // GET: api/MyGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyGenre>>> GetmyGenres()
        {
            _logger.LogDebug("Start GetmyGenres");
            return  _myGenresServices.GelAllGenres();
        }

        

    }
}
