using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Data;
using VeterinariaAPI.Models;

namespace VeterinariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitaProcedimientosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VisitaProcedimientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VisitaProcedimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitaProcedimiento>>> GetVisitaProcedimientos()
        {
            return await _context.VisitaProcedimientos.ToListAsync();
        }

        // GET: api/VisitaProcedimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitaProcedimiento>> GetVisitaProcedimiento(int id)
        {
            var visitaProcedimiento = await _context.VisitaProcedimientos.FindAsync(id);

            if (visitaProcedimiento == null)
            {
                return NotFound();
            }

            return visitaProcedimiento;
        }

        // POST: api/VisitaProcedimientos
        [HttpPost]
        public async Task<ActionResult<VisitaProcedimiento>> PostVisitaProcedimiento(VisitaProcedimiento visitaProcedimiento)
        {
            _context.VisitaProcedimientos.Add(visitaProcedimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitaProcedimiento", new { id = visitaProcedimiento.VisitaProcedimientoID }, visitaProcedimiento);
        }

        // PUT: api/VisitaProcedimientos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitaProcedimiento(int id, VisitaProcedimiento visitaProcedimiento)
        {
            if (id != visitaProcedimiento.VisitaProcedimientoID)
            {
                return BadRequest();
            }

            _context.Entry(visitaProcedimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaProcedimientoExists(id))
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

        // DELETE: api/VisitaProcedimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitaProcedimiento(int id)
        {
            var visitaProcedimiento = await _context.VisitaProcedimientos.FindAsync(id);
            if (visitaProcedimiento == null)
            {
                return NotFound();
            }

            _context.VisitaProcedimientos.Remove(visitaProcedimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitaProcedimientoExists(int id)
        {
            return _context.VisitaProcedimientos.Any(e => e.VisitaProcedimientoID == id);
        }
    }
}
