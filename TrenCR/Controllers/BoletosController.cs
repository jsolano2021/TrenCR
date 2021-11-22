using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrenCR.Models;

namespace TrenCR.Controllers
{
    public class BoletosController : Controller
    {
        private readonly TrenCRContext _context;

        public BoletosController(TrenCRContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Rutas"] = new SelectList(_context.Ruta, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult GetHorarios([Bind("Id,Nombre")] Ruta ruta)
        {

            if(ruta != null && ruta.Id > 0)
            {

                var Lista = _context.Horario.Include(e => e.IdEstacionRutaNavigation)
                    .Include(e => e.IdEstacionRutaNavigation.IdEstacionNavigation)
                    .Include(e => e.IdEstacionRutaNavigation.IdRutaNavigation)
                    .ToList().Where(x => x.IdEstacionRutaNavigation.IdRuta == ruta.Id);

 
                ViewData["ListaDatos"] = Lista;
            }

          


            ViewData["Rutas"] = new SelectList(_context.Ruta, "Id", "Nombre"); 
            return View("Index");
        }


        Usuario getUser()
        {
            string json = HttpContext.Session.GetString("Usuario");

            if (!String.IsNullOrEmpty(json))
            {
                Usuario miUsuario = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(json);
                return miUsuario;
            }
            return null;
        }


        public async Task<IActionResult> ComprarBoleto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Horario = await _context.Horario
                .Include(u => u.IdEstacionRutaNavigation)
                .Include(u => u.IdEstacionRutaNavigation.IdEstacionNavigation)
                .Include(u => u.IdEstacionRutaNavigation.IdRutaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Horario == null)
            {
                return NotFound();
            }

            Boleto _boleto = _context.Boleto.Where(x => x.IdHorarioNavigation.IdEstacionRuta == Horario.IdEstacionRuta).FirstOrDefault();
            int Asiento = 1;

            if (_boleto != null)
                Asiento = _boleto.IdHorarioNavigation.IdEstacionRutaNavigation.IdRutaNavigation.Capacidad;

            Horario.Asiento = Asiento;


            return View(Horario);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComprarBoleto(int? id, [Bind("Id,Hora, Asiento")] Horario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Boleto boleto = new Boleto
                    {
                        IdHorario = usuario.Id,
                        Asiento = Convert.ToInt32(ViewBag.Asiento),
                        Hora = usuario.Hora,
                        Fecha = DateTime.Now,
                        IdUsuario = getUser().Id, 
                    };


                    _context.Add(boleto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                } 
            } 
            return View(usuario);
        }







    }
}
