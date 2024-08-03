using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberMinds.Web.Models;

namespace CyberMinds.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly CyberMindsContext _context;

        public SucursalesController(CyberMindsContext context)
        {
            _context = context;
        }

        // GET: api/Sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursale>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        // GET: api/Sucursales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursale>> GetSucursale(int id)
        {
            var sucursale = await _context.Sucursales.FindAsync(id);

            if (sucursale == null)
            {
                return NotFound();
            }

            return sucursale;
        }

        // PUT: api/Sucursales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursale(int id, Sucursale sucursale)
        {
            if (id != sucursale.Id)
            {
                return BadRequest();
            }

            _context.Entry(sucursale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursaleExists(id))
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

        // POST: api/Sucursales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sucursale>> PostSucursale(Sucursale sucursale)
        {
            _context.Sucursales.Add(sucursale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursale", new { id = sucursale.Id }, sucursale);
        }

        // DELETE: api/Sucursales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursale(int id)
        {
            var sucursale = await _context.Sucursales.FindAsync(id);
            if (sucursale == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursaleExists(int id)
        {
            return _context.Sucursales.Any(e => e.Id == id);
        }
    }
}
