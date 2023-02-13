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
    public class TcharacterLoginsController : ControllerBase
    {
        private readonly RohanGameContext _context;

        public TcharacterLoginsController(RohanGameContext context)
        {
            _context = context;
        }

        // GET: api/TcharacterLogins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TcharacterLogin>>> GetTcharacterLogins()
        {
          if (_context.TcharacterLogins == null)
          {
              return NotFound();
          }
            return await _context.TcharacterLogins.ToListAsync();
        }

        // GET: api/TcharacterLogins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TcharacterLogin>> GetTcharacterLogin(int id)
        {
          if (_context.TcharacterLogins == null)
          {
              return NotFound();
          }
            var tcharacterLogin = await _context.TcharacterLogins.FindAsync(id);

            if (tcharacterLogin == null)
            {
                return NotFound();
            }

            return tcharacterLogin;
        }

        // PUT: api/TcharacterLogins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTcharacterLogin(int id, TcharacterLogin tcharacterLogin)
        {
            if (id != tcharacterLogin.CharId)
            {
                return BadRequest();
            }

            _context.Entry(tcharacterLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TcharacterLoginExists(id))
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

        // POST: api/TcharacterLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TcharacterLogin>> PostTcharacterLogin(TcharacterLogin tcharacterLogin)
        {
          if (_context.TcharacterLogins == null)
          {
              return Problem("Entity set 'RohanGameContext.TcharacterLogins'  is null.");
          }
            _context.TcharacterLogins.Add(tcharacterLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TcharacterLoginExists(tcharacterLogin.CharId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTcharacterLogin", new { id = tcharacterLogin.CharId }, tcharacterLogin);
        }

        // DELETE: api/TcharacterLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTcharacterLogin(int id)
        {
            if (_context.TcharacterLogins == null)
            {
                return NotFound();
            }
            var tcharacterLogin = await _context.TcharacterLogins.FindAsync(id);
            if (tcharacterLogin == null)
            {
                return NotFound();
            }

            _context.TcharacterLogins.Remove(tcharacterLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TcharacterLoginExists(int id)
        {
            return (_context.TcharacterLogins?.Any(e => e.CharId == id)).GetValueOrDefault();
        }
    }
}
