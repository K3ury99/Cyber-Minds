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
    public class VendedoresController : Controller
    {
        private readonly CyberMindsContext _context;

        public VendedoresController(CyberMindsContext context)
        {
            _context = context;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index(string buscar)
        {
            // Método para buscar en la tabla cliente
            var vendedores = from vendedor in _context.Vendedores select vendedor;

            if (!String.IsNullOrEmpty(buscar))
            {
                // Método para buscar el nombre o apellido en la tabla cliente
                vendedores = vendedores.Where(c => c.Nombre!.Contains(buscar) || c.Apellido!.Contains(buscar) || c.Email!.Contains(buscar) || c.Telefono!.Contains(buscar));
            }

            return View(await vendedores.ToListAsync());
        }



        // GET: Vendedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedore = await _context.Vendedores
                .Include(v => v.Sucursal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedore == null)
            {
                return NotFound();
            }

            return View(vendedore);
        }

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "Id", "Id");
            return View();
        }

        // POST: Vendedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,Telefono,SucursalId")] Vendedore vendedore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "Id", "Id", vendedore.SucursalId);
            return View(vendedore);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedore = await _context.Vendedores.FindAsync(id);
            if (vendedore == null)
            {
                return NotFound();
            }
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "Id", "Id", vendedore.SucursalId);
            return View(vendedore);
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Telefono,SucursalId")] Vendedore vendedore)
        {
            if (id != vendedore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedoreExists(vendedore.Id))
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
            ViewData["SucursalId"] = new SelectList(_context.Sucursales, "Id", "Id", vendedore.SucursalId);
            return View(vendedore);
        }

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedore = await _context.Vendedores
                .Include(v => v.Sucursal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedore == null)
            {
                return NotFound();
            }

            return View(vendedore);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedore = await _context.Vendedores.FindAsync(id);
            if (vendedore != null)
            {
                _context.Vendedores.Remove(vendedore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedoreExists(int id)
        {
            return _context.Vendedores.Any(e => e.Id == id);
        }
    }
}
