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
    public class MyBuckectItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public MyBuckectItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MyBuckectItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyBuckectItem>>> GetmyBuckectItems()
        {
          if (_context.myBuckectItems == null)
          {
              return NotFound();
          }
            return await _context.myBuckectItems.ToListAsync();
        }

        // GET: api/MyBuckectItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MyBuckectItem>> GetMyBuckectItem(int id)
        {
          if (_context.myBuckectItems == null)
          {
              return NotFound();
          }
            var myBuckectItem = await _context.myBuckectItems.FindAsync(id);

            if (myBuckectItem == null)
            {
                return NotFound();
            }

            return myBuckectItem;
        }

        // PUT: api/MyBuckectItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyBuckectItem(int id, MyBuckectItem myBuckectItem)
        {
            if (id != myBuckectItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(myBuckectItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyBuckectItemExists(id))
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

        // POST: api/MyBuckectItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MyBuckectItem>> PostMyBuckectItem(MyBuckectItem myBuckectItem)
        {
          if (_context.myBuckectItems == null)
          {
              return Problem("Entity set 'DataContext.myBuckectItems'  is null.");
          }
            _context.myBuckectItems.Add(myBuckectItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMyBuckectItem", new { id = myBuckectItem.Id }, myBuckectItem);
        }

        // DELETE: api/MyBuckectItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyBuckectItem(int id)
        {
            if (_context.myBuckectItems == null)
            {
                return NotFound();
            }
            var myBuckectItem = await _context.myBuckectItems.FindAsync(id);
            if (myBuckectItem == null)
            {
                return NotFound();
            }

            _context.myBuckectItems.Remove(myBuckectItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MyBuckectItemExists(int id)
        {
            return (_context.myBuckectItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
