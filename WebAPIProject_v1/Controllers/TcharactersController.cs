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
    public class TcharactersController : ControllerBase
    {
        private readonly RohanGameContext _context;

        public TcharactersController(RohanGameContext context)
        {
            _context = context;
        }

        // GET: api/Tcharacters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcharacter>>> GetTcharacters()
        {
          if (_context.Tcharacters == null)
          {
              return NotFound();
          }
            return await _context.Tcharacters.ToListAsync();
        }

        // GET: api/Tcharacters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tcharacter>> GetTcharacter(int id)
        {
          if (_context.Tcharacters == null)
          {
              return NotFound();
          }
            var tcharacter = await _context.Tcharacters.FindAsync(id);

            if (tcharacter == null)
            {
                return NotFound();
            }

            return tcharacter;
        }

        // PUT: api/Tcharacters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcharacter(int id, Tcharacter tcharacter)
        {
            if (id != tcharacter.Id)
            {
                return BadRequest();
            }

            _context.Entry(tcharacter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TcharacterExists(id))
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

        // POST: api/Tcharacters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tcharacter>> PostTcharacter(Tcharacter tcharacter)
        {
          if (_context.Tcharacters == null)
          {
              return Problem("Entity set 'RohanGameContext.Tcharacters'  is null.");
          }
            _context.Tcharacters.Add(tcharacter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTcharacter", new { id = tcharacter.Id }, tcharacter);
        }

        // DELETE: api/Tcharacters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTcharacter(int id)
        {
            if (_context.Tcharacters == null)
            {
                return NotFound();
            }
            var tcharacter = await _context.Tcharacters.FindAsync(id);
            if (tcharacter == null)
            {
                return NotFound();
            }

            _context.Tcharacters.Remove(tcharacter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TcharacterExists(int id)
        {
            return (_context.Tcharacters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
