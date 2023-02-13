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
    public class TitemsController : ControllerBase
    {
        private readonly RohanGameContext _context;

        public TitemsController(RohanGameContext context)
        {
            _context = context;
        }

        // GET: api/Titems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titem>>> GetTitems()
        {
          if (_context.Titems == null)
          {
              return NotFound();
          }
            return await _context.Titems.ToListAsync();
        }

        // GET: api/Titems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titem>> GetTitem(int id)
        {
          if (_context.Titems == null)
          {
              return NotFound();
          }
            var titem = await _context.Titems.FindAsync(id);

            if (titem == null)
            {
                return NotFound();
            }

            return titem;
        }

        // PUT: api/Titems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitem(int id, Titem titem)
        {
            if (id != titem.Id)
            {
                return BadRequest();
            }

            _context.Entry(titem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitemExists(id))
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

        // POST: api/Titems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Titem>> PostTitem(Titem titem)
        {
          if (_context.Titems == null)
          {
              return Problem("Entity set 'RohanGameContext.Titems'  is null.");
          }
            _context.Titems.Add(titem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitemExists(titem.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitem", new { id = titem.Id }, titem);
        }

        // DELETE: api/Titems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitem(int id)
        {
            if (_context.Titems == null)
            {
                return NotFound();
            }
            var titem = await _context.Titems.FindAsync(id);
            if (titem == null)
            {
                return NotFound();
            }

            _context.Titems.Remove(titem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TitemExists(int id)
        {
            return (_context.Titems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
