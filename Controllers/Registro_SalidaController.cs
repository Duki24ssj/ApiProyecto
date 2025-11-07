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
    public class Registro_SalidaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Registro_SalidaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Registro_Salida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registro_Salida>>> GetRegistro_Salida()
        {
            return await _context.Registro_Salida.ToListAsync();
        }

        // GET: api/Registro_Salida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registro_Salida>> GetRegistro_Salida(int id)
        {
            var registro_Salida = await _context.Registro_Salida.FindAsync(id);

            if (registro_Salida == null)
            {
                return NotFound();
            }

            return registro_Salida;
        }

        // PUT: api/Registro_Salida/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro_Salida(int id, Registro_Salida registro_Salida)
        {
            if (id != registro_Salida.ID_Registro_Salida)
            {
                return BadRequest();
            }

            _context.Entry(registro_Salida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_SalidaExists(id))
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

        // POST: api/Registro_Salida
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registro_Salida>> PostRegistro_Salida(Registro_Salida registro_Salida)
        {
            _context.Registro_Salida.Add(registro_Salida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro_Salida", new { id = registro_Salida.ID_Registro_Salida }, registro_Salida);
        }

        // DELETE: api/Registro_Salida/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro_Salida(int id)
        {
            var registro_Salida = await _context.Registro_Salida.FindAsync(id);
            if (registro_Salida == null)
            {
                return NotFound();
            }

            _context.Registro_Salida.Remove(registro_Salida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Registro_SalidaExists(int id)
        {
            return _context.Registro_Salida.Any(e => e.ID_Registro_Salida == id);
        }
    }
}
