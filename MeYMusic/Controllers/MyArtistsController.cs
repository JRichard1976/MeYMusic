using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeYMusic;
using MeMyMusicData;
using MeMyMusicData.Models;
using MeMyMusicData.Services;

namespace MeYMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyArtistsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly MyArtistService _myArtistService;
        private readonly ILogger<MyArtistsController> _logger;

        public MyArtistsController(DataContext context, ILogger<MyArtistsController> logger, MyArtistService myArtistService)
        {
            _context = context;
            _myArtistService = myArtistService;
        }


        // GET: api/MyArtists/5
        [HttpGet("GetMyArtistByGenre/{GenreId}")]
        public async Task<ActionResult<List<MyArtist>>> GetMyArtistByGenre(int GenreId)
        {
              return _myArtistService.GetArtistsByGenre(GenreId);
        }


        //All abive code should be done on the service but i didn't have the time they will be use for the admin of My Music
        //Normally it should two different web api one for Client front and one for Admin front


        // PUT: api/MyArtists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyArtist(int id, MyArtist myArtist)
        {
            if (id != myArtist.Id)
            {
                return BadRequest();
            }

            _context.Entry(myArtist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MyArtists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyArtist>> PostMyArtist(MyArtist myArtist)
        {
          if (_context.myArtists == null)
          {
              return Problem("Entity set 'DataContext.myArtists'  is null.");
          }
            _context.myArtists.Add(myArtist);
            await _context.SaveChangesAsync();

            return myArtist;
        }

        // DELETE: api/MyArtists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyArtist(int id)
        {
            if (_context.myArtists == null)
            {
                return NotFound();
            }
            var myArtist = await _context.myArtists.FindAsync(id);
            if (myArtist == null)
            {
                return NotFound();
            }

            _context.myArtists.Remove(myArtist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyArtistExists(int id)
        {
            return (_context.myArtists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
