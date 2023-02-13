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
    public class TproductsController : ControllerBase
    {
        private readonly RohanWebContext _context;

        public TproductsController(RohanWebContext context)
        {
            _context = context;
        }

        // GET: api/Tproducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tproduct>>> GetTproducts()
        {
          if (_context.Tproducts == null)
          {
              return NotFound();
          }
            return await _context.Tproducts.ToListAsync();
        }

        // GET: api/Tproducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tproduct>> GetTproduct(int id)
        {
          if (_context.Tproducts == null)
          {
              return NotFound();
          }
            var tproduct = await _context.Tproducts.FindAsync(id);

            if (tproduct == null)
            {
                return NotFound();
            }

            return tproduct;
        }

        // PUT: api/Tproducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTproduct(int id, Tproduct tproduct)
        {
            if (id != tproduct.Itemid)
            {
                return BadRequest();
            }

            _context.Entry(tproduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TproductExists(id))
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

        // POST: api/Tproducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tproduct>> PostTproduct(Tproduct tproduct)
        {
          if (_context.Tproducts == null)
          {
              return Problem("Entity set 'RohanWebContext.Tproducts'  is null.");
          }
            _context.Tproducts.Add(tproduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTproduct", new { id = tproduct.Itemid }, tproduct);
        }

        // DELETE: api/Tproducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTproduct(int id)
        {
            if (_context.Tproducts == null)
            {
                return NotFound();
            }
            var tproduct = await _context.Tproducts.FindAsync(id);
            if (tproduct == null)
            {
                return NotFound();
            }

            _context.Tproducts.Remove(tproduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TproductExists(int id)
        {
            return (_context.Tproducts?.Any(e => e.Itemid == id)).GetValueOrDefault();
        }
    }
}
