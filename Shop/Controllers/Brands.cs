using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ApiAkhmetovContext _context;

        public BrandsController(ApiAkhmetovContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> CreateBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrand), new { id = brand.BrandId }, brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, Brand brand)
        {
            if (id != brand.BrandId)
                return BadRequest();

            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
