﻿using System;
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
    public class VehiculoController : ControllerBase
    {
        private readonly Context _context;

        public VehiculoController(Context context)
        {
            _context = context;
        }

        // GET: api/Vehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetVehiculo()
        {
          if (_context.Vehiculo == null)
          {
              return NotFound();
          }
            return await _context.Vehiculo.ToListAsync();
        }

        // GET: api/Vehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
          if (_context.Vehiculo == null)
          {
              return NotFound();
          }
            var vehiculos = await _context.Vehiculo.FindAsync(id);

            if (vehiculos == null)
            {
                return NotFound();
            }

            return vehiculos;
        }

        // PUT: api/Vehiculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculos(int id, Vehiculo vehiculos)
        {
            if (id != vehiculos.VehiculoId)
            {
                return BadRequest();
            }

            _context.Entry(vehiculos).State = EntityState.Modified;

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

        // POST: api/Vehiculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculos(Vehiculo vehiculos)
        {
          if (_context.Vehiculo == null)
          {
              return Problem("Entity set 'Context.Vehiculo'  is null.");
          }
            _context.Vehiculo.Add(vehiculos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculo", new { id = vehiculos.VehiculoId }, vehiculos);
        }

        // DELETE: api/Vehiculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculos(int id)
        {
            if (_context.Vehiculo == null)
            {
                return NotFound();
            }
            var vehiculos = await _context.Vehiculo.FindAsync(id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            _context.Vehiculo.Remove(vehiculos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoExists(int id)
        {
            return (_context.Vehiculo?.Any(e => e.VehiculoId == id)).GetValueOrDefault();
        }
    }
}
