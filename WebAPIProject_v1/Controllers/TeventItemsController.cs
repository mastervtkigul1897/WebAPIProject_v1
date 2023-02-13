using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIProject_v1.Models;

namespace WebAPIProject_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeventItemsController : ControllerBase
    {
        private readonly RohanGameContext _context;

        public TeventItemsController(RohanGameContext context)
        {
            _context = context;
        }

        // GET: api/TeventItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeventItem>>> GetTeventItems()
        {
          if (_context.TeventItems == null)
          {
              return NotFound();
          }
            return await _context.TeventItems.ToListAsync();
        }

        // GET: api/TeventItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeventItem>> GetTeventItem(int id)
        {
          if (_context.TeventItems == null)
          {
              return NotFound();
          }
            var teventItem = await _context.TeventItems.FindAsync(id);

            if (teventItem == null)
            {
                return NotFound();
            }

            return teventItem;
        }

        // PUT: api/TeventItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeventItem(int id, TeventItem teventItem)
        {
            if (id != teventItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(teventItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeventItemExists(id))
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

        // POST: api/TeventItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeventItem>> PostTeventItem(TeventItem teventItem)
        {
          if (_context.TeventItems == null)
          {
              return Problem("Entity set 'RohanGameContext.TeventItems'  is null.");
          }
            _context.TeventItems.Add(teventItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeventItem", new { id = teventItem.Id }, teventItem);
        }

        // DELETE: api/TeventItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeventItem(int id)
        {
            if (_context.TeventItems == null)
            {
                return NotFound();
            }
            var teventItem = await _context.TeventItems.FindAsync(id);
            if (teventItem == null)
            {
                return NotFound();
            }

            _context.TeventItems.Remove(teventItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeventItemExists(int id)
        {
            return (_context.TeventItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
