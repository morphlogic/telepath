﻿using System;
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
    public class ThinkGroupsController : ControllerBase
    {
        private readonly TelepathContext _context;

        public ThinkGroupsController(TelepathContext context)
        {
            _context = context;
        }

        // GET: api/ThinkGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThinkGroup>>> GetThinkGroups()
        {
          if (_context.ThinkGroups == null)
          {
              return NotFound();
          }

            var blah = _context.ThinkGroups.Include(g => g.ThinkMembers).ToList();

            return await _context.ThinkGroups.Include(g => g.ThinkMembers).ToListAsync();
        }

        // GET: api/ThinkGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThinkGroup>> GetThinkGroup(int id)
        {
          if (_context.ThinkGroups == null)
          {
              return NotFound();
          }
            var thinkGroup = await _context.ThinkGroups.FindAsync(id);

            if (thinkGroup == null)
            {
                return NotFound();
            }

            return thinkGroup;
        }

        // PUT: api/ThinkGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThinkGroup(int id, ThinkGroup thinkGroup)
        {
            if (id != thinkGroup.ThinkGroupId)
            {
                return BadRequest();
            }

            _context.Entry(thinkGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThinkGroupExists(id))
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

        // POST: api/ThinkGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThinkGroup>> PostThinkGroup(ThinkGroup thinkGroup)
        {
          if (_context.ThinkGroups == null)
          {
              return Problem("Entity set 'TelepathContext.ThinkGroups'  is null.");
          }
            _context.ThinkGroups.Add(thinkGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThinkGroup", new { id = thinkGroup.ThinkGroupId }, thinkGroup);
        }

        // DELETE: api/ThinkGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThinkGroup(int id)
        {
            if (_context.ThinkGroups == null)
            {
                return NotFound();
            }
            var thinkGroup = await _context.ThinkGroups.FindAsync(id);
            if (thinkGroup == null)
            {
                return NotFound();
            }

            _context.ThinkGroups.Remove(thinkGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThinkGroupExists(int id)
        {
            return (_context.ThinkGroups?.Any(e => e.ThinkGroupId == id)).GetValueOrDefault();
        }
    }
}
