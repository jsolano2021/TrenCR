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
    public class EstacionesController : Controller
    {
        private readonly TrenCRContext _context;

        public EstacionesController(TrenCRContext context)
        {
            _context = context;
        }

        // GET: Estaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estacion.ToListAsync());
        }

        // GET: Estaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacion = await _context.Estacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacion == null)
            {
                return NotFound();
            }

            return View(estacion);
        }

        // GET: Estaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Estado")] Estacion estacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estacion);
        }

        // GET: Estaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacion = await _context.Estacion.FindAsync(id);
            if (estacion == null)
            {
                return NotFound();
            }
            return View(estacion);
        }

        // POST: Estaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Estado")] Estacion estacion)
        {
            if (id != estacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacionExists(estacion.Id))
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
            return View(estacion);
        }

        // GET: Estaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacion = await _context.Estacion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacion == null)
            {
                return NotFound();
            }

            return View(estacion);
        }

        // POST: Estaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estacion = await _context.Estacion.FindAsync(id);
            _context.Estacion.Remove(estacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacionExists(int id)
        {
            return _context.Estacion.Any(e => e.Id == id);
        }
    }
}
