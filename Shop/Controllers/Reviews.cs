using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        private readonly ApiAkhmetovContext _context;

        public ReviewsController(ApiAkhmetovContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetTrips()
        {
            return Ok(_context.Specifications.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTrip(int id)
        {
            var trip = _context.Specifications.Find(id);
            if (trip == null) return NotFound();
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip(Specification trip)
        {
            _context.Specifications.Add(trip);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrip), new { id = trip.SpecificationId }, trip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, Specification trip)
        {
            if (id != trip.SpecificationId) return BadRequest();

            _context.Entry(trip).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var trip = await _context.Specifications.FindAsync(id);
            if (trip == null) return NotFound();

            _context.Specifications.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
