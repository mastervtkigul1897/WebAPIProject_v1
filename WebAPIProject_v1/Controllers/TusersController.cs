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
    public class TusersController : ControllerBase
    {
        private readonly RohanUserContext _context;

        public TusersController(RohanUserContext context)
        {
            _context = context;
        }

        // GET: api/Tusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tuser>>> GetTusers()
        {
          if (_context.Tusers == null)
          {
              return NotFound();
          }
            return await _context.Tusers.ToListAsync();
        }

        // GET: api/Tusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tuser>> GetTuser(int id)
        {
          if (_context.Tusers == null)
          {
              return NotFound();
          }
            var tuser = await _context.Tusers.FindAsync(id);

            if (tuser == null)
            {
                return NotFound();
            }

            return tuser;
        }

        // PUT: api/Tusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTuser(int id, Tuser tuser)
        {
            if (id != tuser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(tuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuserExists(id))
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

        // POST: api/Tusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tuser>> PostTuser(Tuser tuser)
        {
          if (_context.Tusers == null)
          {
              return Problem("Entity set 'RohanUserContext.Tusers'  is null.");
          }
            _context.Tusers.Add(tuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTuser", new { id = tuser.UserId }, tuser);
        }

        // DELETE: api/Tusers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTuser(int id)
        {
            if (_context.Tusers == null)
            {
                return NotFound();
            }
            var tuser = await _context.Tusers.FindAsync(id);
            if (tuser == null)
            {
                return NotFound();
            }

            _context.Tusers.Remove(tuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TuserExists(int id)
        {
            return (_context.Tusers?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
