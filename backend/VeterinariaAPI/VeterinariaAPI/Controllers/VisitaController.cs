using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Data;
using VeterinariaAPI.Models;

namespace Veterinaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotivosVisitaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MotivosVisitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MotivosVisita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotivosVisita>>> GetMotivosVisita()
        {
            return await _context.MotivosVisitas.ToListAsync();
        }

        // GET: api/MotivosVisita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotivosVisita>> GetMotivosVisita(int id)
        {
            var motivosVisita = await _context.MotivosVisitas.FindAsync(id);

            if (motivosVisita == null)
            {
                return NotFound();
            }

            return motivosVisita;
        }

        // POST: api/MotivosVisita
        [HttpPost]
        public async Task<ActionResult<MotivosVisita>> PostMotivosVisita(MotivosVisita motivosVisita)
        {
            _context.MotivosVisitas.Add(motivosVisita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivosVisita", new { id = motivosVisita.MotivoID }, motivosVisita);
        }

        // PUT: api/MotivosVisita/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivosVisita(int id, MotivosVisita motivosVisita)
        {
            if (id != motivosVisita.MotivoID)
            {
                return BadRequest();
            }

            _context.Entry(motivosVisita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivosVisitaExists(id))
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

        // DELETE: api/MotivosVisita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivosVisita(int id)
        {
            var motivosVisita = await _context.MotivosVisitas.FindAsync(id);
            if (motivosVisita == null)
            {
                return NotFound();
            }

            _context.MotivosVisitas.Remove(motivosVisita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivosVisitaExists(int id)
        {
            return _context.MotivosVisitas.Any(e => e.MotivoID == id);
        }
    }
}
