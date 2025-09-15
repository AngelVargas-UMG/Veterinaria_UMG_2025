using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Data;
using VeterinariaAPI.Models;

namespace Veterinaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosSaludController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstadosSaludController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadosSalud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoSalud>>> GetEstadosSalud()
        {
            return await _context.EstadosSalud.ToListAsync();
        }

        // GET: api/EstadosSalud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoSalud>> GetEstadoSalud(int id)
        {
            var estadoSalud = await _context.EstadosSalud.FindAsync(id);

            if (estadoSalud == null)
            {
                return NotFound();
            }

            return estadoSalud;
        }

        // POST: api/EstadosSalud
        [HttpPost]
        public async Task<ActionResult<EstadoSalud>> PostEstadoSalud(EstadoSalud estadoSalud)
        {
            _context.EstadosSalud.Add(estadoSalud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoSalud", new { id = estadoSalud.EstadoSaludID }, estadoSalud);
        }

        // PUT: api/EstadosSalud/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoSalud(int id, EstadoSalud estadoSalud)
        {
            if (id != estadoSalud.EstadoSaludID)
            {
                return BadRequest();
            }

            _context.Entry(estadoSalud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoSaludExists(id))
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

        // DELETE: api/EstadosSalud/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoSalud(int id)
        {
            var estadoSalud = await _context.EstadosSalud.FindAsync(id);
            if (estadoSalud == null)
            {
                return NotFound();
            }

            _context.EstadosSalud.Remove(estadoSalud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoSaludExists(int id)
        {
            return _context.EstadosSalud.Any(e => e.EstadoSaludID == id);
        }
    }
}
