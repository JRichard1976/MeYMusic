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

namespace MeYMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAlbumsController : ControllerBase
    {
        private readonly DataContext _context;

        public MyAlbumsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MyAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyAlbum>>> GetmyAlbums()
        {
          if (_context.myAlbums == null)
          {
              return NotFound();
          }
            return await _context.myAlbums.ToListAsync();
        }

        // GET: api/MyAlbums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyAlbum>> GetMyAlbum(int id)
        {
          if (_context.myAlbums == null)
          {
              return NotFound();
          }
            var myAlbum = await _context.myAlbums.FindAsync(id);

            if (myAlbum == null)
            {
                return NotFound();
            }

            return myAlbum;
        }

        // PUT: api/MyAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyAlbum(int id, MyAlbum myAlbum)
        {
            if (id != myAlbum.Id)
            {
                return BadRequest();
            }

            _context.Entry(myAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyAlbumExists(id))
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

        // POST: api/MyAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyAlbum>> PostMyAlbum(MyAlbum myAlbum)
        {
          if (_context.myAlbums == null)
          {
              return Problem("Entity set 'DataContext.myAlbums'  is null.");
          }
            _context.myAlbums.Add(myAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyAlbum", new { id = myAlbum.Id }, myAlbum);
        }

        // DELETE: api/MyAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyAlbum(int id)
        {
            if (_context.myAlbums == null)
            {
                return NotFound();
            }
            var myAlbum = await _context.myAlbums.FindAsync(id);
            if (myAlbum == null)
            {
                return NotFound();
            }

            _context.myAlbums.Remove(myAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyAlbumExists(int id)
        {
            return (_context.myAlbums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
