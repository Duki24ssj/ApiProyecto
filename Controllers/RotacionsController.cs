using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProyecto.Context;
using ApiProyecto.Models;

namespace ApiProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotacionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RotacionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Rotacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rotacion>>> GetRotacion()
        {
            return await _context.Rotacion.ToListAsync();
        }

        // GET: api/Rotacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rotacion>> GetRotacion(int id)
        {
            var rotacion = await _context.Rotacion.FindAsync(id);

            if (rotacion == null)
            {
                return NotFound();
            }

            return rotacion;
        }

        // PUT: api/Rotacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotacion(int id, Rotacion rotacion)
        {
            if (id != rotacion.ID_Rotacion)
            {
                return BadRequest();
            }

            _context.Entry(rotacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotacionExists(id))
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

        // POST: api/Rotacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rotacion>> PostRotacion(Rotacion rotacion)
        {
            _context.Rotacion.Add(rotacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRotacion", new { id = rotacion.ID_Rotacion }, rotacion);
        }

        // DELETE: api/Rotacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotacion(int id)
        {
            var rotacion = await _context.Rotacion.FindAsync(id);
            if (rotacion == null)
            {
                return NotFound();
            }

            _context.Rotacion.Remove(rotacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotacionExists(int id)
        {
            return _context.Rotacion.Any(e => e.ID_Rotacion == id);
        }
    }
}
