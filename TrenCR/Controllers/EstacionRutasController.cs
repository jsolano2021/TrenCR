using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrenCR.Models;

namespace TrenCR.Controllers
{
    public class EstacionRutasController : Controller
    {
        private readonly TrenCRContext _context;

        public EstacionRutasController(TrenCRContext context)
        {
            _context = context;
        }

        // GET: EstacionRutas
        public async Task<IActionResult> Index()
        {
            var trenCRContext = _context.EstacionRuta.Include(e => e.IdEstacionNavigation).Include(e => e.IdRutaNavigation);
            return View(await trenCRContext.ToListAsync());
        }

        // GET: EstacionRutas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacionRuta = await _context.EstacionRuta
                .Include(e => e.IdEstacionNavigation)
                .Include(e => e.IdRutaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionRuta == null)
            {
                return NotFound();
            }

            return View(estacionRuta);
        }

        // GET: EstacionRutas/Create
        public IActionResult Create()
        {
            ViewData["IdEstacion"] = new SelectList(_context.Estacion, "Id", "Nombre");
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "Id", "Nombre");
            return View();
        }

        // POST: EstacionRutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdRuta,IdEstacion")] EstacionRuta estacionRuta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estacionRuta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstacion"] = new SelectList(_context.Estacion, "Id", "Nombre", estacionRuta.IdEstacion);
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "Id", "Nombre", estacionRuta.IdRuta);
            return View(estacionRuta);
        }

        // GET: EstacionRutas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacionRuta = await _context.EstacionRuta.FindAsync(id);
            if (estacionRuta == null)
            {
                return NotFound();
            }
            ViewData["IdEstacion"] = new SelectList(_context.Estacion, "Id", "Nombre", estacionRuta.IdEstacion);
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "Id", "Nombre", estacionRuta.IdRuta);
            return View(estacionRuta);
        }

        // POST: EstacionRutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdRuta,IdEstacion,Estado")] EstacionRuta estacionRuta)
        {
            if (id != estacionRuta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacionRuta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionRutaExists(estacionRuta.Id))
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
            ViewData["IdEstacion"] = new SelectList(_context.Estacion, "Id", "Nombre", estacionRuta.IdEstacion);
            ViewData["IdRuta"] = new SelectList(_context.Ruta, "Id", "Nombre", estacionRuta.IdRuta);
            return View(estacionRuta);
        }

        // GET: EstacionRutas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacionRuta = await _context.EstacionRuta
                .Include(e => e.IdEstacionNavigation)
                .Include(e => e.IdRutaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacionRuta == null)
            {
                return NotFound();
            }

            return View(estacionRuta);
        }

        // POST: EstacionRutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estacionRuta = await _context.EstacionRuta.FindAsync(id);
            _context.EstacionRuta.Remove(estacionRuta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacionRutaExists(int id)
        {
            return _context.EstacionRuta.Any(e => e.Id == id);
        }
    }
}
