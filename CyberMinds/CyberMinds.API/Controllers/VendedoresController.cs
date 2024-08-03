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
    public class VendedoresController : ControllerBase
    {
        private readonly CyberMindsContext _context;

        public VendedoresController(CyberMindsContext context)
        {
            _context = context;
        }

        // GET: api/Vendedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedore>>> GetVendedores()
        {
            return await _context.Vendedores.ToListAsync();
        }

        // GET: api/Vendedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedore>> GetVendedore(int id)
        {
            var vendedore = await _context.Vendedores.FindAsync(id);

            if (vendedore == null)
            {
                return NotFound();
            }

            return vendedore;
        }

        // PUT: api/Vendedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedore(int id, Vendedore vendedore)
        {
            if (id != vendedore.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendedore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedoreExists(id))
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

        // POST: api/Vendedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendedore>> PostVendedore(Vendedore vendedore)
        {
            _context.Vendedores.Add(vendedore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendedore", new { id = vendedore.Id }, vendedore);
        }

        // DELETE: api/Vendedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedore(int id)
        {
            var vendedore = await _context.Vendedores.FindAsync(id);
            if (vendedore == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendedoreExists(int id)
        {
            return _context.Vendedores.Any(e => e.Id == id);
        }
    }
}
