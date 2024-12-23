using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApiAkhmetovContext _context;

        public SupplierController(ApiAkhmetovContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetTrips()
        {
            return Ok(_context.Suppliers.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTrip(int id)
        {
            var trip = _context.Suppliers.Find(id);
            if (trip == null) return NotFound();
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip(Supplier trip)
        {
            _context.Suppliers.Add(trip);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrip), new { id = trip.SupplierId }, trip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, Supplier trip)
        {
            if (id != trip.SupplierId) return BadRequest();

            _context.Entry(trip).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var trip = await _context.Suppliers.FindAsync(id);
            if (trip == null) return NotFound();

            _context.Suppliers.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
