using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RegistrosWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        private readonly Context _context;

        public PrioridadesController(Context context)
        {
            _context = context;
        }

        // GET: api/Prioridades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accesorio>>> GetPrioridades()
        {
          if (_context.Prioridades == null)
          {
              return NotFound();
          }
            return await _context.Prioridades.ToListAsync();
        }

        // GET: api/Prioridades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accesorio>> GetPrioridades(int id)
        {
          if (_context.Prioridades == null)
          {
              return NotFound();
          }
            var prioridades = await _context.Prioridades.FindAsync(id);

            if (prioridades == null)
            {
                return NotFound();
            }

            return prioridades;
        }

        // PUT: api/Prioridades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrioridades(int id, Accesorio prioridades)
        {
            if (id != prioridades.AccesorioId)
            {
                return BadRequest();
            }

            _context.Entry(prioridades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrioridadesExists(id))
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

        // POST: api/Prioridades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accesorio>> PostPrioridades(Accesorio prioridades)
        {
          if (_context.Prioridades == null)
          {
              return Problem("Entity set 'Context.Prioridades'  is null.");
          }
            _context.Prioridades.Add(prioridades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrioridades", new { id = prioridades.AccesorioId }, prioridades);
        }

        // DELETE: api/Prioridades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrioridades(int id)
        {
            if (_context.Prioridades == null)
            {
                return NotFound();
            }
            var prioridades = await _context.Prioridades.FindAsync(id);
            if (prioridades == null)
            {
                return NotFound();
            }

            _context.Prioridades.Remove(prioridades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrioridadesExists(int id)
        {
            return (_context.Prioridades?.Any(e => e.AccesorioId == id)).GetValueOrDefault();
        }
    }
}
