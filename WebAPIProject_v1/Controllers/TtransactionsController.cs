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
    public class TtransactionsController : ControllerBase
    {
        private readonly RohanWebContext _context;

        public TtransactionsController(RohanWebContext context)
        {
            _context = context;
        }

        // GET: api/Ttransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ttransaction>>> GetTtransactions()
        {
          if (_context.Ttransactions == null)
          {
              return NotFound();
          }
            return await _context.Ttransactions.ToListAsync();
        }

        // GET: api/Ttransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ttransaction>> GetTtransaction(int id)
        {
          if (_context.Ttransactions == null)
          {
              return NotFound();
          }
            var ttransaction = await _context.Ttransactions.FindAsync(id);

            if (ttransaction == null)
            {
                return NotFound();
            }

            return ttransaction;
        }

        // PUT: api/Ttransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTtransaction(int id, Ttransaction ttransaction)
        {
            if (id != ttransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(ttransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TtransactionExists(id))
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

        // POST: api/Ttransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ttransaction>> PostTtransaction(Ttransaction ttransaction)
        {
          if (_context.Ttransactions == null)
          {
              return Problem("Entity set 'RohanWebContext.Ttransactions'  is null.");
          }
            _context.Ttransactions.Add(ttransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTtransaction", new { id = ttransaction.Id }, ttransaction);
        }

        // DELETE: api/Ttransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTtransaction(int id)
        {
            if (_context.Ttransactions == null)
            {
                return NotFound();
            }
            var ttransaction = await _context.Ttransactions.FindAsync(id);
            if (ttransaction == null)
            {
                return NotFound();
            }

            _context.Ttransactions.Remove(ttransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TtransactionExists(int id)
        {
            return (_context.Ttransactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
