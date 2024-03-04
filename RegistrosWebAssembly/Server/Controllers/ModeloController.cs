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

        // GET: api/Modelo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoDetalle>>> GetTickets()
        {
          if (_context.Modelo == null)
          {
              return NotFound();
          }
            return await _context.Modelo.ToListAsync();
        }

        // GET: api/Modelo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoDetalle>> GetTickets(int id)
        {
          if (_context.Modelo == null)
          {
              return NotFound();
          }
            var tickets = await _context.Modelo.FindAsync(id);

            if (tickets == null)
            {
                return NotFound();
            }

            return tickets;
        }

        // PUT: api/Modelo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets(int id, VehiculoDetalle tickets)
        {
            if (id != tickets.ModeloId)
            {
                return BadRequest();
            }

            _context.Entry(tickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(id))
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

        // POST: api/Modelo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoDetalle>> PostTickets(VehiculoDetalle tickets)
        {
          if (_context.Modelo == null)
          {
              return Problem("Entity set 'Context.Modelo'  is null.");
          }
            _context.Modelo.Add(tickets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTickets", new { id = tickets.ModeloId }, tickets);
        }

        // DELETE: api/Modelo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            if (_context.Modelo == null)
            {
                return NotFound();
            }
            var tickets = await _context.Modelo.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.Modelo.Remove(tickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketsExists(int id)
        {
            return (_context.Modelo?.Any(e => e.ModeloId == id)).GetValueOrDefault();
        }
    }
}
