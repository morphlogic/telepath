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
    public class ThinkMembersController : ControllerBase
    {
        private readonly TelepathContext _context;

        public ThinkMembersController(TelepathContext context)
        {
            _context = context;
        }

        // GET: api/ThinkMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThinkMember>>> GetThinkMembers()
        {
          if (_context.ThinkMembers == null)
          {
              return NotFound();
          }
            return await _context.ThinkMembers.Include(m => m.ThinkGroups).ToListAsync();
        }

        // GET: api/ThinkMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThinkMember>> GetThinkMember(int id)
        {
          if (_context.ThinkMembers == null)
          {
              return NotFound();
          }
            var thinkMember = await _context.ThinkMembers.FindAsync(id);

            if (thinkMember == null)
            {
                return NotFound();
            }

            return thinkMember;
        }

        // PUT: api/ThinkMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThinkMember(int id, ThinkMember thinkMember)
        {
            if (id != thinkMember.ThinkMemberId)
            {
                return BadRequest();
            }

            _context.Entry(thinkMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThinkMemberExists(id))
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

        // POST: api/ThinkMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThinkMember>> PostThinkMember(ThinkMember thinkMember)
        {
          if (_context.ThinkMembers == null)
          {
              return Problem("Entity set 'TelepathContext.ThinkMembers'  is null.");
          }
            _context.ThinkMembers.Add(thinkMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThinkMember", new { id = thinkMember.ThinkMemberId }, thinkMember);
        }

        // DELETE: api/ThinkMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThinkMember(int id)
        {
            if (_context.ThinkMembers == null)
            {
                return NotFound();
            }
            var thinkMember = await _context.ThinkMembers.FindAsync(id);
            if (thinkMember == null)
            {
                return NotFound();
            }

            _context.ThinkMembers.Remove(thinkMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThinkMemberExists(int id)
        {
            return (_context.ThinkMembers?.Any(e => e.ThinkMemberId == id)).GetValueOrDefault();
        }
    }
}
