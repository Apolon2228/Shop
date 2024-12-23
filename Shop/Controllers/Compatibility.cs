using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompatibilityController : ControllerBase
    {
        private readonly ApiAkhmetovContext _context;

        public CompatibilityController(ApiAkhmetovContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compatibility>>> GetCompatibilities()
        {
            return await _context.Compatibilities.Include(c => c.ProductId1).Include(c => c.ProductId2).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compatibility>> GetCompatibility(int id)
        {
            var compatibility = await _context.Compatibilities.Include(c => c.ProductId1).Include(c => c.ProductId2).FirstOrDefaultAsync(c => c.CompatibilityId == id);
            if (compatibility == null)
                return NotFound();
            return compatibility;
        }

        [HttpPost]
        public async Task<ActionResult<Compatibility>> CreateCompatibility(Compatibility compatibility)
        {
            _context.Compatibilities.Add(compatibility);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCompatibility), new { id = compatibility.CompatibilityId }, compatibility);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompatibility(int id, Compatibility compatibility)
        {
            if (id != compatibility.CompatibilityId)
                return BadRequest();

            _context.Entry(compatibility).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompatibility(int id)
        {
            var compatibility = await _context.Compatibilities.FindAsync(id);
            if (compatibility == null)
                return NotFound();

            _context.Compatibilities.Remove(compatibility);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
