using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseWebApi.Data;
using BaseWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CowsController : ControllerBase
    {
        private readonly SolAppContext _context;

        public CowsController(SolAppContext context)
        {
            _context = context;
        }

        // GET: api/Cows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cow>>> GetCow()
        {
          if (_context.Cow == null)
          {
              return NotFound();
          }
            return await _context.Cow.ToListAsync();
        }

        // GET: api/Cows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cow>> GetCow(long id)
        {
          if (_context.Cow == null)
          {
              return NotFound();
          }
            var cow = await _context.Cow.FindAsync(id);

            if (cow == null)
            {
                return NotFound();
            }

            return cow;
        }

        // PUT: api/Cows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCow(long id, Cow cow)
        {
            if (id != cow.Id)
            {
                return BadRequest();
            }

            _context.Entry(cow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CowExists(id))
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

        // POST: api/Cows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cow>> PostCow(Cow cow)
        {
          if (_context.Cow == null)
          {
              return Problem("Entity set 'SolAppContext.Cow'  is null.");
          }
            _context.Cow.Add(cow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCow", new { id = cow.Id }, cow);
        }

        // DELETE: api/Cows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCow(long id)
        {
            if (_context.Cow == null)
            {
                return NotFound();
            }
            var cow = await _context.Cow.FindAsync(id);
            if (cow == null)
            {
                return NotFound();
            }

            _context.Cow.Remove(cow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CowExists(long id)
        {
            return (_context.Cow?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
