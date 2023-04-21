using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morphware.Telepath.Core;
using Morphware.Telepath.DataAccess;

namespace Morphware.Telepath.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThoughtsController : ControllerBase
    {
        private readonly TelepathContext _context;

        public ThoughtsController(TelepathContext context)
        {
            _context = context;
        }

        // GET: api/Thoughts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thought>>> GetThoughts()
        {
          if (_context.Thoughts == null)
          {
              return NotFound();
          }
            return await _context.Thoughts.ToListAsync();
        }

        // GET: api/Thoughts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thought>> GetThought(int id)
        {
          if (_context.Thoughts == null)
          {
              return NotFound();
          }
            var thought = await _context.Thoughts.FindAsync(id);

            if (thought == null)
            {
                return NotFound();
            }

            return thought;
        }

        // PUT: api/Thoughts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThought(int id, Thought thought)
        {
            if (id != thought.ThoughtId)
            {
                return BadRequest();
            }

            _context.Entry(thought).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThoughtExists(id))
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

        // POST: api/Thoughts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thought>> PostThought(Thought thought)
        {
          if (_context.Thoughts == null)
          {
              return Problem("Entity set 'TelepathContext.Thoughts'  is null.");
          }
            _context.Thoughts.Add(thought);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThought", new { id = thought.ThoughtId }, thought);
        }

        // DELETE: api/Thoughts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThought(int id)
        {
            if (_context.Thoughts == null)
            {
                return NotFound();
            }
            var thought = await _context.Thoughts.FindAsync(id);
            if (thought == null)
            {
                return NotFound();
            }

            _context.Thoughts.Remove(thought);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThoughtExists(int id)
        {
            return (_context.Thoughts?.Any(e => e.ThoughtId == id)).GetValueOrDefault();
        }
    }
}
