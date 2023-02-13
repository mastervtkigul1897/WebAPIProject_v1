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
    public class TnguildsController : ControllerBase
    {
        private readonly RohanGameContext _context;

        public TnguildsController(RohanGameContext context)
        {
            _context = context;
        }

        // GET: api/Tnguilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tnguild>>> GetTnguilds()
        {
          if (_context.Tnguilds == null)
          {
              return NotFound();
          }
            return await _context.Tnguilds.ToListAsync();
        }

        // GET: api/Tnguilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tnguild>> GetTnguild(int id)
        {
          if (_context.Tnguilds == null)
          {
              return NotFound();
          }
            var tnguild = await _context.Tnguilds.FindAsync(id);

            if (tnguild == null)
            {
                return NotFound();
            }

            return tnguild;
        }

        // PUT: api/Tnguilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTnguild(int id, Tnguild tnguild)
        {
            if (id != tnguild.MasterId)
            {
                return BadRequest();
            }

            _context.Entry(tnguild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TnguildExists(id))
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

        // POST: api/Tnguilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tnguild>> PostTnguild(Tnguild tnguild)
        {
          if (_context.Tnguilds == null)
          {
              return Problem("Entity set 'RohanGameContext.Tnguilds'  is null.");
          }
            _context.Tnguilds.Add(tnguild);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TnguildExists(tnguild.MasterId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTnguild", new { id = tnguild.MasterId }, tnguild);
        }

        // DELETE: api/Tnguilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTnguild(int id)
        {
            if (_context.Tnguilds == null)
            {
                return NotFound();
            }
            var tnguild = await _context.Tnguilds.FindAsync(id);
            if (tnguild == null)
            {
                return NotFound();
            }

            _context.Tnguilds.Remove(tnguild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TnguildExists(int id)
        {
            return (_context.Tnguilds?.Any(e => e.MasterId == id)).GetValueOrDefault();
        }
    }
}
