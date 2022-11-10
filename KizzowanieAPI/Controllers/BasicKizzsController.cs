using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KizzowanieAPI;

namespace KizzowanieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicKizzsController : ControllerBase
    {
        private readonly KizzowanieDbContext _context;

        public BasicKizzsController(KizzowanieDbContext context)
        {
            _context = context;
        }

        // GET: api/BasicKizzs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicKizz>>> GetBasicKizz()
        {
            return await _context.BasicKizz.ToListAsync();
        }

        // GET: api/BasicKizzs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicKizz>> GetBasicKizz(int id)
        {
            var basicKizz = await _context.BasicKizz.FindAsync(id);

            if (basicKizz == null)
            {
                return NotFound();
            }

            return basicKizz;
        }

        // PUT: api/BasicKizzs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBasicKizz(int id, BasicKizz basicKizz)
        {
            if (id != basicKizz.BasicKizzId)
            {
                return BadRequest();
            }

            _context.Entry(basicKizz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasicKizzExists(id))
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

        // POST: api/BasicKizzs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BasicKizz>> PostBasicKizz(BasicKizz basicKizz)
        {
            _context.BasicKizz.Add(basicKizz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBasicKizz", new { id = basicKizz.BasicKizzId }, basicKizz);
        }

        // DELETE: api/BasicKizzs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BasicKizz>> DeleteBasicKizz(int id)
        {
            var basicKizz = await _context.BasicKizz.FindAsync(id);
            if (basicKizz == null)
            {
                return NotFound();
            }

            _context.BasicKizz.Remove(basicKizz);
            await _context.SaveChangesAsync();

            return basicKizz;
        }

        private bool BasicKizzExists(int id)
        {
            return _context.BasicKizz.Any(e => e.BasicKizzId == id);
        }
    }
}
