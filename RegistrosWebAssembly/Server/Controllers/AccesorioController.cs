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
    public class AccesorioController : ControllerBase
    {
        private readonly Context _context;

        public AccesorioController(Context context)
        {
            _context = context;
        }

        // GET: api/Accesorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accesorio>>> GetAccesorio()
        {
          if (_context.Accesorios == null)
          {
              return NotFound();
          }
            return await _context.Accesorios.ToListAsync();
        }

        // GET: api/Accesorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accesorio>> GetAccesorio(int id)
        {
          if (_context.Accesorios == null)
          {
              return NotFound();
          }
            var Accesorio = await _context.Accesorios.FindAsync(id);

            if (Accesorio == null)
            {
                return NotFound();
            }

            return Accesorio;
        }

        // PUT: api/Accesorios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccesorios(int id, Accesorio accesorio)
        {
            if (id != accesorio.AccesorioId)
            {
                return BadRequest();
            }

            _context.Entry(accesorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccesorioExists(id))
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

        // POST: api/Accesorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accesorio>> PostAccesorio(Accesorio accesorio)
        {
          if (_context.Accesorios == null)
          {
              return Problem("Entity set 'Context.Accesorios'  is null.");
          }
            _context.Accesorios.Add(accesorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccesorio", new { id = accesorio.AccesorioId }, accesorio);
        }

        // DELETE: api/Accesorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccesorio(int id)
        {
            if (_context.Accesorios == null)
            {
                return NotFound();
            }
            var accesorio = await _context.Accesorios.FindAsync(id);
            if (accesorio == null)
            {
                return NotFound();
            }

            _context.Accesorios.Remove(accesorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccesorioExists(int id)
        {
            return (_context.Accesorios?.Any(e => e.AccesorioId == id)).GetValueOrDefault();
        }
    }
}
