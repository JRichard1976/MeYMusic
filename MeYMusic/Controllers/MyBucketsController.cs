using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeMyMusicData;
using MeMyMusicData.Models;

namespace MeYMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBucketsController : ControllerBase
    {
        private readonly DataContext _context;

        public MyBucketsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MyBuckets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyBucket>>> GetmyBuckets()
        {
          if (_context.myBuckets == null)
          {
              return NotFound();
          }
            return await _context.myBuckets.ToListAsync();
        }

        // GET: api/MyBuckets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyBucket>> GetMyBucket(int id)
        {
          if (_context.myBuckets == null)
          {
              return NotFound();
          }
            var myBucket = await _context.myBuckets.FindAsync(id);

            if (myBucket == null)
            {
                return NotFound();
            }

            return myBucket;
        }

        // PUT: api/MyBuckets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyBucket(int id, MyBucket myBucket)
        {
            if (id != myBucket.Id)
            {
                return BadRequest();
            }

            _context.Entry(myBucket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyBucketExists(id))
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

        // POST: api/MyBuckets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyBucket>> PostMyBucket(MyBucket myBucket)
        {
          if (_context.myBuckets == null)
          {
              return Problem("Entity set 'DataContext.myBuckets'  is null.");
          }
            _context.myBuckets.Add(myBucket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyBucket", new { id = myBucket.Id }, myBucket);
        }

        // DELETE: api/MyBuckets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyBucket(int id)
        {
            if (_context.myBuckets == null)
            {
                return NotFound();
            }
            var myBucket = await _context.myBuckets.FindAsync(id);
            if (myBucket == null)
            {
                return NotFound();
            }

            _context.myBuckets.Remove(myBucket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyBucketExists(int id)
        {
            return (_context.myBuckets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
