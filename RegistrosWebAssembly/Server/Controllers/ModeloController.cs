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
    public class ModeloController : ControllerBase
    {
        private readonly Context _context;

        public ModeloController(Context context)
        {
            _context = context;
        }

        // GET: api/Accesorio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoDetalle>>> GetVehiculo()
        {
          if (_context.Accesorio == null)
          {
              return NotFound();
          }
            return await _context.Accesorio.ToListAsync();
        }

        // GET: api/Accesorio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoDetalle>> GetVehiculos(int id)
        {
          if (_context.Accesorio == null)
          {
              return NotFound();
          }
            var tickets = await _context.Accesorio.FindAsync(id);

            if (tickets == null)
            {
                return NotFound();
            }

            return tickets;
        }

        // PUT: api/Accesorio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, VehiculoDetalle vehiculo)
        {
            if (id != vehiculo.AccesorioId)
            {
                return BadRequest();
            }

            _context.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
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

        // POST: api/Accesorio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoDetalle>> PostVehiculo(VehiculoDetalle vehiculo)
        {
          if (_context.Accesorio == null)
          {
              return Problem("Entity set 'Context.Accesorio'  is null.");
          }
            _context.Accesorio.Add(vehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculo", new { id = vehiculo.AccesorioId }, vehiculo);
        }

        // DELETE: api/Accesorio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculos(int id)
        {
            if (_context.Accesorio == null)
            {
                return NotFound();
            }
            var vehiculos = await _context.Accesorio.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            _context.Accesorio.Remove(vehiculos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return (_context.Accesorio?.Any(e => e.AccesorioId == id)).GetValueOrDefault();
        }
    }
}
