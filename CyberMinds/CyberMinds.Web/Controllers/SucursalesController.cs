using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CyberMinds.Web.Models;

namespace CyberMinds.Web.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly CyberMindsContext _context;

        public SucursalesController(CyberMindsContext context)
        {
            _context = context;
        }

        // GET: Sucursales
        public async Task<IActionResult> Index(string buscar)
        {
            // Método para buscar en la tabla cliente
            var sucursales = from sucursal in _context.Sucursales select sucursal;

            if (!String.IsNullOrEmpty(buscar))
            {
                // Método para buscar el nombre o apellido en la tabla cliente
                sucursales = sucursales.Where(c => c.Nombre!.Contains(buscar) || c.Direccion!.Contains(buscar) || c.Ciudad!.Contains(buscar) || c.Estado!.Contains(buscar) || c.Pais!.Contains(buscar));
            }

            return View(await sucursales.ToListAsync());
        }



        // GET: Sucursales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursale = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursale == null)
            {
                return NotFound();
            }

            return View(sucursale);
        }

        // GET: Sucursales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Ciudad,Estado,Pais")] Sucursale sucursale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursale);
        }

        // GET: Sucursales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursale = await _context.Sucursales.FindAsync(id);
            if (sucursale == null)
            {
                return NotFound();
            }
            return View(sucursale);
        }

        // POST: Sucursales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Ciudad,Estado,Pais")] Sucursale sucursale)
        {
            if (id != sucursale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursaleExists(sucursale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sucursale);
        }

        // GET: Sucursales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursale = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sucursale == null)
            {
                return NotFound();
            }

            return View(sucursale);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursale = await _context.Sucursales.FindAsync(id);
            if (sucursale != null)
            {
                _context.Sucursales.Remove(sucursale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SucursaleExists(int id)
        {
            return _context.Sucursales.Any(e => e.Id == id);
        }
    }
}
