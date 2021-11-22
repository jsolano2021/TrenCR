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
    public class HorariosController : Controller
    {
        private readonly TrenCRContext _context;

        public HorariosController(TrenCRContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var trenCRContext =  from e in _context.Horario.Include(h => h.IdEstacionRutaNavigation)
                                                .Include(h => h.IdEstacionRutaNavigation.IdEstacionNavigation)
                                                .Include(h => h.IdEstacionRutaNavigation.IdRutaNavigation)

                                 select new Horario
                                 {
                                     Id = e.Id,
                                     Estado = e.Estado,
                                     Hora = e.Hora,
                                     IdEstacionRuta = e.IdEstacionRuta,
                                     IdEstacionRutaNavigation = new EstacionRuta
                                     {
                                         Id = e.IdEstacionRutaNavigation.Id,
                                         IdEstacion = e.IdEstacionRutaNavigation.IdEstacion,
                                         IdRuta = e.IdEstacionRutaNavigation.IdRuta,
                                         Estado = e.IdEstacionRutaNavigation.Estado,
                                         IdRutaNavigation = e.IdEstacionRutaNavigation.IdRutaNavigation,
                                         IdEstacionNavigation = new Estacion
                                         {
                                             Id = e.IdEstacionRutaNavigation.IdEstacionNavigation.Id,
                                             Nombre = e.IdEstacionRutaNavigation.IdEstacionNavigation.Nombre + "(" + e.IdEstacionRutaNavigation.IdRutaNavigation.Nombre + ")",
                                             Estado = e.IdEstacionRutaNavigation.IdRutaNavigation.Estado
                                         }
                                     }
                                 };


            return View(await trenCRContext.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.IdEstacionRutaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        { 

            var lista = from e in _context.EstacionRuta.Include(h => h.IdEstacionNavigation).Include(h => h.IdRutaNavigation)
                        orderby e.IdRutaNavigation.Id ascending
                        select new HorarioEstacion
                       {
                           idEstacionRuta = e.Id,
                           EstacionRuta = e.IdEstacionNavigation.Nombre + " (" + e.IdRutaNavigation.Nombre + ") "
                       };

            ViewData["IdEstacionRuta"] = new SelectList(lista, "idEstacionRuta", "EstacionRuta");

            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEstacionRuta, Hora")] HorarioEstacion valor)
        {
            if (ModelState.IsValid)
            {
                Horario horario1 = new Horario
                {
                    Hora = valor.Hora,
                    IdEstacionRuta = valor.idEstacionRuta
                };

                _context.Add(horario1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            var lista = _context.EstacionRuta.Include(h => h.IdEstacionNavigation); 
            ViewData["IdEstacionRuta"] = new SelectList(lista, "Id", "IdEstacionNavigation.Nombre");

            return View(valor);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }

            var lista = _context.EstacionRuta.Include(h => h.IdEstacionNavigation);
            ViewData["IdEstacionRuta"] = new SelectList(lista, "Id", "IdEstacionNavigation.Nombre");

            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEstacionRuta,Hora,Estado")] Horario horario)
        {
            if (id != horario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.Id))
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

            var lista = _context.EstacionRuta.Include(h => h.IdEstacionNavigation);
            ViewData["IdEstacionRuta"] = new SelectList(lista, "Id", "IdEstacionNavigation.Nombre");

            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario = await _context.Horario
                .Include(h => h.IdEstacionRutaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.FindAsync(id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.Id == id);
        }
    }
}
