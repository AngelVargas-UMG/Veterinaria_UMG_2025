using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeterinariaAPI.Data;
using VeterinariaAPI.Models;

namespace Veterinaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedimientosMedicosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProcedimientosMedicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProcedimientosMedicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedimientoMedico>>> GetProcedimientosMedicos()
        {
            return await _context.ProcedimientosMedicos.ToListAsync();
        }

        // GET: api/ProcedimientosMedicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedimientoMedico>> GetProcedimientoMedico(int id)
        {
            var procedimientoMedico = await _context.ProcedimientosMedicos.FindAsync(id);

            if (procedimientoMedico == null)
            {
                return NotFound();
            }

            return procedimientoMedico;
        }

        // POST: api/ProcedimientosMedicos
        [HttpPost]
        public async Task<ActionResult<ProcedimientoMedico>> PostProcedimientoMedico(ProcedimientoMedico procedimientoMedico)
        {
            _context.ProcedimientosMedicos.Add(procedimientoMedico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedimientoMedico", new { id = procedimientoMedico.ProcedimientoID }, procedimientoMedico);
        }

        // PUT: api/ProcedimientosMedicos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedimientoMedico(int id, ProcedimientoMedico procedimientoMedico)
        {
            if (id != procedimientoMedico.ProcedimientoID)
            {
                return BadRequest();
            }

            _context.Entry(procedimientoMedico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedimientoMedicoExists(id))
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

        // DELETE: api/ProcedimientosMedicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedimientoMedico(int id)
        {
            var procedimientoMedico = await _context.ProcedimientosMedicos.FindAsync(id);
            if (procedimientoMedico == null)
            {
                return NotFound();
            }

            _context.ProcedimientosMedicos.Remove(procedimientoMedico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcedimientoMedicoExists(int id)
        {
            return _context.ProcedimientosMedicos.Any(e => e.ProcedimientoID == id);
        }
    }
}
