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
    public class Registro_EntradaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Registro_EntradaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Registro_Entrada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registro_Entrada>>> GetRegistro_Entrada()
        {
            return await _context.Registro_Entrada.ToListAsync();
        }

        // GET: api/Registro_Entrada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registro_Entrada>> GetRegistro_Entrada(int id)
        {
            var registro_Entrada = await _context.Registro_Entrada.FindAsync(id);

            if (registro_Entrada == null)
            {
                return NotFound();
            }

            return registro_Entrada;
        }

        // PUT: api/Registro_Entrada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro_Entrada(int id, Registro_Entrada registro_Entrada)
        {
            if (id != registro_Entrada.ID_Registro_Entrada)
            {
                return BadRequest();
            }

            _context.Entry(registro_Entrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Registro_EntradaExists(id))
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

        // POST: api/Registro_Entrada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registro_Entrada>> PostRegistro_Entrada(Registro_Entrada registro_Entrada)
        {
            _context.Registro_Entrada.Add(registro_Entrada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistro_Entrada", new { id = registro_Entrada.ID_Registro_Entrada }, registro_Entrada);
        }

        // DELETE: api/Registro_Entrada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro_Entrada(int id)
        {
            var registro_Entrada = await _context.Registro_Entrada.FindAsync(id);
            if (registro_Entrada == null)
            {
                return NotFound();
            }

            _context.Registro_Entrada.Remove(registro_Entrada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Registro_EntradaExists(int id)
        {
            return _context.Registro_Entrada.Any(e => e.ID_Registro_Entrada == id);
        }
    }
}
